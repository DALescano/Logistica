using Autofac;
using Autofac.Builder;
//using MED.Security.API.Authentication;
//using MED.Security.API.Authorization;

namespace Logistica.Servicios.IoC.Modules
{
    public class DependencyInjection : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<Authentication>().AsImplementedInterfaces<Authentication, ConcreteReflectionActivatorData>();
            //builder.RegisterType<BasicAuthorization>().AsImplementedInterfaces<BasicAuthorization, ConcreteReflectionActivatorData>();
        }
    }
}
