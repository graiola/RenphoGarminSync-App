namespace RenphoGarminSync.Renpho.Shared.Models.Enums
{
    public enum ScaleDataSourceType
    {
        ManualInput = 0,
        BluetoothOnlineMeasure = 2,
        BleCloudAutoAllocation = 3,
        CloudManualAllocation = 4,
        BluetoothOfflineAutoAllocation = 5,
        BluetoothOfflineManualAllocation = 6,
        Other = 7,
        RenphoMeasureData = 8,
        PregnantModeOnlineMeasure = 11,
        PregnantModeOfflineAutoAllocation = 12,
        PregnantModeOfflineManualAllocation = 13,
        PregnantCloudManualAllocation = 14,
        PregnantCloudBleAllocation = 15,
        PregnantCloudWifiAllocation = 16,
        PregnantBleCloudAllocation = 17,
        CloudWifiAutoAllocation = 18,
        CloudBleAutoAllocation = 19,
    }
}
