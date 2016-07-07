using System;
using System.Web.Mvc;
using Singularity.Account;
using Singularity.Controllers;

namespace Singularity.Extensions
    {
    public abstract class SingularityRazor : WebViewPage
        {
        public IAuthenticationService Auth { get; set; }

        public SingularityController SingController => this.ViewContext.Controller as SingularityController;
        }

    public abstract class SingularityRazor<T> : WebViewPage<T>
        {
        public IAuthenticationService Auth { get; set; }

        public SingularityController SingController => this.ViewContext.Controller as SingularityController;
        }
    }
