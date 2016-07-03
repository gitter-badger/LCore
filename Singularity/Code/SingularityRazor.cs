using System;
using System.Web.Mvc;
using Singularity.Account;

namespace Singularity.Extensions
    {
    public abstract class SingularityRazor : WebViewPage
        {
        public IAuthenticationService Auth { get; set; }
        }

    public abstract class SingularityRazor<T> : WebViewPage<T>
        {
        public IAuthenticationService Auth { get; set; }
        }
    }
