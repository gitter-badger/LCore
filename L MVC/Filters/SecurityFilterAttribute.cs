using System;
using System.Security;
using System.Web.Mvc;
using LMVC.Context;

namespace LMVC.Filters
    {
    public class SecurityFilterAttribute : ActionFilterAttribute, IAuthorizationFilter
        {
        /// <exception cref="SecurityException">HTTPS is required to view this site.</exception>
        public void OnAuthorization(AuthorizationContext FilterContext)
            {
            var Config = ContextProviderFactory.GetCurrent().GetContext(FilterContext.HttpContext.Session)
                .GetSiteConfig(FilterContext.HttpContext);

            string URL = FilterContext.HttpContext.Request.Url?.AbsoluteUri ?? "";
            URL = URL.ToLower();

            if (Config.RequireHTTPS && !URL.StartsWith("https://"))
                throw new SecurityException("HTTPS is required to view this site.");
            }

        protected virtual void LogError(Exception Ex)
            {
            }
        }
    }