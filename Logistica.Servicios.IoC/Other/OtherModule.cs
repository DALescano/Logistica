using Autofac;
using Autofac.Core;
using Med.Comun.Core.File;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Logistica.Servicios.IoC.Other
{
    public class OtherModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            var param = new List<Parameter>
                {
                    new NamedParameter("localFolder", null),
                    new NamedParameter("remoteFolder", null)
                };

            builder.RegisterType<FileManager>().As<IFileManager>().WithParameters(param);

            base.Load(builder);
        }
    }
}
