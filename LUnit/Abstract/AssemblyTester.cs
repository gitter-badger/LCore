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
        protected virtual bool TrackCoverageByNamingConvention => false;

        /// <summary>
        /// Reference to the assembly being tested.
        /// </summary>
        protected Assembly Assembly => Assembly.GetAssembly(this.AssemblyType);

        /// <summary>
        /// All types exposed by the targeted Assembly.
        /// </summary>
        protected Type[] AssemblyTypes => this.Assembly.GetExportedTypes();

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
            this._Output.WriteLine($"Testing Assembly: {this.Assembly.GetName().Name}");
            this._Output.WriteLine("");

            Type[] Types = this.AssemblyTypes.WithoutAttribute<ExcludeFromCodeCoverageAttribute, Type>(false).Array();

            Type[] StaticTypes = Types.Select(Type => Type.IsStatic());
            Type[] NonStaticTypes = Types.Select(Type => Type.IsClass);

            if (StaticTypes.Length > 0)
                {
                this._Output.WriteLine("Static Classes: ");
                foreach (var Type in StaticTypes)
                    {
                    var TestData = Type.GetTestData();

                    uint Coverage = TestData.CoveragePercent;

                    this._Output.WriteLine($"{Type.FullyQualifiedName().Pad(60)}({$"{Coverage}".AlignRight(3)}%)");
                    }
                this._Output.WriteLine("");
                }

            if (NonStaticTypes.Length > 0)
                {
                this._Output.WriteLine("Classes: ");
                foreach (var Type in NonStaticTypes)
                    {
                    this._Output.WriteLine($"{Type.FullyQualifiedName()}");
                    }
                this._Output.WriteLine("");
                }
            }

        [Fact]
        public void AssemblyMissingCoverage()
            {
            this._Output.WriteLine($"Testing Assembly: {this.Assembly.GetName().Name}");
            this._Output.WriteLine("");

            Type[] Types = this.AssemblyTypes.WithoutAttribute<ExcludeFromCodeCoverageAttribute, Type>(false).Array();

            foreach (var Type in Types)
                {
                MemberInfo[] Members = Type.GetMembers();

                List<Tuple<string, string, string>> MemberNaming = Members.Convert(Member => Member.GetTargetingName()).List();


                MemberNaming.ToDictionary();
                }
            }

        ////////////////////////////////////////////////////////

        private void RunTests()
            {
            Type[] Types = this.AssemblyTypes.WithoutAttribute<ExcludeFromCodeCoverageAttribute, Type>(false).Array();

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
                        Member.GetAttributes<ITestMethodGenericsAttribute>(true)
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
            Type.GetAttributes<ILUnitAttribute>(true).Each(
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
                bool MethodCanBeNull = Method.HasAttribute<CanBeNullAttribute>(false);

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
                    Param => Param.HasAttribute<CanBeNullAttribute>(false));

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
                                    var Result = TheMethod.Invoke(null, Params);

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
                            }).Async(300)();

                        uint Waited = 0;

                        while (Waited < 300)
                            {
                            Thread.Sleep(1);
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
                    $"{Type.FullyQualifiedName()}".Pad(30) + $"Ran {Tested} Nullability {"Test".Pluralize(Tested)}");
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
            this.ThrowException(0);
            }

        /// <summary>
        /// Reports Exception #2, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure02()
            {
            this.PerformTestsOnce();
            this.ThrowException(1);
            }

        /// <summary>
        /// Reports Exception #3, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure03()
            {
            this.PerformTestsOnce();
            this.ThrowException(2);
            }

        /// <summary>
        /// Reports Exception #4, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure04()
            {
            this.PerformTestsOnce();
            this.ThrowException(3);
            }

        /// <summary>
        /// Reports Exception #5, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure05()
            {
            this.PerformTestsOnce();
            this.ThrowException(4);
            }

        /// <summary>
        /// Reports Exception #6, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure06()
            {
            this.PerformTestsOnce();
            this.ThrowException(5);
            }

        /// <summary>
        /// Reports Exception #7, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure07()
            {
            this.PerformTestsOnce();
            this.ThrowException(6);
            }

        /// <summary>
        /// Reports Exception #8, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure08()
            {
            this.PerformTestsOnce();
            this.ThrowException(7);
            }

        /// <summary>
        /// Reports Exception #9, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure09()
            {
            this.PerformTestsOnce();
            this.ThrowException(8);
            }

        /// <summary>
        /// Reports Exception #10, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure10()
            {
            this.PerformTestsOnce();
            this.ThrowException(9);
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
    }