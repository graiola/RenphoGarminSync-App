using RenphoGarminSync.Renpho.Auth.Models;
using RenphoGarminSync.Renpho.Auth.Persistence;
using RenphoGarminSync.Renpho.Shared.Exceptions;
using RenphoGarminSync.Renpho.Shared.Models;
using RenphoGarminSync.Renpho.Shared.Models.Responses;
using System;
using System.Threading.Tasks;

namespace RenphoGarminSync.Renpho.Auth
{
    public class RenphoAuthService : IRenphoAuthService
    {
        private readonly string _username;
        private readonly string _password;
        private readonly IRenphoAuthCache _authCache;
        private readonly IRenphoAuthApi _authApi;

        public RenphoAuthService(string username, string password, IRenphoAuthCache authCache, IRenphoAuthApi authApi)
        {
            _username = username;
            _password = password;
            _authCache = authCache;
            _authApi = authApi;
        }

        public async Task<long> GetLoggedInUserIdAsync()
        {
            var authState = await GetActiveSessionTokenAsync();
            return authState.UserId.Value;
        }

        public async Task<RenphoUser> GetLoggedInUserInfoAsync()
        {
            var authState = await GetActiveSessionTokenAsync();
            return authState.User;
        }

        public async Task InvalidateSessionAsync()
        {
            await _authCache.InvalidateAuthEntryAsync(_username);
        }

        public async Task<RenphoAuthToken> GetActiveSessionTokenAsync()
        {
            var authState = await _authCache.GetAuthEntryAsync(_username);
            if (authState is null || IsTokenExpired(authState))
            {
                authState = await RetrieveNewTokenAsync();
                await _authCache.UpdateAuthEntryAsync(_username, authState);
            }

            if (authState is null)
                throw new RenphoException(RenphoStatusCode.CUSTOM_AUTH_FAILED, "Token not assigned");

            if (string.IsNullOrWhiteSpace(authState.Token))
                throw new RenphoException(RenphoStatusCode.CUSTOM_AUTH_FAILED, "Token invalid");

            if (!authState.UserId.HasValue || authState.UserId <= 0)
                throw new RenphoException(RenphoStatusCode.CUSTOM_AUTH_FAILED, "Invalid or missing user id");

            return authState;
        }

        private async Task<RenphoAuthToken> RetrieveNewTokenAsync()
        {
            var loginResult = await _authApi.LoginAsync(_username, _password);
            var authState = await GetTokenWithFilledTimeAsync(loginResult.Login.Token, loginResult.Login.Id);
            authState.User = loginResult.Login;
            return authState;
        }

        private async Task<RenphoAuthToken> GetTokenWithFilledTimeAsync(string token, long userId)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(token);
            if (userId <= 0)
                throw new ArgumentException("User ID Invalid", nameof(userId));

            var tokenTime = await _authApi.GetTokenTimeAsync(token, userId);
            if (tokenTime.UserId != userId)
                throw new RenphoException(RenphoStatusCode.CUSTOM_AUTH_FAILED, "Token info userId doesn't match provided userId");

            return new RenphoAuthToken
            {
                Token = token,
                UserId = tokenTime.UserId,
                ExpiresAt = tokenTime.ExpiresAt,
                IssuedAt = tokenTime.IssuedAt,
            };
        }

        private bool IsTokenExpired(RenphoAuthToken token)
        {
            if (token is null)
                return true;

            var curUnix = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            if (curUnix >= token.ExpiresAt)
                return true;

            return false;
        }
    }
}
