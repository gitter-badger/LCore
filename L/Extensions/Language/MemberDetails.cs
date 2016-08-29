using System;
using System.Collections;
using System.Collections.Generic;

namespace LCore.Extensions
    {
    public struct MemberDetails
        {
        public MemberScope Scope { get; set; }
        public MemberContext Context { get; set; }
        public MemberType Type { get; set; }
        public MemberInheritance Inheritance { get; set; }

        public override string ToString()
            {
            return $"{this.Scope.GetFriendlyName()} " +
                   $"{(this.Context == MemberContext.Instance ? "" : this.Context.GetFriendlyName())} " +
                   $"{(this.Inheritance == MemberInheritance.None ? "" : this.Inheritance.GetFriendlyName())} " +
                   $"{this.Type.GetFriendlyName()}".ReplaceAll("  ", " ");
            }
        }
    }