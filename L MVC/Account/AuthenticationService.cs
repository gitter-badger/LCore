using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using LCore.Extensions;
using LMVC.Extensions;
using LMVC.Models;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMethodReturnValue.Global

namespace LMVC.Account
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

        private HttpSessionStateBase _SessionState { get; }

        public AuthenticationService(HttpSessionStateBase Session)
            {
            this._SessionState = Session;
            }

        /////////////////////////////////////////////////////////

        public bool IsLoggedIn
            {
            get
                {
                try
                    {
                    return this._SessionState[Session.UserName] != null;
                    }
                catch (NotImplementedException)
                    {
                    /* IIS 7 Integrated mode error, should not occur. */
                    return false;
                    }
                }
            }

        public string UserName
            {
            get
                {
                try
                    {
                    return (string)this._SessionState[Session.UserName];
                    }
                catch (NotImplementedException)
                    {
                    /* IIS 7 Integrated mode error, should not occur. */
                    return null;
                    }
                }
            private set
                {
                try
                    {
                    this._SessionState[Session.UserName] = value;
                    }
                catch (NotImplementedException)
                    {
                    /* IIS 7 Integrated mode error, should not occur. */
                    }
                }
            }

        public int FailedLoginAttempts
            {
            get
                {
                try
                    {
                    return (int)(this._SessionState[Session.FailedLoginAttempts] ?? 0);
                    }
                catch (NotImplementedException)
                    {
                    /* IIS 7 Integrated mode error, should not occur. */
                    return 0;
                    }
                }
            private set
                {
                try
                    {
                    this._SessionState[Session.FailedLoginAttempts] = value;
                    }
                catch (NotImplementedException)
                    {
                    /* IIS 7 Integrated mode error, should not occur. */
                    }
                }
            }


        public string PasswordHash
            {
            get
                {
                try
                    {
                    return (string)this._SessionState[Session.PasswordHash];
                    }
                catch (NotImplementedException)
                    {
                    /* IIS 7 Integrated mode error, should not occur. */
                    return null;
                    }
                }
            private set
                {
                try
                    {
                    this._SessionState[Session.PasswordHash] = value;
                    }
                catch (NotImplementedException)
                    {
                    /* IIS 7 Integrated mode error, should not occur. */
                    }
                }
            }

        public DateTime SessionStart
            {
            get
                {
                try
                    {
                    return (DateTime)this._SessionState[Session.Start];
                    }
                catch (NotImplementedException)
                    {
                    /* IIS 7 Integrated mode error, should not occur. */
                    return DateTime.MinValue;
                    }
                }
            private set
                {
                try
                    {
                    this._SessionState[Session.Start] = value;
                    }
                catch (NotImplementedException)
                    {
                    /* IIS 7 Integrated mode error, should not occur. */
                    }
                }
            }

        public IUserAccount LoggedInUser
            {
            get
                {
                try
                    {
                    return (UserAccount)this._SessionState[Session.User];
                    }
                catch (NotImplementedException)
                    {
                    /* IIS 7 Integrated mode error, should not occur. */
                    return null;
                    }
                }
            private set
                {
                try
                    {
                    this._SessionState[Session.User] = value;
                    }
                catch (NotImplementedException)
                    {
                    /* IIS 7 Integrated mode error, should not occur. */
                    }
                }
            }

        public List<IAccountRole> LoggedInRoles
            {
            get
                {
                try
                    {
                    return (List<IAccountRole>)this._SessionState[Session.Roles];
                    }
                catch (NotImplementedException)
                    {
                    /* IIS 7 Integrated mode error, should not occur. */
                    return new List<IAccountRole>();
                    }
                }
            private set
                {
                try
                    {
                    this._SessionState[Session.Roles] = value;
                    }
                catch (NotImplementedException)
                    {
                    /* IIS 7 Integrated mode error, should not occur. */
                    }
                }
            }

        public bool IsImpersonating
            {
            get
                {
                try
                    {
                    return (bool)(this._SessionState[Session.IsImpersonating] ?? false);
                    }
                catch (NotImplementedException)
                    {
                    /* IIS 7 Integrated mode error, should not occur. */
                    return false;
                    }
                }
            set
                {
                try
                    {
                    this._SessionState[Session.IsImpersonating] = value;
                    }
                catch (NotImplementedException)
                    {
                    /* IIS 7 Integrated mode error, should not occur. */
                    }
                }
            }
        public IUserAccount LoggedInUserImpersonating
            {
            get
                {
                try
                    {
                    return (UserAccount)this._SessionState[Session.UserImpersonating];
                    }
                catch (NotImplementedException)
                    {
                    /* IIS 7 Integrated mode error, should not occur. */
                    return null;
                    }
                }
            private set
                {
                try
                    {
                    this._SessionState[Session.UserImpersonating] = value;
                    }
                catch (NotImplementedException)
                    {
                    /* IIS 7 Integrated mode error, should not occur. */
                    }
                }
            }

        /////////////////////////////////////////////////////////

        public IUserAccount AttemptLogIn(HttpContextBase Context, string NewUserName, string NewPassword)
            {
            return this.AttemptLogInHash(Context, NewUserName, Crypto.GetHash(NewUserName + NewPassword));
            }

        public IUserAccount AttemptLogInHash(HttpContextBase Context, string NewUserName, string NewPasswordHash)
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

        public IUserAccount Impersonate(HttpContextBase Context, int UserID)
            {
            if (this.IsLoggedIn && this.LoggedInUser.IsAdmin)
                {
                var DbContext = Context.GetModelContext();
                var User = UserAccount.Data.GetByID(DbContext, UserID);

                this.LoggedInUserImpersonating = this.LoggedInUser;
                this.UserName = User.UserName;
                this.PasswordHash = User.PasswordHash;
                this.LoggedInUser = User;
                this.LoggedInRoles = User.Roles.List<IAccountRole>();
                this.SessionStart = DateTime.Now;

                this.IsImpersonating = true;

                return User;
                }
            return null;
            }

        /////////////////////////////////////////////////////////

        private void LogIn(UserAccount Result)
            {
            this.UserName = Result.UserName;
            this.PasswordHash = Result.PasswordHash;
            this.LoggedInUser = Result;
            this.LoggedInRoles = Result.Roles.List<IAccountRole>();
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

        private void LogSuccess(HttpContextBase Context, IUserAccount Result)
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
