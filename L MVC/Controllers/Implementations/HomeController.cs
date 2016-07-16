using System;
using System.Web.Mvc;
using Singularity.Account;

namespace Singularity.Controllers
    {
    public class HomeController : SingularityController
        {
        public ActionResult Index()
            {
            return this.View();
            }

        public HomeController(IAuthenticationService Auth) : base(Auth) { }
        }
    }