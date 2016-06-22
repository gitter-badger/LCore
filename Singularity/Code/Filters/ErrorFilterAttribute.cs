using System;
using System.Web.Mvc;
using Singularity.Controllers;
using Singularity.Extensions;

namespace Singularity.Filters
    {
    public class ErrorFilterAttribute : ActionFilterAttribute
        {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
            {
            try
                {
                base.OnResultExecuting(filterContext);
                }
            catch (Exception e)
                {
                this.LogError(e);

                UrlHelper Url = new UrlHelper(filterContext.RequestContext);
                filterContext.HttpContext.Response.Redirect(Url.Controller<ErrorController>().Action(c => c.Index));
                }
            }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
            try
                {
                base.OnActionExecuting(filterContext);
                }
            catch (Exception e)
                {
                this.LogError(e);

                UrlHelper Url = new UrlHelper(filterContext.RequestContext);
                filterContext.HttpContext.Response.Redirect(Url.Controller<ErrorController>().Action(c => c.Index));
                }
            }

        protected virtual void LogError(Exception e)
            {
            }
        }
    }