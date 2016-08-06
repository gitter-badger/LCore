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
    [Trait(Category, AssemblyTests)]
    public abstract class AssemblyTester : XUnitOutputTester
        {
        protected abstract Type AssemblyType { get; }

        protected virtual bool EnforceNullabilityAttributes => false;

        protected Assembly Assembly => Assembly.GetAssembly(this.AssemblyType);

        protected Type[] AssemblyTypes => this.Assembly.GetExportedTypes();

        ////////////////////////////////////////////////////////

        protected AssemblyTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ////////////////////////////////////////////////////////

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
                                L.Ref.NewRandom_TypeCreators.Keys.Random(Method.GetGenericArguments().Length).Array());
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
                this._Output.WriteLine($"Ran {Tested} Nullability {"Test".Pluralize(Tested)}".Pad(30) + $"{Type.FullyQualifiedName()}");
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
                    $"\nTesting custom Method assertions failed for Type: {Method.FullyQualifiedName()} failed.", Ex));
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
                    $"\nTesting custom Member assertions failed for Type: {Member.FullyQualifiedName()} failed.", Ex));
                }
            }

        private void TestPropertyAssertions(PropertyInfo Prop)
            {
            try
                {
                this.PropertyAssertions(Prop);
                }
            catch (Exception Ex)
                {
                this.AddException(new InternalTestFailureException(
                    $"\nTesting custom Property assertions failed for Type: {Prop.FullyQualifiedName()} failed.", Ex));
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
                    $"\nTesting custom Event assertions failed for Type: {Event.FullyQualifiedName()} failed.", Ex));
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
                    $"\nTesting custom Event assertions failed for Type: {Field.FullyQualifiedName()} failed.", Ex));
                }
            }

        protected virtual void TypeAssertions(Type Type) { }

        protected virtual void AllMemberAssertions(MemberInfo Member) { }

        protected virtual void MethodAssertions(MethodInfo Method) { }

        protected virtual void PropertyAssertions(PropertyInfo Prop) { }

        protected virtual void EventAssertions(EventInfo Event) { }

        protected virtual void FieldAssertions(FieldInfo Field) { }

        #endregion

        ////////////////////////////////////////////////////////

        #region Test Failure Methods

        [Fact]
        public void TestFailure01()
            {
            this.PerformTestsOnce();
            this.ThrowException(0);
            }

        [Fact]
        public void TestFailure02()
            {
            this.PerformTestsOnce();
            this.ThrowException(1);
            }

        [Fact]
        public void TestFailure03()
            {
            this.PerformTestsOnce();
            this.ThrowException(2);
            }

        [Fact]
        public void TestFailure04()
            {
            this.PerformTestsOnce();
            this.ThrowException(3);
            }

        [Fact]
        public void TestFailure05()
            {
            this.PerformTestsOnce();
            this.ThrowException(4);
            }

        [Fact]
        public void TestFailure06()
            {
            this.PerformTestsOnce();
            this.ThrowException(5);
            }

        [Fact]
        public void TestFailure07()
            {
            this.PerformTestsOnce();
            this.ThrowException(6);
            }

        [Fact]
        public void TestFailure08()
            {
            this.PerformTestsOnce();
            this.ThrowException(7);
            }

        [Fact]
        public void TestFailure09()
            {
            this.PerformTestsOnce();
            this.ThrowException(8);
            }

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