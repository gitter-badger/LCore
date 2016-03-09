using System;
using System.Data.Entity;
using LCore;
using System.Web;
using System.Collections.Generic;
using Singularity.Controllers;
using Singularity.Models;
using System.Linq;

using Singularity.Extensions;

namespace Singularity.Context
    {
    public abstract class ModelContext : DbContext
        {
        public abstract String GetLogoURL();
        public abstract String ContextName { get; }

        public abstract Type[] ContextTypes { get; }

        public abstract Type UserAccountType { get; }
        public abstract Type UserInfoType { get; }
        public abstract Type UserRoleType { get; }

        public SiteConfig GetSiteConfig(HttpContextBase Context)
            {
            Func<String, SiteConfig> func = (url) =>
                {
                    SiteConfig Out = SiteConfig.FindCurrent(this, url);
                    if (Out == null)
                        throw new Exception("Could not find Site Config for: " + url);
                    return Out;
                };

            String URL = Context.Request.Url.AbsoluteUri;

            return func.Cache("SiteConfigCache")(URL);
            }

        public virtual DbSet GetDBSet(Type t)
            {
            return this.Set(t);
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

        public ModelContext(String Connection)
            : base(Connection)
            {

            }

        public static implicit operator ModelContext(HttpContextBase Context)
            {
            return Context.GetModelContext();
            }
        }
    }
