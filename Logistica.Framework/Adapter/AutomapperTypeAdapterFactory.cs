using System;
using System.Collections.Generic;
using System.Linq;

namespace Logistica.Framework
{
    public class AutomapperTypeAdapterFactory : ITypeAdapterFactory
    {
        public ITypeAdapter Create()
        {
            return new AutomapperTypeAdapter();
        }
    }
}
