
using Singularity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Singularity.Controllers
    {
    [Authorize]
    public class TextContentController : ManageController<Singularity.Models.TextContent>
        {
        public override string PageGroup
            {
            get
                {
                return ControllerHelper.Menu_Admin;
                }
            }

        [HttpPost, ValidateInput(false)]
        public override ActionResult Edit(int id, string ReturnURL, FormCollection Form, bool Create = false)
            {
            return base.Edit(id, ReturnURL, Form, Create);
            }

        [HttpPost, ValidateInput(false)]
        public override ActionResult Create(string ReturnURL, FormCollection Form)
            {
            return base.Create(ReturnURL, Form);
            }

        protected override Models.TextContent GetModel(int id, bool Create, Models.TextContent Model)
            {
            TextContent Content = base.GetModel(id, Create, Model);

            Content.Text = HttpUtility.HtmlDecode(Content.Text);

            return Content;
            }
        }
    }
