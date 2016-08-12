using System;
using System.Collections;
using System.Collections.Generic;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace LUnit_Tests.LCore.LUnit
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestAttribute))]
    public partial class TestAttributeTester : XUnitOutputTester, IDisposable
        {
        public TestAttributeTester(ITestOutputHelper Output) : base(Output) {}

        public void Dispose() {}

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TestAttribute) + "." + nameof(TestAttribute.RunTest) + "(MethodInfo)")]
        public void RunTest()
            {
            // TODO: Implement method test LCore.LUnit.TestAttribute.RunTest
            }
        }
    }