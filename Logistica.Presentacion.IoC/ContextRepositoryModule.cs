using Autofac;
using Med.Comun.Datos.Core;
using Med.Comun.Datos.ICore;
using Med.Comun.Datos.ICore.Repository;
using Logistica.Datos.Modelo.PEC;
using System;
using System.Reflection;
using Med.Comun.Core;
using Logistica.Datos.Interfaces;
using Logistica.Datos.Repositorio;
using Logistica.Dominio.RepositorioInterfaces;

namespace Logistica.Presentacion.IoC
{
	public class ContextRepositoryModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			string source = string.Empty;

			//Regedit
			string registryKey = System.Configuration.ConfigurationManager.AppSettings["StringsPEC_RegistryKey"];
			string metadata = System.Configuration.ConfigurationManager.AppSettings["MetaData"];
            //string dbContextValue = (string)RegeditManager.Read(registryKey, "PECDbContext", false);


            string dbContextValue = "Data Source=DESKTOP-D4CM9UP;Initial Catalog=db_PEC_v2;User ID=sa;Password=topsecret1;MultipleActiveResultSets=True;App=EntityFramework";

            source = new ConnectionStringManager().GetEntityConnection(dbContextValue, metadata);

			//Context
			builder.RegisterType<PECDbContext>().Named<IDbContext>("context").WithParameter("nameOrConnectionString", source).InstancePerLifetimeScope();
			//Resolve
			builder.RegisterType<UnitOfWorkPEC>().As<IUnitOfWorkPEC>().WithParameter((c, p) => true, (c, p) => p.ResolveNamed<IDbContext>("context"));
			builder.RegisterType<ContextAdapter>().As<IContext>().WithParameter((c, p) => true, (c, p) => p.ResolveNamed<IDbContext>("context"));

			//Repository
			builder.RegisterAssemblyTypes(Assembly.Load("Logistica.Datos.Repositorio"))
			   .Where(type => type.Name.EndsWith("Repository", StringComparison.Ordinal))
			   .AsImplementedInterfaces()
			   .InstancePerLifetimeScope();

			builder.RegisterGeneric(typeof(Repository<>))
				.As(typeof(IRepository<>))
				.InstancePerDependency();

         
            base.Load(builder);
		}
	}
}
