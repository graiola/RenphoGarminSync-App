using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.Core.App;
using Microsoft.Maui;
using Microsoft.Extensions.DependencyInjection;

namespace RGS.App.Platforms.Android;

// Dichiarare il tipo FGS è richiesto con targetSdk 34 (Android 14)
[Service(
    Exported = true,
    ForegroundServiceType = global::Android.Content.PM.ForegroundService.TypeDataSync)]
public class SyncForegroundService : Service
{
    public override IBinder? OnBind(Intent? intent) => null;

    public override StartCommandResult OnStartCommand(Intent? intent, StartCommandFlags flags, int startId)
    {
        var notification = BuildNotification("RGS Sync", "Sync in progress…");
        StartForeground(1, notification);

        _ = Task.Run(async () =>
        {
            var services = IPlatformApplication.Current?.Services
                           ?? throw new InvalidOperationException("ServiceProvider unavailable");

            var svc = services.GetRequiredService<RGS.App.Services.SyncService>();
            await svc.RunOnceAsync(DateTime.UtcNow.AddDays(-7));

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Tiramisu) // API 33+
                StopForeground(StopForegroundFlags.Remove);
            else
                StopForeground(true);

            StopSelf();
        });

        return StartCommandResult.NotSticky;
    }

    Notification BuildNotification(string title, string text)
    {
        const string channelId = "rgs_sync";
        var mgr = (NotificationManager)GetSystemService(NotificationService)!;
        if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            mgr.CreateNotificationChannel(new NotificationChannel(channelId, "RGS Sync", NotificationImportance.Low));

        return new NotificationCompat.Builder(this, channelId)
            .SetContentTitle(title)
            .SetContentText(text)
            .SetSmallIcon(global::Android.Resource.Drawable.StatNotifySync) // ← icona di sistema
            .SetOngoing(true)
            .Build();
    }
}

