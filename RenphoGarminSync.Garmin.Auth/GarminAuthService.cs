using RenphoGarminSync.Garmin.Auth.Models;
using RenphoGarminSync.Garmin.Shared.Exceptions;
using RenphoGarminSync.Garmin.Shared.Models;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace RenphoGarminSync.Garmin.Auth
{
    public class GarminAuthService : IGarminAuthService
    {
        private readonly string _username;
        private readonly string _password;
        private readonly IGarminAuthCache _authCache;
        private readonly IGarminAuthApi _authApi;

        public GarminAuthService(string username, string password, IGarminAuthCache authCache, IGarminAuthApi authApi)
        {
            _username = username;
            _password = password;
            _authCache = authCache;
            _authApi = authApi;
        }

        public async Task InvalidateSessionAsync()
        {
            var authEntry = await _authCache.GetAuthEntryAsync(_username);
            if (authEntry is null)
                return;

            if (authEntry?.Stage != AuthStage.Completed || authEntry.OAuth2Token is null)
                return;

            authEntry.OAuth2Token = null;
            await _authCache.UpdateAuthEntryAsync(_username, authEntry);
        }

        public async Task FinishMFAProcessAsync(string mfaCode)
        {
            var authEntry = await _authCache.GetAuthEntryAsync(_username);
            if (authEntry?.Stage != AuthStage.NeedMfaToken)
                throw new GarminException(GarminStatusCode.UnexpectedMfa, "MFA token is not required for this user yet");

            if (authEntry.MFAState.IsExpired)
                throw new GarminException(GarminStatusCode.InvalidMfaCode, "MFA request has expired, please start a new auth process first");

            try
            {
                var cookiesCollection = JsonSerializer.Deserialize<CookieCollection>(authEntry.MFAState.CookieContainer);
                _authApi.AddCookies(cookiesCollection);

                var ticketResult = await _authApi.ConfirmMFACodeAsync(mfaCode, authEntry.MFAState.MFACsrfToken);
                authEntry.OAuth1Token = await _authApi.GetOAuth1TokenAsync(ticketResult.ServiceTicket, ticketResult.ServiceUrl);
                authEntry.MFAState = null;
                authEntry.Stage = AuthStage.Completed;
            }
            finally
            {
                await _authCache.UpdateAuthEntryAsync(_username, authEntry);
            }
        }

        public async Task<OAuth2Token> GetActiveSessionTokenAsync()
        {
            var authEntry = await _authCache.GetAuthEntryAsync(_username);
            if (authEntry?.Stage == AuthStage.Completed && authEntry.OAuth2Token?.IsExpired == false)
                return authEntry.OAuth2Token;

            authEntry ??= new GarminAuthEntry
            {
                Username = _username,
                Stage = AuthStage.None,
            };

            try
            {
                if (authEntry?.Stage == AuthStage.NeedMfaToken)
                {
                    if (!authEntry.MFAState.IsExpired)
                        throw new GarminException(GarminStatusCode.MfaNotFinished, "MFA is not yet finished");
                }

                await AssignActiveOAuth1TokenAsync(authEntry);
                await AssignActiveOAuth2TokenAsync(authEntry);

                if (authEntry.OAuth2Token is null || authEntry.OAuth2Token.IsExpired)
                    throw new GarminException(GarminStatusCode.AuthAppearedSuccessful, "Couldn't retrieve OAuth2 token");

                authEntry.Stage = AuthStage.Completed;
                return authEntry.OAuth2Token;
            }
            finally
            {
                await _authCache.UpdateAuthEntryAsync(_username, authEntry);
            }
        }

        private async Task AssignActiveOAuth1TokenAsync(GarminAuthEntry authEntry)
        {
            if (authEntry.OAuth1Token is not null && !authEntry.OAuth1Token.IsExpired)
                return;

            InvalidateOAuth1Token(authEntry);

            var ticketResult = await _authApi.GetServiceTicketAsync(_username, _password);
            if (ticketResult.MFAState is not null)
            {
                authEntry.Stage = AuthStage.NeedMfaToken;
                authEntry.MFAState = ticketResult.MFAState;
                await _authCache.UpdateAuthEntryAsync(_username, authEntry);
                throw new GarminException(GarminStatusCode.MfaRequired, "MFA code required to finish authorization process");
            }

            authEntry.OAuth1Token = await _authApi.GetOAuth1TokenAsync(ticketResult.ServiceTicket, ticketResult.ServiceUrl);
        }

        private async Task AssignActiveOAuth2TokenAsync(GarminAuthEntry authEntry)
        {
            ArgumentNullException.ThrowIfNull(authEntry);
            if (authEntry.OAuth2Token is not null && !authEntry.OAuth2Token.IsExpired)
                return;

            InvalidateOAuth2Token(authEntry);
            try
            {
                authEntry.OAuth2Token = await _authApi.ExchangeOAuth1ForOAuth2Async(authEntry.OAuth1Token);
            }
            catch (GarminException ex) when (ex.StatusCode is GarminStatusCode.OAuth1TokenInvalid)
            {
                InvalidateOAuth1Token(authEntry);
                throw;
            }
        }

        private void InvalidateOAuth2Token(GarminAuthEntry authEntry)
        {
            ArgumentNullException.ThrowIfNull(authEntry);
            authEntry.OAuth2Token = null;
        }

        private void InvalidateOAuth1Token(GarminAuthEntry authEntry)
        {
            ArgumentNullException.ThrowIfNull(authEntry);
            InvalidateOAuth2Token(authEntry);
            authEntry.OAuth1Token = null;
            authEntry.MFAState = null;
            authEntry.Stage = AuthStage.None;
        }
    }
}
