using System;
using System.Collections.Generic;
using System.Web.Mvc;
using LCore.Tools;
using Singularity.Account;
using Singularity.Filters;
using Singularity.Extensions;
using Singularity.Routes;

namespace Singularity.Controllers
    {
    [ErrorFilter]
    public abstract class SingularityController : Controller
        {
        public const string SessionLastError = "LastError";

        public IAuthenticationService Auth { get; set; }

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

        private Set<string, string>[] _Breadcrumbs { get; set; }

        public Set<string, string>[] Breadcrumbs
            {
            get
                {
                return this._Breadcrumbs;
                }
            set
                {
                // Set the ViewBag Title automaticaly
                if (value?.Length > 0)
                    {
                    this.ViewBag.Title = value[value.Length - 1].Obj1;
                    }

                this._Breadcrumbs = value;
                }
            }

        public virtual string DefaultLayout => Layouts.Main;

        protected SingularityController(IAuthenticationService Auth)
            {
            this.Auth = Auth;
            }
        }
    }

