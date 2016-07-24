using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.Interfaces;
using LMVC.Context;
using LMVC.Controllers;

namespace LMVC.Extensions
    {
    [ExtensionProvider]
    public static class SingularityControllerExt
        {
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

        #region AllowCreate

        public static bool AllowCreate(this ViewContext Context, Type Type)
            {
            var Controller = Context.GetManageController();

            return Context.HttpContext.Session != null &&
                   ContextProviderFactory.GetCurrent().CurrentRole(Context.HttpContext.Session) != null &&
                   ContextProviderFactory.GetCurrent().GetModelPermissions(Context.HttpContext.Session, Type)?.Create == true &&
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
                   ContextProviderFactory.GetCurrent().GetModelPermissions(Context.HttpContext.Session, Type)?.Deactivate == true &&
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
                   ContextProviderFactory.GetCurrent().GetModelPermissions(Context.HttpContext.Session, Type)?.Edit == true &&
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
                   ContextProviderFactory.GetCurrent().GetModelPermissions(Context.HttpContext.Session, Type)?.Export == true &&
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
                   ContextProviderFactory.GetCurrent().GetModelPermissions(Context.HttpContext.Session, Type)?.View ==
                   true &&
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
                   ContextProviderFactory.GetCurrent().GetModelPermissions(Context.HttpContext.Session, Type)?.ViewInactive == true &&
                   (Controller == null || Controller.ModelType != Type ||
                    Controller.OverridePermissions.ViewInactive == true);
            }

        #endregion

        #region HasContextType

        public static bool HasContextType<T>(this HttpContextBase Context)
            where T : class, new()
            {
            return ContextProviderFactory.GetCurrent().GetContextTypes(Context.Session).Has(typeof(T));
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

        #region GetManageController

        [CanBeNull]
        public static ManageController GetManageController(this ViewContext Context)
            {
            return Context.GetController<ManageController>();
            }

        #endregion
        }
    }