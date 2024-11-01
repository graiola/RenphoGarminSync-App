using System;
using System.Text.Json.Serialization;

namespace RenphoGarminSync.Garmin.Auth.Models
{
    public class OAuth2Token
    {
        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        [JsonPropertyName("jti")]
        public string Jti { get; set; }

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("refresh_token_expires_in")]
        public int RefreshTokenExpiresIn { get; set; }

        public DateTimeOffset IssuedAt { get; set; }

        public bool IsExpired => IssuedAt.AddSeconds(ExpiresIn) < DateTimeOffset.UtcNow.AddHours(1); // pad the time a bit
    }
}
