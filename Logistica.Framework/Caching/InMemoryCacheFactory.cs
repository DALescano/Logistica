using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Framework
{
    public class InMemoryCacheFactory : ICacheFactory
    {
        public ICache Create()
        {
            return new InMemoryCache();
        }
    }
}
