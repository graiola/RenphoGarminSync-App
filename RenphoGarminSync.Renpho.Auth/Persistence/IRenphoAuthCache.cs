using RenphoGarminSync.Renpho.Auth.Models;
using System.Threading.Tasks;

namespace RenphoGarminSync.Renpho.Auth.Persistence
{
    public interface IRenphoAuthCache
    {
        Task<RenphoAuthToken> GetAuthEntryAsync(string username);
        Task UpdateAuthEntryAsync(string username, RenphoAuthToken entry);
        Task InvalidateAuthEntryAsync(string username);
    }
}
