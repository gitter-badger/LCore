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
    
    #line 2 "..\..\Views\EmailTemplate\EmailSavedSearch.cshtml"
    using Singularity.Extensions;
    
    #line default
    #line hidden
    using Singularity.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/EmailTemplate/EmailSavedSearch.cshtml")]
    public partial class _Views_EmailTemplate_EmailSavedSearch_cshtml : System.Web.Mvc.WebViewPage<EmailTemplateSavedSearchViewModel>
    {
        public _Views_EmailTemplate_EmailSavedSearch_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("\r\n");

            
            #line 4 "..\..\Views\EmailTemplate\EmailSavedSearch.cshtml"
  
    var SavedSearchSelector = new ViewField(ViewContext, typeof(SavedSearch), "SavedSearch", Model, ControllerHelper.ViewType.Edit);
    var TemplateSelector = new ViewField(ViewContext, typeof(EmailTemplate), "Template", Model, ControllerHelper.ViewType.Edit);
 // ReSharper disable once ArrangeThisQualifier
 // ReSharper disable once RedundantAssignment
    var Controller = this.ViewContext.Controller as EmailTemplateController;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 14 "..\..\Views\EmailTemplate\EmailSavedSearch.cshtml"
 using (Html.BeginForm(nameof(Controller.EmailSavedSearchTemplate),
        Url.Controller<EmailTemplateController>().ControllerName, FormMethod.Post, new { id = "logoutForm" }))
    {
    
            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\EmailTemplate\EmailSavedSearch.cshtml"
Write(Html.ViewField(SavedSearchSelector));

            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\EmailTemplate\EmailSavedSearch.cshtml"
                                        

    
            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\EmailTemplate\EmailSavedSearch.cshtml"
Write(Html.ViewField(TemplateSelector));

            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\EmailTemplate\EmailSavedSearch.cshtml"
                                     


            
            #line default
            #line hidden
WriteLiteral("    <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Next\"");

WriteLiteral(" />\r\n");

            
            #line 22 "..\..\Views\EmailTemplate\EmailSavedSearch.cshtml"
    }
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591