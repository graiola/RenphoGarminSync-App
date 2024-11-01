using RestSharp.Authenticators;
using System.Threading.Tasks;

namespace RenphoGarminSync.Garmin.Auth.Authenticators
{
    public interface IGarminAuthenticator : IAuthenticator
    {
        Task InvalidateSessionAsync();
    }
}