using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talakado.Infrastructure.CacheHelpers
{
    public static class CacheHelper
    {
        public static readonly TimeSpan DefaultCacheDuration = TimeSpan.FromSeconds(10);
        public static string GenerateHomePageCacheKey()
        {
            return "HomePage";
        }
    }
}
