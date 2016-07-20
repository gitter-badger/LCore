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
    
    #line 4 "..\..\Views\Shared\TextContent.cshtml"
    using LCore.Extensions;
    
    #line default
    #line hidden
    using LMVC;
    using LMVC.Annotations;
    using LMVC.Context;
    using LMVC.Controllers;
    using LMVC.Extensions;
    using LMVC.Models;
    using Singularity;
    
    #line 5 "..\..\Views\Shared\TextContent.cshtml"
    using Singularity.Extensions;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/TextContent.cshtml")]
    public partial class _Views_Shared_TextContent_cshtml : System.Web.Mvc.WebViewPage<TextContentViewModel>
    {
        public _Views_Shared_TextContent_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n\r\n\r\n");

WriteLiteral("\r\n");

            
            #line 7 "..\..\Views\Shared\TextContent.cshtml"
  


    string Token = Model.Token ?? "";

    Token = Token.ReplaceAll(" ", "");

    var ContextProvider = ContextProviderFactory.GetCurrent();
    var Context = ContextProvider.GetContext(Session);

    var Content = TextContent.FindByToken(Context, Token);

    // Auto-create TextContent models so they exist before being filled in
    if (Content == null && Model.AutoCreate)
        {
        Content = new TextContent
            {
            Active = true,
            Token = Model.Token,
            Text = Model.DefaultText
            };

        Context.GetDBSet<TextContent>().Add(Content);

        try
            {
            Context.SaveChanges();
            }
        catch
            {

            }
        }

    var Permissions = ContextProvider.GetModelPermissions(Session, typeof(TextContent));

    string Display = Content != null ? Content.Text : Model.DefaultText;
    Display = Display ?? "";

    for (int Index = 0; Index < Model.ContextData.Length; Index++)
        {
        Display = Display.ReplaceAll($"[{Index}]", (Model.ContextData[Index] ?? "").ToString());
        }

    Display = Display.ReplaceAll("\r\n", "<br>");

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 55 "..\..\Views\Shared\TextContent.cshtml"
 try
    {
    if (Content != null)
        {

            
            #line default
            #line hidden
WriteLiteral("        <span");

WriteLiteral(" class=\"text-content-custom\"");

WriteLiteral(">\r\n");

            
            #line 60 "..\..\Views\Shared\TextContent.cshtml"
            
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\Shared\TextContent.cshtml"
             if (Model.ShowText)
                {
                
            
            #line default
            #line hidden
            
            #line 62 "..\..\Views\Shared\TextContent.cshtml"
           Write(Html.Raw(Display));

            
            #line default
            #line hidden
            
            #line 62 "..\..\Views\Shared\TextContent.cshtml"
                                  
                }
            else
                {

            
            #line default
            #line hidden
WriteLiteral("                <span>...</span>\r\n");

            
            #line 67 "..\..\Views\Shared\TextContent.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            ");

            
            #line 68 "..\..\Views\Shared\TextContent.cshtml"
             if (Permissions != null && Permissions.Edit == true)
                {

            
            #line default
            #line hidden
WriteLiteral("                <span");

WriteAttribute("class", Tuple.Create(" class=\"", 1734), Tuple.Create("\"", 1795)
, Tuple.Create(Tuple.Create("", 1742), Tuple.Create("text-content-edit", 1742), true)
            
            #line 70 "..\..\Views\Shared\TextContent.cshtml"
, Tuple.Create(Tuple.Create(" ", 1759), Tuple.Create<System.Object, System.Int32>(Model.ShowText ? "" : "no-text" 
            
            #line default
            #line hidden
, 1760), false)
);

WriteLiteral(">\r\n\r\n                    <span");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 1826), Tuple.Create("\"", 2170)
, Tuple.Create(Tuple.Create("", 1836), Tuple.Create("window.location", 1836), true)
, Tuple.Create(Tuple.Create(" ", 1851), Tuple.Create("=", 1852), true)
, Tuple.Create(Tuple.Create(" ", 1853), Tuple.Create("\'", 1854), true)
            
            #line 72 "..\..\Views\Shared\TextContent.cshtml"
, Tuple.Create(Tuple.Create("", 1855), Tuple.Create<System.Object, System.Int32>(Url.Controller<TextContentController>()
                    .QS(new Dictionary<string, object> { { "Token", Token }, { "DefaultText", HttpUtility.HtmlEncode(Model.DefaultText) } })
                    .Action(Controller => Controller.Edit, Content.GetID<int>(), Request.Url?.AbsoluteUri, false)
            
            #line default
            #line hidden
, 1855), false)
, Tuple.Create(Tuple.Create("", 2154), Tuple.Create("\';", 2154), true)
, Tuple.Create(Tuple.Create(" ", 2156), Tuple.Create("return", 2157), true)
, Tuple.Create(Tuple.Create(" ", 2163), Tuple.Create("false;", 2164), true)
);

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(">\r\n                        <glyph>&#xe065;</glyph>\r\n                    </span>\r\n" +
"                </span>\r\n");

            
            #line 78 "..\..\Views\Shared\TextContent.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("        </span>\r\n");

            
            #line 80 "..\..\Views\Shared\TextContent.cshtml"
        }
    else
        {

            
            #line default
            #line hidden
WriteLiteral("        <span");

WriteLiteral(" class=\"text-content-default\"");

WriteLiteral(">\r\n");

            
            #line 84 "..\..\Views\Shared\TextContent.cshtml"
            
            
            #line default
            #line hidden
            
            #line 84 "..\..\Views\Shared\TextContent.cshtml"
             if (Model.ShowText)
                {
                
            
            #line default
            #line hidden
            
            #line 86 "..\..\Views\Shared\TextContent.cshtml"
           Write(Html.Raw(Display));

            
            #line default
            #line hidden
            
            #line 86 "..\..\Views\Shared\TextContent.cshtml"
                                  
                }
            else
                {

            
            #line default
            #line hidden
WriteLiteral("                <span>...</span>\r\n");

            
            #line 91 "..\..\Views\Shared\TextContent.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            ");

            
            #line 92 "..\..\Views\Shared\TextContent.cshtml"
             if (Permissions != null && Permissions.Create == true)
                {

            
            #line default
            #line hidden
WriteLiteral("                <span");

WriteAttribute("class", Tuple.Create(" class=\"", 2721), Tuple.Create("\"", 2783)
, Tuple.Create(Tuple.Create("", 2729), Tuple.Create("text-content-create", 2729), true)
            
            #line 94 "..\..\Views\Shared\TextContent.cshtml"
, Tuple.Create(Tuple.Create(" ", 2748), Tuple.Create<System.Object, System.Int32>(Model.ShowText ? "" : "no-text"
            
            #line default
            #line hidden
, 2749), false)
);

WriteLiteral(">\r\n\r\n\r\n                    <span");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 2816), Tuple.Create("\"", 3133)
, Tuple.Create(Tuple.Create("", 2826), Tuple.Create("window.location", 2826), true)
, Tuple.Create(Tuple.Create(" ", 2841), Tuple.Create("=", 2842), true)
, Tuple.Create(Tuple.Create(" ", 2843), Tuple.Create("\'", 2844), true)
            
            #line 97 "..\..\Views\Shared\TextContent.cshtml"
, Tuple.Create(Tuple.Create("", 2845), Tuple.Create<System.Object, System.Int32>(Url.Controller<TextContentController>()
                    .QS(new Dictionary<string, object> { { "Token", Token }, { "DefaultText", HttpUtility.HtmlEncode(Model.DefaultText) } })
                    .Action(Controller => Controller.Create, Request.Url?.AbsoluteUri)
            
            #line default
            #line hidden
, 2845), false)
, Tuple.Create(Tuple.Create("", 3117), Tuple.Create("\';", 3117), true)
, Tuple.Create(Tuple.Create(" ", 3119), Tuple.Create("return", 3120), true)
, Tuple.Create(Tuple.Create(" ", 3126), Tuple.Create("false;", 3127), true)
);

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(">\r\n                        <glyph>&#xe065;</glyph>\r\n                    </span>\r\n" +
"                </span>\r\n");

            
            #line 103 "..\..\Views\Shared\TextContent.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("        </span>\r\n");

            
            #line 105 "..\..\Views\Shared\TextContent.cshtml"
        }
    }
catch
    {
    }
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
