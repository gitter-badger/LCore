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
    
    #line 8 "..\..\Views\Shared\Fields\Edit\DateTime.cshtml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 9 "..\..\Views\Shared\Fields\Edit\DateTime.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 10 "..\..\Views\Shared\Fields\Edit\DateTime.cshtml"
    using System.ComponentModel;
    
    #line default
    #line hidden
    
    #line 16 "..\..\Views\Shared\Fields\Edit\DateTime.cshtml"
    using System.ComponentModel.DataAnnotations;
    
    #line default
    #line hidden
    
    #line 17 "..\..\Views\Shared\Fields\Edit\DateTime.cshtml"
    using System.ComponentModel.DataAnnotations.Schema;
    
    #line default
    #line hidden
    
    #line 11 "..\..\Views\Shared\Fields\Edit\DateTime.cshtml"
    using System.ComponentModel.Design;
    
    #line default
    #line hidden
    using System.IO;
    
    #line 14 "..\..\Views\Shared\Fields\Edit\DateTime.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 15 "..\..\Views\Shared\Fields\Edit\DateTime.cshtml"
    using System.Linq.Expressions;
    
    #line default
    #line hidden
    using System.Net;
    using System.Text;
    
    #line 12 "..\..\Views\Shared\Fields\Edit\DateTime.cshtml"
    using System.Web;
    
    #line default
    #line hidden
    using System.Web.Helpers;
    
    #line 13 "..\..\Views\Shared\Fields\Edit\DateTime.cshtml"
    using System.Web.Mvc;
    
    #line default
    #line hidden
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 3 "..\..\Views\Shared\Fields\Edit\DateTime.cshtml"
    using LCore;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\Shared\Fields\Edit\DateTime.cshtml"
    using MVCL;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Views\Shared\Fields\Edit\DateTime.cshtml"
    using MVCL.Context;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Views\Shared\Fields\Edit\DateTime.cshtml"
    using MVCL.Controllers;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Views\Shared\Fields\Edit\DateTime.cshtml"
    using MVCL.Models;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Fields/Edit/DateTime.cshtml")]
    public partial class _Views_Shared_Fields_Edit_DateTime_cshtml : System.Web.Mvc.WebViewPage<IViewField>
    {
        public _Views_Shared_Fields_Edit_DateTime_cshtml()
        {
        }
        public override void Execute()
        {


WriteLiteral("\r\n\r\n");
















WriteLiteral("\r\n");


            
            #line 19 "..\..\Views\Shared\Fields\Edit\DateTime.cshtml"
  
    DateTime? CurrentValue = (Model.ModelData.GetProperty(Model.Meta.PropertyName) as DateTime?);



            
            #line default
            #line hidden
WriteLiteral("\r\n");


WriteLiteral("\r\n\r\n");


            
            #line 27 "..\..\Views\Shared\Fields\Edit\DateTime.cshtml"
 if (CurrentValue == DateTime.MinValue)
    {
    CurrentValue = null;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 32 "..\..\Views\Shared\Fields\Edit\DateTime.cshtml"
 if (Model.Meta.DataTypeName == DataType.Time.ToString())
    {
    
            
            #line default
            #line hidden
            
            #line 34 "..\..\Views\Shared\Fields\Edit\DateTime.cshtml"
Write(Html.TextBox(Model.Meta.PropertyName,
                            CurrentValue == null ? "" : ((DateTime)CurrentValue).ToShortTimeString(),
                            new { @class = "timepicker" }));

            
            #line default
            #line hidden
            
            #line 36 "..\..\Views\Shared\Fields\Edit\DateTime.cshtml"
                                                          
    }

            
            #line default
            #line hidden

            
            #line 38 "..\..\Views\Shared\Fields\Edit\DateTime.cshtml"
 if (Model.Meta.DataTypeName == DataType.Date.ToString())
    {
    
            
            #line default
            #line hidden
            
            #line 40 "..\..\Views\Shared\Fields\Edit\DateTime.cshtml"
Write(Html.TextBox(Model.Meta.PropertyName,
                            CurrentValue == null ? "" : ((DateTime)CurrentValue).ToShortDateString(),
                            new { @class = "datepicker" }));

            
            #line default
            #line hidden
            
            #line 42 "..\..\Views\Shared\Fields\Edit\DateTime.cshtml"
                                                          
    }

            
            #line default
            #line hidden

            
            #line 44 "..\..\Views\Shared\Fields\Edit\DateTime.cshtml"
 if (Model.Meta.DataTypeName == DataType.DateTime.ToString())
    {
    
            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\Shared\Fields\Edit\DateTime.cshtml"
Write(Html.TextBox(Model.Meta.PropertyName,
                            CurrentValue,
                            new { @class = "datepicker" }));

            
            #line default
            #line hidden
            
            #line 48 "..\..\Views\Shared\Fields\Edit\DateTime.cshtml"
                                                          
    }
            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
