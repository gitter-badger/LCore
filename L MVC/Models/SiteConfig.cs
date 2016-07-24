using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;
using LCore.Extensions;
using LMVC.Context;


namespace LMVC.Models
    {
    [Table("SiteConfig")]
    public class SiteConfig : IModel, ISiteConfig
        {
        [Key]
        public int SiteConfigID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string SiteRootURL { get; set; }

        public bool RequireHTTPS { get; set; }

        // ReSharper disable once InconsistentNaming
        public bool Require2FA { get; set; }

        [CanBeNull]
        public static SiteConfig FindCurrent(ModelContext DbContext, [CanBeNull]string URL)
            {
            URL = URL ?? "";

            URL = URL.ToLower();

            // Remove protocol
            if (URL.StartsWith("http://"))
                URL = URL.Sub("http://".Length);
            else if (URL.StartsWith("https://"))
                URL = URL.Sub("https://".Length);

            // Remove path
            if (URL.Contains("/"))
                URL = URL.Sub(0, URL.IndexOf('/'));

            // Remove port
            if (URL.Contains(":"))
                URL = URL.Sub(0, URL.IndexOf(':'));

            return DbContext.GetDBSet<SiteConfig>().FirstOrDefault(Site => Site.SiteRootURL == URL);
            }
        }
    }
