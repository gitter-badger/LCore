﻿
using System;
using System.Web;
using System.Web.Mvc;
using LMVC.Account;
using LMVC.Controllers;
using LMVC.Extensions;

namespace LMVC.Filters
    {
    public class RequireAuthAttribute : AuthorizeAttribute
        {
        public IAuthenticationService Auth { get; set; }
        public UrlHelper Url { get; set; }

        public override void OnAuthorization(AuthorizationContext FilterContext)
            {
            base.OnAuthorization(FilterContext);
            }

        /// <exception cref="ArgumentNullException"><paramref name="HttpContext"/> is <see langword="null" />.</exception>
        protected override bool AuthorizeCore(HttpContextBase HttpContext)
            {
            if (HttpContext == null) throw new ArgumentNullException(nameof(HttpContext));

            if (this.Auth.IsLoggedIn &&
                this.Auth.LoggedInUser != null &&
                this.Auth.LoggedInUser.Enabled)
                {
                if (this.Auth.LoggedInUser.PasswordResetRequired &&
                    !HttpContext.Request.Url?.AbsoluteUri.EndsWith(nameof(AccountController.ForceResetPassword)) == true &&
                    !this.Auth.IsImpersonating)
                    {
                    HttpContext.Response.Redirect(this.Url.Action(nameof(AccountController.ForceResetPassword), typeof(AccountController).CName()));

                    return true;
                    }

                return true;
                }

            return false;
            }
        }
    }