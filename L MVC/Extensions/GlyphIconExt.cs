using System;
using System.Collections.Generic;
using System.Web.Mvc;
using LCore;
using LCore.Extensions;
using LCore.Interfaces;

// ReSharper disable UnusedParameter.Global

// ReSharper disable UnusedMember.Global

namespace LMVC.Extensions
    {
    [ExtensionProvider]
    public static class GlyphIconExt
        {
        #region Extensions +

        #region Glyph

        public static MvcHtmlString Glyph(this HtmlHelper Html, GlyphIcon Icon)
            {
            return new MvcHtmlString($"<span class=\"glyphicon glyphicon-{StyleName(Icon)}\"></span>");
            }

        #endregion

        #endregion
        
        #region Static Methods +

        #region StyleName

        public static string StyleName(GlyphIcon i)
            {
            return i.ToString().ToLower().ReplaceAll("_", "-");
            }

        #endregion

        #endregion

        }
    }