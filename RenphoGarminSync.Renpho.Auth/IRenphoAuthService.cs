using RenphoGarminSync.Renpho.Auth.Models;
using RenphoGarminSync.Renpho.Shared.Models.Responses;
using System.Threading.Tasks;

namespace RenphoGarminSync.Renpho.Auth
{
    public interface IRenphoAuthService
    {
        Task<RenphoAuthToken> GetActiveSessionTokenAsync();
        Task<long> GetLoggedInUserIdAsync();
        Task<RenphoUser> GetLoggedInUserInfoAsync();
        Task InvalidateSessionAsync();
    }
}