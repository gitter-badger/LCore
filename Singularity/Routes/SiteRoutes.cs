using System;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using RazorGenerator.Mvc;
using Singularity.Models;
using Singularity.Controllers;
using Singularity.Extensions;
using System.Web.Helpers;
using System.Collections.Generic;

namespace Singularity.Routes
    {
    public static class Controllers
        {
        public static class Test
            {
            public const String Name = "Test";

            public static class Actions
                {
                public const String JavascriptTest = "JavascriptTest";
                public const String SingularityTest = "SingularityTest";
                }
            }

        public static class SavedSearch
            {
            public const String Name = "SavedSearch";

            public static class Actions
                {
                public static Dictionary<String, Object> Route_CreateSavedSearch(ManageViewModel ManageModel, ViewContext ViewContext)
                    {
                    return new Dictionary<String, Object>
                    {
                        {"ReturnURL", ViewContext.RequestContext.HttpContext.Request.Url.AbsoluteUri},
                        {"GlobalSearch", ManageModel.GlobalSearchTerm},
                        {"FieldSearch", ManageModel.GetGlobalSearchCombined("Global")},
                        {"OverrideSort", ManageModel.OverrideSort},
                        {"OverrideSortDirection", ManageModel.OverrideSortDirection},
                        {"ControllerName", ViewContext.Controller.GetType().FullName},
                        {"SearchType", ManageModel.ModelType.FullName},
                    };
                    }

                public static Dictionary<String, Object> Route_ViewSavedSearch(ManageViewModel ManageModel, Singularity.Models.SavedSearch Search)
                    {
                    return new Dictionary<String, Object>
                    { { "Page", 1 },
                        {"SortTerm", Search.OverrideSort},
                        {"SortDirection", Search.OverrideSortDirection},
                        {"GlobalSearchTerm", Search.GlobalSearch},
                        {"FieldSearchTerms", Search.FieldSearch},
                        {"ViewType", ManageModel.ViewType},
                    };
                    }
                }
            }

        public static class Manage
            {
            public const String Name = "Manage";

            public static class Actions
                {
                public const String Create = "Create";
                public const String Delete = "Delete";
                public const String DeleteConfirm = "DeleteConfirm";
                public const String Edit = "Edit";
                public const String Manage = "Manage";
                public const String Search = "Search";
                public const String Export = "Export";
                public const String Details = "Details";

                public const String DownloadFile = "DownloadFile";


                public static Dictionary<String, Object> Route_Page(ManageViewModel ManageModel, int Page)
                    {
                    return new Dictionary<String, Object>
                        { { "Page", Page },
                            { "SortTerm", ManageModel.OverrideSort },
                            { "SortDirection", ManageModel.OverrideSortDirection },
                            { "GlobalSearchTerm", ManageModel.GlobalSearchTerm },
                            { "FieldSearchTerms", ManageModel.GetGlobalSearchCombined("Global") },
                            {"ViewType", ManageModel.ViewType},
                        };
                    }
                public static Object Route_Search(ManageViewModel ManageModel)
                    {
                    return new
                        {
                            Page = 1,
                            SortTerm = "",
                            SortDirection = "ASC",
                            GlobalSearchTerm = "",
                            FieldSearchTerms = "",
                            ViewType = ManageModel.ViewType,
                        };
                    }
                public static Object Route_ClearSearch(ManageViewModel ManageModel)
                    {
                    return new
                        {
                            Page = 1,
                            SortTerm = "",
                            SortDirection = "ASC",
                            GlobalSearchTerm = "",
                            FieldSearchTerms = "",
                            ViewType = ManageModel.ViewType,
                        };
                    }
                public static Object Route_RemoveFilter(ManageViewModel ManageModel, String Property)
                    {
                    return new
                    {
                        SortTerm = ManageModel.OverrideSort,
                        SortDirection = ManageModel.OverrideSortDirection,
                        GlobalSearchTerm = ManageModel.GlobalSearchTerm,
                        FieldSearchTerms = ManageModel.GetGlobalSearchCombined("Global", Property),
                        ViewType = ManageModel.ViewType,
                    };
                    }
                public static Dictionary<String, Object> Route_SortColumn(ManageViewModel ManageModel, String ColumnName)
                    {
                    return new Dictionary<String, Object>
                        { 
                            { "Page", 1 },
                            { "SortTerm", ColumnName },
                            {"SortDirection", (ManageModel.OverrideSort == ColumnName &&
                                ManageModel.OverrideSortDirection == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending)},
                            { "GlobalSearchTerm", ManageModel.GlobalSearchTerm },
                            { "FieldSearchTerms", ManageModel.GetGlobalSearchCombined("Global") },
                            {"ViewType", ManageModel.ViewType},
                        };
                    }

                public static Object Route_Export(ManageViewModel ManageModel)
                    {
                    return new
                        {
                            SortTerm = ManageModel.OverrideSort,
                            SortDirection = ManageModel.OverrideSortDirection,
                            GlobalSearchTerm = ManageModel.GlobalSearchTerm,
                            FieldSearchTerms = ManageModel.GetGlobalSearchCombined("Global"),
                            ViewType = ManageModel.ViewType,
                        };
                    }
                public static Object Route_Export(ManageViewModel ManageModel, Singularity.Models.CustomExport Export)
                    {
                    return new
                    {
                        SortTerm = ManageModel.OverrideSort,
                        SortDirection = ManageModel.OverrideSortDirection,
                        GlobalSearchTerm = ManageModel.GlobalSearchTerm,
                        FieldSearchTerms = ManageModel.GetGlobalSearchCombined("Global"),
                        ViewType = ManageModel.ViewType,
                        CustomExportID = Export.CustomExportID,
                    };
                    }

                public static Dictionary<String, Object> Route_ToggleArchive(ManageViewModel ManageModel)
                    {
                    return new Dictionary<String, Object>
                        { 
                        { "Page" , 1 },
                            { "SortTerm" , ManageModel.OverrideSort },
                            { "SortDirection" , ManageModel.OverrideSortDirection },
                            { "GlobalSearchTerm", ManageModel.GlobalSearchTerm },
                            { "FieldSearchTerms", ManageModel.GetGlobalSearchCombined("Global") },
                            {"ViewType", ManageModel.ViewType.HasFlag(ControllerHelper.ManageViewType.Archive) ?
                                ControllerHelper.ManageViewType.Normal : ControllerHelper.ManageViewType.Archive},
                        };
                    }
                public static Dictionary<String, Object> Route_ToggleInactive(ManageViewModel ManageModel)
                    {
                    return new Dictionary<String, Object>
                        { { "Page", 1 },
                            { "SortTerm", ManageModel.OverrideSort },
                            { "SortDirection", ManageModel.OverrideSortDirection },
                            { "GlobalSearchTerm", ManageModel.GlobalSearchTerm },
                            { "FieldSearchTerms", ManageModel.GetGlobalSearchCombined("Global") },
                            {"ViewType", ManageModel.ViewType.HasFlag(ControllerHelper.ManageViewType.Inactive) ?
                                ControllerHelper.ManageViewType.Normal : ControllerHelper.ManageViewType.Inactive},
                        };
                    }

                public static Object Route_DetailView(IModel Model, HttpRequestBase Request)
                    {
                    return new
                    {
                        ID = Model.GetID(),
                        ReturnURL = Request.Url,
                    };
                    }
                public static Object Route_DetailView(IModel Model, String ReturnURL)
                    {
                    return new
                    {
                        ID = Model.GetID(),
                        ReturnURL = ReturnURL,
                    };
                    }

                public static Dictionary<String, Object> Route_InlineEdit(ManageViewModel ManageModel, IModel Model, HttpRequestBase Request)
                    {
                    return new Dictionary<String, Object>
                    { 
                        { "Page", ManageModel.Page },
                        { "SortTerm", ManageModel.OverrideSort },
                        {"SortDirection", ManageModel.OverrideSortDirection},
                        {"GlobalSearchTerm", ManageModel.GlobalSearchTerm},
                        {"FieldSearchTerms", ManageModel.GetGlobalSearchCombined("Global")},
                        {"ViewType", ManageModel.ViewType},
                        {"InlineEdit", Model.GetID()},
                    };
                    }

                public static Dictionary<String, Object> Route_Edit(IModel Model, HttpRequestBase Request)
                    {
                    return new Dictionary<String, Object>
                    {
                        { "ID", Model.GetID() },
                        { "ReturnURL", Request.Url },
                    };
                    }
                public static Dictionary<String, Object> Route_Edit(IModel Model, String ReturnURL)
                    {
                    return new Dictionary<String, Object>
                    { 
                    { "ID", Model.GetID() },
                        {"ReturnURL", ReturnURL},
                    };
                    }

                public static Object Route_Create(HttpRequestBase Request)
                    {
                    return new
                    {
                        ReturnURL = Request.Url,
                    };
                    }
                public static Object Route_Create(String ReturnURL)
                    {
                    return new
                    {
                        ReturnURL = ReturnURL,
                    };
                    }

                public static Object Route_Delete(IModel Model, HttpRequestBase Request)
                    {
                    return new
                    {
                        ID = Model.GetID(),
                        ReturnURL = Request.Url,
                    };
                    }
                public static Object Route_Delete(IModel Model, String ReturnURL)
                    {
                    return new
                    {
                        ID = Model.GetID(),
                        ReturnURL = ReturnURL,
                    };
                    }
                }
            }

        }

    public static class Layouts
        {
        public const String MainLayout = "~/Views/_MainLayout.cshtml";
        }

    public static class PartialViews
        {
        public const String Manage_HeaderRow = "_Manage_HeaderRow";
        public const String Manage_Pagination = "_Manage_Pagination";
        public const String Manage_Row = "_Manage_Row";
        public const String Manage_Search = "_Manage_Search";

        public const String FieldHeader = "_FieldHeader";

        public const String TextContent = "_TextContent";
        }
    }