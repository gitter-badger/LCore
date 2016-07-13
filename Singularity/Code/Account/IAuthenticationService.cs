using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using Singularity.Models;

namespace Singularity.Account
    {
    public interface IAuthenticationService
        {
        bool IsLoggedIn { get; }
        string UserName { get; }
        int FailedLoginAttempts { get; }
        string PasswordHash { get; }
        DateTime SessionStart { get; }
        UserAccount LoggedInUser { get; }
        List<AccountRole> LoggedInRoles { get; }
        bool IsImpersonating { get; set; }
        UserAccount LoggedInUserImpersonating { get; }
        UserAccount AttemptLogIn(HttpContextBase Context, string NewUserName, string NewPassword);
        UserAccount AttemptLogInHash(HttpContextBase Context, string NewUserName, string NewPasswordHash);
        UserAccount Impersonate(HttpContextBase Context, int UserID);
        void LogOut();
        }
    }