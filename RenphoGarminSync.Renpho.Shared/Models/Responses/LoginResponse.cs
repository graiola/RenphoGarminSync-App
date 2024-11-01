using System.Text.Json.Serialization;

namespace RenphoGarminSync.Renpho.Shared.Models.Responses
{

    public class LoginResponse
    {
        [JsonPropertyName("questionnaire")]
        public bool? Questionnaire { get; set; }

        [JsonPropertyName("login")]
        public RenphoUser Login { get; set; }

        [JsonPropertyName("bindingList")]
        public Bindinglist BindingList { get; set; }
    }

    public class RenphoUser
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("encryptedPassword")]
        public string EncryptedPassword { get; set; }

        [JsonPropertyName("supplyerId")]
        public string SupplyerId { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("isPushData")]
        public string IsPushData { get; set; }

        [JsonPropertyName("isPushEmailMessage")]
        public string IsPushEmailMessage { get; set; }

        [JsonPropertyName("isPushFriendMessage")]
        public string IsPushFriendMessage { get; set; }

        [JsonPropertyName("accountName")]
        public string AccountName { get; set; }

        [JsonPropertyName("roleType")]
        public int? RoleType { get; set; }

        [JsonPropertyName("gender")]
        public Gender? Gender { get; set; }

        [JsonPropertyName("height")]
        public float? Height { get; set; }

        [JsonPropertyName("heightUnit")]
        public HeightUnit? HeightUnit { get; set; }

        [JsonPropertyName("birthday")]
        public string Birthday { get; set; }

        [JsonPropertyName("waistline")]
        public int? Waistline { get; set; }

        [JsonPropertyName("hip")]
        public int? Hip { get; set; }

        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }

        [JsonPropertyName("personType")]
        public int? PersonType { get; set; }

        [JsonPropertyName("categoryType")]
        public CategoryType? CategoryType { get; set; }

        [JsonPropertyName("weightUnit")]
        public WeightUnit? WeightUnit { get; set; }

        [JsonPropertyName("currentGoalWeight")]
        public float? CurrentGoalWeight { get; set; }

        [JsonPropertyName("weightGoalUnit")]
        public WeightUnit? WeightGoalUnit { get; set; }

        [JsonPropertyName("weightGoal")]
        public float WeightGoal { get; set; }

        [JsonPropertyName("weightGoalDate")]
        public string WeightGoalDate { get; set; }

        [JsonPropertyName("deletedAt")]
        public string DeletedAt { get; set; }

        [JsonPropertyName("rememberCreatedAt")]
        public string RememberCreatedAt { get; set; }

        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public string IpdatedAt { get; set; }

        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        [JsonPropertyName("facebookAccount")]
        public object FacebookAccount { get; set; }

        [JsonPropertyName("twitterAccount")]
        public object TwitterAccount { get; set; }

        [JsonPropertyName("lineAccount")]
        public object LineAccount { get; set; }

        [JsonPropertyName("debugFlag")]
        public int? DebugFlag { get; set; }

        [JsonPropertyName("weight")]
        public float? Weight { get; set; }

        [JsonPropertyName("resistance")]
        public int? Resistance { get; set; }

        [JsonPropertyName("secResistance")]
        public int? SecResistance { get; set; }

        [JsonPropertyName("platform")]
        public string Platform { get; set; }

        [JsonPropertyName("appId")]
        public string AppId { get; set; }

        [JsonPropertyName("appRevision")]
        public string AppRevision { get; set; }

        [JsonPropertyName("cellphoneType")]
        public string CellphoneType { get; set; }

        [JsonPropertyName("systemType")]
        public string SystemType { get; set; }

        [JsonPropertyName("sportGoal")]
        public int? SportGoal { get; set; }

        [JsonPropertyName("sleepGoal")]
        public int? SleepGoal { get; set; }

        [JsonPropertyName("areaCode")]
        public string AreaCode { get; set; }

        [JsonPropertyName("testFlag")]
        public int? TestFlag { get; set; }

        [JsonPropertyName("userCode")]
        public string UserCode { get; set; }

        [JsonPropertyName("agreeFlag")]
        public int? AgreeFlag { get; set; }

        [JsonPropertyName("bodyfatGoal")]
        public float? BodyfatGoal { get; set; }

        [JsonPropertyName("initialWeight")]
        public float? InitialWeight { get; set; }

        [JsonPropertyName("initialBodyfat")]
        public float? InitialBodyfat { get; set; }

        [JsonPropertyName("reachGoalWeightFlag")]
        public int? ReachGoalWeightFlag { get; set; }

        [JsonPropertyName("reachGoalBodyfatFlag")]
        public int? ReachGoalBodyfatFlag { get; set; }

        [JsonPropertyName("clientIp")]
        public string ClientIp { get; set; }

        [JsonPropertyName("extraField")]
        public string ExtraField { get; set; }

        [JsonPropertyName("timeStamp")]
        public string TimeStamp { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("method")]
        public int? Method { get; set; }

        [JsonPropertyName("measureLastTime")]
        public string MeasureLastTime { get; set; }

        [JsonPropertyName("measureLastWeight")]
        public string MeasureLastWeight { get; set; }

        [JsonPropertyName("timeZone")]
        public string TimeZone { get; set; }

        [JsonPropertyName("userUuid")]
        public string UserUUID { get; set; }

        [JsonPropertyName("revise")]
        public int? Revise { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("area")]
        public string Area { get; set; }

        [JsonPropertyName("dailyExercise")]
        public int? DailyExercise { get; set; }

        [JsonPropertyName("issAt")]
        public long? IssAt { get; set; }

        [JsonPropertyName("expAt")]
        public long? ExpAt { get; set; }

        [JsonPropertyName("emailValid")]
        public bool? EmailValid { get; set; }

        [JsonPropertyName("calmDown")]
        public bool? CalmDown { get; set; }

        [JsonPropertyName("firstLogin")]
        public string FirstLogin { get; set; }
    }

    public class Bindinglist
    {
        [JsonPropertyName("bluetooth")]
        public Device[] Bluetooth { get; set; }

        [JsonPropertyName("wifi")]
        public Device[] WiFi { get; set; }
    }

    public class Device
    {
        [JsonPropertyName("deviceType")]
        public string DeviceType { get; set; }

        [JsonPropertyName("deviceName")]
        public string DeviceName { get; set; }

        [JsonPropertyName("deviceNumber")]
        public string DeviceNumber { get; set; }

        [JsonPropertyName("mac")]
        public string MAC { get; set; }

        [JsonPropertyName("deviceModel")]
        public string DeviceModel { get; set; }

        [JsonPropertyName("firmwareVersion")]
        public string FirmwareVersion { get; set; }

        [JsonPropertyName("deviceInfoId")]
        public string DeviceInfoId { get; set; }

        [JsonPropertyName("uuid")]
        public string UUID { get; set; }

        [JsonPropertyName("deviceNickName")]
        public object DeviceNickName { get; set; }
    }

    public enum WeightUnit
    {
        Kg = 1,
        Lbs = 2,
        StoneLbs = 3,
        Stone = 4,
    }

    public enum HeightUnit
    {
        Cm = 1,
        Inch = 2,
    }

    public enum CategoryType
    {
        MeasureUser = 0,
        BabyUser = 1,
    }

    public enum Gender
    {
        Female = 0,
        Male = 1,
    }
}
