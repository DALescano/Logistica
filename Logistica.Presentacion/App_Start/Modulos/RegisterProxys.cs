
//===================================================================================
// Template T4 for WCF Services Proxys
// NO Editar manualmente esta Clase
//===================================================================================
using Autofac;
using Logistica.Servicios.Host;
using System;
using System.ServiceModel.Channels;

namespace Logistica.Presentacion.App_Start.Modulos
{
    public partial class ProxysModule
    {
        //============================================================================================================
        // Registra en el contenedor Instancias de Servicios Proxys para : MED.SICRECE.Servicios.Administracion.Interfaces
        //============================================================================================================
		public static void Administracion_ServiceProxy(ContainerBuilder builder, Uri uriHost, Binding binding)
		{
            builder.RegisterServiceProxy<IAdministracionServicio>(uriHost, binding, "AdministracionServicio.svc");
            builder.RegisterServiceProxy<ISeguridadServicio>(uriHost, binding, "SeguridadServicio.svc");

        }

    }    
}
