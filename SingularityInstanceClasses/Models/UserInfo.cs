using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Singularity.Annotations;
using Singularity.Context;
using Singularity.Models;

namespace SingularityInstanceClasses.Models
    {
    [Table("Users")]
    [FriendlyModelName("User")]
    [ModelPermissions("UserPermissions")]
    public class UserInfo : IEmailable
        {
        [Key]
        public int UserID { get; set; }

        [FieldGlobalSearch]
        public string UserName { get; set; }

        [HideManageViewColumn]
        [FieldDisableExport]
        public string Password { get; set; }

        [HideManageViewColumn]
        public int RoleID { get; set; }

        [FieldGlobalSearch]
        public virtual Role Role { get; set; }

        [HideManageViewColumn]
        public bool Active { get; set; }

        [FieldGlobalSearch]
        [DataType(DataType.EmailAddress)]
        public string Email1 { get; set; }

        [FieldGlobalSearch]
        public string FirstName { get; set; }
        [HideManageViewColumn]
        public string MiddleName { get; set; }
        [FieldGlobalSearch]
        public string LastName { get; set; }

        public string[] GetEmails()
            {
            return this.GetEmails("Email1");
            }
        public string[] GetEmails(string Field)
            {
            if (Field == "Email1" && !string.IsNullOrEmpty(this.Email1))
                {
                return new[] {
                    this.Email1
                };
                }
            return new string[] { };
            }

        public override string ToString()
            {
            return $"{this.FirstName} {this.LastName}";
            }

        public static IQueryable<UserInfo> GetActiveUsers(ModelContext DbContext)
            {
            return DbContext.GetDBSet<UserInfo>().Where(Filter_Active);
            }

        public static Expression<Func<UserInfo, bool>> Filter_ByID(int UserID)
            {
            return u => u.Active &&
                u.UserID == UserID;
            }

        public static Expression<Func<UserInfo, bool>> Filter_Active =
            u => u.Active &&
                u.Role != null;

        public static Expression<Func<UserInfo, bool>> Filter_ByName(string FirstName, string LastName)
            {
            return u => u.Active &&
                u.Role != null &&
                u.FirstName == FirstName &&
                u.LastName == LastName;
            }
        }
    }