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
    
    #line 2 "..\..\Views\Shared\Manage\Fields\View\FormatString.cshtml"
    using Singularity.Annotations;
    
    #line default
    #line hidden
    using Singularity.Context;
    using Singularity.Controllers;
    using Singularity.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Manage/Fields/View/FormatString.cshtml")]
    public partial class _Views_Shared_Manage_Fields_View_FormatString_cshtml : System.Web.Mvc.WebViewPage<IViewField>
    {
        public _Views_Shared_Manage_Fields_View_FormatString_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("\r\n");

            
            #line 4 "..\..\Views\Shared\Manage\Fields\View\FormatString.cshtml"
  

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

WriteLiteral("<span>\r\n");

WriteLiteral("    ");

            
            #line 10 "..\..\Views\Shared\Manage\Fields\View\FormatString.cshtml"
Write(((IFormattable)Model.PropertyData).ToString((string)Model.Meta.AdditionalValues[FieldStringFormatAttribute.Key], null));

            
            #line default
            #line hidden
WriteLiteral("\r\n</span>");

        }
    }
}
#pragma warning restore 1591