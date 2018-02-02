using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logistica.Framework
{

    public class AutomapperTypeAdapter : ITypeAdapter
    {

        public List<TTarget> ToEntity<TSource, TTarget>(List<TSource> listsource, params MapperChild[] childs)
        {
            var listdestination = new List<TTarget>();
            foreach (var loc in listsource)
                listdestination.Add(ToEntity<TSource, TTarget>(loc, childs));

            return listdestination;
        }

        public class LowerUnderscoreNamingConvention : INamingConvention
        {
            public Regex SplittingExpression { get; } = new Regex(@"[\p{Ll}\p{Lu}0-9]+(?=_?)");

            public string SeparatorCharacter => "_";

            public string ReplaceValue(Match match) => match.Value.ToLower();
        }

        public TTarget ToEntity<TSource, TTarget>(TSource source, params MapperChild[] childs)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsVirtual;
                cfg.CreateMap<TSource, TTarget>();
                cfg.DestinationMemberNamingConvention = new LowerUnderscoreNamingConvention();
                if (childs != null)
                    foreach (var d in childs)
                        cfg.CreateMap(d.Source, d.Destination);

            });

            var mapper = config.CreateMapper();

            return mapper.Map<TSource, TTarget>(source);

        }

        public List<TTarget> ToDto<TSource, TTarget>(List<TSource> listsource, params MapperChild[] childs)
        {
            var listdestination = new List<TTarget>();
            foreach (var loc in listsource)
                listdestination.Add(ToDto<TSource, TTarget>(loc, childs));

            return listdestination;
        }

        //Source 
        public TTarget ToDto<TSource, TTarget>(TSource source, params MapperChild[] childs)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsVirtual;
                cfg.CreateMap<TSource, TTarget>();
                cfg.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
                if (childs != null)
                    foreach (var d in childs)
                        cfg.CreateMap(d.Source, d.Destination);

            });

            var mapper = config.CreateMapper();

            return mapper.Map<TSource, TTarget>(source);
        }
    }
}
