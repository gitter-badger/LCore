using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Singularity.Context;


namespace Singularity.Models
    {
    [Table("SiteConfig")]
    public class SiteConfig : IModel
        {
        [Key]
        public int SiteConfigID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string SiteRootURL { get; set; }

        public bool RequireHTTPS { get; set; }

        public bool Require2FA { get; set; }

        public static SiteConfig FindCurrent(ModelContext DbContext, string URL)
            {
            URL = URL ?? "";

            URL = URL.ToLower();

            // Remove protocol
            if (URL.StartsWith("http://"))
                URL = URL.Substring("http://".Length);
            else if (URL.StartsWith("https://"))
                URL = URL.Substring("https://".Length);

            // Remove path
            if (URL.Contains("/"))
                URL = URL.Substring(0, URL.IndexOf('/'));

            // Remove port
            if (URL.Contains(":"))
                URL = URL.Substring(0, URL.IndexOf(':'));

            return DbContext.GetDBSet<SiteConfig>().FirstOrDefault(s => s.SiteRootURL == URL);
            }
        }
    }
