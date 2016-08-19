using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using JetBrains.Annotations;
using LCore.Extensions;
using Xunit;
using Xunit.Abstractions;

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
            (uint)(this.MemberCoverage.Convert(Member => Member.IsCovered
               ? 1
               : 0).Average() * 100).Round();

        /// <summary>
        /// Information about the Member Coverage for all methods on the Type.
        /// </summary>
        public ReadOnlyCollection<MethodCoverage> MemberCoverage { get; }

        private ReadOnlyCollection<Assembly> _TestAssemblies { get; }


        /// <summary>
        /// A Tuple representing the generated test member Namespace, Class, Method
        /// </summary>
        protected Tuple<string, string, string> TestClassLocation { get; }

        /// <summary>
        /// The suggested namespace for the generated test class
        /// </summary>
        public string TestMember_Namespace => this.TestClassLocation.Item1;

        /// <summary>
        /// The suggested class name for the generated test class
        /// </summary>
        public string TestMember_Class => this.TestClassLocation.Item2;

        /// <summary>
        /// Generate test stubs for all types in the assembly.
        /// </summary>
        public void GenerateTestStubs(string GeneratedCodeFullPath)
            {
            string[] Stub = this.GetTestStub();

            if (!Stub.IsEmpty())
                {
                string GeneratedCodeFolderPath = Path.GetDirectoryName(GeneratedCodeFullPath);

                GeneratedCodeFolderPath.EnsurePathExists();

                File.WriteAllLines(GeneratedCodeFullPath, Stub);
                }
            }

        /// <summary>
        /// Retrieves the empty test stub for this class. 
        /// If all members are covered then an empty string[] will be returned.
        /// </summary>
        public string[] GetTestStub(bool UseXunitOutputBase = true)
            {
            const string Attribute = "Attribute";
            const string Partial = " partial ";

            var Usings = new List<string>();


            var Out = new List<string>();
            var Members = new List<string>();

            var TargetClassTest = L.Ref.FindType($"{this.TestMember_Namespace}.{this.TestMember_Class}", this._TestAssemblies.Array());



            uint MembersAdded = 0;

            this.MemberCoverage.Each(Member =>
                {
                    string[] Stub = Member.GetTestStub(ref Usings);

                    if (Stub != null && Stub.Length > 0)
                        {
                        MembersAdded++;
                        Members.AddRange(Stub);
                        Members.Add("");
                        }
                });


            Out.Add($"namespace {this.TestMember_Namespace}");
            Out.Add("{");

            Out.Add("    /*");
            Out.Add($"    Covering class: {this.CoveringType.FullyQualifiedName()}");
            Out.Add("    ");
            Out.Add($"    {nameof(LUnit)} has Autogenerated {MembersAdded} method {"stubs".Pluralize(MembersAdded)}:");
            Out.Add("    */");

            if (TargetClassTest == null)
                {
                Out.Add(UseXunitOutputBase
                    ? $"    public{Partial}class {this.TestMember_Class} : {nameof(XUnitOutputTester)}, {nameof(IDisposable)}"
                    : $"    public{Partial}class {this.TestMember_Class} : {nameof(IDisposable)}");
                }
            else
                {
                Out.Add($"    public{Partial}class {this.TestMember_Class}");
                }

            Out.Add("    {");

            // Don't re-declare constructor and destructor if the target class exists
            if (TargetClassTest == null)
                {
                Out.Add(UseXunitOutputBase
                    ? $"        public {this.TestMember_Class}([{nameof(NotNullAttribute).Before(Attribute)}] {nameof(ITestOutputHelper)} Output) : base(Output) {{ }}"
                    : $"        public {this.TestMember_Class}() {{ }}");

                Out.Add("");

                Out.Add("        public void Dispose() { }");
                Out.Add("");
                }
            Out.AddRange(Members);
            Out.Add("    }");
            Out.Add("}");

            if (MembersAdded == 0u)
                Out.Clear();
            else
                {
                var Header = new List<string>();


                Usings.Add(typeof(IDisposable).Namespace);
                Usings.Add(typeof(TraitAttribute).Namespace);
                Usings.Add(typeof(FactAttribute).Namespace);
                Usings.Add(typeof(Traits).Namespace);
                Usings.Add(typeof(ITestOutputHelper).Namespace);

                Usings = Usings.RemoveDuplicates();

                Usings.Each(Namespace => Header.Insert(index: 0, item: $"using {Namespace};"));

                Out = Header.Array().Add(Out).List();
                }

            return Out.Array();
            }

        /// <summary>
        /// Creates a TypeCoverage object, given a Type  to be tested, 
        /// along with any Test Assemblies covering it.
        /// </summary>
        public TypeCoverage(Type CoveringType, [CanBeNull] params Assembly[] TestAssemblies)
            {
            this.CoveringType = CoveringType;
            this._TestAssemblies = (TestAssemblies ?? L.Ref.GetAvailableTestAssemblies()).List().AsReadOnly();

            List<MethodInfo> TestMembers = this.CoveringType.GetMembers().Select<MethodInfo>(
                Member => Member.DeclaringType == CoveringType &&
                          !Member.IsPropertyGetterOrSetter())
                .WithoutAttribute<ExcludeFromCodeCoverageAttribute>()
                .Filter<MethodInfo>();

            this.MemberCoverage = TestMembers
                .Convert(Member =>
                    new
                        MethodCoverage(Member, this._TestAssemblies.Array()))
                .AsReadOnly();

            this.TestClassLocation = this.CoveringType.GetTargetingName();
            }
        }
    }