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
    
    #line 10 "..\..\Views\Shared\_Menu.cshtml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 11 "..\..\Views\Shared\_Menu.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 12 "..\..\Views\Shared\_Menu.cshtml"
    using System.ComponentModel;
    
    #line default
    #line hidden
    
    #line 13 "..\..\Views\Shared\_Menu.cshtml"
    using System.ComponentModel.DataAnnotations;
    
    #line default
    #line hidden
    
    #line 14 "..\..\Views\Shared\_Menu.cshtml"
    using System.ComponentModel.Design;
    
    #line default
    #line hidden
    using System.IO;
    
    #line 8 "..\..\Views\Shared\_Menu.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 9 "..\..\Views\Shared\_Menu.cshtml"
    using System.Linq.Expressions;
    
    #line default
    #line hidden
    using System.Net;
    using System.Text;
    
    #line 15 "..\..\Views\Shared\_Menu.cshtml"
    using System.Web;
    
    #line default
    #line hidden
    using System.Web.Helpers;
    
    #line 16 "..\..\Views\Shared\_Menu.cshtml"
    using System.Web.Mvc;
    
    #line default
    #line hidden
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 3 "..\..\Views\Shared\_Menu.cshtml"
    using LCore;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\Shared\_Menu.cshtml"
    using MVCL;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Views\Shared\_Menu.cshtml"
    using MVCL.Context;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Views\Shared\_Menu.cshtml"
    using MVCL.Controllers;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Views\Shared\_Menu.cshtml"
    using MVCL.Models;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/_Menu.cshtml")]
    public partial class _Views_Shared__Menu_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Shared__Menu_cshtml()
        {
        }
        public override void Execute()
        {


WriteLiteral("\r\n\r\n");















WriteLiteral("\r\n");


            
            #line 18 "..\..\Views\Shared\_Menu.cshtml"
  



            
            #line default
            #line hidden
WriteLiteral("\r\n<div class=\"content-wrapper\">\r\n    <div class=\"float-left\">\r\n        <p class=\"" +
"site-title\">\r\n            <a href=\"");


            
            #line 25 "..\..\Views\Shared\_Menu.cshtml"
                Write(Url.Action("Index", "Home"));

            
            #line default
            #line hidden
WriteLiteral(")\">\r\n                <img id=\"logo\" src=\"");


            
            #line 26 "..\..\Views\Shared\_Menu.cshtml"
                               Write(ViewBag.ContextProvider.GetContext(Session).GetLogoURL());

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n            </a>\r\n        </p>\r\n");


            
            #line 29 "..\..\Views\Shared\_Menu.cshtml"
         if (ControllerHelper.IsLoggedIn(Session))
            {

            
            #line default
            #line hidden
WriteLiteral("            <a href=\"");


            
            #line 31 "..\..\Views\Shared\_Menu.cshtml"
                Write(Url.Action("SwitchContext", "Main"));

            
            #line default
            #line hidden
WriteLiteral(" \" class=\"context-switch\" title=\"Switch Sites\"></a>\r\n");


            
            #line 32 "..\..\Views\Shared\_Menu.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n    <div class=\"float-right\">\r\n        <section id=\"login\">\r\n        " +
"    ");


            
            #line 36 "..\..\Views\Shared\_Menu.cshtml"
       Write(Html.Partial(ControllerHelper.PartialViews.Login));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </section>\r\n        <nav>\r\n            <ul id=\"menu\">\r\n                " +
"<li>\r\n                    ");


            
            #line 41 "..\..\Views\Shared\_Menu.cshtml"
               Write(Html.ActionLink("Home", "Index", "Home"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");


            
            #line 43 "..\..\Views\Shared\_Menu.cshtml"
                     if (ControllerHelper.IsLoggedIn(Session))
                        {
                        foreach (IGrouping<String, ManageController> Group in ContextProviderFactory.GetCurrent().AllManageControllers(Session).GroupBy(m => m.PageGroup))
                            {
                            if (Group.Has((m) =>
                            {
                                return m.OverridePermissions.View == true &&
                                    ControllerHelper.AllowView(Session, m.ModelType);
                            }))
                                {

            
            #line default
            #line hidden
WriteLiteral("                            <li>\r\n                                <span>");


            
            #line 54 "..\..\Views\Shared\_Menu.cshtml"
                                 Write(Group.Key);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                                <ul>\r\n");


            
            #line 56 "..\..\Views\Shared\_Menu.cshtml"
                                     foreach (ManageController Manage in Group)
                                        {
                                        if (Manage.OverridePermissions.View == true &&
                                            ControllerHelper.AllowView(Session, Manage.ModelType))
                                            {

            
            #line default
            #line hidden
WriteLiteral("                                            <li>\r\n                               " +
"                 ");


            
            #line 62 "..\..\Views\Shared\_Menu.cshtml"
                                           Write(Html.ActionLink(Manage.MenuText, Manage.ManageActionName, Manage.Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </li>\r\n");


            
            #line 64 "..\..\Views\Shared\_Menu.cshtml"
                                            }
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                </ul>\r\n                            </li>\r\n");


            
            #line 68 "..\..\Views\Shared\_Menu.cshtml"
                                }
                            }
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </li>\r\n                </ul>\r\n            </nav>\r\n        </d" +
"iv>\r\n    </div>");


        }
    }
}
#pragma warning restore 1591
