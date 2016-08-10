using System;
using System.Collections;
using System.Collections.Generic;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart

namespace LUnit_Tests.LCore.LUnit
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestAttribute))]
    public partial class TestAttributeTester : XUnitOutputTester
        {
        public TestAttributeTester(ITestOutputHelper Output) : base(Output) { }

        ~TestAttributeTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestAttribute) + "." + nameof(TestAttribute.RunTest))]
        public void RunTest()
            {
            // TODO: Implement method test LCore.LUnit.TestAttribute.RunTest
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestAttribute) + "." + nameof(TestAttribute.GenericTypes))]
        public void get_GenericTypes()
            {
            // TODO: Implement method test LCore.LUnit.TestAttribute.get_GenericTypes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestAttribute) + "." + nameof(TestAttribute.GenericTypes))]
        public void set_GenericTypes()
            {
            // TODO: Implement method test LCore.LUnit.TestAttribute.set_GenericTypes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestAttribute) + "." + nameof(TestAttribute.GenericTypes))]
        public void GenericTypes()
            {
            // TODO: Implement method test LCore.LUnit.TestAttribute.GenericTypes
            }

        }
    }