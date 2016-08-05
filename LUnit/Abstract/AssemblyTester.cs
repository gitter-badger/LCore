using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using LCore.Extensions;
using LCore.Extensions.Optional;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Xunit.Abstractions;
using static LCore.LUnit.LUnit.Categories;

namespace LCore.LUnit
    {
    [Trait(Category, AssemblyTest)]
    public abstract class AssemblyTester : MultiTestReporter
        {
        private readonly ITestOutputHelper _Output;

        protected AssemblyTester(ITestOutputHelper Output)
            {
            this._Output = Output;
            }

        protected abstract Type AssemblyType { get; }

        protected Assembly Assembly => Assembly.GetAssembly(this.AssemblyType);

        protected Type[] AssemblyTypes => this.Assembly.GetExportedTypes();

        [Fact]
        public void TestAssembly()
            {
            this._Output?.WriteLine($"Testing Assembly: {this.Assembly.GetName().Name}");
            this._Output?.WriteLine("");

            Type[] Types = this.AssemblyTypes.WithoutAttribute<ExcludeFromCodeCoverageAttribute, Type>(false).Array();

            Type[] StaticTypes = Types.Select(Type => Type.IsStatic());
            Type[] NonStaticTypes = Types.Select(Type => Type.IsClass);

            if (StaticTypes.Length > 0)
                {
                this._Output?.WriteLine("Static Classes: ");
                foreach (var Type in StaticTypes)
                    {
                    var TestData = Type.GetTestData();

                    uint Coverage = TestData.CoveragePercent;

                    this._Output?.WriteLine($"{Type.FullyQualifiedName().Pad(60)}({$"{Coverage}".AlignRight(3)}%)");
                    }
                this._Output?.WriteLine("");
                }

            if (NonStaticTypes.Length > 0)
                {
                this._Output?.WriteLine("Classes: ");
                foreach (var Type in NonStaticTypes)
                    {
                    this._Output?.WriteLine($"{Type.FullyQualifiedName()}");
                    }
                this._Output?.WriteLine("");
                }
            }

        protected override void RunTests()
            {
            Type[] Types = this.AssemblyTypes.WithoutAttribute<ExcludeFromCodeCoverageAttribute, Type>(false).Array();

            if (Types.Length > 0)
                {
                foreach (var Type in Types)
                    {
                    this.TestTypeDeclarationAttributes(Type);

                    this.TestTypeInterface(Type);

                    this.TestTypeMembers(Type);
                    }

                this._Output?.WriteLine("");
                }
            }


        private void TestTypeDeclarationAttributes(Type Type)
            {
            uint TestsRan = 0;

            Dictionary<MemberInfo, List<ILUnitAttribute>> Tests = Type.GetTestMembers();

            Tests.Each(Test =>
                {
                int CurrentTest = 1;
                try
                    {
                    var Key = Test.Key as MethodInfo;
                    if (Key != null)
                        {
                        List<ILUnitAttribute> ValueList = Test.Value.List();
                        ValueList.Reverse();

                        ValueList.Each(AttrTest =>
                            {
                            var Member = Key;

                            if (AttrTest is ITestParameters)
                                LUnit.FixParameterTypes(Member, ((ITestParameters) AttrTest).Parameters);

                            if (Member.ContainsGenericParameters)
                                {
                                var Generics =
                                    Member.GetAttributes<ITestMethodGenericsAttribute>(true)
                                        .Select(Attr => !Attr.GenericTypes.IsEmpty())
                                        .First();

                                // Generics from current attribute take 1st priority
                                if (AttrTest is ITestMethodGenericsAttribute &&
                                    !((ITestMethodGenericsAttribute) AttrTest).GenericTypes.IsEmpty())
                                    {
                                    Member = Member.MakeGenericMethod(((ITestMethodGenericsAttribute) AttrTest).GenericTypes);
                                    }
                                // Then declared generics from other attributes
                                else if (Generics != null)
                                    {
                                    Member = Member.MakeGenericMethod(Generics.GenericTypes);
                                    }
                                // Ignore tested attributes
                                else if (AttrTest is ITestedAttribute) {}
                                else
                                    {
                                    try
                                        {
                                        Member = Member.MakeGenericMethod(
                                            L.Ref.NewRandom_TypeCreators.Keys.Random(Member.GetGenericArguments().Length).Array());
                                        }
                                    catch (Exception Ex)
                                        {
                                        throw new InternalTestFailureException("Unable to find generics for Test Attribute", Ex);
                                        }
                                    }
                                }


                            // ReSharper disable UseNullPropagation
                            if (AttrTest is ITestResultAttribute)
                                ((ITestResultAttribute) AttrTest).RunTest(Member);

                            if (AttrTest is ITestFailsAttribute)
                                ((ITestFailsAttribute) AttrTest).RunTest(Member);

                            if (AttrTest is ITestSucceedsAttribute)
                                ((ITestSucceedsAttribute) AttrTest).RunTest(Member);

                            if (AttrTest is ITestSourceAttribute)
                                ((ITestSourceAttribute) AttrTest).RunTest(Member);
                            // ReSharper restore UseNullPropagation

                            TestsRan++;
                            CurrentTest++;
                            });
                        }
                    else
                        throw new InternalTestFailureException($"Member {Test.Key.Name} is not a method.");
                    }
                catch (Exception Ex)
                    {
                    throw new InternalTestFailureException(
                        $"\nTesting for Member: {Test.Key.FullyQualifiedName()} \nTest #{CurrentTest} failed.\n{Ex.ToS()}\n", Ex);
                    }
                });
            }

        private void TestTypeInterface(Type Type)
            {
            // TODO: Test type - Type Test Interface
            }

        private void TestTypeMembers(Type Type)
            {
            // TODO: Test type - Members - Testable Attributes
            }
        }
    }