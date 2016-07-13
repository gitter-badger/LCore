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

        // ReSharper disable once MemberCanBeProtected.Global
        public IAuthenticationService Auth { get; set; }

        protected override void OnException(ExceptionContext FilterContext)
            {
            try
                {
                ControllerHelper.HandleError(FilterContext.HttpContext, FilterContext.Exception);
                }
            catch (Exception Ex)
                {
                throw new Exception(FilterContext.Exception.Message, Ex);
                }

            base.OnException(FilterContext);

            this.Session[SessionLastError] = FilterContext.Exception;

            FilterContext.HttpContext.Response.Redirect(this.Url.Controller<ErrorController>().Action(Controller => Controller.Index));
            }

        private Set<string, string>[] _Breadcrumbs { get; set; }

        public Set<string, string>[] Breadcrumbs
            {
            get
                {
                return this._Breadcrumbs;
                }
            protected set
                {
                // Set the ViewBag Title automatically
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

