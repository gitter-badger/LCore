﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    
    #line 11 "..\..\Views\_MainLayout.cshtml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 12 "..\..\Views\_MainLayout.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 13 "..\..\Views\_MainLayout.cshtml"
    using System.ComponentModel;
    
    #line default
    #line hidden
    
    #line 14 "..\..\Views\_MainLayout.cshtml"
    using System.ComponentModel.DataAnnotations;
    
    #line default
    #line hidden
    
    #line 15 "..\..\Views\_MainLayout.cshtml"
    using System.ComponentModel.Design;
    
    #line default
    #line hidden
    using System.IO;
    
    #line 9 "..\..\Views\_MainLayout.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 10 "..\..\Views\_MainLayout.cshtml"
    using System.Linq.Expressions;
    
    #line default
    #line hidden
    using System.Net;
    using System.Text;
    
    #line 16 "..\..\Views\_MainLayout.cshtml"
    using System.Web;
    
    #line default
    #line hidden
    using System.Web.Helpers;
    
    #line 18 "..\..\Views\_MainLayout.cshtml"
    using System.Web.Mvc;
    
    #line default
    #line hidden
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    
    #line 17 "..\..\Views\_MainLayout.cshtml"
    using System.Web.Optimization;
    
    #line default
    #line hidden
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 3 "..\..\Views\_MainLayout.cshtml"
    using LCore;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\_MainLayout.cshtml"
    using MVCL;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Views\_MainLayout.cshtml"
    using MVCL.Context;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Views\_MainLayout.cshtml"
    using MVCL.Controllers;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Views\_MainLayout.cshtml"
    using MVCL.Models;
    
    #line default
    #line hidden
    
    #line 8 "..\..\Views\_MainLayout.cshtml"
    using MVCL.Routes;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/_MainLayout.cshtml")]
    public partial class _Views__MainLayout_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views__MainLayout_cshtml()
        {
        }
        public override void Execute()
        {


WriteLiteral("\r\n\r\n");

















WriteLiteral("\r\n");


            
            #line 20 "..\..\Views\_MainLayout.cshtml"
  
    ViewBag.Title = ViewBag.Title ?? "Home";


            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"utf-8\" />\r\n    " +
"<title>");


            
            #line 29 "..\..\Views\_MainLayout.cshtml"
      Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral(" - MVCL</title>\r\n    <link href=\"~/favicon.ico\" rel=\"shortcut icon\" type=\"image/x" +
"-icon\" />\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n\r\n    ");


            
            #line 33 "..\..\Views\_MainLayout.cshtml"
Write(Scripts.Render(BundleConfig.Script_jQuery));

            
            #line default
            #line hidden
WriteLiteral("\r\n    ");


            
            #line 34 "..\..\Views\_MainLayout.cshtml"
Write(Scripts.Render(BundleConfig.Script_jQueryUI));

            
            #line default
            #line hidden
WriteLiteral("\r\n    ");


            
            #line 35 "..\..\Views\_MainLayout.cshtml"
Write(Scripts.Render(BundleConfig.Script_jQueryVal));

            
            #line default
            #line hidden
WriteLiteral("\r\n    ");


            
            #line 36 "..\..\Views\_MainLayout.cshtml"
Write(Scripts.Render(BundleConfig.Script_Bootstrap));

            
            #line default
            #line hidden
WriteLiteral("\r\n    ");


            
            #line 37 "..\..\Views\_MainLayout.cshtml"
Write(Scripts.Render(BundleConfig.Script_Modernizr));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    ");


            
            #line 39 "..\..\Views\_MainLayout.cshtml"
Write(Scripts.Render(ControllerHelper.Script_Singularity));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    ");


            
            #line 41 "..\..\Views\_MainLayout.cshtml"
Write(Scripts.Render(ControllerHelper.Script_MVCL));

            
            #line default
            #line hidden
WriteLiteral("\r\n    ");


            
            #line 42 "..\..\Views\_MainLayout.cshtml"
Write(Scripts.Render(ControllerHelper.Script_MVCL_Chance));

            
            #line default
            #line hidden
WriteLiteral("\r\n    ");


            
            #line 43 "..\..\Views\_MainLayout.cshtml"
Write(Scripts.Render(ControllerHelper.Script_MVCL_jQueryCookie));

            
            #line default
            #line hidden
WriteLiteral("\r\n    ");


            
            #line 44 "..\..\Views\_MainLayout.cshtml"
Write(Scripts.Render(ControllerHelper.Script_MVCL_jQueryMousewheel));

            
            #line default
            #line hidden
WriteLiteral("\r\n    ");


            
            #line 45 "..\..\Views\_MainLayout.cshtml"
Write(Scripts.Render(ControllerHelper.Script_MVCL_jQueryTimepicker));

            
            #line default
            #line hidden
WriteLiteral("\r\n    ");


            
            #line 46 "..\..\Views\_MainLayout.cshtml"
Write(Scripts.Render(ControllerHelper.Script_MVCL_qTip));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    ");


            
            #line 48 "..\..\Views\_MainLayout.cshtml"
Write(Styles.Render(ControllerHelper.Style_Singularity));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    ");


            
            #line 50 "..\..\Views\_MainLayout.cshtml"
Write(Styles.Render(BundleConfig.Style_Bootstrap));

            
            #line default
            #line hidden
WriteLiteral("\r\n    ");


            
            #line 51 "..\..\Views\_MainLayout.cshtml"
Write(Styles.Render(BundleConfig.Style_jQueryUI));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    ");


            
            #line 53 "..\..\Views\_MainLayout.cshtml"
Write(Styles.Render(ControllerHelper.Style_MVCL));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n</head>\r\n<body singularity class=\"");


            
            #line 56 "..\..\Views\_MainLayout.cshtml"
                     Write(ViewBag.ContextProvider != null ? StringExt.ToUrlSlug(ViewBag.ContextProvider.GetContext(Session).ContextName) : "");

            
            #line default
            #line hidden
WriteLiteral("\">\r\n\r\n    <script type=\"text/javascript\">\r\n\r\n        $().ready(function () {\r\n   " +
"         MNCL_Init();\r\n        })\r\n    </script>\r\n    <header>\r\n        ");



WriteLiteral("\r\n\r\n");


            
            #line 67 "..\..\Views\_MainLayout.cshtml"
         if (TempData.Peek(ControllerHelper.StatusMessage) != null)
        {
            String Message = (String)TempData[ControllerHelper.StatusMessage];
            String Icon = (String)(TempData[ControllerHelper.StatusMessageIcon] ?? "");


            
            #line default
            #line hidden
WriteLiteral("            <div class=\"status-message close-dialog\">\r\n");


            
            #line 73 "..\..\Views\_MainLayout.cshtml"
                 if (!String.IsNullOrEmpty(Icon))
                {

            
            #line default
            #line hidden
WriteLiteral("                    <glyph>");


            
            #line 75 "..\..\Views\_MainLayout.cshtml"
                      Write(Icon);

            
            #line default
            #line hidden
WriteLiteral("</glyph>\r\n");


            
            #line 76 "..\..\Views\_MainLayout.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("                ");


            
            #line 77 "..\..\Views\_MainLayout.cshtml"
           Write(Message);

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n");


            
            #line 79 "..\..\Views\_MainLayout.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral(@"
        <div class=""key-bind-tip"">
            <div class=""border-bottom"">
                <glyph>&#xe047;</glyph>
                Key Shortcuts
            </div>
            <span id=""key-bind-page-tip"">
            </span>
        </div>
    </header>
    <div id=""body"">

        ");


            
            #line 92 "..\..\Views\_MainLayout.cshtml"
   Write(RenderSection("featured", required: false));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n        <section class=\"content-wrapper main-content clear-fix\">\r\n           " +
" ");


            
            #line 95 "..\..\Views\_MainLayout.cshtml"
       Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\r\n        </section>\r\n    </div>\r\n    <footer>\r\n        <div class=\"content-wrapp" +
"er\">\r\n            <div class=\"float-left\">\r\n                <p>&copy; ");


            
            #line 101 "..\..\Views\_MainLayout.cshtml"
                     Write(DateTime.Now.Year);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n    </footer>\r\n    ");


            
            #line 105 "..\..\Views\_MainLayout.cshtml"
Write(Scripts.Render(BundleConfig.Script_jQuery));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    ");


            
            #line 107 "..\..\Views\_MainLayout.cshtml"
Write(RenderSection("scripts", required: false));

            
            #line default
            #line hidden
WriteLiteral("\r\n</body>\r\n</html>");


        }
    }
}
#pragma warning restore 1591
