using System.Text.Json.Serialization;

namespace RenphoGarminSync.Garmin.Shared.Models
{
    public class GarminConfig
    {
        [JsonPropertyName("UserAgent")]
        public string UserAgent { get; set; }

        [JsonPropertyName("SSOBaseUrl")]
        public string SSOBaseUrl { get; set; }

        [JsonPropertyName("ApiBaseUrl")]
        public string ApiBaseUrl { get; set; }

        [JsonPropertyName("ConsumerKey")]
        public string ConsumerKey { get; set; }

        [JsonPropertyName("ConsumerSecret")]
        public string ConsumerSecret { get; set; }
    }
}
