using System;
using System.Data.Entity;
using LCore;
using System.Web;
using System.Collections.Generic;
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

        public abstract String GetFileUploadRootPath(HttpSessionStateBase Session, HttpPostedFileBase File, String RelationType, String RelationProperty, int RelationID);

        public abstract String GetFileUploadFilePath(HttpSessionStateBase Session, HttpPostedFileBase File, String RelationType, String RelationProperty, int RelationID);

        public abstract CloudBlobDirectory GetFileUploadCloudContainer();

        ///////////////////////////////////////////////////////////////////////////////////////////////////

        public ManageController GetManageController(HttpSessionStateBase Session, String ControllerName)
            {
            return AllManageControllers(Session).Where((c) =>
                {
                    return c.GetType().FullName == ControllerName;
                }).FirstOrDefault();
            }
        public ManageController GetManageController(HttpSessionStateBase Session, Type ModelType)
            {
            return AllManageControllers(Session).Where((c) =>
            {
                return c.ModelType == ModelType;
            }).FirstOrDefault();
            }

        public ModelPermissions GetModelPermissions(HttpSessionStateBase Session, Type RequestedType)
            {
            return GetModelPermissions(CurrentRole(Session), RequestedType);
            }

        private ModelPermissions GetModelPermissions(IModel ProfileRole, Type RequestedType)
            {
            Type RoleType = ProfileRole.GetType();

            RequestedType = RequestedType.WithoutDynamicType();

            String TypeName = RequestedType.Name;

            IModelPermissions Attr = RequestedType.GetAttribute<IModelPermissions>();

            TypeName += "Permissions";

            if (Attr != null)
                {
                if (String.IsNullOrEmpty(Attr.PermissionFieldName))
                    return new ModelPermissions();

                TypeName = Attr.PermissionFieldName;
                }

            if (RoleType.HasProperty(TypeName))
                return (ModelPermissions)RoleType.GetProperty(TypeName).GetValue(ProfileRole) ?? new ModelPermissions();

            throw new Exception("Could not find permissions for " + RequestedType.Name);
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
