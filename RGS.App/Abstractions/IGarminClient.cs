namespace RGS.App.Abstractions;

public interface IGarminClient
{
    Task UploadBodyCompositionAsync(BodyMeasurement m, CancellationToken ct = default);
    Task EnsureLoginAsync(CancellationToken ct = default);
}

