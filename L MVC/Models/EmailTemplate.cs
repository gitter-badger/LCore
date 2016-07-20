using LMVC.Context;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using LMVC.Annotations;


namespace LMVC.Models
    {
    public class EmailTemplate : IModel
        {
        [Key]
        public int EmailTemplateID { get; set; }

        [Required]
        public string Subject { get; set; }

        [FieldTypeHtmlContentEditor]
        public string Body { get; set; }

        [FieldTypeDropdownContextManageControllers(MultiSelect: true)]
        public string Pages { get; set; }

        [HideManageViewColumn]
        [FieldTypeFileUpload]
        [NotMapped]
        public string Attachments { get; set; }

        [HideManageViewColumn]
        public bool Active { get; set; }

        public override string ToString()
            {
            return this.Subject;
            }

        public static IQueryable<EmailTemplate> FindPageTemplates(ModelContext DbContext, string ControllerName)
            {
            return DbContext.GetDBSet<EmailTemplate>().Where(
                Template => Template.Active &&
                    (Template.Pages.Contains($"{ControllerName},") ||
                    Template.Pages.EndsWith(ControllerName)));
            }
        }
    }
