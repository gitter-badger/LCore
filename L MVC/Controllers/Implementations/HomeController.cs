using System;
using System.Web.Mvc;
using LMVC.Account;

namespace LMVC.Controllers
    {
    public class HomeController : SingularityController
        {
        public ActionResult Index()
            {
            // ReSharper disable once Mvc.ViewNotResolved
            return this.View();
            }

        public HomeController(IAuthenticationService Auth) : base(Auth) { }
        }
    }