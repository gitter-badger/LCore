
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

using LCore;

using Singularity;
using Singularity.Context;
using Singularity.Controllers;


namespace Singularity.Models
    {
    [Table("SiteConfig")]
    public class SiteConfig : IModel
        {
        [Key]
        public int SiteConfigID { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String SiteRootURL { get; set; }

        public Boolean RequireHTTPS { get; set; }

        public Boolean Require2FA { get; set; }

        public static SiteConfig FindCurrent(ModelContext DbContext, String URL)
            {
            URL = URL ?? "";

            URL = URL.ToLower();

            // Remove protocol
            if (URL.StartsWith("http://"))
                URL = URL.Substring(("http://").Length);
            else if (URL.StartsWith("https://"))
                URL = URL.Substring(("https://").Length);

            // Remove path
            if (URL.Contains("/"))
                URL = URL.Substring(0, URL.IndexOf('/'));

            // Remove port
            if (URL.Contains(":"))
                URL = URL.Substring(0, URL.IndexOf(':'));

            return DbContext.GetDBSet<SiteConfig>().Where(
                s => s.SiteRootURL == URL)
                .FirstOrDefault();
            }
        }
    }
