using RenphoGarminSync.Console.Models;
using RenphoGarminSync.Garmin.Api;
using RenphoGarminSync.Garmin.Auth;
using RenphoGarminSync.Garmin.Auth.Authenticators;
using RenphoGarminSync.Garmin.Auth.Persistence;
using RenphoGarminSync.Garmin.Shared.Exceptions;
using RenphoGarminSync.Garmin.Shared.Models;
using Spectre.Console;
using System;
using System.Threading.Tasks;

namespace RenphoGarminSync.Console
{
    public class GarminAuthCommandHandler
    {
        private readonly string _mfaCode;

        private readonly IGarminAuthService _garminAuthService;
        private readonly IGarminApi _garminApi;
        private readonly AppConfig _config;

        public GarminAuthCommandHandler(string username, string password, string mfaCode)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(username);

            _mfaCode = mfaCode;

            _config = ConfigurationHelper.GetApplicationConfig();
            var authCache = new GarminFileBasedAuthCache(_config.General.CachePath);
            var authApi = new GarminAuthApi(_config.Garmin);
            _garminAuthService = new GarminAuthService(username, password, authCache, authApi);

            var authenticator = new GarminApiAuthenticator(_garminAuthService);
            _garminApi = new GarminApi(_config.Garmin, authenticator);
        }

        public async Task<int> InvokeAsync()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(_mfaCode))
                    await _garminAuthService.FinishMFAProcessAsync(_mfaCode);

                var user = await _garminApi.GetUserProfile();
                AnsiConsole.MarkupLineInterpolated($"Logged in as: [bold green]{user.FullName}[/]");
                return 0;
            }
            catch (GarminException ex) when (ex.StatusCode == GarminStatusCode.MfaRequired)
            {
                AnsiConsole.MarkupLine($"[maroon]Multi-Factor Authentication is set up for this user, please run the command again and include the mfaCode parameter[/]");
                return 1;
            }
            catch (GarminException ex)
            {
                AnsiConsole.MarkupLineInterpolated($"[maroon]Garmin Exception encountered, code: [yellow]{ex.StatusCode}[/], message: [yellow]{ex.Message}[/][/]");
                return 1;
            }
        }
    }
}
