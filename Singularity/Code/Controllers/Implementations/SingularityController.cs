using System;
using System.Web.Mvc;
using Singularity.Filters;
using Singularity.Extensions;

namespace Singularity.Controllers
    {
    [ErrorFilter]
    public abstract class SingularityController : Controller
        {
        public const string SessionLastError = "LastError";

        protected override void OnException(ExceptionContext filterContext)
            {
            try
                {
                ControllerHelper.HandleError(filterContext.HttpContext, filterContext.Exception);
                }
            catch (Exception e)
                {
                throw new Exception(filterContext.Exception.Message, e);
                }

            base.OnException(filterContext);

            this.Session[SessionLastError] = filterContext.Exception;

            filterContext.HttpContext.Response.Redirect(this.Url.Controller<ErrorController>().Action(c => c.Index));
            }

        }
    }
