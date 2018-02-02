using Autofac;
using Autofac.Integration.WebApi;
using Logistica.Servicios.IoC;
using System.Reflection;
using System.Web.Http;

namespace Logistica.Servicios
{
    public class Bootstrapper
    {
        public static IContainer Container;
        public static void LoadContainer(HttpConfiguration config)
        {
            #region WEB API
            Initialize(config, RegisterServices(new ContainerBuilder()));

           

            #endregion WEB API
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            BootstrapperContainer.ReturnContainer("Logistica.Aplicacion.Servicios", builder);

            //Configura las transversales
            FrameworkConfiguration.Configuration();

            BootstrapperContainer.ReturnContainerBuilderWebAPI(builder);

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            Container = builder.Build();

            return Container;
        }
    }
}