using System;
using System.Web.Mvc;
using Singularity.Context;

namespace Singularity.Filters
    {
    public class SecurityFilterAttribute : ActionFilterAttribute, IAuthorizationFilter
        {
        public void OnAuthorization(AuthorizationContext FilterContext)
            {
            var Config = ContextProviderFactory.GetCurrent().GetContext(FilterContext.HttpContext.Session).GetSiteConfig(FilterContext.HttpContext);

            string URL = FilterContext.HttpContext.Request.Url?.AbsoluteUri ?? "";
            URL = URL.ToLower();

            if (Config.RequireHTTPS && !URL.StartsWith("https://"))
                throw new Exception("HTTPS is required to view this site.");
            }

        protected virtual void LogError(Exception e)
            {
            }
        }
    }