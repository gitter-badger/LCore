using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace SingularityInstance
    {
    public class RouteConfig
        {
        public static void RegisterRoutes(RouteCollection Routes)
            {
            Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            Routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            }
        }
    }
