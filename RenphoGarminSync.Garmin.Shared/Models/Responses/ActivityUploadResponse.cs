using System.Text.Json.Serialization;

namespace RenphoGarminSync.Garmin.Shared.Models.Responses
{
    public class ActivityUploadResponse
    {
        [JsonPropertyName("detailedImportResult")]
        public DetailedImportResult DetailedImportResult { get; set; }
    }

    public class DetailedImportResult
    {
        [JsonPropertyName("uploadId")]
        public long UploadId { get; set; }

        [JsonPropertyName("uploadUuid")]
        public UploadUuid UploadUuid { get; set; }

        [JsonPropertyName("owner")]
        public int Owner { get; set; }

        [JsonPropertyName("fileSize")]
        public int FileSize { get; set; }

        [JsonPropertyName("processingTime")]
        public int ProcessingTime { get; set; }

        [JsonPropertyName("creationDate")]
        public string CreationDate { get; set; }

        [JsonPropertyName("ipAddress")]
        public string IpAddress { get; set; }

        [JsonPropertyName("fileName")]
        public string FileName { get; set; }

        [JsonPropertyName("report")]
        public object Report { get; set; }

        [JsonPropertyName("successes")]
        public Success[] Successes { get; set; }

        [JsonPropertyName("failures")]
        public Failure[] Failures { get; set; }
    }

    public class UploadUuid
    {
        [JsonPropertyName("uuid")]
        public string Uuid { get; set; }
    }

    public class Success
    {
        [JsonPropertyName("internalId")]
        public string InternalId { get; set; }

        [JsonPropertyName("externalId")]
        public string ExternalId { get; set; }

        [JsonPropertyName("messages")]
        public Message[] Messages { get; set; }
    }

    public class Failure
    {
        [JsonPropertyName("internalId")]
        public string InternalId { get; set; }

        [JsonPropertyName("externalId")]
        public string ExternalId { get; set; }

        [JsonPropertyName("messages")]
        public Message[] Messages { get; set; }
    }

    public class Message
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }
    }

}
