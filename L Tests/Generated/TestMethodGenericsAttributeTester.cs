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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestMethodGenericsAttribute))]
    public partial class TestMethodGenericsAttributeTester : XUnitOutputTester
        {
        public TestMethodGenericsAttributeTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~TestMethodGenericsAttributeTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestMethodGenericsAttribute) + "." + nameof(TestMethodGenericsAttribute.GenericTypes))]
        public void get_GenericTypes()
            {
            // TODO: Implement method test LCore.LUnit.TestMethodGenericsAttribute.get_GenericTypes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestMethodGenericsAttribute) + "." + nameof(TestMethodGenericsAttribute.GenericTypes))]
        public void GenericTypes()
            {
            // TODO: Implement method test LCore.LUnit.TestMethodGenericsAttribute.GenericTypes
            }

        }
    }