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
    
    #line 13 "..\..\Views\Template\Fields\Description_After.cshtml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 14 "..\..\Views\Template\Fields\Description_After.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 15 "..\..\Views\Template\Fields\Description_After.cshtml"
    using System.ComponentModel;
    
    #line default
    #line hidden
    
    #line 16 "..\..\Views\Template\Fields\Description_After.cshtml"
    using System.ComponentModel.DataAnnotations;
    
    #line default
    #line hidden
    
    #line 17 "..\..\Views\Template\Fields\Description_After.cshtml"
    using System.ComponentModel.Design;
    
    #line default
    #line hidden
    using System.IO;
    
    #line 11 "..\..\Views\Template\Fields\Description_After.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 12 "..\..\Views\Template\Fields\Description_After.cshtml"
    using System.Linq.Expressions;
    
    #line default
    #line hidden
    using System.Net;
    using System.Text;
    
    #line 18 "..\..\Views\Template\Fields\Description_After.cshtml"
    using System.Web;
    
    #line default
    #line hidden
    using System.Web.Helpers;
    
    #line 19 "..\..\Views\Template\Fields\Description_After.cshtml"
    using System.Web.Mvc;
    
    #line default
    #line hidden
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 3 "..\..\Views\Template\Fields\Description_After.cshtml"
    using LCore;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\Template\Fields\Description_After.cshtml"
    using Singularity;
    
    #line default
    #line hidden
    
    #line 10 "..\..\Views\Template\Fields\Description_After.cshtml"
    using Singularity.Annotations;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Views\Template\Fields\Description_After.cshtml"
    using Singularity.Context;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Views\Template\Fields\Description_After.cshtml"
    using Singularity.Controllers;
    
    #line default
    #line hidden
    
    #line 9 "..\..\Views\Template\Fields\Description_After.cshtml"
    using Singularity.Extensions;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Views\Template\Fields\Description_After.cshtml"
    using Singularity.Models;
    
    #line default
    #line hidden
    
    #line 8 "..\..\Views\Template\Fields\Description_After.cshtml"
    using Singularity.Routes;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Template/Fields/Description_After.cshtml")]
    public partial class _Views_Template_Fields_Description_After_cshtml : System.Web.Mvc.WebViewPage<IViewField>
    {
        public _Views_Template_Fields_Description_After_cshtml()
        {
        }
        public override void Execute()
        {


WriteLiteral("\r\n\r\n");


















WriteLiteral("\r\n");


            
            #line 21 "..\..\Views\Template\Fields\Description_After.cshtml"
  
    Template ModelData = (Template)Model.ModelData;


            
            #line default
            #line hidden
WriteLiteral("\r\n");


WriteLiteral("\r\n<a href=\"");


            
            #line 27 "..\..\Views\Template\Fields\Description_After.cshtml"
     Write(Url.Controller<TemplateController>().Action(c=>c.PreviewPDF, ModelData.TemplateID));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n    <glyph>&#xe175;</glyph>\r\n    View template PDF\r\n</a>");


        }
    }
}
#pragma warning restore 1591
