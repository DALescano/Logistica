using System.Web.Http;
using System.Web.Http.Cors;

namespace Logistica.Servicios
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            /*Configuraciones personalizadas*/

            //Enable CORS : origins, headers, methods
            //var cors = new EnableCorsAttribute("www.example.com", "*", "*");
            //https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/enabling-cross-origin-requests-in-web-api
            // var cors = new EnableCorsAttribute("*", "*", "*");
            var cors = new EnableCorsAttribute(origins: "http://199.89.53.22:70,http://localhost:4300", headers: "*", methods: "*");

            config.EnableCors(cors);

            //Evitar las referencias circulares al trabajar con entidades relacionadas
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;

            //Eliminar el parseo en XML, sólo se trabajará con JSON
            config.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            //Eliminar $id y $ref de la serializacion
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
        }
    }
}
