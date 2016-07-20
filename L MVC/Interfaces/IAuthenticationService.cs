using System;
using System.Collections.Generic;
using System.Web;
using LMVC.Models;

namespace LMVC.Account
    {
    public interface IAuthenticationService
        {
        bool IsLoggedIn { get; }
        string UserName { get; }
        int FailedLoginAttempts { get; }
        string PasswordHash { get; }
        DateTime SessionStart { get; }
        IUserAccount LoggedInUser { get; }
        List<IAccountRole> LoggedInRoles { get; }
        bool IsImpersonating { get; set; }
        IUserAccount LoggedInUserImpersonating { get; }
        IUserAccount AttemptLogIn(HttpContextBase Context, string NewUserName, string NewPassword);
        IUserAccount AttemptLogInHash(HttpContextBase Context, string NewUserName, string NewPasswordHash);
        IUserAccount Impersonate(HttpContextBase Context, int UserID);
        void LogOut();
        }
    }