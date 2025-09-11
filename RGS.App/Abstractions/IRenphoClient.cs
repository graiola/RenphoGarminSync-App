namespace RGS.App.Abstractions;

public interface IRenphoClient
{
    Task<IReadOnlyList<BodyMeasurement>> GetMeasurementsAsync(DateTime sinceUtc, CancellationToken ct = default);
    Task EnsureLoginAsync(CancellationToken ct = default);
}

