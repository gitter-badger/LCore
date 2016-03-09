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
using WebMatrix.WebData;

namespace Singularity.Extensions
    {
    public static class HtmlExt
        {
        public static String ControllerName(this HtmlHelper Html)
            {
            try
                {
                return (String)Html.ViewContext.RouteData.Values["controller"];
                }
            catch
                {
                return null;
                }
            }

        public static MvcHtmlString TextContent(this HtmlHelper Html, String Token, String DefaultText = "", Object[] ContextData = null, Boolean ShowText = true, Boolean AutoCreate = false)
            {
            return Html.Partial(PartialViews.TextContent, new TextContentViewModel(Token, DefaultText, ContextData, ShowText, AutoCreate));
            }

        public static MvcHtmlString TextContent(this HtmlHelper Html, String Token, MvcHtmlString DefaultText, Object[] ContextData = null, Boolean ShowText = true, Boolean AutoCreate = false)
            {
            return Html.Partial(PartialViews.TextContent, new TextContentViewModel(Token, DefaultText, ContextData, ShowText, AutoCreate));
            }


        public static Boolean ViewExists(this HtmlHelper Html, String Name)
            {
            return _ViewExistsCache(Html, Html.ViewContext.Controller.GetType().FullName, Name);
            }

        private static Func<HtmlHelper, String, String, Boolean> _ViewExists = (Html, ControllerName, Name) =>
            {
                ControllerContext ControllerContext = Html.ViewContext.Controller.ControllerContext;
                ViewEngineResult Result = ViewEngines.Engines.FindView(ControllerContext, Name, null);

                return Result != null && Result.View != null;
            };

        private static Func<HtmlHelper, String, String, Boolean> _ViewExistsCache = _ViewExists.Cache("ViewExists");

        public static MvcHtmlString ViewField(this HtmlHelper Html, IViewField Field)
            {
            return Html.Partial(ControllerHelper.PartialViews.Field, Field);
            }

        public static ControllerActionLinkHelper<T> Controller<T>(this HtmlHelper Html)
            where T : Controller
            {
            return new ControllerActionLinkHelper<T>(Html);
            }
        }
    }