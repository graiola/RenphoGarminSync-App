using System;

namespace RenphoGarminSync.Garmin.Auth.Models
{
    public class OAuth1Token
    {
        public string Token { get; set; }
        public string TokenSecret { get; set; }
        public DateTimeOffset IssuedAt { get; set; }
        public bool IsExpired => IssuedAt.AddDays(360) < DateTimeOffset.UtcNow;
    }
}
