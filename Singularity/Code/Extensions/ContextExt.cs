using System;
using System.Collections.Generic;
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
using LCore.Interfaces;
using Singularity.Models;

namespace Singularity.Extensions
    {
    [ExtensionProvider]
    public static class ContextExt
        {
        #region Extensions +

        #region DbContext +

        #region GetTableName

        public static string GetTableName<T>(this DbContext context) where T : class
            {
            var ObjectContext = ((IObjectContextAdapter) context).ObjectContext;

            return ObjectContext.GetTableName<T>();
            }

        public static string GetTableName(this DbContext context, Type t)
            {
            var ObjectContext = ((IObjectContextAdapter) context).ObjectContext;

            return ObjectContext.GetTableName(t);
            }

        #endregion

        #endregion

        #region HttpContextBase +

        #region GetAllManageControllers

        public static ManageController[] GetAllManageControllers(this HttpContextBase Context)
            {
            return ContextProviderFactory.GetCurrent().AllManageControllers(Context.Session);
            }

        #endregion

        #region GetAllMenuControllers

        public static IMenuController[] GetAllMenuControllers(this HttpContextBase Context)
            {
            return ContextProviderFactory.GetCurrent().AllMenuControllers(Context.Session);
            }

        #endregion

        #region GetModelContext

        public static ModelContext GetModelContext(this HttpContextBase Context)
            {
            return ContextProviderFactory.GetCurrent().GetContext(Context.Session);
            }

        #endregion

        #region GetModelData

        public static DbSet<T> GetModelData<T>(this HttpContextBase Context)
            where T : class, new()
            {
            return ContextProviderFactory.GetCurrent().GetDBSet<T>(Context.Session);
            }

        #endregion

        #region HasContextType

        public static bool HasContextType<T>(this HttpContextBase Context)
            where T : class, new()
            {
            return ContextProviderFactory.GetCurrent().GetContextTypes(Context.Session).Has(typeof(T));
            }

        #endregion

        #endregion

        #region ObjectContext +

        #region GetTableName

        public static string GetTableName<T>(this ObjectContext context) where T : class
            {
            string SQL = context.CreateObjectSet<T>().ToTraceString();
            var Regex = new Regex("FROM (?<table>.*) AS");
            var Match = Regex.Match(SQL);

            string Table = Match.Groups["table"].Value;
            return Table;
            }

        public static string GetTableName(this ObjectContext context, Type t)
            {
            var Method = (MethodInfo) context.GetType().GetMember("CreateObjectSet").FirstOrDefault();

            Method = Method?.MakeGenericMethod(t);

            if (Method != null)
                {
                var Query = (ObjectQuery) Method.Invoke(context, new object[] {});

                string SQL = Query.ToTraceString();
                var Regex = new Regex("FROM (?<table>.*) AS");
                var Match = Regex.Match(SQL);

                string Table = Match.Groups["table"].Value;
                return Table;
                }

            return null;
            }

        #endregion

        #endregion

        #region ViewContext +

        #region AllowCreate

        public static bool AllowCreate(this ViewContext Context, Type t)
            {
            var Controller = Context.GetManageController();

            return Context.HttpContext.Session != null &&
                   ContextProviderFactory.GetCurrent().CurrentRole(Context.HttpContext.Session) != null &&
                   ContextProviderFactory.GetCurrent().GetModelPermissions(Context.HttpContext.Session, t).Create ==
                   true &&
                   (Controller == null || Controller.ModelType != t ||
                    Controller.OverridePermissions.Create == true);
            }

        #endregion

        #region AllowDeactivate

        public static bool AllowDeactivate(this ViewContext Context, Type t)
            {
            var Controller = Context.GetManageController();

            return Context.HttpContext.Session != null &&
                   ContextProviderFactory.GetCurrent().CurrentRole(Context.HttpContext.Session) != null &&
                   ContextProviderFactory.GetCurrent().GetModelPermissions(Context.HttpContext.Session, t).Deactivate ==
                   true &&
                   (Controller == null || Controller.ModelType != t ||
                    Controller.OverridePermissions.Deactivate == true);
            }

        #endregion

        #region AllowEdit

        public static bool AllowEdit(this ViewContext Context, Type t)
            {
            var Controller = Context.GetManageController();

            return Context.HttpContext.Session != null &&
                   ContextProviderFactory.GetCurrent().CurrentRole(Context.HttpContext.Session) != null &&
                   ContextProviderFactory.GetCurrent().GetModelPermissions(Context.HttpContext.Session, t).Edit == true &&
                   (Controller == null || Controller.ModelType != t ||
                    Controller.OverridePermissions.Edit == true);
            }

        #endregion

        #region AllowExport

        public static bool AllowExport(this ViewContext Context, Type t)
            {
            var Controller = Context.GetManageController();

            return Context.HttpContext.Session != null &&
                   ContextProviderFactory.GetCurrent().CurrentRole(Context.HttpContext.Session) != null &&
                   ContextProviderFactory.GetCurrent().GetModelPermissions(Context.HttpContext.Session, t).Export ==
                   true &&
                   (Controller == null || Controller.ModelType != t ||
                    Controller.OverridePermissions.Export == true);
            }

        #endregion

        #region AllowView

        public static bool AllowView(this ViewContext Context, Type t)
            {
            var Controller = Context.GetManageController();

            return Context.HttpContext.Session != null &&
                   ContextProviderFactory.GetCurrent().CurrentRole(Context.HttpContext.Session) != null &&
                   ContextProviderFactory.GetCurrent().GetModelPermissions(Context.HttpContext.Session, t).View == true &&
                   (Controller == null ||
                    Controller.OverridePermissions.View == true);
            }

        #endregion

        #region AllowViewInactive

        public static bool AllowViewInactive(this ViewContext Context, Type t)
            {
            var Controller = Context.GetManageController();

            return Context.HttpContext.Session != null &&
                   ContextProviderFactory.GetCurrent().CurrentRole(Context.HttpContext.Session) != null &&
                   ContextProviderFactory.GetCurrent().GetModelPermissions(Context.HttpContext.Session, t).ViewInactive ==
                   true &&
                   (Controller == null || Controller.ModelType != t ||
                    Controller.OverridePermissions.ViewInactive == true);
            }

        #endregion

        #region GetActionName

        public static string GetActionName(this ViewContext Context)
            {
            return (string) Context.RouteData.Values["action"];
            }

        #endregion

        #region GetActionTrace

        public static IMenuAction[] GetActionTrace(this ViewContext Context)
            {
            string Action = Context.GetActionName();
            string Controller = Context.GetControllerName();

            var ControllerType = Type.GetType($"{Controller}Controller");

            var Method = ControllerType?.GetMethod(Action);

            var Out = new List<IMenuAction>();

            while (Method != null)
                {
                var Attr = Method.GetAttributes<IMenuAction>(true).FirstOrDefault() ?? new MenuAction();

                Attr.MethodName = Action;
                Attr.MenuText = Attr.MenuText ?? Attr.MethodName;

                Out.Add(Attr);

                ControllerType = Type.GetType(Attr.ParentController ?? Controller);

                Method = ControllerType?.GetMethod(Attr.ParentAction ?? Action);
                }

            Out.Reverse();

            return Out.ToArray();
            }

        #endregion

        #region GetControllerName

        public static string GetControllerName(this ViewContext Context)
            {
            return (string) Context.RouteData.Values["controller"];
            }

        #endregion

        #region GetManageController

        public static ManageController GetManageController(this ViewContext Context)
            {
            return Context.GetController<ManageController>();
            }

        #endregion

        #region GetController

        public static T GetController<T>(this ViewContext Context)
            where T : Controller
            {
            return Context.Controller as T;
            }

        #endregion

        #endregion

        #endregion
        }
    }