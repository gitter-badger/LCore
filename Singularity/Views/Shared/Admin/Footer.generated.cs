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
    using Singularity.Context;
    using Singularity.Controllers;
    using Singularity.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Admin/Footer.cshtml")]
    public partial class _Views_Shared_Admin_Footer_cshtml : System.Web.Mvc.WebViewPage<ContextProvider>
    {
        public _Views_Shared_Admin_Footer_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<footer");

WriteLiteral(" class=\"main-footer\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"pull-right hidden-xs\"");

WriteLiteral(">\r\n        <b>Version</b> ");

            
            #line 5 "..\..\Views\Shared\Admin\Footer.cshtml"
                  Write(Model.GetVersionNumber());

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n    <strong>\r\n        Copyright &copy; ");

            
            #line 8 "..\..\Views\Shared\Admin\Footer.cshtml"
                    Write(DateTime.Now.Year);

            
            #line default
            #line hidden
WriteLiteral("\r\n        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 227), Tuple.Create("\"", 259)
            
            #line 9 "..\..\Views\Shared\Admin\Footer.cshtml"
, Tuple.Create(Tuple.Create("", 234), Tuple.Create<System.Object, System.Int32>(Singularity.Url.MainSite
            
            #line default
            #line hidden
, 234), false)
);

WriteLiteral(">Singularity</a>.\r\n    </strong>\r\n    All rights reserved.\r\n</footer>");

        }
    }
}
#pragma warning restore 1591
