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
    
    #line 5 "..\..\Views\Shared\Manage\Fields\Edit\IModel.cshtml"
    using LMVC.Routes;
    
    #line default
    #line hidden
    using Singularity;
    
    #line 3 "..\..\Views\Shared\Manage\Fields\Edit\IModel.cshtml"
    using Singularity.Extensions;
    
    #line default
    #line hidden
    using Singularity.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Manage/Fields/Edit/IModel.cshtml")]
    public partial class _Views_Shared_Manage_Fields_Edit_IModel_cshtml : System.Web.Mvc.WebViewPage<IViewField>
    {
        public _Views_Shared_Manage_Fields_Edit_IModel_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n\r\n");

WriteLiteral("\r\n");

WriteLiteral("\r\n");

            
            #line 7 "..\..\Views\Shared\Manage\Fields\Edit\IModel.cshtml"
  
    var SubModel = (IModel)Model.PropertyData;

    List<SelectListItem> Items = Model.GetRelationItems(Model.Meta.ModelType, SubModel);

    if (SubModel != null)
        {
        string Id = SubModel.GetID();

        var Selected = EnumerableExt.First(Items, Item => Item.Value == Id);

        if (Selected != null)
            {
            Selected.Selected = true;
            }
        }

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 27 "..\..\Views\Shared\Manage\Fields\Edit\IModel.cshtml"
Write(Html.DropDownList(Model.Meta.PropertyName, Items, new { @class = "select-list" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591
