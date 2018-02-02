using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Framework
{
    public class InMemoryCache : ICache
    {
        public void Clear()
        {
            List<string> cacheKeys = MemoryCache.Default.Select(kvp => kvp.Key).ToList();
            foreach (string cacheKey in cacheKeys)
            {
                MemoryCache.Default.Remove(cacheKey);
            }
        }

        public T GetItem<T>(string key) where T : class
        {
            return (T)MemoryCache.Default[key];
        }

        public void InvalidateItem(string key)
        {
            MemoryCache.Default.Remove(key);
        }

        public void InvalidateSets(IEnumerable<string> entitySets)
        {
            var distinctEntries = entitySets.Distinct();

            foreach (var entity in distinctEntries)
            {
                List<string> cacheEntityList = MemoryCache.Default.Where(x=>x.Key.Contains(entity)).Select(x => x.Key).ToList();
                foreach(var cacheType in cacheEntityList)
                    InvalidateItem(cacheType);
            }
        }

        public void PutItem(string key, object value)
        {
            if (value == null)
            {
                return;
            }

            int cacheTime = 60; // 60 minutes
            if (ConfigurationManager.AppSettings["CachingExpiredTime"] != null)
                cacheTime = int.Parse(ConfigurationManager.AppSettings["CachingExpiredTime"]);


            PutItem(key, value, cacheTime, 0);
        }

        public void PutItem(string key, object value, int slidingExpiration = 60, int absoluteExpiration = 0)
        {
            if (value == null)
            {
                return;
            }


            TimeSpan _slidingExpiration = TimeSpan.FromMinutes(slidingExpiration);
            DateTimeOffset _absoluteExpiration = DateTimeOffset.UtcNow.AddHours(absoluteExpiration);

            var policy = new CacheItemPolicy();

            if(absoluteExpiration > 0)
                policy.AbsoluteExpiration = _absoluteExpiration;

            policy.SlidingExpiration = _slidingExpiration;

            MemoryCache.Default.Add(new CacheItem(key, value), policy);
        }
    }
}
