
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Singularity.Context;
using Singularity.Annotations;


namespace Singularity.Models
    {
    public class EmailJob : IModel
        {
        [Key]
        public int EmailJobID { get; set; }

        [FieldVisibility(false)]
        public int SavedSearchID { get; set; }

        [Required]
        public string Name { get; set; }

        [Column("SavedSearchID")]
        [FieldLoadFromQueryString]
        public virtual SavedSearch SavedSearch { get; set; }

        [FieldVisibility(false)]
        public int EmailTemplateID { get; set; }

        [FieldLoadFromQueryString]
        [Column("EmailTemplateID")]
        public virtual EmailTemplate EmailTemplate { get; set; }

        [FieldType_DropdownContextModelFields_SavedSearch_EmailType]
        [Required]
        [HideManageViewColumn]
        public string EmailToField { get; set; }

        public DateTime? LastSent { get; set; }

        [NotMapped]
        [HideManageViewColumn]
        public object SendToUsers { get; set; }

        [HideManageViewColumn]
        [FieldType_FileUpload]
        [NotMapped]
        public string Attachments { get; set; }

        [HideManageViewColumn]
        [FieldVisibility(false)]
        public DateTime Created { get; set; }

        [HideManageViewColumn]
        public bool Active { get; set; }

        public override string ToString()
            {
            return this.EmailTemplate != null ? this.EmailTemplate.Subject : "";
            }

        public static EmailJob Find(ModelContext DbContext, int EmailJobID)
            {
            return DbContext.GetDBSet<EmailJob>().FirstOrDefault(t => t.Active && t.EmailJobID == EmailJobID);
            }

        public class FieldType_DropdownContextModelFields_SavedSearch_EmailType : FieldType_DropdownContextModelFields_ByDataType
            {
            public FieldType_DropdownContextModelFields_SavedSearch_EmailType()
                : base(DataType.EmailAddress, (Type)null, false, true)
                {
                }

            public override Type GetModelType(System.Web.Mvc.ViewContext Context)
                {
                if (Context.Controller.ViewBag.EditModel != null)
                    {
                    var Job = (EmailJob)Context.Controller.ViewBag.EditModel;

                    if (Job.SavedSearch != null)
                        {
                        var Controller = ContextProviderFactory.GetCurrent()
                            .GetManageController(Context.HttpContext.Session, Job.SavedSearch.ControllerName);

                        if (Controller != null)
                            {
                            return Controller.ModelType;
                            }
                        }
                    }

                return null;
                }
            }
        }
    }