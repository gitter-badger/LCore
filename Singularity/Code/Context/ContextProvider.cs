using System;
using System.Data.Entity;

using System.Web;
using Singularity.Controllers;
using Singularity.Models;
using Singularity.Extensions;
using System.Linq;
using Microsoft.WindowsAzure.StorageClient;

namespace Singularity.Context
    {
    public abstract class ContextProvider
        {
        public const string ContextSession = "RosieContext";

        public abstract ManageController[] AllManageControllers(HttpSessionStateBase Session);

        public abstract IMenuController[] AllMenuControllers(HttpSessionStateBase Session);

        public abstract ModelContext GetContext(HttpSessionStateBase Session);

        public abstract Type[] GetContextTypes(HttpSessionStateBase Session);

        public abstract IModelUser CurrentUser(HttpSessionStateBase Session);

        public abstract IModelRole CurrentRole(HttpSessionStateBase Session);

        public abstract IModelRole GetAnonymousRole();

        public abstract string GetFileUploadRootPath(HttpSessionStateBase Session, HttpPostedFileBase File, string RelationType, string RelationProperty, int RelationID);

        public abstract string GetFileUploadFilePath(HttpSessionStateBase Session, HttpPostedFileBase File, string RelationType, string RelationProperty, int RelationID);

        public abstract CloudBlobDirectory GetFileUploadCloudContainer();

        ///////////////////////////////////////////////////////////////////////////////////////////////////

        public ManageController GetManageController(HttpSessionStateBase Session, string ControllerName)
            {
            return this.AllManageControllers(Session).FirstOrDefault(c => c.GetType().FullName == ControllerName);
            }
        public ManageController GetManageController(HttpSessionStateBase Session, Type ModelType)
            {
            return this.AllManageControllers(Session).FirstOrDefault(c => c.ModelType == ModelType);
            }

        public ModelPermissions GetModelPermissions(HttpSessionStateBase Session, Type RequestedType)
            {
            return this.GetModelPermissions(this.CurrentRole(Session), RequestedType);
            }

        private ModelPermissions GetModelPermissions(IModel ProfileRole, Type RequestedType)
            {
            Type RoleType = ProfileRole.GetType();

            RequestedType = RequestedType.WithoutDynamicType();

            string TypeName = RequestedType.Name;

            IModelPermissions Attr = RequestedType.GetAttribute<IModelPermissions>();

            TypeName += "Permissions";

            if (Attr != null)
                {
                if (string.IsNullOrEmpty(Attr.PermissionFieldName))
                    return new ModelPermissions();

                TypeName = Attr.PermissionFieldName;
                }

            if (RoleType.HasProperty(TypeName))
                return (ModelPermissions)RoleType.GetProperty(TypeName).GetValue(ProfileRole) ?? new ModelPermissions();

            throw new Exception($"Could not find permissions for {RequestedType.Name}");
            }

        public DbSet GetDBSet(HttpSessionStateBase Session, Type t)
            {
            return this.GetContext(Session).GetDBSet(t);
            }

        public DbSet<T> GetDBSet<T>(HttpSessionStateBase Session)
            where T : class, new()
            {
            return this.GetContext(Session).GetDBSet<T>();
            }
        }
    }
