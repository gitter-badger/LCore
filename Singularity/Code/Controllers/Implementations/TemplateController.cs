
using Singularity.Models;
using System;
using System.Web;
using System.Web.Mvc;


using LCore.Extensions;
using Singularity.Account;
using Singularity.Extensions;

namespace Singularity.Controllers
    {
    [Authorize]
    public class TemplateController : ManageController<Template>
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

        public void PreviewPDF(int id)
            {
            var Temp = this.DBContext.GetDBSet<Template>().Find(id);

            byte[] PDFBytes = Temp.GetPdfBytes();

            this.Response.WritePDF(PDFBytes, $"{Temp.Description.CleanFileName()}.pdf");
            }

        protected override Template GetModel(int id, bool Create, Template Model)
            {
            var Content = base.GetModel(id, Create, Model);

            Content.TemplateHTML = HttpUtility.HtmlDecode(Content.TemplateHTML);

            return Content;
            }

        public TemplateController(IAuthenticationService Auth) : base(Auth) { }
        }
    }