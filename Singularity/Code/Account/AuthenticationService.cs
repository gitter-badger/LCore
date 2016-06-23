using Singularity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Singularity.Context;
using Singularity.Extensions;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMethodReturnValue.Global

namespace Singularity.Account
    {
    public class AuthenticationService
        {
        public const string Session_UserName = "Session_UserName";
        public const string Session_PasswordHash = "Session_PasswordHash";
        public const string Session_FailedLoginAttempts = "Session_FailedLoginAttempts";

        public const string Session_Start = "Session_SessionStart";

        public const string Session_User = "Session_User";
        public const string Session_Roles = "Session_Roles";

        public const string Session_UserImpersonating = "Session_UserImpersonating";
        public const string Session_IsImpersonating = "Session_IsImpersonating";


        /////////////////////////////////////////////////////////

        private readonly HttpSessionStateBase Session;

        public AuthenticationService(HttpSessionStateBase Session)
            {
            this.Session = Session;
            }

        /////////////////////////////////////////////////////////

        public bool IsLoggedIn => this.Session[Session_UserName] != null;

        public string UserName
            {
            get
                {
                return (string)this.Session[Session_UserName];
                }
            private set
                {
                this.Session[Session_UserName] = value;
                }
            }

        public int FailedLoginAttempts
            {
            get
                {
                return (int)(this.Session[Session_FailedLoginAttempts] ?? 0);
                }
            private set
                {
                this.Session[Session_FailedLoginAttempts] = value;
                }
            }


        public string PasswordHash
            {
            get
                {
                return (string)this.Session[Session_PasswordHash];
                }
            private set
                {
                this.Session[Session_PasswordHash] = value;
                }
            }

        public DateTime SessionStart
            {
            get
                {
                return (DateTime)this.Session[Session_Start];
                }
            private set
                {
                this.Session[Session_Start] = value;
                }
            }

        public UserAccount LoggedInUser
            {
            get
                {
                return (UserAccount)this.Session[Session_User];
                }
            private set
                {
                this.Session[Session_User] = value;
                }
            }

        public List<Role> LoggedInRoles
            {
            get
                {
                return (List<Role>)this.Session[Session_Roles];
                }
            private set
                {
                this.Session[Session_Roles] = value;
                }
            }

        public bool IsImpersonating
            {
            get
                {
                return (bool)(this.Session[Session_IsImpersonating] ?? false);
                }
            set
                {
                this.Session[Session_IsImpersonating] = value;
                }
            }
        public UserAccount LoggedInUserImpersonating
            {
            get
                {
                return (UserAccount)this.Session[Session_UserImpersonating];
                }
            private set
                {
                this.Session[Session_UserImpersonating] = value;
                }
            }

        /////////////////////////////////////////////////////////

        public UserAccount AttemptLogIn(HttpContextBase Context, string NewUserName, string NewPassword)
            {
            return this.AttemptLogInHash(Context, NewUserName, Crypto.GetHash(NewUserName + NewPassword));
            }

        public UserAccount AttemptLogInHash(HttpContextBase Context, string NewUserName, string NewPasswordHash)
            {
            UserAccount Result = UserAccount.Data.GetByHash(Context.GetModelContext(), NewUserName, NewPasswordHash);

            if (Result == null)
                {
                this.FailedLoginAttempts += 1;

                Thread.Sleep(this.FailedLoginDelayMS);

                this.LogFailure(Context, NewUserName);

                return null;
                }
            this.LogIn(Result);

            this.LogSuccess(Context, Result);

            return Result;
            }

        public UserAccount Impersonate(HttpContextBase Context, int userID)
            {
            if (this.IsLoggedIn && this.LoggedInUser.IsAdmin)
                {
                ModelContext DbContext = Context.GetModelContext();
                UserAccount u = UserAccount.Data.GetByID(DbContext, userID);
                
                this.LoggedInUserImpersonating = this.LoggedInUser;
                this.UserName = u.UserName;
                this.PasswordHash = u.PasswordHash;
                this.LoggedInUser = u;
                this.LoggedInRoles = u.Roles.ToList();
                this.SessionStart = DateTime.Now;

                this.IsImpersonating = true;

                return u;
                }
            return null;
            }

        /////////////////////////////////////////////////////////

        private UserAccount LogIn(UserAccount Result)
            {
            this.UserName = Result.UserName;
            this.PasswordHash = Result.PasswordHash;
            this.LoggedInUser = Result;
            this.LoggedInRoles = Result.Roles.ToList();
            this.SessionStart = DateTime.Now;

            this.IsImpersonating = false;
            this.LoggedInUserImpersonating = null;

            return Result;
            }

        public void LogOut()
            {
            this.UserName = null;
            this.PasswordHash = null;
            this.LoggedInUser = null;
            this.LoggedInRoles = null;
            }

        /////////////////////////////////////////////////////////

        private void LogFailure(HttpContextBase Context, string User)
            {
            ModelContext DbContext = Context.GetModelContext();

            SecurityLog Log = new SecurityLog
                {
                Description = $"Login failed for: \'{User}\'",
                IPAddress = Context.Request.UserHostAddress,
                Created = DateTime.Now
                };


            DbContext.SecurityLogs.Add(Log);
            DbContext.SaveChanges();
            }

        private void LogSuccess(HttpContextBase Context, UserAccount Result)
            {
            ModelContext DbContext = Context.GetModelContext();

            SecurityLog Log = new SecurityLog
                {
                Description = "Logged On",
                IPAddress = Context.Request.UserHostAddress,
                UserAccountID = Result.UserAccountID,
                Created = DateTime.Now
                };


            DbContext.SecurityLogs.Add(Log);

            DbContext.SaveChanges();
            }

        // Failed auth attempts have a delay. This is simple but effective against bruteforcing attempts.
        // 1 second for every failed attempt in a session
        private int FailedLoginDelayMS => 1000 * this.FailedLoginAttempts;
        }
    }
