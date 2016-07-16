using System;
using System.Web;

namespace Singularity.Attributes
    {
    public class RequireAdminAttribute : RequireAuthAttribute
        {
        protected override bool AuthorizeCore(HttpContextBase HttpContext)
            {
            bool BaseResult = base.AuthorizeCore(HttpContext);

            if (BaseResult)
                {
                if (this.Auth.IsLoggedIn && this.Auth.LoggedInUser.IsAdmin)
                    return true;
                }

            return false;
            }
        }
    }
