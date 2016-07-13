using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using SingularityInstance.Models;

namespace SingularityInstance
    {
    public class EmailService : IIdentityMessageService
        {
        public Task SendAsync(IdentityMessage Message)
            {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
            }
        }

    public class SmsService : IIdentityMessageService
        {
        public Task SendAsync(IdentityMessage Message)
            {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
            }
        }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser>
        {
        public ApplicationUserManager(IUserStore<ApplicationUser> Store)
            : base(Store)
            {
            }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> Options, IOwinContext Context)
            {
            var Manager = new ApplicationUserManager(new UserStore<ApplicationUser>(Context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            Manager.UserValidator = new UserValidator<ApplicationUser>(Manager)
                {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
                };

            // Configure validation logic for passwords
            Manager.PasswordValidator = new PasswordValidator
                {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true
                };

            // Configure user lockout defaults
            Manager.UserLockoutEnabledByDefault = true;
            Manager.DefaultAccountLockoutTimeSpan = new TimeSpan(0, 5, 0);
            Manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            Manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
                {
                MessageFormat = "Your security code is {0}"
                });
            Manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
                {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
                });
            Manager.EmailService = new EmailService();
            Manager.SmsService = new SmsService();
            var DataProtectionProvider = Options.DataProtectionProvider;
            if (DataProtectionProvider != null)
                {
                Manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser>(DataProtectionProvider.Create("ASP.NET Identity"));
                }
            return Manager;
            }
        }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
        {
        public ApplicationSignInManager(ApplicationUserManager UserManager, IAuthenticationManager AuthenticationManager)
            : base(UserManager, AuthenticationManager)
            {
            }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser User)
            {
            return User.GenerateUserIdentityAsync((ApplicationUserManager)this.UserManager);
            }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> Options, IOwinContext Context)
            {
            return new ApplicationSignInManager(Context.GetUserManager<ApplicationUserManager>(), Context.Authentication);
            }
        }
    }
