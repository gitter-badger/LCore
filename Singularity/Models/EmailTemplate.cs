using Singularity;
using Singularity.Context;
using Singularity.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web;
using System.Web.Security;
using LCore;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Linq;
using Singularity.Annotations;


namespace Singularity.Models
    {
    public class EmailTemplate : IModel
        {
        [Key]
        public int EmailTemplateID { get; set; }

        [Required]
        public String Subject { get; set; }

        [FieldType_HTMLContentEditor]
        public String Body { get; set; }

        [FieldType_DropdownContextManageControllers(MultiSelect: true)]
        public String Pages { get; set; }

        [HideManageViewColumn]
        [FieldType_FileUpload]
        [NotMapped]
        public String Attachments { get; set; }

        [HideManageViewColumn]
        public Boolean Active { get; set; }

        public override string ToString()
            {
            return Subject;
            }

        public static IQueryable<EmailTemplate> FindPageTemplates(ModelContext DbContext, String ControllerName)
            {
            return DbContext.GetDBSet<EmailTemplate>().Where(
                e => e.Active &&
                    (e.Pages.Contains(ControllerName + ",") ||
                    e.Pages.EndsWith(ControllerName)));
            }
        }
    }
