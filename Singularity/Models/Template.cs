using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Singularity;
using System.Web.Mvc;
using Singularity.Context;
using System.Linq;
using Singularity.Annotations;

namespace Singularity.Models
    {
    public class Template : IModel
        {
        [Key]
        public int TemplateID { get; set; }

        [FieldLoadFromQueryString]
        [FieldFocus]
        public String Token { get; set; }

        public String Description { get; set; }

        [HideManageViewColumn]
        [FieldType_HTMLContentEditor]
        [AllowHtml]
        [FieldLoadFromQueryString]
        public String TemplateHTML { get; set; }

        [HideManageViewColumn]
        public Boolean Active { get; set; }

        public override string ToString()
            {
            return base.ToString();
            }

        public Byte[] GetPdfBytes()
            {
            return HtmlToPdf(this.TemplateHTML);
            }


        public static Byte[] HtmlToPdf(String HTML)
            {
            return null;
            /*
            SelectPdf.HtmlToPdf converter = new SelectPdf.HtmlToPdf();

            // set converter options
            converter.Options.PdfPageSize = SelectPdf.PdfPageSize.A4;
            converter.Options.PdfPageOrientation = SelectPdf.PdfPageOrientation.Portrait;
            converter.Options.WebPageWidth = 800;
            converter.Options.MarginTop = 50;
            converter.Options.MarginBottom = 50;
            converter.Options.MarginLeft = 30;
            converter.Options.MarginRight = 30;
            //converter.Options.WebPageHeight = webPageHeight;

            // create a new pdf document converting an html string
            SelectPdf.PdfDocument doc = converter.ConvertHtmlString(HTML, "");

            // save pdf document
            Byte[] OutFile = doc.Save();

            // close pdf document
            doc.Close();

            return OutFile;
            */
            }


        public static Template FindByToken(ModelContext Context, String Token)
            {
            Template Content = Context.GetDBSet<Template>().Where(
                t => t.Token == Token &&
                    t.Active == true).FirstOrDefault();

            return Content;
            }

        public static String GetTemplateString(ModelContext Context, String Token)
            {
            String Out = "";

            Template Content = FindByToken(Context, Token);

            if (Content != null)
                Out = Content.TemplateHTML;

            return Out;
            }
        }
    }