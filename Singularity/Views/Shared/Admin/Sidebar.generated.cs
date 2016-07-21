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
    
    #line 3 "..\..\Views\Shared\Admin\Sidebar.cshtml"
    using System.Reflection;
    
    #line default
    #line hidden
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
    
    #line 4 "..\..\Views\Shared\Admin\Sidebar.cshtml"
    using LCore.Interfaces;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Views\Shared\Admin\Sidebar.cshtml"
    using LCore.Tools;
    
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
    
    #line 6 "..\..\Views\Shared\Admin\Sidebar.cshtml"
    using Singularity.Extensions;
    
    #line default
    #line hidden
    using Singularity.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Admin/Sidebar.cshtml")]
    public partial class _Views_Shared_Admin_Sidebar_cshtml : SingularityRazor<dynamic>
    {
        public _Views_Shared_Admin_Sidebar_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 8 "..\..\Views\Shared\Admin\Sidebar.cshtml"
  
    Type[] ExtensionClasses_Singularity = L.Ref.GetNamespaceTypes(typeof(Singularity),
        Singularity.Namespaces.Singularity.Extensions,
        typeof(IExtensionProvider));

    Type[] ExtensionClasses_L = L.Ref.GetNamespaceTypes(typeof(L),
        Singularity.Namespaces.LCore.Extensions,
        typeof(IExtensionProvider));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<aside");

WriteLiteral(" class=\"main-sidebar\"");

WriteLiteral(">\r\n    <section");

WriteLiteral(" class=\"sidebar\"");

WriteLiteral(">\r\n\r\n        <div");

WriteLiteral(" class=\"user-panel\"");

WriteLiteral(">\r\n\r\n");

            
            #line 23 "..\..\Views\Shared\Admin\Sidebar.cshtml"
            
            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\Shared\Admin\Sidebar.cshtml"
             if (Auth.IsLoggedIn)
                {

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"pull-left image\"");

WriteLiteral(">\r\n                    <ident");

WriteLiteral(" class=\"img-circle\"");

WriteLiteral(">");

            
            #line 26 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                                         Write(User.GetHashCode());

            
            #line default
            #line hidden
WriteLiteral("</ident>\r\n                </div>\r\n");

WriteLiteral("                <div");

WriteLiteral(" class=\"pull-left info\"");

WriteLiteral(">\r\n                    <p>Alexander Pierce</p>\r\n                    <a");

WriteLiteral(" href=\"#\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-circle text-success\"");

WriteLiteral("></i> Online</a>\r\n                </div>\r\n");

            
            #line 32 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n\r\n        <form");

WriteLiteral(" action=\"#\"");

WriteLiteral(" method=\"get\"");

WriteLiteral(" class=\"sidebar-form site-search-form\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" name=\"q\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"Search...\"");

WriteLiteral(">\r\n                <span");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral(">\r\n                    <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" name=\"search\"");

WriteLiteral(" id=\"search-btn\"");

WriteLiteral(" class=\"btn btn-flat\"");

WriteLiteral(">\r\n                        <i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i>\r\n                    </button>\r\n                </span>\r\n            </div>" +
"\r\n        </form>\r\n        <ul");

WriteLiteral(" class=\"sidebar-menu\"");

WriteLiteral(">\r\n            <li");

WriteLiteral(" class=\"header\"");

WriteLiteral(">MAIN NAVIGATION</li>\r\n\r\n            <li");

WriteLiteral(" class=\"active treeview\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" href=\"/\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 50 "..\..\Views\Shared\Admin\Sidebar.cshtml"
               Write(Html.FontAwesome(FontAwesomeExt.Icon.circle));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <span>");

            
            #line 51 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                     Write(Singularity.AppName);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    <i");

WriteLiteral(" class=\"fa fa-angle-left pull-right\"");

WriteLiteral("></i>\r\n                </a>\r\n                <ul");

WriteLiteral(" class=\"treeview-menu\"");

WriteLiteral(">\r\n                    <li ");

            
            #line 55 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                    Write(ViewBag.Breadcrumbs?.Contains(
                        (Expression<Func<Set<string,string>,bool>>)(Set=> Set.Obj2.ToLower() == Url.Action(nameof(ExamplesController.L), typeof(ExamplesController).CName()))) == true ?
                        "class=\"active\"" : "");

            
            #line default
            #line hidden
WriteLiteral(">\r\n                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2254), Tuple.Create("\"", 2337)
            
            #line 58 "..\..\Views\Shared\Admin\Sidebar.cshtml"
, Tuple.Create(Tuple.Create("", 2261), Tuple.Create<System.Object, System.Int32>(Url.Action(nameof(ExamplesController.L),typeof(ExamplesController).CName())
            
            #line default
            #line hidden
, 2261), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 59 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                       Write(Html.FontAwesome(FontAwesomeExt.Icon.gbp));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            L <small");

WriteLiteral(" class=\"right\"");

WriteLiteral(">(C#)</small><br />\r\n                            <small>Standalone Extension Libr" +
"ary</small>\r\n                            <i");

WriteLiteral(" class=\"fa fa-angle-left pull-right\"");

WriteLiteral("></i>\r\n                        </a>\r\n                        <ul");

WriteLiteral(" class=\"treeview-menu\"");

WriteLiteral(">\r\n                            <li ");

            
            #line 65 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                            Write(ViewBag.Breadcrumbs?.Contains(
                                (Expression<Func<Set<string,string>,bool>>)(Set=> Set.Obj2.ToLower() == Url.Action(nameof(ExamplesController.L_Extensions), typeof(ExamplesController).CName()))) == true ?
                                "class=\"active\"" : "");

            
            #line default
            #line hidden
WriteLiteral(">\r\n                                <a");

WriteAttribute("href", Tuple.Create(" href=\"", 3076), Tuple.Create("\"", 3170)
            
            #line 68 "..\..\Views\Shared\Admin\Sidebar.cshtml"
, Tuple.Create(Tuple.Create("", 3083), Tuple.Create<System.Object, System.Int32>(Url.Action(nameof(ExamplesController.L_Extensions),typeof(ExamplesController).CName())
            
            #line default
            #line hidden
, 3083), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 69 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                               Write(Html.FontAwesome(FontAwesomeExt.Icon.link));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    Extensions\r\n                               " +
"     <small");

WriteLiteral(" class=\"right\"");

WriteLiteral(">(C#)</small>\r\n                                    <i");

WriteLiteral(" class=\"fa fa-angle-left pull-right\"");

WriteLiteral("></i>\r\n                                </a>\r\n\r\n                                <u" +
"l");

WriteLiteral(" class=\"treeview-menu\"");

WriteLiteral(">\r\n");

            
            #line 76 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                                    
            
            #line default
            #line hidden
            
            #line 76 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                                     foreach (var Ext in ExtensionClasses_L)
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                        <li ");

            
            #line 78 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                                        Write(ViewBag.Breadcrumbs?.Contains( (Expression<Func<Set<string, string>, bool>>)(Set => Set.Obj2.ToLower() == Url.Action(nameof(ExamplesController.L_Extensions_Class), typeof(ExamplesController).CName(), new { ClassName = Ext.Name }))) == true ? "class=\"active\"" : "");

            
            #line default
            #line hidden
WriteLiteral(">\r\n                                            <a");

WriteAttribute("href", Tuple.Create(" href=\"", 4037), Tuple.Create("\"", 4221)
            
            #line 79 "..\..\Views\Shared\Admin\Sidebar.cshtml"
, Tuple.Create(Tuple.Create("", 4044), Tuple.Create<System.Object, System.Int32>(Url.Action(nameof(ExamplesController.L_Extensions_Class), typeof(ExamplesController).CName(),
                                                    new { ClassName = Ext.Name })
            
            #line default
            #line hidden
, 4044), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                                                ");

            
            #line 81 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                                           Write(Html.FontAwesome(Singularity.Icons.GetTypeIcon(Ext) ?? FontAwesomeExt.Icon.question));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                                ");

            
            #line 82 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                                           Write(Ext.Name.Humanize().TrimEnd("Ext"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                <small");

WriteLiteral(" class=\"right\"");

WriteLiteral(">(C#)</small>\r\n                                                <i");

WriteLiteral(" class=\"fa fa-angle-left pull-right\"");

WriteLiteral("></i>\r\n                                            </a>\r\n");

            
            #line 86 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                                            
            
            #line default
            #line hidden
            
            #line 86 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                                              
                                            MethodInfo[] ExtMethods = Ext.GetExtensionMethods();
                                            
            
            #line default
            #line hidden
WriteLiteral("\r\n                                            <ul");

WriteLiteral(" class=\"treeview-menu\"");

WriteLiteral(">\r\n");

            
            #line 90 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                                                
            
            #line default
            #line hidden
            
            #line 90 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                                                 foreach (var Method in ExtMethods)
                                                    {

            
            #line default
            #line hidden
WriteLiteral("                                                    <li>\r\n                       " +
"                                 <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                            ");

            
            #line 94 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                                                       Write(Html.FontAwesome(FontAwesomeExt.Icon.question));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                                            ");

            
            #line 95 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                                                       Write(Method.Name);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                            <small");

WriteLiteral(" class=\"right\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                                ");

            
            #line 97 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                                                           Write(Method.ToInvocationSignature());

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                            </small>\r\n         " +
"                                                   <i");

WriteLiteral(" class=\"fa fa-angle-left pull-right\"");

WriteLiteral("></i>\r\n                                                        </a>\r\n            " +
"                                        </li>\r\n");

            
            #line 102 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                                                    }

            
            #line default
            #line hidden
WriteLiteral("                                            </ul>\r\n                              " +
"          </li>\r\n");

            
            #line 105 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                </ul>\r\n                            </li>\r\n       " +
"                     <li>\r\n                                <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 110 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                               Write(Html.FontAwesome(FontAwesomeExt.Icon.wrench));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    Tools\r\n                                    " +
"<small");

WriteLiteral(" class=\"right\"");

WriteLiteral(">(C#)</small>\r\n                                    <i");

WriteLiteral(" class=\"fa fa-angle-left pull-right\"");

WriteLiteral("></i>\r\n                                </a>\r\n                            </li>\r\n " +
"                       </ul>\r\n                    </li>\r\n                    <li" +
">\r\n                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 6674), Tuple.Create("\"", 6767)
            
            #line 119 "..\..\Views\Shared\Admin\Sidebar.cshtml"
, Tuple.Create(Tuple.Create("", 6681), Tuple.Create<System.Object, System.Int32>(Url.Action(nameof(ExamplesController.Singularity),typeof(ExamplesController).CName())
            
            #line default
            #line hidden
, 6681), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 120 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                       Write(Html.FontAwesome(FontAwesomeExt.Icon.dot_circle_o));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            Singularity <small");

WriteLiteral(" class=\"right\"");

WriteLiteral(">(C#)</small><br />\r\n                            <small>MVC-based framework</smal" +
"l>\r\n                            <i");

WriteLiteral(" class=\"fa fa-angle-left pull-right\"");

WriteLiteral("></i>\r\n                        </a>\r\n                        <ul");

WriteLiteral(" class=\"treeview-menu\"");

WriteLiteral(">\r\n                            <li>\r\n                                <a");

WriteAttribute("href", Tuple.Create(" href=\"", 7220), Tuple.Create("\"", 7323)
            
            #line 127 "..\..\Views\Shared\Admin\Sidebar.cshtml"
, Tuple.Create(Tuple.Create("", 7227), Tuple.Create<System.Object, System.Int32>(Url.Action(nameof(ExamplesController.SingularityExtensions),typeof(ExamplesController).CName())
            
            #line default
            #line hidden
, 7227), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 128 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                               Write(Html.FontAwesome(FontAwesomeExt.Icon.link));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    Extensions\r\n                               " +
"     <small");

WriteLiteral(" class=\"right\"");

WriteLiteral(">(C#)</small>\r\n                                    <i");

WriteLiteral(" class=\"fa fa-angle-left pull-right\"");

WriteLiteral("></i>\r\n                                </a>\r\n                                <ul");

WriteLiteral(" class=\"treeview-menu\"");

WriteLiteral(">\r\n");

            
            #line 134 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                                    
            
            #line default
            #line hidden
            
            #line 134 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                                     foreach (var Ext in ExtensionClasses_Singularity)
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                        <li>\r\n                                   " +
"         <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                ");

            
            #line 138 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                                           Write(Html.FontAwesome(Singularity.Icons.GetTypeIcon(Ext) ?? FontAwesomeExt.Icon.question));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                                ");

            
            #line 139 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                                           Write(Ext.Name.Trim("Ext").Humanize());

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                <small");

WriteLiteral(" class=\"right\"");

WriteLiteral("></small>\r\n                                            </a>\r\n\r\n\r\n                " +
"                        </li>\r\n");

            
            #line 145 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                </ul>\r\n                            </li>\r\n       " +
"                     <li>\r\n                                <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 150 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                               Write(Html.FontAwesome(FontAwesomeExt.Icon.wrench));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    Tools\r\n                                    " +
"<small");

WriteLiteral(" class=\"right\"");

WriteLiteral(">(C#)</small>\r\n                                </a>\r\n                            " +
"</li>\r\n                            <li>\r\n                                <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 157 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                               Write(Html.FontAwesome(FontAwesomeExt.Icon.file_code_o));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    Views\r\n                                    " +
"<small");

WriteLiteral(" class=\"right\"");

WriteLiteral(">(C#)</small>\r\n                                </a>\r\n                            " +
"</li>\r\n                        </ul>\r\n                    </li>\r\n               " +
"     <li>\r\n                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 166 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                       Write(Html.FontAwesome(FontAwesomeExt.Icon.link));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            Singularity TS<small");

WriteLiteral(" class=\"right\"");

WriteLiteral(">(HTML)(TS)(JS)</small><br />\r\n                            <small>Extension libra" +
"ry and template engine</small>\r\n                            <i");

WriteLiteral(" class=\"fa fa-angle-left pull-right\"");

WriteLiteral("></i>\r\n                        </a>\r\n                        <ul");

WriteLiteral(" class=\"treeview-menu\"");

WriteLiteral(">\r\n                            <li>\r\n                                <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 174 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                               Write(Html.FontAwesome(FontAwesomeExt.Icon.link));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    Extension library\r\n                        " +
"            <small");

WriteLiteral(" class=\"right\"");

WriteLiteral(">(TS)(JS)</small>\r\n                                    <i");

WriteLiteral(" class=\"fa fa-angle-left pull-right\"");

WriteLiteral("></i>\r\n                                </a>\r\n                            </li>\r\n " +
"                           <li>\r\n                                <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 182 "..\..\Views\Shared\Admin\Sidebar.cshtml"
                               Write(Html.FontAwesome(FontAwesomeExt.Icon.file_code_o));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    Templating library\r\n                       " +
"             <small");

WriteLiteral(" class=\"right\"");

WriteLiteral(">(HTML)</small>\r\n                                    <i");

WriteLiteral(" class=\"fa fa-angle-left pull-right\"");

WriteLiteral("></i>\r\n                                </a>\r\n                            </li>\r\n " +
"                       </ul>\r\n                    </li>\r\n                </ul>\r\n" +
"            </li>\r\n        </ul>\r\n    </section>\r\n</aside>");

        }
    }
}
#pragma warning restore 1591
