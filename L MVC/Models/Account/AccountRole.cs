using System;using System.Collections.Generic;using System.Linq;using System.ComponentModel.DataAnnotations;using LCore.Extensions;using Singularity.Context;// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnassignedGetOnlyAutoProperty
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace Singularity.Models
    {
    public class AccountRole : IModel, IAccountRole
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

        public IModelPermissions EventPermissions { get; set; }
        public IModelPermissions TestModelPermissions { get; set; }
        public IModelPermissions WorkSitePermissions { get; set; }
        public IModelPermissions DistrictPermissions { get; set; }
        public IModelPermissions AddedPayPermissions { get; set; }
        public IModelPermissions ContractPermissions { get; set; }
        public IModelPermissions FormRequirementPermissions { get; set; }
        public IModelPermissions FormsPermissions { get; set; }
        public IModelPermissions FormTypePermissions { get; set; }
        public IModelPermissions TimeEntryPermissions { get; set; }
        public IModelPermissions TimeSheetPermissions { get; set; }
        public IModelPermissions UserPermissions { get; set; }
        public IModelPermissions ExhibitHubPermissions { get; set; }
        public IModelPermissions ErrorPermissions { get; set; }
        public IModelPermissions TextContentPermissions { get; set; }
        public IModelPermissions TemplatePermissions { get; set; }
        public IModelPermissions EmailTemplatePermissions { get; set; }
        public IModelPermissions EmailHistoryPermissions { get; set; }
        public IModelPermissions CustomExportPermissions { get; set; }
        public IModelPermissions SavedSearchPermissions { get; set; }
        public IModelPermissions EmailJobPermissions { get; set; }

        // ReSharper disable once InconsistentNaming
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
                return Context.GetDBSet<AccountRole>().FirstOrDefault(Role => Role.RoleID == RoleID);
                }
            }        public virtual bool AllowAccess(IModel Model)            {            var Permissions = (ModelPermissions)this.GetProperty($"{Model.GetType().Name}Permissions");            return Permissions?.View == true;            }        }

    }
