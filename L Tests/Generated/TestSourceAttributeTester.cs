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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestSourceAttribute))]
    public partial class TestSourceAttributeTester : XUnitOutputTester
        {
        public TestSourceAttributeTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~TestSourceAttributeTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestSourceAttribute) + "." + nameof(TestSourceAttribute.ExpectedSource))]
        public void get_ExpectedSource()
            {
            // TODO: Implement method test LCore.LUnit.TestSourceAttribute.get_ExpectedSource
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestSourceAttribute) + "." + nameof(TestSourceAttribute.AdditionalSourceChecks))]
        public void get_AdditionalSourceChecks()
            {
            // TODO: Implement method test LCore.LUnit.TestSourceAttribute.get_AdditionalSourceChecks
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestSourceAttribute) + "." + nameof(TestSourceAttribute.Parameters))]
        public void get_Parameters()
            {
            // TODO: Implement method test LCore.LUnit.TestSourceAttribute.get_Parameters
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestSourceAttribute) + "." + nameof(TestSourceAttribute.ExpectedSource))]
        public void ExpectedSource()
            {
            // TODO: Implement method test LCore.LUnit.TestSourceAttribute.ExpectedSource
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestSourceAttribute) + "." + nameof(TestSourceAttribute.AdditionalSourceChecks))]
        public void AdditionalSourceChecks()
            {
            // TODO: Implement method test LCore.LUnit.TestSourceAttribute.AdditionalSourceChecks
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestSourceAttribute) + "." + nameof(TestSourceAttribute.Parameters))]
        public void Parameters()
            {
            // TODO: Implement method test LCore.LUnit.TestSourceAttribute.Parameters
            }

        }
    }