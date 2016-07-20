using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LMVC.Models
    {
    public class ImpersonateUserViewModel
        {
        [Required]
        public int UserAccountID { get; set; }
        }
    }