using System;
using System.IO;
using System.Reflection;
using Autofac;
using Logistica.Servicios.IoC.Modules;
using Logistica.Servicios.IoC.Other;
using Logistica.Servicios.IoC.Proxy;

namespace Logistica.Servicios.IoC
{
	public class BootstrapperContainer
	{
		public static void ReturnContainerBuilderWebAPI(ContainerBuilder builder)
		{
			

			
			builder.RegisterModule<OtherModule>();
			builder.RegisterModule<ProxysModule>();

			
		}
		public static void ReturnContainerBuilderMvc(ContainerBuilder builder)
		{
			

			
			builder.RegisterModule<DependencyInjection>();
			builder.RegisterModule<OtherModule>();
			builder.RegisterModule<ProxysModule>();

			
		}

        public static void ReturnContainer(string assemblyStringApplicationService, ContainerBuilder builder)
        {

            builder.RegisterModule<ContextRepositoryModule>();
            var servicesModule = new ServicesModule
            {

                AssemblyStringApplicationService = assemblyStringApplicationService
            };
            builder.RegisterModule<OtherModule>();
            builder.RegisterModule(servicesModule);


        }

        public static string GetRootPath()
		{
			var codeBase = Assembly.GetExecutingAssembly().CodeBase;
			var uri = new UriBuilder(codeBase);
			var pathBin = Path.GetDirectoryName(Uri.UnescapeDataString(uri.Path));
			return pathBin.Replace(@"\bin", @"\");
		}
	}
}
