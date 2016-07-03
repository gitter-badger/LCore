using System;
using System.Web.Mvc;

namespace Singularity.Controllers
    {
    public class HomeController : SingularityController
        {
        public ActionResult Index()
            {
            return this.View();
            }
        }
    }