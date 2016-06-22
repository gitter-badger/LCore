using System;


namespace Singularity.Models
    {
    public interface IModelPermissions
        {
        string PermissionFieldName { get; set; }
        }

    public class ModelPermissionsAttribute : Attribute, IModelPermissions
        {
        public string PermissionFieldName { get; set; }

        public ModelPermissionsAttribute(string PermissionFieldName)
            {
            this.PermissionFieldName = PermissionFieldName;
            }
        }
    }
