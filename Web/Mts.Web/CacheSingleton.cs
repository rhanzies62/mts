using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mts.Web
{
    public class CacheSingleton
    {
        public IMemoryCache MemCache;
        public CacheSingleton(IMemoryCache memCache)
        {
            MemCache = memCache;
        }
    }
}
