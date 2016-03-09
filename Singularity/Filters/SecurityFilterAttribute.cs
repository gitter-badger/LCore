using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Singularity.Routes;
using Singularity.Context;
using Singularity.Models;

namespace Singularity.Filters
    {
    public class SecurityFilterAttribute : ActionFilterAttribute, IAuthorizationFilter
        {
        public SecurityFilterAttribute()
            {

            }

        public void OnAuthorization(AuthorizationContext FilterContext)
            {
            SiteConfig Config = ContextProviderFactory.GetCurrent().GetContext(FilterContext.HttpContext.Session).GetSiteConfig(FilterContext.HttpContext);

            String URL = FilterContext.HttpContext.Request.Url.AbsoluteUri ?? "";
            URL = URL.ToLower();

            if (Config.RequireHTTPS && !URL.StartsWith("https://"))
                throw new Exception("HTTPS is required to view this site.");
            }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
            {
            base.OnResultExecuting(filterContext);
            }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
            base.OnActionExecuting(filterContext);
            }

        private void LogError(Exception e)
            {
            // TODO: Log error here
            /////
            }
        }
    }