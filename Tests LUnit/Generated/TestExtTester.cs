using System;
using System.Collections;
using System.Collections.Generic;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart

namespace LUnit_Tests.LCore.LUnit
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestExt))]
    public partial class TestExtTester : XUnitOutputTester
        {
        public TestExtTester(ITestOutputHelper Output) : base(Output) {}

        ~TestExtTester() {}

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestExt) + "." + nameof(TestExt.GetTestMembers))]
        public void GetTestMembers()
            {
            // TODO: Implement method test LCore.LUnit.TestExt.GetTestMembers
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestExt) + "." + nameof(TestExt.RunTest))]
        public void RunTest_ITestResultAttribute_MethodInfo()
            {
            // TODO: Implement method test LCore.LUnit.TestExt.RunTest
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestExt) + "." + nameof(TestExt.RunTest))]
        public void RunTest_ITestFailsAttribute_MethodInfo()
            {
            // TODO: Implement method test LCore.LUnit.TestExt.RunTest
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestExt) + "." + nameof(TestExt.RunTest))]
        public void RunTest_ITestSucceedsAttribute_MethodInfo()
            {
            // TODO: Implement method test LCore.LUnit.TestExt.RunTest
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestExt) + "." + nameof(TestExt.RunTest))]
        public void RunTest_ITestSourceAttribute_MethodInfo()
            {
            // TODO: Implement method test LCore.LUnit.TestExt.RunTest
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestExt) + "." + nameof(TestExt.RunTest))]
        public void RunTest_IValidateAttribute_MemberInfo()
            {
            // TODO: Implement method test LCore.LUnit.TestExt.RunTest
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestExt) + "." + nameof(TestExt.GetTestData))]
        public void GetTestData()
            {
            // TODO: Implement method test LCore.LUnit.TestExt.GetTestData
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestExt) + "." + nameof(TestExt.GetTargetingName))]
        public void GetTargetingName()
            {
            // TODO: Implement method test LCore.LUnit.TestExt.GetTargetingName
            }
        }
    }