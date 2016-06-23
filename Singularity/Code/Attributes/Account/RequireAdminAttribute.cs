using System;
using System.Web;
using Singularity.Account;

namespace Singularity.Attributes
    {
    public class RequireAdminAttribute : RequireAuthAttribute
        {
        protected override bool AuthorizeCore(HttpContextBase HttpContext)
            {
            bool BaseResult = base.AuthorizeCore(HttpContext);

            if (BaseResult)
                {
                AuthenticationService Auth = new AuthenticationService(HttpContext.Session);

                if (Auth.IsLoggedIn && Auth.LoggedInUser.IsAdmin)
                    return true;
                }

            return false;
            }
        }
    }
