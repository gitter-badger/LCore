using System;
using System.Web.Mvc;
using Singularity.Extensions;
using Singularity.Models;
using Singularity.Routes;

namespace Singularity.Controllers
    {
    public class ExamplesController : Controller, IDefaultViewLayout
        {
        [MenuAction(null, FontAwesomeExt.Icon.circle)]
        public ActionResult Home()
            {
            return this.View();
            }

        [MenuAction(null, FontAwesomeExt.Icon.circle, nameof(Home))]
        public ActionResult Singularity()
            {
            return this.View();
            }

        [Route("Examples/Singularity/Extensions")]
        [MenuAction(null, FontAwesomeExt.Icon.chain, nameof(Singularity))]
        public ActionResult SingularityExtensions()
            {
            return this.View();
            }

        [Route("Examples/Singularity/Extensions/{Type}")]
        [MenuAction(null, FontAwesomeExt.Icon.question, nameof(SingularityExtensions))]
        public ActionResult SingularityExtensionType(string Type)
            {
            return this.View();
            }

        [Route("Examples/Singularity/Extensions/{Type}/{Method}")]
        [MenuAction(null, FontAwesomeExt.Icon.chain, nameof(Singularity))]
        public ActionResult SingularityExtensionMethod(string Type, string Method)
            {
            return this.View();
            }




        public string DefaultLayout => Layouts.Admin;
        }
    }
