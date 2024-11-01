using RenphoGarminSync.Renpho.Shared.Models.Enums;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace RenphoGarminSync.Renpho.Shared.Extensions
{
    public static class EnumExtensions
    {
        public static string GetEnumMemberValue<T>(this T val) where T : Enum
        {
            if (val is null)
                return null;

            if (!Enum.IsDefined(typeof(T), val))
                return null;

            var enumMember = typeof(T)
                .GetMember(val.ToString())
                .FirstOrDefault();

            if (enumMember is null)
                return null;

            var attibute = enumMember
                .GetCustomAttribute<EnumMemberAttribute>();

            if (attibute is null)
                return null;

            return attibute.Value;
        }
        public static DeviceType GetDeviceTypeForTag(this string tag)
        {
            if (string.IsNullOrWhiteSpace(tag))
                return DeviceType.DeviceTypeUnsupported;

            var allDeviceValues = Enum.GetValues<DeviceType>();
            var matchingEnumField = typeof(DeviceType)
                .GetFields()
                .FirstOrDefault(x =>
                {
                    var memberAttribute = x.GetCustomAttribute<EnumMemberAttribute>();
                    if (memberAttribute is null)
                        return false;

                    if (memberAttribute.Value.Equals(tag))
                        return true;

                    return false;
                });

            if (matchingEnumField is null)
                return DeviceType.DeviceTypeUnsupported;

            return (DeviceType)matchingEnumField.GetValue(null);
        }

        public static bool IsBodyWeightScale(this DeviceType deviceType)
        {
            return deviceType switch
            {
                DeviceType.DeviceTypeBodyFatScale => true,
                DeviceType.DeviceTypeBodyFatScale3 => true,
                DeviceType.DeviceTypeColorfulScale => true,
                DeviceType.DeviceTypeTFTScale => true,
                DeviceType.DeviceTypeColorWifiScale => true,
                DeviceType.DeviceTypeYKBFatScale => true,
                DeviceType.DeviceTypeYKBBroadcastScale => true,
                DeviceType.DeviceTypeYKBWifiBleScale => true,
                DeviceType.DeviceTypeScaleDoubleModel => true,
                DeviceType.DeviceTypeBodyWeightScale => true,
                _ => false,
            };
        }
    }
}
