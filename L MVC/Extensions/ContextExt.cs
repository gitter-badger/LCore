using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LCore.Extensions;
using System.Web.Mvc;
using LMVC.Controllers;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using LCore.Interfaces;
using LMVC.Models;

namespace LMVC.Extensions
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

        #region GetController

        public static T GetController<T>(this ViewContext Context)
            {
            try
                {
                return (T)(object)Context.Controller;
                }
            catch
                {
                return default(T);
                }
            }

        #endregion

        #endregion

        #endregion
        }
    }