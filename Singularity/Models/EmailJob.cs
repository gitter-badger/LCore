
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web;
using System.Web.Security;
using System.Web.Helpers;
using System.ComponentModel;

using LCore;

using Singularity;
using Singularity.Context;
using Singularity.Controllers;
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
        public String Name { get; set; }

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
        public String EmailToField { get; set; }

        public DateTime? LastSent { get; set; }

        [NotMapped]
        [HideManageViewColumn]
        public Object SendToUsers { get; set; }

        [HideManageViewColumn]
        [FieldType_FileUpload]
        [NotMapped]
        public String Attachments { get; set; }

        [HideManageViewColumn]
        [FieldVisibility(false)]
        public DateTime Created { get; set; }

        [HideManageViewColumn]
        public Boolean Active { get; set; }

        public override string ToString()
            {
            if (EmailTemplate != null)
                return EmailTemplate.Subject;

            return "";
            }

        public static EmailJob Find(ModelContext DbContext, int EmailJobID)
            {
            return DbContext.GetDBSet<EmailJob>().Where(
                t => t.Active &&
                    t.EmailJobID == EmailJobID)
                .FirstOrDefault();
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
                    EmailJob Job = (EmailJob)Context.Controller.ViewBag.EditModel;

                    if (Job.SavedSearch != null)
                        {
                        ManageController Controller = ContextProviderFactory.GetCurrent()
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