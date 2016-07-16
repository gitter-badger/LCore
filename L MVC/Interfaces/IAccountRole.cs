using System;
using System.Collections.Generic;

namespace Singularity.Models
    {
    public interface IAccountRole
        {
        IModelPermissions AddedPayPermissions { get; set; }
        IModelPermissions ContractPermissions { get; set; }
        DateTime CreateDate { get; set; }
        string CreatedBy { get; set; }
        IModelPermissions CustomExportPermissions { get; set; }
        IModelPermissions DistrictPermissions { get; set; }
        IModelPermissions EmailHistoryPermissions { get; set; }
        IModelPermissions EmailJobPermissions { get; set; }
        IModelPermissions EmailTemplatePermissions { get; set; }
        IModelPermissions ErrorPermissions { get; set; }
        IModelPermissions EventPermissions { get; set; }
        IModelPermissions ExhibitHubPermissions { get; set; }
        IModelPermissions FormRequirementPermissions { get; set; }
        IModelPermissions FormsPermissions { get; set; }
        IModelPermissions FormTypePermissions { get; set; }
        string ModifiedBy { get; set; }
        DateTime? ModifyDate { get; set; }
        // ReSharper disable once InconsistentNaming
        bool RequireDuo2FA { get; set; }
        string RoleDescription { get; set; }
        int RoleID { get; set; }
        string RoleName { get; set; }
        IModelPermissions SavedSearchPermissions { get; set; }
        IModelPermissions TemplatePermissions { get; set; }
        IModelPermissions TestModelPermissions { get; set; }
        IModelPermissions TextContentPermissions { get; set; }
        IModelPermissions TimeEntryPermissions { get; set; }
        IModelPermissions TimeSheetPermissions { get; set; }
        IModelPermissions UserPermissions { get; set; }

        IModelPermissions WorkSitePermissions { get; set; }

        bool AllowAccess(IModel Model);
        }
    }