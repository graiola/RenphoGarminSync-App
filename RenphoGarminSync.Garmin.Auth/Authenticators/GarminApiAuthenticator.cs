using RestSharp;
using RestSharp.Authenticators.OAuth2;
using System;
using System.Threading.Tasks;

namespace RenphoGarminSync.Garmin.Auth.Authenticators
{
    public class GarminApiAuthenticator : IGarminAuthenticator
    {
        private readonly IGarminAuthService _authService;

        public GarminApiAuthenticator(IGarminAuthService authService)
        {
            ArgumentNullException.ThrowIfNull(authService);
            _authService = authService;
        }

        public async ValueTask Authenticate(IRestClient client, RestRequest request)
        {
            var authToken = await _authService.GetActiveSessionTokenAsync();
            var finalAuthenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(authToken.AccessToken, authToken.TokenType);
            await finalAuthenticator.Authenticate(client, request);
        }

        public async Task InvalidateSessionAsync()
        {
            await _authService.InvalidateSessionAsync();
        }
    }
}
