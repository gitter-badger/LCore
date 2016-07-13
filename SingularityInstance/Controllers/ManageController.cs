using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SingularityInstance.Models;

namespace SingularityInstance.Controllers
    {
    [Authorize]
    public class ManageController : Controller
        {
        private ApplicationSignInManager _SignInManager;
        private ApplicationUserManager _UserManager;

        public ManageController()
            {
            }

        public ManageController(ApplicationUserManager UserManager, ApplicationSignInManager SignInManager)
            {
            this.UserManager = UserManager;
            this.SignInManager = SignInManager;
            }

        public ApplicationSignInManager SignInManager
            {
            get
                {
                return this._SignInManager ?? this.HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
                }
            private set
                {
                this._SignInManager = value;
                }
            }

        public ApplicationUserManager UserManager
            {
            get
                {
                return this._UserManager ?? this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                }
            private set
                {
                this._UserManager = value;
                }
            }

        //
        // GET: /Manage/Index
        public async Task<ActionResult> Index(ManageMessageId? Message)
            {
            this.ViewBag.StatusMessage =
                Message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : Message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : Message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                : Message == ManageMessageId.Error ? "An error has occurred."
                : Message == ManageMessageId.AddPhoneSuccess ? "Your phone number was added."
                : Message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                : "";

            string UserId = this.User.Identity.GetUserId();
            var Model = new IndexViewModel
                {
                HasPassword = this.HasPassword(),
                PhoneNumber = await this.UserManager.GetPhoneNumberAsync(UserId),
                TwoFactor = await this.UserManager.GetTwoFactorEnabledAsync(UserId),
                Logins = await this.UserManager.GetLoginsAsync(UserId),
                BrowserRemembered = await this.AuthenticationManager.TwoFactorBrowserRememberedAsync(UserId)
                };
            return this.View(Model);
            }

        //
        // POST: /Manage/RemoveLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveLogin(string LoginProvider, string ProviderKey)
            {
            ManageMessageId? Message;
            var Result = await this.UserManager.RemoveLoginAsync(this.User.Identity.GetUserId(), new UserLoginInfo(LoginProvider, ProviderKey));
            if (Result.Succeeded)
                {
                var User = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
                if (User != null)
                    {
                    await this.SignInManager.SignInAsync(User, false, false);
                    }
                Message = ManageMessageId.RemoveLoginSuccess;
                }
            else
                {
                Message = ManageMessageId.Error;
                }
            return this.RedirectToAction("ManageLogins", new { Message });
            }

        //
        // GET: /Manage/AddPhoneNumber
        public ActionResult AddPhoneNumber()
            {
            return this.View();
            }

        //
        // POST: /Manage/AddPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPhoneNumber(AddPhoneNumberViewModel Model)
            {
            if (!this.ModelState.IsValid)
                {
                return this.View(Model);
                }
            // Generate the token and send it
            string Code = await this.UserManager.GenerateChangePhoneNumberTokenAsync(this.User.Identity.GetUserId(), Model.Number);
            if (this.UserManager.SmsService != null)
                {
                var Message = new IdentityMessage
                    {
                    Destination = Model.Number,
                    Body = $"Your security code is: {Code}"
                    };
                await this.UserManager.SmsService.SendAsync(Message);
                }
            return this.RedirectToAction("VerifyPhoneNumber", new { PhoneNumber = Model.Number });
            }

        //
        // POST: /Manage/EnableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EnableTwoFactorAuthentication()
            {
            await this.UserManager.SetTwoFactorEnabledAsync(this.User.Identity.GetUserId(), true);
            var User = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
            if (User != null)
                {
                await this.SignInManager.SignInAsync(User, false, false);
                }
            return this.RedirectToAction("Index", "Manage");
            }

        //
        // POST: /Manage/DisableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DisableTwoFactorAuthentication()
            {
            await this.UserManager.SetTwoFactorEnabledAsync(this.User.Identity.GetUserId(), false);
            var ApplicationUser = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
            if (ApplicationUser != null)
                {
                await this.SignInManager.SignInAsync(ApplicationUser, false, false);
                }
            return this.RedirectToAction("Index", "Manage");
            }

        //
        // GET: /Manage/VerifyPhoneNumber
        public async Task<ActionResult> VerifyPhoneNumber(string PhoneNumber)
            {
            await this.UserManager.GenerateChangePhoneNumberTokenAsync(this.User.Identity.GetUserId(), PhoneNumber);
            // Send an SMS through the SMS provider to verify the phone number
            return PhoneNumber == null ? this.View("Error") : this.View(new VerifyPhoneNumberViewModel { PhoneNumber = PhoneNumber });
            }

        //
        // POST: /Manage/VerifyPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyPhoneNumber(VerifyPhoneNumberViewModel Model)
            {
            if (!this.ModelState.IsValid)
                {
                return this.View(Model);
                }
            var Result = await this.UserManager.ChangePhoneNumberAsync(this.User.Identity.GetUserId(), Model.PhoneNumber, Model.Code);
            if (Result.Succeeded)
                {
                var User = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
                if (User != null)
                    {
                    await this.SignInManager.SignInAsync(User, false, false);
                    }
                return this.RedirectToAction("Index", new { Message = ManageMessageId.AddPhoneSuccess });
                }
            // If we got this far, something failed, redisplay form
            this.ModelState.AddModelError("", "Failed to verify phone");
            return this.View(Model);
            }

        //
        // POST: /Manage/RemovePhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemovePhoneNumber()
            {
            var Result = await this.UserManager.SetPhoneNumberAsync(this.User.Identity.GetUserId(), null);
            if (!Result.Succeeded)
                {
                return this.RedirectToAction("Index", new { Message = ManageMessageId.Error });
                }
            var User = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
            if (User != null)
                {
                await this.SignInManager.SignInAsync(User, false, false);
                }
            return this.RedirectToAction("Index", new { Message = ManageMessageId.RemovePhoneSuccess });
            }

        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
            {
            return this.View();
            }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel Model)
            {
            if (!this.ModelState.IsValid)
                {
                return this.View(Model);
                }
            var Result = await this.UserManager.ChangePasswordAsync(this.User.Identity.GetUserId(), Model.OldPassword, Model.NewPassword);
            if (Result.Succeeded)
                {
                var User = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
                if (User != null)
                    {
                    await this.SignInManager.SignInAsync(User, false, false);
                    }
                return this.RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
                }
            this.AddErrors(Result);
            return this.View(Model);
            }

        //
        // GET: /Manage/SetPassword
        public ActionResult SetPassword()
            {
            return this.View();
            }

        //
        // POST: /Manage/SetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetPassword(SetPasswordViewModel Model)
            {
            if (this.ModelState.IsValid)
                {
                var Result = await this.UserManager.AddPasswordAsync(this.User.Identity.GetUserId(), Model.NewPassword);
                if (Result.Succeeded)
                    {
                    var User = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
                    if (User != null)
                        {
                        await this.SignInManager.SignInAsync(User, false, false);
                        }
                    return this.RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
                    }
                this.AddErrors(Result);
                }

            // If we got this far, something failed, redisplay form
            return this.View(Model);
            }

        //
        // GET: /Manage/ManageLogins
        public async Task<ActionResult> ManageLogins(ManageMessageId? Message)
            {
            this.ViewBag.StatusMessage =
                Message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : Message == ManageMessageId.Error ? "An error has occurred."
                : "";
            var User = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
            if (User == null)
                {
                return this.View("Error");
                }
            IList<UserLoginInfo> UserLogins = await this.UserManager.GetLoginsAsync(this.User.Identity.GetUserId());
            List<AuthenticationDescription> OtherLogins = this.AuthenticationManager.GetExternalAuthenticationTypes().Where(Auth => UserLogins.All(Ul => Auth.AuthenticationType != Ul.LoginProvider)).ToList();
            this.ViewBag.ShowRemoveButton = User.PasswordHash != null || UserLogins.Count > 1;
            return this.View(new ManageLoginsViewModel
                {
                CurrentLogins = UserLogins,
                OtherLogins = OtherLogins
                });
            }

        //
        // POST: /Manage/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string Provider)
            {
            // Request a redirect to the external login provider to link a login for the current user
            return new AccountController.ChallengeResult(Provider, this.Url.Action("LinkLoginCallback", "Manage"), this.User.Identity.GetUserId());
            }

        //
        // GET: /Manage/LinkLoginCallback
        public async Task<ActionResult> LinkLoginCallback()
            {
            var LoginInfo = await this.AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, this.User.Identity.GetUserId());
            if (LoginInfo == null)
                {
                return this.RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
                }
            var Result = await this.UserManager.AddLoginAsync(this.User.Identity.GetUserId(), LoginInfo.Login);
            return Result.Succeeded ? this.RedirectToAction("ManageLogins") : this.RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
            }

        protected override void Dispose(bool Disposing)
            {
            if (Disposing && this._UserManager != null)
                {
                this._UserManager.Dispose();
                this._UserManager = null;
                }

            base.Dispose(Disposing);
            }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager => this.HttpContext.GetOwinContext().Authentication;

        private void AddErrors(IdentityResult Result)
            {
            foreach (string Error in Result.Errors)
                {
                this.ModelState.AddModelError("", Error);
                }
            }

        private bool HasPassword()
            {
            var User = this.UserManager.FindById(this.User.Identity.GetUserId());
            return User?.PasswordHash != null;
            }

        private bool HasPhoneNumber()
            {
            var User = this.UserManager.FindById(this.User.Identity.GetUserId());
            return User?.PhoneNumber != null;
            }

        public enum ManageMessageId
            {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
            }

        #endregion
        }
    }