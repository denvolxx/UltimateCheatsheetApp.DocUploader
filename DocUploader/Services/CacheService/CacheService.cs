using StackExchange.Redis;

namespace DocUploader.Services.CacheService
{
    public class CacheService(IConnectionMultiplexer _redis) : ICacheService
    {
        public async Task CacheFileAsync(string fileKey, byte[] fileData)
        {
            var db = _redis.GetDatabase();
            await db.StringSetAsync(fileKey, fileData);
        }

        public async Task<byte[]> GetCachedFileAsync(string fileKey)
        {
            var db = _redis.GetDatabase();
            var result = await db.StringGetAsync(fileKey);

            return result;
        }
    }
}
