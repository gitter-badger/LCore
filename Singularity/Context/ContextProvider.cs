using System;
using System.Data.Entity;
using LCore;
using System.Web;
using System.Collections.Generic;
using Singularity.Controllers;
using Singularity.Models;
using System.Linq;

namespace Singularity.Context
    {
    public abstract class ModelContext : DbContext
        {
        public abstract String GetLogoURL();
        public abstract String ContextName { get; }

        public abstract Type[] ContextTypes { get; }

        public virtual IQueryable GetDBSet(Type t)
            {
            return this.GetType()
                .GetProperties().First((prop) =>
                {
                    if (prop.PropertyType.IsGenericType &&
                        prop.PropertyType.GetGenericArguments()[0] == t)
                        return (IQueryable)prop.GetValue(this);

                    return null;
                });
            }

        public virtual DbSet<T> GetDBSet<T>()
            where T : class
            {
            return this.GetType()
                .GetProperties().First((prop) =>
                {
                    if (prop.PropertyType.IsGenericType &&
                        prop.PropertyType.GetGenericArguments()[0] == typeof(T))
                        return (DbSet<T>)prop.GetValue(this);

                    return (DbSet<T>)null;
                });
            }

        public ModelContext(String Connection)
            : base(Connection)
            {

            }
        }

    public abstract class ContextProvider
        {
        public const string ContextSession = "RosieContext";

        public abstract ManageController[] AllManageControllers(HttpSessionStateBase Session);

        public abstract ModelContext GetContext(HttpSessionStateBase Session);

        public abstract Type[] GetContextTypes(HttpSessionStateBase Session);

        public abstract IModelUser CurrentUser(HttpSessionStateBase Session);

        public abstract IModelRole CurrentRole(HttpSessionStateBase Session);

        public abstract IModelRole GetAnonymousRole();

        public abstract String GetFileUploadRootPath(HttpSessionStateBase Session, HttpPostedFileBase File, String RelationType, String RelationProperty, int RelationID);

        public abstract String GetFileUploadFilePath(HttpSessionStateBase Session, HttpPostedFileBase File, String RelationType, String RelationProperty, int RelationID);


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
                return (ModelPermissions)RoleType.GetProperty(TypeName).GetValue(ProfileRole);

            throw new Exception("Could not find permissions for " + RequestedType.Name);

            return new ModelPermissions();
            }

        public IQueryable GetDBSet(HttpSessionStateBase Session, Type t)
            {
            return this.GetContext(Session).GetDBSet(t);
            }
        }
    }
