using Singularity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Singularity.Extensions;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMethodReturnValue.Global

namespace Singularity.Account
    {
    public class AuthenticationService : IAuthenticationService
        {
        private static class Session
            {
            public static readonly string UserName = $"{nameof(Session)}_{nameof(UserName)}";
            public static readonly string PasswordHash = $"{nameof(Session)}_{nameof(PasswordHash)}";
            public static readonly string FailedLoginAttempts = $"{nameof(Session)}_{nameof(FailedLoginAttempts)}";

            public static readonly string Start = $"{nameof(Session)}_{nameof(Start)}";

            public static readonly string User = $"{nameof(Session)}_{nameof(User)}";
            public static readonly string Roles = $"{nameof(Session)}_{nameof(Roles)}";

            public static readonly string UserImpersonating = $"{nameof(Session)}_{nameof(UserImpersonating)}";
            public static readonly string IsImpersonating = $"{nameof(Session)}_{nameof(IsImpersonating)}";
            }


        /////////////////////////////////////////////////////////

        private readonly HttpSessionStateBase SessionState;

        public AuthenticationService(HttpSessionStateBase Session)
            {
            this.SessionState = Session;
            }

        /////////////////////////////////////////////////////////

        public bool IsLoggedIn => this.SessionState[Session.UserName] != null;

        public string UserName
            {
            get
                {
                return (string)this.SessionState[Session.UserName];
                }
            private set
                {
                this.SessionState[Session.UserName] = value;
                }
            }

        public int FailedLoginAttempts
            {
            get
                {
                return (int)(this.SessionState[Session.FailedLoginAttempts] ?? 0);
                }
            private set
                {
                this.SessionState[Session.FailedLoginAttempts] = value;
                }
            }


        public string PasswordHash
            {
            get
                {
                return (string)this.SessionState[Session.PasswordHash];
                }
            private set
                {
                this.SessionState[Session.PasswordHash] = value;
                }
            }

        public DateTime SessionStart
            {
            get
                {
                return (DateTime)this.SessionState[Session.Start];
                }
            private set
                {
                this.SessionState[Session.Start] = value;
                }
            }

        public UserAccount LoggedInUser
            {
            get
                {
                return (UserAccount)this.SessionState[Session.User];
                }
            private set
                {
                this.SessionState[Session.User] = value;
                }
            }

        public List<AccountRole> LoggedInRoles
            {
            get
                {
                return (List<AccountRole>)this.SessionState[Session.Roles];
                }
            private set
                {
                this.SessionState[Session.Roles] = value;
                }
            }

        public bool IsImpersonating
            {
            get
                {
                return (bool)(this.SessionState[Session.IsImpersonating] ?? false);
                }
            set
                {
                this.SessionState[Session.IsImpersonating] = value;
                }
            }
        public UserAccount LoggedInUserImpersonating
            {
            get
                {
                return (UserAccount)this.SessionState[Session.UserImpersonating];
                }
            private set
                {
                this.SessionState[Session.UserImpersonating] = value;
                }
            }

        /////////////////////////////////////////////////////////

        public UserAccount AttemptLogIn(HttpContextBase Context, string NewUserName, string NewPassword)
            {
            return this.AttemptLogInHash(Context, NewUserName, Crypto.GetHash(NewUserName + NewPassword));
            }

        public UserAccount AttemptLogInHash(HttpContextBase Context, string NewUserName, string NewPasswordHash)
            {
            var Result = UserAccount.Data.GetByHash(Context.GetModelContext(), NewUserName, NewPasswordHash);

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
                var DbContext = Context.GetModelContext();
                var u = UserAccount.Data.GetByID(DbContext, userID);

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

        private void LogIn(UserAccount Result)
            {
            this.UserName = Result.UserName;
            this.PasswordHash = Result.PasswordHash;
            this.LoggedInUser = Result;
            this.LoggedInRoles = Result.Roles.ToList();
            this.SessionStart = DateTime.Now;

            this.IsImpersonating = false;
            this.LoggedInUserImpersonating = null;
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
            var DbContext = Context.GetModelContext();

            var Log = new SecurityLog
                {
                Description = $"Login failed for: \'{User}\'",
                IPAddress = Context.Request.UserHostAddress,
                Created = DateTime.Now
                };


            DbContext.GetDBSet<SecurityLog>().Add(Log);
            DbContext.SaveChanges();
            }

        private void LogSuccess(HttpContextBase Context, UserAccount Result)
            {
            var DbContext = Context.GetModelContext();

            var Log = new SecurityLog
                {
                Description = "Logged On",
                IPAddress = Context.Request.UserHostAddress,
                UserAccountID = Result.UserAccountID,
                Created = DateTime.Now
                };


            DbContext.GetDBSet<SecurityLog>().Add(Log);

            DbContext.SaveChanges();
            }

        // Failed auth attempts have a delay. This is simple but effective against bruteforcing attempts.
        // 1 second for every failed attempt in a session
        private int FailedLoginDelayMS => 1000 * this.FailedLoginAttempts;
        }

    }
