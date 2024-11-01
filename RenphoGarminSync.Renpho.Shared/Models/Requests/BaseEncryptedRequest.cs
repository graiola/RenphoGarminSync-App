using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RenphoGarminSync.Renpho.Shared.Models.Requests
{
    public class BaseEncryptedRequest
    {
        [JsonPropertyName("encryptData")]
        public string? EncryptedData { get; set; }

        public static BaseEncryptedRequest GetForObject<T>(T obj, string encryptionKey) where T : class
        {
            ArgumentNullException.ThrowIfNull(obj);
            ArgumentException.ThrowIfNullOrWhiteSpace(encryptionKey);

            var serialized = JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = false, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
            var encryptedContent = AesUtility.Encrypt(serialized, encryptionKey);

            return new BaseEncryptedRequest
            {
                EncryptedData = encryptedContent,
            };
        }

        public static BaseEncryptedRequest GetEmpty(string encryptionKey, bool emptyObject = true)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(encryptionKey);

            var encryptedContent = AesUtility.EncryptRenpho([], encryptionKey);
            if (emptyObject)
            {
                var serialized = JsonSerializer.Serialize(new object(), new JsonSerializerOptions { WriteIndented = false, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
                encryptedContent = AesUtility.Encrypt(serialized, encryptionKey);
            }

            return new BaseEncryptedRequest
            {
                EncryptedData = encryptedContent,
            };
        }
    }
}
