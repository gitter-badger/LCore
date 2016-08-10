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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestSucceedesAttribute))]
    public partial class TestSucceedesAttributeTester : XUnitOutputTester
        {
        public TestSucceedesAttributeTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~TestSucceedesAttributeTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestSucceedesAttribute) + "." + nameof(TestSucceedesAttribute.AdditionalChecks))]
        public void get_AdditionalChecks()
            {
            // TODO: Implement method test LCore.LUnit.TestSucceedesAttribute.get_AdditionalChecks
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestSucceedesAttribute) + "." + nameof(TestSucceedesAttribute.AdditionalChecks))]
        public void set_AdditionalChecks()
            {
            // TODO: Implement method test LCore.LUnit.TestSucceedesAttribute.set_AdditionalChecks
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestSucceedesAttribute) + "." + nameof(TestSucceedesAttribute.Parameters))]
        public void get_Parameters()
            {
            // TODO: Implement method test LCore.LUnit.TestSucceedesAttribute.get_Parameters
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestSucceedesAttribute) + "." + nameof(TestSucceedesAttribute.Parameters))]
        public void set_Parameters()
            {
            // TODO: Implement method test LCore.LUnit.TestSucceedesAttribute.set_Parameters
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestSucceedesAttribute) + "." + nameof(TestSucceedesAttribute.AdditionalChecks))]
        public void AdditionalChecks()
            {
            // TODO: Implement method test LCore.LUnit.TestSucceedesAttribute.AdditionalChecks
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestSucceedesAttribute) + "." + nameof(TestSucceedesAttribute.Parameters))]
        public void Parameters()
            {
            // TODO: Implement method test LCore.LUnit.TestSucceedesAttribute.Parameters
            }

        }
    }