using RenphoGarminSync.Renpho.Shared.Models.Responses;
using RestSharp.Authenticators;
using System.Threading.Tasks;

namespace RenphoGarminSync.Renpho.Auth.Authenticators
{
    public interface IRenphoAuthenticator : IAuthenticator
    {
        Task InvalidateSessionAsync();
        Task<long> GetLoggedInUserIdAsync();
        Task<RenphoUser> GetLoggedInUserInfoAsync();
    }
}
