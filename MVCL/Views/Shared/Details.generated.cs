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
    
    #line 9 "..\..\Views\Shared\Details.cshtml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 10 "..\..\Views\Shared\Details.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 11 "..\..\Views\Shared\Details.cshtml"
    using System.ComponentModel;
    
    #line default
    #line hidden
    
    #line 12 "..\..\Views\Shared\Details.cshtml"
    using System.ComponentModel.DataAnnotations;
    
    #line default
    #line hidden
    
    #line 13 "..\..\Views\Shared\Details.cshtml"
    using System.ComponentModel.DataAnnotations.Schema;
    
    #line default
    #line hidden
    
    #line 14 "..\..\Views\Shared\Details.cshtml"
    using System.ComponentModel.Design;
    
    #line default
    #line hidden
    using System.IO;
    
    #line 7 "..\..\Views\Shared\Details.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 8 "..\..\Views\Shared\Details.cshtml"
    using System.Linq.Expressions;
    
    #line default
    #line hidden
    using System.Net;
    using System.Text;
    
    #line 15 "..\..\Views\Shared\Details.cshtml"
    using System.Web;
    
    #line default
    #line hidden
    using System.Web.Helpers;
    
    #line 16 "..\..\Views\Shared\Details.cshtml"
    using System.Web.Mvc;
    
    #line default
    #line hidden
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 3 "..\..\Views\Shared\Details.cshtml"
    using LCore;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\Shared\Details.cshtml"
    using MVCL;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Views\Shared\Details.cshtml"
    using MVCL.Controllers;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Views\Shared\Details.cshtml"
    using MVCL.Models;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Details.cshtml")]
    public partial class _Views_Shared_Details_cshtml : System.Web.Mvc.WebViewPage<IModel>
    {
        public _Views_Shared_Details_cshtml()
        {
        }
        public override void Execute()
        {


WriteLiteral("\r\n\r\n");















WriteLiteral("\r\n");


            
            #line 18 "..\..\Views\Shared\Details.cshtml"
  
    ViewBag.Title = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

    ControllerHelper.ViewType ViewType = ControllerHelper.ViewType.Display;

    IEnumerable<System.Web.ModelBinding.ModelMetadata> Fields = null;

    if (Model is IFieldGroups)
    {
        Fields = ((IFieldGroups)Model).GetFieldGroup(Context, ViewType);
    }
    else
    {
        Fields = FieldGroups.GetFieldGroup(Context, Model.TrueModelType(), ViewType);
    }


            
            #line default
            #line hidden
WriteLiteral("\r\n");


WriteLiteral("\r\n<div class=\"details wide-form\">\r\n\r\n");


            
            #line 40 "..\..\Views\Shared\Details.cshtml"
     if (!String.IsNullOrEmpty(ViewBag.ReturnURL))
    {
        if (ViewContext.Controller is ManageController &&
            ((ManageController)ViewContext.Controller).OverridePermissions.Edit == true &&
            ControllerHelper.AllowEdit(Session, Model.TrueModelType()))
        {

            
            #line default
            #line hidden
WriteLiteral("            <a class=\"btn-default right\" href=\"");


            
            #line 46 "..\..\Views\Shared\Details.cshtml"
                                          Write(Url.Action(ViewBag.ManageController.EditActionName,
                    ViewBag.ManageController.Name, new { id = Model.GetID(), ReturnURL = Request.Url }));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                <glyph>&#xe065;</glyph>\r\n                Edit\r\n            </" +
"a>\r\n");


            
            #line 51 "..\..\Views\Shared\Details.cshtml"
        }


            
            #line default
            #line hidden
WriteLiteral("        <a class=\"btn-default right\" href=\"");


            
            #line 53 "..\..\Views\Shared\Details.cshtml"
                                      Write(ViewBag.ReturnURL);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n            <glyph>&#xe091;</glyph>\r\n            Back\r\n        </a>\r\n");


            
            #line 57 "..\..\Views\Shared\Details.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n    <h1>\r\n        ");


            
            #line 60 "..\..\Views\Shared\Details.cshtml"
   Write(Model.GetFriendlyTypeName());

            
            #line default
            #line hidden
WriteLiteral(" Details\r\n    </h1>\r\n\r\n    <h2>\r\n        ");


            
            #line 64 "..\..\Views\Shared\Details.cshtml"
   Write(Model.ToString());

            
            #line default
            #line hidden
WriteLiteral("\r\n    </h2>\r\n\r\n");


            
            #line 67 "..\..\Views\Shared\Details.cshtml"
     foreach (System.Web.ModelBinding.ModelMetadata Meta in Fields)
    {
        String ColumnClass = Meta.PropertyName.ToUrlSlug();

        ViewField Field = new ViewField(Context, Model.TrueModelType(), Meta.PropertyName, Model, ViewType);

        
            
            #line default
            #line hidden
            
            #line 73 "..\..\Views\Shared\Details.cshtml"
   Write(Html.Partial(ControllerHelper.PartialViews.Field, Field));

            
            #line default
            #line hidden
            
            #line 73 "..\..\Views\Shared\Details.cshtml"
                                                                 
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 76 "..\..\Views\Shared\Details.cshtml"
     if (!String.IsNullOrEmpty(ViewBag.ReturnURL))
    {
        if (ViewContext.Controller is ManageController &&
            ((ManageController)ViewContext.Controller).OverridePermissions.Edit == true &&
            ControllerHelper.AllowEdit(Session, Model.TrueModelType()))
        {

            
            #line default
            #line hidden
WriteLiteral("            <a class=\"btn-default right\" href=\"");


            
            #line 82 "..\..\Views\Shared\Details.cshtml"
                                          Write(Url.Action(ViewBag.ManageController.EditActionName,
                    ViewBag.ManageController.Name, new { id = Model.GetID(), ReturnURL = Request.Url }));

            
            #line default
            #line hidden
WriteLiteral("\"\r\n               key-bind-click=\"Ctrl+E\"\r\n               key-bind-click-name=\"Ed" +
"it\">\r\n                <glyph>&#xe065;</glyph>\r\n                Edit\r\n           " +
" </a>\r\n");


            
            #line 89 "..\..\Views\Shared\Details.cshtml"
        }


            
            #line default
            #line hidden
WriteLiteral("        <a class=\"btn-default right\"\r\n           href=\"");


            
            #line 92 "..\..\Views\Shared\Details.cshtml"
            Write(ViewBag.ReturnURL);

            
            #line default
            #line hidden
WriteLiteral("\"\r\n           key-bind-click=\"Esc\"\r\n           key-bind-click-name=\"Back\">\r\n     " +
"       <glyph>&#xe091;</glyph>\r\n            Back\r\n        </a>\r\n");


            
            #line 98 "..\..\Views\Shared\Details.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>");


        }
    }
}
#pragma warning restore 1591
