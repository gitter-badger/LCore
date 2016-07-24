using System;
using System.Web.Mvc;
using JetBrains.Annotations;
using LMVC.Controllers;
using LMVC.Extensions;

namespace LMVC.Filters
    {
    public class ErrorFilterAttribute : ActionFilterAttribute
        {
        public UrlHelper Url { get; set; }

        public override void OnResultExecuting([CanBeNull] ResultExecutingContext FilterContext)
            {
            if (FilterContext == null)
                return;

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

        public override void OnActionExecuting([CanBeNull] ActionExecutingContext FilterContext)
            {
            if (FilterContext == null)
                return;

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