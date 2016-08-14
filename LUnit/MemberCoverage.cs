using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using JetBrains.Annotations;
using LCore.Extensions;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable CollectionNeverQueried.Global

namespace LCore.LUnit
    {
    public class MemberCoverage
        {
        public MethodInfo CoveringMember { get; }

        public ReadOnlyCollection<ITestResultAttribute> TestResultAttributes { get; }
        public ReadOnlyCollection<ITestSourceAttribute> TestSourceAttributes { get; }
        public ReadOnlyCollection<ITestSucceedsAttribute> TestSucceedsAttributes { get; }
        public ReadOnlyCollection<ITestFailsAttribute> TestFailsAttributes { get; }

        public ReadOnlyCollection<ITestBoundAttribute> TestBoundAttributes { get; }

        public uint AttributeCoverage { get; }

        public bool TestedFlag { get; }

        public bool IsCovered => this.TestedFlag || this.AttributeCoverage > 0 || this.MemberTraitFound;

        public string MemberTraitValue { get; }


        private ReadOnlyCollection<Assembly> _TestAssemblies { get; }

        public bool MemberTraitFound { get; }

        public MemberCoverage(MethodInfo CoveringMember, [CanBeNull]params Assembly[] TestAssemblies)
            {
            this.CoveringMember = CoveringMember;
            this._TestAssemblies = (TestAssemblies ?? new Assembly[] { }).List().AsReadOnly();

            this.TestResultAttributes = this.CoveringMember.GetAttributes<ITestResultAttribute>(IncludeBaseTypes: false)
                .List().AsReadOnly();
            this.TestSourceAttributes = this.CoveringMember.GetAttributes<ITestSourceAttribute>(IncludeBaseTypes: false)
                .List().AsReadOnly();
            this.TestSucceedsAttributes = this.CoveringMember.GetAttributes<ITestSucceedsAttribute>(IncludeBaseTypes: false)
                .List().AsReadOnly();
            this.TestFailsAttributes = this.CoveringMember.GetAttributes<ITestFailsAttribute>(IncludeBaseTypes: false)
                .List().AsReadOnly();

            this.TestBoundAttributes = this.CoveringMember.GetAttributes<ITestBoundAttribute>(IncludeBaseTypes: false)
                .List().AsReadOnly();

            this.TestedFlag = this.CoveringMember.HasAttribute<ITestedAttribute>();

            this.MemberTraitValue = this.CoveringMember.ToInvocationSignature(FullyQualify: true);

            this.MemberTraitFound = this._TestAssemblies.GetAssemblyMemberTraits().Has(this.MemberTraitValue);

            this.AttributeCoverage =
                (uint)this.TestResultAttributes.Count +
                (uint)this.TestSourceAttributes.Count +
                (uint)this.TestSucceedsAttributes.Count +
                (uint)this.TestFailsAttributes.Count;
            }
        }
    }
