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
    /// <summary>
    /// Represents Member coverage information, given a Member
    /// to be tested, along with any Test Assemblies covering it.
    /// </summary>
    public class MemberCoverage
        {
        /// <summary>
        /// The Member being tested.
        /// </summary>
        public MethodInfo CoveringMember { get; }

        /// <summary>
        /// All ITestResultAttributes declared on the member.
        /// </summary>
        public ReadOnlyCollection<ITestResultAttribute> TestResultAttributes { get; }

        /// <summary>
        /// All ITestSourceAttributes declared on the member.
        /// </summary>
        public ReadOnlyCollection<ITestSourceAttribute> TestSourceAttributes { get; }
        /// <summary>
        /// All ITestSucceedsAttributes declared on the member.
        /// </summary>
        public ReadOnlyCollection<ITestSucceedsAttribute> TestSucceedsAttributes { get; }
        /// <summary>
        /// All ITestFailsAttributes declared on the member.
        /// </summary>
        public ReadOnlyCollection<ITestFailsAttribute> TestFailsAttributes { get; }

        /// <summary>
        /// All ITestBoundAttributes declared on the member.
        /// </summary>
        public ReadOnlyCollection<ITestBoundAttribute> TestBoundAttributes { get; }

        /// <summary>
        /// The number of test attributes covering the member.
        /// </summary>
        public uint AttributeCoverage { get; }

        /// <summary>
        /// True if the member has an ITestedAttribute defined.
        /// </summary>
        public bool TestedFlag { get; }

        /// <summary>
        /// Returns true if the member is covered in a Trait-targeted test,
        /// an attribute test, or a manual ITestedAttribute.
        /// </summary>
        public bool IsCovered => this.TestedFlag || this.AttributeCoverage > 0 || this.MemberTraitFound;

        /// <summary>
        /// The member trait value used for direct targeting.
        /// </summary>
        public string MemberTraitValue { get; }

        /// <summary>
        /// True if MemberTraitValue is found in the testing assemblies.
        /// </summary>
        public bool MemberTraitFound { get; }

        private ReadOnlyCollection<Assembly> _TestAssemblies { get; }

        /// <summary>
        /// Creates a new MemberCoverage object, given a Member to be tested, 
        /// along with any Test Assemblies covering it.
        /// </summary>
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
