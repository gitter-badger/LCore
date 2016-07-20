using System;using System.Collections.Generic;using System.ComponentModel.DataAnnotations;using System.ComponentModel.DataAnnotations.Schema;// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnassignedGetOnlyAutoProperty
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace LMVC.Models
    {    public class SecurityLog : IModel        {        [Key]        public int SecurityLogID { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public string Description { get; set; }

        public int? UserAccountID { get; set; }

        [ForeignKey("UserAccountID")]
        public virtual UserAccount User { get; set; }
        
        public string Platform { get; set; }
        
        public string IPAddress { get; set; }        }    }