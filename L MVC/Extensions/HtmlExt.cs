using System;
using LCore.Extensions;

using System.Web.Mvc;
using System.Web.Mvc.Html;
using LCore.Interfaces;
using Singularity.Models;
using Singularity.Routes;

namespace Singularity.Extensions
    {
    [ExtensionProvider]
    public static class HtmlExt
        {
        #region Extensions +

        #region Controller
        public static ControllerActionLinkHelper<T> Controller<T>(this HtmlHelper Html)
            where T : Controller
            {
            return new ControllerActionLinkHelper<T>(Html);
            }
        #endregion

        #region ControllerName
        public static string ControllerName(this HtmlHelper Html)
            {
            try
                {
                return (string)Html.ViewContext.RouteData.Values["controller"];
                }
            catch
                {
                return null;
                }
            }
        #endregion

        #region TextContent
        public static MvcHtmlString TextContent(this HtmlHelper Html, string Token, string DefaultText = "", object[] ContextData = null, bool ShowText = true, bool AutoCreate = false)
            {
            return Html.Partial(PartialViews.TextContent, new TextContentViewModel(Token, DefaultText, ContextData, ShowText, AutoCreate));
            }
        public static MvcHtmlString TextContent(this HtmlHelper Html, string Token, MvcHtmlString DefaultText, object[] ContextData = null, bool ShowText = true, bool AutoCreate = false)
            {
            return Html.Partial(PartialViews.TextContent, new TextContentViewModel(Token, DefaultText, ContextData, ShowText, AutoCreate));
            }
        #endregion

        #region ViewExists
        public static bool ViewExists(this HtmlHelper Html, string Name)
            {
            return _ViewExistsCache(Html, Html.ViewContext.Controller.GetType().FullName, Name);
            }

        private static readonly Func<HtmlHelper, string, string, bool> _ViewExists = (Html, ControllerName, Name) =>
            {
                var ControllerContext = Html.ViewContext.Controller.ControllerContext;
                var Result = ViewEngines.Engines.FindView(ControllerContext, Name, null);

                return Result?.View != null;
            };

        private static readonly Func<HtmlHelper, string, string, bool> _ViewExistsCache = _ViewExists.Cache("ViewExists");

        #endregion

        #region ViewField
        public static MvcHtmlString ViewField(this HtmlHelper Html, IViewField Field)
            {
            return Html.Partial(PartialViews.Manage.Fields.Field, Field);
            }

        #endregion

        #endregion
        }
    }