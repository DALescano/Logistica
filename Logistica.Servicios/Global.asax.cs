using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.SessionState;

namespace Logistica.Servicios
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start()
        {



            Bootstrapper.LoadContainer(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configure(WebApiConfig.Register);


        }

        protected void Application_PreSendRequestHeaders()
        {
            Response.Headers.Remove("Server");
            Response.Headers.Remove("X-AspNet-Version");
            Response.Headers.Remove("X-Powered-By");
            Response.Headers.Remove("X-AspNetMvc-Version");
        }
    }
}