using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using LCore;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Singularity.Models;
using Singularity.Routes;
using Singularity.Controllers;
using Singularity.Context;
using System.IO;
using System.Dynamic;
using System.Web.Routing;

namespace Singularity.Extensions
    {
    public static class UrlExt
        {
        public static String ModelAction/*<T>*/(this UrlHelper Url, String Action, String Controller = "")
            {
            if (String.IsNullOrEmpty(Controller))
                {
                return Url.Action(Action,
                    //     ContextProviderFactory.GetCurrent().GetManageController(Url.RequestContext.HttpContext.Session, typeof(T)).Name,
                    Singularity.Routes.Controllers.Manage.Actions.Route_Create(Url.RequestContext.HttpContext.Request));
                }
            else
                {
                return Url.Action(Action,
                    Controller,
                    Singularity.Routes.Controllers.Manage.Actions.Route_Create(Url.RequestContext.HttpContext.Request));
                }
            }

        public static String ModelCreate(this UrlHelper Url, String Controller = "")
            {
            return Url.ModelAction(Singularity.Routes.Controllers.Manage.Actions.Create, Controller);
            }
        public static String ModelEdit(this UrlHelper Url, String Controller = "")
            {
            return Url.ModelAction(Singularity.Routes.Controllers.Manage.Actions.Edit, Controller);
            }
        public static String ModelDelete(this UrlHelper Url, String Controller = "")
            {
            return Url.ModelAction(Singularity.Routes.Controllers.Manage.Actions.Delete, Controller);
            }

        public static ControllerActionHelper<T> Controller<T>(this UrlHelper Url)
            where T : Controller
            {
            return new ControllerActionHelper<T>(Url);
            }
        }
    }
