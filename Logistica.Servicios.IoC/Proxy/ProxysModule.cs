using Autofac;
using Autofac.Builder;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Autofac.Integration.Wcf;

namespace Logistica.Servicios.IoC.Proxy
{
    public partial class ProxysModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ServiceProxy(builder);
        }

        private static void ServiceProxy(ContainerBuilder builder)
        {
            NameValueCollection keys = ConfigurationManager.AppSettings;

            string urlHost = "Logistica.Host.Url";
            Binding bindingService = ContainerBuilderExtensions.MakeBinding(keys["Logistica.Host.Binding"]);

            //PEC
            //PEC_ServiceProxy(builder, new Uri(keys[urlHost]), bindingService);

        }
    }

    public static class ContainerBuilderExtensions
    {
        public static IRegistrationBuilder<TChannel, SimpleActivatorData, SingleRegistrationStyle> RegisterServiceProxy<TChannel>(this ContainerBuilder builder, Uri baseUri, Binding binding, string relativeUri)
        {
            builder.Register(c => new ChannelFactory<TChannel>(binding, new EndpointAddress(new Uri(baseUri, relativeUri))))
                   .SingleInstance();

            return builder.Register(c => c.Resolve<ChannelFactory<TChannel>>().CreateChannel())
                   .UseWcfSafeRelease();
        }

        public static Binding MakeBinding(string @bindingName)
        {
            // Bindings Soportados en el Servidor de Servicios

            Binding binding = null;
            switch (@bindingName)
            {
                case "basicHttpBinding":
                    binding = new BasicHttpBinding("proxyHttpBinding");
                    break;

                case "customBinding":
                    binding = new CustomBinding("proxyHttpBinding");
                    break;
            }
            //Es el mismo nombre que el web.config
            return binding;
        }
    }
}
