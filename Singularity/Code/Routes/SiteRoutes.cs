using System;
using System.Web;
using System.Web.Mvc;
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
            public const string Name = "Test";

            public static class Actions
                {
                public const string JavascriptTest = "JavascriptTest";
                public const string SingularityTest = "SingularityTest";
                }
            }

        public static class SavedSearch
            {
            public const string Name = "SavedSearch";

            public static class Actions
                {
                public static Dictionary<string, object> Route_CreateSavedSearch(ManageViewModel ManageModel, ViewContext ViewContext)
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

                public static Dictionary<string, object> Route_ViewSavedSearch(ManageViewModel ManageModel, Models.SavedSearch Search)
                    {
                    return new Dictionary<string, object>
                    {
                        { "Page", 1 },
                        {"SortTerm", Search.OverrideSort},
                        {"SortDirection", Search.OverrideSortDirection},
                        {"GlobalSearchTerm", Search.GlobalSearch},
                        {"FieldSearchTerms", Search.FieldSearch},
                        {"ViewType", ManageModel.ViewType}
                    };
                    }
                }
            }

        public static class Manage
            {
            public const string Name = "Manage";

            public static class Actions
                {
                public const string Create = "Create";
                public const string Delete = "Delete";
                public const string DeleteConfirm = "DeleteConfirm";
                public const string Edit = "Edit";
                public const string Manage = "Manage";
                public const string Search = "Search";
                public const string Export = "Export";
                public const string Details = "Details";

                public const string DownloadFile = "DownloadFile";


                public static Dictionary<string, object> Route_Page(ManageViewModel ManageModel, int Page)
                    {
                    return new Dictionary<string, object>
                        { { "Page", Page },
                            { "SortTerm", ManageModel.OverrideSort },
                            { "SortDirection", ManageModel.OverrideSortDirection },
                            { "GlobalSearchTerm", ManageModel.GlobalSearchTerm },
                            { "FieldSearchTerms", ManageModel.GetGlobalSearchCombined("Global") },
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
                            { "Page", 1 },
                            { "SortTerm", ColumnName },
                            {"SortDirection", ManageModel.OverrideSort == ColumnName &&
                                              ManageModel.OverrideSortDirection == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending},
                            { "GlobalSearchTerm", ManageModel.GlobalSearchTerm },
                            { "FieldSearchTerms", ManageModel.GetGlobalSearchCombined("Global") },
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
                public static object Route_Export(ManageViewModel ManageModel, CustomExport CustomExport)
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
                        { "Page" , 1 },
                            { "SortTerm" , ManageModel.OverrideSort },
                            { "SortDirection" , ManageModel.OverrideSortDirection },
                            { "GlobalSearchTerm", ManageModel.GlobalSearchTerm },
                            { "FieldSearchTerms", ManageModel.GetGlobalSearchCombined("Global") },
                            {"ViewType", ManageModel.ViewType.HasFlag(ControllerHelper.ManageViewType.Archive) ?
                                ControllerHelper.ManageViewType.Normal : ControllerHelper.ManageViewType.Archive}
                        };
                    }
                public static Dictionary<string, object> Route_ToggleInactive(ManageViewModel ManageModel)
                    {
                    return new Dictionary<string, object>
                        { { "Page", 1 },
                            { "SortTerm", ManageModel.OverrideSort },
                            { "SortDirection", ManageModel.OverrideSortDirection },
                            { "GlobalSearchTerm", ManageModel.GlobalSearchTerm },
                            { "FieldSearchTerms", ManageModel.GetGlobalSearchCombined("Global") },
                            {"ViewType", ManageModel.ViewType.HasFlag(ControllerHelper.ManageViewType.Inactive) ?
                                ControllerHelper.ManageViewType.Normal : ControllerHelper.ManageViewType.Inactive}
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
                public static object Route_DetailView(IModel Model, string ReturnURL)
                    {
                    return new
                        {
                        ID = Model.GetID(),
                        ReturnURL
                        };
                    }

                public static Dictionary<string, object> Route_InlineEdit(ManageViewModel ManageModel, IModel Model, HttpRequestBase Request)
                    {
                    return new Dictionary<string, object>
                    {
                        { "Page", ManageModel.Page },
                        { "SortTerm", ManageModel.OverrideSort },
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
                        { "ID", Model.GetID() },
                        { "ReturnURL", Request.Url }
                    };
                    }
                public static Dictionary<string, object> Route_Edit(IModel Model, string ReturnURL)
                    {
                    return new Dictionary<string, object>
                    {
                    { "ID", Model.GetID() },
                        {"ReturnURL", ReturnURL}
                    };
                    }

                public static object Route_Create(HttpRequestBase Request)
                    {
                    return new
                        {
                        ReturnURL = Request.Url
                        };
                    }
                public static object Route_Create(string ReturnURL)
                    {
                    return new
                        {
                        ReturnURL
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
                public static object Route_Delete(IModel Model, string ReturnURL)
                    {
                    return new
                        {
                        ID = Model.GetID(),
                        ReturnURL
                        };
                    }
                }
            }

        public static class Account
            {
            public const string Name = "Account";

            public static class Actions
                {
                public const string ForceResetPassword = "ForceResetPassword";
                public const string Login = "Login";
                public const string LogOff = "LogOff";
                }
            }

        public static class Home
            {
            public const string Name = "Home";

            public static class Actions
                {
                public const string Index = "Index";
                }
            }
        }

    public static class Layouts
        {
        public const string MainLayout = "~/Views/_MainLayout.cshtml";
        }

    public static class PartialViews
        {
        public const string Nav = "Nav";

        public const string LoginPartial = "LoginPartial";
        public const string PasswordRequirements = "PasswordRequirements";

        public const string Manage_HeaderRow = "Manage_HeaderRow";
        public const string Manage_Pagination = "Manage_Pagination";
        public const string Manage_Row = "Manage_Row";
        public const string Manage_Search = "Manage_Search";

        public const string FieldHeader = "FieldHeader";

        public const string TextContent = "TextContent";

        public const string Manage_CustomExport = "Manage_Exports";

        public const string Singularity_JS_Test = "Test/JavascriptTest";

        public const string Edit = "Edit";

        public const string Field = "Fields/Field";

        public const string Manage_Before = "Manage_Before";
        public const string Manage_After = "Manage_After";

        public static string Examples_Bootstrap = "Examples_Bootstrap";
        public static string Examples_JQueryUI = "Examples_JQueryUI";
        public static string Examples_Singularity = "Examples_Singularity";

        public static string Field_PropertyName(string PropertyName)
            {
            return $"Fields/{PropertyName}";
            }

        public static string Field_PropertyName_Before(string PropertyName)
            {
            return $"Fields/{PropertyName}_Before";
            }
        public static string Field_PropertyName_After(string PropertyName)
            {
            return $"Fields/{PropertyName}_After";
            }

        public static string Field_PropertyType_Before(Type PropertyType)
            {
            return PropertyType != null ? $"Fields/{PropertyType.Name}_Before" : null;
            }

        public static string Field_PropertyType_After(Type PropertyType)
            {
            return $"Fields/{PropertyType.Name}_After";
            }

        public static string Field_ViewType_Before(ControllerHelper.ViewType ViewType)
            {
            return $"Fields/{ViewType}_Before";
            }
        public static string Field_ViewType_After(ControllerHelper.ViewType ViewType)
            {
            return $"Fields/{ViewType}_After";
            }

        public const string Field_Error = "Fields/Error";

        public const string Field_View = "Fields/View";

        public static string Field_View_PropertyName(string PropertyName)
            {
            return $"Fields/View/{PropertyName}";
            }
        public static string Field_View_PropertyType(Type PropertyType)
            {
            return $"Fields/View/{PropertyType.Name}";
            }
        public static string Field_View_DataTypeName(string DataType)
            {
            return $"Fields/View/{DataType}";
            }

        public const string Field_View_Boolean = "Fields/View/Boolean";
        // public const String Field_View_ComplexType = "Fields/View/ComplexType";
        public const string Field_View_Currency = "Fields/View/Currency";
        public const string Field_View_DateTime = "Fields/View/DateTime";
        public const string Field_View_DisplayColumn = "Fields/View/DisplayColumn";
        public const string Field_View_Enum = "Fields/View/Enum";
        public const string Field_View_Empty = "Fields/View/Empty";
        public const string Field_View_FormatString = "Fields/View/FormatString";
        public const string Field_View_IModel = "Fields/View/IModel";
        public const string Field_View_IModelCollection = "Fields/View/IModelCollection";
        public const string Field_View_Int = "Fields/View/Int";
        public const string Field_View_String = "Fields/View/String";
        public const string Field_View_StringMatrix = "Fields/View/StringMatrix";
        public const string Field_View_StringMultiArray = "Fields/View/StringMultiArray";


        public const string Field_View_Unknown = "Fields/View/Unknown";

        public const string Field_Edit = "Fields/Edit";

        public static string Field_Edit_PropertyName(string PropertyName)
            {
            return $"Fields/Edit/{PropertyName}";
            }
        public static string Field_Edit_PropertyType(Type PropertyType)
            {
            return $"Fields/Edit/{PropertyType.Name}";
            }
        public static string Field_Edit_DataTypeName(string DataType)
            {
            return $"Fields/Edit/{DataType}";
            }

        public const string Field_Edit_Boolean = "Fields/Edit/Boolean";
        public const string Field_Edit_ComplexType = "Fields/Edit/ComplexType";
        public const string Field_Edit_Currency = "Fields/Edit/Currency";
        public const string Field_Edit_DateTime = "Fields/Edit/DateTime";
        public const string Field_Edit_Decimal = "Fields/Edit/Decimal";
        public const string Field_Edit_Enum = "Fields/Edit/Enum";
        public const string Field_Edit_Key = "Fields/Edit/Key";
        public const string Field_Edit_DisplayColumn = "Fields/Edit/DisplayColumn";
        public const string Field_Edit_Empty = "Fields/Edit/Empty";
        public const string Field_Edit_FormatString = "Fields/Edit/FormatString";
        public const string Field_Edit_Hidden = "Fields/Edit/Hidden";
        public const string Field_Edit_IModel = "Fields/Edit/IModel";
        // public const String Field_Edit_IModelCollection = "Fields/Edit/IModelCollection";
        public const string Field_Edit_Int = "Fields/Edit/Int";
        public const string Field_Edit_Long = "Fields/Edit/Long";
        public const string Field_Edit_IntRange = "Fields/Edit/IntRange";
        public const string Field_Edit_String = "Fields/Edit/String";
        public const string Field_Edit_StringMultiLine = "Fields/Edit/StringMultiLine";
        public const string Field_Edit_HTMLContent = "Fields/Edit/HTMLContent";
        public const string Field_Edit_Unknown = "Fields/Edit/Unknown";
        public const string Field_Edit_Dropdown = "Fields/Edit/Dropdown";


        public const string Field_FileUpload = "Fields/FileUpload";

        public const string Field_Information = "Fields/Information";
        }
    }