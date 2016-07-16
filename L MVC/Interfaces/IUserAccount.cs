using System;
using System.Collections.Generic;

namespace Singularity.Models
    {
    public interface IUserAccount
        {
        DateTime Created { get; set; }
        string Email { get; set; }
        bool Enabled { get; set; }
        DateTime ExpiredDate { get; set; }
        bool IsAdmin { get; set; }
        DateTime? LastLogin { get; set; }
        string PasswordHash { get; set; }
        bool PasswordResetRequired { get; set; }
        int UserAccountID { get; set; }
        string UserName { get; set; }

        string[] GetEmails();
        void SetPassword(string Pass);
        }
    }