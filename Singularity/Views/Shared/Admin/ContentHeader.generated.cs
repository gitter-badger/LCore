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
    using LCore.Extensions;
    
    #line 3 "..\..\Views\Shared\Admin\ContentHeader.cshtml"
    using LCore.Tools;
    
    #line default
    #line hidden
    using Singularity;
    using Singularity.Context;
    using Singularity.Controllers;
    
    #line 4 "..\..\Views\Shared\Admin\ContentHeader.cshtml"
    using Singularity.Extensions;
    
    #line default
    #line hidden
    using Singularity.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Admin/ContentHeader.cshtml")]
    public partial class _Views_Shared_Admin_ContentHeader_cshtml : SingularityRazor<dynamic>
    {
        public _Views_Shared_Admin_ContentHeader_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n\r\n");

            
            #line 7 "..\..\Views\Shared\Admin\ContentHeader.cshtml"
  
    Set<string, string>[] Breadcrumbs = SingController.Breadcrumbs ?? new Set<string, string>[] { };

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<section");

WriteLiteral(" class=\"content-header\"");

WriteLiteral(">\r\n\r\n    <h1");

WriteLiteral(" class=\"breadcrumb-title\"");

WriteLiteral(">\r\n");

            
            #line 14 "..\..\Views\Shared\Admin\ContentHeader.cshtml"
        
            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\Shared\Admin\ContentHeader.cshtml"
         for (int i = 0; i < Breadcrumbs.Length; i++)
            {
            Set<string, string> Key = Breadcrumbs[i];
            bool Last = i == Breadcrumbs.Length - 1;

            if (Last)
                {
                
            
            #line default
            #line hidden
            
            #line 21 "..\..\Views\Shared\Admin\ContentHeader.cshtml"
           Write(Key.Obj1);

            
            #line default
            #line hidden
            
            #line 21 "..\..\Views\Shared\Admin\ContentHeader.cshtml"
                         
                }
            else
                {

            
            #line default
            #line hidden
WriteLiteral("                <a");

WriteAttribute("href", Tuple.Create(" href=\"", 591), Tuple.Create("\"", 607)
            
            #line 25 "..\..\Views\Shared\Admin\ContentHeader.cshtml"
, Tuple.Create(Tuple.Create("", 598), Tuple.Create<System.Object, System.Int32>(Key.Obj2
            
            #line default
            #line hidden
, 598), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 26 "..\..\Views\Shared\Admin\ContentHeader.cshtml"
               Write(Key.Obj1);

            
            #line default
            #line hidden
WriteLiteral("\r\n                </a>\r\n");

            
            #line 28 "..\..\Views\Shared\Admin\ContentHeader.cshtml"
                
            
            #line default
            #line hidden
            
            #line 28 "..\..\Views\Shared\Admin\ContentHeader.cshtml"
           Write(Html.FontAwesome(FontAwesomeExt.Icon.arrow_right));

            
            #line default
            #line hidden
            
            #line 28 "..\..\Views\Shared\Admin\ContentHeader.cshtml"
                                                                  
                }
            }

            
            #line default
            #line hidden
WriteLiteral("    </h1>\r\n\r\n    <ol");

WriteLiteral(" class=\"breadcrumb\"");

WriteLiteral(">\r\n");

            
            #line 34 "..\..\Views\Shared\Admin\ContentHeader.cshtml"
        
            
            #line default
            #line hidden
            
            #line 34 "..\..\Views\Shared\Admin\ContentHeader.cshtml"
         for (int i = 0; i < Breadcrumbs.Length; i++)
            {
            Set<string, string> Key = Breadcrumbs[i];
            bool Last = i == Breadcrumbs.Length - 1;

            if (Last)
                {

            
            #line default
            #line hidden
WriteLiteral("                <li");

WriteLiteral(" class=\"active\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 42 "..\..\Views\Shared\Admin\ContentHeader.cshtml"
               Write(Key.Obj1);

            
            #line default
            #line hidden
WriteLiteral("\r\n                </li>\r\n");

            
            #line 44 "..\..\Views\Shared\Admin\ContentHeader.cshtml"
                }
            else
                {

            
            #line default
            #line hidden
WriteLiteral("                <li");

WriteLiteral(" class=\"active\"");

WriteLiteral(">\r\n                    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1237), Tuple.Create("\"", 1253)
            
            #line 48 "..\..\Views\Shared\Admin\ContentHeader.cshtml"
, Tuple.Create(Tuple.Create("", 1244), Tuple.Create<System.Object, System.Int32>(Key.Obj2
            
            #line default
            #line hidden
, 1244), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 49 "..\..\Views\Shared\Admin\ContentHeader.cshtml"
                   Write(Key.Obj1);

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </a>\r\n                </li>\r\n");

            
            #line 52 "..\..\Views\Shared\Admin\ContentHeader.cshtml"
                
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\Shared\Admin\ContentHeader.cshtml"
           Write(Html.FontAwesome(FontAwesomeExt.Icon.arrow_right));

            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\Shared\Admin\ContentHeader.cshtml"
                                                                  
                }
            }

            
            #line default
            #line hidden
WriteLiteral("    </ol>\r\n</section>\r\n\r\n<h1>");

            
            #line 58 "..\..\Views\Shared\Admin\ContentHeader.cshtml"
Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n");

        }
    }
}
#pragma warning restore 1591
