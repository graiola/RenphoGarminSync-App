using RenphoGarminSync.Garmin.Auth.Models;
using System.Threading.Tasks;

namespace RenphoGarminSync.Garmin.Auth
{
    public interface IGarminAuthCache
    {
        Task<GarminAuthEntry> GetAuthEntryAsync(string username);
        Task UpdateAuthEntryAsync(string username, GarminAuthEntry entry);
        Task InvalidateAuthEntryAsync(string username);
    }
}
