using System.Web.Mvc;
using LCore.Interfaces;
using LMVC.Controllers;

namespace LMVC.Extensions
    {
    [ExtensionProvider]
    public static class UrlExt
        {
        public static string ModelAction /*<T>*/(this UrlHelper Url, string Action, string Controller = "")
            {
            if (string.IsNullOrEmpty(Controller))
                {
                return Url.Action(Action,
                    //     ContextProviderFactory.GetCurrent().GetManageController(Url.RequestContext.HttpContext.Session, typeof(T)).Name,
                    Routes.Controllers.Manage.Actions.Route_Create(Url.RequestContext.HttpContext.Request));
                }
            return Url.Action(Action,
                Controller,
                Routes.Controllers.Manage.Actions.Route_Create(Url.RequestContext.HttpContext.Request));
            }

        public static string ModelCreate(this UrlHelper Url, string Controller = "")
            {
            return Url.ModelAction(nameof(ManageController.Create), Controller);
            }

        public static string ModelEdit(this UrlHelper Url, string Controller = "")
            {
            return Url.ModelAction(nameof(ManageController.Edit), Controller);
            }

        public static string ModelDelete(this UrlHelper Url, string Controller = "")
            {
            return Url.ModelAction(nameof(ManageController.Delete), Controller);
            }

        public static ControllerActionHelper<T> Controller<T>(this UrlHelper Url)
            {
            return new ControllerActionHelper<T>(Url);
            }
        }
    }