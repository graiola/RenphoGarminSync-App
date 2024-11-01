using RenphoGarminSync.Renpho.Shared.Models.Responses;

namespace RenphoGarminSync.Renpho.Auth.Models
{
    public class RenphoAuthToken
    {
        public long? IssuedAt { get; set; }
        public long? ExpiresAt { get; set; }
        public long? UserId { get; set; }
        public string Token { get; set; }
        public RenphoUser User { get; set; }
    }
}
