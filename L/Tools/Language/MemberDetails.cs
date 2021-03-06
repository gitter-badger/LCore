﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;

namespace LCore.Extensions
    {
    /// <summary>
    /// Describes a member's declaration details.
    /// </summary>
    public class MemberDetails
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
        /// The scope of the getter and setter methods, if the member is a <see cref="PropertyInfo"/>
        /// </summary>
        [CanBeNull]
        public PropertyScope PropertyScope { get; set; }

        /// <summary>
        /// Returns a string representation of a <see cref="MemberDetails"/>
        /// </summary>
        public override string ToString()
            {
            string Out = $"{this.Scope.GetFriendlyName()} " +
                         $"{(this.Context == MemberContext.Instance ? "" : this.Context.GetFriendlyName())} " +
                         $"{(this.Inheritance == MemberInheritance.None ? "" : this.Inheritance.GetFriendlyName())} " +
                         $"{this.Type.GetFriendlyName()}".ReplaceAll("  ", " ");

            return Out.ReplaceAll("  ", " ");
            }

        /// <summary>
        /// Returns the member's details as a code string.
        /// Ex. "public virtual string",
        ///     "protected abstract class"
        /// </summary>
        /// <returns></returns>
        public string ToCodeString()
            {
            return this.ToString()
                .Replace(MemberType.Structure.ToString(), "struct")
                .ToLower()
                .Replace(" method", "")
                .Replace(" property", "")
                .Replace(" field", "")
                .Replace("sealed enum", "enum"); // Enums are sealed but sealed is not written
            }
        }
    }