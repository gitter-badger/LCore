using System;
using System.Collections;
using System.Collections.Generic;

namespace LCore.Extensions
    {
    /// <summary>
    /// Describes a member's declaration details.
    /// </summary>
    public struct MemberDetails
        {
        /// <summary>
        /// The member's scope
        /// </summary>
        public MemberScope Scope { get; set; }
        /// <summary>
        /// The member's context
        /// </summary>
        public MemberContext Context { get; set; }
        /// <summary>
        /// The member's type
        /// </summary>
        public MemberType Type { get; set; }
        /// <summary>
        /// The member's inheritance 
        /// </summary>
        public MemberInheritance Inheritance { get; set; }

        /// <summary>
        /// Returns a string representation of a <see cref="MemberDetails"/>
        /// </summary>
        public override string ToString()
            {
            return $"{this.Scope.GetFriendlyName()} " +
                   $"{(this.Context == MemberContext.Instance ? "" : this.Context.GetFriendlyName())} " +
                   $"{(this.Inheritance == MemberInheritance.None ? "" : this.Inheritance.GetFriendlyName())} " +
                   $"{this.Type.GetFriendlyName()}".ReplaceAll("  ", " ");
            }
        }
    }