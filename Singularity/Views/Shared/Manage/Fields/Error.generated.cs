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
    using Singularity;
    using LMVC.Context;
    using LMVC.Controllers;
    using Singularity.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Manage/Fields/Error.cshtml")]
    public partial class _Views_Shared_Manage_Fields_Error_cshtml : System.Web.Mvc.WebViewPage<Exception>
    {
        public _Views_Shared_Manage_Fields_Error_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n\r\n");

            
            #line 3 "..\..\Views\Shared\Manage\Fields\Error.cshtml"
  


            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

WriteLiteral("<span");

WriteLiteral(" class=\"field-error error\"");

WriteLiteral(">\r\n\r\n");

            
            #line 11 "..\..\Views\Shared\Manage\Fields\Error.cshtml"
    
            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\Shared\Manage\Fields\Error.cshtml"
     if (ContextProviderFactory.GetCurrent().CurrentUser(Session) != null &&
                ContextProviderFactory.GetCurrent().CurrentUser(Session).IsAdmin)
        {

            
            #line default
            #line hidden
WriteLiteral("        <a");

WriteAttribute("title", Tuple.Create(" title=\"", 277), Tuple.Create("\"", 302)
            
            #line 14 "..\..\Views\Shared\Manage\Fields\Error.cshtml"
, Tuple.Create(Tuple.Create("", 285), Tuple.Create<System.Object, System.Int32>(Model.ToString()
            
            #line default
            #line hidden
, 285), false)
);

WriteLiteral(">Error</a>\r\n");

            
            #line 15 "..\..\Views\Shared\Manage\Fields\Error.cshtml"
        }
    else
        {

            
            #line default
            #line hidden
WriteLiteral("        <a>Error</a>\r\n");

            
            #line 19 "..\..\Views\Shared\Manage\Fields\Error.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("</span>");

        }
    }
}
#pragma warning restore 1591
