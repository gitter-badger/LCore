using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace LCore.Extensions
    {
    /// <summary>
    /// Stores the getter and setter scopes for a <see cref="PropertyInfo"/>
    /// </summary>
    public class PropertyScope
        {
        /// <summary>
        /// The getter scope, or MemberScope.None if no getter exists.
        /// </summary>
        public MemberScope? GetScope { get; set; }
        /// <summary>
        /// The setter scope, or MemberScope.None if no setter exists.
        /// </summary>
        public MemberScope? SetScope { get; set; }
        }
    }