using System;
using System.Web.Mvc;
using Singularity.Account;
using Singularity.Attributes;
using Singularity.Extensions;
using Singularity.Models;

namespace Singularity.Controllers
    {
    public class AccountController : SingularityController
        {
        public ActionResult Index()
            {
            return this.RedirectToAction(nameof(AccountController.Login));
            }


        public ActionResult Login()
            {
            return this.View();
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel Model)
            {
            if (!this.ModelState.IsValid)
                {
                return this.View(Model);
                }

            var DbContext = this.HttpContext.GetModelContext();

            var Result = this.Auth.AttemptLogIn(this.HttpContext, Model.Username, Model.Password);

            if (Result != null)
                {
                this.AddStatusMessages_Success($"Logged in, welcome {Result.UserName}!");

                return Result.PasswordResetRequired
                    ? this.RedirectToAction(nameof(AccountController.ForceResetPassword), typeof(AccountController).CName())
                    : this.RedirectToAction(DbContext.GetHomeAction(Result), DbContext.GetHomeController(Result));
                }
            this.AddStatusMessages_Error("Unable to login");

            return this.View();
            }

        [HttpPost]
        [RequireAuth]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff(IAuthenticationService Auth)
            {
            var DbContext = this.HttpContext.GetModelContext();

            if (Auth.IsLoggedIn)
                {
                Auth.LogOut();
                }

            this.AddStatusMessages_Success("You have logged off");

            return this.RedirectToAction(DbContext.GetHomeAction(Auth.LoggedInUser), DbContext.GetHomeController(Auth.LoggedInUser));
            }

        [RequireAuth]
        public ActionResult ForceResetPassword()
            {
            return this.View();
            }

        [HttpPost]
        [RequireAuth]
        [ValidateAntiForgeryToken]
        public ActionResult ForceResetPassword(ForceResetPasswordViewModel Model, IAuthenticationService Auth)
            {
            bool Errors = false;

            if (Model != null)
                {
                if (string.IsNullOrEmpty(Model.Password))
                    {
                    this.AddStatusMessages_Error("Please supply a new password");

                    Errors = true;
                    }
                if (string.IsNullOrEmpty(Model.ConfirmPassword))
                    {
                    this.AddStatusMessages_Error("Please confirm your password");

                    Errors = true;
                    }
                if (Model.Password != Model.ConfirmPassword)
                    {
                    this.AddStatusMessages_Error("Passwords did not match");

                    Errors = true;
                    }
                if (!Authentication.PasswordFitsRules(Model.Password, Authentication.PasswordDefaultRules))
                    {
                    this.AddStatusMessages_Error("Password does not fit password requirements");

                    Errors = true;
                    }
                }
            else
                {
                Errors = true;
                }

            if (!Errors)
                {
                var DbContext = this.HttpContext.GetModelContext();

                var LoggedIn = UserAccount.Data.GetByID(DbContext, Auth.LoggedInUser.UserAccountID);

                LoggedIn.SetPassword(Model.Password);
                LoggedIn.ExpiredDate = DateTime.Now.Add(Authentication.UserAccountPasswordExpire);

                try
                    {
                    DbContext.SaveChanges();

                    // new password, new session
                    Auth.LogOut();

                    Auth.AttemptLogIn(this.HttpContext, LoggedIn.UserName, Model.Password);

                    this.AddStatusMessages_Success("Password successfully updated");

                    return this.RedirectToAction(DbContext.GetHomeAction(LoggedIn), DbContext.GetHomeController(LoggedIn));
                    }
                catch (Exception Ex)
                    {
                    ControllerHelper.HandleError(this.HttpContext, Ex);

                    this.AddStatusMessages_Error("An error has occured.");
                    }
                }

            return this.View();
            }

        [HttpPost]
        [RequireAdmin]
        [ValidateAntiForgeryToken]
        public ActionResult ImpersonateUser(ImpersonateUserViewModel Model, IAuthenticationService Auth)
            {
            var DbContext = this.HttpContext.GetModelContext();

            Auth.Impersonate(this.HttpContext, Model.UserAccountID);

            return this.RedirectToAction(DbContext.GetHomeAction(Auth.LoggedInUser), DbContext.GetHomeController(Auth.LoggedInUser));
            }

        public AccountController(IAuthenticationService Auth) : base(Auth) { }
        }
    }