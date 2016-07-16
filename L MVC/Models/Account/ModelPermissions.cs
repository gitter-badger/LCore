using System.ComponentModel.DataAnnotations.Schema;

namespace Singularity.Models
    {
    [ComplexType]
    public class ModelPermissions : IModelPermissions
        {
        public bool? View { get; set; }
        public bool? ViewInactive { get; set; }
        public bool? Export { get; set; }
        public bool? Create { get; set; }
        public bool? Edit { get; set; }
        public bool? Deactivate { get; set; }

        public static ModelPermissions AllowAll => new ModelPermissions
            {
            View = true,
            ViewInactive = true,
            Export = true,
            Create = true,
            Edit = true,
            Deactivate = true
        };
        }
    }
