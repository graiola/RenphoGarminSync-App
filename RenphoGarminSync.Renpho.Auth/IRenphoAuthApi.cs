using RenphoGarminSync.Renpho.Shared.Models.Responses;
using System.Threading.Tasks;

namespace RenphoGarminSync.Renpho.Auth
{
    public interface IRenphoAuthApi
    {
        Task<GetTokenTimeResponse> GetTokenTimeAsync(string token, long userId);
        Task<LoginResponse> LoginAsync(string username, string password);
    }
}