using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Singularity.Annotations;
using Singularity.Models;

namespace SingularityInstanceClasses.Models
    {
    [Table("Roles")]
    public class Role : IModel
        {
        [Key]
        public int RoleID { get; set; }

        [Required]
        [FieldGlobalSearch]
        public string Name { get; set; }

        public string Description { get; set; }

        [FieldNoToken]
        public bool ViewPastForms { get; set; }
        public bool AllowLogin { get; set; }
        public int TimeSheetAlertDays { get; set; }
        [FieldNoToken]
        public bool ShowAdminSettingsPage { get; set; }
        [FieldNoToken]
        public bool ShowHomePage { get; set; }
        [FieldNoToken]
        public bool ShowFormsPage { get; set; }
        [FieldNoToken]
        public bool ShowTimeEntryPage { get; set; }
        [FieldNoToken]
        public bool View_TimeSheets_Own { get; set; }
        [FieldNoToken]
        public bool View_TimeSheets_District { get; set; }
        [FieldNoToken]
        public bool View_TimeSheets_All { get; set; }
        [FieldNoToken]
        public bool View_Alerts_Time { get; set; }
        [FieldNoToken]
        public bool View_Alerts_Forms { get; set; }
        [FieldNoToken]
        public bool ShowApplicantsPage { get; set; }
        [FieldNoToken]
        public bool View_Forms_Own { get; set; }
        [FieldNoToken]
        public bool View_Forms_District { get; set; }
        [FieldNoToken]
        public bool View_Forms_All { get; set; }
        [FieldNoToken]
        public bool View_RecentActivity_Own { get; set; }
        [FieldNoToken]
        public bool View_RecentActivity_District { get; set; }
        [FieldNoToken]
        public bool View_RecentActivity_All { get; set; }
        [FieldNoToken]
        public bool View_Users_All { get; set; }
        [FieldNoToken]
        public bool View_Users_District { get; set; }
        [FieldNoToken]
        public bool ShowProfilePage { get; set; }
        [FieldNoToken]
        public bool ShowManagementPage { get; set; }
        [FieldNoToken]
        public bool CreateUsers { get; set; }
        [FieldNoToken]
        public bool EditUsers { get; set; }
        [FieldNoToken]
        public bool DeleteUsers { get; set; }
        [FieldNoToken]
        public bool DeactivateUsers { get; set; }
        [FieldNoToken]
        public bool UploadTimeSheet { get; set; }
        [FieldNoToken]
        public bool EnableHotJump { get; set; }
        [FieldNoToken]
        public bool ViewTimeReports { get; set; }

        [FieldNoToken]
        public bool EditWorkSites { get; set; }
        [FieldNoToken]
        public bool DeleteWorkSites { get; set; }
        [FieldNoToken]
        public bool CreateWorkSites { get; set; }

        [FieldNoToken]
        public bool CreateDistricts { get; set; }
        [FieldNoToken]
        public bool EditDistricts { get; set; }
        [FieldNoToken]
        public bool DeleteDistricts { get; set; }

        [FieldNoToken]
        public bool CreateRoles { get; set; }
        [FieldNoToken]
        public bool EditRoles { get; set; }
        [FieldNoToken]
        public bool DeleteRoles { get; set; }

        [FieldNoToken]
        public bool CreateNews { get; set; }
        [FieldNoToken]
        public bool EditNews { get; set; }
        [FieldNoToken]
        public bool DeleteNews { get; set; }

        [FieldNoToken]
        public bool CreateFormType { get; set; }
        [FieldNoToken]
        public bool EditFormType { get; set; }
        [FieldNoToken]
        public bool DeleteFormType { get; set; }

        [FieldNoToken]
        public bool CreateLink { get; set; }
        [FieldNoToken]
        public bool EditLink { get; set; }
        [FieldNoToken]
        public bool DeleteLink { get; set; }

        [FieldNoToken]
        public bool CreateReports { get; set; }
        [FieldNoToken]
        public bool EditReports { get; set; }
        [FieldNoToken]
        public bool DeleteReports { get; set; }

        public bool Wizard { get; set; }

        [FieldNoToken]
        public bool CreateFormGroups { get; set; }
        [FieldNoToken]
        public bool EditFormGroups { get; set; }
        [FieldNoToken]
        public bool DeleteFormGroups { get; set; }

        [FieldNoToken]
        public bool View_AddendaPay_Own { get; set; }
        [FieldNoToken]
        public bool View_AddendaPay_District { get; set; }
        [FieldNoToken]
        public bool View_AddendaPay_All { get; set; }

        [FieldNoToken]
        public bool View_AddedService_Own { get; set; }
        [FieldNoToken]
        public bool View_AddedService_District { get; set; }
        [FieldNoToken]
        public bool View_AddedService_All { get; set; }

        [FieldNoToken]
        public bool CreateAddendaPay { get; set; }
        [FieldNoToken]
        public bool EditAddendaPay { get; set; }
        [FieldNoToken]
        public bool DeleteAddendaPay { get; set; }
        [FieldNoToken]
        public bool CreateAddedService { get; set; }
        [FieldNoToken]
        public bool EditAddedService { get; set; }
        [FieldNoToken]
        public bool DeleteAddedService { get; set; }
        [FieldNoToken]
        public bool ShowAddedPayPage { get; set; }


        [FieldNoToken]
        public bool ContractsEnabled { get; set; }
        [FieldNoToken]
        public bool View_Contracts_All { get; set; }
        [FieldNoToken]
        public bool View_Contracts_District { get; set; }
        [FieldNoToken]
        public bool View_Contracts_Own { get; set; }
        [FieldNoToken]
        public bool CreateContract { get; set; }
        [FieldNoToken]
        public bool EditContract { get; set; }
        [FieldNoToken]
        public bool DeleteContract { get; set; }
        [FieldNoToken]
        public bool ShowContractsPage { get; set; }

        [FieldNoToken]
        public bool AllowShowPastAddedPay { get; set; }
        [FieldNoToken]
        public bool RestorePastAddedPay { get; set; }
        [FieldNoToken]
        public bool DecomissionAddedPay { get; set; }
        [FieldNoToken]
        public bool ShowPastContracts { get; set; }

        [FieldNoToken]
        public bool CreateNotifications { get; set; }
        [FieldNoToken]
        public bool EditNotifications { get; set; }
        [FieldNoToken]
        public bool DeleteNotifications { get; set; }
        [FieldNoToken]
        public bool UploadContracts { get; set; }
        [FieldNoToken]
        public bool SendContracts { get; set; }
        [FieldNoToken]
        public string TimeConfigType { get; set; }
        [FieldNoToken]
        public bool IncludeInApplicantList { get; set; }

        public override string ToString()
            {
            return this.Name;
            }
        }
    }