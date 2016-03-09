using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCore;

namespace Singularity.Models
    {
    public interface IModelPermissions
        {
        String PermissionFieldName { get; set; }
        }

    public class ModelPermissionsAttribute : Attribute, IModelPermissions
        {
        public String PermissionFieldName { get; set; }

        public ModelPermissionsAttribute(String PermissionFieldName)
            {
            this.PermissionFieldName = PermissionFieldName;
            }
        }
    }
