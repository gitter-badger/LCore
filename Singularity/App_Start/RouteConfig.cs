using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Singularity.Config
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = Singularity.Routes.Controllers.Test.Name, action = Singularity.Routes.Controllers.Test.Actions.SingularityTest, id = UrlParameter.Optional }
            );
        }
    }
}
