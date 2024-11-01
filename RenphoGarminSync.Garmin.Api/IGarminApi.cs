using RenphoGarminSync.Garmin.Shared.Models.Responses;
using System;
using System.Threading.Tasks;

namespace RenphoGarminSync.Garmin.Api
{
    public interface IGarminApi
    {
        Task<BodyCompositionResult> GetBodyComposition(DateTime startDate, DateTime endDate);
        Task<UserDailySummaryResponse> GetUserDailySummary(string displayName, DateTime date);
        Task<UserProfileResponse> GetUserProfile();
        Task<ActivityUploadResponse> UploadActivity(string fileName, byte[] content);
    }
}