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
    
    #line 7 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
    using System.ComponentModel.DataAnnotations.Schema;
    
    #line default
    #line hidden
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
    
    #line 4 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
    using LCore.Extensions;
    
    #line default
    #line hidden
    using Singularity;
    
    #line 5 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
    using Singularity.Annotations;
    
    #line default
    #line hidden
    using Singularity.Context;
    using Singularity.Controllers;
    
    #line 6 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
    using Singularity.Extensions;
    
    #line default
    #line hidden
    using Singularity.Models;
    
    #line 3 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
    using Singularity.Routes;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Manage/Fields/FieldView.cshtml")]
    public partial class _Views_Shared_Manage_Fields_FieldView_cshtml : System.Web.Mvc.WebViewPage<IViewField>
    {
        public _Views_Shared_Manage_Fields_FieldView_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("\r\n");

WriteLiteral("\r\n");

            
            #line 9 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
  
    bool ShowLabel = Model.ViewTypes.HasAny(ControllerHelper.ViewType.Create, ControllerHelper.ViewType.Edit, ControllerHelper.ViewType.Display);

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

WriteLiteral("\r\n<div");

WriteAttribute("class", Tuple.Create(" class=\"", 437), Tuple.Create("\"", 592)
, Tuple.Create(Tuple.Create("", 445), Tuple.Create("field", 445), true)
            
            #line 16 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
, Tuple.Create(Tuple.Create(" ", 450), Tuple.Create<System.Object, System.Int32>(Model.ViewTypes.CollectStr((i,Type) => $"{Type.ToString().ToLower()}-field ")
            
            #line default
            #line hidden
, 451), false)
, Tuple.Create(Tuple.Create(" ", 529), Tuple.Create("field-", 530), true)
            
            #line 16 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
                        , Tuple.Create(Tuple.Create("", 536), Tuple.Create<System.Object, System.Int32>(Model.ColumnClass
            
            #line default
            #line hidden
, 536), false)
            
            #line 16 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
                                          , Tuple.Create(Tuple.Create(" ", 554), Tuple.Create<System.Object, System.Int32>(Model.ModelFieldClasses.Combine(" ")
            
            #line default
            #line hidden
, 555), false)
);

WriteLiteral("\r\n     ");

            
            #line 17 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
Write(Html.Raw(Model.ModelFieldHtmlAttributes.Combine(" ")));

            
            #line default
            #line hidden
WriteLiteral("\r\n     data-object-type=\"");

            
            #line 18 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
                  Write(Model.Meta.ModelType);

            
            #line default
            #line hidden
WriteLiteral("\"\r\n     data-type-name=\"");

            
            #line 19 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
                Write(Model.Meta.DataTypeName);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n\r\n");

            
            #line 21 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
    
            
            #line default
            #line hidden
            
            #line 21 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
     if (Model.Meta.HasAttribute<ICustomPartial>() &&
                        Model.Meta.GetAttribute<ICustomPartial>().IsActive(Html, Model, Model.ViewTypes))
        {
        Model.Meta.GetAttribute<ICustomPartial>().RenderPartial(Html, Model, Model.ViewTypes);
        }
    else
        {
        if (Model.ViewTypes.Has(ControllerHelper.ViewType.TableCell) &&
            !Model.Meta.HasAttribute<NotMappedAttribute>(true) &&
            (Model.Meta.ModelType.PreferGeneric().HasInterface<IConvertible>() ||
            Model.Meta.ModelType.HasInterface<IModel>()))
            {
            string Data = (Model.PropertyData ?? "").ToString();

            if (Model.PropertyData is DateTime)
                {
                Data = ((DateTime)Model.PropertyData).ToShortDateString();
                }
            Data = Data.RemoveAll(" 12:00:00 AM");

            var Data1 = Model.PropertyData as IModel;
            if (Data1 != null)
                {
                Data = Data1.ToString();
                }

            if (!string.IsNullOrEmpty(Data))
                {

            
            #line default
            #line hidden
WriteLiteral("                <span");

WriteLiteral(" class=\"manage-view-show-similar\"");

WriteLiteral("\r\n                      data-field-name=\"");

            
            #line 50 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
                                  Write(Model.Meta.PropertyName);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral("\r\n                      data-field-value=\"");

            
            #line 51 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
                                   Write(Data);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral("\r\n                      title=\"View Similar\"");

WriteLiteral(">\r\n                    <glyph>&#xe003;</glyph>\r\n                </span>\r\n");

            
            #line 55 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
                }
            }

        if (ShowLabel)
            {
            string Label = Model.Meta.DisplayName ?? Model.Meta.PropertyName.Humanize();

            
            
            #line default
            #line hidden
            
            #line 62 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
       Write(Html.TextContent($"Manage_Edit_Field_Label_{Model.ModelData.GetFriendlyTypeName()}_{Label}",
                Html.Label(Model.Meta.PropertyName, Label)));

            
            #line default
            #line hidden
            
            #line 63 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
                                                           
            }

        if (Model.PropertyData == null)
            {
            
            
            #line default
            #line hidden
            
            #line 68 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
       Write(Html.Partial(PartialViews.Manage.Fields.View.Empty, Model));

            
            #line default
            #line hidden
            
            #line 68 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
                                                                       
            }
        else
            {
            if (Html.ViewExists(PartialViews.Manage.Fields.View.PropertyName(Model.PropertyName)))
                {
                // Override the Edit view for the property.

                
            
            #line default
            #line hidden
            
            #line 76 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
           Write(Html.Partial(PartialViews.Manage.Fields.View.PropertyName(Model.PropertyName)));

            
            #line default
            #line hidden
            
            #line 76 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
                                                                                               
                }
            else if (Model.Meta.AdditionalValues.ContainsKey(FieldStringFormatAttribute.Key) &&
                Model.PropertyData is IFormattable)
                {
                
            
            #line default
            #line hidden
            
            #line 81 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
           Write(Html.Partial(PartialViews.Manage.Fields.View.FormatString, Model));

            
            #line default
            #line hidden
            
            #line 81 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
                                                                                  
                }
            else if (Model.Meta.ModelType == typeof(bool) || Model.Meta.ModelType == typeof(bool?))
                {
                
            
            #line default
            #line hidden
            
            #line 85 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
           Write(Html.Partial(PartialViews.Manage.Fields.View.Boolean, Model));

            
            #line default
            #line hidden
            
            #line 85 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
                                                                             
                }
            else if (Model.Meta.DataTypeName == DataType.Currency.ToString())
                {
                
            
            #line default
            #line hidden
            
            #line 89 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
           Write(Html.Partial(PartialViews.Manage.Fields.View.Currency, Model));

            
            #line default
            #line hidden
            
            #line 89 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
                                                                              
                }
            else if (Model.Meta.ModelType == typeof(int) || Model.Meta.ModelType == typeof(int?))
                {
                
            
            #line default
            #line hidden
            
            #line 93 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
           Write(Html.Partial(PartialViews.Manage.Fields.View.Int, Model));

            
            #line default
            #line hidden
            
            #line 93 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
                                                                         
                }
            else if (Model.Meta.ModelType == typeof(DateTime) || Model.Meta.ModelType == typeof(DateTime?))
                {
                
            
            #line default
            #line hidden
            
            #line 97 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
           Write(Html.Partial(PartialViews.Manage.Fields.View.DateTime, Model));

            
            #line default
            #line hidden
            
            #line 97 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
                                                                              
                }
            else if (Model.ModelData.TrueModelType().HasAttribute<DisplayColumnAttribute>(true) &&
                Model.ModelData.TrueModelType().GetAttribute<DisplayColumnAttribute>(true).DisplayColumn == Model.Meta.PropertyName)
                {
                
            
            #line default
            #line hidden
            
            #line 102 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
           Write(Html.Partial(PartialViews.Manage.Fields.View.DisplayColumn, Model));

            
            #line default
            #line hidden
            
            #line 102 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
                                                                                   
                }
            else if (Model.Meta.ModelType.HasInterface<IModel>())
                {
                
            
            #line default
            #line hidden
            
            #line 106 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
           Write(Html.Partial(PartialViews.Manage.Fields.View.IModel, Model));

            
            #line default
            #line hidden
            
            #line 106 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
                                                                            
                }
            else if (Model.Meta.ModelType.HasInterface<IEnumerable>() &&
                Model.Meta.ModelType.IsGenericType &&
                Model.Meta.ModelType.GetGenericArguments()[0].HasInterface<IModel>())
                {
                
            
            #line default
            #line hidden
            
            #line 112 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
           Write(Html.Partial(PartialViews.Manage.Fields.View.IModelCollection, Model));

            
            #line default
            #line hidden
            
            #line 112 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
                                                                                      
                }
            else if (Model.Meta.ModelType.PreferGeneric().IsEnum)
                {
                
            
            #line default
            #line hidden
            
            #line 116 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
           Write(Html.Partial(PartialViews.Manage.Fields.View.Enum, Model));

            
            #line default
            #line hidden
            
            #line 116 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
                                                                          
                }
            else if (Html.ViewExists(PartialViews.Manage.Fields.View.PropertyType(Model.Meta.ModelType)))
                {
                
            
            #line default
            #line hidden
            
            #line 120 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
           Write(Html.Partial(PartialViews.Manage.Fields.View.PropertyType(Model.Meta.ModelType), Model));

            
            #line default
            #line hidden
            
            #line 120 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
                                                                                                        
                }
            else if (Html.ViewExists(PartialViews.Manage.Fields.View.DataTypeName(Model.Meta.DataTypeName)))
                {
                
            
            #line default
            #line hidden
            
            #line 124 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
           Write(Html.Partial(PartialViews.Manage.Fields.View.DataTypeName(Model.Meta.DataTypeName), Model));

            
            #line default
            #line hidden
            
            #line 124 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
                                                                                                           
                }
            else if (Model.Meta.ModelType == typeof(string))
                {
                
            
            #line default
            #line hidden
            
            #line 128 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
           Write(Html.Partial(PartialViews.Manage.Fields.View.String, Model));

            
            #line default
            #line hidden
            
            #line 128 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
                                                                            
                }
            else if (Model.Meta.ModelType == typeof(string[,]))
                {
                
            
            #line default
            #line hidden
            
            #line 132 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
           Write(Html.Partial(PartialViews.Manage.Fields.View.StringMatrix, Model));

            
            #line default
            #line hidden
            
            #line 132 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
                                                                                  
                }
            else if (Model.Meta.ModelType == typeof(string[][]))
                {
                
            
            #line default
            #line hidden
            
            #line 136 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
           Write(Html.Partial(PartialViews.Manage.Fields.View.StringMultiArray, Model));

            
            #line default
            #line hidden
            
            #line 136 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
                                                                                      
                }
            else
                {
                
            
            #line default
            #line hidden
            
            #line 140 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
           Write(Html.Partial(PartialViews.Manage.Fields.View.Unknown, Model));

            
            #line default
            #line hidden
            
            #line 140 "..\..\Views\Shared\Manage\Fields\FieldView.cshtml"
                                                                             
                }
            }
        }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

        }
    }
}
#pragma warning restore 1591