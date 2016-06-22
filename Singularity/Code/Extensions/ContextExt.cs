using System;
using System.Linq;
using System.Reflection;
using System.Web;

using LCore.Extensions;
using System.Web.Mvc;
using Singularity.Controllers;
using Singularity.Context;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Text.RegularExpressions;

namespace Singularity.Extensions
    {
    public static class ContextExt
        {
        public static ManageController GetManageController(this ViewContext Context)
            {
            return Context.GetController<ManageController>();
            }

        public static ManageController[] GetAllManageControllers(this HttpContextBase Context)
            {
            return ContextProviderFactory.GetCurrent().AllManageControllers(Context.Session);
            }

        public static IMenuController[] GetAllMenuControllers(this HttpContextBase Context)
            {
            return ContextProviderFactory.GetCurrent().AllMenuControllers(Context.Session);
            }

        public static T GetController<T>(this ViewContext Context)
            where T : Controller
            {
            return Context.Controller as T;
            }

        public static bool AllowEdit(this ViewContext Context, Type t)
            {
            ManageController Controller = Context.GetManageController();

            return Context.HttpContext.Session != null &&
                ContextProviderFactory.GetCurrent().CurrentRole(Context.HttpContext.Session) != null &&
                ContextProviderFactory.GetCurrent().GetModelPermissions(Context.HttpContext.Session, t).Edit == true &&
                (Controller == null || Controller.ModelType != t ||
                Controller.OverridePermissions.Edit == true);
            }
        public static bool AllowDeactivate(this ViewContext Context, Type t)
            {
            ManageController Controller = Context.GetManageController();

            return Context.HttpContext.Session != null &&
                ContextProviderFactory.GetCurrent().CurrentRole(Context.HttpContext.Session) != null &&
                ContextProviderFactory.GetCurrent().GetModelPermissions(Context.HttpContext.Session, t).Deactivate == true &&
                (Controller == null || Controller.ModelType != t ||
                Controller.OverridePermissions.Deactivate == true);
            }
        public static bool AllowExport(this ViewContext Context, Type t)
            {
            ManageController Controller = Context.GetManageController();

            return Context.HttpContext.Session != null &&
                ContextProviderFactory.GetCurrent().CurrentRole(Context.HttpContext.Session) != null &&
                ContextProviderFactory.GetCurrent().GetModelPermissions(Context.HttpContext.Session, t).Export == true &&
                (Controller == null || Controller.ModelType != t ||
                Controller.OverridePermissions.Export == true);
            }
        public static bool AllowViewInactive(this ViewContext Context, Type t)
            {
            ManageController Controller = Context.GetManageController();

            return Context.HttpContext.Session != null &&
                ContextProviderFactory.GetCurrent().CurrentRole(Context.HttpContext.Session) != null &&
                ContextProviderFactory.GetCurrent().GetModelPermissions(Context.HttpContext.Session, t).ViewInactive == true &&
                (Controller == null || Controller.ModelType != t ||
                Controller.OverridePermissions.ViewInactive == true);
            }
        public static bool AllowCreate(this ViewContext Context, Type t)
            {
            ManageController Controller = Context.GetManageController();

            return Context.HttpContext.Session != null &&
                ContextProviderFactory.GetCurrent().CurrentRole(Context.HttpContext.Session) != null &&
                ContextProviderFactory.GetCurrent().GetModelPermissions(Context.HttpContext.Session, t).Create == true &&
                (Controller == null || Controller.ModelType != t ||
                Controller.OverridePermissions.Create == true);
            }
        public static bool AllowView(this ViewContext Context, Type t)
            {
            ManageController Controller = Context.GetManageController();

            return Context.HttpContext.Session != null &&
                ContextProviderFactory.GetCurrent().CurrentRole(Context.HttpContext.Session) != null &&
                ContextProviderFactory.GetCurrent().GetModelPermissions(Context.HttpContext.Session, t).View == true &&
                (Controller == null ||
                Controller.OverridePermissions.View == true);
            }

        public static string GetTableName<T>(this DbContext context) where T : class
            {
            ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;

            return objectContext.GetTableName<T>();
            }
        public static string GetTableName(this DbContext context, Type t)
            {
            ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;

            return objectContext.GetTableName(t);
            }

        public static string GetTableName<T>(this ObjectContext context) where T : class
            {
            string sql = context.CreateObjectSet<T>().ToTraceString();
            Regex regex = new Regex("FROM (?<table>.*) AS");
            Match match = regex.Match(sql);

            string table = match.Groups["table"].Value;
            return table;
            }
        public static string GetTableName(this ObjectContext context, Type t)
            {
            MethodInfo Method = (MethodInfo)context.GetType().GetMember("CreateObjectSet").FirstOrDefault();

            Method = Method?.MakeGenericMethod(t);

            if (Method != null)
                {
                ObjectQuery Query = (ObjectQuery)Method.Invoke(context, new object[] { });

                string sql = Query.ToTraceString();
                Regex regex = new Regex("FROM (?<table>.*) AS");
                Match match = regex.Match(sql);

                string table = match.Groups["table"].Value;
                return table;
                }

            return null;
            }

        public static DbSet<T> GetModelData<T>(this HttpContextBase Context)
            where T : class, new()
            {
            return ContextProviderFactory.GetCurrent().GetDBSet<T>(Context.Session);
            }

        public static bool HasContextType<T>(this HttpContextBase Context)
            where T : class, new()
            {
            return ContextProviderFactory.GetCurrent().GetContextTypes(Context.Session).Has(typeof(T));
            }

        public static ModelContext GetModelContext(this HttpContextBase Context)
            {
            return ContextProviderFactory.GetCurrent().GetContext(Context.Session);
            }
        }
    }