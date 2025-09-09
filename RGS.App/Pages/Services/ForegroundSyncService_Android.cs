namespace RGS.App.Services;

public class ForegroundSyncService_Android
{
#if ANDROID
    public Task StartOneShotForegroundSyncAsync()
    {
        var ctx = Android.App.Application.Context;
        var intent = new Android.Content.Intent(ctx, typeof(Platforms.Android.ForegroundService));
        ctx.StartForegroundService(intent);
        return Task.CompletedTask;
    }
#else
    public Task StartOneShotForegroundSyncAsync() => Task.CompletedTask;
#endif
}

