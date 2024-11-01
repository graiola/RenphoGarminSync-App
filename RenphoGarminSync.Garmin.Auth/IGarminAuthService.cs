using RenphoGarminSync.Garmin.Auth.Models;
using System.Threading.Tasks;

namespace RenphoGarminSync.Garmin.Auth
{
    public interface IGarminAuthService
    {
        Task FinishMFAProcessAsync(string mfaCode);
        Task<OAuth2Token> GetActiveSessionTokenAsync();
        Task InvalidateSessionAsync();
    }
}