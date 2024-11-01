using RenphoGarminSync.Renpho.Shared.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RenphoGarminSync.Renpho.Api
{
    public interface IRenphoApi
    {
        Task<IEnumerable<BodyScaleResponse>> GetBodyScaleMeasurements(long? userId, int totalCount, string tableName);
        Task<GetDeviceInfoResponse> GetDeviceInfoAsync();
        Task<IEnumerable<RenphoUser>> QueryFamilyMembers();
        Task<long> GetLoggedInUserIdAsync();
        Task<RenphoUser> GetLoggedInUserInfoAsync();
    }
}