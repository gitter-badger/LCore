namespace Singularity.Models
    {
    public interface ISiteConfig
        {
        string Name { get; set; }
        // ReSharper disable once InconsistentNaming
        bool Require2FA { get; set; }
        bool RequireHTTPS { get; set; }
        int SiteConfigID { get; set; }
        string SiteRootURL { get; set; }
        }
    }