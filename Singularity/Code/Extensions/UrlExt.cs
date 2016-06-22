using System.Web.Mvc;

namespace Singularity.Extensions
    {
    public static class UrlExt
        {
        public static string ModelAction/*<T>*/(this UrlHelper Url, string Action, string Controller = "")
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
            return Url.ModelAction(Routes.Controllers.Manage.Actions.Create, Controller);
            }
        public static string ModelEdit(this UrlHelper Url, string Controller = "")
            {
            return Url.ModelAction(Routes.Controllers.Manage.Actions.Edit, Controller);
            }
        public static string ModelDelete(this UrlHelper Url, string Controller = "")
            {
            return Url.ModelAction(Routes.Controllers.Manage.Actions.Delete, Controller);
            }

        public static ControllerActionHelper<T> Controller<T>(this UrlHelper Url)
            where T : Controller
            {
            return new ControllerActionHelper<T>(Url);
            }
        }
    }
