using System.Text.Json.Serialization;

namespace RenphoGarminSync.Renpho.Shared.Models.Requests
{
    public class QueryMeasurementDataRequest
    {
        [JsonPropertyName("pageNum")]
        public required int PageNum { get; set; }

        [JsonPropertyName("pageSize")]
        public required int PageSize { get; set; }

        [JsonPropertyName("userIds")]
        public required string[] UserIds { get; set; }

        [JsonPropertyName("tableName")]
        public required string TableName { get; set; }

    }
}
