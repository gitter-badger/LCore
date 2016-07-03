using System;using System.Collections.Generic;using System.Linq;using System.ComponentModel.DataAnnotations;using LCore.Extensions;using Singularity.Context;// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnassignedGetOnlyAutoProperty
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace Singularity.Models
    {
    public class AccountRole : IModel
        {
        [Key]
        public int RoleID { get; set; }

        [Required]
        [MaxLength(50)]
        public string RoleName { get; set; }

        [MaxLength(100)]
        public string RoleDescription { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [MaxLength(20)]
        public string CreatedBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        [MaxLength(20)]
        public string ModifiedBy { get; set; }

        public ModelPermissions EventPermissions { get; set; }
        public ModelPermissions TestModelPermissions { get; set; }
        public ModelPermissions WorkSitePermissions { get; set; }
        public ModelPermissions DistrictPermissions { get; set; }
        public ModelPermissions AddedPayPermissions { get; set; }
        public ModelPermissions ContractPermissions { get; set; }
        public ModelPermissions FormRequirementPermissions { get; set; }
        public ModelPermissions FormsPermissions { get; set; }
        public ModelPermissions FormTypePermissions { get; set; }
        public ModelPermissions TimeEntryPermissions { get; set; }
        public ModelPermissions TimeSheetPermissions { get; set; }
        public ModelPermissions UserPermissions { get; set; }
        public ModelPermissions ExhibitHubPermissions { get; set; }
        public ModelPermissions ErrorPermissions { get; set; }
        public ModelPermissions TextContentPermissions { get; set; }
        public ModelPermissions TemplatePermissions { get; set; }
        public ModelPermissions EmailTemplatePermissions { get; set; }
        public ModelPermissions EmailHistoryPermissions { get; set; }
        public ModelPermissions CustomExportPermissions { get; set; }
        public ModelPermissions SavedSearchPermissions { get; set; }
        public ModelPermissions EmailJobPermissions { get; set; }

        public bool RequireDuo2FA { get; set; }

        public virtual ICollection<UserAccount> Users { get; set; }

        public class Data
            {
            public static IQueryable<AccountRole> GetAll(ModelContext Context)
                {
                return Context.GetDBSet<AccountRole>().AsQueryable();
                }

            public static AccountRole GetByID(ModelContext Context, int RoleID)
                {
                return Context.GetDBSet<AccountRole>().FirstOrDefault(r => r.RoleID == RoleID);
                }
            }        public virtual bool AllowAccess(IModel Model)            {            var Permissions = (ModelPermissions)this.GetProperty($"{Model.GetType().Name}Permissions");            return Permissions?.View == true;            }        }

    }
