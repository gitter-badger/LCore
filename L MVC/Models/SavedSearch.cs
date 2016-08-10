using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Helpers;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using LCore.Naming;
using LMVC.Context;
using LMVC.Annotations;
using LMVC.Extensions;
using LCore.Interfaces;

namespace LMVC.Models
    {
    public class SavedSearch : IModel, IGrouped
        {
        public const string DefaultName = "Default";

        [Key]
        public int SavedSearchID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Group { get; set; }

        [FieldLoadFromQueryString]
        [FieldTypeHidden]
        public string SearchType { get; set; }

        [HideManageViewColumn]
        [NotMapped]
        [FriendlyName("Search Type")]
        public string SearchTypeReadOnly => this.SearchType;

        [FieldLoadFromQueryString]
        [FieldTypeHidden]
        public string ControllerName { get; set; }

        [HideManageViewColumn]
        [NotMapped]
        [FriendlyName("Controller Name")]
        public string ControllerNameReadOnly => this.ControllerName;

        [FieldLoadFromQueryString]
        [FieldTypeDropdownContextModelFields("SearchType")]
        public string OverrideSort { get; set; }

        [FieldLoadFromQueryString]
        public SortDirection? OverrideSortDirection { get; set; }

        [FieldLoadFromQueryString]
        public string GlobalSearch { get; set; }

        [FieldLoadFromQueryString]
        public string FieldSearch { get; set; }

        [ReadOnly(isReadOnly: true)]
        public bool? Default { get; set; }

        [HideManageViewColumn]
        public bool Active { get; set; }

        public override string ToString()
            {
            return this.Name;
            }

        public static IQueryable<SavedSearch> Find(ModelContext DbContext, string TypeName, string ControllerName)
            {
            return DbContext.GetDBSet<SavedSearch>().Where(
                Search => Search.Active &&
                    Search.SearchType == TypeName &&
                    Search.ControllerName == ControllerName &&
                    Search.Default != true);
            }

        public static SavedSearch FindDefault(IModelContext DbContext, string TypeName, string ControllerName, bool Autocreate)
            {
            DbSet<SavedSearch> SearchSet = DbContext.GetDBSet<SavedSearch>();
            var Out = SearchSet.FirstOrDefault(Search
                => Search.Active &&
                    Search.SearchType == TypeName &&
                    Search.ControllerName == ControllerName &&
                    Search.Default == true);

            if (Out == null && Autocreate)
                {
                Out = new SavedSearch();
                Out.Initialize();

                Out.SearchType = TypeName;
                Out.ControllerName = ControllerName;
                Out.Default = true;
                Out.Name = $"Default Search for {ControllerName} page";

                // ReSharper disable once PossibleNullReferenceException
                SearchSet.Add(Out);

                try
                    {
                    DbContext.SaveChanges();
                    }
                catch (DbUpdateException) { }
                catch (DbEntityValidationException) { }
                }

            return Out;
            }
        }
    }
