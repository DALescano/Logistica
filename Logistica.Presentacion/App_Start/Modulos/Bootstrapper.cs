using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Logistica.Presentacion.App_Start.Modulos
{
    public class Bootstrapper
    {
        public static void LoadContainer(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            //Modules            
            builder.RegisterModule<ProxysModule>();

            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterApiControllers(typeof(MED.Comun.Seguridad.API.Controllers.SeguridadController).Assembly);


            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            /*config.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());

            var builder2 = new ContainerBuilder();
            builder2.RegisterModule<DependencyInjection>();
            builder2.RegisterModule<ProxysModule>();

            var container = builder2.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));*/
        }

        
    }
}