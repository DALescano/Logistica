using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Framework
{
    public interface ITypeAdapter
    {
        List<TTarget> ToEntity<TSource, TTarget>(List<TSource> listsource, params MapperChild[] childs);
        TTarget ToEntity<TSource, TTarget>(TSource source, params MapperChild[] childs);

        List<TTarget> ToDto<TSource, TTarget>(List<TSource> listsource, params MapperChild[] childs);
        TTarget ToDto<TSource, TTarget>(TSource source, params MapperChild[] childs);
    }
}
