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
    
    #line 3 "..\..\Views\Shared\Manage\Fields\Edit\StringMultiLine.cshtml"
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
    using Singularity;
    
    #line 2 "..\..\Views\Shared\Manage\Fields\Edit\StringMultiLine.cshtml"
    using Singularity.Extensions;
    
    #line default
    #line hidden
    using Singularity.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Manage/Fields/Edit/StringMultiLine.cshtml")]
    public partial class _Views_Shared_Manage_Fields_Edit_StringMultiLine_cshtml : System.Web.Mvc.WebViewPage<IViewField>
    {
        public _Views_Shared_Manage_Fields_Edit_StringMultiLine_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("\r\n");

            
            #line 5 "..\..\Views\Shared\Manage\Fields\Edit\StringMultiLine.cshtml"
  
    bool IsSortableList = Model.Meta.HasAttribute<FieldTypeSortableListAttribute>();

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 11 "..\..\Views\Shared\Manage\Fields\Edit\StringMultiLine.cshtml"
 if (IsSortableList)
    {
    string[] Lines;
    var Data = Model.PropertyData as string[];
    if (Data != null)
        {
        Lines = Data;
        }
    else if (Model.PropertyData is string)
        {
        Lines = ((string)Model.PropertyData).Lines();
        }
    else
        {
        Lines = (Model.PropertyData ?? "").ToString().Lines();
        }


            
            #line default
            #line hidden
WriteLiteral("    <select");

WriteLiteral(" class=\"sortable\"");

WriteAttribute("id", Tuple.Create(" id=\"", 615), Tuple.Create("\"", 644)
            
            #line 28 "..\..\Views\Shared\Manage\Fields\Edit\StringMultiLine.cshtml"
, Tuple.Create(Tuple.Create("", 620), Tuple.Create<System.Object, System.Int32>(Model.Meta.PropertyName
            
            #line default
            #line hidden
, 620), false)
);

WriteAttribute("name", Tuple.Create(" name=\"", 645), Tuple.Create("\"", 676)
            
            #line 28 "..\..\Views\Shared\Manage\Fields\Edit\StringMultiLine.cshtml"
, Tuple.Create(Tuple.Create("", 652), Tuple.Create<System.Object, System.Int32>(Model.Meta.PropertyName
            
            #line default
            #line hidden
, 652), false)
);

WriteLiteral(">\r\n");

            
            #line 29 "..\..\Views\Shared\Manage\Fields\Edit\StringMultiLine.cshtml"
        
            
            #line default
            #line hidden
            
            #line 29 "..\..\Views\Shared\Manage\Fields\Edit\StringMultiLine.cshtml"
         foreach (string Line in Lines)
            {

            
            #line default
            #line hidden
WriteLiteral("            <option");

WriteAttribute("value", Tuple.Create(" value=\"", 755), Tuple.Create("\"", 768)
            
            #line 31 "..\..\Views\Shared\Manage\Fields\Edit\StringMultiLine.cshtml"
, Tuple.Create(Tuple.Create("", 763), Tuple.Create<System.Object, System.Int32>(Line
            
            #line default
            #line hidden
, 763), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 32 "..\..\Views\Shared\Manage\Fields\Edit\StringMultiLine.cshtml"
           Write(Line);

            
            #line default
            #line hidden
WriteLiteral("\r\n            </option>\r\n");

            
            #line 34 "..\..\Views\Shared\Manage\Fields\Edit\StringMultiLine.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("    </select>\r\n");

            
            #line 36 "..\..\Views\Shared\Manage\Fields\Edit\StringMultiLine.cshtml"
    }
else
    {

            
            #line default
            #line hidden
WriteLiteral("    <textarea");

WriteAttribute("id", Tuple.Create(" id=\"", 881), Tuple.Create("\"", 910)
            
            #line 39 "..\..\Views\Shared\Manage\Fields\Edit\StringMultiLine.cshtml"
, Tuple.Create(Tuple.Create("", 886), Tuple.Create<System.Object, System.Int32>(Model.Meta.PropertyName
            
            #line default
            #line hidden
, 886), false)
);

WriteAttribute("name", Tuple.Create(" name=\"", 911), Tuple.Create("\"", 942)
            
            #line 39 "..\..\Views\Shared\Manage\Fields\Edit\StringMultiLine.cshtml"
, Tuple.Create(Tuple.Create("", 918), Tuple.Create<System.Object, System.Int32>(Model.Meta.PropertyName
            
            #line default
            #line hidden
, 918), false)
);

WriteLiteral(">");

            
            #line 39 "..\..\Views\Shared\Manage\Fields\Edit\StringMultiLine.cshtml"
                                                                       Write(Model.PropertyData);

            
            #line default
            #line hidden
WriteLiteral("</textarea>\r\n");

            
            #line 40 "..\..\Views\Shared\Manage\Fields\Edit\StringMultiLine.cshtml"
    }

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
