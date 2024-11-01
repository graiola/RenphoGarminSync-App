using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RenphoGarminSync.Renpho.Shared.Models.Responses
{
    public class BaseEncryptedResponse<T> where T : class
    {
        [JsonPropertyName("code")]
        public RenphoStatusCode Code { get; set; }

        [JsonPropertyName("msg")]
        public string Message { get; set; }

        [JsonPropertyName("data")]
        public string EncryptedData { get; set; }

        [JsonIgnore]
        public bool IsSuccessful => Code == RenphoStatusCode.Success;

        public T DecryptData(string secretKey)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(secretKey);
            if (EncryptedData is null)
                return null;

            var decryptedContent = AesUtility.Decrypt(EncryptedData, secretKey);
            return JsonSerializer.Deserialize<T>(decryptedContent);
        }
    }
}
