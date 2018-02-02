using Autofac;
using Autofac.Builder;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web;

namespace Logistica.Presentacion.App_Start.Modulos
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
            const string host = "Host.Url";
            const string binding = "Host.Binding";
            var b = ContainerBuilderExtensions.MakeBinding("basicHttpBinding");

            string baseServicios = host;
            //#if DEBUG
            baseServicios = "Servicios.Host.Url";
            
            //#endif

            //TODO: Colocar Metodo aqui si hay mas modulos
            /****Los Metodos se Generan automaticamente en la Plantilla T4: RegisterProxys.tt***/
            /****Para Nuevos Modulos, Agregue la Carpeta y el NameSpace de Contratos en: RegisterProxys.tt***/

            Administracion_ServiceProxy(builder, new Uri("http://localhost:2200/"), b);
        }
    }

    public static class ContainerBuilderExtensions
    {
        public static IRegistrationBuilder<TChannel, SimpleActivatorData, SingleRegistrationStyle> RegisterServiceProxy<TChannel>(this ContainerBuilder builder, Uri baseUri, Binding binding, string relativeUri)
        {
            builder.Register(c => new ChannelFactory<TChannel>(binding, new EndpointAddress(new Uri(baseUri, relativeUri)))).SingleInstance();
            return builder.Register(c => c.Resolve<ChannelFactory<TChannel>>().CreateChannel()).InstancePerLifetimeScope();
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