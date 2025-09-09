using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RGS.App.Services;

namespace RGS.App.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    private readonly SyncService _sync;
    private readonly ForegroundSyncService_Android _fgSvc;
    private readonly IServiceProvider _sp;

    [ObservableProperty] private string _lastResult = "Idle.";

    public HomeViewModel(SyncService sync, ForegroundSyncService_Android fgSvc, IServiceProvider sp)
    { _sync = sync; _fgSvc = fgSvc; _sp = sp; }

    [RelayCommand]
    private async Task SyncNow()
    {
#if ANDROID
        await _fgSvc.StartOneShotForegroundSyncAsync();
#else
        var res = await _sync.RunOnceAsync(DateTime.UtcNow.AddDays(-7));
        LastResult = $"Uploaded: {res.UploadedCount} @ {DateTime.Now:t}";
#endif
    }

    [RelayCommand] private Task ConnectRenpho() => Shell.Current.DisplayAlert("Renpho", "TODO: implement login", "OK");
    [RelayCommand] private Task ConnectGarmin() => Shell.Current.DisplayAlert("Garmin", "TODO: implement login", "OK");

    [RelayCommand] private Task GoSettings() => Shell.Current.Navigation.PushAsync(_sp.GetRequiredService<Pages.SettingsPage>());
    [RelayCommand] private Task GoLogs()     => Shell.Current.Navigation.PushAsync(_sp.GetRequiredService<Pages.LogsPage>());
}

