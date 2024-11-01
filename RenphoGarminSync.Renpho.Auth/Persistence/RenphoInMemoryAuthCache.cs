using RenphoGarminSync.Renpho.Auth.Models;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace RenphoGarminSync.Renpho.Auth.Persistence
{
    public class RenphoInMemoryAuthCache : IRenphoAuthCache
    {
        private readonly ConcurrentDictionary<string, RenphoAuthToken> _stateDict;

        public RenphoInMemoryAuthCache()
        {
            _stateDict = new ConcurrentDictionary<string, RenphoAuthToken>();
        }

        public Task<RenphoAuthToken> GetAuthEntryAsync(string username)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(username);

            if (_stateDict.TryGetValue(username, out var authState))
                return Task.FromResult(authState);

            return Task.FromResult<RenphoAuthToken>(null);
        }

        public Task UpdateAuthEntryAsync(string username, RenphoAuthToken entry)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(username);
            ArgumentNullException.ThrowIfNull(entry);

            _stateDict.AddOrUpdate(username, entry, (key, oldValue) => entry);
            return Task.CompletedTask;
        }

        public Task InvalidateAuthEntryAsync(string username)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(username);
            _stateDict.TryRemove(username, out var _);
            return Task.CompletedTask;
        }
    }
}
