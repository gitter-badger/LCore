using Singularity.Context;
using Singularity.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LCore.Extensions.ObjectExt;

namespace SingularityInstanceClasses.Models
    {
    [Table("UserProfile")]
    public class UserProfile : IModelUser
        {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public virtual ProfileRole Role { get; set; }

        public bool? IsAdmin { get; set; }

        public string[] GetEmails()
            {
            return new string[] { };
            }
        public string[] GetEmails(string FieldName)
            {
            return new string[] { };
            }

        public static UserProfile FindByUserName(ModelContext DbContext, string UserName)
            {
            return DbContext.GetDBSet<UserProfile>().FirstOrDefault(m => m.UserName == UserName);
            }
        }

    [Table("ProfileRoles")]
    public class ProfileRole : IModelRole
        {
        [Key]
        public int ProfileRoleId { get; set; }

        public string Name { get; set; }

        public ModelPermissions EventPermissions { get; set; }
        public ModelPermissions TestModelPermissions { get; set; }
        public ModelPermissions WorkSitePermissions { get; set; }
        public ModelPermissions DistrictPermissions { get; set; }
        public ModelPermissions AddedPayPermissions { get; set; }
        public ModelPermissions ContractPermissions { get; set; }
        public ModelPermissions FormRequirementPermissions { get; set; }
        public ModelPermissions FormsPermissions { get; set; }
        public ModelPermissions FormTypePermissions { get; set; }
        public ModelPermissions TimeEntryPermissions { get; set; }
        public ModelPermissions TimeSheetPermissions { get; set; }
        public ModelPermissions UserPermissions { get; set; }
        public ModelPermissions ExhibitHubPermissions { get; set; }

        public ModelPermissions ErrorPermissions { get; set; }

        public ModelPermissions TextContentPermissions { get; set; }
        public ModelPermissions TemplatePermissions { get; set; }
        public ModelPermissions EmailTemplatePermissions { get; set; }
        public ModelPermissions EmailHistoryPermissions { get; set; }
        public ModelPermissions CustomExportPermissions { get; set; }
        public ModelPermissions SavedSearchPermissions { get; set; }

        public ModelPermissions EmailJobPermissions { get; set; }

        public bool RequireDuo2FA { get; set; }

        public ProfileRole()
            {
            this.InitProperties<ModelPermissions>();
            }

        public bool AllowAccess(IModel Model)
            {
            return true;
            }
        }

    public class RegisterExternalLoginModel
        {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
        }

    public class LocalPasswordModel
        {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        }

    public class LoginModel
        {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        }

    public class RegisterModel
        {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        }

    public class ExternalLogin
        {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
        }
    }
