using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.ModelBinding;
using LCore;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Singularity
    {
    public static class HtmlExt
        {
        public static String ControllerName(this HtmlHelper Html)
            {
            try
                {
                return (String)Html.ViewContext.RouteData.Values["controller"];
                }
            catch (Exception e)
                {
                return null;
                }
            }

        public static Boolean ViewExists(this HtmlHelper Html, String Name)
            {
            return _ViewExistsCache(Html, Name);
            }

        private static Func<HtmlHelper, String, Boolean> _ViewExists = (Html, Name) =>
          {
              ControllerContext ControllerContext = Html.ViewContext.Controller.ControllerContext;
              ViewEngineResult Result = ViewEngines.Engines.FindView(ControllerContext, Name, null);

              return Result != null && Result.View != null;
          };

        private static Func<HtmlHelper, String, Boolean> _ViewExistsCache = _ViewExists.Cache("ViewExists");
        }
    }