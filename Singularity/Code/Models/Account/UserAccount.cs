using System;using System.Collections.Generic;using System.Linq;using System.ComponentModel.DataAnnotations;using System.Web.Mvc;using Singularity.Account;using Singularity.Context;// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnassignedGetOnlyAutoProperty
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace Singularity.Models
    {
    public class UserAccount : IModel
        {
        [Key]
        public int UserAccountID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime? LastLogin { get; set; }

        [MaxLength(64)]
        public string PasswordHash { get; set; }

        [Required]
        public bool Enabled { get; set; }

        [Required]
        public bool PasswordResetRequired { get; set; }
        
        public DateTime Created { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        [Required]        public DateTime ExpiredDate { get; set; }


        public virtual ICollection<Role> Roles { get; set; }        public void SetPassword(string Pass)
            {
            string PasswordString = this.UserName + Pass;
            // this.Password = Pass;
            this.PasswordHash = Crypto.GetHash(PasswordString);
            }

        public static class Data
            {
            public static IQueryable<UserAccount> GetAll(ModelContext Context)
                {
                return Context.UserAccounts.AsQueryable();
                }

            public static UserAccount GetByID(ModelContext Context, int UserID)
                {
                return Context.UserAccounts.FirstOrDefault(r => r.UserAccountID == UserID);
                }

            public static UserAccount GetByCredentials(ModelContext Context, string UserName, string Password)
                {
                string PasswordString = UserName + Password;

                string Hash = Crypto.GetHash(PasswordString);
                return Context.UserAccounts.FirstOrDefault(
                    r => r.UserName == UserName &&
                         //  (r.PasswordHash == null && r.Password == Password) ||
                         // Enabled users only!
                         r.Enabled && r.PasswordHash != null && r.PasswordHash == Hash);
                }
            public static UserAccount GetByHash(ModelContext Context, string UserName, string PasswordHash)
                {
                return Context.UserAccounts.FirstOrDefault(
                    r => r.UserName == UserName &&
                         // Enabled users only!
                         r.Enabled && r.PasswordHash != null && r.PasswordHash == PasswordHash);
                }

            public static void GeneratePasswordHash(UserAccount In, string Password)
                {
                if (!string.IsNullOrEmpty(Password))
                    {
                    string PasswordString = In.UserName + Password;

                    In.PasswordHash = Crypto.GetHash(PasswordString);
                    }
                }

            public static bool ValidatePasswordHash(UserAccount In, string Password)
                {
                if (In?.PasswordHash == null)
                    return false;

                string PasswordString = In.UserName + Password;

                return In.PasswordHash == Crypto.GetHash(PasswordString);                }

            public static IEnumerable<SelectListItem> GetActiveUserSelectList(ModelContext Context)
                {
                List<UserAccount> Users = GetAll(Context).Where(u => u.Enabled).ToList();                return Users.Select(u => new SelectListItem                    {                    Text = u.UserName,
                    Value = u.UserAccountID.ToString()                    }).ToList();
                }

            /*
            public static void HashAllPasswords(UsersContext Context)
                {
                List<User> Users = User.Data.GetAll(Context).ToList();

                foreach (User User in Users)
                    {
                    if (User.PasswordHash == null || User.PasswordHash.Length == 0)
                        {
                        User.Data.GeneratePasswordHash(User, true);
                        Context.SaveChanges();
                        }
                    }

                }
                */
            }
        }

    }