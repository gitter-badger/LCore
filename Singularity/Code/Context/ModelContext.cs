﻿using System;
using System.Data.Entity;

using LCore.Extensions;
using System.Web;
using Singularity.Models;
using Singularity.Extensions;
using System.Data.SqlClient;
using Singularity.Controllers;

// ReSharper disable UnassignedGetOnlyAutoProperty

namespace Singularity.Context
    {
    public abstract class ModelContext : DbContext
        {
        public abstract string GetLogoURL();
        public abstract string ContextName { get; }

        public abstract Type[] ContextTypes { get; }

        public abstract Type UserAccountType { get; }
        public abstract Type UserRoleType { get; }

        public SiteConfig GetSiteConfig(HttpContextBase Context)
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

        public virtual string GetHomeAction(UserAccount User)
            {
            return nameof(HomeController.Index);
            }

        public virtual string GetHomeController(UserAccount User)
            {
            return typeof(HomeController).CName();
            }
        }
    }
