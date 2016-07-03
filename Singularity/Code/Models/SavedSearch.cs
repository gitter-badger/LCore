using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Helpers;
using System.ComponentModel;
using LCore.Naming;
using Singularity.Context;
using Singularity.Annotations;
using Singularity.Extensions;
using LCore.Interfaces;

namespace Singularity.Models
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
        [FieldType_Hidden]
        public string SearchType { get; set; }

        [HideManageViewColumn]
        [NotMapped]
        [FriendlyName("Search Type")]
        public string SearchType_ReadOnly => this.SearchType;

        [FieldLoadFromQueryString]
        [FieldType_Hidden]
        public string ControllerName { get; set; }

        [HideManageViewColumn]
        [NotMapped]
        [FriendlyName("Controller Name")]
        public string ControllerName_ReadOnly => this.ControllerName;

        [FieldLoadFromQueryString]
        [FieldType_DropdownContextModelFields("SearchType")]
        public string OverrideSort { get; set; }

        [FieldLoadFromQueryString]
        public SortDirection? OverrideSortDirection { get; set; }

        [FieldLoadFromQueryString]
        public string GlobalSearch { get; set; }

        [FieldLoadFromQueryString]
        public string FieldSearch { get; set; }

        [ReadOnly(true)]
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
                e => e.Active &&
                    e.SearchType == TypeName &&
                    e.ControllerName == ControllerName &&
                    e.Default != true);
            }

        public static SavedSearch FindDefault(ModelContext DbContext, string TypeName, string ControllerName, bool Autocreate)
            {
            var Out = DbContext.GetDBSet<SavedSearch>(
                ).FirstOrDefault(e => e.Active &&
                    e.SearchType == TypeName &&
                    e.ControllerName == ControllerName &&
                    e.Default == true);

            if (Out == null && Autocreate)
                {
                Out = new SavedSearch();
                Out.Initialize();

                Out.SearchType = TypeName;
                Out.ControllerName = ControllerName;
                Out.Default = true;
                Out.Name = $"Default Search for {ControllerName} page";

                DbContext.GetDBSet<SavedSearch>().Add(Out);
                DbContext.SaveChanges();
                }

            return Out;
            }
        }
    }
