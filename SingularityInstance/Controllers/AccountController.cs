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
    public class AccountController : Controller
        {
        private ApplicationSignInManager _SignInManager;
        private ApplicationUserManager _UserManager;

        public AccountController()
            {
            }

        public AccountController(ApplicationUserManager UserManager, ApplicationSignInManager SignInManager)
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
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string ReturnUrl)
            {
            this.ViewBag.ReturnUrl = ReturnUrl;
            return this.View();
            }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel Model, string ReturnUrl)
            {
            if (!this.ModelState.IsValid)
                {
                return this.View(Model);
                }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var Result = await this.SignInManager.PasswordSignInAsync(Model.Email, Model.Password, Model.RememberMe, false);
            switch (Result)
                {
                case SignInStatus.Success:
                    return this.RedirectToLocal(ReturnUrl);
                case SignInStatus.LockedOut:
                    return this.View("Lockout");
                case SignInStatus.RequiresVerification:
                    return this.RedirectToAction("SendCode", new {ReturnUrl, Model.RememberMe });
                // ReSharper disable once RedundantCaseLabel
                case SignInStatus.Failure:
                default:
                    this.ModelState.AddModelError("", "Invalid login attempt.");
                    return this.View(Model);
                }
            }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string Provider, string ReturnUrl, bool RememberMe)
            {
            // Require that the user has already logged in via username/password or external login
            if (!await this.SignInManager.HasBeenVerifiedAsync())
                {
                return this.View("Error");
                }
            return this.View(new VerifyCodeViewModel { Provider = Provider, ReturnUrl = ReturnUrl, RememberMe = RememberMe });
            }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel Model)
            {
            if (!this.ModelState.IsValid)
                {
                return this.View(Model);
                }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var Result = await this.SignInManager.TwoFactorSignInAsync(Model.Provider, Model.Code, Model.RememberMe, Model.RememberBrowser);
            switch (Result)
                {
                case SignInStatus.Success:
                    return this.RedirectToLocal(Model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return this.View("Lockout");
                // ReSharper disable once RedundantCaseLabel
                case SignInStatus.Failure:
                default:
                    this.ModelState.AddModelError("", "Invalid code.");
                    return this.View(Model);
                }
            }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
            {
            return this.View();
            }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel Model)
            {
            if (this.ModelState.IsValid)
                {
                var User = new ApplicationUser { UserName = Model.Email, Email = Model.Email };
                var Result = await this.UserManager.CreateAsync(User, Model.Password);
                if (Result.Succeeded)
                    {
                    await this.SignInManager.SignInAsync(User, false, false);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", $"Please confirm your account by clicking <a href=\"{callbackUrl}\">here</a>");

                    return this.RedirectToAction("Index", "Home");
                    }
                this.AddErrors(Result);
                }

            // If we got this far, something failed, redisplay form
            return this.View(Model);
            }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string UserId, string Code)
            {
            if (UserId == null || Code == null)
                {
                return this.View("Error");
                }
            var Result = await this.UserManager.ConfirmEmailAsync(UserId, Code);
            return this.View(Result.Succeeded ? "ConfirmEmail" : "Error");
            }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
            {
            return this.View();
            }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel Model)
            {
            if (this.ModelState.IsValid)
                {
                var User = await this.UserManager.FindByNameAsync(Model.Email);
                if (User == null || !await this.UserManager.IsEmailConfirmedAsync(User.Id))
                    {
                    // Don't reveal that the user does not exist or is not confirmed
                    return this.View("ForgotPasswordConfirmation");
                    }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", $"Please reset your password by clicking <a href=\"{callbackUrl}\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
                }

            // If we got this far, something failed, redisplay form
            return this.View(Model);
            }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
            {
            return this.View();
            }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string Code)
            {
            return Code == null ? this.View("Error") : this.View();
            }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel Model)
            {
            if (!this.ModelState.IsValid)
                {
                return this.View(Model);
                }
            var User = await this.UserManager.FindByNameAsync(Model.Email);
            if (User == null)
                {
                // Don't reveal that the user does not exist
                return this.RedirectToAction("ResetPasswordConfirmation", "Account");
                }
            var Result = await this.UserManager.ResetPasswordAsync(User.Id, Model.Code, Model.Password);
            if (Result.Succeeded)
                {
                return this.RedirectToAction("ResetPasswordConfirmation", "Account");
                }
            this.AddErrors(Result);
            return this.View();
            }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
            {
            return this.View();
            }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string Provider, string ReturnUrl)
            {
            // Request a redirect to the external login provider
            return new ChallengeResult(Provider, this.Url.Action("ExternalLoginCallback", "Account", new {ReturnUrl }));
            }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string ReturnUrl, bool RememberMe)
            {
            string UserId = await this.SignInManager.GetVerifiedUserIdAsync();
            if (UserId == null)
                {
                return this.View("Error");
                }
            IList<string> UserFactors = await this.UserManager.GetValidTwoFactorProvidersAsync(UserId);
            List<SelectListItem> FactorOptions = UserFactors.Select(Purpose => new SelectListItem { Text = Purpose, Value = Purpose }).ToList();
            return this.View(new SendCodeViewModel { Providers = FactorOptions, ReturnUrl = ReturnUrl, RememberMe = RememberMe });
            }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel Model)
            {
            if (!this.ModelState.IsValid)
                {
                return this.View();
                }

            // Generate the token and send it
            if (!await this.SignInManager.SendTwoFactorCodeAsync(Model.SelectedProvider))
                {
                return this.View("Error");
                }
            return this.RedirectToAction("VerifyCode", new { Provider = Model.SelectedProvider, Model.ReturnUrl, Model.RememberMe });
            }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string ReturnUrl)
            {
            var LoginInfo = await this.AuthenticationManager.GetExternalLoginInfoAsync();
            if (LoginInfo == null)
                {
                return this.RedirectToAction("Login");
                }

            // Sign in the user with this external login provider if the user already has a login
            var Result = await this.SignInManager.ExternalSignInAsync(LoginInfo, false);
            switch (Result)
                {
                case SignInStatus.Success:
                    return this.RedirectToLocal(ReturnUrl);
                case SignInStatus.LockedOut:
                    return this.View("Lockout");
                case SignInStatus.RequiresVerification:
                    return this.RedirectToAction("SendCode", new {ReturnUrl, RememberMe = false });
                // ReSharper disable once RedundantCaseLabel
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    this.ViewBag.ReturnUrl = ReturnUrl;
                    this.ViewBag.LoginProvider = LoginInfo.Login.LoginProvider;
                    return this.View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = LoginInfo.Email });
                }
            }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel Model, string ReturnUrl)
            {
            if (this.User.Identity.IsAuthenticated)
                {
                return this.RedirectToAction("Index", "Manage");
                }

            if (this.ModelState.IsValid)
                {
                // Get the information about the user from the external login provider
                var Info = await this.AuthenticationManager.GetExternalLoginInfoAsync();
                if (Info == null)
                    {
                    return this.View("ExternalLoginFailure");
                    }
                var User = new ApplicationUser { UserName = Model.Email, Email = Model.Email };
                var Result = await this.UserManager.CreateAsync(User);
                if (Result.Succeeded)
                    {
                    Result = await this.UserManager.AddLoginAsync(User.Id, Info.Login);
                    if (Result.Succeeded)
                        {
                        await this.SignInManager.SignInAsync(User, false, false);
                        return this.RedirectToLocal(ReturnUrl);
                        }
                    }
                this.AddErrors(Result);
                }

            this.ViewBag.ReturnUrl = ReturnUrl;
            return this.View(Model);
            }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
            {
            this.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return this.RedirectToAction("Index", "Home");
            }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
            {
            return this.View();
            }

        protected override void Dispose(bool Disposing)
            {
            if (Disposing)
                {
                if (this._UserManager != null)
                    {
                    this._UserManager.Dispose();
                    this._UserManager = null;
                    }

                if (this._SignInManager != null)
                    {
                    this._SignInManager.Dispose();
                    this._SignInManager = null;
                    }
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

        private ActionResult RedirectToLocal(string ReturnUrl)
            {
            if (this.Url.IsLocalUrl(ReturnUrl))
                {
                return this.Redirect(ReturnUrl);
                }
            return this.RedirectToAction("Index", "Home");
            }

        internal class ChallengeResult : HttpUnauthorizedResult
            {
            public ChallengeResult(string Provider, string RedirectURI, string UserID = null)
                {
                this.LoginProvider = Provider;
                this.RedirectUri = RedirectURI;
                this.UserId = UserID;
                }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext Context)
                {
                var Properties = new AuthenticationProperties { RedirectUri = this.RedirectUri };
                if (this.UserId != null)
                    {
                    Properties.Dictionary[XsrfKey] = this.UserId;
                    }
                Context.HttpContext.GetOwinContext().Authentication.Challenge(Properties, this.LoginProvider);
                }
            }
        #endregion
        }
    }