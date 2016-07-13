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
    
    #line 3 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
    using Singularity.Annotations;
    
    #line default
    #line hidden
    using Singularity.Context;
    using Singularity.Controllers;
    
    #line 2 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
    using Singularity.Extensions;
    
    #line default
    #line hidden
    using Singularity.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Manage/Fields/Edit/Dropdown.cshtml")]
    public partial class _Views_Shared_Manage_Fields_Edit_Dropdown_cshtml : System.Web.Mvc.WebViewPage<IViewField>
    {
        public _Views_Shared_Manage_Fields_Edit_Dropdown_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("\r\n");

            
            #line 5 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
  
    var FieldAttr = Model.Meta.GetAttribute<FieldTypeDropdown>();

    bool Required = Model.Meta.IsRequired;

    string EmptyValue = FieldAttr.EmptyValue;
    string EmptyKey = FieldAttr.EmptyKey;

    List<SelectListItem> Items = FieldAttr.KeyValues(ViewContext).Select(KeyValue => new SelectListItem
        {
        Text = KeyValue.Key,
        Value = KeyValue.Value,
        Selected = (Model.PropertyData ?? "").ToString() == KeyValue.Value
        }).ToList();

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 23 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
 if (FieldAttr.MultiSelect)
    {

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"option-checks\"");

WriteLiteral(">\r\n\r\n        <input");

WriteAttribute("name", Tuple.Create(" name=\"", 692), Tuple.Create("\"", 723)
            
            #line 27 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
, Tuple.Create(Tuple.Create("", 699), Tuple.Create<System.Object, System.Int32>(Model.Meta.PropertyName
            
            #line default
            #line hidden
, 699), false)
);

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" value=\"\"");

WriteLiteral(" />\r\n\r\n");

            
            #line 29 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
        
            
            #line default
            #line hidden
            
            #line 29 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
         foreach (var Item in Items)
            {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"list-check\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" type=\"checkbox\"");

WriteAttribute("id", Tuple.Create("\r\n                       id=\"", 883), Tuple.Create("\"", 952)
            
            #line 33 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
, Tuple.Create(Tuple.Create("", 912), Tuple.Create<System.Object, System.Int32>(Model.Meta.PropertyName
            
            #line default
            #line hidden
, 912), false)
, Tuple.Create(Tuple.Create("", 938), Tuple.Create("_", 938), true)
            
            #line 33 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
, Tuple.Create(Tuple.Create("", 939), Tuple.Create<System.Object, System.Int32>(Item.Value
            
            #line default
            #line hidden
, 939), false)
);

WriteAttribute("name", Tuple.Create("\r\n                       name=\"", 953), Tuple.Create("\"", 1008)
            
            #line 34 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
, Tuple.Create(Tuple.Create("", 984), Tuple.Create<System.Object, System.Int32>(Model.Meta.PropertyName
            
            #line default
            #line hidden
, 984), false)
);

WriteAttribute("value", Tuple.Create("\r\n                       value=\"", 1009), Tuple.Create("\"", 1052)
            
            #line 35 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
, Tuple.Create(Tuple.Create("", 1041), Tuple.Create<System.Object, System.Int32>(Item.Value
            
            #line default
            #line hidden
, 1041), false)
);

WriteLiteral("\r\n                       ");

            
            #line 36 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
                   Write((Model.PropertyData ?? "").ToString().Contains(Item.Value) ? Html.Raw("checked=\"true\"") : Html.Raw(""));

            
            #line default
            #line hidden
WriteLiteral(">\r\n                <label");

WriteAttribute("for", Tuple.Create(" for=\"", 1210), Tuple.Create("\"", 1256)
            
            #line 37 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
, Tuple.Create(Tuple.Create("", 1216), Tuple.Create<System.Object, System.Int32>(Model.Meta.PropertyName
            
            #line default
            #line hidden
, 1216), false)
, Tuple.Create(Tuple.Create("", 1242), Tuple.Create("_", 1242), true)
            
            #line 37 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
, Tuple.Create(Tuple.Create("", 1243), Tuple.Create<System.Object, System.Int32>(Item.Value
            
            #line default
            #line hidden
, 1243), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 38 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
               Write(Item.Text);

            
            #line default
            #line hidden
WriteLiteral("\r\n                </label>\r\n            </div>\r\n");

            
            #line 41 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n");

            
            #line 43 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
    }
else
    {

            
            #line default
            #line hidden
WriteLiteral("    <select");

WriteAttribute("name", Tuple.Create(" name=\"", 1396), Tuple.Create("\"", 1427)
            
            #line 46 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
, Tuple.Create(Tuple.Create("", 1403), Tuple.Create<System.Object, System.Int32>(Model.Meta.PropertyName
            
            #line default
            #line hidden
, 1403), false)
);

WriteAttribute("id", Tuple.Create(" id=\"", 1428), Tuple.Create("\"", 1457)
            
            #line 46 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
, Tuple.Create(Tuple.Create("", 1433), Tuple.Create<System.Object, System.Int32>(Model.Meta.PropertyName
            
            #line default
            #line hidden
, 1433), false)
);

WriteLiteral(">\r\n");

            
            #line 47 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
        
            
            #line default
            #line hidden
            
            #line 47 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
         if (!Required)
            {

            
            #line default
            #line hidden
WriteLiteral("            <option");

WriteAttribute("value", Tuple.Create(" value=\"", 1520), Tuple.Create("\"", 1539)
            
            #line 49 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
, Tuple.Create(Tuple.Create("", 1528), Tuple.Create<System.Object, System.Int32>(EmptyValue
            
            #line default
            #line hidden
, 1528), false)
);

WriteLiteral(" ");

            
            #line 49 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
                                    Write((string)Model.PropertyData == EmptyValue ? "selected" : "");

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 50 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
           Write(EmptyKey);

            
            #line default
            #line hidden
WriteLiteral("\r\n            </option>\r\n");

            
            #line 52 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"

            }

            
            #line default
            #line hidden
WriteLiteral("        ");

            
            #line 54 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
         foreach (var Item in Items)
            {

            
            #line default
            #line hidden
WriteLiteral("            <option");

WriteAttribute("value", Tuple.Create(" value=\"", 1744), Tuple.Create("\"", 1763)
            
            #line 56 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
, Tuple.Create(Tuple.Create("", 1752), Tuple.Create<System.Object, System.Int32>(Item.Value
            
            #line default
            #line hidden
, 1752), false)
);

WriteLiteral(" ");

            
            #line 56 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
                                    Write(Item.Selected ? "selected" : "");

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 57 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
           Write(Item.Text);

            
            #line default
            #line hidden
WriteLiteral("\r\n            </option>\r\n");

            
            #line 59 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("    </select>\r\n");

            
            #line 61 "..\..\Views\Shared\Manage\Fields\Edit\Dropdown.cshtml"
    }
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591