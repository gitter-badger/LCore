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
    
    #line 7 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
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
    
    #line 4 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
    using LCore.Extensions;
    
    #line default
    #line hidden
    using Singularity;
    
    #line 6 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
    using Singularity.Annotations;
    
    #line default
    #line hidden
    using Singularity.Context;
    using Singularity.Controllers;
    
    #line 5 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
    using Singularity.Extensions;
    
    #line default
    #line hidden
    using Singularity.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Manage_HeaderRow.cshtml")]
    public partial class _Views_Shared_Manage_HeaderRow_cshtml : System.Web.Mvc.WebViewPage<ManageViewModel>
    {
        public _Views_Shared_Manage_HeaderRow_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n\r\n\r\n");

WriteLiteral("\r\n");

WriteLiteral("\r\n");

            
            #line 12 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
  
    IEnumerable<ModelMetadata> Fields = Model.ModelType.HasInterface<IFieldGroups>() ? (Model.ModelType.New() as IFieldGroups)?.GetFieldGroup(Context, ControllerHelper.ViewType.TableCell) : FieldGroups.GetFieldGroup(Context, Model.ModelType, ControllerHelper.ViewType.TableCell).ToList();

    // ReSharper disable PossibleNullReferenceException

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<thead>\r\n    <tr>\r\n");

            
            #line 20 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
        
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
         if (ViewContext.AllowView(Model.ModelType))
            {

            
            #line default
            #line hidden
WriteLiteral("            <td");

WriteLiteral(" class=\"view-cell center\"");

WriteLiteral(">\r\n                <div>\r\n");

WriteLiteral("                    ");

            
            #line 24 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
               Write(Html.TextContent($"Manage_ColumnHeader_{Model.ModelType.GetFriendlyTypeName()}_View", "View"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </td>\r\n");

            
            #line 27 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 29 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
        
            
            #line default
            #line hidden
            
            #line 29 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
         foreach (ModelMetadata Meta in Fields)
            {
            string ColumnTitle = Meta.DisplayName ?? Meta.PropertyName.Humanize();
            string ColumnClass = Meta.PropertyName.ToUrlSlug();


            
            #line default
            #line hidden
WriteLiteral("            <td");

WriteAttribute("class", Tuple.Create(" class=\"", 1123), Tuple.Create("\"", 1207)
            
            #line 34 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
, Tuple.Create(Tuple.Create("", 1131), Tuple.Create<System.Object, System.Int32>(Model.OverrideSort == Meta.PropertyName ? "sort-column" : ""
            
            #line default
            #line hidden
, 1131), false)
            
            #line 34 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
      , Tuple.Create(Tuple.Create(" ", 1194), Tuple.Create<System.Object, System.Int32>(ColumnClass
            
            #line default
            #line hidden
, 1195), false)
);

WriteLiteral(">\r\n                ");

WriteLiteral("\r\n");

            
            #line 44 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
                
            
            #line default
            #line hidden
            
            #line 44 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
                 if (Meta.HasAttribute<NotMappedAttribute>())
                    {
                    // No DB column: no sorting

                    
            
            #line default
            #line hidden
            
            #line 48 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
               Write(Html.TextContent($"Manage_ColumnHeader_{Model.ModelType.GetFriendlyTypeName()}_{ColumnTitle}", ColumnTitle));

            
            #line default
            #line hidden
            
            #line 48 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
                                                                                                                                
                    }
                else if (Meta.PropertyName.Contains("."))
                    {
                    foreach (string s in Meta.PropertyName.Split("."))
                        {
                        
            
            #line default
            #line hidden
            
            #line 54 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
                   Write(s.Humanize());

            
            #line default
            #line hidden
            
            #line 54 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
                                     
                        
            
            #line default
            #line hidden
            
            #line 55 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
                    Write(new HtmlString("&nbsp;"));

            
            #line default
            #line hidden
            
            #line 55 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
                                                   
                        }
                    }
                else
                    {

            
            #line default
            #line hidden
WriteLiteral("                    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2263), Tuple.Create("\"", 2564)
            
            #line 60 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
, Tuple.Create(Tuple.Create("", 2270), Tuple.Create<System.Object, System.Int32>(Url.Controller<ManageController>()
                        .QS(Singularity.Routes.Controllers.Manage.Actions.Route_SortColumn(Model, Meta.PropertyName))
                        .Lambda<int,string,SortDirection,string ,string , ControllerHelper.ManageViewType , string , bool>(c=> c.Manage)
            
            #line default
            #line hidden
, 2270), false)
);

WriteLiteral(">\r\n\r\n");

WriteLiteral("                        ");

            
            #line 64 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
                   Write(Html.TextContent($"Manage_ColumnHeader_{Model.ModelType.GetFriendlyTypeName()}_{ColumnTitle}", ColumnTitle));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 66 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 66 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
                         if (Model.OverrideSort == Meta.PropertyName)
                        {
                        if (Model.OverrideSortDirection == SortDirection.Ascending)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <span");

WriteLiteral(" class=\"glyphicons glyphicons-up-arrow\"");

WriteLiteral(">&#xe093;</span>\r\n");

            
            #line 71 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
                                }
                            else
                                {

            
            #line default
            #line hidden
WriteLiteral("                                <span");

WriteLiteral(" class=\"glyphicons glyphicons-down-arrow\"");

WriteLiteral(">&#xe094;</span>\r\n");

            
            #line 75 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
                                }
                            }

            
            #line default
            #line hidden
WriteLiteral("                    </a>\r\n");

            
            #line 78 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("            </td>\r\n");

            
            #line 80 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 82 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
        
            
            #line default
            #line hidden
            
            #line 82 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
         if (ViewContext.AllowEdit(Model.ModelType))
            {

            
            #line default
            #line hidden
WriteLiteral("            <td");

WriteLiteral(" class=\"edit-cell\"");

WriteLiteral(">\r\n                <div>\r\n");

WriteLiteral("                    ");

            
            #line 86 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
               Write(Html.TextContent($"Manage_ColumnHeader_{Model.ModelType.GetFriendlyTypeName()}_Edit", "Edit"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </td>\r\n");

            
            #line 89 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 91 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
        
            
            #line default
            #line hidden
            
            #line 91 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
         if (ViewContext.AllowDeactivate(Model.ModelType))
            {

            
            #line default
            #line hidden
WriteLiteral("            <td");

WriteLiteral(" class=\"deactivate-cell\"");

WriteLiteral(">\r\n                <div>\r\n");

            
            #line 95 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 95 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
                      
                        string DeleteResotreStr = Model.ViewType.HasFlag(ControllerHelper.ManageViewType.Inactive) ? "Restore" : "Delete";
                    
            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

WriteLiteral("                    ");

            
            #line 99 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
               Write(Html.TextContent($"Manage_ColumnHeader_{Model.ModelType.GetFriendlyTypeName()}_{DeleteResotreStr}", DeleteResotreStr));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </td>\r\n");

            
            #line 102 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("    </tr>\r\n</thead>\r\n\r\n");

            
            #line 106 "..\..\Views\Shared\Manage_HeaderRow.cshtml"
  
    // ReSharper restore PossibleNullReferenceException

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
