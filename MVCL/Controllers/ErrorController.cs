
using MVCL.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCL.Controllers
{
    [Authorize]
    public class ErrorController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
    }
}
