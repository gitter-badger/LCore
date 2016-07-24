using System;
using System.Collections.Generic;
using System.Linq;
using LCore.Extensions;
using System.ComponentModel.DataAnnotations;
using LMVC.Controllers;
using System.Web.Helpers;
using JetBrains.Annotations;
using LMVC.Extensions;
using LMVC.Annotations;

namespace LMVC.Models
    {
    public class ManageViewModel
        {
        public ManageViewModel(IManageController Controller)
            {
            this.Controller = Controller;
            this.Title = Controller.ManageTitle;
            }

        public IManageController Controller { get; private set; }

        public IEnumerable<IModel> Models { get; set; }
        public int TotalItems { get; set; }

        public string TypeName { get; set; }
        public Type ModelType { get; set; }

        public Dictionary<string, SearchOperation> FieldSearchTerms { get; set; }


        public string GlobalSearchTerm { get; set; }

        public string OverrideSort { get; set; }
        public SortDirection OverrideSortDirection { get; set; }

        public int Page { get; set; }
        public int TotalPages { get; set; }

        public const int ShowSurroundingPages = 3;

        public const bool AlwaysShowPaginationFirstLast = true;
        public const string FirstPageText = "<<";
        public const string PreviousPageText = "<";
        public const string NextPageText = ">";
        public const string LastPageText = ">>";

        public ControllerHelper.ManageViewType ViewType { get; set; }

        public string InlineEditID { get; set; }

        public string GetGlobalSearchCombined([CanBeNull]params string[] Without)
            {
            Without = Without ?? new string[] { };

            if (this.FieldSearchTerms == null)
                this.FieldSearchTerms = new Dictionary<string, SearchOperation>();

            List<string> Terms = (from Key in this.FieldSearchTerms.Keys select this.FieldSearchTerms[Key] into Op where !Without.Has(Op.Property) select Op.Property + Op.OperatorStr + Op.Search).ToList();

            if (!Without.Has("Global") && !string.IsNullOrEmpty(this.GlobalSearchTerm))
                Terms.Add(this.GlobalSearchTerm);

            return Terms.JoinLines("|");
            }

        public List<string> GetVisibleColumns()
            {
            List<string> Columns = this.ModelType.Meta().Properties.Select(Prop => Prop.PropertyName).ToList();

            var Out = new List<string>();

            if (this.FieldSearchTerms?.Keys.Count > 0)
                {
                foreach (var Op in this.FieldSearchTerms.Values)
                    {
                    if (!Columns.Has(Op.Property))
                        {
                        Columns.Add(Op.Property);
                        }
                    }
                }


            foreach (string Str in Columns)
                {
                if (Str.Contains("."))
                    {
                    Out.Add(Str);
                    }
                else
                    {
                    var Meta = this.ModelType.Meta(Str);

                    if (this.FieldSearchTerms?.ContainsKey(Str) == true)
                        {
                        Out.Add(Str);
                        }
                    else if (Meta.HasAttribute<KeyAttribute>(true))
                        {
                        // Hide Column because of Primary Key
                        }
                    else if (Meta.AdditionalValues.ContainsKey(HideManageViewColumnAttribute.Key)
                        && Meta.AdditionalValues[HideManageViewColumnAttribute.Key] as bool? == true)
                        {
                        // Hide Column because of Attribute
                        }
                    else
                        {
                        Out.Add(Str);
                        }
                    }
                }

            return Out;
            }

        public string GetSearchSuggestions()
            {
            string Out = "";

            foreach (string PropertyName in this.GetVisibleColumns())
                {
                Out += $"\'{PropertyName}:\',";

                if (!PropertyName.Contains("."))
                    {
                    // Show suggestions for related model fields
                    var Meta = this.ModelType.Meta(PropertyName);

                    if (Meta.ModelType.HasInterface<IModel>())
                        {
                        Out = Meta.ModelType.Meta().Properties.Aggregate(Out, (Current, SubPropertyName) => Current + $"\'{PropertyName}.{SubPropertyName.PropertyName}:\',");
                        }
                    }
                }

            return Out;
            }

        public string FriendlyModelTypeName => this.ModelType.GetFriendlyTypeName();

        public string FriendlyModelTypeNamePlural => this.FriendlyModelTypeName.Pluralize();

        public string ModelTypeCssClass => this.ModelType.Name.Humanize().ToUrlSlug();

        private string _Title;
        public string Title
            {
            get
                {
                return this._Title ?? $"Manage {this.ViewTypePrefix} {this.FriendlyModelTypeNamePlural}";
                }
            set
                {
                this._Title = value;
                }
            }

        public string ViewTypePrefix
            {
            get
                {
                if (this.ViewType.HasFlag(ControllerHelper.ManageViewType.All))
                    {
                    return "All";
                    }
                if (this.ViewType.HasFlag(ControllerHelper.ManageViewType.Archive))
                    {
                    return "Archived";
                    }
                return this.ViewType.HasFlag(ControllerHelper.ManageViewType.Inactive) ? "Inactive" : "";
                }
            }
        }
    }