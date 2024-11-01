using System.Text.Json.Serialization;

namespace RenphoGarminSync.Renpho.Shared.Models
{
    public class RenphoConfig
    {
        [JsonPropertyName("EncryptionSecret")]
        public string EncryptionSecret { get; set; }

        [JsonPropertyName("ApiBaseUrl")]
        public string ApiBaseUrl { get; set; }

        [JsonPropertyName("AppVersion")]
        public string AppVersion { get; set; }

        [JsonPropertyName("Platform")]
        public string Platform { get; set; }
    }
}
