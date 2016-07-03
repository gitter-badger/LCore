using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Singularity.Models
    {
    [Table("GlobalSettings")]
    public class GlobalSettings
        {
        [Key]
        public int GlobalSettingsID { get; set; }

        public string AppTitle { get; set; }
        public string SubTitle { get; set; }
        public string ErrorEmail { get; set; }
        public string ErrorFromEmail { get; set; }
        public string ErrorEmailSubject { get; set; }
        public string STMPHost { get; set; }
        public string STMPUser { get; set; }
        public string STMPPassword { get; set; }
        public string StyleFolder { get; set; }
        public string Copyright { get; set; }
        public string NameFormat { get; set; }
        
        public int AdminRoleID { get; set; }
        public int InactiveRoleID { get; set; }

        public int Password_LengthRequired { get; set; }
        public int Password_SpecialCharactersRequired { get; set; }
        public int Password_LowerCaseRequired { get; set; }
        public int Password_UpperCaseRequired { get; set; }
        public int Password_NumbersRequired { get; set; }

        public string DatabaseVersion { get; set; }
        public string NotifyPath { get; set; }
        public string HTTPSPath { get; set; }
        public string LoginPage { get; set; }
        public string NotifyTempPath { get; set; }

        public string StorageFolder { get; set; }

        }
    }