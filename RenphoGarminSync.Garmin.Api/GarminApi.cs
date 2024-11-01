using Polly;
using Polly.Retry;
using RenphoGarminSync.Garmin.Auth.Authenticators;
using RenphoGarminSync.Garmin.Shared;
using RenphoGarminSync.Garmin.Shared.Exceptions;
using RenphoGarminSync.Garmin.Shared.Models;
using RenphoGarminSync.Garmin.Shared.Models.Responses;
using RestSharp;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RenphoGarminSync.Garmin.Api
{
    public class GarminApi : IGarminApi
    {
        private readonly GarminConfig _config;
        private readonly RestClient _client;
        private readonly IGarminAuthenticator _authenticator;

        public GarminApi(GarminConfig config, IGarminAuthenticator authenticator)
        {
            ArgumentNullException.ThrowIfNull(authenticator);

            _config = config;
            _authenticator = authenticator;
            var options = new RestClientOptions(config.ApiBaseUrl)
            {
                Authenticator = authenticator
            };
            _client = new RestClient(options);
        }

        public async Task<UserProfileResponse> GetUserProfile()
        {
            var pipeline = GetGarminResiliencePipeline();
            return await pipeline.ExecuteAsync(async cancellationToken =>
            {
                var restRequest = new RestRequest(GarminApiEndpoints.CONNECT_API_USER_PROFILE_ENDPOINT);
                var response = await _client.ExecuteAsync<UserProfileResponse>(restRequest);
                ThrowOnUnsuccesfullResponse(response);

                return response.Data;
            });
        }

        public async Task<UserDailySummaryResponse> GetUserDailySummary(string displayName, DateTime date)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(displayName);

            var pipeline = GetGarminResiliencePipeline();
            return await pipeline.ExecuteAsync(async cancellationToken =>
            {
                var endpoint = $"{GarminApiEndpoints.CONNECT_API_DAILY_SUMMARY_ENDPOINT}/{{displayName}}";
                var restRequest = new RestRequest(endpoint);
                restRequest.AddUrlSegment("displayName", displayName);
                restRequest.AddQueryParameter("calendarDate", date.ToString("yyyy-MM-dd"));
                var response = await _client.ExecuteAsync<UserDailySummaryResponse>(restRequest);
                ThrowOnUnsuccesfullResponse(response);

                return response.Data;
            });
        }

        public async Task<BodyCompositionResult> GetBodyComposition(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                throw new ArgumentException("endDate must be after startDate", nameof(endDate));

            var pipeline = GetGarminResiliencePipeline();
            return await pipeline.ExecuteAsync(async cancellationToken =>
            {
                var restRequest = new RestRequest(GarminApiEndpoints.CONNECT_API_BODYCOMPOSITION_ENDPOINT);
                restRequest.AddQueryParameter("startDate", startDate.ToString("yyyy-MM-dd"));
                restRequest.AddQueryParameter("endDate", endDate.ToString("yyyy-MM-dd"));
                var response = await _client.ExecuteAsync<BodyCompositionResult>(restRequest);
                ThrowOnUnsuccesfullResponse(response);

                return response.Data;
            });
        }

        public async Task<ActivityUploadResponse> UploadActivity(string fileName, byte[] content)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(fileName);
            if (content is null || !content.Any())
                throw new ArgumentException("Content is missing", nameof(content));

            var pipeline = GetGarminResiliencePipeline();
            return await pipeline.ExecuteAsync(async cancellationToken =>
            {
                var restRequest = new RestRequest(GarminApiEndpoints.CONNECT_API_UPLOAD_ENDPOINT, Method.Post);
                restRequest.AddFile("file", content, fileName, ContentType.Binary);
                var response = await _client.ExecuteAsync<ActivityUploadResponse>(restRequest);
                ThrowOnUnsuccesfullResponse(response);

                return response.Data;
            });
        }

        private void ThrowOnUnsuccesfullResponse(RestResponseBase response)
        {
            ArgumentNullException.ThrowIfNull(response);
            if (response.IsSuccessful)
                return;

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new GarminException(GarminStatusCode.Unauthorized, "Unauthorized");

            throw new GarminException(GarminStatusCode.None, response.Content);
        }

        private ResiliencePipeline GetGarminResiliencePipeline()
        {
            var retryOptions = new RetryStrategyOptions
            {
                MaxRetryAttempts = 1,
                Delay = TimeSpan.FromSeconds(1),
                ShouldHandle = new PredicateBuilder().Handle<GarminException>(x => x.StatusCode == GarminStatusCode.Unauthorized),
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
