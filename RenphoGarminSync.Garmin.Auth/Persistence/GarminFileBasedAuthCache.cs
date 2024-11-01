using RenphoGarminSync.Garmin.Auth.Models;
using RenphoGarminSync.Garmin.Auth.Utility;
using RenphoGarminSync.Garmin.Shared;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace RenphoGarminSync.Garmin.Auth.Persistence
{
    public class GarminFileBasedAuthCache : IGarminAuthCache
    {
        private readonly string _basePath;
        const string ENCRYPTION_KEY = "p13aSeD0ntSteaL0";

        public GarminFileBasedAuthCache(string basePath)
        {
            _basePath = basePath;
        }

        public async Task<GarminAuthEntry> GetAuthEntryAsync(string username)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(username);
            var directoryPath = GetDirectoryForUsername(username);
            if (!Directory.Exists(directoryPath))
                return null;

            var filePath = Path.Combine(directoryPath, "state.json");
            if (!File.Exists(filePath))
                return null;

            var fileContent = await File.ReadAllTextAsync(filePath);
            if (string.IsNullOrEmpty(fileContent))
                return null;

            var decryptedContent = AesUtility.Decrypt(fileContent, ENCRYPTION_KEY);
            return JsonSerializer.Deserialize<GarminAuthEntry>(decryptedContent);
        }

        public async Task UpdateAuthEntryAsync(string username, GarminAuthEntry entry)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(username);
            ArgumentNullException.ThrowIfNull(entry);

            var directoryPath = GetDirectoryForUsername(username);
            Directory.CreateDirectory(directoryPath);

            var serializedEntry = JsonSerializer.Serialize(entry);
            var encryptedContent = AesUtility.Encrypt(serializedEntry, ENCRYPTION_KEY);

            var filePath = Path.Combine(directoryPath, "state.json");
            await File.WriteAllTextAsync(filePath, encryptedContent);
        }

        public Task InvalidateAuthEntryAsync(string username)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(username);

            var directoryPath = GetDirectoryForUsername(username);
            var filePath = Path.Combine(directoryPath, "state.json");
            if (File.Exists(filePath))
                File.Delete(filePath);

            return Task.CompletedTask;
        }

        private string GetDirectoryForUsername(string username)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(username);
            var escapedDirName = PathEscaper.Escape(username);
            return Path.Combine(_basePath, "GarminAuth", escapedDirName);
        }
    }
}
