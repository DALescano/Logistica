using Autofac;
using Med.Comun.Datos.Core;
using Med.Comun.Datos.ICore;
using Med.Comun.Datos.ICore.Repository;
using Logistica.Datos.Interfaces;
using Logistica.Datos.Modelo.PEC;
using Logistica.Datos.Repositorio;
using Logistica.Dominio.RepositorioInterfaces;
using Logistica.Servicios.IoC;
using System;
using System.Linq;
using System.Reflection;

namespace Logistica.Servicios.Host
{
    public static class AutofacContainerBuilder
    {
        /// <summary>
        /// Configures and builds Autofac IOC container.
        /// </summary>
        /// <returns></returns>
        public static IContainer BuildContainer()
        {
            string source = string.Empty;

            var builder = new ContainerBuilder();

            //Regedit
            //string registryKey = System.Configuration.ConfigurationManager.AppSettings["StringsPEC_RegistryKey"];
            string metadata = System.Configuration.ConfigurationManager.AppSettings["MetaData"];
            //string dbContextValue = (string)RegeditManager.Read(registryKey, "PECDbContext", false);
            //string dbContextValue = System.Configuration.ConfigurationManager.AppSettings["PECDbContext"];


           //string dbContextValue = "Data Source=sql5037.site4now.net;Initial Catalog=DB_A1FCC3_pec;User ID=DB_A1FCC3_pec_admin;Password=topsecret1;MultipleActiveResultSets=True;App=EntityFramework";
            string dbContextValue = "Data Source=LENOVO-PC\\MSSQLSERVERXPR;Initial Catalog=Logistica;User ID=sa;Password=123456;MultipleActiveResultSets=True;App=EntityFramework";

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

          

            
            var servicesModule = new ServicesModule
            {

                AssemblyStringApplicationService = "Logistica.Aplicacion.Servicios"
            };
           
            builder.RegisterModule(servicesModule);
            builder.RegisterType<AdministracionServicio>().As<IAdministracionServicio>();
            builder.RegisterType<SeguridadServicio>().As<ISeguridadServicio>();
            // build container
            return builder.Build();
        }
    }
}