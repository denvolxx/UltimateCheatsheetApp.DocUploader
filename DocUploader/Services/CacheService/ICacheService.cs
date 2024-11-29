using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocUploader.Services.CacheService
{
    public interface ICacheService
    {
        Task CacheFileAsync(string key, byte[] fileData);
        Task<byte[]> GetCachedFileAsync(string key);
    }
}
