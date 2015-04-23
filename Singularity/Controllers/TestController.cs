using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using LCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.IO;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Singularity.Models;
using Singularity.Context;
using System.Web.Mvc;

namespace Singularity.Controllers
{
    public class TestController : Controller
    {
        public ActionResult JavascriptTest()
        {
            return View();
        }

        public ActionResult SingularityTest()
        {
            return View();
        }
    }
}
