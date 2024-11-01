namespace RenphoGarminSync.Renpho.Shared
{
    public static class RenphoApiEndpoints
    {
        public const string API_BASE_URL = @"https://cloud.renpho.com";

        public const string Login = @"renpho-aggregation/user/login";
        public const string GetDeviceInfo = @"renpho-aggregation/device/count";

        public const string GetTokenTime = @"RenphoHealth/app/sync/getTokenTime";
        public const string QueryMembers = @"RenphoHealth/centerUser/queryFamilyMemberList";
        public const string QueryMeasurementData = @"RenphoHealth/scale/queryAllMeasureDataList";
    }
}
