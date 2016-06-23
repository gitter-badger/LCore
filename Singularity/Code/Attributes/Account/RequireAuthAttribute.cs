
using System;
using System.Web;
using System.Web.Mvc;
using Singularity.Account;

namespace Singularity.Attributes
    {
    public class RequireAuthAttribute : AuthorizeAttribute
        {
        public override void OnAuthorization(AuthorizationContext FilterContext)
            {
            base.OnAuthorization(FilterContext);
            }

        protected override bool AuthorizeCore(HttpContextBase HttpContext)
            {
            if (HttpContext == null) throw new ArgumentNullException(nameof(HttpContext));

            AuthenticationService Auth = new AuthenticationService(HttpContext.Session);

            if (Auth.IsLoggedIn &&
                Auth.LoggedInUser != null &&
                Auth.LoggedInUser.Enabled)
                {
                if (Auth.LoggedInUser.PasswordResetRequired &&
                    !HttpContext.Request.Url?.AbsoluteUri.EndsWith(Routes.Controllers.Account.Actions.ForceResetPassword) == true &&
                    !Auth.IsImpersonating)
                    {
                    HttpContext.Response.Redirect(
                        new UrlHelper(HttpContext.Request.RequestContext)
                            .Action(Routes.Controllers.Account.Actions.ForceResetPassword, Routes.Controllers.Account.Name));

                    return true;
                    }

                return true;
                }

            return false;
            }
        }
    }
