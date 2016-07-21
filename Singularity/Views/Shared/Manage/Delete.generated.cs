﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.Design;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Mvc.Routing;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 4 "..\..\Views\Shared\Manage\Delete.cshtml"
    using LCore.Extensions;
    
    #line default
    #line hidden
    using LMVC;
    using LMVC.Account;
    using LMVC.Annotations;
    using LMVC.Context;
    using LMVC.Controllers;
    using LMVC.Extensions;
    using LMVC.Models;
    using LMVC.Routes;
    using Singularity;
    
    #line 5 "..\..\Views\Shared\Manage\Delete.cshtml"
    using Singularity.Extensions;
    
    #line default
    #line hidden
    using Singularity.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Manage/Delete.cshtml")]
    public partial class _Views_Shared_Manage_Delete_cshtml : System.Web.Mvc.WebViewPage<IModel>
    {
        public _Views_Shared_Manage_Delete_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n\r\n\r\n");

WriteLiteral("\r\n");

            
            #line 7 "..\..\Views\Shared\Manage\Delete.cshtml"
  
    ViewBag.RestoreMode = Model.HasProperty("Active") && Model.GetProperty("Active") as bool? != true;

    ViewBag.Title = $"{(ViewBag.RestoreMode ? "Restore" : "Delete")} {Model.GetFriendlyTypeName()}: {Model}";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

WriteLiteral("\r\n<div");

WriteLiteral(" class=\"delete wide-form\"");

WriteLiteral(">\r\n    <h1>\r\n");

WriteLiteral("        ");

            
            #line 18 "..\..\Views\Shared\Manage\Delete.cshtml"
    Write(ViewBag.RestoreMode ? "Restore" : "Delete");

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 18 "..\..\Views\Shared\Manage\Delete.cshtml"
                                                 Write(Model.GetFriendlyTypeName());

            
            #line default
            #line hidden
WriteLiteral("\r\n    </h1>\r\n\r\n    <h2>\r\n");

WriteLiteral("        ");

            
            #line 22 "..\..\Views\Shared\Manage\Delete.cshtml"
   Write(Model.ToString());

            
            #line default
            #line hidden
WriteLiteral("\r\n    </h2>\r\n\r\n    <div");

WriteLiteral(" style=\"text-align: center;\"");

WriteLiteral(">\r\n        <h3>\r\n            Are you sure you want to ");

            
            #line 27 "..\..\Views\Shared\Manage\Delete.cshtml"
                                 Write(ViewBag.RestoreMode ? "restore" : "delete");

            
            #line default
            #line hidden
WriteLiteral(" this ");

            
            #line 27 "..\..\Views\Shared\Manage\Delete.cshtml"
                                                                                   Write(Model.GetFriendlyTypeName());

            
            #line default
            #line hidden
WriteLiteral("?\r\n        </h3>\r\n\r\n");

            
            #line 30 "..\..\Views\Shared\Manage\Delete.cshtml"
        
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\Shared\Manage\Delete.cshtml"
         using (Html.BeginForm("DeleteConfirm", (string)ViewBag.ControllerName, new { id = Model.GetID(), ViewBag.ReturnURL, Restore = ViewBag.RestoreMode }))
            {

            
            #line default
            #line hidden
WriteLiteral("            <a");

WriteAttribute("href", Tuple.Create(" href=\"", 902), Tuple.Create("\"", 927)
            
            #line 32 "..\..\Views\Shared\Manage\Delete.cshtml"
, Tuple.Create(Tuple.Create("", 909), Tuple.Create<System.Object, System.Int32>(ViewBag.ReturnURL
            
            #line default
            #line hidden
, 909), false)
);

WriteLiteral("\r\n               key-bind-click=\"N\"");

WriteLiteral("\r\n               class=\"btn-default btn-danger btn-lg pointer\"");

WriteLiteral("\r\n               key-bind-click-name=\"No\"");

WriteLiteral(">\r\n                <span>\r\n                    <glyph>&#xe091;</glyph>\r\n         " +
"           No\r\n                </span>\r\n            </a>\r\n");

WriteLiteral("            <a");

WriteLiteral(" class=\"btn-default btn-lg btn-success pointer\"");

WriteLiteral("\r\n               key-bind-click=\"Y\"");

WriteLiteral("\r\n               key-bind-click-name=\"Yes\"");

WriteLiteral("\r\n               onclick=\"$(\'form\').submit();\"");

WriteLiteral(">\r\n                <span>\r\n                    <glyph>");

            
            #line 46 "..\..\Views\Shared\Manage\Delete.cshtml"
                      Write(Html.Raw(ViewBag.RestoreMode ? "&#xe133;" : "&#xe020;"));

            
            #line default
            #line hidden
WriteLiteral("</glyph>\r\n                    Yes\r\n                </span>\r\n            </a>\r\n");

            
            #line 50 "..\..\Views\Shared\Manage\Delete.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
