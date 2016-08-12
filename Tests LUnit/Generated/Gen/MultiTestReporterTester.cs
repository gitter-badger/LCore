using System;
using System.Collections;
using System.Collections.Generic;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace LUnit_Tests.LCore.LUnit
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(MultiTestReporter))]
    public partial class MultiTestReporterTester : XUnitOutputTester, IDisposable
        {
        public MultiTestReporterTester(ITestOutputHelper Output) : base(Output) {}

        public void Dispose() {}

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(MultiTestReporter) + "." + nameof(MultiTestReporter.TestFailure01) + "()")]
        public void TestFailure01()
            {
            // TODO: Implement method test LCore.LUnit.MultiTestReporter.TestFailure01
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(MultiTestReporter) + "." + nameof(MultiTestReporter.TestFailure02) + "()")]
        public void TestFailure02()
            {
            // TODO: Implement method test LCore.LUnit.MultiTestReporter.TestFailure02
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(MultiTestReporter) + "." + nameof(MultiTestReporter.TestFailure03) + "()")]
        public void TestFailure03()
            {
            // TODO: Implement method test LCore.LUnit.MultiTestReporter.TestFailure03
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(MultiTestReporter) + "." + nameof(MultiTestReporter.TestFailure04) + "()")]
        public void TestFailure04()
            {
            // TODO: Implement method test LCore.LUnit.MultiTestReporter.TestFailure04
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(MultiTestReporter) + "." + nameof(MultiTestReporter.TestFailure05) + "()")]
        public void TestFailure05()
            {
            // TODO: Implement method test LCore.LUnit.MultiTestReporter.TestFailure05
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(MultiTestReporter) + "." + nameof(MultiTestReporter.TestFailure06) + "()")]
        public void TestFailure06()
            {
            // TODO: Implement method test LCore.LUnit.MultiTestReporter.TestFailure06
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(MultiTestReporter) + "." + nameof(MultiTestReporter.TestFailure07) + "()")]
        public void TestFailure07()
            {
            // TODO: Implement method test LCore.LUnit.MultiTestReporter.TestFailure07
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(MultiTestReporter) + "." + nameof(MultiTestReporter.TestFailure08) + "()")]
        public void TestFailure08()
            {
            // TODO: Implement method test LCore.LUnit.MultiTestReporter.TestFailure08
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(MultiTestReporter) + "." + nameof(MultiTestReporter.TestFailure09) + "()")]
        public void TestFailure09()
            {
            // TODO: Implement method test LCore.LUnit.MultiTestReporter.TestFailure09
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(MultiTestReporter) + "." + nameof(MultiTestReporter.TestFailure10) + "()")]
        public void TestFailure10()
            {
            // TODO: Implement method test LCore.LUnit.MultiTestReporter.TestFailure10
            }
        }
    }