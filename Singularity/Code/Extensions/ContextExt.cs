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

        public static string GetTableName<T>(this DbContext Context) where T : class
            {
            var ObjectContext = ((IObjectContextAdapter)Context).ObjectContext;

            return ObjectContext.GetTableName<T>();
            }

        public static string GetTableName(this DbContext Context, Type Type)
            {
            var ObjectContext = ((IObjectContextAdapter)Context).ObjectContext;

            return ObjectContext.GetTableName(Type);
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

        public static string GetTableName<T>(this ObjectContext Context) where T : class
            {
            string SQL = Context.CreateObjectSet<T>().ToTraceString();

            var Match = SQL.Matches("FROM (?<table>.*) AS").FirstOrDefault();

            string Table = Match?.Groups["table"].Value;
            return Table;
            }

        /// <exception cref="InvalidOperationException">Cannot get table name from context</exception>
        public static string GetTableName(this ObjectContext Context, Type Type)
            {
            var Method = (MethodInfo)Context.GetType().GetMember("CreateObjectSet").FirstOrDefault();

            Method = Method?.MakeGenericMethod(Type);

            if (Method != null)
                {
                ObjectQuery Query;
                try
                    {
                    Query = (ObjectQuery)Method.Invoke(Context, new object[] { });
                    }
                catch (Exception Ex)
                    {
                    throw new InvalidOperationException("Cannot get table name from context", Ex);
                    }

                string SQL = Query.ToTraceString();

                var Match = SQL.Matches("FROM (?<table>.*) AS").FirstOrDefault();

                string Table = Match?.Groups["table"].Value;
                return Table;
                }

            return null;
            }

        #endregion

        #endregion

        #region ViewContext +

        #region AllowCreate

        public static bool AllowCreate(this ViewContext Context, Type Type)
            {
            var Controller = Context.GetManageController();

            return Context.HttpContext.Session != null &&
                   ContextProviderFactory.GetCurrent().CurrentRole(Context.HttpContext.Session) != null &&
                   ContextProviderFactory.GetCurrent().GetModelPermissions(Context.HttpContext.Session, Type).Create ==
                   true &&
                   (Controller == null || Controller.ModelType != Type ||
                    Controller.OverridePermissions.Create == true);
            }

        #endregion

        #region AllowDeactivate

        public static bool AllowDeactivate(this ViewContext Context, Type Type)
            {
            var Controller = Context.GetManageController();

            return Context.HttpContext.Session != null &&
                   ContextProviderFactory.GetCurrent().CurrentRole(Context.HttpContext.Session) != null &&
                   ContextProviderFactory.GetCurrent().GetModelPermissions(Context.HttpContext.Session, Type).Deactivate ==
                   true &&
                   (Controller == null || Controller.ModelType != Type ||
                    Controller.OverridePermissions.Deactivate == true);
            }

        #endregion

        #region AllowEdit

        public static bool AllowEdit(this ViewContext Context, Type Type)
            {
            var Controller = Context.GetManageController();

            return Context.HttpContext.Session != null &&
                   ContextProviderFactory.GetCurrent().CurrentRole(Context.HttpContext.Session) != null &&
                   ContextProviderFactory.GetCurrent().GetModelPermissions(Context.HttpContext.Session, Type).Edit == true &&
                   (Controller == null || Controller.ModelType != Type ||
                    Controller.OverridePermissions.Edit == true);
            }

        #endregion

        #region AllowExport

        public static bool AllowExport(this ViewContext Context, Type Type)
            {
            var Controller = Context.GetManageController();

            return Context.HttpContext.Session != null &&
                   ContextProviderFactory.GetCurrent().CurrentRole(Context.HttpContext.Session) != null &&
                   ContextProviderFactory.GetCurrent().GetModelPermissions(Context.HttpContext.Session, Type).Export ==
                   true &&
                   (Controller == null || Controller.ModelType != Type ||
                    Controller.OverridePermissions.Export == true);
            }

        #endregion

        #region AllowView

        public static bool AllowView(this ViewContext Context, Type Type)
            {
            var Controller = Context.GetManageController();

            return Context.HttpContext.Session != null &&
                   ContextProviderFactory.GetCurrent().CurrentRole(Context.HttpContext.Session) != null &&
                   ContextProviderFactory.GetCurrent().GetModelPermissions(Context.HttpContext.Session, Type).View == true &&
                   (Controller == null ||
                    Controller.OverridePermissions.View == true);
            }

        #endregion

        #region AllowViewInactive

        public static bool AllowViewInactive(this ViewContext Context, Type Type)
            {
            var Controller = Context.GetManageController();

            return Context.HttpContext.Session != null &&
                   ContextProviderFactory.GetCurrent().CurrentRole(Context.HttpContext.Session) != null &&
                   ContextProviderFactory.GetCurrent().GetModelPermissions(Context.HttpContext.Session, Type).ViewInactive ==
                   true &&
                   (Controller == null || Controller.ModelType != Type ||
                    Controller.OverridePermissions.ViewInactive == true);
            }

        #endregion

        #region GetActionName

        public static string GetActionName(this ViewContext Context)
            {
            return (string)Context.RouteData.Values["action"];
            }

        #endregion

        #region GetActionTrace


        public static IMenuAction[] GetActionTrace(this ViewContext Context)
            {
            string Action = Context.GetActionName();
            string Controller = Context.GetControllerName();

            Type ControllerType;

            try
                {
                ControllerType = Type.GetType($"{Controller}Controller");
                }
            catch (Exception Ex)
                {
                ControllerHelper.HandleError(Context.HttpContext, Ex);
                return new IMenuAction[] { };
                }

            MethodInfo Method;

            try
                {
                Method = ControllerType?.GetMethod(Action);
                }
            catch (AmbiguousMatchException Ex)
                {
                ControllerHelper.HandleError(Context.HttpContext, Ex);
                return new IMenuAction[] { };
                }

            var Out = new List<IMenuAction>();

            while (Method != null)
                {
                var Attr = Method.GetAttributes<IMenuAction>(true).FirstOrDefault() ?? new MenuAction();

                Attr.MethodName = Action;
                Attr.MenuText = Attr.MenuText ?? Attr.MethodName;

                Out.Add(Attr);

                try
                    {
                    ControllerType = Type.GetType(Attr.ParentController ?? Controller);

                    Method = ControllerType?.GetMethod(Attr.ParentAction ?? Action);
                    }
                catch (Exception Ex)
                    {
                    ControllerHelper.HandleError(Context.HttpContext, Ex);
                    return new IMenuAction[] { };
                    }
                }

            Out.Reverse();

            return Out.ToArray();
            }

        #endregion

        #region GetControllerName

        public static string GetControllerName(this ViewContext Context)
            {
            return (string)Context.RouteData.Values["controller"];
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