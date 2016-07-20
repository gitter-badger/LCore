using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using LMVC.Context;
using System.Linq;
using LMVC.Annotations;

namespace LMVC.Models
    {
    public class Template : IModel
        {
        [Key]
        public int TemplateID { get; set; }

        [FieldLoadFromQueryString]
        [FieldFocus]
        public string Token { get; set; }

        public string Description { get; set; }

        [HideManageViewColumn]
        [FieldTypeHtmlContentEditor]
        [AllowHtml]
        [FieldLoadFromQueryString]
        public string TemplateHTML { get; set; }

        [HideManageViewColumn]
        public bool Active { get; set; }

        public byte[] GetPdfBytes()
            {
            return HtmlToPdf(this.TemplateHTML);
            }


        public static byte[] HtmlToPdf(string HTML)
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


        public static Template FindByToken(ModelContext Context, string Token)
            {
            var Content = Context.GetDBSet<Template>(
                ).FirstOrDefault(Template => Template.Token == Token &&
                    Template.Active);

            return Content;
            }

        public static string GetTemplateString(ModelContext Context, string Token)
            {
            string Out = "";

            var Content = FindByToken(Context, Token);

            if (Content != null)
                Out = Content.TemplateHTML;

            return Out;
            }
        }
    }