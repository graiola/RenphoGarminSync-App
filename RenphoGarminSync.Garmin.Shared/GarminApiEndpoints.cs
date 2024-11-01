namespace RenphoGarminSync.Garmin.Shared
{
    public static class GarminApiEndpoints
    {
        public const string SSO_SIGNIN_ENDPOINT = @"sso/signin";
        public const string SSO_EMBED_ENDPOINT = @"sso/embed";
        public const string SSO_VERIFY_MFA = @"sso/verifyMFA/loginEnterMfaCode";

        public const string OAUTH_PREAUTHORIZE_ENDPOINT = @"oauth-service/oauth/preauthorized";
        public const string OAUTH_EXCHANGE_ENDPOINT = @"oauth-service/oauth/exchange/user/2.0";

        public const string CONNECT_API_USER_PROFILE_ENDPOINT = @"userprofile-service/socialProfile";
        public const string CONNECT_API_STEPS_ENDPOINT = @"usersummary-service/stats/steps";
        public const string CONNECT_API_DAILY_SUMMARY_ENDPOINT = @"usersummary-service/usersummary/daily";
        public const string CONNECT_API_BODYCOMPOSITION_ENDPOINT = @"weight-service/weight/dateRange";
        public const string CONNECT_API_UPLOAD_ENDPOINT = @"upload-service/upload";
    }
}
