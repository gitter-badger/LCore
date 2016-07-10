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
    
    #line 4 "..\..\Views\Shared\Manage\Edit.cshtml"
    using LCore.Extensions;
    
    #line default
    #line hidden
    using Singularity;
    
    #line 6 "..\..\Views\Shared\Manage\Edit.cshtml"
    using Singularity.Annotations;
    
    #line default
    #line hidden
    using Singularity.Context;
    using Singularity.Controllers;
    
    #line 5 "..\..\Views\Shared\Manage\Edit.cshtml"
    using Singularity.Extensions;
    
    #line default
    #line hidden
    using Singularity.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Manage/Edit.cshtml")]
    public partial class _Views_Shared_Manage_Edit_cshtml : System.Web.Mvc.WebViewPage<IModel>
    {
        public _Views_Shared_Manage_Edit_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n\r\n\r\n");

WriteLiteral("\r\n");

            
            #line 8 "..\..\Views\Shared\Manage\Edit.cshtml"
  
    if (ViewBag.Create == null)
        {
        ViewBag.Create = false;
        }

    var ViewType = ViewBag.Create == true ? ControllerHelper.ViewType.Create : ControllerHelper.ViewType.Edit;

    var Groups = Model as IFieldGroups;
    IEnumerable<ModelMetadata> Fields = Groups != null ? Groups.GetFieldGroup(Context, ViewType) : FieldGroups.GetFieldGroup(Context, Model.TrueModelType(), ViewType);

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

WriteLiteral("<div");

WriteAttribute("class", Tuple.Create(" class=\"", 567), Tuple.Create("\"", 622)
            
            #line 22 "..\..\Views\Shared\Manage\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 575), Tuple.Create<System.Object, System.Int32>(ViewBag.Create ? "create" : "edit"
            
            #line default
            #line hidden
, 575), false)
, Tuple.Create(Tuple.Create(" ", 612), Tuple.Create("wide-form", 613), true)
);

WriteLiteral("\r\n     focus-first=\"input[type=text]\"");

WriteLiteral(">\r\n\r\n    <div");

WriteLiteral(" class=\"view-updating-shade\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"view-updating-icon spin\"");

WriteLiteral(">\r\n            <glyph>&#xe031;</glyph>\r\n        </div>\r\n    </div>\r\n\r\n");

            
            #line 31 "..\..\Views\Shared\Manage\Edit.cshtml"
    
            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\Shared\Manage\Edit.cshtml"
     if (!string.IsNullOrEmpty(ViewBag.ReturnURL))
        {

            
            #line default
            #line hidden
WriteLiteral("        <a");

WriteLiteral(" class=\"btn btn-default right btn-warning\"");

WriteAttribute("href", Tuple.Create(" href=\"", 955), Tuple.Create("\"", 980)
            
            #line 33 "..\..\Views\Shared\Manage\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 962), Tuple.Create<System.Object, System.Int32>(ViewBag.ReturnURL
            
            #line default
            #line hidden
, 962), false)
);

WriteLiteral(">\r\n            <glyph>&#xe091;</glyph>\r\n            Cancel\r\n        </a>\r\n");

            
            #line 37 "..\..\Views\Shared\Manage\Edit.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("\r\n    <h1>\r\n");

WriteLiteral("        ");

            
            #line 40 "..\..\Views\Shared\Manage\Edit.cshtml"
   Write(Html.TextContent($"Manage_{(ViewBag.Create ? "Create" : "Edit")}_Header_{Model.GetFriendlyTypeName()}",
            $"{(ViewBag.Create ? "Create" : "Edit")} {Model.GetFriendlyTypeName()}"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </h1>\r\n\r\n    <h2>\r\n");

WriteLiteral("        ");

            
            #line 45 "..\..\Views\Shared\Manage\Edit.cshtml"
   Write(Html.TextContent($"Manage_{(ViewBag.Create ? "Create" : "Edit")}_ModelHeader_{Model.GetFriendlyTypeName()}", "[0]", new object[] { Model.ToString() }));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </h2>\r\n\r\n");

            
            #line 48 "..\..\Views\Shared\Manage\Edit.cshtml"
    
            
            #line default
            #line hidden
            
            #line 48 "..\..\Views\Shared\Manage\Edit.cshtml"
     using (Html.BeginForm(ViewBag.Create ?
                            nameof(ManageController.Create) :
                            nameof(ManageController.Edit),
                        (string)ViewBag.ControllerName,
                        (object)ViewBag.Route_Edit, FormMethod.Post, new { @class = "edit-form" }))
        {

        bool RequiredFields = false;

        string LastTab = "";

        Dictionary<string, List<ModelMetadata>> TabGroups = Fields.Group(m =>
        {
            if (m.AdditionalValues.ContainsKey(FieldTabAttribute.Key))
                {
                LastTab = (string)m.AdditionalValues[FieldTabAttribute.Key];
                return LastTab;
                }
            return LastTab;
        });

        bool IsTabView = TabGroups.Keys.Count > 1;


            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteAttribute("class", Tuple.Create(" class=\"", 2307), Tuple.Create("\"", 2390)
            
            #line 71 "..\..\Views\Shared\Manage\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 2315), Tuple.Create<System.Object, System.Int32>(ViewBag.Create ? "create" : "edit"
            
            #line default
            #line hidden
, 2315), false)
, Tuple.Create(Tuple.Create("", 2352), Tuple.Create("-fields", 2352), true)
            
            #line 71 "..\..\Views\Shared\Manage\Edit.cshtml"
, Tuple.Create(Tuple.Create(" ", 2359), Tuple.Create<System.Object, System.Int32>(IsTabView ? "tab-view" : ""
            
            #line default
            #line hidden
, 2360), false)
);

WriteLiteral(">\r\n\r\n");

WriteLiteral("            ");

            
            #line 73 "..\..\Views\Shared\Manage\Edit.cshtml"
       Write(Html.ValidationSummary(true));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 75 "..\..\Views\Shared\Manage\Edit.cshtml"
            
            
            #line default
            #line hidden
            
            #line 75 "..\..\Views\Shared\Manage\Edit.cshtml"
             if (IsTabView)
                {

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"tab-container\"");

WriteLiteral(">\r\n                    <ul>\r\n");

            
            #line 79 "..\..\Views\Shared\Manage\Edit.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 79 "..\..\Views\Shared\Manage\Edit.cshtml"
                         for (int Index = 0; Index < TabGroups.Keys.Count; Index++)
                            {
                            string Key = TabGroups.Keys.List()[Index];


            
            #line default
            #line hidden
WriteLiteral("                            <li>\r\n                                <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2818), Tuple.Create("\"", 2842)
, Tuple.Create(Tuple.Create("", 2825), Tuple.Create("#tab-", 2825), true)
            
            #line 84 "..\..\Views\Shared\Manage\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 2830), Tuple.Create<System.Object, System.Int32>(Index + 1
            
            #line default
            #line hidden
, 2830), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 85 "..\..\Views\Shared\Manage\Edit.cshtml"
                               Write(Html.TextContent($"Manage_{(ViewBag.Create ? "Create" : "Edit")}_Tab_{Model.GetFriendlyTypeName()}_{Key}", Key));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </a>\r\n                            </li>\r\n");

            
            #line 88 "..\..\Views\Shared\Manage\Edit.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                    </ul>\r\n\r\n");

            
            #line 91 "..\..\Views\Shared\Manage\Edit.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 91 "..\..\Views\Shared\Manage\Edit.cshtml"
                      
                        int Index2 = 0;
                    
            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 95 "..\..\Views\Shared\Manage\Edit.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 95 "..\..\Views\Shared\Manage\Edit.cshtml"
                     foreach (string Str in TabGroups.Keys)
                        {
                        List<ModelMetadata> TabFields = TabGroups[Str];


            
            #line default
            #line hidden
WriteLiteral("                        <div");

WriteAttribute("id", Tuple.Create(" id=\"", 3410), Tuple.Create("\"", 3432)
, Tuple.Create(Tuple.Create("", 3415), Tuple.Create("tab-", 3415), true)
            
            #line 99 "..\..\Views\Shared\Manage\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 3419), Tuple.Create<System.Object, System.Int32>(Index2 + 1
            
            #line default
            #line hidden
, 3419), false)
);

WriteLiteral(">\r\n\r\n");

            
            #line 101 "..\..\Views\Shared\Manage\Edit.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 101 "..\..\Views\Shared\Manage\Edit.cshtml"
                             foreach (var Meta in TabFields)
                                {
                                var Field = new ViewField(ViewContext, Model.TrueModelType(), Meta.PropertyName, Model, ViewType);

                                if (Meta.IsRequired)
                                    {
                                    RequiredFields = true;
                                    }

                                
            
            #line default
            #line hidden
            
            #line 110 "..\..\Views\Shared\Manage\Edit.cshtml"
                           Write(Html.ViewField(Field));

            
            #line default
            #line hidden
            
            #line 110 "..\..\Views\Shared\Manage\Edit.cshtml"
                                                      
                                }

            
            #line default
            #line hidden
WriteLiteral("                        </div>\r\n");

            
            #line 113 "..\..\Views\Shared\Manage\Edit.cshtml"
                        Index2++;
                        }

            
            #line default
            #line hidden
WriteLiteral("                </div>\r\n");

            
            #line 116 "..\..\Views\Shared\Manage\Edit.cshtml"
                            }
                        else
                            {
                            foreach (var Meta in Fields)
                                {
                                var Field = new ViewField(ViewContext, Model.TrueModelType(), Meta.PropertyName, Model, ViewType);

                                if (Meta.IsRequired)
                                    {
                                    RequiredFields = true;
                                    }

                                
            
            #line default
            #line hidden
            
            #line 128 "..\..\Views\Shared\Manage\Edit.cshtml"
                           Write(Html.ViewField(Field));

            
            #line default
            #line hidden
            
            #line 128 "..\..\Views\Shared\Manage\Edit.cshtml"
                                                      
                                }
                            }

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n        </div>\r\n");

            
            #line 134 "..\..\Views\Shared\Manage\Edit.cshtml"

                        if (ViewBag.Create &&
                            ViewBag.AllowAdminRandomize &&
                            ContextProviderFactory.GetCurrent().CurrentUser(Session).IsAdmin)
                            {

            
            #line default
            #line hidden
WriteLiteral("                            <div");

WriteLiteral(" id=\"randomize-fields\"");

WriteLiteral(" class=\"btn btn-default left\"");

WriteLiteral("\r\n                                 key-bind-click=\"Ctrl+R\"");

WriteLiteral("\r\n                                 key-bind-click-name=\"Randomize\"");

WriteLiteral(">\r\n                                <span");

WriteLiteral(" class=\"glyphicon pointer\"");

WriteLiteral(">\r\n                                    &#xe115;\r\n                                " +
"</span>\r\n                                Randomize\r\n                            " +
"</div>\r\n");

            
            #line 147 "..\..\Views\Shared\Manage\Edit.cshtml"
                            }

                        if (ViewContext.AllowDeactivate(Model.TrueModelType()) && !ViewBag.Create)
                            {

            
            #line default
            #line hidden
WriteLiteral("                            <div");

WriteLiteral(" class=\"left\"");

WriteLiteral(">\r\n                                <a");

WriteAttribute("href", Tuple.Create(" href=\"", 5650), Tuple.Create("\"", 5869)
            
            #line 152 "..\..\Views\Shared\Manage\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 5657), Tuple.Create<System.Object, System.Int32>(Url.Controller<ManageController>()
                    .Action((Expression<Func<ManageController, Func<int, string, ActionResult>>>)(c => c.Delete),
                    Model.GetID<int>(), ViewBag.ReturnURL)
            
            #line default
            #line hidden
, 5657), false)
);

WriteLiteral("\r\n                                   id=\"DeleteButton\"");

WriteLiteral("\r\n                                   key-bind-click=\"Ctrl+Delete\"");

WriteLiteral("\r\n                                   key-bind-click-name=\"Delete\"");

WriteLiteral("\r\n                                   class=\"btn btn-default btn-danger\"");

WriteLiteral(">\r\n                                    <span");

WriteLiteral(" class=\"glyphicon pointer\"");

WriteLiteral(">\r\n                                        &#xe020; Delete\r\n                     " +
"               </span>\r\n                                </a>\r\n                  " +
"          </div>\r\n");

            
            #line 164 "..\..\Views\Shared\Manage\Edit.cshtml"
                            }

                        if (!string.IsNullOrEmpty(ViewBag.ReturnURL))
                            {

            
            #line default
            #line hidden
WriteLiteral("                            <span");

WriteLiteral(" class=\"right\"");

WriteLiteral(">\r\n\r\n                                <a");

WriteLiteral(" class=\"btn btn-default btn-warning\"");

WriteAttribute("href", Tuple.Create("\r\n                                   href=\"", 6631), Tuple.Create("\"", 6692)
            
            #line 171 "..\..\Views\Shared\Manage\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 6674), Tuple.Create<System.Object, System.Int32>(ViewBag.ReturnURL
            
            #line default
            #line hidden
, 6674), false)
);

WriteLiteral("\r\n                                   id=\"CancelButton\"");

WriteLiteral("\r\n                                   key-bind-click=\"Esc\"");

WriteLiteral("\r\n                                   key-bind-click-name=\"Cancel\"");

WriteLiteral(">\r\n                                    <glyph>&#xe091;</glyph>\r\n                 " +
"                   Cancel\r\n                                </a>\r\n");

            
            #line 178 "..\..\Views\Shared\Manage\Edit.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 178 "..\..\Views\Shared\Manage\Edit.cshtml"
                                 if (!ViewBag.Create)
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                    <button");

WriteLiteral(" class=\"btn btn-default btn-success pointer\"");

WriteLiteral("\r\n                                            onclick=\"$(\'form\').submit();\"");

WriteLiteral("\r\n                                            id=\"UpdateButton\"");

WriteLiteral("\r\n                                            name=\"UpdateButton\"");

WriteLiteral("\r\n                                            value=\"Update\"");

WriteLiteral("\r\n                                            key-bind-click=\"Ctrl+U\"");

WriteLiteral("\r\n                                            key-bind-click-name=\"Update\"");

WriteLiteral(">\r\n                                        <glyph>&#xe031;</glyph>\r\n             " +
"                           Update\r\n                                    </button>" +
"\r\n");

            
            #line 190 "..\..\Views\Shared\Manage\Edit.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                <a");

WriteLiteral(" class=\"btn btn-default btn-success pointer\"");

WriteLiteral("\r\n                                   onclick=\"$(\'form\').submit();\"");

WriteLiteral("\r\n                                   id=\"SaveButton\"");

WriteLiteral("\r\n                                   key-bind-click=\"Ctrl+S\"");

WriteLiteral("\r\n                                   key-bind-click-name=\"Save\"");

WriteLiteral(">\r\n                                    <glyph>&#xe173;</glyph>\r\n                 " +
"                   Save\r\n                                </a>\r\n                 " +
"           </span>\r\n");

            
            #line 200 "..\..\Views\Shared\Manage\Edit.cshtml"
                            }

                        if (RequiredFields)
                            {

            
            #line default
            #line hidden
WriteLiteral("                            <div");

WriteLiteral(" class=\"required-fields\"");

WriteLiteral(">\r\n                                * Some fields are required\r\n                  " +
"          </div>\r\n");

            
            #line 207 "..\..\Views\Shared\Manage\Edit.cshtml"
                                }
                            }

            
            #line default
            #line hidden
WriteLiteral("</div>");

        }
    }
}
#pragma warning restore 1591
