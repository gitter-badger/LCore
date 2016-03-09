
using Singularity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LCore;
using Singularity.Extensions;

namespace Singularity.Controllers
    {
    [Authorize]
    public class TemplateController : ManageController<Singularity.Models.Template>
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

        public void PreviewPDF(int id)
            {
            Template Temp = this.DBContext.GetDBSet<Template>().Find(id);

            Byte[] PDFBytes = Temp.GetPdfBytes();

            Response.WritePDF(PDFBytes, Temp.Description.CleanFileName() + ".pdf");
            }

        protected override Models.Template GetModel(int id, bool Create, Models.Template Model)
            {
            Template Content = base.GetModel(id, Create, Model);

            Content.TemplateHTML = HttpUtility.HtmlDecode(Content.TemplateHTML);

            return Content;
            }
        }
    }