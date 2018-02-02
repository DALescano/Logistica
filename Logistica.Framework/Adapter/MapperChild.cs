using System;
using System.Collections.Generic;
using System.Linq;

namespace Logistica.Framework
{
    public class MapperChild
    {
        Type source;
        Type destination;
        public MapperChild(Type source, Type destination)
        {
            this.source = source;
            this.destination = destination;
        }

        public Type Source { get { return source; } }
        public Type Destination { get { return destination; } }

    }
}
