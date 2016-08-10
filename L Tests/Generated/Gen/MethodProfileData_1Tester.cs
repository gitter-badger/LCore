using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.Tools
    {
    [Trait(Traits.TargetMember, "LCore.Tools.MethodProfileData`1")]
    public partial class MethodProfileData_1Tester : XUnitOutputTester
        {
        public MethodProfileData_1Tester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~MethodProfileData_1Tester() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.MethodProfileData`1.get_Times")]
        public void get_Times()
            {
            // TODO: Implement method test LCore.Tools.MethodProfileData`1.get_Times
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.MethodProfileData`1.get_AverageMS")]
        public void get_AverageMS()
            {
            // TODO: Implement method test LCore.Tools.MethodProfileData`1.get_AverageMS
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.MethodProfileData`1.Times")]
        public void Times()
            {
            // TODO: Implement method test LCore.Tools.MethodProfileData`1.Times
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.MethodProfileData`1.AverageMS")]
        public void AverageMS()
            {
            // TODO: Implement method test LCore.Tools.MethodProfileData`1.AverageMS
            }

        }
    }