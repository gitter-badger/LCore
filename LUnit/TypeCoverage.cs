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
    public class TypeCoverage
        {
        public Type CoveringType { get; }

        public uint CoveragePercent =>
            (uint)(this.MemberCoverage.Convert(Member => Member.IsCovered ? 1 : 0).Average() * 100).Round();

        public ReadOnlyCollection<MemberCoverage> MemberCoverage { get; }


        private ReadOnlyCollection<Assembly> _TestAssemblies { get; }


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