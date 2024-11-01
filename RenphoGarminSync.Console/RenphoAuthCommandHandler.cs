using RenphoGarminSync.Console.Models;
using RenphoGarminSync.Renpho.Auth;
using RenphoGarminSync.Renpho.Auth.Persistence;
using RenphoGarminSync.Renpho.Shared.Exceptions;
using Spectre.Console;
using System;
using System.Threading.Tasks;

namespace RenphoGarminSync.Console
{
    public class RenphoAuthCommandHandler
    {
        private readonly IRenphoAuthService _authService;
        private readonly AppConfig _config;

        public RenphoAuthCommandHandler(string username, string password)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(username);
            ArgumentException.ThrowIfNullOrWhiteSpace(password);

            _config = ConfigurationHelper.GetApplicationConfig();
            var renphoAuthCache = new RenphoInMemoryAuthCache();
            var renphoAuthApi = new RenphoAuthApi(_config.Renpho);
            _authService = new RenphoAuthService(username, password, renphoAuthCache, renphoAuthApi);
        }

        public async Task<int> InvokeAsync()
        {
            try
            {
                var user = await _authService.GetLoggedInUserInfoAsync();
                AnsiConsole.MarkupLineInterpolated($"Logged in as: [bold green]{user.AccountName}[/]");
                return 0;
            }
            catch (RenphoException ex)
            {
                AnsiConsole.MarkupLineInterpolated($"[maroon]Renpho Exception encountered, code: [yellow]{ex.StatusCode}[/], message: [yellow]{ex.Message}[/][/]");
                return 1;
            }
        }
    }
}
