using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using LCore.Extensions;
using Xunit;
using Xunit.Abstractions;
using static LCore.Extensions.L.Test.Categories;

namespace L_Tests
    {
    [Trait(Category, AssemblyTest)]
    public abstract class AssemblyTester
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
        [Trait(Category, AssemblyTest)]
        public void TestAssembly()
            {
            this._Output?.WriteLine($"Testing Assembly: {this.Assembly.GetName().Name}");
            this._Output?.WriteLine("");

            Type[] Types = this.AssemblyTypes.WithoutAttribute<ExcludeFromCodeCoverageAttribute, Type>(false).Array();

            Type[] StaticTypes = Types.Select(Type => Type.IsStatic());
            Type[] NonStaticTypes = Types.Select(Type => Type.IsClass);

            if (StaticTypes.Length > 0)
                {
                this._Output?.WriteLine($"Static Classes: ");
                foreach (var Type in StaticTypes)
                    {
                    var TestData = Type.GetTestData();

                    uint Coverage = TestData.CoveragePercent;

                    this._Output?.WriteLine($"{Type.FullyQualifiedName().Pad(60)}({$"{Coverage}".AlignRight(3)}%)");

                    this.TestTypeDeclarationAttributes(Type);

                    this.TestTypeInterface(Type);

                    this.TestTypeMembers(Type);
                    }
                this._Output?.WriteLine("");
                }

            if (StaticTypes.Length > 0)
                {
                this._Output?.WriteLine($"Classes: ");
                foreach (var Type in NonStaticTypes)
                    {
                    var TestData = Type.GetTestData();

                    uint Coverage = TestData.CoveragePercent;

                    this._Output?.WriteLine($"{Type.FullyQualifiedName()}");

                    this.TestTypeDeclarationAttributes(Type);

                    this.TestTypeInterface(Type);

                    this.TestTypeMembers(Type);
                    }
                this._Output?.WriteLine("");
                }
            }

        private void TestTypeDeclarationAttributes(Type Type)
            {
            // TODO: Test type - Type Attribute Validators
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