using RGS.App.Abstractions;

namespace RGS.App.Services;

public class SyncService
{
    private readonly IRenphoClient _renpho;
    private readonly IGarminClient _garmin;
    private readonly ILogSink _log;

    public SyncService(IRenphoClient renpho, IGarminClient garmin, ILogSink log)
    { _renpho = renpho; _garmin = garmin; _log = log; }

    public async Task<SyncResult> RunOnceAsync(DateTime sinceUtc, CancellationToken ct = default)
    {
        try
        {
            _log.Info("Starting sync...");
            await _renpho.EnsureLoginAsync(ct);
            await _garmin.EnsureLoginAsync(ct);

            var list = await _renpho.GetMeasurementsAsync(sinceUtc, ct);
            int uploaded = 0;
            foreach (var m in list)
            {
                await _garmin.UploadBodyCompositionAsync(m, ct);
                uploaded++;
            }

            _log.Info($"Done. Uploaded {uploaded} measurements.");
            return new SyncResult(uploaded);
        }
        catch (Exception ex)
        {
            _log.Error(ex.ToString());
            return new SyncResult(0, ex.Message);
        }
    }
}

public record SyncResult(int UploadedCount, string? Error = null);

