using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
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

        protected AssemblyTester([NotNull] ITestOutputHelper Output) : base(Output) {}

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
                    this.TestMethodAssertions((MethodInfo) Member);
                if (Member is PropertyInfo)
                    this.TestPropertyAssertions((PropertyInfo) Member);
                if (Member is FieldInfo)
                    this.TestFieldAssertions((FieldInfo) Member);
                if (Member is EventInfo)
                    this.TestEventAssertions((EventInfo) Member);

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
                    ((IValidateAttribute) AttrTest).RunTest(Member);
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
                        !((ITestMethodGenericsAttribute) AttrTest).GenericTypes.IsEmpty())
                        {
                        Method = Method.MakeGenericMethod(((ITestMethodGenericsAttribute) AttrTest).GenericTypes);
                        }
                    // Then declared generics from other attributes
                    else if (Generics != null)
                        {
                        Method = Method.MakeGenericMethod(Generics.GenericTypes);
                        }
                    // Ignore tested attributes
                    else if (AttrTest is ITestedAttribute) {}
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
                        ((ITestResultAttribute) AttrTest).RunTest(Method);

                    if (AttrTest is ITestFailsAttribute)
                        ((ITestFailsAttribute) AttrTest).RunTest(Method);

                    if (AttrTest is ITestSucceedsAttribute)
                        ((ITestSucceedsAttribute) AttrTest).RunTest(Method);

                    if (AttrTest is ITestSourceAttribute)
                        ((ITestSourceAttribute) AttrTest).RunTest(Method);
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

        private void TestTypeDeclarationAttributes(Type Type)
            {
            Type.GetAttributes<ILUnitAttribute>(true).Each(
                (i, AttrTest) => this.TestAttribute(AttrTest, Type, i + 1));
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

        protected virtual void TypeAssertions(Type Type) {}

        protected virtual void AllMemberAssertions(MemberInfo Member) {}

        protected virtual void MethodAssertions(MethodInfo Method) {}

        protected virtual void PropertyAssertions(PropertyInfo Prop) {}

        protected virtual void EventAssertions(EventInfo Event) {}

        protected virtual void FieldAssertions(FieldInfo Field) {}

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