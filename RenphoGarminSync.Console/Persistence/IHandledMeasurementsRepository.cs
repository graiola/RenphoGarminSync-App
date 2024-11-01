using System.Collections.Generic;
using System.Threading.Tasks;

namespace RenphoGarminSync.ConsoleApp.Persistence
{
    public interface IHandledMeasurementsRepository
    {
        Task<long?> GetLatestHandledMeasurementTimestampAsync(long userId);
        Task MarkMeasurementAsHandledAsync(long userId, long id, long timestamp);
        Task<bool> IsMeasurementAlreadyHandledAsync(long id);
        Task<IEnumerable<long>> FilterOutHandledMeasurementsAsync(long userId, IEnumerable<long> measurementIds);
    }
}
