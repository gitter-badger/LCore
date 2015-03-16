using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using LCore;

namespace MVCL
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
