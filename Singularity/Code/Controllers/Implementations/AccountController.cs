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
        public ActionResult Login(LoginViewModel model, IAuthenticationService Auth)
            {
            if (!this.ModelState.IsValid)
                {
                return this.View(model);
                }

            var DbContext = this.HttpContext.GetModelContext();

            var Result = Auth.AttemptLogIn(this.HttpContext, model.Username, model.Password);

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
        public ActionResult ForceResetPassword(ForceResetPasswordViewModel model, IAuthenticationService Auth)
            {
            bool Errors = false;

            if (model != null)
                {
                if (string.IsNullOrEmpty(model.Password))
                    {
                    this.AddStatusMessages_Error("Please supply a new password");

                    Errors = true;
                    }
                if (string.IsNullOrEmpty(model.ConfirmPassword))
                    {
                    this.AddStatusMessages_Error("Please confirm your password");

                    Errors = true;
                    }
                if (model.Password != model.ConfirmPassword)
                    {
                    this.AddStatusMessages_Error("Passwords did not match");

                    Errors = true;
                    }
                if (!Authentication.PasswordFitsRules(model.Password, Authentication.PasswordDefaultRules))
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

                LoggedIn.SetPassword(model.Password);
                LoggedIn.ExpiredDate = DateTime.Now.Add(Authentication.UserAccountPasswordExpire);

                DbContext.SaveChanges();

                // new password, new session
                Auth.LogOut();

                Auth.AttemptLogIn(this.HttpContext, LoggedIn.UserName, model.Password);

                this.AddStatusMessages_Success("Password successfully updated");

                return this.RedirectToAction(DbContext.GetHomeAction(LoggedIn), DbContext.GetHomeController(LoggedIn));
                }

            return this.View();
            }

        [HttpPost]
        [RequireAdmin]
        [ValidateAntiForgeryToken]
        public ActionResult ImpersonateUser(ImpersonateUserViewModel model, IAuthenticationService Auth)
            {
            var DbContext = this.HttpContext.GetModelContext();

            Auth.Impersonate(this.HttpContext, model.UserAccountID);

            return this.RedirectToAction(DbContext.GetHomeAction(Auth.LoggedInUser), DbContext.GetHomeController(Auth.LoggedInUser));
            }
        }
    }