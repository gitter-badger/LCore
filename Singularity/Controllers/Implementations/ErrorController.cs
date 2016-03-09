
using Singularity.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Singularity.Controllers
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
