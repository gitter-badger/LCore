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
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 2 "..\..\Views\Manage\ManageLogins.cshtml"
    using Microsoft.AspNet.Identity;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Manage\ManageLogins.cshtml"
    using Microsoft.Owin.Security;
    
    #line default
    #line hidden
    using SingularityInstance;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Manage/ManageLogins.cshtml")]
    public partial class _Views_Manage_ManageLogins_cshtml : System.Web.Mvc.WebViewPage<SingularityInstance.Models.ManageLoginsViewModel>
    {
        public _Views_Manage_ManageLogins_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\Manage\ManageLogins.cshtml"
  
    ViewBag.Title = "Manage your external logins";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h2>");

            
            #line 8 "..\..\Views\Manage\ManageLogins.cshtml"
Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral(".</h2>\r\n\r\n<p");

WriteLiteral(" class=\"text-success\"");

WriteLiteral(">");

            
            #line 10 "..\..\Views\Manage\ManageLogins.cshtml"
                   Write(ViewBag.StatusMessage);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 11 "..\..\Views\Manage\ManageLogins.cshtml"
  
    IEnumerable<AuthenticationDescription> loginProviders = Context.GetOwinContext().Authentication.GetExternalAuthenticationTypes();
    if (!loginProviders.Any()) {

            
            #line default
            #line hidden
WriteLiteral("        <div>\r\n            <p>\r\n                There are no external authenticat" +
"ion services configured. See <a");

WriteLiteral(" href=\"http://go.microsoft.com/fwlink/?LinkId=313242\"");

WriteLiteral(">this article</a>\r\n                for details on setting up this ASP.NET applica" +
"tion to support logging in via external services.\r\n            </p>\r\n        </d" +
"iv>\r\n");

            
            #line 20 "..\..\Views\Manage\ManageLogins.cshtml"
    }
    else
    {
        if (Model.CurrentLogins.Count > 0)
        {

            
            #line default
            #line hidden
WriteLiteral("            <h4>Registered Logins</h4>\r\n");

WriteLiteral("            <table");

WriteLiteral(" class=\"table\"");

WriteLiteral(">\r\n                <tbody>\r\n");

            
            #line 28 "..\..\Views\Manage\ManageLogins.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 28 "..\..\Views\Manage\ManageLogins.cshtml"
                     foreach (UserLoginInfo account in Model.CurrentLogins)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <tr>\r\n                            <td>");

            
            #line 31 "..\..\Views\Manage\ManageLogins.cshtml"
                           Write(account.LoginProvider);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                            <td>\r\n");

            
            #line 33 "..\..\Views\Manage\ManageLogins.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 33 "..\..\Views\Manage\ManageLogins.cshtml"
                                 if (ViewBag.ShowRemoveButton)
                                {
                                    using (Html.BeginForm("RemoveLogin", "Manage"))
                                    {
                                        
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\Manage\ManageLogins.cshtml"
                                   Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\Manage\ManageLogins.cshtml"
                                                                

            
            #line default
            #line hidden
WriteLiteral("                                        <div>\r\n");

WriteLiteral("                                            ");

            
            #line 39 "..\..\Views\Manage\ManageLogins.cshtml"
                                       Write(Html.Hidden("loginProvider", account.LoginProvider));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                            ");

            
            #line 40 "..\..\Views\Manage\ManageLogins.cshtml"
                                       Write(Html.Hidden("providerKey", account.ProviderKey));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" value=\"Remove\"");

WriteAttribute("title", Tuple.Create(" title=\"", 1803), Tuple.Create("\"", 1869)
, Tuple.Create(Tuple.Create("", 1811), Tuple.Create("Remove", 1811), true)
, Tuple.Create(Tuple.Create(" ", 1817), Tuple.Create("this", 1818), true)
            
            #line 41 "..\..\Views\Manage\ManageLogins.cshtml"
                                          , Tuple.Create(Tuple.Create(" ", 1822), Tuple.Create<System.Object, System.Int32>(account.LoginProvider
            
            #line default
            #line hidden
, 1823), false)
, Tuple.Create(Tuple.Create(" ", 1845), Tuple.Create("login", 1846), true)
, Tuple.Create(Tuple.Create(" ", 1851), Tuple.Create("from", 1852), true)
, Tuple.Create(Tuple.Create(" ", 1856), Tuple.Create("your", 1857), true)
, Tuple.Create(Tuple.Create(" ", 1861), Tuple.Create("account", 1862), true)
);

WriteLiteral(" />\r\n                                        </div>\r\n");

            
            #line 43 "..\..\Views\Manage\ManageLogins.cshtml"
                                    }
                                }
                                else
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    ");

WriteLiteral(" &nbsp;\r\n");

            
            #line 48 "..\..\Views\Manage\ManageLogins.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                            </td>\r\n                        </tr>\r\n");

            
            #line 51 "..\..\Views\Manage\ManageLogins.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </tbody>\r\n            </table>\r\n");

            
            #line 54 "..\..\Views\Manage\ManageLogins.cshtml"
        }
        if (Model.OtherLogins.Count > 0)
        {
            using (Html.BeginForm("LinkLogin", "Manage"))
            {
                
            
            #line default
            #line hidden
            
            #line 59 "..\..\Views\Manage\ManageLogins.cshtml"
           Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 59 "..\..\Views\Manage\ManageLogins.cshtml"
                                        

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" id=\"socialLoginList\"");

WriteLiteral(">\r\n                <p>\r\n");

            
            #line 62 "..\..\Views\Manage\ManageLogins.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 62 "..\..\Views\Manage\ManageLogins.cshtml"
                     foreach (AuthenticationDescription p in Model.OtherLogins)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteAttribute("id", Tuple.Create(" id=\"", 2707), Tuple.Create("\"", 2733)
            
            #line 64 "..\..\Views\Manage\ManageLogins.cshtml"
, Tuple.Create(Tuple.Create("", 2712), Tuple.Create<System.Object, System.Int32>(p.AuthenticationType
            
            #line default
            #line hidden
, 2712), false)
);

WriteLiteral(" name=\"provider\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2750), Tuple.Create("\"", 2779)
            
            #line 64 "..\..\Views\Manage\ManageLogins.cshtml"
                                        , Tuple.Create(Tuple.Create("", 2758), Tuple.Create<System.Object, System.Int32>(p.AuthenticationType
            
            #line default
            #line hidden
, 2758), false)
);

WriteAttribute("title", Tuple.Create(" title=\"", 2780), Tuple.Create("\"", 2824)
, Tuple.Create(Tuple.Create("", 2788), Tuple.Create("Log", 2788), true)
, Tuple.Create(Tuple.Create(" ", 2791), Tuple.Create("in", 2792), true)
, Tuple.Create(Tuple.Create(" ", 2794), Tuple.Create("using", 2795), true)
, Tuple.Create(Tuple.Create(" ", 2800), Tuple.Create("your", 2801), true)
            
            #line 64 "..\..\Views\Manage\ManageLogins.cshtml"
                                                                                       , Tuple.Create(Tuple.Create(" ", 2805), Tuple.Create<System.Object, System.Int32>(p.Caption
            
            #line default
            #line hidden
, 2806), false)
, Tuple.Create(Tuple.Create(" ", 2816), Tuple.Create("account", 2817), true)
);

WriteLiteral(">");

            
            #line 64 "..\..\Views\Manage\ManageLogins.cshtml"
                                                                                                                                                                                       Write(p.AuthenticationType);

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n");

            
            #line 65 "..\..\Views\Manage\ManageLogins.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </p>\r\n                </div>\r\n");

            
            #line 68 "..\..\Views\Manage\ManageLogins.cshtml"
            }
        }
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591
