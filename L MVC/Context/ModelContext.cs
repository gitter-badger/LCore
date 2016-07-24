using System;
using System.Data.Entity;

using LCore.Extensions;
using System.Web;
using LMVC.Models;
using LMVC.Extensions;
using System.Data.SqlClient;
using JetBrains.Annotations;
using LMVC.Controllers;

// ReSharper disable UnassignedGetOnlyAutoProperty

namespace LMVC.Context
    {
    public abstract class ModelContext : DbContext, IModelContext
        {
        [CanBeNull]
        public abstract string GetLogoURL();
        [CanBeNull]
        public abstract string ContextName { get; }

        [CanBeNull]
        public abstract Type[] ContextTypes { get; }

        [CanBeNull]
        public abstract Type UserAccountType { get; }
        [CanBeNull]
        public abstract Type UserRoleType { get; }

        [CanBeNull]
        public ISiteConfig GetSiteConfig(HttpContextBase Context)
            {
            Func<string, SiteConfig> Func = Url =>
                {
                    var Out = SiteConfig.FindCurrent(this, Url);
                    if (Out == null)
                        throw new Exception($"Could not find Site Config for: {Url}");
                    return Out;
                };

            string URL = Context.Request.Url?.AbsoluteUri;

            return Func.Cache("SiteConfigCache")(URL);
            }

        [CanBeNull]
        public virtual DbSet GetDBSet(Type Type)
            {
            return this.Set(Type);
            /*
            return this.GetType()
                .GetProperties().First((prop) =>
                {
                    if (prop.PropertyType.IsGenericType &&
                        prop.PropertyType.GetGenericArguments()[0] == t)
                        return (DbSet)prop.GetValue(this);
                    
                    return null;
                });
             */
            }
        [CanBeNull]
        public virtual DbSet<T> GetDBSet<T>()
            where T : class
            {
            return this.Set<T>();
            /*
        return this.GetType()
            .GetProperties().First((prop) =>
            {
                if (prop.PropertyType.IsGenericType &&
                    prop.PropertyType.GetGenericArguments()[0] == typeof(T))
                    return (DbSet<T>)prop.GetValue(this);

                return (DbSet<T>)null;
            });
             */
            }

        private string ConnectionStr { get; }

        public SqlConnection CreateConnection()
            {
            var Out = new SqlConnection(this.ConnectionStr);
            return Out;
            }

        protected ModelContext(string Connection)
            : base(Connection)
            {
            this.ConnectionStr = Connection;
            }

        public static implicit operator ModelContext(HttpContextBase Context)
            {
            return Context.GetModelContext();
            }

        [CanBeNull]
        public virtual string GetHomeAction(IUserAccount User)
            {
            return nameof(HomeController.Index);
            }

        [CanBeNull]
        public virtual string GetHomeController(IUserAccount User)
            {
            return typeof(HomeController).CName();
            }
        }
    }
