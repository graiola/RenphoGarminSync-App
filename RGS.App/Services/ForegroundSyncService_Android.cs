namespace RGS.App.Services;

public class ForegroundSyncService_Android
{
#if ANDROID
    public Task StartOneShotForegroundSyncAsync()
    {
        var ctx = Android.App.Application.Context;
        var intent = new Android.Content.Intent(
            ctx, typeof(RGS.App.Platforms.Android.SyncForegroundService));

        if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            ctx.StartForegroundService(intent); // API 26+
        else
            ctx.StartService(intent);           // < 26

        return Task.CompletedTask;
    }
#else
    public Task StartOneShotForegroundSyncAsync() => Task.CompletedTask;
#endif
}

