using System.Text.Json.Serialization;

namespace RenphoGarminSync.Renpho.Shared.Models.Responses
{
    public class GetTokenTimeResponse
    {
        [JsonPropertyName("issAt")]
        public long? IssuedAt { get; set; }

        [JsonPropertyName("expAt")]
        public long? ExpiresAt { get; set; }

        [JsonPropertyName("userId")]
        public long? UserId { get; set; }

        [JsonPropertyName("token")]
        public string? Token { get; set; }
    }
}
