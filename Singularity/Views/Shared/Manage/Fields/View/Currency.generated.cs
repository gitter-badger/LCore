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
    using Singularity.Extensions;
    using Singularity.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Manage/Fields/View/Currency.cshtml")]
    public partial class _Views_Shared_Manage_Fields_View_Currency_cshtml : System.Web.Mvc.WebViewPage<IViewField>
    {
        public _Views_Shared_Manage_Fields_View_Currency_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n\r\n");

            
            #line 3 "..\..\Views\Shared\Manage\Fields\View\Currency.cshtml"
  


            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 9 "..\..\Views\Shared\Manage\Fields\View\Currency.cshtml"
  
    var Data = Model.PropertyData as IFormattable;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 13 "..\..\Views\Shared\Manage\Fields\View\Currency.cshtml"
 if (Data != null)
    {

            
            #line default
            #line hidden
WriteLiteral("    <span>\r\n");

WriteLiteral("        ");

            
            #line 16 "..\..\Views\Shared\Manage\Fields\View\Currency.cshtml"
   Write(Data.ToString("C", null));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </span>\r\n");

            
            #line 18 "..\..\Views\Shared\Manage\Fields\View\Currency.cshtml"
    }
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
