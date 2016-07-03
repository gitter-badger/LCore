using System;
using System.Web.Mvc;
using Singularity.Controllers;
using Singularity.Extensions;

namespace Singularity.Filters
    {
    public class ErrorFilterAttribute : ActionFilterAttribute
        {
        public UrlHelper Url { get; set; }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
            {
            try
                {
                base.OnResultExecuting(filterContext);
                }
            catch (Exception e)
                {
                this.LogError(e);
                
                filterContext.HttpContext.Response.Redirect(this.Url.Controller<ErrorController>().Action(c => c.Index));
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
                
                filterContext.HttpContext.Response.Redirect(this.Url.Controller<ErrorController>().Action(c => c.Index));
                }
            }

        protected virtual void LogError(Exception e)
            {
            }
        }
    }