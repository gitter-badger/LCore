using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Singularity.Extensions;
using Singularity.Models;
using Singularity.Routes;
using LCore.Extensions;
using LCore.Tools;
using Singularity.Account;


namespace Singularity.Controllers
    {
    public class ExamplesController : SingularityController, IDefaultViewLayout
        {
        [MenuAction(null, FontAwesomeExt.Icon.circle)]
        public ActionResult Home()
            {
            this.Breadcrumbs = new[]
                {
                new Set<string, string>(nameof(this.Home), this.Url.Action(nameof(this.Home)))
                };

            return this.View();
            }


        [MenuAction(null, FontAwesomeExt.Icon.gbp, nameof(Home))]
        public ActionResult L()
            {
            this.Breadcrumbs = new[]
                {
                new Set<string, string>(nameof(this.Home), this.Url.Action(nameof(this.Home))),
                new Set<string, string>(nameof(this.L), this.Url.Action(nameof(this.L)))
                };
            return this.View(typeof(L));
            }

        [Route("/Examples/L/Extensions")]
        [MenuAction(null, FontAwesomeExt.Icon.chain, nameof(L))]
        public ActionResult L_Extensions()
            {
            this.Breadcrumbs = new[]
                {
                new Set<string, string>(nameof(this.Home), this.Url.Action(nameof(this.Home))),
                new Set<string, string>(nameof(this.L), this.Url.Action(nameof(this.L))),
                new Set<string, string>("Extensions", this.Url.Action(nameof(this.L_Extensions)))
                };

            return this.View(typeof(LogicExt));
            }

        [Route("/Examples/L/Extensions/{ClassName:string}")]
        [MenuAction(null, FontAwesomeExt.Icon.chain, nameof(L_Extensions))]
        public ActionResult L_Extensions_Class(string ClassName)
            {
            var ExtClass = LCore.Extensions.L.Ref.FindType($"LCore.Extensions.{ClassName}");

            ClassName = ClassName.TrimEnd("Ext");

            this.Breadcrumbs = new[]
                {
                new Set<string, string>(nameof(this.Home), this.Url.Action(nameof(this.Home))),
                new Set<string, string>(nameof(this.L), this.Url.Action(nameof(this.L))),
                new Set<string, string>("Extensions", this.Url.Action(nameof(this.L_Extensions))),
                // ReSharper disable once RedundantAnonymousTypePropertyName
                new Set<string, string>(ClassName, this.Url.Action(nameof(this.L_Extensions_Class), new { ClassName =ClassName }))
                };

            return this.View(ExtClass);
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

        public override string DefaultLayout => Layouts.Admin;
        public ExamplesController(IAuthenticationService Auth) : base(Auth) { }
        }
    }
