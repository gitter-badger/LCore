using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Singularity.Routes;

namespace Singularity.Filters
    {
    public class ErrorFilterAttribute : ActionFilterAttribute
        {
        public ErrorFilterAttribute()
            {

            }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
            {
            try
                {
                base.OnResultExecuting(filterContext);
                }
            catch (Exception e)
                {
                LogError(e);

                UrlHelper Url = new UrlHelper(filterContext.RequestContext);
                filterContext.HttpContext.Response.Redirect(Url.Action(Singularity.Routes.Controllers.Error.Name, Singularity.Routes.Controllers.Error.Actions.Index));
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
                LogError(e);

                UrlHelper Url = new UrlHelper(filterContext.RequestContext);
                filterContext.HttpContext.Response.Redirect(Url.Action(Singularity.Routes.Controllers.Error.Name, Singularity.Routes.Controllers.Error.Actions.Index));
                }
            }

        private void LogError(Exception e)
            {
            // TODO: Log error here
            /////
            }
        }
    }