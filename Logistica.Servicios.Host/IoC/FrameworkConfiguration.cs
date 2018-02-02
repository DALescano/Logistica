using Logistica.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Servicios.IoC
{
    public class FrameworkConfiguration
    {
        public static void Configuration()
        {
            TypeAdapterFactory.SetCurrent(new AutomapperTypeAdapterFactory());
            CacheFactory.SetCurrent(new InMemoryCacheFactory());
        }

    }
}
