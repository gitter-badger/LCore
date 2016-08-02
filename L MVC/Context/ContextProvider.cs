using System;
using System.Data.Entity;

using LMVC.Controllers;
using LMVC.Models;
using LMVC.Extensions;
using System.Linq;
using LCore.Extensions;
using Microsoft.WindowsAzure.StorageClient;
using System.Web;
using JetBrains.Annotations;

// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable UnusedParameter.Global
// ReSharper disable VirtualMemberNeverOverriden.Global

namespace LMVC.Context
    {
    public abstract class ContextProvider : IContextProvider
        {
        public const string ContextSession = "SingularityContext";

        public abstract ManageController[] AllManageControllers([CanBeNull]HttpSessionStateBase Session);

        public abstract IMenuController[] AllMenuControllers([CanBeNull]HttpSessionStateBase Session);

        public abstract ModelContext GetContext([CanBeNull]HttpSessionStateBase Session);

        public abstract Type[] GetContextTypes([CanBeNull]HttpSessionStateBase Session);

        [CanBeNull]
        public abstract UserAccount CurrentUser([CanBeNull]HttpSessionStateBase Session);

        [CanBeNull]
        public abstract AccountRole CurrentRole([CanBeNull]HttpSessionStateBase Session);

        public abstract AccountRole GetAnonymousRole();

        [CanBeNull]
        public abstract string GetFileUploadRootPath([CanBeNull]HttpSessionStateBase Session, [CanBeNull]HttpPostedFileBase File, [CanBeNull]string RelationType, [CanBeNull]string RelationProperty, int RelationID);

        [CanBeNull]
        public abstract string GetFileUploadFilePath([CanBeNull]HttpSessionStateBase Session, [CanBeNull]HttpPostedFileBase File, [CanBeNull]string RelationType, [CanBeNull]string RelationProperty, int RelationID);

        public abstract CloudBlobDirectory GetFileUploadCloudContainer();

        public abstract string SiteTitle { get; }

        ///////////////////////////////////////////////////////////////////////////////////////////////////

        [CanBeNull]
        public ManageController GetManageController([CanBeNull]HttpSessionStateBase Session, [CanBeNull]string ControllerName)
            {
            return this.AllManageControllers(Session).FirstOrDefault(Controller => Controller.GetType().FullName == ControllerName);
            }
        [CanBeNull]
        public ManageController GetManageController([CanBeNull]HttpSessionStateBase Session, [CanBeNull]Type ModelType)
            {
            return this.AllManageControllers(Session).FirstOrDefault(Controller => Controller.ModelType == ModelType);
            }

        [CanBeNull]
        public ModelPermissions GetModelPermissions([CanBeNull]HttpSessionStateBase Session, [CanBeNull]Type RequestedType)
            {
            return this.GetModelPermissions(this.CurrentRole(Session), RequestedType);
            }

        [CanBeNull]
        private ModelPermissions GetModelPermissions([CanBeNull] IModel ProfileRole, [CanBeNull] Type RequestedType)
            {
            if (ProfileRole == null)
                return null;

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

        [CanBeNull]
        public DbSet GetDBSet([CanBeNull]HttpSessionStateBase Session, [CanBeNull]Type Type)
            {
            return this.GetContext(Session).GetDBSet(Type);
            }

        [CanBeNull]
        public DbSet<T> GetDBSet<T>([CanBeNull]HttpSessionStateBase Session)
            where T : class, new()
            {
            return this.GetContext(Session).GetDBSet<T>();
            }

        [CanBeNull]
        public virtual string GetVersionNumber()
            {
            return "1.0";
            }
        }
    }
