using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Security;
using LCore;
using Singularity;
using Singularity.Context;
using Singularity.Models;
using WebMatrix.WebData;
using System.Configuration;
using System.Web.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Web.Helpers;
using Singularity.Extensions;


namespace Singularity.Controllers
    {
    public abstract class ControllerHelper
        {
        public const string Menu_Admin = "Admin";
        public const string Menu_Directory = "Directory";
        public const string Menu_Time = "Time";
        public const string Menu_Forms = "Forms";
        public const string Menu_Invoicing = "Invoicing";

        public const String Script_Singularity = "~/Scripts/singularity";
        public const String Style_Singularity = "~/Content/singularity";
        
        public const String Style_JQuery_Mobile = "~/Content/jquery-mobile";
        public const String Script_JQuery_Mobile = "~/Scripts/jquery-mobile";

        public const String Script_MVCL_Chance = "~/Scripts/mvcl/chance";
        public const String Script_MVCL_qTip = "~/Scripts/mvcl/qTip";
        public const String Script_MVCL_jQueryCookie = "~/Scripts/mvcl/jquery.cookie";
        public const String Script_MVCL_jQueryMousewheel = "~/Scripts/mvcl/jquery.mousewheel";
        public const String Script_MVCL_jQueryTimepicker = "~/bundles/mvcl/jquery.timepicker";

        public const String ViewBag_ManageModel = "ManageModel";
        public const String ViewBag_EditModel = "EditModel";

        public const String Config_EnableDuoAuth = "EnableDuoAuth";
        public const String Config_DuoHost = "DuoHost";
        public const String Config_DuoIKey = "DuoIKey";
        public const String Config_DuoSKey = "DuoSKey";
        public const String Config_DuoAKey = "DuoAKey";

        public const String StatusMessage_Temporary = "TempStatusMessage";
        public const String StatusMessage_TemporaryIcon = "TempStatusMessageIcon";

        public const String Session_DuoSignRequest = "DuoSignRequest";
        public const String Session_DuoSignRequest_ReturnURL = "DuoSignRequest_ReturnURL";

        public const String Session_Role = "ProfileRoleSession";
        public const String Session_User = "ProfileUserSession";

        public static TimeSpan DefaultArchiveTimeSpan = new TimeSpan(180, 0, 0, 0, 0);

        [Flags]
        public enum ViewType
            {
            Create = 1,
            Edit = 2,
            Display = 4,
            TableCell = 8,
            FieldHeader = 16,
            Export = 32,

            All = ViewType.Create | ViewType.Display | ViewType.Edit | ViewType.Export | ViewType.FieldHeader | ViewType.TableCell
            }

        [Flags]
        public enum ManageViewType
            {
            Normal = 1,
            Inactive = 2,
            Archive = 4,

            All = ManageViewType.Normal | ManageViewType.Inactive | ManageViewType.Archive
            }

        public static class PartialViews
            {
            public const String Manage_Pagination = "_Manage_Pagination";
            public const String Manage_Search = "_Manage_Search";
            public const String Manage_HeaderRow = "_Manage_HeaderRow";
            public const String Manage_Row = "_Manage_Row";

            public const String Manage_CustomExport = "_Manage_Exports";

            public const String Singularity_JS_Test = "Test/JavascriptTest";

            public const String Edit = "Edit";
            public const String Login = "_LoginPartial";

            public const String Field = "Fields/Field";

            public const String Manage_Before = "Manage_Before";
            public const String Manage_After = "Manage_After";

            public static String Field_PropertyName(String PropertyName)
                {
                return "Fields/" + PropertyName;
                }

            public static String Field_PropertyName_Before(String PropertyName)
                {
                return "Fields/" + PropertyName + "_Before";
                }
            public static String Field_PropertyName_After(String PropertyName)
                {
                return "Fields/" + PropertyName + "_After";
                }

            public static String Field_PropertyType_Before(Type PropertyType)
                {
                return "Fields/" + PropertyType.Name + "_Before";
                }
            public static String Field_PropertyType_After(Type PropertyType)
                {
                return "Fields/" + PropertyType.Name + "_After";
                }

            public static String Field_ViewType_Before(ControllerHelper.ViewType ViewType)
                {
                return "Fields/" + ViewType.ToString() + "_Before";
                }
            public static String Field_ViewType_After(ControllerHelper.ViewType ViewType)
                {
                return "Fields/" + ViewType.ToString() + "_After";
                }

            public const String Field_Error = "Fields/Error";

            public const String Field_View = "Fields/View";

            public static String Field_View_PropertyName(String PropertyName)
                {
                return "Fields/View/" + PropertyName;
                }
            public static String Field_View_PropertyType(Type PropertyType)
                {
                return "Fields/View/" + PropertyType.Name;
                }
            public static String Field_View_DataTypeName(String DataType)
                {
                return "Fields/View/" + DataType;
                }

            public const String Field_View_Boolean = "Fields/View/Boolean";
            // public const String Field_View_ComplexType = "Fields/View/ComplexType";
            public const String Field_View_Currency = "Fields/View/Currency";
            public const String Field_View_DateTime = "Fields/View/DateTime";
            public const String Field_View_DisplayColumn = "Fields/View/DisplayColumn";
            public const String Field_View_Enum = "Fields/View/Enum";
            public const String Field_View_Empty = "Fields/View/Empty";
            public const String Field_View_FormatString = "Fields/View/FormatString";
            public const String Field_View_IModel = "Fields/View/IModel";
            public const String Field_View_IModelCollection = "Fields/View/IModelCollection";
            public const String Field_View_Int = "Fields/View/Int";
            public const String Field_View_String = "Fields/View/String";
            public const String Field_View_StringMatrix = "Fields/View/StringMatrix";
            public const String Field_View_StringMultiArray = "Fields/View/StringMultiArray";


            public const String Field_View_Unknown = "Fields/View/Unknown";

            public const String Field_Edit = "Fields/Edit";

            public static String Field_Edit_PropertyName(String PropertyName)
                {
                return "Fields/Edit/" + PropertyName;
                }
            public static String Field_Edit_PropertyType(Type PropertyType)
                {
                return "Fields/Edit/" + PropertyType.Name;
                }
            public static String Field_Edit_DataTypeName(String DataType)
                {
                return "Fields/Edit/" + DataType;
                }

            public const String Field_Edit_Boolean = "Fields/Edit/Boolean";
            public const String Field_Edit_ComplexType = "Fields/Edit/ComplexType";
            public const String Field_Edit_Currency = "Fields/Edit/Currency";
            public const String Field_Edit_DateTime = "Fields/Edit/DateTime";
            public const String Field_Edit_Decimal = "Fields/Edit/Decimal";
            public const String Field_Edit_Enum = "Fields/Edit/Enum";
            public const String Field_Edit_Key = "Fields/Edit/Key";
            public const String Field_Edit_DisplayColumn = "Fields/Edit/DisplayColumn";
            public const String Field_Edit_Empty = "Fields/Edit/Empty";
            public const String Field_Edit_FormatString = "Fields/Edit/FormatString";
            public const String Field_Edit_Hidden = "Fields/Edit/Hidden";
            public const String Field_Edit_IModel = "Fields/Edit/IModel";
            // public const String Field_Edit_IModelCollection = "Fields/Edit/IModelCollection";
            public const String Field_Edit_Int = "Fields/Edit/Int";
            public const String Field_Edit_Long = "Fields/Edit/Long";
            public const String Field_Edit_IntRange = "Fields/Edit/IntRange";
            public const String Field_Edit_String = "Fields/Edit/String";
            public const String Field_Edit_StringMultiLine = "Fields/Edit/StringMultiLine";
            public const String Field_Edit_HTMLContent = "Fields/Edit/HTMLContent";
            public const String Field_Edit_Unknown = "Fields/Edit/Unknown";
            public const String Field_Edit_Dropdown = "Fields/Edit/Dropdown";


            public const String Field_FileUpload = "Fields/FileUpload";

            public const String Field_Information = "Fields/Information";
            }

        public static class AutomaticFields
            {
            public const String Active = "Active";
            public const String Created = "Created";
            public const String Updated = "Updated";
            public const String Archived = "Archived";
            }

        public static readonly Boolean AllowRegister = false;
        public static readonly Boolean AllowExternalLogin = false;
        public static readonly Boolean AllowLoginCookie = false;

        public static readonly int DefaultTableTextLength = 50;

        public static readonly Boolean GlobalSearchAssumeStars = false;

        public static readonly int DefaultRowsPerPage = 20;

        public static void HandleError(HttpContextBase HttpContext, Exception Ex)
            {
            ModelContext Context = ContextProviderFactory.GetCurrent().GetContext(HttpContext.Session);

            if (Context.ContextTypes.Has(typeof(Singularity.Models.Error)))
                {
                DbSet<Singularity.Models.Error> ErrorsTable = Context.GetDBSet<Singularity.Models.Error>();

                try
                    {
                    Singularity.Models.Error Error = new Error();
                    Error.Message = Ex.Message;
                    Error.FullDetails = Ex.ToString();
                    Error.Created = DateTime.Now;
                    Error.Active = true;
                    Error.URL = HttpContext.Request.Url.AbsoluteUri;

                    if (ErrorsTable.Where(
                            e => e.FullDetails == Error.FullDetails &&
                            e.URL == Error.URL &&
                                //                            e.Created.Date == Error.Created.Date &&
                            e.Active == true).Count() > 0)
                        {
                        // Don't duplicate errors more than once per day.
                        return;
                        }

                    ErrorsTable.Add(Error);
                    Context.SaveChanges();
                    }
                catch (Exception e)
                    {
                    throw new Exception("Could not log error to database", e);
                    }
                }
            }

        public static String GetConfig(String Key)
            {
            return System.Configuration.ConfigurationManager.AppSettings[Key];
            }

        public static void RegisterBundles(System.Web.Optimization.BundleCollection bundles, Boolean IncludedLib)
            {
            String Root = IncludedLib ? "~/bin/" : "~/";

            #region Singularity
            bundles.Add(new ScriptBundle(Script_Singularity).Include(
                        Root + "Scripts/singularity-min.js"));

            bundles.Add(new StyleBundle(Style_Singularity).Include(
                Root + "Content/singularity.css",
                Root + "Content/singularity-forms.css"));
            #endregion

            bundles.Add(new ScriptBundle(Script_JQuery_Mobile).Include(
                        Root + "Scripts/jquery-mobile/jquery.mobile.custom.js"));

            bundles.Add(new ScriptBundle(Style_JQuery_Mobile).Include(
                        Root + "Scripts/jquery-mobile/jquery.mobile.custom.theme.css"));

            bundles.Add(new ScriptBundle(Script_MVCL_Chance).Include(
                        Root + "Scripts/chance.js"));

            bundles.Add(new ScriptBundle(Script_MVCL_qTip).Include(
                        Root + "Scripts/qTip.js"));

            bundles.Add(new ScriptBundle(Script_MVCL_jQueryCookie).Include(
                        Root + "Scripts/jquery.cookie.js"));

            bundles.Add(new ScriptBundle(Script_MVCL_jQueryMousewheel).Include(
                        Root + "Scripts/jquery.mousewheel.js"));

            bundles.Add(new ScriptBundle(Script_MVCL_jQueryTimepicker).Include(
                      "~/Scripts/jquery.timepicker.js"));
            }

        public Dictionary<string, SearchOperation> ExtractSearchTerms(ref string GlobalSearchTerm, Type ModelType)
            {
            Dictionary<string, SearchOperation> Out = new Dictionary<string, SearchOperation>();

            String[] Split = null;

            GlobalSearchTerm = GlobalSearchTerm ?? "";

            if (GlobalSearchTerm.Contains("|"))
                Split = GlobalSearchTerm.Split("|");
            else
                Split = new[] { GlobalSearchTerm };

            GlobalSearchTerm = "";

            List<String> Keys = QueryExt.BinaryOps.Keys.List();

            foreach (String SearchTerm in Split)
                {
                Boolean KeyFound = false;

                foreach (String Key in Keys)
                    {
                    if (SearchTerm.Contains(Key))
                        {
                        String[] Split2 = SearchTerm.Split(Key);

                        String Property = Split2[0].RemoveAll(" ");

                        if (Property == null)
                            continue;

                        if (!ModelType.Meta().Properties.Has(p => p.PropertyName == Property))
                            {
                            if (Property.Contains("."))
                                {
                                // Corrects abbreviated properties so they display completely
                                String[] FullProperties = null;
                                ModelMetadata Meta = null;

                                var Accessor = ModelType.FindSubProperty(out Meta, out FullProperties, Property.Split("."));

                                Property = FullProperties.JoinLines(".");
                                }
                            else
                                {
                                Property = ModelType.SearchForProperty(Property);
                                }
                            }

                        String OperatorStr = Key;
                        Func<Expression, Expression, Expression> Operator = QueryExt.BinaryOps[Key];

                        String Search = Split2[1].Trim();

                        SearchOperation Op = new SearchOperation()
                        {
                            Property = Property,
                            OperatorStr = OperatorStr,
                            Operator = Operator,
                            Search = Search
                        };

                        if (Property == null)
                            continue;

                        if (Out.ContainsKey(Property))
                            {
                            Out[Property] = Op;
                            }
                        else
                            {
                            Out.Add(Property, Op);
                            }

                        KeyFound = true;
                        break;
                        }
                    }

                if (!KeyFound)
                    GlobalSearchTerm = SearchTerm;
                }

            return Out;
            }

        public abstract IEnumerable<IModel> GetModels();

        public abstract IEnumerable<IModel> GetModels(out int TotalItems,
            int Page = 0,
            int RowsPerPage = -1,
            String SortTerm = "",
            SortDirection SortDirection = SortDirection.Ascending,
            String GlobalSearchTerm = "",
            Dictionary<String, SearchOperation> FieldSearchOperations = null,
            ManageViewType ViewType = ManageViewType.Normal);
        }

    public class ControllerHelper<T> : ControllerHelper
        where T : class, IModel
        {
        public ManageController<T> Owner { get; set; }

        public ControllerHelper(ManageController<T> Owner)
            {
            this.Owner = Owner;
            }

        public override IEnumerable<IModel> GetModels()
            {
            int TotalItems = 0;

            return GetModels(out TotalItems);
            }

        public override IEnumerable<IModel> GetModels(out int TotalItems,
            int Page = 0,
            int RowsPerPage = -1,
            String SortTerm = "",
            SortDirection SortDirection = SortDirection.Ascending,
            String GlobalSearchTerm = "",
            Dictionary<String, SearchOperation> FieldSearchOperations = null,
            ManageViewType ViewType = ManageViewType.Normal)
            {
            return GetModels_T(out TotalItems, Page, RowsPerPage, SortTerm, SortDirection, GlobalSearchTerm, FieldSearchOperations, ViewType);
            }

        public IEnumerable<T> GetModels_T()
            {
            int TotalItems = 0;

            return GetModels_T(out TotalItems);
            }

        public IEnumerable<T> GetModels_T(out int TotalItems,
            int Page = 0,
            int RowsPerPage = -1,
            String SortTerm = "",
            SortDirection SortDirection = SortDirection.Ascending,
            String GlobalSearchTerm = "",
            Dictionary<String, SearchOperation> FieldSearchOperations = null,
            ManageViewType ViewType = ManageViewType.Normal)
            {
            FieldSearchOperations = FieldSearchOperations ?? new Dictionary<String, SearchOperation>();

            IQueryable<T> Set = (IQueryable<T>)Owner.GetModelQuery().AsQueryable();

            Set = Owner.RestrictScope(Set);

            IQueryable<T> Out = null;

            #region Global Search
            if (!String.IsNullOrEmpty(GlobalSearchTerm))
                {
                if (ControllerHelper.GlobalSearchAssumeStars && !GlobalSearchTerm.Contains("*"))
                    GlobalSearchTerm = "*" + GlobalSearchTerm + "*";

                Expression<Func<T, Boolean>> Search = QueryExt.GlobalSearchRecursive<T>(GlobalSearchTerm);

                if (Search != null)
                    Set = Set.Where(Search);
                }
            #endregion

            #region Archive Filter
            if (Owner.ArchiveActive)
                {
                if (ViewType == ManageViewType.Archive)
                    {
                    Set = Set.Where(Owner.GetArchivedCondition(true));
                    }
                else
                    {
                    Set = Set.Where(Owner.GetArchivedCondition(false));
                    }
                }
            #endregion

            #region Active Filter
            if (typeof(T).HasProperty(ControllerHelper.AutomaticFields.Active) &&
                typeof(T).Meta(ControllerHelper.AutomaticFields.Active).ModelType == typeof(Boolean))
                {
                if (ViewType.HasFlag(ManageViewType.All))
                    {
                    }
                else if (ViewType.HasFlag(ManageViewType.Inactive))
                    {
                    Expression<Func<T, Boolean>> Exp = typeof(T).GetExpression<T, Boolean>(ControllerHelper.AutomaticFields.Active);
                    Expression Equal = Expression.NotEqual(Exp.Body, Expression.Constant(true));
                    Expression Lambda = Expression.Lambda(Equal, Exp.Parameters[0]);

                    Set = Set.Where((Expression<Func<T, Boolean>>)Lambda);
                    }
                else
                    {
                    Expression<Func<T, Boolean>> Exp = typeof(T).GetExpression<T, Boolean>(ControllerHelper.AutomaticFields.Active);
                    Expression Equal = Expression.Equal(Exp.Body, Expression.Constant(true));
                    Expression Lambda = Expression.Lambda(Equal, Exp.Parameters[0]);

                    Set = Set.Where((Expression<Func<T, Boolean>>)Lambda);
                    }
                }
            #endregion

            #region Field Search Filter
            if (FieldSearchOperations != null &&
                FieldSearchOperations.Keys.Count > 0)
                {
                foreach (String Property in FieldSearchOperations.Keys)
                    {
                    Set = Set.FilterBy(FieldSearchOperations[Property]);
                    }
                }
            #endregion

            #region Sort
            if (!String.IsNullOrEmpty(SortTerm))
                {
                if (typeof(T).Meta(SortTerm).ModelType.HasInterface<IModel>(false))
                    {
                    Type t = typeof(T).Meta(SortTerm).ModelType;
                    DisplayColumnAttribute display = t.GetAttribute<DisplayColumnAttribute>();

                    if (display != null)
                        SortTerm = SortTerm + "." + display.SortColumn;
                    else
                        SortTerm = SortTerm + "." + System.Linq.Enumerable.First(t.Meta().Properties).PropertyName;
                    }

                if (SortDirection == SortDirection.Ascending)
                    {
                    Out = Set.OrderBy(SortTerm);
                    }
                else
                    {
                    Out = Set.OrderByDescending(SortTerm);
                    }
                }
            else
                {
                Out = Set.OrderBy(p => 0);
                }
            #endregion

            TotalItems = ((IQueryable<T>)Set).Count();

            if (ViewType != ManageViewType.All && RowsPerPage > 0)
                {
                int Skip = (Page - 1) * RowsPerPage;

                if (Skip > 0)
                    Out = (IOrderedQueryable<T>)Out.Skip((Page - 1) * RowsPerPage);

                if (TotalItems > RowsPerPage)
                    Out = Out.Take(RowsPerPage);
                }

            return Out;
            }
        }
    }
