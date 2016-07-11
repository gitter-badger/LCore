using Singularity.Context;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Singularity.Annotations;


namespace Singularity.Models
    {
    public class EmailTemplate : IModel
        {
        [Key]
        public int EmailTemplateID { get; set; }

        [Required]
        public string Subject { get; set; }

        [FieldType_HTMLContentEditor]
        public string Body { get; set; }

        [FieldTypeDropdownContextManageControllers(MultiSelect: true)]
        public string Pages { get; set; }

        [HideManageViewColumn]
        [FieldType_FileUpload]
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
                e => e.Active &&
                    (e.Pages.Contains($"{ControllerName},") ||
                    e.Pages.EndsWith(ControllerName)));
            }
        }
    }
