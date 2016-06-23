using System;
using System.Web.Mvc;
using Singularity.Account;
using Singularity.Attributes;
using Singularity.Context;
using Singularity.Extensions;
using Singularity.Models;

namespace Singularity.Controllers
    {
    public class AccountController : Controller
        {
        public ActionResult Index()
            {
            return this.RedirectToAction(Routes.Controllers.Account.Actions.Login);
            }


        public ActionResult Login()
            {
            return this.View();
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
            {
            if (!this.ModelState.IsValid)
                {
                return this.View(model);
                }

            AuthenticationService Auth = new AuthenticationService(this.Session);
            ModelContext DbContext = this.HttpContext.GetModelContext();

            UserAccount Result = Auth.AttemptLogIn(this.HttpContext, model.Username, model.Password);

            if (Result != null)
                {
                this.AddStatusMessages_Success($"Logged in, welcome {Result.UserName}!");

                return Result.PasswordResetRequired
                    ? this.RedirectToAction(Routes.Controllers.Account.Actions.ForceResetPassword, Routes.Controllers.Account.Name)
                    : this.RedirectToAction(DbContext.GetHomeAction(Result), DbContext.GetHomeController(Result));
                }
            this.AddStatusMessages_Error("Unable to login");

            return this.View();
            }

        [HttpPost]
        [RequireAuth]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
            {
            ModelContext DbContext = this.HttpContext.GetModelContext();

            AuthenticationService Auth = new AuthenticationService(this.Session);

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
        public ActionResult ForceResetPassword(ForceResetPasswordViewModel model)
            {
            AuthenticationService Auth = new AuthenticationService(this.Session);

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
                ModelContext DbContext = this.HttpContext.GetModelContext();

                UserAccount LoggedIn = UserAccount.Data.GetByID(DbContext, Auth.LoggedInUser.UserAccountID);

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
        public ActionResult ImpersonateUser(ImpersonateUserViewModel model)
            {
            ModelContext DbContext = this.HttpContext.GetModelContext();
            AuthenticationService Auth = new AuthenticationService(this.Session);

            Auth.Impersonate(this.HttpContext, model.UserAccountID);

            return this.RedirectToAction(DbContext.GetHomeAction(Auth.LoggedInUser), DbContext.GetHomeController(Auth.LoggedInUser));
            }
        }
    }