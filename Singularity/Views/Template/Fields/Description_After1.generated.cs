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
    
    #line 2 "..\..\Views\Template\Fields\Description_After.cshtml"
    using Singularity.Extensions;
    
    #line default
    #line hidden
    using Singularity.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Template/Fields/Description_After.cshtml")]
    public partial class _Views_Template_Fields_Description_After_cshtml : System.Web.Mvc.WebViewPage<IViewField>
    {
        public _Views_Template_Fields_Description_After_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("\r\n");

            
            #line 4 "..\..\Views\Template\Fields\Description_After.cshtml"
  
    var ModelData = (Template)Model.ModelData;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

WriteLiteral("<a");

WriteAttribute("href", Tuple.Create(" href=\"", 140), Tuple.Create("\"", 232)
            
            #line 10 "..\..\Views\Template\Fields\Description_After.cshtml"
, Tuple.Create(Tuple.Create("", 147), Tuple.Create<System.Object, System.Int32>(Url.Controller<TemplateController>().Action(c=>c.PreviewPDF, ModelData.TemplateID)
            
            #line default
            #line hidden
, 147), false)
);

WriteLiteral(">\r\n    <glyph>&#xe175;</glyph>\r\n    View template PDF\r\n</a>");

        }
    }
}
#pragma warning restore 1591
