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
    
    #line 2 "..\..\Views\Shared\Manage\Fields\View\String.cshtml"
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
    using Singularity.Extensions;
    using Singularity.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Manage/Fields/View/String.cshtml")]
    public partial class _Views_Shared_Manage_Fields_View_String_cshtml : System.Web.Mvc.WebViewPage<IViewField>
    {
        public _Views_Shared_Manage_Fields_View_String_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("\r\n");

            
            #line 4 "..\..\Views\Shared\Manage\Fields\View\String.cshtml"
  

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 9 "..\..\Views\Shared\Manage\Fields\View\String.cshtml"
 if (Model.ViewTypes.Has(ControllerHelper.ViewType.TableCell) &&
    Model.PropertyData.ToString().Length > SingularityControllerHelper.DefaultTableTextLength)
    {

            
            #line default
            #line hidden
WriteLiteral("    <span");

WriteLiteral(" class=\"abbreviated\"");

WriteAttribute("title", Tuple.Create(" title=\"", 282), Tuple.Create("\"", 309)
            
            #line 12 "..\..\Views\Shared\Manage\Fields\View\String.cshtml"
, Tuple.Create(Tuple.Create("", 290), Tuple.Create<System.Object, System.Int32>(Model.PropertyData
            
            #line default
            #line hidden
, 290), false)
);

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 13 "..\..\Views\Shared\Manage\Fields\View\String.cshtml"
   Write(Model.PropertyData.ToString().Substring(startIndex: 0, length: SingularityControllerHelper.DefaultTableTextLength));

            
            #line default
            #line hidden
WriteLiteral(" ...\r\n    </span>\r\n");

            
            #line 15 "..\..\Views\Shared\Manage\Fields\View\String.cshtml"
    }
else
    {

            
            #line default
            #line hidden
WriteLiteral("    <span>\r\n");

WriteLiteral("        ");

            
            #line 19 "..\..\Views\Shared\Manage\Fields\View\String.cshtml"
   Write(Model.PropertyData);

            
            #line default
            #line hidden
WriteLiteral("\r\n    </span>\r\n");

            
            #line 21 "..\..\Views\Shared\Manage\Fields\View\String.cshtml"
    }
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
