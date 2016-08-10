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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestResultAttribute))]
    public partial class TestResultAttributeTester : XUnitOutputTester
        {
        public TestResultAttributeTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~TestResultAttributeTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestResultAttribute) + "." + nameof(TestResultAttribute.Parameters))]
        public void get_Parameters()
            {
            // TODO: Implement method test LCore.LUnit.TestResultAttribute.get_Parameters
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestResultAttribute) + "." + nameof(TestResultAttribute.ExpectedResult))]
        public void get_ExpectedResult()
            {
            // TODO: Implement method test LCore.LUnit.TestResultAttribute.get_ExpectedResult
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestResultAttribute) + "." + nameof(TestResultAttribute.AdditionalResultChecks))]
        public void get_AdditionalResultChecks()
            {
            // TODO: Implement method test LCore.LUnit.TestResultAttribute.get_AdditionalResultChecks
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestResultAttribute) + "." + nameof(TestResultAttribute.GenericTypes))]
        public void get_GenericTypes()
            {
            // TODO: Implement method test LCore.LUnit.TestResultAttribute.get_GenericTypes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestResultAttribute) + "." + nameof(TestResultAttribute.GenericTypes))]
        public void set_GenericTypes()
            {
            // TODO: Implement method test LCore.LUnit.TestResultAttribute.set_GenericTypes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestResultAttribute) + "." + nameof(TestResultAttribute.Parameters))]
        public void Parameters()
            {
            // TODO: Implement method test LCore.LUnit.TestResultAttribute.Parameters
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestResultAttribute) + "." + nameof(TestResultAttribute.ExpectedResult))]
        public void ExpectedResult()
            {
            // TODO: Implement method test LCore.LUnit.TestResultAttribute.ExpectedResult
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestResultAttribute) + "." + nameof(TestResultAttribute.AdditionalResultChecks))]
        public void AdditionalResultChecks()
            {
            // TODO: Implement method test LCore.LUnit.TestResultAttribute.AdditionalResultChecks
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestResultAttribute) + "." + nameof(TestResultAttribute.GenericTypes))]
        public void GenericTypes()
            {
            // TODO: Implement method test LCore.LUnit.TestResultAttribute.GenericTypes
            }

        }
    }