using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Infrastructure.DistributedCaches
{
    public class DistributedCacheProvider : IDistributedCacheProvider
    {
        private readonly IDistributedCache _cache;
        private readonly IOptions<DistributedCacheOptions> _options;
        private readonly ILogger<DistributedCacheProvider> _logger;

        public DistributedCacheProvider(IDistributedCache cache, IOptions<DistributedCacheOptions> options, ILogger<DistributedCacheProvider> logger)
        {
            _cache = cache;
            _logger = logger;
            _options = options;
        }

        public async Task<T> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class
        {
            try
            {
                var json = await _cache.GetStringAsync(key, cancellationToken) ?? "null";
                var obj = JsonSerializer.Deserialize<T>(json);
                return obj;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has occurred on method '{method}'", nameof(GetAsync));
                return default;
            }
        }

        public async Task SetAsync<T>(string key, T obj, CancellationToken cancellationToken = default) where T : class
        {
            try
            {
                var json = JsonSerializer.Serialize(obj);
                var options = BuildDistributedCacheEntryOptions();
                await _cache.SetStringAsync(key, json, options, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has occurred on method '{method}'", nameof(SetAsync));
            }
        }

        private DistributedCacheEntryOptions BuildDistributedCacheEntryOptions()
        {
            var expirationInMinutes = _options.Value.ExpirationInMinutes;

            return new DistributedCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(expirationInMinutes),
                AbsoluteExpiration = DateTime.Now.AddMinutes(expirationInMinutes)
            };
        }
    }
}