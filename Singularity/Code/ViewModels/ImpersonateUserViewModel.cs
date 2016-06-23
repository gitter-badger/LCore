using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Singularity.Models
    {
    public class ImpersonateUserViewModel
        {
        [Required]
        public int UserAccountID { get; set; }
        }
    }