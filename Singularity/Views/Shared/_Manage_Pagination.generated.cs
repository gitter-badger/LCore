﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    
    #line 10 "..\..\Views\Shared\_Manage_Pagination.cshtml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 11 "..\..\Views\Shared\_Manage_Pagination.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 12 "..\..\Views\Shared\_Manage_Pagination.cshtml"
    using System.ComponentModel;
    
    #line default
    #line hidden
    
    #line 13 "..\..\Views\Shared\_Manage_Pagination.cshtml"
    using System.ComponentModel.DataAnnotations;
    
    #line default
    #line hidden
    
    #line 14 "..\..\Views\Shared\_Manage_Pagination.cshtml"
    using System.ComponentModel.DataAnnotations.Schema;
    
    #line default
    #line hidden
    
    #line 15 "..\..\Views\Shared\_Manage_Pagination.cshtml"
    using System.ComponentModel.Design;
    
    #line default
    #line hidden
    using System.IO;
    
    #line 8 "..\..\Views\Shared\_Manage_Pagination.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 9 "..\..\Views\Shared\_Manage_Pagination.cshtml"
    using System.Linq.Expressions;
    
    #line default
    #line hidden
    using System.Net;
    using System.Text;
    
    #line 16 "..\..\Views\Shared\_Manage_Pagination.cshtml"
    using System.Web;
    
    #line default
    #line hidden
    using System.Web.Helpers;
    
    #line 17 "..\..\Views\Shared\_Manage_Pagination.cshtml"
    using System.Web.Mvc;
    
    #line default
    #line hidden
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 3 "..\..\Views\Shared\_Manage_Pagination.cshtml"
    using LCore;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\Shared\_Manage_Pagination.cshtml"
    using Singularity;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Views\Shared\_Manage_Pagination.cshtml"
    using Singularity.Controllers;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Views\Shared\_Manage_Pagination.cshtml"
    using Singularity.Models;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Views\Shared\_Manage_Pagination.cshtml"
    using Singularity.Routes;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/_Manage_Pagination.cshtml")]
    public partial class _Views_Shared__Manage_Pagination_cshtml : System.Web.Mvc.WebViewPage<ManageViewModel>
    {
        public _Views_Shared__Manage_Pagination_cshtml()
        {
        }
        public override void Execute()
        {


WriteLiteral("\r\n\r\n");
















WriteLiteral("\r\n");


WriteLiteral("\r\n");


            
            #line 21 "..\..\Views\Shared\_Manage_Pagination.cshtml"
  
    ViewBag.PaginationCount = (ViewBag.PaginationCount == null ? 0 : (int)ViewBag.PaginationCount) + 1;

    String ShowingStart = ((Model.Page * Model.Controller.RowsPerPage) + 1).ToString("N0");
    String ShowingEnd = (((Model.Page * Model.Controller.RowsPerPage) + Model.Models.Count).ToString("N0"));
    String ShowingTotal = Model.TotalItems.ToString("N0");


            
            #line default
            #line hidden
WriteLiteral("\r\n<div class=\"manage-pagination\">\r\n");


            
            #line 30 "..\..\Views\Shared\_Manage_Pagination.cshtml"
     if (Model.TotalItems > 0)
        {

            
            #line default
            #line hidden
WriteLiteral("        <div class=\"pagination-visible-items\">\r\n            ");


            
            #line 33 "..\..\Views\Shared\_Manage_Pagination.cshtml"
       Write(Html.Partial(PartialViews.TextContent, new TextContentViewModel("Manage_Pagination_Results_" + Model.FriendlyModelTypeName, "Showing results [0] - [1] of [2]", new Object[] { ShowingStart, ShowingEnd, ShowingTotal })));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n");


            
            #line 35 "..\..\Views\Shared\_Manage_Pagination.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 37 "..\..\Views\Shared\_Manage_Pagination.cshtml"
     if (Model.Page != 0)
        {

            
            #line default
            #line hidden
WriteLiteral("        <a href=\"");


            
            #line 39 "..\..\Views\Shared\_Manage_Pagination.cshtml"
            Write(Url.Action(Model.Controller.ManageActionName, Model.Controller.Name, Model.Route_Page(1)));

            
            #line default
            #line hidden
WriteLiteral("\"\r\n           key-bind-click=\"");


            
            #line 40 "..\..\Views\Shared\_Manage_Pagination.cshtml"
                       Write(ViewBag.PaginationCount == 1 ? "Ctrl+Home" : null);

            
            #line default
            #line hidden
WriteLiteral("\"\r\n           key-bind-click-name=\"");


            
            #line 41 "..\..\Views\Shared\_Manage_Pagination.cshtml"
                            Write(ViewBag.PaginationCount == 1 ? "First Page" : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n            <span class=\"page-previous\">\r\n                ");


            
            #line 43 "..\..\Views\Shared\_Manage_Pagination.cshtml"
           Write(Model.FirstPageText);

            
            #line default
            #line hidden
WriteLiteral("\r\n            </span>\r\n        </a>\r\n");


            
            #line 46 "..\..\Views\Shared\_Manage_Pagination.cshtml"


            
            #line default
            #line hidden
WriteLiteral("        <a href=\"");


            
            #line 47 "..\..\Views\Shared\_Manage_Pagination.cshtml"
            Write(Url.Action(Model.Controller.ManageActionName, Model.Controller.Name, Model.Route_Page(Model.Page)));

            
            #line default
            #line hidden
WriteLiteral("\"\r\n           key-bind-click=\"");


            
            #line 48 "..\..\Views\Shared\_Manage_Pagination.cshtml"
                       Write(ViewBag.PaginationCount == 1 ? "Ctrl+Left" : null);

            
            #line default
            #line hidden
WriteLiteral("\"\r\n           key-bind-click-name=\"");


            
            #line 49 "..\..\Views\Shared\_Manage_Pagination.cshtml"
                            Write(ViewBag.PaginationCount == 1 ? "Previous Page" : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n            <span class=\"page-previous\">\r\n                ");


            
            #line 51 "..\..\Views\Shared\_Manage_Pagination.cshtml"
           Write(Model.PreviousPageText);

            
            #line default
            #line hidden
WriteLiteral("\r\n            </span>\r\n        </a>\r\n");


            
            #line 54 "..\..\Views\Shared\_Manage_Pagination.cshtml"
        }
    else if (Model.AlwaysShowPaginationFirstLast)
        {

            
            #line default
            #line hidden
WriteLiteral("        <span class=\"page-previous\">\r\n            ");


            
            #line 58 "..\..\Views\Shared\_Manage_Pagination.cshtml"
       Write(Model.FirstPageText);

            
            #line default
            #line hidden
WriteLiteral("\r\n        </span>\r\n");


            
            #line 60 "..\..\Views\Shared\_Manage_Pagination.cshtml"


            
            #line default
            #line hidden
WriteLiteral("        <span class=\"page-previous\">\r\n            ");


            
            #line 62 "..\..\Views\Shared\_Manage_Pagination.cshtml"
       Write(Model.PreviousPageText);

            
            #line default
            #line hidden
WriteLiteral("\r\n        </span>\r\n");


            
            #line 64 "..\..\Views\Shared\_Manage_Pagination.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("\r\n    <span class=\"page-numbers\">\r\n");


            
            #line 67 "..\..\Views\Shared\_Manage_Pagination.cshtml"
         if (Model.TotalItems > 0)
            {
            for (int i = 0; i < Model.TotalPages; i++)
                {
                if (i == Model.Page)
                    {

            
            #line default
            #line hidden
WriteLiteral("                    <span class=\"page-current\">\r\n                        ");


            
            #line 74 "..\..\Views\Shared\_Manage_Pagination.cshtml"
                    Write(i + 1);

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </span>\r\n");


            
            #line 76 "..\..\Views\Shared\_Manage_Pagination.cshtml"
                    }
                else if (i >= Model.Page - Model.ShowSurroundingPages &&
                    i <= Model.Page + Model.ShowSurroundingPages)
                    {

            
            #line default
            #line hidden
WriteLiteral("                    <a href=\"");


            
            #line 80 "..\..\Views\Shared\_Manage_Pagination.cshtml"
                        Write(Url.Action(Model.Controller.ManageActionName, Model.Controller.Name, Model.Route_Page(i + 1)));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                        <span class=\"page\">\r\n                            ");


            
            #line 82 "..\..\Views\Shared\_Manage_Pagination.cshtml"
                        Write(i + 1);

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </span>\r\n                    </a>\r\n");


            
            #line 85 "..\..\Views\Shared\_Manage_Pagination.cshtml"
                    }
                else
                    {
                    // Don't show.
                    }
                }
            }
        else
            {
            
            
            #line default
            #line hidden
            
            #line 94 "..\..\Views\Shared\_Manage_Pagination.cshtml"
       Write(Html.Partial(PartialViews.TextContent, new TextContentViewModel("Manage_Pagination_NoResults_" + Model.FriendlyModelTypeName, "No Results")));

            
            #line default
            #line hidden
            
            #line 94 "..\..\Views\Shared\_Manage_Pagination.cshtml"
                                                                                                                                                         
            }

            
            #line default
            #line hidden
WriteLiteral("    </span>\r\n\r\n");


            
            #line 98 "..\..\Views\Shared\_Manage_Pagination.cshtml"
     if (Model.Page + 1 != Model.TotalPages)
        {

            
            #line default
            #line hidden
WriteLiteral("        <a href=\"");


            
            #line 100 "..\..\Views\Shared\_Manage_Pagination.cshtml"
            Write(Url.Action(Model.Controller.ManageActionName, Model.Controller.Name, Model.Route_Page(Model.Page + 2)));

            
            #line default
            #line hidden
WriteLiteral("\"\r\n           key-bind-click=\"");


            
            #line 101 "..\..\Views\Shared\_Manage_Pagination.cshtml"
                       Write(ViewBag.PaginationCount == 1 ? "Ctrl+Right" : null);

            
            #line default
            #line hidden
WriteLiteral("\"\r\n           key-bind-click-name=\"");


            
            #line 102 "..\..\Views\Shared\_Manage_Pagination.cshtml"
                            Write(ViewBag.PaginationCount == 1 ? "Next Page" : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n            <span class=\"page-next\">\r\n                ");


            
            #line 104 "..\..\Views\Shared\_Manage_Pagination.cshtml"
           Write(Model.NextPageText);

            
            #line default
            #line hidden
WriteLiteral("\r\n            </span>\r\n        </a>\r\n");


            
            #line 107 "..\..\Views\Shared\_Manage_Pagination.cshtml"


            
            #line default
            #line hidden
WriteLiteral("        <a href=\"");


            
            #line 108 "..\..\Views\Shared\_Manage_Pagination.cshtml"
            Write(Url.Action(Model.Controller.ManageActionName, Model.Controller.Name, Model.Route_Page(Model.TotalPages)));

            
            #line default
            #line hidden
WriteLiteral("\"\r\n           key-bind-click=\"");


            
            #line 109 "..\..\Views\Shared\_Manage_Pagination.cshtml"
                       Write(ViewBag.PaginationCount == 1 ? "Ctrl+End" : null);

            
            #line default
            #line hidden
WriteLiteral("\"\r\n           key-bind-click-name=\"");


            
            #line 110 "..\..\Views\Shared\_Manage_Pagination.cshtml"
                            Write(ViewBag.PaginationCount == 1 ? "Last Page" : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n            <span class=\"page-last\">\r\n                ");


            
            #line 112 "..\..\Views\Shared\_Manage_Pagination.cshtml"
           Write(Model.LastPageText);

            
            #line default
            #line hidden
WriteLiteral("\r\n            </span>\r\n        </a>\r\n");


            
            #line 115 "..\..\Views\Shared\_Manage_Pagination.cshtml"
        }
    else if (Model.AlwaysShowPaginationFirstLast)
        {

            
            #line default
            #line hidden
WriteLiteral("        <span class=\"page-next\">\r\n            ");


            
            #line 119 "..\..\Views\Shared\_Manage_Pagination.cshtml"
       Write(Model.NextPageText);

            
            #line default
            #line hidden
WriteLiteral("\r\n        </span>\r\n");


            
            #line 121 "..\..\Views\Shared\_Manage_Pagination.cshtml"


            
            #line default
            #line hidden
WriteLiteral("        <span class=\"page-last\">\r\n            ");


            
            #line 123 "..\..\Views\Shared\_Manage_Pagination.cshtml"
       Write(Model.LastPageText);

            
            #line default
            #line hidden
WriteLiteral("\r\n        </span>\r\n");


            
            #line 125 "..\..\Views\Shared\_Manage_Pagination.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("</div>");


        }
    }
}
#pragma warning restore 1591
