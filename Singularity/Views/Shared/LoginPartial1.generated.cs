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
    
    #line 1 "..\..\Views\Shared\LoginPartial.cshtml"
    using Singularity.Account;
    
    #line default
    #line hidden
    using Singularity.Context;
    using Singularity.Controllers;
    using Singularity.Models;
    
    #line 2 "..\..\Views\Shared\LoginPartial.cshtml"
    using Singularity.Routes;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/LoginPartial.cshtml")]
    public partial class _Views_Shared_LoginPartial_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Shared_LoginPartial_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 4 "..\..\Views\Shared\LoginPartial.cshtml"
  
    AuthenticationService Auth = new AuthenticationService(Session);


            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 9 "..\..\Views\Shared\LoginPartial.cshtml"
 if (Auth.IsLoggedIn)
    {
    using (Html.BeginForm(Controllers.Account.Actions.LogOff, Controllers.Account.Name,
        FormMethod.Post, new { id = "logoutForm", @class = "navbar-right" }))
        {
        
            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\Shared\LoginPartial.cshtml"
   Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\Shared\LoginPartial.cshtml"
                                


            
            #line default
            #line hidden
WriteLiteral("        <ul");

WriteLiteral(" class=\"nav navbar-nav navbar-right\"");

WriteLiteral(">\r\n            <li>\r\n                Hello ");

            
            #line 18 "..\..\Views\Shared\LoginPartial.cshtml"
                 Write(Auth.UserName);

            
            #line default
            #line hidden
WriteLiteral("!\r\n            </li>\r\n            <li><a");

WriteLiteral(" href=\"javascript:document.getElementById(\'logoutForm\').submit()\"");

WriteLiteral(">Log off</a></li>\r\n        </ul>\r\n");

            
            #line 22 "..\..\Views\Shared\LoginPartial.cshtml"
        }
    }
else
    {

            
            #line default
            #line hidden
WriteLiteral("    <ul");

WriteLiteral(" class=\"nav navbar-nav navbar-right\"");

WriteLiteral(">\r\n        <li>\r\n");

WriteLiteral("            ");

            
            #line 28 "..\..\Views\Shared\LoginPartial.cshtml"
       Write(Html.ActionLink("Log in",
           Controllers.Account.Actions.Login, Controllers.Account.Name,
           null, htmlAttributes: new { id = "loginLink" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </li>\r\n</ul>\r\n");

            
            #line 33 "..\..\Views\Shared\LoginPartial.cshtml"
    }

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
