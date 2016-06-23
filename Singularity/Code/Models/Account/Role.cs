using System;using System.Collections.Generic;using System.Linq;using System.ComponentModel.DataAnnotations;using Singularity.Context;// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnassignedGetOnlyAutoProperty
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace Singularity.Models
    {
    public class Role : IModel
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

        public virtual ICollection<UserAccount> Users { get; set; }

        public class Data
            {
            public static IQueryable<Role> GetAll(ModelContext Context)
                {
                return Context.Roles.AsQueryable();
                }

            public static Role GetByID(ModelContext Context, int RoleID)
                {
                return Context.Roles.FirstOrDefault(r => r.RoleID == RoleID);
                }
            }
        }

    }
