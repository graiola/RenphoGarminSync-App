using RenphoGarminSync.Renpho.Shared.Models;
using RenphoGarminSync.Renpho.Shared.Models.Responses;
using RestSharp;
using System.Threading.Tasks;

namespace RenphoGarminSync.Renpho.Auth.Authenticators
{
    public class RenphoApiAuthenticator : IRenphoAuthenticator
    {
        private readonly IRenphoAuthService _authService;
        private readonly RenphoConfig _config;

        public RenphoApiAuthenticator(IRenphoAuthService authService, RenphoConfig config)
        {
            _authService = authService;
            _config = config;
        }

        public async ValueTask Authenticate(IRestClient client, RestRequest request)
        {
            var token = await _authService.GetActiveSessionTokenAsync();

            request.AddHeader("token", token.Token);
            request.AddHeader("userId", token.UserId.Value.ToString());
            request.AddHeader("appVersion", _config.AppVersion);
            request.AddHeader("platform", _config.Platform);
        }

        public async Task<long> GetLoggedInUserIdAsync() => await _authService.GetLoggedInUserIdAsync();

        public async Task<RenphoUser> GetLoggedInUserInfoAsync() => await _authService.GetLoggedInUserInfoAsync();

        public async Task InvalidateSessionAsync() => await _authService.InvalidateSessionAsync();
    }
}
