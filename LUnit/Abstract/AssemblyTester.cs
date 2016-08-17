using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Threading;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.Extensions.Optional;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Xunit.Abstractions;
using static LCore.LUnit.LUnit.Categories;

// ReSharper disable UnusedParameter.Global

// ReSharper disable VirtualMemberNeverOverriden.Global

namespace LCore.LUnit
    {
    /// <summary>
    /// Extend this class to perform Assembly-wide automatic tests and assertions.
    /// </summary>
    [Trait(Category, AssemblyTests)]
    public abstract class AssemblyTester : XUnitOutputTester
        {
        /// <summary>
        /// Return a type in order to target assembly you're testing.
        /// </summary>
        protected abstract Type AssemblyType { get; }

        /// <summary>
        /// Set this property to true to enable
        /// </summary>
        protected virtual bool EnforceNullabilityAttributes => false;

        /// <summary>
        /// Enables tracking of class / method coverage using test naming convention.
        /// See the output of AssemblyMissingCoverage.
        /// </summary>
        protected virtual bool GeneratedCode_UseXunitOutputBase => true;

        /// <summary>
        /// Enables tracking of Xunit Trait attributes directly targeting tested members.
        /// This is useful for tying tests directly to tested members, as well as 
        /// being able to jump directly to the tested member from the test.
        /// </summary>
        protected virtual bool GeneratedCode_IncludeTraitTargetAttributes => true;

        /// <summary>
        /// Enables inclusion of Test members for Class instance properties.
        /// Default is false.
        /// </summary>
        protected virtual bool GeneratedCode_IncludeInstanceProperties => false;

        /// <summary>
        /// Enables generation of partial classes.
        /// </summary>
        protected virtual bool GeneratedCode_UsePartialClasses => true;

        /// <summary>
        /// Enables the use of [CanBeNull], [NotNull] in code generation.
        /// Defaults to the value of EnforceNullabilityAttributes.
        /// </summary>
        protected virtual bool GeneratedCode_UseNullabilityAttribute => this.EnforceNullabilityAttributes;

        /// <summary>
        /// Override the namespace format.
        /// </summary>
        /// <see cref="LUnit.Format.Namespace"/>
        protected virtual string NamingConvention_Format_Namespace => LUnit.Format.Namespace;

        /// <summary>
        /// Override the class format.
        /// </summary>
        /// <see cref="LUnit.Format.Class"/>
        protected virtual string NamingConvention_Format_Class => LUnit.Format.Class;

        /// <summary>
        /// Override the member format.
        /// </summary>
        /// <see cref="LUnit.Format.Member"/>
        protected virtual string NamingConvention_Format_Member => LUnit.Format.Member;

        /// <summary>
        /// Override TestAssemblies to specify additional Assemblies to search for code coverage. 
        /// </summary>
        protected virtual Assembly[] TestAssemblies => AppDomain.CurrentDomain.GetAssemblies();

        ////////////////////////////////////////////////////////

        /// <summary>
        /// Reference to the assembly being tested.
        /// </summary>
        protected Assembly Assembly => Assembly.GetAssembly(this.AssemblyType);

        /// <summary>
        /// All types exposed by the targeted Assembly.
        /// </summary>
        protected Type[] AssemblyTypes => this.Assembly.GetExportedTypes();

        /// <summary>
        /// Returns the root directory of the Test Assembly project.
        /// </summary>
        protected string TestAssemblyCodePath => Environment.CurrentDirectory.BeforeLast("\\bin\\");

        /// <summary>
        /// Override this property to set the directory generated code will be placed.
        /// The default is "Generated".
        /// </summary>
        protected virtual string GeneratedCodeFolder => "Generated";

        /// <summary>
        /// Override this property to set the file name generated code will be placed.
        /// The default is "LUnitGenerated.cs".
        /// </summary>
        protected virtual string GeneratedCodeFile => "LUnitGenerated.cs";

        /// <summary>
        /// Retrieves the folder path to place generated code.
        /// </summary>
        protected string GeneratedCodeFolderPath => $"{this.TestAssemblyCodePath}\\{this.GeneratedCodeFolder}";

        /// <summary>
        /// Retrieves the full file path to place generated code
        /// </summary>
        protected string GeneratedCodeFullPath => $"{this.TestAssemblyCodePath}\\{this.GeneratedCodeFolder}\\{this.GeneratedCodeFile}";

        /// <summary>
        /// Enables automatic code generation into the Test Assembly.
        /// Default is false.
        /// 
        /// Override other GeneratedCode properties to customize where generated code is placed.
        /// </summary>
        protected virtual bool EnableCodeAutoGeneration => false;

        ////////////////////////////////////////////////////////

        /// <summary>
        /// Create a new AssemblyTester
        /// </summary>
        protected AssemblyTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ////////////////////////////////////////////////////////

        /// <summary>
        /// Returns a status of test coverage over the targeted assembly.
        /// </summary>
        [Fact]
        public void AssemblyStatus()
            {
            this._Output.WriteLine($"Covering Assembly: {this.Assembly.GetName().Name}");
            this._Output.WriteLine("");

            Type[] Types = this.AssemblyTypes.WithoutAttribute<ExcludeFromCodeCoverageAttribute, Type>(IncludeBaseTypes: false).Array();

            Type[] StaticTypes = Types.Select(Type => Type.IsStatic());
            Type[] NonStaticTypes = Types.Select(Type => Type.IsClass && !Type.IsStatic());

            var Out = new List<string>();
            //var MissingMembers = new List<string>();

            if (NonStaticTypes.Length > 0)
                {
                uint TotalMembers = 0;
                uint TotalTests = 0;

                var AllCoverage = new List<uint>();
                // Out.Add($"Classes:                        Total Coverage: {TotalCoverage}");
                foreach (var Type in NonStaticTypes)
                    {
                    var TestData = new TypeCoverage(Type, this.TestAssemblies);
                    //Type.GetTestData(this.TestAssemblies);


                    if (TestData.MemberCoverage.Count > 0)
                        {
                        uint Coverage = TestData.CoveragePercent;
                        AllCoverage.Add(Coverage);

                        TotalMembers += (uint)TestData.MemberCoverage.Count;
                        uint Covered = TestData.MemberCoverage.Count(Member => Member.IsCovered);
                        TotalTests += Covered;

                        Out.Add($"{Type.FullyQualifiedName().Pad(Length: 45)}({$"{Coverage}".AlignRight(Length: 3)}%) ({Covered}/{TestData.MemberCoverage.Count})");

                        //TestData.MissingMemberInvocations.Each(Member => MissingMembers.Add($"-{Member}"));
                        }
                    }

                Out.Insert(index: 0, item: $"Classes:                     Total Coverage: ({$"{AllCoverage.Average().Round()}".AlignRight(Length: 3)}%)  ({TotalTests}/{TotalMembers})");
                Out.Insert(index: 1, item: "--------------------------------------------------------------");
                Out.Add("");
                Out.Add("");
                Out.Each(this._Output.WriteLine);
                Out.Clear();
                }

            if (StaticTypes.Length > 0)
                {
                uint TotalMembers = 0;
                uint TotalTests = 0;

                var AllCoverage = new List<uint>();

                foreach (var Type in StaticTypes)
                    {
                    var TestData = new TypeCoverage(Type, this.TestAssemblies);
                    //Type.GetTestData(this.TestAssemblies);

                    AllCoverage.Add(TestData.CoveragePercent);

                    if (TestData.MemberCoverage.Count > 0)
                        {
                        uint Coverage = TestData.CoveragePercent;


                        TotalMembers += (uint)TestData.MemberCoverage.Count;
                        uint Covered = TestData.MemberCoverage.Count(Member => Member.IsCovered);
                        TotalTests += Covered;

                        Out.Add($"{Type.FullyQualifiedName().Pad(Length: 45)}({$"{Coverage}".AlignRight(Length: 3)}%) ({Covered}/{TestData.MemberCoverage.Count})");

                        //TestData.MissingMemberInvocations.Each(Member => MissingMembers.Add($"-{Member}"));
                        }
                    }

                Out.Insert(index: 0, item: $"Static Classes:              Total Coverage: ({$"{AllCoverage.Average().Round()}".AlignRight(Length: 3)}%)  ({TotalTests}/{TotalMembers})");
                Out.Insert(index: 1, item: "--------------------------------------------------------------");
                Out.Add("");
                Out.Each(this._Output.WriteLine);
                Out.Clear();
                }

            //MissingMembers.Each(this._Output.WriteLine);
            }

        /// <summary>
        /// Includes details about uncovered methods. 
        /// Use the code provided here to automatically target missing methods.
        /// </summary>
        [Fact]
        public void AssemblyMissingCoverage()
            {
            // ReSharper disable FormatStringProblem
            // ReSharper disable once UseObjectOrCollectionInitializer
            var WriteStack = new List<string>();
            var Using = new List<string>();

            const string Attribute = nameof(Attribute);

            Type[] Types = this.AssemblyTypes.WithoutAttribute<ExcludeFromCodeCoverageAttribute, Type>(IncludeBaseTypes: false).Array();

            uint NamespacesMissing = 0;

            uint TotalClassesMissing = 0;
            uint TotalMembersMissing = 0;

            var MemberAttributes = new Dictionary<MemberInfo, List<ILUnitAttribute>>();

            var MemberNaming = new Dictionary<MemberInfo, Tuple<string, string, string>>();

            string Partial = this.GeneratedCode_UsePartialClasses
                ? " partial "
                : " ";

            foreach (var Type in Types)
                {
                MemberAttributes.AddRange(Type.GetTestMembers());

                MemberNaming.AddRange(MemberAttributes.Keys.Index(Member => Member.GetTargetingName()).Flip());
                }

            // Remove non-static properties from being tested.
            if (!this.GeneratedCode_IncludeInstanceProperties)
                {
                var Removals = new List<MemberInfo>();
                MemberNaming.Keys.Each(Key =>
                {
                    if (Key is MethodInfo && ((MethodInfo)Key).IsPropertyGetterOrSetter())
                        Removals.Add(Key);

                    if (Key is PropertyInfo
                        && ((PropertyInfo)Key).GetMethod?.IsStatic != true
                        && ((PropertyInfo)Key).SetMethod?.IsStatic != true)
                        Removals.Add(Key);
                });

                Removals.Each(Remove => MemberNaming.Remove(Remove));
                }

            Dictionary<string, Dictionary<string, List<string>>> MemberTable = MemberNaming.Values.ToDictionary();

            List<string> MemberTraits = this.TestAssemblies.GetAssemblyMemberTraits();

            MemberTable.Keys.Each((Index, Namespace) =>
            {
                // ReSharper disable once UseObjectOrCollectionInitializer
                var WriteStack2 = new List<string>();
                WriteStack2.Add("");
                WriteStack2.Add($"namespace {Namespace}");
                WriteStack2.Add("{");

                Dictionary<string, List<string>> Classes = MemberTable[Namespace];

                uint ClassesMissing = 0;

                Classes.Keys.Each(Class =>
                {
                    var TargetClass =
                    MemberNaming.First(Member => Member.Value.Item1 == Namespace && Member.Value.Item2 == Class).Key.DeclaringType;

                    var TargetClassTest = L.Ref.FindType($"{Namespace}.{Class}", this.TestAssemblies);

                    if (TargetClass != null)
                        {
                        bool FullyQualifyWithNamespace =
                        MemberNaming.Values.Count(Naming => Naming.Item2 == Class && Naming.Item1 != Namespace) > 0;


                        // ReSharper disable once UseObjectOrCollectionInitializer
                        var WriteStack3 = new List<string>();

                        if (this.GeneratedCode_IncludeTraitTargetAttributes)
                            {
                            bool StrongTypeTraitAttribute = !TargetClass.FullyQualifiedName().HasAny('`', '<', '>');

                            if (TargetClassTest != null)
                                Partial = " partial ";

                            WriteStack3.Add(StrongTypeTraitAttribute
                                ? $"    [{nameof(TraitAttribute).Before(Attribute)}({nameof(Traits)}.{nameof(Traits.TargetClass)},{TargetClass.FullyQualifiedName().NameofParts(TargetClass, TargetClass.Namespace, FullyQualifyWithNamespace)})]"
                                : $"    [{nameof(TraitAttribute).Before(Attribute)}({nameof(Traits)}.{nameof(Traits.TargetClass)},\"{TargetClass.FullyQualifiedName()}\")]");

                            if (TargetClassTest == null)
                                {
                                WriteStack3.Add(this.GeneratedCode_UseXunitOutputBase
                                ? $"    public{Partial}class {Class} : {nameof(XUnitOutputTester)}, {nameof(IDisposable)}"
                                : $"    public{Partial}class {Class} : {nameof(IDisposable)}");
                                }
                            else
                                {
                                WriteStack3.Add($"   public{Partial}class {Class}");
                                }

                            WriteStack3.Add("    {");

                            // Don't re-declare constructor and destructor if the target class exists
                            if (TargetClassTest == null)
                                {
                                WriteStack3.Add(this.GeneratedCode_UseXunitOutputBase
                                ? $"        public {Class}([{nameof(NotNullAttribute).Before(Attribute)}] {nameof(ITestOutputHelper)} Output) : base(Output) {{ }}"
                                : $"        public {Class}() {{ }}");

                                WriteStack3.Add("");

                                WriteStack3.Add("        public void Dispose() { }");
                                WriteStack3.Add("");
                                }

                            List<string> MemberNames = Classes[Class];


                            uint MembersMissing = 0;

                            MemberNames.Each(MemberName =>
                            {
                                var TargetMember =
                                MemberNaming.First(
                                    Member =>
                                        Member.Value.Item1 == Namespace && Member.Value.Item2 == Class &&
                                        Member.Value.Item3 == MemberName).Key;

                                if (TargetMember.HasAttribute<ITestedAttribute>() ||
                                TargetMember?.HasAttribute<ExcludeFromCodeCoverageAttribute>(IncludeBaseClasses: true) == true ||
                                TargetMember?.DeclaringType?.HasAttribute<ExcludeFromCodeCoverageAttribute>(IncludeBaseClasses: true) == true)
                                    return;

                                StrongTypeTraitAttribute = !TargetMember.FullyQualifiedName().HasAny('`', '<', '>') &&
                                                       !(TargetMember is MethodInfo && ((MethodInfo)TargetMember).IsOperator());

                                // ReSharper disable once UnusedVariable
                                var TargetMemberTest = L.Ref.FindMembers($"{Namespace}.{Class}.{MemberName}", this.TestAssemblies).First();

                                string TraitKeyAttribute = StrongTypeTraitAttribute
                                ? (TargetMember is MethodInfo
                                    ? $"{TargetMember.FullyQualifiedName().NameofParts(TargetMember, TargetClass.Namespace, FullyQualifyWithNamespace)} + \"{((MethodInfo)TargetMember).ToParameterSignature()}\""
                                    : $"{TargetMember.FullyQualifiedName().NameofParts(TargetMember, TargetClass.Namespace, FullyQualifyWithNamespace)}")
                                : (TargetMember is MethodInfo
                                    ? $"\"{((MethodInfo)TargetMember).ToInvocationSignature(FullyQualify: true)}\""
                                    : $"\"{TargetMember.FullyQualifiedName()}\"");

                                string TraitKeyLookup = TargetMember is MethodInfo
                                    ? $"{((MethodInfo)TargetMember).ToInvocationSignature(FullyQualify: true)}"
                                    : $"{TargetMember.FullyQualifiedName()}";

                                if (!MemberTraits.Has(TraitKeyLookup) &&
                                    //(TargetMemberTest == null) &&
                                    !string.IsNullOrEmpty(MemberName))
                                    {
                                    // ReSharper disable RedundantNameQualifier
                                    string New = MemberName == nameof(object.GetHashCode) ||
                                                 MemberName == nameof(object.ToString)
                                        // ReSharper restore RedundantNameQualifier
                                        ? " new "
                                        : " ";

                                    MembersMissing++;
                                    TotalMembersMissing++;

                                    WriteStack3.Add($"        [{nameof(FactAttribute).Before(Attribute)}]");
                                    if (this.GeneratedCode_IncludeTraitTargetAttributes)
                                        {
                                        WriteStack3.Add($"        [{nameof(TraitAttribute).Before(Attribute)}({nameof(Traits)}.{nameof(Traits.TargetMember)},{TraitKeyAttribute})]");

                                        if (!Using.Contains(TargetClass.Namespace))
                                            Using.Add(TargetClass.Namespace);
                                        }

                                    WriteStack3.Add($"        public{New}void {MemberName}()");
                                    WriteStack3.Add("         {");

                                    WriteStack3.Add(TargetMember != null && MemberAttributes[TargetMember].Count > 0
                                    ? "            // Attribute Tests Implemented"
                                    : $"            // TODO: Implement method test {TargetMember.FullyQualifiedName()}");

                                    WriteStack3.Add("         }");
                                    WriteStack3.Add("         ");
                                    }
                            });

                            WriteStack3.Add("    }");

                            if (MembersMissing == 0)
                                WriteStack3.Clear();
                            else
                                {
                                ClassesMissing++;
                                TotalClassesMissing++;
                                WriteStack2.AddRange(WriteStack3);
                                }
                            }
                        }
                });

                WriteStack2.Add("}");

                if (ClassesMissing == 0)
                    WriteStack2.Clear();
                else
                    {
                    NamespacesMissing++;
                    WriteStack.AddRange(WriteStack2);
                    }
            });

            if (NamespacesMissing == 0u)
                {
                WriteStack.Clear();

                WriteStack.Add("No missing test members!");

                WriteStack.Each(Str => this._Output.WriteLine(Str));
                }
            else
                {
                var WriteStack4 = new List<string>
                    {
                    "/*",
                    $"Covering Assembly: {this.Assembly.GetName().Name}",
                    "",
                    "Cover application using naming conventions.",
                    "",
                    $"{nameof(LUnit)} has Autogenerated {TotalClassesMissing} Classes and {TotalMembersMissing} Methods:",
                    "*/"
                    };


                Using.Add(typeof(IDisposable).Namespace);
                Using.Add(typeof(TraitAttribute).Namespace);
                Using.Add(typeof(FactAttribute).Namespace);
                Using.Add(typeof(Traits).Namespace);
                Using.Add(typeof(ITestOutputHelper).Namespace);

                Using = Using.RemoveDuplicates();

                Using.Each(Namespace => WriteStack.Insert(index: 0, item: $"using {Namespace};"));

                if (this.GeneratedCode_UseNullabilityAttribute)
                    WriteStack.Insert(index: 0, item: $"using {typeof(CanBeNullAttribute).Namespace};");
                else
                    WriteStack = WriteStack.Collect(Line => Line.ReplaceAll("[NotNull]", "").ReplaceAll("[CanBeNull]", ""));

                if (this.EnableCodeAutoGeneration)
                    {
                    this.GeneratedCodeFolderPath.EnsurePathExists();

                    System.IO.File.WriteAllLines(this.GeneratedCodeFullPath, WriteStack4.Array().Add(WriteStack));

                    WriteStack4.Each(Str => this._Output.WriteLine(Str));
                    }
                else
                    {
                    WriteStack.Each(Str => this._Output.WriteLine(Str));
                    }
                }


            // ReSharper restore FormatStringProblem
            }



        ////////////////////////////////////////////////////////
        /// 
        private void RunTests()
            {
            Type[] Types = this.AssemblyTypes.WithoutAttribute<ExcludeFromCodeCoverageAttribute, Type>(IncludeBaseTypes: false).Array();

            if (Types.Length > 0)
                {
                foreach (var Type in Types)
                    {
                    this.TestTypeAssertions(Type);

                    this.TestNullability(Type);

                    this.TestTypeDeclarationAttributes(Type);

                    this.TestTypeInterface(Type);

                    this.TestTypeMembers(Type);
                    }

                this._Output.WriteLine("");
                }
            }

        private void TestTypeMembers(Type Type)
            {
            Dictionary<MemberInfo, List<ILUnitAttribute>> Tests = Type.GetTestMembers();

            Tests.Each(Test =>
                {
                    var Member = Test.Key;

                    this.TestAllMemberAssertions(Member);

                    if (Member is MethodInfo)
                        this.TestMethodAssertions((MethodInfo)Member);
                    if (Member is PropertyInfo)
                        this.TestPropertyAssertions((PropertyInfo)Member);
                    if (Member is FieldInfo)
                        this.TestFieldAssertions((FieldInfo)Member);
                    if (Member is EventInfo)
                        this.TestEventAssertions((EventInfo)Member);

                    List<ILUnitAttribute> ValueList = Test.Value.Select(Attr => !(Attr is ITestedAttribute));

                    ValueList.Reverse();

                    ValueList.Each((i, AttrTest) => this.TestAttribute(AttrTest, Member, i + 1));
                });
            }

        private void TestAttribute(ILUnitAttribute AttrTest, MemberInfo Member, int CurrentTest)
            {
            string FullName = Member.FullyQualifiedName();

            try
                {
                // ReSharper disable UseNullPropagation
                if (AttrTest is IValidateAttribute)
                    ((IValidateAttribute)AttrTest).RunTest(Member);
                // ReSharper restore UseNullPropagation
                }
            catch (Exception Ex)
                {
                this.AddException(new InternalTestFailureException(
                    $"\nTesting for Member: {FullName} \nTest #{CurrentTest} failed.", Ex));
                }

            var Method = Member as MethodInfo;
            if (Method != null)
                {
                if (Method.ContainsGenericParameters)
                    {
                    var Generics =
                        Member.GetAttributes<ITestMethodGenericsAttribute>(IncludeBaseTypes: true)
                            .Select(Attr => !Attr.GenericTypes.IsEmpty())
                            .First();

                    // Generics from current attribute take 1st priority
                    if (AttrTest is ITestMethodGenericsAttribute &&
                        !((ITestMethodGenericsAttribute)AttrTest).GenericTypes.IsEmpty())
                        {
                        Method = Method.MakeGenericMethod(((ITestMethodGenericsAttribute)AttrTest).GenericTypes);
                        }
                    // Then declared generics from other attributes
                    else if (Generics != null)
                        {
                        Method = Method.MakeGenericMethod(Generics.GenericTypes);
                        }
                    // Ignore tested attributes
                    else if (AttrTest is ITestedAttribute) { }
                    else
                        {
                        try
                            {
                            Method = Method.MakeGenericMethod(
                                L.Obj.NewRandom_TypeCreators.Keys.Random(Method.GetGenericArguments().Length).Array());
                            }
                        catch (Exception Ex)
                            {
                            this.AddException(
                                new InternalTestFailureException($"Unable to find generics for Member: {FullName}\nTest #{CurrentTest} ", Ex));
                            }
                        }
                    }
                try
                    {
                    // ReSharper disable UseNullPropagation
                    if (AttrTest is ITestResultAttribute)
                        ((ITestResultAttribute)AttrTest).RunTest(Method);

                    if (AttrTest is ITestFailsAttribute)
                        ((ITestFailsAttribute)AttrTest).RunTest(Method);

                    if (AttrTest is ITestSucceedsAttribute)
                        ((ITestSucceedsAttribute)AttrTest).RunTest(Method);

                    if (AttrTest is ITestSourceAttribute)
                        ((ITestSourceAttribute)AttrTest).RunTest(Method);
                    // ReSharper restore UseNullPropagation
                    }
                catch (Exception Ex)
                    {
                    this.AddException(new InternalTestFailureException(
                        $"\nTesting for Method: {FullName} \nTest #{CurrentTest} failed.", Ex));
                    }
                }
            }

        private void TestTypeInterface(Type Type)
            {
            // TODO: Test type - Type Test Interface
            }

        // ReSharper disable once SuggestBaseTypeForParameter
        private void TestTypeDeclarationAttributes(Type Type)
            {
            Type.GetAttributes<ILUnitAttribute>(IncludeBaseTypes: true).Each(
                (i, AttrTest) => this.TestAttribute(AttrTest, Type, i + 1));
            }

        private void TestNullability(Type Type)
            {
            if (!this.EnforceNullabilityAttributes)
                return;

            uint Tested = 0;

            MethodInfo[] Methods = Type.GetExtensionMethods();

            foreach (var Method in Methods)
                {
                bool MethodCanBeNull = Method.HasAttribute<CanBeNullAttribute>(IncludeBaseClasses: false);

                var TheMethod = Method;

                if (Method.ContainsGenericParameters)
                    {
                    try
                        {
                        TheMethod = Method.MakeGenericMethod(typeof(int));
                        }
                    catch
                        {
                        try
                            {
                            TheMethod = Method.MakeGenericMethod(typeof(string));
                            }
                        catch
                            {
                            try
                                {
                                TheMethod = Method.MakeGenericMethod(typeof(int), typeof(string));
                                }
                            catch
                                {
                                try
                                    {
                                    TheMethod = Method.MakeGenericMethod(typeof(string), typeof(string));
                                    }
                                catch
                                    {
                                    try
                                        {
                                        TheMethod = Method.MakeGenericMethod(typeof(int), typeof(int), typeof(int));
                                        }
                                    catch
                                        {
                                        try
                                            {
                                            TheMethod = Method.MakeGenericMethod(typeof(string), typeof(string), typeof(string));
                                            }
                                        catch { }
                                        }
                                    }
                                }
                            }
                        }
                    }

                // If we cant find a proper type to use to fill parameters, skip the method.
                if (TheMethod.ContainsGenericParameters)
                    continue;


                ParameterInfo[] Parameters = TheMethod.GetParameters();

                bool[] ParametersCanBeNull = Parameters.Convert(
                    Param => Param.HasAttribute<CanBeNullAttribute>(IncludeBaseClasses: false));

                int ParameterCount = Parameters.Length;

                for (int i = 0; i < ParametersCanBeNull.Length; i++)
                    {
                    bool NullsAllowedForParameter = ParametersCanBeNull[i];

                    // For Optional Value Type parameters, do not expect a null value to cause a failure.
                    // ReSharper disable once ConvertIfToOrExpression
                    if (Parameters[i].IsOptional && Parameters[i].ParameterType.IsValueType && !Parameters[i].ParameterType.IsNullable())
                        NullsAllowedForParameter = true;

                    bool ParameterIsNullable = Parameters[i].CanBeNull();

                    var Params = new object[ParameterCount];

                    for (int j = 0; j < Params.Length; j++)
                        {
                        if (i == j)
                            Params[j] = null;
                        else
                            Params[j] = Parameters[j].ParameterType.NewRandom();

                        var ParamBound = Parameters[j].GetAttribute<ITestBoundAttribute>();
                        if (ParamBound != null)
                            {
                            try
                                {
                                Params[j] = Parameters[j].ParameterType.NewRandom(ParamBound.Minimum,
                                    ParamBound.Maximum);
                                }
                            catch (Exception Ex)
                                {
                                this.AddException(new InternalTestFailureException(
                                    $"Method {Method.FullyQualifiedName()} could not generate random parameter #{j + 1} {Parameters[j].ParameterType.FullName}",
                                    Ex));
                                }
                            }
                        }
                    try
                        {
                        bool Finished = false;
                        L.A(() =>
                            {
                                try
                                    {
                                    var Result = TheMethod.Invoke(obj: null, parameters: Params);

                                    if (!NullsAllowedForParameter && ParameterIsNullable)
                                        {
                                        Finished = true;
                                        this.AddException(new InternalTestFailureException(
                                            $"Method {Method.FullyQualifiedName()} was passed null for parameter {i + 1}, should have failed, but it passed." +
                                            $"\n\n Resolve this by adding [{typeof(CanBeNullAttribute).FullyQualifiedName().BeforeLast("Attribute")}] to the parameter, " +
                                            $"\n Or adding: if ({Parameters[i].Name} == null) throw new ArgumentNullException(\"{Parameters[i].Name}\");"));
                                        }

                                    if (!MethodCanBeNull
                                        && TheMethod.ReturnType != typeof(void)
                                        && !TheMethod.ReturnType.IsNullable()
                                        && Result.IsNull())
                                        {
                                        Finished = true;
                                        this.AddException(new InternalTestFailureException(
                                            $"Method {Method.FullyQualifiedName()} was passed null for parameter {i + 1}, should not have returned null, but it did." +
                                            $"\n\n Resolve this by adding [{typeof(CanBeNullAttribute).FullyQualifiedName().BeforeLast("Attribute")}] to the method, " +
                                            "\n Or adding a non-null return value."));
                                        }
                                    }
                                catch (Exception Ex)
                                    {
                                    if (!NullsAllowedForParameter && ParameterIsNullable)
                                        {
                                        Finished = true;
                                        // Enforces use of ArgumentNullException on any field marked [NotNull]
                                        if (!(Ex is ArgumentNullException) ||
                                            ((ArgumentNullException)Ex).ParamName != Parameters[i].Name)
                                            {
                                            this.AddException(new InternalTestFailureException(
                                                $"Method {Method.FullyQualifiedName()} was passed null for parameter {i + 1}, should have failed with an ArgumentNullException matching the parameter name, but it threw an {Ex.GetType()}: {Ex.Message}. " +
                                                $"\n\n Resolve this by adding: if ({Parameters[i].Name} == null) throw new ArgumentNullException(\"{Parameters[i].Name}\");"));
                                            }
                                        }
                                    }

                                Finished = true;
                            }).Async(TimeLimitMilliseconds: 300)();

                        uint Waited = 0;

                        while (Waited < 300)
                            {
                            Thread.Sleep(millisecondsTimeout: 1);
                            Waited += 1;

                            if (Finished)
                                break;
                            }

                        if (!Finished)
                            this.AddException(new InternalTestFailureException(
                                $"Method {Method.FullyQualifiedName()} timed out. Passed parameters: {Params.ToS()}"));
                        }
                    catch (Exception Ex)
                        {
                        this.AddException(new InternalTestFailureException(
                            $"Method {Method.FullyQualifiedName()} was passed null for parameter {i + 1} and failed with {Ex}"));
                        }
                    Tested++;
                    }
                }


            if (Tested > 0)
                this._Output.WriteLine(
                    $"{Type.FullyQualifiedName()}".Pad(Length: 30) + $"Ran {Tested} Nullability {"Test".Pluralize(Tested)}");
            }

        #region Virtual Assertions

        private void TestTypeAssertions(Type Type)
            {
            try
                {
                this.TypeAssertions(Type);
                }
            catch (Exception Ex)
                {
                this.AddException(new InternalTestFailureException(
                    $"\nTesting custom Type assertions failed for Type: {Type.FullyQualifiedName()} failed.", Ex));
                }
            }

        private void TestMethodAssertions(MethodInfo Method)
            {
            try
                {
                this.MethodAssertions(Method);
                }
            catch (Exception Ex)
                {
                this.AddException(new InternalTestFailureException(
                    $"\nTesting custom Method assertions failed for Method: {Method.FullyQualifiedName()} failed.", Ex));
                }
            }

        private void TestAllMemberAssertions(MemberInfo Member)
            {
            try
                {
                this.AllMemberAssertions(Member);
                }
            catch (Exception Ex)
                {
                this.AddException(new InternalTestFailureException(
                    $"\nTesting custom Member assertions failed for Member: {Member.FullyQualifiedName()} failed.", Ex));
                }
            }

        private void TestPropertyAssertions(PropertyInfo Property)
            {
            try
                {
                this.PropertyAssertions(Property);
                }
            catch (Exception Ex)
                {
                this.AddException(new InternalTestFailureException(
                    $"\nTesting custom Property assertions failed for Property: {Property.FullyQualifiedName()} failed.", Ex));
                }
            }

        private void TestEventAssertions(EventInfo Event)
            {
            try
                {
                this.EventAssertions(Event);
                }
            catch (Exception Ex)
                {
                this.AddException(new InternalTestFailureException(
                    $"\nTesting custom Event assertions failed for Event: {Event.FullyQualifiedName()} failed.", Ex));
                }
            }

        private void TestFieldAssertions(FieldInfo Field)
            {
            try
                {
                this.FieldAssertions(Field);
                }
            catch (Exception Ex)
                {
                this.AddException(new InternalTestFailureException(
                    $"\nTesting custom Event assertions failed for Field: {Field.FullyQualifiedName()} failed.", Ex));
                }
            }

        private void TestParameterAssertions(ParameterInfo Parameter)
            {
            try
                {
                this.ParameterAssertions(Parameter);
                }
            catch (Exception Ex)
                {
                this.AddException(new InternalTestFailureException(
                    $"\nTesting custom Event assertions failed for Parameter: {Parameter.FullyQualifiedName()} failed.", Ex));
                }
            }

        /// <summary>
        /// Override this method to make assertions on every exposed Type in the assembly. 
        /// This method will get called many times and all Exceptions and failed 
        /// assertions will be added to the list.
        /// </summary>
        protected virtual void TypeAssertions(Type Type) { }

        /// <summary>
        /// Override this method to make assertions on every exposed MemberInfo in the assembly. 
        /// This method will get called many times and all Exceptions and failed 
        /// assertions will be added to the list.
        /// </summary>
        protected virtual void AllMemberAssertions(MemberInfo Member) { }

        /// <summary>
        /// Override this method to make assertions on every exposed MethodInfo in the assembly. 
        /// This method will get called many times and all Exceptions and failed 
        /// assertions will be added to the list.
        /// </summary>
        protected virtual void MethodAssertions(MethodInfo Method) { }

        /// <summary>
        /// Override this method to make assertions on every exposed ParameterInfo in the assembly. 
        /// This method will get called many times and all Exceptions and failed 
        /// assertions will be added to the list.
        /// </summary>
        protected virtual void ParameterAssertions(ParameterInfo Parameter) { }

        /// <summary>
        /// Override this method to make assertions on every exposed PropertyInfo in the assembly. 
        /// This method will get called many times and all Exceptions and failed 
        /// assertions will be added to the list.
        /// </summary>
        protected virtual void PropertyAssertions(PropertyInfo Prop) { }

        /// <summary>
        /// Override this method to make assertions on every exposed EventInfo in the assembly. 
        /// This method will get called many times and all Exceptions and failed 
        /// assertions will be added to the list.
        /// </summary>
        protected virtual void EventAssertions(EventInfo Event) { }

        /// <summary>
        /// Override this method to make assertions on every exposed FieldInfo in the assembly. 
        /// This method will get called many times and all Exceptions and failed 
        /// assertions will be added to the list.
        /// </summary>
        protected virtual void FieldAssertions(FieldInfo Field) { }

        #endregion

        ////////////////////////////////////////////////////////

        #region Test Failure Methods

        /// <summary>
        /// Reports Exception #1, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure01()
            {
            this.PerformTestsOnce();
            this.ThrowException(Number: 0);
            }

        /// <summary>
        /// Reports Exception #2, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure02()
            {
            this.PerformTestsOnce();
            this.ThrowException(Number: 1);
            }

        /// <summary>
        /// Reports Exception #3, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure03()
            {
            this.PerformTestsOnce();
            this.ThrowException(Number: 2);
            }

        /// <summary>
        /// Reports Exception #4, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure04()
            {
            this.PerformTestsOnce();
            this.ThrowException(Number: 3);
            }

        /// <summary>
        /// Reports Exception #5, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure05()
            {
            this.PerformTestsOnce();
            this.ThrowException(Number: 4);
            }

        /// <summary>
        /// Reports Exception #6, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure06()
            {
            this.PerformTestsOnce();
            this.ThrowException(Number: 5);
            }

        /// <summary>
        /// Reports Exception #7, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure07()
            {
            this.PerformTestsOnce();
            this.ThrowException(Number: 6);
            }

        /// <summary>
        /// Reports Exception #8, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure08()
            {
            this.PerformTestsOnce();
            this.ThrowException(Number: 7);
            }

        /// <summary>
        /// Reports Exception #9, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure09()
            {
            this.PerformTestsOnce();
            this.ThrowException(Number: 8);
            }

        /// <summary>
        /// Reports Exception #10, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure10()
            {
            this.PerformTestsOnce();
            this.ThrowException(Number: 9);
            }

        #endregion

        private void ThrowException(int Number)
            {
            var Ex = _AssemblyExceptions.HasIndex(Number)
                ? _AssemblyExceptions.GetAt(Number)
                : null;

            if (Ex != null)
                throw Ex;
            }

        /// <summary>
        /// Add an exception to the list, only the first 10 will be reported in the test runner.
        /// </summary>
        protected void AddException(Exception Ex)
            {
            if (!_AssemblyExceptions.Has(Ex2 => Ex.ToS() == Ex2.ToS()))
                {
                _AssemblyExceptions.Add(Ex);
                }
            }

        private void PerformTestsOnce()
            {
            if (!_TestsPerformed)
                {
                this.RunTests();

                _TestsPerformed = true;
                }
            }

        private static bool _TestsPerformed;
        private static readonly List<Exception> _AssemblyExceptions = new List<Exception>();
        }

    internal static class AssemblyTesterExt
        {
        internal static string NameofParts(this string In, MemberInfo Member, string Namespace, bool UseGlobal)
            {
            string[] Parts = In.After($"{Namespace}.").Split(".");

            string Out = "";
            string Path = "";

            // When the namespace name is the same as the type name, global:: is needed to explicitally target the method
            bool GlobalNeeded = Namespace.Split(".").Has(Parts.First()) || UseGlobal;

            foreach (string NamespacePart in Namespace.Split("."))
                {
                if (!string.IsNullOrEmpty(Out))
                    Out += "+ \".\" + ";

                // Root namespaces want no global::, all others do.
                if (Path == "")
                    Out += $"nameof({Path}{NamespacePart})";
                else
                    Out += $"nameof(global::{Path}{NamespacePart})";

                Path += $"{NamespacePart}.";
                }

            Path = "";

            foreach (string Part in Parts)
                {
                if (!string.IsNullOrEmpty(Out))
                    Out += "+ \".\" + ";

                if (GlobalNeeded)
                    Out += $"nameof(global::{Namespace}.{Path}{Part})";
                else
                    Out += $"nameof({Path}{Part})";

                Path += $"{Part}.";
                }

            var Replacements = new Dictionary<string, string>
                {
                ["`1"] = "",
                ["`2"] = "<,>",
                ["`3"] = "<,,>",
                ["`4"] = "<,,,>",
                ["`5"] = "<,,,,>",
                ["`6"] = "<,,,,,>",
                ["`7"] = "<,,,,,,>",
                ["`8"] = "<,,,,,,,>",
                [".get_"] = ".",
                [".set_"] = ".",
                [".add_"] = ".",
                [".remove_"] = "."
                };

            return Out.ReplaceAll(Replacements);
            }
        }
    }