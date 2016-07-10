﻿
using Singularity.Models;
using System.Web;
using System.Web.Mvc;
using Singularity.Account;

namespace Singularity.Controllers
    {
    [Authorize]
    public class TextContentController : ManageController<TextContent>
        {
        public override string PageGroup => ControllerHelper.Menu_Admin;

        [HttpPost, ValidateInput(false)]
        public override ActionResult Edit(int id, string ReturnUrl, FormCollection Form, bool Create = false)
            {
            return base.Edit(id, ReturnUrl, Form, Create);
            }

        [HttpPost, ValidateInput(false)]
        public override ActionResult Create(string ReturnUrl, FormCollection Form)
            {
            return base.Create(ReturnUrl, Form);
            }

        protected override TextContent GetModel(int id, bool Create, TextContent Model)
            {
            var Content = base.GetModel(id, Create, Model);

            Content.Text = HttpUtility.HtmlDecode(Content.Text);

            return Content;
            }

        public TextContentController(IAuthenticationService Auth) : base(Auth) { }
        }
    }
