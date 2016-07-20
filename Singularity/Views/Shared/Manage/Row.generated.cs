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
    using LMVC;
    using LMVC.Account;
    using LMVC.Annotations;
    using LMVC.Context;
    using LMVC.Controllers;
    using LMVC.Extensions;
    using LMVC.Models;
    using Singularity;
    
    #line 3 "..\..\Views\Shared\Manage\Row.cshtml"
    using Singularity.Extensions;
    
    #line default
    #line hidden
    using Singularity.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Manage/Row.cshtml")]
    public partial class _Views_Shared_Manage_Row_cshtml : System.Web.Mvc.WebViewPage<IModel>
    {
        public _Views_Shared_Manage_Row_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n\r\n");

WriteLiteral("\r\n");

            
            #line 5 "..\..\Views\Shared\Manage\Row.cshtml"
  
    bool InlineEdit = ViewBag.InlineEdit == true && ViewBag.InlineEditID == Model.GetID();

    ControllerHelper.ViewType[] ViewTypes = InlineEdit ?
        new[] { ControllerHelper.ViewType.Edit, ControllerHelper.ViewType.TableCell } :
        new[] { ControllerHelper.ViewType.TableCell };

    var Groups = Model as IFieldGroups;
    IEnumerable<ModelMetadata> Fields = Groups != null ?
        Groups.GetFieldGroup(Context, ControllerHelper.ViewType.TableCell) :
        FieldGroups.GetFieldGroup(Context, Model.TrueModelType(), ControllerHelper.ViewType.TableCell);

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

WriteLiteral("<tr>\r\n");

            
            #line 21 "..\..\Views\Shared\Manage\Row.cshtml"
    
            
            #line default
            #line hidden
            
            #line 21 "..\..\Views\Shared\Manage\Row.cshtml"
     if (!InlineEdit &&
                        ViewContext.AllowView(Model.TrueModelType()))
        {

            
            #line default
            #line hidden
WriteLiteral("        <td");

WriteLiteral(" class=\"view-cell center\"");

WriteLiteral(">\r\n            <div>\r\n                <a");

WriteAttribute("href", Tuple.Create(" href=\"", 858), Tuple.Create("\"", 989)
            
            #line 26 "..\..\Views\Shared\Manage\Row.cshtml"
, Tuple.Create(Tuple.Create("", 865), Tuple.Create<System.Object, System.Int32>(Url.Controller<ManageController>().Action(Controller => Controller.Details, Model.GetID<int>(), Request.Url?.AbsoluteUri)
            
            #line default
            #line hidden
, 865), false)
);

WriteLiteral(">\r\n                    <span");

WriteLiteral(" class=\"glyphicon pointer btn btn-default\"");

WriteLiteral(">\r\n                        &#xe003;\r\n                    </span>\r\n               " +
" </a>\r\n            </div>\r\n        </td>\r\n");

            
            #line 33 "..\..\Views\Shared\Manage\Row.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 35 "..\..\Views\Shared\Manage\Row.cshtml"
    
            
            #line default
            #line hidden
            
            #line 35 "..\..\Views\Shared\Manage\Row.cshtml"
     foreach (var Meta in Fields)
        {
        var Field = new ViewField(ViewContext, Model.TrueModelType(), Meta.PropertyName, Model, ViewTypes);

        
            
            #line default
            #line hidden
            
            #line 39 "..\..\Views\Shared\Manage\Row.cshtml"
   Write(Html.ViewField(Field));

            
            #line default
            #line hidden
            
            #line 39 "..\..\Views\Shared\Manage\Row.cshtml"
                              
        }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 42 "..\..\Views\Shared\Manage\Row.cshtml"
    
            
            #line default
            #line hidden
            
            #line 42 "..\..\Views\Shared\Manage\Row.cshtml"
     if (ViewContext.AllowEdit(Model.TrueModelType()))
        {

            
            #line default
            #line hidden
WriteLiteral("        <td");

WriteLiteral(" class=\"edit-cell center\"");

WriteLiteral(">\r\n            <div>\r\n                <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1541), Tuple.Create("\"", 1676)
            
            #line 46 "..\..\Views\Shared\Manage\Row.cshtml"
, Tuple.Create(Tuple.Create("", 1548), Tuple.Create<System.Object, System.Int32>(Url.Controller<ManageController>().Action(Controller => Controller.Edit, Model.GetID<int>(), Request.Url?.AbsoluteUri, false)
            
            #line default
            #line hidden
, 1548), false)
);

WriteLiteral("\r\n                   ");

WriteLiteral(">\r\n                    <span");

WriteLiteral(" class=\"glyphicon pointer btn btn-default\"");

WriteLiteral(">\r\n                        &#xe065;\r\n                    </span>\r\n               " +
" </a>\r\n            </div>\r\n        </td>\r\n");

            
            #line 58 "..\..\Views\Shared\Manage\Row.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 60 "..\..\Views\Shared\Manage\Row.cshtml"
    
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\Shared\Manage\Row.cshtml"
     if (ViewContext.AllowDeactivate(Model.TrueModelType()))
        {

            
            #line default
            #line hidden
WriteLiteral("        <td");

WriteLiteral(" class=\"deactivate-cell center\"");

WriteLiteral(">\r\n            <div>\r\n                <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2568), Tuple.Create("\"", 2698)
            
            #line 64 "..\..\Views\Shared\Manage\Row.cshtml"
, Tuple.Create(Tuple.Create("", 2575), Tuple.Create<System.Object, System.Int32>(Url.Controller<ManageController>().Action(Controller => Controller.Delete, Model.GetID<int>(), Request.Url?.AbsoluteUri)
            
            #line default
            #line hidden
, 2575), false)
);

WriteAttribute("shift-href", Tuple.Create("\r\n                   shift-href=\"", 2699), Tuple.Create("\"", 3154)
            
            #line 65 "..\..\Views\Shared\Manage\Row.cshtml"
, Tuple.Create(Tuple.Create("", 2732), Tuple.Create<System.Object, System.Int32>(Url.Controller<ManageController>()
                   .Action<int,string,FormCollection, bool>(
                   (Expression<Func<ManageController, Func<int,string,FormCollection, bool, ActionResult>>>)(Controller => Controller.DeleteConfirm),
                   Model.GetID<int>(), Request.Url?.AbsoluteUri, null,
                   ViewBag.ManageModel.ViewType.HasFlag(ControllerHelper.ManageViewType.Inactive))
            
            #line default
            #line hidden
, 2732), false)
);

WriteLiteral(">\r\n                    <span");

WriteLiteral(" class=\"glyphicon pointer btn btn-default\"");

WriteLiteral(">\r\n\r\n");

WriteLiteral("                        ");

            
            #line 72 "..\..\Views\Shared\Manage\Row.cshtml"
                   Write(Html.Raw(ViewBag.ManageModel.ViewType.HasFlag(ControllerHelper.ManageViewType.Inactive) ? "&#xe133;" : "&#xe020;"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n                    </span>\r\n                </a>\r\n            </div>\r\n      " +
"  </td>\r\n");

            
            #line 78 "..\..\Views\Shared\Manage\Row.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("</tr>");

        }
    }
}
#pragma warning restore 1591
