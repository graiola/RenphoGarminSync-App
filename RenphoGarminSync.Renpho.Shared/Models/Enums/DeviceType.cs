using System.Runtime.Serialization;

namespace RenphoGarminSync.Renpho.Shared.Models.Enums
{
    public enum DeviceType
    {
        [EnumMember(Value = "00019")]
        DeviceTypeAirPurifier1 = 19,

        [EnumMember(Value = "00020")]
        DeviceTypeAirPurifier2 = 20,

        [EnumMember(Value = "00005")]
        DeviceTypeBike = 5,

        [EnumMember(Value = "00015")]
        DeviceTypeBloodPressure = 15,

        [EnumMember(Value = "00002")]
        DeviceTypeBodyFatScale = 2,

        [EnumMember(Value = "00003")]
        DeviceTypeBodyFatScale3 = 3,

        [EnumMember(Value = "00016")]
        DeviceTypeBodyWeightScale = 16,

        [EnumMember(Value = "00014")]
        DeviceTypeCalfFoot = 14,

        [EnumMember(Value = "00021")]
        DeviceTypeCalfLeg = 21,

        [EnumMember(Value = "00038")]
        DeviceTypeColorWifiScale = 38,

        [EnumMember(Value = "00034")]
        DeviceTypeColorfulScale = 34,

        [EnumMember(Value = "00004")]
        DeviceTypeECG = 4,

        [EnumMember(Value = "00029")]
        DeviceTypeFasciaGun = 29,

        [EnumMember(Value = "00012")]
        DeviceTypeFoodScale = 12,

        [EnumMember(Value = "00022")]
        DeviceTypeFoodScalePG = 22,

        [EnumMember(Value = "00018")]
        DeviceTypeFootMachine = 18,

        [EnumMember(Value = "00032")]
        DeviceTypeHotEyeMassager = 32,

        [EnumMember(Value = "00001")]
        DeviceTypeJumpRope = 1,

        [EnumMember(Value = "00011")]
        DeviceTypeJumpRopeNew = 11,

        [EnumMember(Value = "00024")]
        DeviceTypeJumpRopeSelf = 24,

        [EnumMember(Value = "00033")]
        DeviceTypeMassageGun = 33,

        [EnumMember(Value = "00013")]
        DeviceTypeOpenBleFoot = 13,

        [EnumMember(Value = "00026")]
        DeviceTypeScaleDoubleModel = 26,

        [EnumMember(Value = "00042")]
        DeviceTypeSelfNatureESG = 42,

        [EnumMember(Value = "00043")]
        DeviceTypeSelfNatureESS = 43,

        [EnumMember(Value = "00023")]
        DeviceTypeSelfNatureRT = 23,

        [EnumMember(Value = "00051")]
        DeviceTypeTFTScale = 51,

        [EnumMember(Value = "00036")]
        DeviceTypeTapeRMTX01 = 36,

        [EnumMember(Value = "00027")]
        DeviceTypeTapeRY002 = 27,

        [EnumMember(Value = "00035")]
        DeviceTypeTapeRY002V2 = 35,

        [EnumMember(Value = "00025")]
        DeviceTypeTapeSelf = 25,

        [EnumMember(Value = "00006")]
        DeviceTypeTreadmill = 6,

        [EnumMember(Value = "")]
        DeviceTypeUnsupported = 0,

        [EnumMember(Value = "00008")]
        DeviceTypeYKBBroadcastScale = 8,

        [EnumMember(Value = "00007")]
        DeviceTypeYKBFatScale = 7,

        [EnumMember(Value = "00010")]
        DeviceTypeYKBTapeMeasure = 10,

        [EnumMember(Value = "00009")]
        DeviceTypeYKBWifiBleScale = 9,
    }
}
