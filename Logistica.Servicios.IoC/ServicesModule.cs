using Autofac;
using System;
using System.Reflection;

namespace Logistica.Servicios.IoC
{
	public class ServicesModule : Autofac.Module
	{
		public string AssemblyStringService { get; set; }
		public string AssemblyStringApplicationService { get; set; }

		protected override void Load(ContainerBuilder builder)
		{			
			//Service
			//builder.RegisterAssemblyTypes(Assembly.Load(AssemblyStringService))
			//	.Where(type => type.Name.EndsWith("Servicio", StringComparison.Ordinal))
			//	.AsImplementedInterfaces();

			//Application
			builder.RegisterAssemblyTypes(Assembly.Load(AssemblyStringApplicationService))
				.Where(type => type.Name.EndsWith("Aplicacion", StringComparison.Ordinal))
				.AsImplementedInterfaces();

			//Application
			builder.RegisterAssemblyTypes(Assembly.Load(AssemblyStringApplicationService))
				.Where(type => type.Name.EndsWith("Validacion", StringComparison.Ordinal))
				.AsSelf();

			builder.RegisterAssemblyTypes(Assembly.Load(AssemblyStringApplicationService))
				.Where(type => type.Name.EndsWith("Proceso", StringComparison.Ordinal))
				.AsSelf();
			
		}
	}
}
