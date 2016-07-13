﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SingularityInstance.Controllers
    {
    public class HomeController : Controller
        {
        public ActionResult Index()
            {
            return this.View();
            }

        public ActionResult About()
            {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
            }

        public ActionResult Contact()
            {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
            }
        }
    }