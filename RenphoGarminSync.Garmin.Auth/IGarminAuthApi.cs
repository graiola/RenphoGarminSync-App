using RenphoGarminSync.Garmin.Auth.Models;
using System.Net;
using System.Threading.Tasks;

namespace RenphoGarminSync.Garmin.Auth
{
    public interface IGarminAuthApi
    {
        void AddCookies(CookieCollection cookies);
        Task<ServiceTicketResult> ConfirmMFACodeAsync(string mfaCode, string csrfToken);
        Task<OAuth2Token> ExchangeOAuth1ForOAuth2Async(OAuth1Token oAuth1Token);
        Task<AuthCredentials> GetConsumerCredentialsAsync();
        Task<string> GetCsrfTokenAsync();
        Task<OAuth1Token> GetOAuth1TokenAsync(string serviceTicket, string serviceUrl);
        Task<ServiceTicketResult> GetServiceTicketAsync(string username, string password);
    }
}