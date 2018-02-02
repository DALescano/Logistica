using System.Collections.Generic;
using System.Web.Http.Controllers;
using System.Web.Http.Routing;

namespace Logistica.Servicios
{
    interface IDirectRouteProvider
    {
        IReadOnlyList<RouteEntry> GetDirectRoutes(
                                    HttpControllerDescriptor httpControllerDescriptor,
                                    IReadOnlyList<HttpActionDescriptor> httpActionDescriptor,
                                    IInlineConstraintResolver inlineConstraintResolver);
    }
}
