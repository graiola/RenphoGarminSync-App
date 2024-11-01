using RenphoGarminSync.Renpho.Shared.Extensions;
using RenphoGarminSync.Renpho.Shared.Models.Enums;
using System;
using System.Collections.Generic;

namespace RenphoGarminSync.Renpho.Shared
{
    public static class RenphoUtility
    {
        public static IEnumerable<DeviceType> GetAllBodyWeightScales()
        {
            foreach (var value in Enum.GetValues<DeviceType>())
            {
                if (value.IsBodyWeightScale())
                    yield return value;
            }
        }
    }
}
