namespace RenphoGarminSync.Garmin.Auth.Models
{
    public class GarminAuthEntry
    {
        public string Username { get; set; }
        public AuthStage Stage { get; set; }
        public OAuth1Token OAuth1Token { get; set; }
        public OAuth2Token OAuth2Token { get; set; }
        public GarminMFAState MFAState { get; set; }
    }
    public enum AuthStage
    {
        None = 0,
        NeedMfaToken = 1,
        Completed = 2,
    }
}
