using System.Text.Json.Serialization;

namespace RenphoGarminSync.Renpho.Shared.Models.Responses
{
    public class GetDeviceInfoResponse
    {
        [JsonPropertyName("scaleGoal")]
        public int? ScaleGoal { get; set; }

        [JsonPropertyName("rope")]
        public int? Rope { get; set; }

        [JsonPropertyName("treadmillFat")]
        public int? TreadmillFat { get; set; }

        [JsonPropertyName("girth")]
        public int? Girth { get; set; }

        [JsonPropertyName("scale")]
        public Scale[] Scale { get; set; }

        [JsonPropertyName("treadmill")]
        public Treadmill Treadmill { get; set; }

        [JsonPropertyName("scaleGoalV2")]
        public int? ScaleGoalV2 { get; set; }

        [JsonPropertyName("girthGoal")]
        public int? GirthGoal { get; set; }

    }

    public class Treadmill
    {
        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("hasMileageUnitSet")]
        public bool? HasMileageUnitSet { get; set; }

        [JsonPropertyName("userUnit")]
        public UserUnit UserUnit { get; set; }
    }

    public class UserUnit
    {
        [JsonPropertyName("mileageUnit")]
        public int? MileageUnit { get; set; }
    }

    public class Scale
    {
        [JsonPropertyName("userIds")]
        public long[] UserIds { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("tableName")]
        public string TableName { get; set; }
    }
}
