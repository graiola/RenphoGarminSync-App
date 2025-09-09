using Microsoft.Maui.Hosting;
using RGS.App.Services;
using RGS.App.ViewModels;
using RGS.App.Pages;
using RGS.App.Abstractions;

namespace RGS.App;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder()
            .UseMauiApp<App>();

        // ViewModels
        builder.Services.AddSingleton<HomeViewModel>();
        builder.Services.AddSingleton<SettingsViewModel>();
        builder.Services.AddSingleton<LogsViewModel>();

        // Services
        builder.Services.AddSingleton<TokenStore>();
        builder.Services.AddSingleton<ILogSink, MemoryLogSink>();
        builder.Services.AddSingleton<SyncService>();
        builder.Services.AddSingleton<ForegroundSyncService_Android>();

        // API clients (stub for now — wire real implementations later)
        builder.Services.AddSingleton<IRenphoClient, StubRenphoClient>();
        builder.Services.AddSingleton<IGarminClient, StubGarminClient>();

        // Pages
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<SettingsPage>();
        builder.Services.AddSingleton<LogsPage>();

        return builder.Build();
    }
}

