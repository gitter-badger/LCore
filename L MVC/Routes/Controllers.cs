using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using LMVC.Controllers;
using LMVC.Extensions;
using LMVC.Models;

namespace LMVC.Routes
    {
    public static class Controllers
        {
        #region Manage

        #region SavedSearch

        public static class SavedSearch
            {
            public static class Actions
                {
                public static Dictionary<string, object> Route_CreateSavedSearch(ManageViewModel ManageModel,
                    ViewContext ViewContext)
                    {
                    return new Dictionary<string, object>
                        {
                        {"ReturnURL", ViewContext.RequestContext.HttpContext.Request.Url?.AbsoluteUri},
                        {"GlobalSearch", ManageModel.GlobalSearchTerm},
                        {"FieldSearch", ManageModel.GetGlobalSearchCombined("Global")},
                        {"OverrideSort", ManageModel.OverrideSort},
                        {"OverrideSortDirection", ManageModel.OverrideSortDirection},
                        {"ControllerName", ViewContext.Controller.GetType().FullName},
                        {"SearchType", ManageModel.ModelType.FullName}
                        };
                    }

                public static Dictionary<string, object> Route_ViewSavedSearch(ManageViewModel ManageModel,
                    Models.SavedSearch Search)
                    {
                    return new Dictionary<string, object>
                        {
                        // ReSharper disable once ArgumentsStyleLiteral
                        {"Page", 1},
                        {"SortTerm", Search.OverrideSort},
                        {"SortDirection", Search.OverrideSortDirection},
                        {"GlobalSearchTerm", Search.GlobalSearch},
                        {"FieldSearchTerms", Search.FieldSearch},
                        {"ViewType", ManageModel.ViewType}
                        };
                    }
                }
            }

        #endregion

        public static class Manage
            {
            public static class Actions
                {
                public static Dictionary<string, object> Route_Page(ManageViewModel ManageModel, int Page)
                    {
                    return new Dictionary<string, object>
                        {
                        {"Page", Page},
                        {"SortTerm", ManageModel.OverrideSort},
                        {"SortDirection", ManageModel.OverrideSortDirection},
                        {"GlobalSearchTerm", ManageModel.GlobalSearchTerm},
                        {"FieldSearchTerms", ManageModel.GetGlobalSearchCombined("Global")},
                        {"ViewType", ManageModel.ViewType}
                        };
                    }

                public static object Route_Search(ManageViewModel ManageModel)
                    {
                    return new
                        {
                        Page = 1,
                        SortTerm = "",
                        SortDirection = "ASC",
                        GlobalSearchTerm = "",
                        FieldSearchTerms = "",
                        ManageModel.ViewType
                        };
                    }

                public static object Route_ClearSearch(ManageViewModel ManageModel)
                    {
                    return new
                        {
                        Page = 1,
                        SortTerm = "",
                        SortDirection = "ASC",
                        GlobalSearchTerm = "",
                        FieldSearchTerms = "",
                        ManageModel.ViewType
                        };
                    }

                public static object Route_RemoveFilter(ManageViewModel ManageModel, string Property)
                    {
                    return new
                        {
                        SortTerm = ManageModel.OverrideSort,
                        SortDirection = ManageModel.OverrideSortDirection,
                        ManageModel.GlobalSearchTerm,
                        FieldSearchTerms = ManageModel.GetGlobalSearchCombined("Global", Property),
                        ManageModel.ViewType
                        };
                    }

                public static Dictionary<string, object> Route_SortColumn(ManageViewModel ManageModel, string ColumnName)
                    {
                    return new Dictionary<string, object>
                        {
                        // ReSharper disable once ArgumentsStyleLiteral
                        {"Page", 1},
                        {"SortTerm", ColumnName},
                        {
                        "SortDirection", ManageModel.OverrideSort == ColumnName &&
                                         ManageModel.OverrideSortDirection == SortDirection.Ascending
                            ? SortDirection.Descending
                            : SortDirection.Ascending
                        },
                        {"GlobalSearchTerm", ManageModel.GlobalSearchTerm},
                        {"FieldSearchTerms", ManageModel.GetGlobalSearchCombined("Global")},
                        {"ViewType", ManageModel.ViewType}
                        };
                    }

                public static object Route_Export(ManageViewModel ManageModel)
                    {
                    return new
                        {
                        SortTerm = ManageModel.OverrideSort,
                        SortDirection = ManageModel.OverrideSortDirection,
                        ManageModel.GlobalSearchTerm,
                        FieldSearchTerms = ManageModel.GetGlobalSearchCombined("Global"),
                        ManageModel.ViewType
                        };
                    }

                public static object Route_Export(ManageViewModel ManageModel, ICustomExport CustomExport)
                    {
                    return new
                        {
                        SortTerm = ManageModel.OverrideSort,
                        SortDirection = ManageModel.OverrideSortDirection,
                        ManageModel.GlobalSearchTerm,
                        FieldSearchTerms = ManageModel.GetGlobalSearchCombined("Global"),
                        ManageModel.ViewType,
                        CustomExport.CustomExportID
                        };
                    }

                public static Dictionary<string, object> Route_ToggleArchive(ManageViewModel ManageModel)
                    {
                    return new Dictionary<string, object>
                        {
                        // ReSharper disable once ArgumentsStyleLiteral
                        {"Page", 1},
                        {"SortTerm", ManageModel.OverrideSort},
                        {"SortDirection", ManageModel.OverrideSortDirection},
                        {"GlobalSearchTerm", ManageModel.GlobalSearchTerm},
                        {"FieldSearchTerms", ManageModel.GetGlobalSearchCombined("Global")},
                        {
                        "ViewType", ManageModel.ViewType.HasFlag(ControllerHelper.ManageViewType.Archive)
                            ? ControllerHelper.ManageViewType.Normal
                            : ControllerHelper.ManageViewType.Archive
                        }
                        };
                    }

                public static Dictionary<string, object> Route_ToggleInactive(ManageViewModel ManageModel)
                    {
                    return new Dictionary<string, object>
                        {
                        // ReSharper disable once ArgumentsStyleLiteral
                        {"Page", 1},
                        {"SortTerm", ManageModel.OverrideSort},
                        {"SortDirection", ManageModel.OverrideSortDirection},
                        {"GlobalSearchTerm", ManageModel.GlobalSearchTerm},
                        {"FieldSearchTerms", ManageModel.GetGlobalSearchCombined("Global")},
                        {
                        "ViewType", ManageModel.ViewType.HasFlag(ControllerHelper.ManageViewType.Inactive)
                            ? ControllerHelper.ManageViewType.Normal
                            : ControllerHelper.ManageViewType.Inactive
                        }
                        };
                    }

                public static object Route_DetailView(IModel Model, HttpRequestBase Request)
                    {
                    return new
                        {
                        ID = Model.GetID(),
                        ReturnURL = Request.Url
                        };
                    }

                public static object Route_DetailView(IModel Model, string ReturnUrl)
                    {
                    return new
                        {
                        ID = Model.GetID(),
                        ReturnURL = ReturnUrl
                        };
                    }

                public static Dictionary<string, object> Route_InlineEdit(ManageViewModel ManageModel, IModel Model)
                    {
                    return new Dictionary<string, object>
                        {
                        {"Page", ManageModel.Page},
                        {"SortTerm", ManageModel.OverrideSort},
                        {"SortDirection", ManageModel.OverrideSortDirection},
                        {"GlobalSearchTerm", ManageModel.GlobalSearchTerm},
                        {"FieldSearchTerms", ManageModel.GetGlobalSearchCombined("Global")},
                        {"ViewType", ManageModel.ViewType},
                        {"InlineEdit", Model.GetID()}
                        };
                    }

                public static Dictionary<string, object> Route_Edit(IModel Model, HttpRequestBase Request)
                    {
                    return new Dictionary<string, object>
                        {
                        {"ID", Model.GetID()},
                        {"ReturnURL", Request.Url}
                        };
                    }

                public static Dictionary<string, object> Route_Edit(IModel Model, string ReturnUrl)
                    {
                    return new Dictionary<string, object>
                        {
                        {"ID", Model.GetID()},
                        {"ReturnURL", ReturnUrl}
                        };
                    }

                public static object Route_Create(HttpRequestBase Request)
                    {
                    return new
                        {
                        ReturnURL = Request.Url
                        };
                    }

                public static object Route_Create(string ReturnUrl)
                    {
                    return new
                        {
                        ReturnURL = ReturnUrl
                        };
                    }

                public static object Route_Delete(IModel Model, HttpRequestBase Request)
                    {
                    return new
                        {
                        ID = Model.GetID(),
                        ReturnURL = Request.Url
                        };
                    }

                public static object Route_Delete(IModel Model, string ReturnUrl)
                    {
                    return new
                        {
                        ID = Model.GetID(),
                        ReturnURL = ReturnUrl
                        };
                    }
                }
            }

        #endregion
        }
    }