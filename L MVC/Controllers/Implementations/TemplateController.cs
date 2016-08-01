
using LMVC.Models;
using System;
using System.Web;
using System.Web.Mvc;


using LCore.Extensions;
using LMVC.Account;
using LMVC.Extensions;

namespace LMVC.Controllers
    {
    [Authorize]
    public class TemplateController : ManageController<Template>
        {
        public override string PageGroup => SingularityControllerHelper.Menu_Admin;

        [HttpPost, ValidateInput(false)]
        public override ActionResult Edit(int ID, string ReturnUrl, FormCollection Form, bool Create = false)
            {
            return base.Edit(ID, ReturnUrl, Form, Create);
            }

        [HttpPost, ValidateInput(false)]
        public override ActionResult Create(string ReturnUrl, FormCollection Form)
            {
            return base.Create(ReturnUrl, Form);
            }

        public void PreviewPdf(int ID)
            {
            var Temp = this.DbContext.GetDBSet<Template>()?.Find(ID);

            byte[] PdfBytes = Temp?.GetPdfBytes();

            if (Temp != null)
                this.Response.WritePDF(PdfBytes, $"{Temp.Description.CleanFileName()}.pdf");
            }

        protected override Template GetModel(int ID, bool Create, Template Model)
            {
            var Content = base.GetModel(ID, Create, Model);

            Content.TemplateHTML = HttpUtility.HtmlDecode(Content.TemplateHTML);

            return Content;
            }

        public TemplateController(IAuthenticationService Auth) : base(Auth) { }
        public TemplateController() : base() { }
        }
    }