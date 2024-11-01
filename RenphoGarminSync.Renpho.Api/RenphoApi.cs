using Polly;
using Polly.Retry;
using RenphoGarminSync.Renpho.Auth.Authenticators;
using RenphoGarminSync.Renpho.Shared;
using RenphoGarminSync.Renpho.Shared.Exceptions;
using RenphoGarminSync.Renpho.Shared.Models;
using RenphoGarminSync.Renpho.Shared.Models.Requests;
using RenphoGarminSync.Renpho.Shared.Models.Responses;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RenphoGarminSync.Renpho.Api
{
    public class RenphoApi : IRenphoApi
    {
        private readonly string _encryptionSecret;
        private readonly RestClient _client;
        private readonly IRenphoAuthenticator _authenticator;

        public RenphoApi(string encryptionSecret, IRenphoAuthenticator authenticator)
        {
            _encryptionSecret = encryptionSecret;
            _authenticator = authenticator;
            var options = new RestClientOptions(RenphoApiEndpoints.API_BASE_URL)
            {
                Authenticator = authenticator
            };
            _client = new RestClient(options);
        }

        public async Task<long> GetLoggedInUserIdAsync()
        {
            return await _authenticator.GetLoggedInUserIdAsync();
        }

        public async Task<RenphoUser> GetLoggedInUserInfoAsync()
        {
            return await _authenticator.GetLoggedInUserInfoAsync();
        }

        public async Task<GetDeviceInfoResponse> GetDeviceInfoAsync()
        {
            var pipeline = GetRenphoResiliencePipeline();
            return await pipeline.ExecuteAsync(async cancellationToken =>
            {
                var restRequest = new RestRequest(RenphoApiEndpoints.GetDeviceInfo, Method.Post);
                var bodyContent = BaseEncryptedRequest.GetEmpty(_encryptionSecret, false);
                restRequest.AddJsonBody(bodyContent);

                var response = await _client.ExecuteAsync<BaseEncryptedResponse<GetDeviceInfoResponse>>(restRequest, cancellationToken);
                ThrowOnUnsuccesfullResponse(response);

                return response.Data?.DecryptData(_encryptionSecret);
            });
        }

        public async Task<IEnumerable<RenphoUser>> QueryFamilyMembers()
        {
            var pipeline = GetRenphoResiliencePipeline();
            return await pipeline.ExecuteAsync(async cancellationToken =>
            {
                var restRequest = new RestRequest(RenphoApiEndpoints.QueryMembers, Method.Post);
                var bodyContent = BaseEncryptedRequest.GetEmpty(_encryptionSecret, true);
                restRequest.AddJsonBody(bodyContent);

                var response = await _client.ExecuteAsync<BaseEncryptedResponse<IEnumerable<RenphoUser>>>(restRequest, cancellationToken);
                ThrowOnUnsuccesfullResponse(response);

                return response.Data?.DecryptData(_encryptionSecret);
            });
        }

        public async Task<IEnumerable<BodyScaleResponse>> GetBodyScaleMeasurements(long? userId, int totalCount, string tableName)
        {
            const int PAGE_SIZE = 50;
            var pipeline = GetRenphoResiliencePipeline();
            userId ??= await GetLoggedInUserIdAsync();

            var resultList = new List<BodyScaleResponse>();
            int curPage = 1;
            while (resultList.Count < totalCount)
            {
                var chunkResult = await pipeline.ExecuteAsync(async cancellationToken =>
                {
                    var restRequest = new RestRequest(RenphoApiEndpoints.QueryMeasurementData, Method.Post);
                    var requestContent = new QueryMeasurementDataRequest
                    {
                        PageNum = curPage,
                        PageSize = PAGE_SIZE,
                        TableName = tableName,
                        UserIds = [userId.Value.ToString()]
                    };
                    var bodyContent = BaseEncryptedRequest.GetForObject(requestContent, _encryptionSecret);
                    restRequest.AddJsonBody(bodyContent);

                    var response = await _client.ExecuteAsync<BaseEncryptedResponse<IEnumerable<BodyScaleResponse>>>(restRequest, cancellationToken);
                    ThrowOnUnsuccesfullResponse(response);

                    return response.Data.DecryptData(_encryptionSecret);
                });

                if (!chunkResult.Any())
                    break;

                resultList.AddRange(chunkResult);
                curPage++;
            }

            return resultList;
        }

        private static void ThrowOnUnsuccesfullResponse<T>(RestResponse<BaseEncryptedResponse<T>> response) where T : class
        {
            ArgumentNullException.ThrowIfNull(response);
            if (response.IsSuccessful)
                return;

            if (response.Data is null)
                throw new RenphoException(RenphoStatusCode.CUSTOM_REQUEST_FAILED, "Null result");

            if (!response.IsSuccessful)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    throw new RenphoException(RenphoStatusCode.Unauthorized, "Unauthorized request");

                throw new RenphoException(RenphoStatusCode.CUSTOM_REQUEST_FAILED, "Unsuccesful request");
            }

            if (!response.Data.IsSuccessful)
                throw new RenphoException(response.Data.Code, response.Data.Message);
        }

        private ResiliencePipeline GetRenphoResiliencePipeline()
        {
            var retryOptions = new RetryStrategyOptions
            {
                MaxRetryAttempts = 1,
                Delay = TimeSpan.FromSeconds(1),
                ShouldHandle = new PredicateBuilder().Handle<RenphoException>(x => x.StatusCode == RenphoStatusCode.Forbidden || x.StatusCode == RenphoStatusCode.Unauthorized),
                OnRetry = async (args) =>
                {
                    await _authenticator.InvalidateSessionAsync();
                }
            };
            return new ResiliencePipelineBuilder()
                .AddRetry(retryOptions)
                .Build();
        }
    }
}
