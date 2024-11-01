using System;
using System.Text.Json.Serialization;

namespace RenphoGarminSync.Garmin.Auth.Models
{
    public class GarminMFAState
    {
        public DateTimeOffset ExpiresAt { get; set; }
        public string CookieContainer { get; set; }
        public string MFACsrfToken { get; set; }

        [JsonIgnore]
        public bool IsExpired => DateTimeOffset.UtcNow > ExpiresAt;
    }
}
