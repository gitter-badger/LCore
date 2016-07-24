using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using LCore.Extensions;
using LMVC.Extensions;
using LMVC.Models;

namespace LMVC.Controllers
    {
    public abstract class SingularityControllerHelper
        {
        public const string Menu_Admin = "Admin";

        public const string Script_Singularity = "~/Scripts/singularity";
        public const string Style_Singularity = "~/Content/singularity";

        public const string Style_JQuery_Mobile = "~/Content/jquery-mobile";
        public const string Script_JQuery_Mobile = "~/Scripts/jquery-mobile";

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
        public const string Session_DuoSignRequest_ReturnUrl = "DuoSignRequest_ReturnURL";

        public const string Session_Role = "ProfileRoleSession";
        public const string Session_User = "ProfileUserSession";

        public static TimeSpan DefaultArchiveTimeSpan = new TimeSpan(180, 0, 0, 0, 0);


        public static readonly bool AllowRegister = false;
        public static readonly bool AllowExternalLogin = false;
        public static readonly bool AllowLoginCookie = false;

        public const int DefaultTableTextLength = 50;

        protected const bool GlobalSearchAssumeStars = false;

        public const int DefaultRowsPerPage = 20;


        public static string GetConfig(string Key)
            {
            return System.Configuration.ConfigurationManager.AppSettings[Key];
            }

        public static void RegisterBundles(BundleCollection Bundles, bool IncludedLib)
            {
            string Root = IncludedLib ? "~/bin/" : "~/";

            #region Singularity
            Bundles.Add(new ScriptBundle(Script_Singularity).Include(
                $"{Root}Scripts/singularity-min.js"));

            Bundles.Add(new StyleBundle(Style_Singularity).Include(
                $"{Root}Content/singularity.css",
                $"{Root}Content/singularity-forms.css"));
            #endregion

            Bundles.Add(new ScriptBundle(Script_JQuery_Mobile).Include(
                $"{Root}Scripts/jquery-mobile/jquery.mobile.custom.js"));

            Bundles.Add(new ScriptBundle(Style_JQuery_Mobile).Include(
                $"{Root}Scripts/jquery-mobile/jquery.mobile.custom.theme.css"));
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

                        if (!ModelType.Meta()?.Properties.Has(Prop => Prop.PropertyName == Property) == true)
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
            ControllerHelper.ManageViewType ViewType = ControllerHelper.ManageViewType.Normal);
        }
    public class SingularityControllerHelper<T> : SingularityControllerHelper
        where T : class, IModel
        {
        public ManageController<T> Owner { get; }

        public SingularityControllerHelper(ManageController<T> Owner)
            {
            this.Owner = Owner;
            }

        /// <exception cref="OverflowException">The number of elements in <see cref="T"/> is larger than <see cref="F:System.Int32.MaxValue" />.</exception>
        public override IEnumerable<IModel> GetModels()
            {
            int TotalItems;

            return this.GetModels(out TotalItems);
            }

        /// <exception cref="OverflowException">The number of elements in <see cref="T"/> is larger than <see cref="F:System.Int32.MaxValue" />.</exception>
        public override IEnumerable<IModel> GetModels(out int TotalItems,
            int Page = 0,
            int RowsPerPage = -1,
            string SortTerm = "",
            SortDirection SortDirection = SortDirection.Ascending,
            string GlobalSearchTerm = "",
            Dictionary<string, SearchOperation> FieldSearchOperations = null,
            ControllerHelper.ManageViewType ViewType = ControllerHelper.ManageViewType.Normal)
            {
            return this.GetModels_T(out TotalItems, Page, RowsPerPage, SortTerm, SortDirection, GlobalSearchTerm, FieldSearchOperations, ViewType);
            }

        /// <exception cref="OverflowException">The number of elements in <see cref="T"/> is larger than <see cref="F:System.Int32.MaxValue" />.</exception>
        public IEnumerable<T> GetModels_T()
            {
            int TotalItems;

            return this.GetModels_T(out TotalItems);
            }

        /// <exception cref="OverflowException">The number of elements in <see cref="T"/> is larger than <see cref="F:System.Int32.MaxValue" />.</exception>
        public IEnumerable<T> GetModels_T(out int TotalItems,
            int Page = 0,
            int RowsPerPage = -1,
            string SortTerm = "",
            SortDirection SortDirection = SortDirection.Ascending,
            string GlobalSearchTerm = "",
            Dictionary<string, SearchOperation> FieldSearchOperations = null,
            ControllerHelper.ManageViewType ViewType = ControllerHelper.ManageViewType.Normal)
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
                Set = Set.Where(ViewType == ControllerHelper.ManageViewType.Archive ?
                    this.Owner.GetArchivedCondition(true) :
                    this.Owner.GetArchivedCondition(false));
                }

            #endregion

            #region Active Filter
            if (typeof(T).HasProperty(ControllerHelper.AutomaticFields.Active) &&
                typeof(T).Meta(ControllerHelper.AutomaticFields.Active)?.ModelType == typeof(bool))
                {
                if (ViewType.HasFlag(ControllerHelper.ManageViewType.All))
                    {
                    }
                else if (ViewType.HasFlag(ControllerHelper.ManageViewType.Inactive))
                    {
                    Expression<Func<T, bool>> Exp = typeof(T).GetExpression<T, bool>(ControllerHelper.AutomaticFields.Active);
                    Expression Equal = Expression.NotEqual(Exp.Body, Expression.Constant(true));
                    Expression Lambda = Expression.Lambda(Equal, Exp.Parameters[0]);

                    Set = Set.Where((Expression<Func<T, bool>>)Lambda);
                    }
                else
                    {
                    Expression<Func<T, bool>> Exp = typeof(T).GetExpression<T, bool>(ControllerHelper.AutomaticFields.Active);
                    Expression Equal = Expression.Equal(Exp.Body, Expression.Constant(true));
                    Expression Lambda = Expression.Lambda(Equal, Exp.Parameters[0]);

                    Set = Set.Where((Expression<Func<T, bool>>)Lambda);
                    }
                }
            #endregion

            #region Field Search Filter
            if (FieldSearchOperations.Keys.Count > 0)
                {
                Set = FieldSearchOperations.Keys.Aggregate(Set, (Current, Property) => Current.FilterBy(FieldSearchOperations[Property]));
                }
            #endregion

            #region Sort
            if (!string.IsNullOrEmpty(SortTerm))
                {
                if (typeof(T).Meta(SortTerm)?.ModelType.HasInterface<IModel>() == true)
                    {
                    var Type = typeof(T).Meta(SortTerm)?.ModelType;
                    var Display = Type.GetAttribute<DisplayColumnAttribute>(false);

                    SortTerm = Display != null
                        ? $"{SortTerm}.{Display.SortColumn}"
                        : $"{SortTerm}.{Type.Meta()?.Properties.First().PropertyName}";
                    }

                Out = SortDirection == SortDirection.Ascending ?
                    Set.OrderBy(SortTerm) :
                    Set.OrderByDescending(SortTerm);
                }
            else
                {
                Out = Set.OrderBy(Item => 0);
                }
            #endregion

            TotalItems = Set.Count();

            if (ViewType != ControllerHelper.ManageViewType.All && RowsPerPage > 0)
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