using CsvHelper;
using CsvHelper.Configuration;
using RenphoGarminSync.ConsoleApp.Persistence;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RenphoGarminSync.Console.Persistence
{
    public class CSVHandledMeasurementsRepository : IHandledMeasurementsRepository
    {
        const string CSV_FILE_NAME = "measurements.csv";
        private readonly string _basePath;

        public CSVHandledMeasurementsRepository(string basePath)
        {
            _basePath = basePath;
        }

        public async Task<long?> GetLatestHandledMeasurementTimestampAsync(long userId)
        {
            if (!Directory.Exists(_basePath))
                return null;

            var filePath = Path.Combine(_basePath, CSV_FILE_NAME);
            if (!File.Exists(filePath))
                return null;

            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var latestResult = await csv.GetRecordsAsync<MeasurementEntry>()
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.Timestamp)
                .FirstOrDefaultAsync();

            return latestResult?.Timestamp;
        }

        public async Task<bool> IsMeasurementAlreadyHandledAsync(long id)
        {
            if (!Directory.Exists(_basePath))
                return false;

            var filePath = Path.Combine(_basePath, CSV_FILE_NAME);
            if (!File.Exists(filePath))
                return false;

            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return await csv.GetRecordsAsync<MeasurementEntry>().AnyAsync(x => x.MeasurementId == id);
        }

        public async Task<IEnumerable<long>> FilterOutHandledMeasurementsAsync(long userId, IEnumerable<long> measurementIds)
        {
            if (measurementIds?.Any() != true)
                return measurementIds;

            if (!Directory.Exists(_basePath))
                return measurementIds;

            var filePath = Path.Combine(_basePath, CSV_FILE_NAME);
            if (!File.Exists(filePath))
                return measurementIds;

            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var csvRecords = await csv.GetRecordsAsync<MeasurementEntry>().ToListAsync();

            var alreadyHandledMeasurements = csvRecords
                .Where(x => x.UserId == userId)
                .Select(x =>x.MeasurementId)
                .Distinct()
                .ToHashSet();

            return measurementIds
                .Where(x => !alreadyHandledMeasurements.Contains(x));
        }

        public async Task MarkMeasurementAsHandledAsync(long userId, long id, long timestamp)
        {
            Directory.CreateDirectory(_basePath);

            var entry = new MeasurementEntry
            {
                UserId = userId,
                MeasurementId = id,
                Timestamp = timestamp,
            };

            var filePath = Path.Combine(_basePath, CSV_FILE_NAME);
            var addHeader = !File.Exists(filePath);
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = addHeader,
            };

            using var stream = File.Open(filePath, FileMode.Append, FileAccess.Write);
            using var writer = new StreamWriter(stream);
            using var csv = new CsvWriter(writer, config);
            await csv.WriteRecordsAsync([entry]);
        }
    }

    public record MeasurementEntry
    {
        public long UserId { get; set; }
        public long MeasurementId { get; set; }
        public long Timestamp { get; set; }
    }
}
