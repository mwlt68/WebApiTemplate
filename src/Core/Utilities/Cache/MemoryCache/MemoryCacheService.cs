using Core.Utilities.Cache.Base;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Core.Utilities.Cache.MemoryCache
{
    public class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache memoryCache;
        private readonly CacheSettings cacheConfig;
        private MemoryCacheEntryOptions cacheOptions;
        public MemoryCacheService(IMemoryCache memoryCache, IOptions<CacheSettings> cacheConfig)
        {
            this.memoryCache = memoryCache;
            this.cacheConfig = cacheConfig.Value;
            if (this.cacheConfig != null)
            {
                cacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddHours(this.cacheConfig.AbsoluteExpirationInHours),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromMinutes(this.cacheConfig.SlidingExpirationInMinutes)
                };
            }
        }
        public bool TryGet<T>(string cacheKey, out T value)
        {
            memoryCache.TryGetValue(cacheKey, out value);
            if (value == null) return false;
            else return true;
        }
        public T Set<T>(string cacheKey, T value)
        {
            return memoryCache.Set(cacheKey, value, cacheOptions);
        }
        public void Remove(string cacheKey)
        {
            memoryCache.Remove(cacheKey);
        }


    }
}
