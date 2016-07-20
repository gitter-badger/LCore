using System;
using System.Data.Entity;

using LMVC.Controllers;
using LMVC.Models;
using LMVC.Extensions;
using System.Linq;
using LCore.Extensions;
using Microsoft.WindowsAzure.StorageClient;
using System.Web;
// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable UnusedParameter.Global
// ReSharper disable VirtualMemberNeverOverriden.Global

namespace LMVC.Context
    {
    public abstract class ContextProvider : IContextProvider
        {
        public const string ContextSession = "SingularityContext";

        public abstract ManageController[] AllManageControllers(HttpSessionStateBase Session);

        public abstract IMenuController[] AllMenuControllers(HttpSessionStateBase Session);

        public abstract ModelContext GetContext(HttpSessionStateBase Session);

        public abstract Type[] GetContextTypes(HttpSessionStateBase Session);

        public abstract UserAccount CurrentUser(HttpSessionStateBase Session);

        public abstract AccountRole CurrentRole(HttpSessionStateBase Session);

        public abstract AccountRole GetAnonymousRole();

        public abstract string GetFileUploadRootPath(HttpSessionStateBase Session, HttpPostedFileBase File, string RelationType, string RelationProperty, int RelationID);

        public abstract string GetFileUploadFilePath(HttpSessionStateBase Session, HttpPostedFileBase File, string RelationType, string RelationProperty, int RelationID);

        public abstract CloudBlobDirectory GetFileUploadCloudContainer();

        public abstract string SiteTitle { get; }

        ///////////////////////////////////////////////////////////////////////////////////////////////////

        public ManageController GetManageController(HttpSessionStateBase Session, string ControllerName)
            {
            return this.AllManageControllers(Session).FirstOrDefault(Controller => Controller.GetType().FullName == ControllerName);
            }
        public ManageController GetManageController(HttpSessionStateBase Session, Type ModelType)
            {
            return this.AllManageControllers(Session).FirstOrDefault(Controller => Controller.ModelType == ModelType);
            }

        public ModelPermissions GetModelPermissions(HttpSessionStateBase Session, Type RequestedType)
            {
            return this.GetModelPermissions(this.CurrentRole(Session), RequestedType);
            }

        private ModelPermissions GetModelPermissions(IModel ProfileRole, Type RequestedType)
            {
            var RoleType = ProfileRole.GetType();

            RequestedType = RequestedType.WithoutDynamicType();

            string TypeName = RequestedType.Name;

            var Attr = RequestedType.GetAttribute<IModelPermissionsAttribute>();

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

        public DbSet GetDBSet(HttpSessionStateBase Session, Type Type)
            {
            return this.GetContext(Session).GetDBSet(Type);
            }

        public DbSet<T> GetDBSet<T>(HttpSessionStateBase Session)
            where T : class, new()
            {
            return this.GetContext(Session).GetDBSet<T>();
            }

        public virtual string GetVersionNumber()
            {
            return "1.0";
            }
        }
    }
