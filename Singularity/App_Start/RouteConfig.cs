﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Singularity.Config
    {
    public class RouteConfig
        {
        public static void RegisterRoutes(RouteCollection routes)
            {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = Routes.Controllers.Test.Name, action = Routes.Controllers.Test.Actions.SingularityTest, id = UrlParameter.Optional }
                //defaults: new { controller = Singularity.Routes.Controllers.Test.Name, action = Singularity.Routes.Controllers.Test.Actions.JavascriptTest, id = UrlParameter.Optional }
            );
            }
        }
    }
