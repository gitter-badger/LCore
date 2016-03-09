using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web;
using System.Web.Security;
using System.Web.Helpers;
using System.ComponentModel;
using System.Web.Mvc;

using LCore;

using Singularity;
using Singularity.Context;
using Singularity.Controllers;
using Singularity.Annotations;
using Singularity.Extensions;

namespace Singularity.Models
    {
    public class SavedSearch : IModel, IGrouped
        {
        public const String DefaultName = "Default";

        [Key]
        public int SavedSearchID { get; set; }

        [Required]
        public String Name { get; set; }

        public String Group { get; set; }

        [FieldLoadFromQueryString]
        [FieldType_Hidden]
        public String SearchType { get; set; }

        [HideManageViewColumn]
        [NotMapped]
        [FriendlyName("Search Type")]
        public String SearchType_ReadOnly
            {
            get
                {
                return SearchType;
                }
            }

        [FieldLoadFromQueryString]
        [FieldType_Hidden]
        public String ControllerName { get; set; }

        [HideManageViewColumn]
        [NotMapped]
        [FriendlyName("Controller Name")]
        public String ControllerName_ReadOnly
            {
            get
                {
                return ControllerName;
                }
            }

        [FieldLoadFromQueryString]
        [FieldType_DropdownContextModelFields("SearchType")]
        public String OverrideSort { get; set; }

        [FieldLoadFromQueryString]
        public SortDirection? OverrideSortDirection { get; set; }

        [FieldLoadFromQueryString]
        public String GlobalSearch { get; set; }

        [FieldLoadFromQueryString]
        public String FieldSearch { get; set; }

        [ReadOnly(true)]
        public Boolean? Default { get; set; }

        [HideManageViewColumn]
        public Boolean Active { get; set; }

        public override string ToString()
            {
            return Name;
            }

        public static IQueryable<SavedSearch> Find(ModelContext DbContext, String TypeName, String ControllerName)
            {
            return DbContext.GetDBSet<SavedSearch>().Where(
                e => e.Active == true &&
                    e.SearchType == TypeName &&
                    e.ControllerName == ControllerName &&
                    e.Default != true);
            }

        public static SavedSearch FindDefault(ModelContext DbContext, String TypeName, String ControllerName, Boolean Autocreate)
            {
            SavedSearch Out = DbContext.GetDBSet<SavedSearch>().Where(
                e => e.Active == true &&
                    e.SearchType == TypeName &&
                    e.ControllerName == ControllerName &&
                    e.Default == true).FirstOrDefault();

            if (Out == null && Autocreate)
                {
                Out = new SavedSearch();
                Out.Initialize();

                Out.SearchType = TypeName;
                Out.ControllerName = ControllerName;
                Out.Default = true;
                Out.Name = "Default Search for " + ControllerName + " page";

                DbContext.GetDBSet<SavedSearch>().Add(Out);
                DbContext.SaveChanges();
                }

            return Out;
            }
        }
    }
