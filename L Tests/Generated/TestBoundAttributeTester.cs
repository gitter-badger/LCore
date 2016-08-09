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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestBoundAttribute))]
    public partial class TestBoundAttributeTester : XUnitOutputTester
        {
        public TestBoundAttributeTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~TestBoundAttributeTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestBoundAttribute) + "." + nameof(TestBoundAttribute.Minimum))]
        public void get_Minimum()
            {
            // TODO: Implement method test LCore.LUnit.TestBoundAttribute.get_Minimum
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestBoundAttribute) + "." + nameof(TestBoundAttribute.Maximum))]
        public void get_Maximum()
            {
            // TODO: Implement method test LCore.LUnit.TestBoundAttribute.get_Maximum
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestBoundAttribute) + "." + nameof(TestBoundAttribute.ValueType))]
        public void get_ValueType()
            {
            // TODO: Implement method test LCore.LUnit.TestBoundAttribute.get_ValueType
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestBoundAttribute) + "." + nameof(TestBoundAttribute.Minimum))]
        public void Minimum()
            {
            // TODO: Implement method test LCore.LUnit.TestBoundAttribute.Minimum
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestBoundAttribute) + "." + nameof(TestBoundAttribute.Maximum))]
        public void Maximum()
            {
            // TODO: Implement method test LCore.LUnit.TestBoundAttribute.Maximum
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestBoundAttribute) + "." + nameof(TestBoundAttribute.ValueType))]
        public void ValueType()
            {
            // TODO: Implement method test LCore.LUnit.TestBoundAttribute.ValueType
            }

        }
    }