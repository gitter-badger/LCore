using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using LCore.Extensions;
using Singularity.Context;
using Singularity.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Helpers;
using Singularity.Extensions;


namespace Singularity.Controllers
    {
    public abstract class ControllerHelper
        {
        public const string Menu_Admin = "Admin";

        public const string Script_Singularity = "~/Scripts/singularity";
        public const string Style_Singularity = "~/Content/singularity";

        public const string Style_JQuery_Mobile = "~/Content/jquery-mobile";
        public const string Script_JQuery_Mobile = "~/Scripts/jquery-mobile";

        public const string Script_MVCL_Chance = "~/Scripts/mvcl/chance";
        public const string Script_MVCL_qTip = "~/Scripts/mvcl/qTip";
        public const string Script_MVCL_jQueryCookie = "~/Scripts/mvcl/jquery.cookie";
        public const string Script_MVCL_jQueryMousewheel = "~/Scripts/mvcl/jquery.mousewheel";
        public const string Script_MVCL_jQueryTimepicker = "~/bundles/mvcl/jquery.timepicker";

        public const string ViewBag_ManageModel = "ManageModel";
        public const string ViewBag_EditModel = "EditModel";

        public const string Config_EnableDuoAuth = "EnableDuoAuth";
        public const string Config_DuoHost = "DuoHost";
        public const string Config_DuoIKey = "DuoIKey";
        public const string Config_DuoSKey = "DuoSKey";
        public const string Config_DuoAKey = "DuoAKey";

        public const string StatusMessage_Temporary = "TempStatusMessage";
        public const string StatusMessage_TemporaryIcon = "TempStatusMessageIcon";

        public const string Session_DuoSignRequest = "DuoSignRequest";
        public const string Session_DuoSignRequest_ReturnURL = "DuoSignRequest_ReturnURL";

        public const string Session_Role = "ProfileRoleSession";
        public const string Session_User = "ProfileUserSession";

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

            All = Create | Display | Edit | Export | FieldHeader | TableCell
            }

        [Flags]
        public enum ManageViewType
            {
            Normal = 1,
            Inactive = 2,
            Archive = 4,

            All = Normal | Inactive | Archive
            }

        public static class AutomaticFields
            {
            public const string Active = "Active";
            public const string Created = "Created";
            public const string Updated = "Updated";
            public const string Archived = "Archived";

            }

        public static readonly bool AllowRegister = false;
        public static readonly bool AllowExternalLogin = false;
        public static readonly bool AllowLoginCookie = false;

        public const int DefaultTableTextLength = 50;

        public const bool GlobalSearchAssumeStars = false;

        public const int DefaultRowsPerPage = 20;

        public static void HandleError(HttpContextBase HttpContext, Exception Ex)
            {
            var Context = ContextProviderFactory.GetCurrent().GetContext(HttpContext.Session);

            if (Context.ContextTypes.Has(typeof(Error)))
                {
                DbSet<Error> ErrorsTable = Context.GetDBSet<Error>();

                try
                    {
                    var Error = new Error
                        {
                        Message = Ex.Message,
                        FullDetails = Ex.ToString(),
                        Created = DateTime.Now,
                        Active = true,
                        URL = HttpContext.Request.Url?.AbsoluteUri
                        };

                    if (ErrorsTable.Count(
                        e => e.FullDetails == Error.FullDetails &&
                        e.URL == Error.URL &&
                        // e.Created.Date == Error.Created.Date &&
                        e.Active) > 0)
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

        public static string GetConfig(string Key)
            {
            return System.Configuration.ConfigurationManager.AppSettings[Key];
            }

        public static void RegisterBundles(BundleCollection bundles, bool IncludedLib)
            {
            string Root = IncludedLib ? "~/bin/" : "~/";

            #region Singularity
            bundles.Add(new ScriptBundle(Script_Singularity).Include(
                $"{Root}Scripts/singularity-min.js"));

            bundles.Add(new StyleBundle(Style_Singularity).Include(
                $"{Root}Content/singularity.css",
                $"{Root}Content/singularity-forms.css"));
            #endregion

            bundles.Add(new ScriptBundle(Script_JQuery_Mobile).Include(
                $"{Root}Scripts/jquery-mobile/jquery.mobile.custom.js"));

            bundles.Add(new ScriptBundle(Style_JQuery_Mobile).Include(
                $"{Root}Scripts/jquery-mobile/jquery.mobile.custom.theme.css"));

            bundles.Add(new ScriptBundle(Script_MVCL_Chance).Include(
                $"{Root}Scripts/chance.js"));

            bundles.Add(new ScriptBundle(Script_MVCL_qTip).Include(
                $"{Root}Scripts/qTip.js"));

            bundles.Add(new ScriptBundle(Script_MVCL_jQueryCookie).Include(
                $"{Root}Scripts/jquery.cookie.js"));

            bundles.Add(new ScriptBundle(Script_MVCL_jQueryMousewheel).Include(
                $"{Root}Scripts/jquery.mousewheel.js"));

            bundles.Add(new ScriptBundle(Script_MVCL_jQueryTimepicker).Include(
                      "~/Scripts/jquery.timepicker.js"));
            }

        public Dictionary<string, SearchOperation> ExtractSearchTerms(ref string GlobalSearchTerm, Type ModelType)
            {
            var Out = new Dictionary<string, SearchOperation>();

            GlobalSearchTerm = GlobalSearchTerm ?? "";

            string[] Split = GlobalSearchTerm.Contains("|") ?
                GlobalSearchTerm.Split("|") :
                new[] { GlobalSearchTerm };

            GlobalSearchTerm = "";

            List<string> Keys = QueryExt.BinaryOps.Keys.List();

            foreach (string SearchTerm in Split)
                {
                bool KeyFound = false;

                foreach (string Key in Keys)
                    {
                    if (SearchTerm.Contains(Key))
                        {
                        string[] Split2 = SearchTerm.Split(Key);

                        string Property = Split2[0].RemoveAll(" ");

                        if (Property == null)
                            continue;

                        if (!ModelType.Meta().Properties.Has(p => p.PropertyName == Property))
                            {
                            if (Property.Contains("."))
                                {
                                // Corrects abbreviated properties so they display completely
                                string[] FullProperties;
                                ModelMetadata Meta;

                                ModelType.FindSubProperty(out Meta, out FullProperties, Property.Split("."));

                                Property = FullProperties.JoinLines(".");
                                }
                            else
                                {
                                Property = ModelType.SearchForProperty(Property);
                                }
                            }

                        string OperatorStr = Key;
                        Func<Expression, Expression, Expression> Operator = QueryExt.BinaryOps[Key];

                        string Search = Split2[1].Trim();

                        var Op = new SearchOperation
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
            string SortTerm = "",
            SortDirection SortDirection = SortDirection.Ascending,
            string GlobalSearchTerm = "",
            Dictionary<string, SearchOperation> FieldSearchOperations = null,
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
            int TotalItems;

            return this.GetModels(out TotalItems);
            }

        public override IEnumerable<IModel> GetModels(out int TotalItems,
            int Page = 0,
            int RowsPerPage = -1,
            string SortTerm = "",
            SortDirection SortDirection = SortDirection.Ascending,
            string GlobalSearchTerm = "",
            Dictionary<string, SearchOperation> FieldSearchOperations = null,
            ManageViewType ViewType = ManageViewType.Normal)
            {
            return this.GetModels_T(out TotalItems, Page, RowsPerPage, SortTerm, SortDirection, GlobalSearchTerm, FieldSearchOperations, ViewType);
            }

        public IEnumerable<T> GetModels_T()
            {
            int TotalItems;

            return this.GetModels_T(out TotalItems);
            }

        public IEnumerable<T> GetModels_T(out int TotalItems,
            int Page = 0,
            int RowsPerPage = -1,
            string SortTerm = "",
            SortDirection SortDirection = SortDirection.Ascending,
            string GlobalSearchTerm = "",
            Dictionary<string, SearchOperation> FieldSearchOperations = null,
            ManageViewType ViewType = ManageViewType.Normal)
            {
            FieldSearchOperations = FieldSearchOperations ?? new Dictionary<string, SearchOperation>();

            IQueryable<T> Set = this.Owner.GetModelQuery().AsQueryable();

            Set = this.Owner.RestrictScope(Set);

            IQueryable<T> Out;

            #region Global Search
            if (!string.IsNullOrEmpty(GlobalSearchTerm))
                {
#pragma warning disable 162
                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                if (GlobalSearchAssumeStars && !GlobalSearchTerm.Contains("*"))
                    // ReSharper disable once HeuristicUnreachableCode
                    GlobalSearchTerm = $"*{GlobalSearchTerm}*";
#pragma warning restore 162

                Expression<Func<T, bool>> Search = QueryExt.GlobalSearchRecursive<T>(GlobalSearchTerm);

                if (Search != null)
                    Set = Set.Where(Search);
                }
            #endregion

            #region Archive Filter
            if (this.Owner.ArchiveActive)
                {
                Set = Set.Where(ViewType == ManageViewType.Archive ?
                    this.Owner.GetArchivedCondition(true) :
                    this.Owner.GetArchivedCondition(false));
                }

            #endregion

            #region Active Filter
            if (typeof(T).HasProperty(AutomaticFields.Active) &&
                typeof(T).Meta(AutomaticFields.Active).ModelType == typeof(bool))
                {
                if (ViewType.HasFlag(ManageViewType.All))
                    {
                    }
                else if (ViewType.HasFlag(ManageViewType.Inactive))
                    {
                    Expression<Func<T, bool>> Exp = typeof(T).GetExpression<T, bool>(AutomaticFields.Active);
                    Expression Equal = Expression.NotEqual(Exp.Body, Expression.Constant(true));
                    Expression Lambda = Expression.Lambda(Equal, Exp.Parameters[0]);

                    Set = Set.Where((Expression<Func<T, bool>>)Lambda);
                    }
                else
                    {
                    Expression<Func<T, bool>> Exp = typeof(T).GetExpression<T, bool>(AutomaticFields.Active);
                    Expression Equal = Expression.Equal(Exp.Body, Expression.Constant(true));
                    Expression Lambda = Expression.Lambda(Equal, Exp.Parameters[0]);

                    Set = Set.Where((Expression<Func<T, bool>>)Lambda);
                    }
                }
            #endregion

            #region Field Search Filter
            if (FieldSearchOperations.Keys.Count > 0)
                {
                Set = FieldSearchOperations.Keys.Aggregate(Set, (current, Property) => current.FilterBy(FieldSearchOperations[Property]));
                }
            #endregion

            #region Sort
            if (!string.IsNullOrEmpty(SortTerm))
                {
                if (typeof(T).Meta(SortTerm).ModelType.HasInterface<IModel>(false))
                    {
                    var t = typeof(T).Meta(SortTerm).ModelType;
                    var display = t.GetAttribute<DisplayColumnAttribute>(false);

                    SortTerm = display != null ? $"{SortTerm}.{display.SortColumn}" : $"{SortTerm}.{Enumerable.First(t.Meta().Properties).PropertyName}";
                    }

                Out = SortDirection == SortDirection.Ascending ?
                    Set.OrderBy(SortTerm) :
                    Set.OrderByDescending(SortTerm);
                }
            else
                {
                Out = Set.OrderBy(p => 0);
                }
            #endregion

            TotalItems = Set.Count();

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
