using System.Web.Helpers;

namespace LMVC.Models
    {
    public interface ICustomExport
        {
        bool Active { get; set; }
        int CustomExportID { get; set; }
        string ExportType { get; set; }
        string Fields { get; set; }
        string Group { get; set; }
        string ManagementPage { get; set; }
        string Name { get; set; }
        string OverrideSort { get; set; }
        SortDirection? OverrideSortDirection { get; set; }

        string ToString();
        }
    }