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
    
    #line 3 "..\..\Views\Shared\Manage\Fields\Edit\IntRange.cshtml"
    using LCore.Extensions;
    
    #line default
    #line hidden
    using Singularity;
    using LMVC.Context;
    using LMVC.Controllers;
    
    #line 2 "..\..\Views\Shared\Manage\Fields\Edit\IntRange.cshtml"
    using Singularity.Extensions;
    
    #line default
    #line hidden
    using Singularity.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Manage/Fields/Edit/IntRange.cshtml")]
    public partial class _Views_Shared_Manage_Fields_Edit_IntRange_cshtml : System.Web.Mvc.WebViewPage<IViewField>
    {
        public _Views_Shared_Manage_Fields_Edit_IntRange_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("\r\n");

            
            #line 5 "..\..\Views\Shared\Manage\Fields\Edit\IntRange.cshtml"
  
    var Attr = Model.Meta.GetAttribute<RangeAttribute>(true);

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

WriteLiteral("<div");

WriteLiteral(" class=\"int-range\"");

WriteAttribute("target", Tuple.Create("\r\n     target=\"", 201), Tuple.Create("\"", 240)
            
            #line 12 "..\..\Views\Shared\Manage\Fields\Edit\IntRange.cshtml"
, Tuple.Create(Tuple.Create("", 216), Tuple.Create<System.Object, System.Int32>(Model.Meta.PropertyName
            
            #line default
            #line hidden
, 216), false)
);

WriteAttribute("text-target", Tuple.Create("\r\n     text-target=\"", 241), Tuple.Create("\"", 292)
            
            #line 13 "..\..\Views\Shared\Manage\Fields\Edit\IntRange.cshtml"
, Tuple.Create(Tuple.Create("", 261), Tuple.Create<System.Object, System.Int32>(Model.Meta.PropertyName
            
            #line default
            #line hidden
, 261), false)
, Tuple.Create(Tuple.Create("", 287), Tuple.Create("_Text", 287), true)
);

WriteAttribute("value", Tuple.Create("\r\n     value=\"", 293), Tuple.Create("\"", 360)
            
            #line 14 "..\..\Views\Shared\Manage\Fields\Edit\IntRange.cshtml"
, Tuple.Create(Tuple.Create("", 307), Tuple.Create<System.Object, System.Int32>(Model.ModelData.GetProperty(Model.Meta.PropertyName)
            
            #line default
            #line hidden
, 307), false)
);

WriteAttribute("maximum", Tuple.Create("\r\n     maximum=\"", 361), Tuple.Create("\"", 390)
            
            #line 15 "..\..\Views\Shared\Manage\Fields\Edit\IntRange.cshtml"
, Tuple.Create(Tuple.Create("", 377), Tuple.Create<System.Object, System.Int32>(Attr.Maximum
            
            #line default
            #line hidden
, 377), false)
);

WriteAttribute("minimum", Tuple.Create("\r\n     minimum=\"", 391), Tuple.Create("\"", 420)
            
            #line 16 "..\..\Views\Shared\Manage\Fields\Edit\IntRange.cshtml"
, Tuple.Create(Tuple.Create("", 407), Tuple.Create<System.Object, System.Int32>(Attr.Minimum
            
            #line default
            #line hidden
, 407), false)
);

WriteLiteral(">\r\n</div>\r\n\r\n<div");

WriteAttribute("id", Tuple.Create(" id=\"", 438), Tuple.Create("\"", 474)
            
            #line 19 "..\..\Views\Shared\Manage\Fields\Edit\IntRange.cshtml"
, Tuple.Create(Tuple.Create("", 443), Tuple.Create<System.Object, System.Int32>(Model.Meta.PropertyName
            
            #line default
            #line hidden
, 443), false)
, Tuple.Create(Tuple.Create("", 469), Tuple.Create("_Text", 469), true)
);

WriteLiteral(" class=\"int-range-display\"");

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 20 "..\..\Views\Shared\Manage\Fields\Edit\IntRange.cshtml"
Write(Model.ModelData.GetProperty(Model.Meta.PropertyName));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n\r\n");

            
            #line 23 "..\..\Views\Shared\Manage\Fields\Edit\IntRange.cshtml"
Write(Html.Hidden(Model.Meta.PropertyName));

            
            #line default
            #line hidden
WriteLiteral(";");

        }
    }
}
#pragma warning restore 1591
