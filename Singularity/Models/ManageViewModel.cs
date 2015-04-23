using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LCore;
using System.ComponentModel.DataAnnotations;
using Singularity.Controllers;

namespace Singularity.Models
{
    public class ManageViewModel
    {
        public ManageViewModel(ManageController Controller)
        {
            this.Controller = Controller;
            this.Title = Controller.ManageTitle;
        }

        public ManageController Controller { get; set; }

        public List<IModel> Models { get; set; }
        public int TotalItems { get; set; }

        public String TypeName { get; set; }
        public Type ModelType { get; set; }

        public Dictionary<String, SearchOperation> FieldSearchTerms { get; set; }


        public String GlobalSearchTerm { get; set; }

        public String OverrideSort { get; set; }
        public String OverrideSortDirection { get; set; }

        public int Page { get; set; }
        public int TotalPages { get; set; }

        public int ShowSurroundingPages = 3;

        public Boolean AlwaysShowPaginationFirstLast = true;
        public String FirstPageText = "<<";
        public String PreviousPageText = "<";
        public String NextPageText = ">";
        public String LastPageText = ">>";

        public Boolean ShowInactiveRecords { get; set; }

        public String InlineEditID { get; set; }

        public String GetGlobalSearchCombined(params String[] Without)
        {
            Without = Without ?? new String[] { };

            List<String> Terms = new List<string>();

            if (FieldSearchTerms == null)
                FieldSearchTerms = new Dictionary<string, SearchOperation>();

            foreach (String Key in FieldSearchTerms.Keys)
            {
                SearchOperation Op = FieldSearchTerms[Key];

                if (Without.Has(Op.Property))
                {
                    continue;
                }

                Terms.Add(Op.Property + Op.OperatorStr + Op.Search);
            }

            if (!Without.Has("Global") && !String.IsNullOrEmpty(GlobalSearchTerm))
                Terms.Add(GlobalSearchTerm);

            return Terms.JoinLines("|");
        }

        public List<String> GetVisibleColumns()
        {
            List<String> Columns = System.Linq.Enumerable.ToList(this.ModelType.Meta().Properties.Select(m => m.PropertyName));

            List<String> Out = new List<String>();

            if (this.FieldSearchTerms != null &&
                this.FieldSearchTerms.Keys.Count > 0)
            {
                foreach (SearchOperation Op in this.FieldSearchTerms.Values)
                {
                    if (!Columns.Has(Op.Property))
                    {
                        Columns.Add(Op.Property);
                    }
                }
            }


            foreach (String s in Columns)
            {
                if (s.Contains("."))
                {
                    Out.Add(s);
                }
                else
                {
                    System.Web.ModelBinding.ModelMetadata Meta = this.ModelType.Meta(s);

                    if (this.FieldSearchTerms.ContainsKey(s))
                    {
                        Out.Add(s);
                    }
                    else if (Meta.HasAttribute<KeyAttribute>())
                    {
                        // Hide Column because of Primary Key
                    }
                    else if (Meta.AdditionalValues.ContainsKey(HideManageViewColumnAttribute.Key)
                        && Meta.AdditionalValues[HideManageViewColumnAttribute.Key] as Boolean? == true)
                    {
                        // Hide Column because of Attribute
                    }
                    else
                    {
                        Out.Add(s);
                    }
                }
            }

            return Out;
        }

        public String GetSearchSuggestions()
        {
            String Out = "";

            foreach (String PropertyName in this.GetVisibleColumns())
            {
                Out += "'" + PropertyName + ":',";

                if (!PropertyName.Contains("."))
                {
                    // Show suggestions for related model fields
                    System.Web.ModelBinding.ModelMetadata Meta = this.ModelType.Meta(PropertyName);

                    if (Meta.ModelType.HasInterface(typeof(IModel), true))
                    {
                        foreach (System.Web.ModelBinding.ModelMetadata SubPropertyName in Meta.ModelType.Meta().Properties)
                        {
                            Out += "'" + PropertyName + "." + SubPropertyName.PropertyName + ":',";
                        }
                    }
                }
            }

            return Out;
        }

        public String FriendlyModelTypeName
        {
            get
            {
                return this.ModelType.GetFriendlyTypeName();
            }
        }

        public String FriendlyModelTypeNamePlural
        {
            get
            {
                return this.FriendlyModelTypeName.Pluralize();
            }
        }

        public String ModelTypeCSSClass
        {
            get
            {
                return ModelType.Name.Humanize().ToUrlSlug();
            }
        }

        private String _Title = null;
        public String Title
        {
            get
            {
                return _Title ?? "Manage " + (this.ShowInactiveRecords ? "Inactive " : "") + this.FriendlyModelTypeNamePlural;
            }
            set
            {
                _Title = value;
            }
        }


        public Object Route_Page(int Page)
        {
            return new
                {
                    Page = Page,
                    SortTerm = this.OverrideSort,
                    SortDirection = this.OverrideSortDirection,
                    GlobalSearchTerm = this.GlobalSearchTerm,
                    FieldSearchTerms = this.GetGlobalSearchCombined("Global"),
                    ShowInactiveRecords = this.ShowInactiveRecords,
                };
        }

        public Object Route_Search()
        {
            return new
                {
                    Page = 1,
                    SortTerm = "",
                    SortDirection = "ASC",
                    GlobalSearchTerm = "",
                    FieldSearchTerms = "",
                    ShowInactiveRecords = this.ShowInactiveRecords,
                };
        }

        public Object Route_RemoveFilter(String Property)
        {
            return new
            {
                SortTerm = this.OverrideSort,
                SortDirection = this.OverrideSortDirection,
                GlobalSearchTerm = this.GlobalSearchTerm,
                FieldSearchTerms = this.GetGlobalSearchCombined("Global", Property),
                ShowInactiveRecords = this.ShowInactiveRecords,
            };
        }

        public Object Route_SortColumn(String ColumnName)
        {
            return new
                {
                    Page = 1,
                    SortTerm = ColumnName,
                    SortDirection = (this.OverrideSort == ColumnName &&
                        this.OverrideSortDirection == "ASC" ? "DESC" : "ASC"),
                    GlobalSearchTerm = this.GlobalSearchTerm,
                    FieldSearchTerms = this.GetGlobalSearchCombined("Global"),
                    ShowInactiveRecords = this.ShowInactiveRecords,
                };
        }

        public Object Route_ClearSearch()
        {
            return new
                {
                    Page = 1,
                    SortTerm = "",
                    SortDirection = "ASC",
                    GlobalSearchTerm = "",
                    FieldSearchTerms = "",
                    ShowInactiveRecords = this.ShowInactiveRecords,
                };
        }

        public Object Route_Export()
        {
            return new
                {
                    SortTerm = this.OverrideSort,
                    SortDirection = this.OverrideSortDirection,
                    GlobalSearchTerm = this.GlobalSearchTerm,
                    FieldSearchTerms = this.GetGlobalSearchCombined("Global"),
                    ShowInactiveRecords = this.ShowInactiveRecords,
                };
        }

        public Object Route_ToggleInactive()
        {
            return new
                {
                    Page = 1,
                    SortTerm = this.OverrideSort,
                    SortDirection = this.OverrideSortDirection,
                    GlobalSearchTerm = this.GlobalSearchTerm,
                    FieldSearchTerms = this.GetGlobalSearchCombined("Global"),
                    ShowInactiveRecords = !this.ShowInactiveRecords,
                };
        }

        public Object Route_DetailView(IModel Model, HttpRequestBase Request)
        {
            return new
            {
                ID = Model.GetID(),
                ReturnURL = Request.Url,
            };
        }

        public Object Route_InlineEdit(IModel Model, HttpRequestBase Request)
        {
            return new
            {
                Page = this.Page,
                SortTerm = this.OverrideSort,
                SortDirection = this.OverrideSortDirection,
                GlobalSearchTerm = this.GlobalSearchTerm,
                FieldSearchTerms = this.GetGlobalSearchCombined("Global"),
                ShowInactiveRecords = this.ShowInactiveRecords,
                InlineEdit = Model.GetID(),
            };
        }

        public Object Route_Edit(IModel Model, HttpRequestBase Request)
        {
            return new
            {
                ID = Model.GetID(),
                ReturnURL = Request.Url,
            };
        }

        public Object Route_Create(HttpRequestBase Request)
        {
            return new
            {
                ReturnURL = Request.Url,
            };
        }

        public Object Route_Delete(IModel Model, HttpRequestBase Request)
        {
            return new
            {
                ID = Model.GetID(),
                ReturnURL = Request.Url,
            };
        }
    }
}
