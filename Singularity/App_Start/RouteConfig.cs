using System.Web.Mvc;
using System.Web.Routing;
using LMVC.Controllers;

namespace Singularity.Config
    {
    public static class RouteConfig
        {
        public static void RegisterRoutes(RouteCollection Routes)
            {
            Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            Routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new
                    {
                    controller = "Home",
                    action = nameof(HomeController.Index),
                    id = UrlParameter.Optional
                    }
                //defaults: new { controller = Singularity.Routes.Controllers.Test.Name, action = Singularity.Routes.Controllers.Test.Actions.JavascriptTest, id = UrlParameter.Optional }
            );
            }
        }
    }
