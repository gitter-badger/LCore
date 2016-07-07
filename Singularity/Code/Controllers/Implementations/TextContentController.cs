
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
        public override ActionResult Edit(int id, string ReturnURL, FormCollection Form, bool Create = false)
            {
            return base.Edit(id, ReturnURL, Form, Create);
            }

        [HttpPost, ValidateInput(false)]
        public override ActionResult Create(string ReturnURL, FormCollection Form)
            {
            return base.Create(ReturnURL, Form);
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
