using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using JetBrains.Annotations;
using LCore.Extensions;
using Xunit;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable CollectionNeverQueried.Global

namespace LCore.LUnit
    {
    /// <summary>
    /// Represents method coverage information, given a method
    /// to be tested, along with any Test Assemblies covering it.
    /// </summary>
    public class MethodCoverage
        {
        /// <summary>
        /// The Member being tested.
        /// </summary>
        [NotNull]
        public MethodInfo CoveringMember { get; }

        /// <summary>
        /// The class that declares the CoveringMember
        /// </summary>
        public Type CoveringMemberDeclaringType => this.CoveringMember.DeclaringType;

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
        /// A Tuple representing the generated test member Namespace, Class, Method
        /// </summary>
        protected Tuple<string, string, string> TestMemberLocation { get; }

        /// <summary>
        /// The suggested namespace for the generated test class
        /// </summary>
        public string TestMember_Namespace => this.TestMemberLocation.Item1;

        /// <summary>
        /// The suggested class name for the generated test class
        /// </summary>
        public string TestMember_Class => this.TestMemberLocation.Item2;

        /// <summary>
        /// The suggested member name for the generated test method
        /// </summary>
        public string TestMember_Member => this.TestMemberLocation.Item3;

        /// <summary>
        /// True if MemberTraitValue is found in the testing assemblies.
        /// </summary>
        public bool MemberTraitFound { get; }

        private ReadOnlyCollection<Assembly> _TestAssemblies { get; }

        /// <summary>
        /// Retrieves the empty test stub for this member, if it is uncovered
        /// </summary>
        public string[] GetTestStub(ref List<string> Usings)
            {
            Usings = Usings ?? new List<string>();

            var Out = new List<string>();
            const string Attribute = "Attribute";

            if (this.TestedFlag || this.MemberTraitFound)
                {
                return new string[] { };
                }

            string Content = this.AttributeCoverage > 0
                ? "// Attribute Tests Implemented"
                : $"// TODO: Implement method test {this.CoveringMember.FullyQualifiedName()}";


            bool StrongTypeTraitAttribute = !this.CoveringMember.FullyQualifiedName().HasAny('`', '<', '>') &&
                                            !this.CoveringMember.IsOperator();

            const bool FullyQualifyWithNamespace = false;

            // ReSharper disable once UnusedVariable
            var TargetMemberTest = L.Ref.FindMembers($"{this.TestMember_Namespace}.{this.TestMember_Class}.{this.TestMember_Member}", this._TestAssemblies.Array()).First();

            string TraitKeyAttribute = StrongTypeTraitAttribute
                ? $"{this.CoveringMember.FullyQualifiedName().NameofParts(this.CoveringMember, this.CoveringMemberDeclaringType.Namespace, FullyQualifyWithNamespace)} + \"{this.CoveringMember.ToParameterSignature()}\""
                : $"\"{this.CoveringMember.ToInvocationSignature(FullyQualify: true)}\"";


            // ReSharper disable RedundantNameQualifier
            string New = this.CoveringMember.Name == nameof(object.GetHashCode) || this.CoveringMember.Name == nameof(object.ToString)
                // ReSharper restore RedundantNameQualifier
                ? " new "
                : " ";

            //     MembersMissing++;
            //     TotalMembersMissing++;

            if (!Usings.Contains(this.CoveringMemberDeclaringType.Namespace))
                Usings.Add(this.CoveringMemberDeclaringType.Namespace);

            Out.Add($"        [{nameof(FactAttribute).Before(Attribute)}]");
            Out.Add($"        [{nameof(TraitAttribute).Before(Attribute)}({nameof(Traits)}.{nameof(Traits.TargetMember)},{TraitKeyAttribute})]");
            Out.Add($"        public{New}void {this.CoveringMember.Name}()");
            Out.Add("        {");
            Out.Add($"            {Content}");
            Out.Add("        }");

            return Out.Array();
            }

        /// <summary>
        /// Creates a new MemberCoverage object, given a Member to be tested, 
        /// along with any Test Assemblies covering it.
        /// </summary>
        public MethodCoverage(MethodInfo CoveringMember, [CanBeNull] params Assembly[] TestAssemblies)
            {
            this.CoveringMember = CoveringMember;
            this._TestAssemblies = (TestAssemblies ?? L.Ref.GetAvailableTestAssemblies()).List().AsReadOnly();

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

            this.TestMemberLocation = this.CoveringMember.GetTargetingName();

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