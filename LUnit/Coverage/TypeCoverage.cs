using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using JetBrains.Annotations;
using LCore.Extensions;

namespace LCore.LUnit
    {
    /// <summary>
    /// Represents Type coverage information, given a Type
    /// to be tested, along with any Test Assemblies covering it.
    /// </summary>
    public class TypeCoverage
        {
        /// <summary>
        /// The Type being tested.
        /// </summary>
        public Type CoveringType { get; }

        /// <summary>
        /// The total coverage percent, a uint value from 0 to 100.
        /// </summary>
        public uint CoveragePercent =>
            (uint)(this.MemberCoverage.Convert(Member => Member.IsCovered ? 1 : 0).Average() * 100).Round();

        /// <summary>
        /// Information about the Member Coverage for all methods on the Type.
        /// </summary>
        public ReadOnlyCollection<MemberCoverage> MemberCoverage { get; }

        private ReadOnlyCollection<Assembly> _TestAssemblies { get; }


        /// <summary>
        /// Creates a TypeCoverage object, given a Type  to be tested, 
        /// along with any Test Assemblies covering it.
        /// </summary>
        public TypeCoverage(Type CoveringType, [CanBeNull]params Assembly[] TestAssemblies)
            {
            this.CoveringType = CoveringType;
            this._TestAssemblies = (TestAssemblies ?? new Assembly[] { }).List().AsReadOnly();

            List<MethodInfo> TestMembers = this.CoveringType.GetMembers().Select<MethodInfo>(
                Member => Member.DeclaringType == CoveringType &&
                          !Member.IsPropertyGetterOrSetter())
                .WithoutAttribute<ExcludeFromCodeCoverageAttribute>()
                .Filter<MethodInfo>();

            this.MemberCoverage = TestMembers
                .Convert(Member => new MemberCoverage(Member, this._TestAssemblies.Array()))
                .AsReadOnly();
            }
        }
    }