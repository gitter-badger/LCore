
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

        protected override Models.TextContent GetModel(int id, bool Create, Models.TextContent Model)
            {
            TextContent Content = base.GetModel(id, Create, Model);

            Content.Token = Request.QueryString["Token"] ?? "";
            Content.Text = Request.QueryString["DefaultText"] ?? "";

            return Content;
            }
        }
    }
