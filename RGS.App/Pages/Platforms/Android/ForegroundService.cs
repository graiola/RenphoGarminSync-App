using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.Core.App;
using Microsoft.Maui;

namespace RGS.App.Platforms.Android;

[Service(Exported = true, ForegroundServiceType = Android.Content.PM.ForegroundService.TypeDataSync)]
public class ForegroundService : Service
{
    public override IBinder? OnBind(Intent? intent) => null;

    public override StartCommandResult OnStartCommand(Intent? intent, StartCommandFlags flags, int startId)
    {
        var notification = BuildNotification("RGS Sync", "Sync in progress…");
        StartForeground(1, notification);

        _ = Task.Run(async () =>
        {
            var svc = MauiApplication.Current.Services.GetService<RGS.App.Services.SyncService>()!;
            await svc.RunOnceAsync(DateTime.UtcNow.AddDays(-7));
            StopForeground(true);
            StopSelf();
        });

        return StartCommandResult.NotSticky;
    }

    Notification BuildNotification(string title, string text)
    {
        var channelId = "rgs_sync";
        var mgr = (NotificationManager)GetSystemService(NotificationService)!;
        if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
        {
            var channel = new NotificationChannel(channelId, "RGS Sync", NotificationImportance.Low);
            mgr.CreateNotificationChannel(channel);
        }

        var builder = new NotificationCompat.Builder(this, channelId)
            .SetContentTitle(title)
            .SetContentText(text)
            .SetSmallIcon(Resource.Drawable.ic_stat_notify_dot) // add a 24x24 dp notif icon to Resources/drawable
            .SetOngoing(true);

        return builder.Build();
    }
}

