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
    
    #line 4 "..\..\Views\Shared\Template.cshtml"
    using System.Data.Entity.Infrastructure;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Views\Shared\Template.cshtml"
    using System.Data.Entity.Validation;
    
    #line default
    #line hidden
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
    
    #line 6 "..\..\Views\Shared\Template.cshtml"
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
    
    #line 7 "..\..\Views\Shared\Template.cshtml"
    using Singularity.Extensions;
    
    #line default
    #line hidden
    using Singularity.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Template.cshtml")]
    public partial class _Views_Shared_Template_cshtml : System.Web.Mvc.WebViewPage<TemplateViewModel>
    {
        public _Views_Shared_Template_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n\r\n\r\n");

WriteLiteral("\r\n");

            
            #line 9 "..\..\Views\Shared\Template.cshtml"
  
    string Token = Model.Token ?? "";

    Token = Token.ReplaceAll(" ", "");

    var ContextProvider = ContextProviderFactory.GetCurrent();
    var Context = ContextProvider.GetContext(Session);

    var Content = Template.FindByToken(Context, Token);

    // Auto-create Template models so they exist before being filled in
    if (Content == null && Model.AutoCreate)
        {
        Content = new Template
            {
            Active = true,
            Token = Model.Token,
            TemplateHTML = Model.DefaultText
            };

        Context.GetDBSet<Template>().Add(Content);

        try
            {
            Context.SaveChanges();
            }
        catch (DbUpdateException) { }
        catch (DbEntityValidationException) { }
        }

    var Permissions = ContextProvider.GetModelPermissions(Session, typeof(Template));

    string Display = Content != null ? Content.TemplateHTML : Model.DefaultText;
    Display = Display ?? "";

    for (int Index = 0; Index < Model.ContextData.Length; Index++)
        {
        Display = Display.ReplaceAll($"[{Index}]", (Model.ContextData[Index] ?? "").ToString());
        }

    Display = Display.ReplaceAll("\r\n", "<br>");

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 54 "..\..\Views\Shared\Template.cshtml"
 if (Content != null)
    {

            
            #line default
            #line hidden
WriteLiteral("    <span");

WriteLiteral(" class=\"text-content-custom\"");

WriteLiteral(">\r\n");

            
            #line 57 "..\..\Views\Shared\Template.cshtml"
        
            
            #line default
            #line hidden
            
            #line 57 "..\..\Views\Shared\Template.cshtml"
         if (Model.ShowText)
            {
            
            
            #line default
            #line hidden
            
            #line 59 "..\..\Views\Shared\Template.cshtml"
       Write(Html.Raw(Display));

            
            #line default
            #line hidden
            
            #line 59 "..\..\Views\Shared\Template.cshtml"
                              
            }
        else
            {

            
            #line default
            #line hidden
WriteLiteral("            <span>...</span>\r\n");

            
            #line 64 "..\..\Views\Shared\Template.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        ");

            
            #line 65 "..\..\Views\Shared\Template.cshtml"
         if (Permissions.Edit == true)
            {

            
            #line default
            #line hidden
WriteLiteral("            <span");

WriteLiteral(" class=\"text-content-edit\"");

WriteLiteral(">\r\n                <span");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 1810), Tuple.Create("\"", 2151)
, Tuple.Create(Tuple.Create("", 1820), Tuple.Create("window.location", 1820), true)
, Tuple.Create(Tuple.Create(" ", 1835), Tuple.Create("=", 1836), true)
, Tuple.Create(Tuple.Create(" ", 1837), Tuple.Create("\'", 1838), true)
            
            #line 68 "..\..\Views\Shared\Template.cshtml"
, Tuple.Create(Tuple.Create("", 1839), Tuple.Create<System.Object, System.Int32>(Url.Controller<TemplateController>()
                    .QS(new Dictionary<string, object> { { "Token", Token }, { "DefaultText", HttpUtility.HtmlEncode(Model.DefaultText) } })
                    .Action(Controller => Controller.Edit, Content.GetID<int>(), Request.Url?.AbsoluteUri, false)
            
            #line default
            #line hidden
, 1839), false)
, Tuple.Create(Tuple.Create("", 2135), Tuple.Create("\';", 2135), true)
, Tuple.Create(Tuple.Create(" ", 2137), Tuple.Create("return", 2138), true)
, Tuple.Create(Tuple.Create(" ", 2144), Tuple.Create("false;", 2145), true)
);

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(">\r\n                    <glyph>&#xe065;</glyph>\r\n                </span>\r\n        " +
"    </span>\r\n");

            
            #line 74 "..\..\Views\Shared\Template.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("    </span>\r\n");

            
            #line 76 "..\..\Views\Shared\Template.cshtml"
    }
else
    {

            
            #line default
            #line hidden
WriteLiteral("    <span");

WriteLiteral(" class=\"text-content-default\"");

WriteLiteral(">\r\n");

            
            #line 80 "..\..\Views\Shared\Template.cshtml"
        
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\Shared\Template.cshtml"
         if (Model.ShowText)
            {
            
            
            #line default
            #line hidden
            
            #line 82 "..\..\Views\Shared\Template.cshtml"
       Write(Html.Raw(Display));

            
            #line default
            #line hidden
            
            #line 82 "..\..\Views\Shared\Template.cshtml"
                              
            }
        else
            {

            
            #line default
            #line hidden
WriteLiteral("            <span>...</span>\r\n");

            
            #line 87 "..\..\Views\Shared\Template.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        ");

            
            #line 88 "..\..\Views\Shared\Template.cshtml"
         if (Permissions.Create == true)
            {

            
            #line default
            #line hidden
WriteLiteral("            <span");

WriteLiteral(" class=\"text-content-create\"");

WriteLiteral(">\r\n\r\n                <span");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 2653), Tuple.Create("\"", 2967)
, Tuple.Create(Tuple.Create("", 2663), Tuple.Create("window.location", 2663), true)
, Tuple.Create(Tuple.Create(" ", 2678), Tuple.Create("=", 2679), true)
, Tuple.Create(Tuple.Create(" ", 2680), Tuple.Create("\'", 2681), true)
            
            #line 92 "..\..\Views\Shared\Template.cshtml"
, Tuple.Create(Tuple.Create("", 2682), Tuple.Create<System.Object, System.Int32>(Url.Controller<TemplateController>()
                    .QS(new Dictionary<string, object> { { "Token", Token }, { "DefaultText", HttpUtility.HtmlEncode(Model.DefaultText) } })
                    .Action(Controller => Controller.Create, Request.Url?.AbsoluteUri)
            
            #line default
            #line hidden
, 2682), false)
, Tuple.Create(Tuple.Create("", 2951), Tuple.Create("\';", 2951), true)
, Tuple.Create(Tuple.Create(" ", 2953), Tuple.Create("return", 2954), true)
, Tuple.Create(Tuple.Create(" ", 2960), Tuple.Create("false;", 2961), true)
);

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(">\r\n                    <glyph>&#xe065;</glyph>\r\n                </span>\r\n        " +
"    </span>\r\n");

            
            #line 98 "..\..\Views\Shared\Template.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("    </span>\r\n");

            
            #line 100 "..\..\Views\Shared\Template.cshtml"
    }

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
