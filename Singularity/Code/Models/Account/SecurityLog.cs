﻿using System;
// ReSharper disable UnusedMember.Global
// ReSharper disable UnassignedGetOnlyAutoProperty
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace Singularity.Models
    {

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public string Description { get; set; }

        public int? UserAccountID { get; set; }

        [ForeignKey("UserAccountID")]
        public virtual UserAccount User { get; set; }
        
        public string Platform { get; set; }
        
        public string IPAddress { get; set; }