using RenphoGarminSync.Renpho.Shared;
using RenphoGarminSync.Renpho.Shared.Exceptions;
using RenphoGarminSync.Renpho.Shared.Extensions;
using RenphoGarminSync.Renpho.Shared.Models;
using RenphoGarminSync.Renpho.Shared.Models.Requests;
using RenphoGarminSync.Renpho.Shared.Models.Responses;
using RestSharp;
using System.Linq;
using System.Threading.Tasks;

namespace RenphoGarminSync.Renpho.Auth
{
    public class RenphoAuthApi : IRenphoAuthApi
    {
        private readonly RenphoConfig _config;
        private readonly RestClient _authClient;

        public RenphoAuthApi(RenphoConfig config)
        {
            _config = config;
            _authClient = new RestClient(config.ApiBaseUrl);
        }

        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
            var deviceTypes = RenphoUtility.GetAllBodyWeightScales()
                .Select(x => x.GetEnumMemberValue())
                .ToArray();

            var loginModel = new LoginRequest
            {
                Questionnaire = new Questionnaire(),
                Login = new Login
                {
                    Email = username,
                    Password = password,
                    AreaCode = "US",
                    AppRevision = _config.AppVersion,
                    CellphoneType = "GarminRenphoSync",
                    SystemType = "11",
                    Platform = _config.Platform,
                },
                BindingList = new Shared.Models.Requests.Bindinglist
                {
                    DeviceTypes = deviceTypes
                }
            };

            var loginRequest = BaseEncryptedRequest.GetForObject(loginModel, _config.EncryptionSecret);
            var restRequest = new RestRequest(RenphoApiEndpoints.Login, Method.Post);
            restRequest.AddJsonBody(loginRequest);

            var result = await _authClient.ExecuteAsync<BaseEncryptedResponse<LoginResponse>>(restRequest);
            if (result == null)
                throw new RenphoException(RenphoStatusCode.CUSTOM_AUTH_FAILED, "Null result");

            if (!result.IsSuccessful || result.Data is null)
                throw new RenphoException(RenphoStatusCode.CUSTOM_AUTH_FAILED, "Unsuccesful login");

            if (!result.Data.IsSuccessful)
                throw new RenphoException(result.Data.Code, result.Data.Message);

            var userDetails = result.Data?.DecryptData(_config.EncryptionSecret);
            if (userDetails is null || userDetails.Login is null)
                throw new RenphoException(RenphoStatusCode.CUSTOM_AUTH_FAILED, "Response doesn't contain user info");

            return userDetails;
        }

        public async Task<GetTokenTimeResponse> GetTokenTimeAsync(string token, long userId)
        {
            var tokenInfoRequest = BaseEncryptedRequest.GetEmpty(_config.EncryptionSecret);
            var restRequest = new RestRequest(RenphoApiEndpoints.GetTokenTime, Method.Post);
            restRequest.AddJsonBody(tokenInfoRequest);
            restRequest.AddHeader("token", token);
            restRequest.AddHeader("userId", userId.ToString());
            restRequest.AddHeader("appVersion", _config.AppVersion);

            var result = await _authClient.ExecuteAsync<BaseEncryptedResponse<GetTokenTimeResponse>>(restRequest);
            if (result == null)
                throw new RenphoException(RenphoStatusCode.CUSTOM_AUTH_FAILED, "Null result");

            if (!result.IsSuccessful || result.Data is null)
                throw new RenphoException(RenphoStatusCode.CUSTOM_AUTH_FAILED, "Unsuccesful request");

            if (!result.Data.IsSuccessful)
                throw new RenphoException(result.Data.Code, result.Data.Message);

            var tokenTime = result.Data?.DecryptData(_config.EncryptionSecret);
            if (tokenTime is null)
                throw new RenphoException(RenphoStatusCode.CUSTOM_AUTH_FAILED, "Result is null");

            return tokenTime;
        }
    }
}
