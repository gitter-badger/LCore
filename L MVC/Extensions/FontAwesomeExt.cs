using System;
using System.Collections.Generic;
using System.Web.Mvc;
using LCore;
using LCore.Extensions;
using LCore.Interfaces;

// ReSharper disable UnusedMember.Global

namespace LMVC.Extensions
    {
    [ExtensionProvider]
    public static class FontAwesomeExt
        {
        #region Extensions +

        #region FontAwesome

        // ReSharper disable once UnusedParameter.Global
        public static MvcHtmlString FontAwesome(this HtmlHelper Html, FontAwesomeIcon? Icon)
            {
            return Icon == null ?
                new MvcHtmlString("") :
                new MvcHtmlString($"<i class=\"fa fa-{StyleName((FontAwesomeIcon)Icon)}\"></i>");
            }

        #endregion

        #endregion

        #region Static Methods +

        #region StyleName

        public static string StyleName(FontAwesomeIcon i)
            {
            return i.ToString().ToLower().ReplaceAll("_", "-");
            }

        #endregion

        #endregion
        }
    }