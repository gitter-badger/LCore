using System;
using System.Collections.Generic;
using System.Web.Mvc;
using JetBrains.Annotations;
using LCore.Tools;
using LMVC.Account;
using LMVC.Filters;
using LMVC.Extensions;
using LMVC.Routes;

namespace LMVC.Controllers
    {
    [ErrorFilter]
    public abstract class SingularityController : Controller, ISingularityController
        {
        public const string SessionLastError = "LastError";

        // ReSharper disable once MemberCanBeProtected.Global
        public IAuthenticationService Auth { get; set; }

        /// <exception cref="InvalidOperationException"></exception>
        protected override void OnException([CanBeNull] ExceptionContext FilterContext)
            {
            if (FilterContext == null)
                return;

            try
                {
                ControllerHelper.HandleError(FilterContext.HttpContext, FilterContext.Exception);
                }
            catch (Exception Ex)
                {
                throw new InvalidOperationException(FilterContext.Exception.Message, Ex);
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

