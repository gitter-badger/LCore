using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.LUnit
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestFailsAttribute))]
    public partial class TestFailsAttributeTester : XUnitOutputTester
        {
        public TestFailsAttributeTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~TestFailsAttributeTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestFailsAttribute) + "." + nameof(TestFailsAttribute.ExceptionType))]
        public void get_ExceptionType()
            {
            // TODO: Implement method test LCore.LUnit.TestFailsAttribute.get_ExceptionType
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestFailsAttribute) + "." + nameof(TestFailsAttribute.ExceptionType))]
        public void set_ExceptionType()
            {
            // TODO: Implement method test LCore.LUnit.TestFailsAttribute.set_ExceptionType
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestFailsAttribute) + "." + nameof(TestFailsAttribute.AdditionalChecks))]
        public void get_AdditionalChecks()
            {
            // TODO: Implement method test LCore.LUnit.TestFailsAttribute.get_AdditionalChecks
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestFailsAttribute) + "." + nameof(TestFailsAttribute.AdditionalChecks))]
        public void set_AdditionalChecks()
            {
            // TODO: Implement method test LCore.LUnit.TestFailsAttribute.set_AdditionalChecks
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestFailsAttribute) + "." + nameof(TestFailsAttribute.Parameters))]
        public void get_Parameters()
            {
            // TODO: Implement method test LCore.LUnit.TestFailsAttribute.get_Parameters
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestFailsAttribute) + "." + nameof(TestFailsAttribute.Parameters))]
        public void set_Parameters()
            {
            // TODO: Implement method test LCore.LUnit.TestFailsAttribute.set_Parameters
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestFailsAttribute) + "." + nameof(TestFailsAttribute.ExceptionType))]
        public void ExceptionType()
            {
            // TODO: Implement method test LCore.LUnit.TestFailsAttribute.ExceptionType
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestFailsAttribute) + "." + nameof(TestFailsAttribute.AdditionalChecks))]
        public void AdditionalChecks()
            {
            // TODO: Implement method test LCore.LUnit.TestFailsAttribute.AdditionalChecks
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestFailsAttribute) + "." + nameof(TestFailsAttribute.Parameters))]
        public void Parameters()
            {
            // TODO: Implement method test LCore.LUnit.TestFailsAttribute.Parameters
            }

        }
    }