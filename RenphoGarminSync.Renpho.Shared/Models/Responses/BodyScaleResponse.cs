using RenphoGarminSync.Renpho.Shared.Models.Enums;
using System.Text.Json.Serialization;

namespace RenphoGarminSync.Renpho.Shared.Models.Responses
{
    public class BodyScaleResponse
    {
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        [JsonPropertyName("timeStamp")]
        public long? TimeStamp { get; set; }

        [JsonPropertyName("localCreatedAt")]
        public string LocalCreatedAt { get; set; }

        [JsonPropertyName("timeZone")]
        public string TimeZone { get; set; }

        [JsonPropertyName("internalModel")]
        public string InternalModel { get; set; }

        [JsonPropertyName("scaleType")]
        public ScaleType? ScaleType { get; set; }

        [JsonPropertyName("scaleName")]
        public string ScaleName { get; set; }

        [JsonPropertyName("mac")]
        public string MAC { get; set; }

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

        [JsonPropertyName("categoryType")]
        public CategoryType? CategoryType { get; set; }

        [JsonPropertyName("personType")]
        public PersonType? PersonType { get; set; }

        [JsonPropertyName("invalidFlag")]
        public int? InvalidFlag { get; set; }

        [JsonPropertyName("weight")]
        public float? Weight { get; set; }

        [JsonPropertyName("weightUnit")]
        public WeightUnit? WeightUnit { get; set; }

        [JsonPropertyName("bodyfat")]
        public float? BodyFat { get; set; }

        [JsonPropertyName("water")]
        public float? Water { get; set; }

        [JsonPropertyName("bmr")]
        public int? BMR { get; set; }

        [JsonPropertyName("bodyage")]
        public int? BodyAge { get; set; }

        [JsonPropertyName("muscle")]
        public float? Muscle { get; set; }

        [JsonPropertyName("bone")]
        public float? Bone { get; set; }

        [JsonPropertyName("subfat")]
        public float? SubFat { get; set; }

        [JsonPropertyName("visfat")]
        public float? VisceralFat { get; set; }

        [JsonPropertyName("bmi")]
        public float? BMI { get; set; }

        [JsonPropertyName("sinew")]
        public float? Sinew { get; set; }

        [JsonPropertyName("protein")]
        public float? Protein { get; set; }

        [JsonPropertyName("bodyShape")]
        public int? BodyShape { get; set; }

        [JsonPropertyName("fatFreeWeight")]
        public float? FatFreeWeight { get; set; }

        [JsonPropertyName("resistance")]
        public int? Resistance { get; set; }

        [JsonPropertyName("secResistance")]
        public int? SecResistance { get; set; }

        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public string UpdatedAt { get; set; }

        [JsonPropertyName("actualResistance")]
        public int? ActualResistance { get; set; }

        [JsonPropertyName("actualSecResistance")]
        public int? ActualSecResistance { get; set; }

        [JsonPropertyName("heartRate")]
        public int? heartRate { get; set; }

        [JsonPropertyName("cardiacIndex")]
        public float? cardiacIndex { get; set; }

        [JsonPropertyName("method")]
        public int? Method { get; set; }

        [JsonPropertyName("sportFlag")]
        public int? SportFlag { get; set; }

        [JsonPropertyName("extraField")]
        public string ExtraField { get; set; }

        [JsonPropertyName("headValue")]
        public float? HeadValue { get; set; }

        [JsonPropertyName("headUnit")]
        public WeightUnit? HeadUnit { get; set; }

        [JsonPropertyName("babyPicture")]
        public string BabyPicture { get; set; }

        [JsonPropertyName("deviceType")]
        public string DeviceType { get; set; }

        [JsonPropertyName("isAuto")]
        public ScaleDataSourceType? IsAuto { get; set; }

        [JsonPropertyName("isNew")]
        public bool? IsNew { get; set; }

        [JsonPropertyName("displayModuleType")]
        public DisplayModuleType? DisplayModuleType { get; set; }

        [JsonPropertyName("subUserId")]
        public long? SubUserId { get; set; }

        [JsonPropertyName("bUserId")]
        public long? UserId { get; set; }

        [JsonPropertyName("bodytype")]
        public BodyType? BodyType { get; set; }

        [JsonPropertyName("TW")]
        public float? TW { get; set; }

        [JsonPropertyName("WC")]
        public float? WC { get; set; }

        [JsonPropertyName("FC")]
        public float? FC { get; set; }

        [JsonPropertyName("A1")]
        public float? A1 { get; set; }
    }
}
