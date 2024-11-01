using System;
using System.Text.Json.Serialization;

namespace RenphoGarminSync.Garmin.Shared.Models.Responses
{
    public class UserDailySummaryResponse
    {
        [JsonPropertyName("userProfileId")]
        public int? UserProfileId { get; set; }

        [JsonPropertyName("totalKilocalories")]
        public float? TotalKilocalories { get; set; }

        [JsonPropertyName("activeKilocalories")]
        public float? ActiveKilocalories { get; set; }

        [JsonPropertyName("bmrKilocalories")]
        public float? BmrKilocalories { get; set; }

        [JsonPropertyName("wellnessKilocalories")]
        public float? WellnessKilocalories { get; set; }

        [JsonPropertyName("burnedKilocalories")]
        public float? BurnedKilocalories { get; set; }

        [JsonPropertyName("consumedKilocalories")]
        public float? ConsumedKilocalories { get; set; }

        [JsonPropertyName("remainingKilocalories")]
        public float? RemainingKilocalories { get; set; }

        [JsonPropertyName("totalSteps")]
        public int? TotalSteps { get; set; }

        [JsonPropertyName("netCalorieGoal")]
        public float? NetCalorieGoal { get; set; }

        [JsonPropertyName("totalDistanceMeters")]
        public int? totalDistanceMeters { get; set; }

        [JsonPropertyName("wellnessDistanceMeters")]
        public int? WellnessDistanceMeters { get; set; }

        [JsonPropertyName("wellnessActiveKilocalories")]
        public float? WellnessActiveKilocalories { get; set; }

        [JsonPropertyName("netRemainingKilocalories")]
        public float? NetRemainingKilocalories { get; set; }

        [JsonPropertyName("userDailySummaryId")]
        public int? UserDailySummaryId { get; set; }

        [JsonPropertyName("calendarDate")]
        public string CalendarDate { get; set; }

        [JsonPropertyName("rule")]
        public Rule Rule { get; set; }

        [JsonPropertyName("uuid")]
        public string Uuid { get; set; }

        [JsonPropertyName("dailyStepGoal")]
        public int? DailyStepGoal { get; set; }

        [JsonPropertyName("wellnessStartTimeGmt")]
        public DateTime WellnessStartTimeGmt { get; set; }

        [JsonPropertyName("wellnessStartTimeLocal")]
        public DateTime WellnessStartTimeLocal { get; set; }

        [JsonPropertyName("wellnessEndTimeGmt")]
        public DateTime WellnessEndTimeGmt { get; set; }

        [JsonPropertyName("wellnessEndTimeLocal")]
        public DateTime WellnessEndTimeLocal { get; set; }

        [JsonPropertyName("durationInMilliseconds")]
        public int? DurationInMilliseconds { get; set; }

        [JsonPropertyName("wellnessDescription")]
        public string WellnessDescription { get; set; }

        [JsonPropertyName("highlyActiveSeconds")]
        public int? HighlyActiveSeconds { get; set; }

        [JsonPropertyName("activeSeconds")]
        public int? ActiveSeconds { get; set; }

        [JsonPropertyName("sedentarySeconds")]
        public int? SedentarySeconds { get; set; }

        [JsonPropertyName("sleepingSeconds")]
        public int? SleepingSeconds { get; set; }

        [JsonPropertyName("includesWellnessData")]
        public bool IncludesWellnessData { get; set; }

        [JsonPropertyName("includesActivityData")]
        public bool IncludesActivityData { get; set; }

        [JsonPropertyName("includesCalorieConsumedData")]
        public bool IncludesCalorieConsumedData { get; set; }

        [JsonPropertyName("privacyProtected")]
        public bool PrivacyProtected { get; set; }

        [JsonPropertyName("moderateIntensityMinutes")]
        public int? ModerateIntensityMinutes { get; set; }

        [JsonPropertyName("vigorousIntensityMinutes")]
        public int? VigorousIntensityMinutes { get; set; }

        [JsonPropertyName("floorsAscendedInMeters")]
        public float? FloorsAscendedInMeters { get; set; }

        [JsonPropertyName("floorsDescendedInMeters")]
        public float? FloorsDescendedInMeters { get; set; }

        [JsonPropertyName("floorsAscended")]
        public float? FloorsAscended { get; set; }

        [JsonPropertyName("floorsDescended")]
        public float? FloorsDescended { get; set; }

        [JsonPropertyName("intensityMinutesGoal")]
        public int? IntensityMinutesGoal { get; set; }

        [JsonPropertyName("userFloorsAscendedGoal")]
        public int? UserFloorsAscendedGoal { get; set; }

        [JsonPropertyName("minHeartRate")]
        public int? MinHeartRate { get; set; }

        [JsonPropertyName("maxHeartRate")]
        public int? MaxHeartRate { get; set; }

        [JsonPropertyName("restingHeartRate")]
        public int? RestingHeartRate { get; set; }

        [JsonPropertyName("lastSevenDaysAvgRestingHeartRate")]
        public int? LastSevenDaysAvgRestingHeartRate { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("averageStressLevel")]
        public int? AverageStressLevel { get; set; }

        [JsonPropertyName("maxStressLevel")]
        public int? MaxStressLevel { get; set; }

        [JsonPropertyName("stressDuration")]
        public int? StressDuration { get; set; }

        [JsonPropertyName("restStressDuration")]
        public int? RestStressDuration { get; set; }

        [JsonPropertyName("activityStressDuration")]
        public int? ActivityStressDuration { get; set; }

        [JsonPropertyName("uncategorizedStressDuration")]
        public int? UncategorizedStressDuration { get; set; }

        [JsonPropertyName("totalStressDuration")]
        public int? TotalStressDuration { get; set; }

        [JsonPropertyName("lowStressDuration")]
        public int? LowStressDuration { get; set; }

        [JsonPropertyName("mediumStressDuration")]
        public int? MediumStressDuration { get; set; }

        [JsonPropertyName("highStressDuration")]
        public int? HighStressDuration { get; set; }

        [JsonPropertyName("stressPercentage")]
        public float? StressPercentage { get; set; }

        [JsonPropertyName("restStressPercentage")]
        public float? RestStressPercentage { get; set; }

        [JsonPropertyName("activityStressPercentage")]
        public float? ActivityStressPercentage { get; set; }

        [JsonPropertyName("uncategorizedStressPercentage")]
        public float? UncategorizedStressPercentage { get; set; }

        [JsonPropertyName("lowStressPercentage")]
        public float? LowStressPercentage { get; set; }

        [JsonPropertyName("mediumStressPercentage")]
        public float? MediumStressPercentage { get; set; }

        [JsonPropertyName("highStressPercentage")]
        public float? HighStressPercentage { get; set; }

        [JsonPropertyName("stressQualifier")]
        public string StressQualifier { get; set; }

        [JsonPropertyName("measurableAwakeDuration")]
        public int? MeasurableAwakeDuration { get; set; }

        [JsonPropertyName("measurableAsleepDuration")]
        public int? MeasurableAsleepDuration { get; set; }

        [JsonPropertyName("lastSyncTimestampGMT")]
        public string LastSyncTimestampGMT { get; set; }

        [JsonPropertyName("minAvgHeartRate")]
        public int? MinAvgHeartRate { get; set; }

        [JsonPropertyName("maxAvgHeartRate")]
        public int? MaxAvgHeartRate { get; set; }

        [JsonPropertyName("bodyBatteryChargedValue")]
        public int? BodyBatteryChargedValue { get; set; }

        [JsonPropertyName("bodyBatteryDrainedValue")]
        public int? BodyBatteryDrainedValue { get; set; }

        [JsonPropertyName("bodyBatteryHighestValue")]
        public int? BodyBatteryHighestValue { get; set; }

        [JsonPropertyName("bodyBatteryLowestValue")]
        public int? BodyBatteryLowestValue { get; set; }

        [JsonPropertyName("bodyBatteryMostRecentValue")]
        public int? BodyBatteryMostRecentValue { get; set; }

        [JsonPropertyName("bodyBatteryDuringSleep")]
        public int? BodyBatteryDuringSleep { get; set; }

        [JsonPropertyName("bodyBatteryVersion")]
        public float? BodyBatteryVersion { get; set; }

        [JsonPropertyName("abnormalHeartRateAlertsCount")]
        public object AbnormalHeartRateAlertsCount { get; set; }

        [JsonPropertyName("averageSpo2")]
        public object AverageSpo2 { get; set; }

        [JsonPropertyName("lowestSpo2")]
        public object LowestSpo2 { get; set; }

        [JsonPropertyName("latestSpo2")]
        public object LatestSpo2 { get; set; }

        [JsonPropertyName("latestSpo2ReadingTimeGmt")]
        public object LatestSpo2ReadingTimeGmt { get; set; }

        [JsonPropertyName("latestSpo2ReadingTimeLocal")]
        public object LatestSpo2ReadingTimeLocal { get; set; }

        [JsonPropertyName("averageMonitoringEnvironmentAltitude")]
        public object AverageMonitoringEnvironmentAltitude { get; set; }

        [JsonPropertyName("restingCaloriesFromActivity")]
        public float? RestingCaloriesFromActivity { get; set; }

        [JsonPropertyName("avgWakingRespirationValue")]
        public float? AvgWakingRespirationValue { get; set; }

        [JsonPropertyName("highestRespirationValue")]
        public float? HighestRespirationValue { get; set; }

        [JsonPropertyName("lowestRespirationValue")]
        public float? LowestRespirationValue { get; set; }

        [JsonPropertyName("latestRespirationValue")]
        public float? LatestRespirationValue { get; set; }

        [JsonPropertyName("latestRespirationTimeGMT")]
        public DateTime LatestRespirationTimeGMT { get; set; }

        [JsonPropertyName("respirationAlgorithmVersion")]
        public int? RespirationAlgorithmVersion { get; set; }
    }

    public class Rule
    {
        [JsonPropertyName("typeId")]
        public int? TypeId { get; set; }

        [JsonPropertyName("typeKey")]
        public string TypeKey { get; set; }
    }

}
