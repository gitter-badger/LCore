using System;
using System.Collections;
using System.Collections.Generic;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace LUnit_Tests.LCore.LUnit
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestExt))]
    public partial class TestExtTester : XUnitOutputTester, IDisposable
        {
        public TestExtTester(ITestOutputHelper Output) : base(Output) {}

        public void Dispose() {}

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestExt) + "." + nameof(TestExt.GetTestMembers) + "(Type) => Dictionary`2<MemberInfo, List`1<ILUnitAttribute>>")]
        public void GetTestMembers()
            {
            // TODO: Implement method test LCore.LUnit.TestExt.GetTestMembers
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestExt) + "." + nameof(TestExt.RunTest) + "(ITestResultAttribute, MethodInfo)")]
        public void RunTest_ITestResultAttribute_MethodInfo()
            {
            // TODO: Implement method test LCore.LUnit.TestExt.RunTest
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestExt) + "." + nameof(TestExt.RunTest) + "(ITestFailsAttribute, MethodInfo)")]
        public void RunTest_ITestFailsAttribute_MethodInfo()
            {
            // TODO: Implement method test LCore.LUnit.TestExt.RunTest
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestExt) + "." + nameof(TestExt.RunTest) + "(ITestSucceedsAttribute, MethodInfo)")]
        public void RunTest_ITestSucceedsAttribute_MethodInfo()
            {
            // TODO: Implement method test LCore.LUnit.TestExt.RunTest
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestExt) + "." + nameof(TestExt.RunTest) + "(ITestSourceAttribute, MethodInfo)")]
        public void RunTest_ITestSourceAttribute_MethodInfo()
            {
            // TODO: Implement method test LCore.LUnit.TestExt.RunTest
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestExt) + "." + nameof(TestExt.RunTest) + "(IValidateAttribute, MemberInfo)")]
        public void RunTest_IValidateAttribute_MemberInfo()
            {
            // TODO: Implement method test LCore.LUnit.TestExt.RunTest
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestExt) + "." + nameof(TestExt.GetTestData) + "(Type) => TypeTests")]
        public void GetTestData()
            {
            // TODO: Implement method test LCore.LUnit.TestExt.GetTestData
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestExt) + "." + nameof(TestExt.GetTargetingName) + "(MemberInfo, String, String, String) => Tuple`3<String, String, String>")]
        public void GetTargetingName()
            {
            // TODO: Implement method test LCore.LUnit.TestExt.GetTargetingName
            }
        }
    }