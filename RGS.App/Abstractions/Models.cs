namespace RGS.App.Abstractions;

public record BodyMeasurement(
    DateTime TimestampUtc,
    double WeightKg,
    double? BodyFatPct = null,
    double? Bmi = null,
    double? MuscleMassKg = null,
    double? WaterPct = null
);

// Temporary stubs so the app compiles; replace with real clients wired to the CLI libs.
public class StubRenphoClient : IRenphoClient
{
    public Task EnsureLoginAsync(CancellationToken ct = default) => Task.CompletedTask;
    public Task<IReadOnlyList<BodyMeasurement>> GetMeasurementsAsync(DateTime sinceUtc, CancellationToken ct = default)
        => Task.FromResult<IReadOnlyList<BodyMeasurement>>(new[]
        {
            new BodyMeasurement(DateTime.UtcNow.AddMinutes(-10), 79.3, 15.8, 23.0, 38.2, 58.0)
        });
}

public class StubGarminClient : IGarminClient
{
    public Task EnsureLoginAsync(CancellationToken ct = default) => Task.CompletedTask;
    public Task UploadBodyCompositionAsync(BodyMeasurement m, CancellationToken ct = default) => Task.CompletedTask;
}

