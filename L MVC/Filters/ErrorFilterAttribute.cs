using System;
using System.Web.Mvc;
using LMVC.Controllers;
using LMVC.Extensions;

namespace LMVC.Filters
    {
    public class ErrorFilterAttribute : ActionFilterAttribute
        {
        public UrlHelper Url { get; set; }

        public override void OnResultExecuting(ResultExecutingContext FilterContext)
            {
            try
                {
                base.OnResultExecuting(FilterContext);
                }
            catch (Exception Ex)
                {
                this.LogError(Ex);
                
                FilterContext.HttpContext.Response.Redirect(
                    this.Url.Controller<ErrorController>().Action(Controller => Controller.Index));
                }
            }

        public override void OnActionExecuting(ActionExecutingContext FilterContext)
            {
            try
                {
                base.OnActionExecuting(FilterContext);
                }
            catch (Exception Ex)
                {
                this.LogError(Ex);
                
                FilterContext.HttpContext.Response.Redirect(this.Url.Controller<ErrorController>().Action(Controller => Controller.Index));
                }
            }

        protected virtual void LogError(Exception Ex)
            {
            }
        }
    }