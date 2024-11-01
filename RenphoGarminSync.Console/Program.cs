using RenphoGarminSync.Console;
using Spectre.Console;
using System;
using System.CommandLine;
using System.Threading.Tasks;

namespace RenphoGarminSync.ConsoleApp
{
    public class Program
    {
        static async Task<int> Main(string[] args)
        {
            var rootCommand = new RootCommand();
            rootCommand.AddCommand(GenerateAuthCommands());
            rootCommand.AddCommand(GenerateSyncCommand());

            return await rootCommand.InvokeAsync(args);
        }

        static Command GenerateAuthCommands()
        {
            var authCommand = new Command("auth", "Check and configure authorization for different services.");
            authCommand.AddCommand(GenerateGarminAuthCommand());
            authCommand.AddCommand(GenerateRenphoAuthCommand());
            return authCommand;
        }

        static Command GenerateGarminAuthCommand()
        {

            var usernameOption = new Option<string>(["--username", "--u"], "Garmin username/email.");
            usernameOption.IsRequired = true;

            var passwordOption = new Option<string>(["--password", "--pw"], "Garmin password.");
            passwordOption.IsRequired = false;

            var mfaCodeOption = new Option<string>(["--mfaCode", "--mfa"], "Multi Factor Authentication code.");
            mfaCodeOption.IsRequired = false;

            var garminAuthCommand = new Command("garmin", "Check and configure garmin authorization.")
            {
                usernameOption,
                passwordOption,
                mfaCodeOption,
            };

            garminAuthCommand.SetHandler(async (context) =>
            {
                var username = context.ParseResult.GetValueForOption(usernameOption);
                var password = context.ParseResult.GetValueForOption(passwordOption);
                var mfaCode = context.ParseResult.GetValueForOption(mfaCodeOption);

                try
                {
                    var command = new GarminAuthCommandHandler(username, password, mfaCode);
                    var exitCode = await command.InvokeAsync();
                    context.ExitCode = exitCode;
                }
                catch (Exception ex)
                {
                    AnsiConsole.WriteException(ex);
                    context.ExitCode = 1;
                }
            });

            return garminAuthCommand;
        }

        static Command GenerateRenphoAuthCommand()
        {

            var usernameOption = new Option<string>(["--username", "--u"], "Renpho username/email.");
            usernameOption.IsRequired = true;

            var passwordOption = new Option<string>(["--password", "--pw"], "Renpho password.");
            passwordOption.IsRequired = true;

            var renphoAuthCommand = new Command("renpho", "Check and configure renpho authorization.")
            {
                usernameOption,
                passwordOption,
            };

            renphoAuthCommand.SetHandler(async (context) =>
            {
                var username = context.ParseResult.GetValueForOption(usernameOption);
                var password = context.ParseResult.GetValueForOption(passwordOption);

                try
                {
                    var command = new RenphoAuthCommandHandler(username, password);
                    var exitCode = await command.InvokeAsync();
                    context.ExitCode = exitCode;
                }
                catch (Exception ex)
                {
                    AnsiConsole.WriteException(ex);
                    context.ExitCode = 1;
                }
            });

            return renphoAuthCommand;
        }

        static Command GenerateSyncCommand()
        {

            var garminUsernameOption = new Option<string>(["--garminUsername", "--gu"], "Garmin username/email.");
            garminUsernameOption.IsRequired = true;

            var garminPasswordOption = new Option<string>(["--garminPassword", "--gpw"], "Garmin password.");
            garminPasswordOption.IsRequired = false;

            var renphoUsernameOption = new Option<string>(["--renphoUsername", "--ru"], "Renpho username/email.");
            renphoUsernameOption.IsRequired = true;

            var renphoPasswordOption = new Option<string>(["--renphoPassword", "--rpw"], "Renpho password.");
            renphoPasswordOption.IsRequired = true;

            var renphoProfileOption = new Option<string>(["--renphoProfile", "--rprofile"], "Renpho profile.");
            renphoProfileOption.IsRequired = false;
            renphoProfileOption.SetDefaultValue(string.Empty);

            var dryRunOption = new Option<bool>(["--dry-run"], "Should only check for new measurements, without actually processing any of the entries.");
            dryRunOption.IsRequired = false;
            dryRunOption.SetDefaultValue(false);

            var noFitFilesOption = new Option<bool>(["--no-fit-files"], "Should skip saving of the FIT files before sending them to Garmin.");
            noFitFilesOption.IsRequired = false;
            noFitFilesOption.SetDefaultValue(false);

            var syncCommand = new Command("sync", "Sync Renpho body measurements with Garmin.")
            {
                garminUsernameOption,
                garminPasswordOption,
                renphoUsernameOption,
                renphoPasswordOption,
                renphoProfileOption,
                dryRunOption,
                noFitFilesOption
            };

            syncCommand.SetHandler(async (context) =>
            {
                var garminUsername = context.ParseResult.GetValueForOption(garminUsernameOption);
                var garminPassword = context.ParseResult.GetValueForOption(garminPasswordOption);
                var renphoUsername = context.ParseResult.GetValueForOption(renphoUsernameOption);
                var renphoPassword = context.ParseResult.GetValueForOption(renphoPasswordOption);
                var renphoProfile = context.ParseResult.GetValueForOption(renphoProfileOption);
                var dryRun = context.ParseResult.GetValueForOption(dryRunOption);
                var noFitFiles = context.ParseResult.GetValueForOption(noFitFilesOption);

                try
                {
                    var command = new RenphoGarminSyncCommandHandler(garminUsername, garminPassword, renphoUsername, renphoPassword, renphoProfile, dryRun, noFitFiles);
                    var exitCode = await command.InvokeAsync();
                    context.ExitCode = exitCode;
                }
                catch (Exception ex)
                {
                    AnsiConsole.WriteException(ex);
                    context.ExitCode = 1;
                }
            });

            return syncCommand;
        }
    }
}
