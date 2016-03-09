
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

using LCore;

using Singularity;
using Singularity.Context;
using Singularity.Controllers;
using Singularity.Annotations;


namespace Singularity.Models
    {
    public class CustomExport : IModel, IGrouped
        {
        public const String DefaultName = "Default";

        [Key]
        public int CustomExportID { get; set; }

        [Required]
        public String Name { get; set; }

        public String Group { get; set; }

        [FieldType_DropdownContextManageControllers]
        [FieldLoadFromQueryString]
        public String ManagementPage { get; set; }

        [Required]
        [FieldType_DropdownContextModelTypes]
        [FieldUpdateRefreshPage]
        [FieldLoadFromQueryString]
        public String ExportType { get; set; }

        [FieldType_DropdownContextModelFields("ExportType")]
        public String OverrideSort { get; set; }

        public SortDirection? OverrideSortDirection { get; set; }

        [DataType(DataType.MultilineText)]
        public String Fields
            {
            get
                {
                return _Fields;
                }
            set
                {
                _Fields = value ?? "";

                // Clean up fields if needed
                if (_Fields.Length > 0)
                    {
                    String[] FieldList = _Fields.Trim().Lines();

                    FieldList = FieldList.Collect((s) =>
                        {
                            s = s.Trim();
                            if (s == "")
                                return null;
                            return s;
                        });

                    FieldList = FieldList.RemoveDuplicates().Array();
                    _Fields = FieldList.JoinLines();
                    }
                }
            }

        private String _Fields { get; set; }

        [HideManageViewColumn]
        public Boolean Active { get; set; }

        public override string ToString()
            {
            return Name;
            }

        public static CustomExport Find(ModelContext DbContext, int CustomExportID)
            {
            return DbContext.GetDBSet<CustomExport>().Where(
                ex => ex.Active &&
                    ex.CustomExportID == CustomExportID)
                .FirstOrDefault();
            }

        public static IQueryable<CustomExport> Find(ModelContext DbContext, Type ModelType, String ControllerTypeName)
            {
            return DbContext.GetDBSet<CustomExport>().Where(
                e => e.Active == true &&
                    e.ExportType == ModelType.FullName &&
                    (e.ManagementPage == null ||
                    e.ManagementPage == "" ||
                    e.ManagementPage == ControllerTypeName));
            }



        }
    }
