using System.Text.Json.Serialization;

namespace RenphoGarminSync.Garmin.Shared.Models.Responses
{

    public class BodyCompositionResult
    {
        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }

        [JsonPropertyName("dateWeightList")]
        public DateWeightEntry[] Entries { get; set; }

        [JsonPropertyName("totalAverage")]
        public AverageWeightEntry TotalAverage { get; set; }
    }

    public class AverageWeightEntry
    {
        [JsonPropertyName("from")]
        public long? From { get; set; }

        [JsonPropertyName("until")]
        public long? Until { get; set; }

        [JsonPropertyName("weight")]
        public float? Weight { get; set; }

        [JsonPropertyName("bmi")]
        public float? Bmi { get; set; }

        [JsonPropertyName("bodyFat")]
        public float? BodyFat { get; set; }

        [JsonPropertyName("bodyWater")]
        public float? BodyWater { get; set; }

        [JsonPropertyName("boneMass")]
        public int? BoneMass { get; set; }

        [JsonPropertyName("muscleMass")]
        public int? MuscleMass { get; set; }

        [JsonPropertyName("physiqueRating")]
        public string PhysiqueRating { get; set; }

        [JsonPropertyName("visceralFat")]
        public int? VisceralFat { get; set; }

        [JsonPropertyName("metabolicAge")]
        public float? MetabolicAge { get; set; }
    }

    public class DateWeightEntry
    {
        [JsonPropertyName("samplePk")]
        public long? SamplePk { get; set; }

        [JsonPropertyName("date")]
        public long? Date { get; set; }

        [JsonPropertyName("calendarDate")]
        public string CalendarDate { get; set; }

        [JsonPropertyName("weight")]
        public float? Weight { get; set; }

        [JsonPropertyName("bmi")]
        public float? Bmi { get; set; }

        [JsonPropertyName("bodyFat")]
        public float? BodyFat { get; set; }

        [JsonPropertyName("bodyWater")]
        public float? BodyWater { get; set; }

        [JsonPropertyName("boneMass")]
        public int? BoneMass { get; set; }

        [JsonPropertyName("muscleMass")]
        public int? MuscleMass { get; set; }

        [JsonPropertyName("physiqueRating")]
        public string PhysiqueRating { get; set; }

        [JsonPropertyName("visceralFat")]
        public int? VisceralFat { get; set; }

        [JsonPropertyName("metabolicAge")]
        public float? MetabolicAge { get; set; }

        [JsonPropertyName("sourceType")]
        public string SourceType { get; set; }

        [JsonPropertyName("timestampGMT")]
        public long? TimestampGMT { get; set; }

        [JsonPropertyName("weightDelta")]
        public float? WeightDelta { get; set; }
    }

}
