namespace Singularity.Models
    {
    public interface IModelPermissions
        {
        bool? Create { get; set; }
        bool? Deactivate { get; set; }
        bool? Edit { get; set; }
        bool? Export { get; set; }
        bool? View { get; set; }
        bool? ViewInactive { get; set; }
        }
    }