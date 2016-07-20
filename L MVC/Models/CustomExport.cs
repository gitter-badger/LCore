
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web.Helpers;


using LCore.Extensions;
using LMVC.Context;
using LMVC.Annotations;
using LCore.Interfaces;

namespace LMVC.Models
    {
    public class CustomExport : IModel, IGrouped, ICustomExport
        {
        public const string DefaultName = "Default";

        [Key]
        public int CustomExportID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Group { get; set; }

        [FieldTypeDropdownContextManageControllers]
        [FieldLoadFromQueryString]
        public string ManagementPage { get; set; }

        [Required]
        [FieldTypeDropdownContextModelTypes]
        [FieldUpdateRefreshPage]
        [FieldLoadFromQueryString]
        public string ExportType { get; set; }

        [FieldTypeDropdownContextModelFields("ExportType")]
        public string OverrideSort { get; set; }

        public SortDirection? OverrideSortDirection { get; set; }

        [DataType(DataType.MultilineText)]
        public string Fields
            {
            get
                {
                return this._Fields;
                }
            set
                {
                    this._Fields = value ?? "";

                // Clean up fields if needed
                if (this._Fields.Length > 0)
                    {
                    string[] FieldList = this._Fields.Trim().Lines();

                    FieldList = FieldList.Collect(Field =>
                        {
                            Field = Field.Trim();
                            return Field == "" ? null : Field;
                        });

                    FieldList = FieldList.RemoveDuplicates().Array();
                        this._Fields = FieldList.JoinLines();
                    }
                }
            }

        private string _Fields { get; set; }

        [HideManageViewColumn]
        public bool Active { get; set; }

        public override string ToString()
            {
            return this.Name;
            }

        public static CustomExport Find(IModelContext DbContext, int CustomExportID)
            {
            return DbContext.GetDBSet<CustomExport>()
                .FirstOrDefault(Export => Export.Active &&
                    Export.CustomExportID == CustomExportID);
            }

        public static IQueryable<CustomExport> Find(IModelContext DbContext, Type ModelType, string ControllerTypeName)
            {
            return DbContext.GetDBSet<CustomExport>().Where(
                Export => Export.Active &&
                    Export.ExportType == ModelType.FullName &&
                    (Export.ManagementPage == null ||
                    Export.ManagementPage == "" ||
                    Export.ManagementPage == ControllerTypeName));
            }
        }
    }
