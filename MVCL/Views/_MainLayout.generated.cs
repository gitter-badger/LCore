﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
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
  
    ViewBag.Title = ViewBag.Title ?? "";


            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"utf-8\" />\r\n    " +
"<title>");


            
            #line 29 "..\..\Views\_MainLayout.cshtml"
      Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral(" - Singularity</title>\r\n    <meta name=\"description\" content=\"\" />\r\n    <link hre" +
"f=\"~/favicon.ico\" rel=\"shortcut icon\" type=\"image/x-icon\" />\r\n    <meta name=\"vi" +
"ewport\" content=\"width=device-width, initial-scale=1\">\r\n\r\n\r\n    <link href=\"/Con" +
"tent/singularity.css\" rel=\"stylesheet\">\r\n    <link href=\"/Content/bootstrap.css\"" +
" rel=\"stylesheet\">\r\n    <link href=\"/Content/jquery-ui/base/accordion.css\" rel=\"" +
"stylesheet\">\r\n    <link href=\"/Content/jquery-ui/base/all.css\" rel=\"stylesheet\">" +
"\r\n    <link href=\"/Content/jquery-ui/base/autocomplete.css\" rel=\"stylesheet\">\r\n " +
"   <link href=\"/Content/jquery-ui/base/base.css\" rel=\"stylesheet\">\r\n    <link hr" +
"ef=\"/Content/jquery-ui/base/button.css\" rel=\"stylesheet\">\r\n    <link href=\"/Cont" +
"ent/jquery-ui/base/core.css\" rel=\"stylesheet\">\r\n    <link href=\"/Content/jquery-" +
"ui/base/datepicker.css\" rel=\"stylesheet\">\r\n    <link href=\"/Content/jquery-ui/ba" +
"se/dialog.css\" rel=\"stylesheet\">\r\n    <link href=\"/Content/jquery-ui/base/dragga" +
"ble.css\" rel=\"stylesheet\">\r\n    <link href=\"/Content/jquery-ui/base/menu.css\" re" +
"l=\"stylesheet\">\r\n    <link href=\"/Content/jquery-ui/base/progressbar.css\" rel=\"s" +
"tylesheet\">\r\n    <link href=\"/Content/jquery-ui/base/resizable.css\" rel=\"stylesh" +
"eet\">\r\n    <link href=\"/Content/jquery-ui/base/selectable.css\" rel=\"stylesheet\">" +
"\r\n    <link href=\"/Content/jquery-ui/base/selectmenu.css\" rel=\"stylesheet\">\r\n   " +
" <link href=\"/Content/jquery-ui/base/slider.css\" rel=\"stylesheet\">\r\n    <link hr" +
"ef=\"/Content/jquery-ui/base/sortable.css\" rel=\"stylesheet\">\r\n    <link href=\"/Co" +
"ntent/jquery-ui/base/spinner.css\" rel=\"stylesheet\">\r\n    <link href=\"/Content/jq" +
"uery-ui/base/tabs.css\" rel=\"stylesheet\">\r\n    <link href=\"/Content/jquery-ui/bas" +
"e/theme.css\" rel=\"stylesheet\">\r\n    <link href=\"/Content/jquery-ui/base/tooltip." +
"css\" rel=\"stylesheet\">\r\n    <link href=\"/Content/mvcl.css\" rel=\"stylesheet\">\r\n\r\n" +
"\r\n    <link rel=\"stylesheet\" href=\"/Scripts/jquery-mobile/jquery-mobile-1.4.5.mi" +
"n.css\">\r\n    <script src=\"/Scripts/jquery-mobile/jquery-1.11.1.min.js\"></script>" +
"\r\n    <script src=\"/Scripts/jquery-mobile/jquery-mobile-1.4.5.min.js\"></script>\r" +
"\n\r\n    <script src=\"/Scripts/jquery-ui-1.11.4.js\"></script>\r\n    <script src=\"/S" +
"cripts/bootstrap.js\"></script>\r\n\r\n    <script src=\"/Scripts/singularity/singular" +
"ity-core.js\"></script>\r\n    <script src=\"/Scripts/singularity/singularity-object" +
".js\"></script>\r\n    <script src=\"/Scripts/singularity/singularity-tests.js\"></sc" +
"ript>\r\n    <script src=\"/Scripts/singularity/singularity-enumerable.js\"></script" +
">\r\n    <script src=\"/Scripts/singularity/singularity-js-function.js\"></script>\r\n" +
"    <script src=\"/Scripts/singularity/singularity-js-array.js\"></script>\r\n    <s" +
"cript src=\"/Scripts/singularity/singularity-js-boolean.js\"></script>\r\n    <scrip" +
"t src=\"/Scripts/singularity/singularity-js-number.js\"></script>\r\n    <script src" +
"=\"/Scripts/singularity/singularity-js-date.js\"></script>\r\n    <script src=\"/Scri" +
"pts/singularity/singularity-js-string.js\"></script>\r\n    <script src=\"/Scripts/s" +
"ingularity/singularity-text-bbcode.js\"></script>\r\n    <script src=\"/Scripts/sing" +
"ularity/singularity-regexp.js\"></script>\r\n    <script src=\"/Scripts/singularity/" +
"singularity-templates.js\"></script>\r\n    <script src=\"/Scripts/singularity/singu" +
"larity-jquery.js\"></script>\r\n    <script src=\"/Scripts/singularity/singularity-h" +
"tml.js\"></script>\r\n    <script src=\"/Scripts/singularity/singularity-doc.js\"></s" +
"cript>\r\n    <script src=\"/Scripts/singularity/singularity-log.js\"></script>\r\n\r\n " +
"   <script src=\"/Scripts/mvcl.js\"></script>\r\n    <script src=\"/Scripts/chance.js" +
"\"></script>\r\n    <script src=\"/Scripts/jquery.cookie.js\"></script>\r\n    <script " +
"src=\"/Scripts/jquery.mousewheel.js\"></script>\r\n    <script src=\"/Scripts/jquery." +
"timepicker.js\"></script>\r\n    <script src=\"/Scripts/qTip.js\"></script>\r\n\r\n    ");



WriteLiteral("\r\n</head>\r\n<body singularity class=\"");


            
            #line 143 "..\..\Views\_MainLayout.cshtml"
                     Write(ViewBag.ContextProvider != null ? StringExt.ToUrlSlug(ViewBag.ContextProvider.GetContext(Session).ContextName) : "");

            
            #line default
            #line hidden
WriteLiteral("\">\r\n\r\n    <script type=\"text/javascript\">\r\n\r\n        $(document).ready(function (" +
") {\r\n\r\n        })\r\n    </script>\r\n    <header>\r\n        ");



WriteLiteral("\r\n\r\n");


            
            #line 154 "..\..\Views\_MainLayout.cshtml"
         if (TempData.Peek(ControllerHelper.StatusMessage) != null)
        {
            String Message = (String)TempData[ControllerHelper.StatusMessage];
            String Icon = (String)(TempData[ControllerHelper.StatusMessageIcon] ?? "");


            
            #line default
            #line hidden
WriteLiteral("            <div class=\"status-message close-dialog\">\r\n");


            
            #line 160 "..\..\Views\_MainLayout.cshtml"
                 if (!String.IsNullOrEmpty(Icon))
                {

            
            #line default
            #line hidden
WriteLiteral("                    <glyph>");


            
            #line 162 "..\..\Views\_MainLayout.cshtml"
                      Write(Icon);

            
            #line default
            #line hidden
WriteLiteral("</glyph>\r\n");


            
            #line 163 "..\..\Views\_MainLayout.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("                ");


            
            #line 164 "..\..\Views\_MainLayout.cshtml"
           Write(Message);

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n");


            
            #line 166 "..\..\Views\_MainLayout.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral(@"
        <div class=""key-bind-tip"" style=""display:none"">
            <div class=""border-bottom"">
                <glyph>&#xe047;</glyph>
                Key Shortcuts
            </div>
            <span id=""key-bind-page-tip"">
            </span>
        </div>
    </header>
    <div id=""body"" data-role=""page"">

        ");


            
            #line 179 "..\..\Views\_MainLayout.cshtml"
   Write(RenderSection("featured", required: false));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n        <section class=\"content-wrapper main-content clear-fix\">\r\n           " +
" ");


            
            #line 182 "..\..\Views\_MainLayout.cshtml"
       Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\r\n        </section>\r\n    </div>\r\n    <footer>\r\n        <div class=\"content-wrapp" +
"er\">\r\n            <div class=\"float-left\">\r\n                <p>&copy; ");


            
            #line 188 "..\..\Views\_MainLayout.cshtml"
                     Write(DateTime.Now.Year);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n    </footer>\r\n\r\n    <script src=\"/Scri" +
"pts/jquery-mobile/jquery-1.11.1.min.js\"></script>\r\n\r\n    ");


            
            #line 195 "..\..\Views\_MainLayout.cshtml"
Write(RenderSection("scripts", required: false));

            
            #line default
            #line hidden
WriteLiteral("\r\n</body>\r\n</html>");


        }
    }
}
#pragma warning restore 1591
