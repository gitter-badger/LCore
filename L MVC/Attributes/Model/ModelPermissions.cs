using System;
using LCore.Extensions;


namespace LMVC.Models
    {
    public interface IModelPermissionsAttribute : ISubClassPersistentAttribute
        {
        string PermissionFieldName { get; set; }
        }

    public class ModelPermissionsAttribute : Attribute, IModelPermissionsAttribute
        {
        public string PermissionFieldName { get; set; }

        public ModelPermissionsAttribute(string PermissionFieldName)
            {
            this.PermissionFieldName = PermissionFieldName;
            }
        }
    }
