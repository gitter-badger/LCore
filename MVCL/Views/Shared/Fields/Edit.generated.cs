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
    
    #line 8 "..\..\Views\Shared\Fields\Edit.cshtml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 9 "..\..\Views\Shared\Fields\Edit.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 10 "..\..\Views\Shared\Fields\Edit.cshtml"
    using System.ComponentModel;
    
    #line default
    #line hidden
    
    #line 16 "..\..\Views\Shared\Fields\Edit.cshtml"
    using System.ComponentModel.DataAnnotations;
    
    #line default
    #line hidden
    
    #line 17 "..\..\Views\Shared\Fields\Edit.cshtml"
    using System.ComponentModel.DataAnnotations.Schema;
    
    #line default
    #line hidden
    
    #line 11 "..\..\Views\Shared\Fields\Edit.cshtml"
    using System.ComponentModel.Design;
    
    #line default
    #line hidden
    using System.IO;
    
    #line 14 "..\..\Views\Shared\Fields\Edit.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 15 "..\..\Views\Shared\Fields\Edit.cshtml"
    using System.Linq.Expressions;
    
    #line default
    #line hidden
    using System.Net;
    using System.Text;
    
    #line 12 "..\..\Views\Shared\Fields\Edit.cshtml"
    using System.Web;
    
    #line default
    #line hidden
    using System.Web.Helpers;
    
    #line 13 "..\..\Views\Shared\Fields\Edit.cshtml"
    using System.Web.Mvc;
    
    #line default
    #line hidden
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 3 "..\..\Views\Shared\Fields\Edit.cshtml"
    using LCore;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\Shared\Fields\Edit.cshtml"
    using MVCL;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Views\Shared\Fields\Edit.cshtml"
    using MVCL.Context;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Views\Shared\Fields\Edit.cshtml"
    using MVCL.Controllers;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Views\Shared\Fields\Edit.cshtml"
    using MVCL.Models;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Fields/Edit.cshtml")]
    public partial class _Views_Shared_Fields_Edit_cshtml : System.Web.Mvc.WebViewPage<IViewField>
    {
        public _Views_Shared_Fields_Edit_cshtml()
        {
        }
        public override void Execute()
        {


WriteLiteral("\r\n\r\n");
















WriteLiteral("\r\n");


            
            #line 19 "..\..\Views\Shared\Fields\Edit.cshtml"
  
    System.Web.ModelBinding.ModelMetadata Meta = Model.Meta;

    LambdaExpression Lambda = null;

    Object ValueData = null;

    Boolean ShowLabel = Model.ViewTypes.HasAny(new[] {ControllerHelper.ViewType.Create,
        ControllerHelper.ViewType.Edit,
        ControllerHelper.ViewType.Display});

    if (Model.PropertyName.Contains("."))
        {
        String[] FullProperties = null;

        Lambda = Model.ModelData.TrueModelType().FindSubProperty(out Meta, out FullProperties, Model.PropertyName.Split("."));
        }
    else
        {
        Meta = Model.ModelData.TrueModelType().Meta(Model.PropertyName);
        }

    if (Lambda == null)
        {
        ValueData = Model.ModelData.GetProperty(Meta.PropertyName);
        }
    else
        {
        Delegate d = Lambda.Compile();
        ValueData = d.DynamicInvoke(Model);
        }

    RangeAttribute Attr = null;

    if (Model.Meta.HasAttribute<RangeAttribute>())
        {
        Attr = Model.Meta.GetAttribute<RangeAttribute>();
        }


            
            #line default
            #line hidden
WriteLiteral("\r\n");


WriteLiteral("\r\n\r\n");


            
            #line 62 "..\..\Views\Shared\Fields\Edit.cshtml"
 if (Model.Meta.PropertyName == ControllerHelper.AutomaticFields.Active)
    {
    return;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n<div class=\"field ");


            
            #line 67 "..\..\Views\Shared\Fields\Edit.cshtml"
             Write(Model.ViewTypes.CollectStr((i,t) => { return t.ToString().ToLower() + "-field "; }));

            
            #line default
            #line hidden
WriteLiteral(" field-");


            
            #line 67 "..\..\Views\Shared\Fields\Edit.cshtml"
                                                                                                        Write(Model.ColumnClass);

            
            #line default
            #line hidden
WriteLiteral("\"\r\n     data-object-type=\"");


            
            #line 68 "..\..\Views\Shared\Fields\Edit.cshtml"
                  Write(Meta.ModelType);

            
            #line default
            #line hidden
WriteLiteral("\"\r\n     data-type-name=\"");


            
            #line 69 "..\..\Views\Shared\Fields\Edit.cshtml"
                Write(Meta.DataTypeName);

            
            #line default
            #line hidden
WriteLiteral("\"\r\n     maximum=\"");


            
            #line 70 "..\..\Views\Shared\Fields\Edit.cshtml"
          Write(Attr != null ? Attr.Maximum : null);

            
            #line default
            #line hidden
WriteLiteral("\"\r\n     minimum=\"");


            
            #line 71 "..\..\Views\Shared\Fields\Edit.cshtml"
          Write(Attr != null ? Attr.Minimum : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n\r\n");


            
            #line 73 "..\..\Views\Shared\Fields\Edit.cshtml"
     if (Model.Meta.HasAttribute<HiddenInputAttribute>())
        {
        
            
            #line default
            #line hidden
            
            #line 75 "..\..\Views\Shared\Fields\Edit.cshtml"
   Write(Html.Partial(ControllerHelper.PartialViews.Field_Edit_Hidden, Model));

            
            #line default
            #line hidden
            
            #line 75 "..\..\Views\Shared\Fields\Edit.cshtml"
                                                                             
        }
    else
        {
        
            
            #line default
            #line hidden
            
            #line 79 "..\..\Views\Shared\Fields\Edit.cshtml"
   Write(Html.ValidationMessage(Model.Meta.PropertyName));

            
            #line default
            #line hidden
            
            #line 79 "..\..\Views\Shared\Fields\Edit.cshtml"
                                                        

        if (ShowLabel)
            {
            
            
            #line default
            #line hidden
            
            #line 83 "..\..\Views\Shared\Fields\Edit.cshtml"
       Write(Html.Label(Model.Meta.PropertyName, Model.Meta.DisplayName ?? Model.Meta.PropertyName.Humanize()));

            
            #line default
            #line hidden
            
            #line 83 "..\..\Views\Shared\Fields\Edit.cshtml"
                                                                                                              
            }

        if (Model.Meta.IsRequired)
            {

            
            #line default
            #line hidden
WriteLiteral("            <span class=\"required-mark\">*</span>\r\n");


            
            #line 89 "..\..\Views\Shared\Fields\Edit.cshtml"
            }

        if (Meta.HasAttribute<ICustomPartial>() &&
            Meta.GetAttribute<ICustomPartial>().IsActive(Html, Model, Model.ViewTypes))
            {
            Meta.GetAttribute<ICustomPartial>().RenderPartial(Html, Model, Model.ViewTypes);
            }
        else if (Html.ViewExists(ControllerHelper.PartialViews.Field_Edit_PropertyName(Model.PropertyName)))
            {
            // Override the Edit view for the property.

            
            
            #line default
            #line hidden
            
            #line 100 "..\..\Views\Shared\Fields\Edit.cshtml"
       Write(Html.Partial(ControllerHelper.PartialViews.Field_Edit_PropertyName(Model.PropertyName), Model));

            
            #line default
            #line hidden
            
            #line 100 "..\..\Views\Shared\Fields\Edit.cshtml"
                                                                                                           ;
            }
        else if (Model.Meta.HasAttribute<KeyAttribute>())
            {
            
            
            #line default
            #line hidden
            
            #line 104 "..\..\Views\Shared\Fields\Edit.cshtml"
       Write(Html.Partial(ControllerHelper.PartialViews.Field_Edit_Key, Model));

            
            #line default
            #line hidden
            
            #line 104 "..\..\Views\Shared\Fields\Edit.cshtml"
                                                                              
            }
        else if (Model.Meta.ModelType == typeof(Boolean) ||
            Model.Meta.ModelType == typeof(Boolean?))
            {
            
            
            #line default
            #line hidden
            
            #line 109 "..\..\Views\Shared\Fields\Edit.cshtml"
       Write(Html.Partial(ControllerHelper.PartialViews.Field_Edit_Boolean, Model));

            
            #line default
            #line hidden
            
            #line 109 "..\..\Views\Shared\Fields\Edit.cshtml"
                                                                                  
            }
        else if (Model.Meta.DataTypeName == DataType.Currency.ToString())
            {
            
            
            #line default
            #line hidden
            
            #line 113 "..\..\Views\Shared\Fields\Edit.cshtml"
       Write(Html.Partial(ControllerHelper.PartialViews.Field_Edit_Currency, Model));

            
            #line default
            #line hidden
            
            #line 113 "..\..\Views\Shared\Fields\Edit.cshtml"
                                                                                   
            }
        else if (Model.Meta.ModelType == typeof(int) ||
            Model.Meta.ModelType == typeof(int?))
            {
            if (Attr != null && (int)Attr.Maximum != int.MaxValue &&
                (int)Attr.Minimum != int.MinValue)
                {
                
            
            #line default
            #line hidden
            
            #line 121 "..\..\Views\Shared\Fields\Edit.cshtml"
           Write(Html.Partial(ControllerHelper.PartialViews.Field_Edit_IntRange, Model));

            
            #line default
            #line hidden
            
            #line 121 "..\..\Views\Shared\Fields\Edit.cshtml"
                                                                                       
                }
            else
                {
                
            
            #line default
            #line hidden
            
            #line 125 "..\..\Views\Shared\Fields\Edit.cshtml"
           Write(Html.Partial(ControllerHelper.PartialViews.Field_Edit_Int, Model));

            
            #line default
            #line hidden
            
            #line 125 "..\..\Views\Shared\Fields\Edit.cshtml"
                                                                                  
                }
            }
        else if (Model.Meta.ModelType == typeof(long) ||
            Model.Meta.ModelType == typeof(long?))
            {
            
            
            #line default
            #line hidden
            
            #line 131 "..\..\Views\Shared\Fields\Edit.cshtml"
       Write(Html.Partial(ControllerHelper.PartialViews.Field_Edit_Long, Model));

            
            #line default
            #line hidden
            
            #line 131 "..\..\Views\Shared\Fields\Edit.cshtml"
                                                                               
            }
        else if (Model.Meta.ModelType == typeof(double) ||
            Model.Meta.ModelType == typeof(double?) ||
            Model.Meta.ModelType == typeof(float) ||
            Model.Meta.ModelType == typeof(float?) ||
            Model.Meta.ModelType == typeof(decimal) ||
            Model.Meta.ModelType == typeof(decimal?))
            {
            
            
            #line default
            #line hidden
            
            #line 140 "..\..\Views\Shared\Fields\Edit.cshtml"
       Write(Html.Partial(ControllerHelper.PartialViews.Field_Edit_Decimal, Model));

            
            #line default
            #line hidden
            
            #line 140 "..\..\Views\Shared\Fields\Edit.cshtml"
                                                                                  
            }
        else if (Model.Meta.ModelType == typeof(DateTime) ||
            Model.Meta.ModelType == typeof(DateTime?))
            {
            
            
            #line default
            #line hidden
            
            #line 145 "..\..\Views\Shared\Fields\Edit.cshtml"
       Write(Html.Partial(ControllerHelper.PartialViews.Field_Edit_DateTime, Model));

            
            #line default
            #line hidden
            
            #line 145 "..\..\Views\Shared\Fields\Edit.cshtml"
                                                                                   
            }
        else if (Model.Meta.ModelType.PreferGeneric().IsEnum)
            {
            
            
            #line default
            #line hidden
            
            #line 149 "..\..\Views\Shared\Fields\Edit.cshtml"
       Write(Html.Partial(ControllerHelper.PartialViews.Field_Edit_Enum, Model));

            
            #line default
            #line hidden
            
            #line 149 "..\..\Views\Shared\Fields\Edit.cshtml"
                                                                               
            }
        else if (Model.Meta.ModelType.MemberHasAttribute<ComplexTypeAttribute>(true))
            {
            
            
            #line default
            #line hidden
            
            #line 153 "..\..\Views\Shared\Fields\Edit.cshtml"
       Write(Html.Partial(ControllerHelper.PartialViews.Field_Edit_ComplexType, Model));

            
            #line default
            #line hidden
            
            #line 153 "..\..\Views\Shared\Fields\Edit.cshtml"
                                                                                      
            }
        else if (Model.Meta.ModelType.HasInterface(typeof(IModel), true))
            {
            
            
            #line default
            #line hidden
            
            #line 157 "..\..\Views\Shared\Fields\Edit.cshtml"
       Write(Html.Partial(ControllerHelper.PartialViews.Field_Edit_IModel, Model));

            
            #line default
            #line hidden
            
            #line 157 "..\..\Views\Shared\Fields\Edit.cshtml"
                                                                                 
            }
        else if (Model.Meta.ModelType == typeof(String))
            {
            if (Model.Meta.DataTypeName == DataType.MultilineText.ToString())
                {
                
            
            #line default
            #line hidden
            
            #line 163 "..\..\Views\Shared\Fields\Edit.cshtml"
           Write(Html.Partial(ControllerHelper.PartialViews.Field_Edit_StringMultiLine, Model));

            
            #line default
            #line hidden
            
            #line 163 "..\..\Views\Shared\Fields\Edit.cshtml"
                                                                                              
                }
            else
                {
                
            
            #line default
            #line hidden
            
            #line 167 "..\..\Views\Shared\Fields\Edit.cshtml"
           Write(Html.Partial(ControllerHelper.PartialViews.Field_Edit_String, Model));

            
            #line default
            #line hidden
            
            #line 167 "..\..\Views\Shared\Fields\Edit.cshtml"
                                                                                     
                }
            }
        else if (Html.ViewExists(ControllerHelper.PartialViews.Field_Edit_PropertyType(Model.Meta.ModelType)))
            {
            
            
            #line default
            #line hidden
            
            #line 172 "..\..\Views\Shared\Fields\Edit.cshtml"
       Write(Html.Partial(ControllerHelper.PartialViews.Field_Edit_PropertyType(Model.Meta.ModelType), Model));

            
            #line default
            #line hidden
            
            #line 172 "..\..\Views\Shared\Fields\Edit.cshtml"
                                                                                                             
            }
        else if (Html.ViewExists(ControllerHelper.PartialViews.Field_Edit_DataTypeName(Model.Meta.DataTypeName)))
            {
            
            
            #line default
            #line hidden
            
            #line 176 "..\..\Views\Shared\Fields\Edit.cshtml"
       Write(Html.Partial(ControllerHelper.PartialViews.Field_Edit_DataTypeName(Model.Meta.DataTypeName), Model));

            
            #line default
            #line hidden
            
            #line 176 "..\..\Views\Shared\Fields\Edit.cshtml"
                                                                                                                
            }
        else
            {
            
            
            #line default
            #line hidden
            
            #line 180 "..\..\Views\Shared\Fields\Edit.cshtml"
       Write(Html.Partial(ControllerHelper.PartialViews.Field_Edit_Unknown, Model));

            
            #line default
            #line hidden
            
            #line 180 "..\..\Views\Shared\Fields\Edit.cshtml"
                                                                                  
            }
        }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");


        }
    }
}
#pragma warning restore 1591
