using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.IO;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Mvc;
using System.Web.Routing;

using LCore;

using System.Collections;
using Singularity;
using Singularity.Filters;
using Singularity.Models;
using Singularity.Context;
using Singularity.Extensions;

namespace Singularity.Controllers
    {
    [ErrorFilter]
    public abstract class SingularityController : Controller
        {
        public const String SessionLastError = "LastError";

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

            Session[SessionLastError] = filterContext.Exception;

            filterContext.HttpContext.Response.Redirect(Url.Controller<ErrorController>().Action(c => c.Index));
            }

        }
    }
