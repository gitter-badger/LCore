using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Comment))]
    public partial class L_Comment_TestTester : XUnitOutputTester, IDisposable
        {
        public L_Comment_TestTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Comment) + "." + nameof(L.Comment.Test) + "." + nameof(L.Comment.Test.TestMethod))]
        public void TestMethod()
            {
            // TODO: Implement method test LCore.Extensions.L.Comment.Test.TestMethod
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Comment) + "." + nameof(L.Comment.Test) + "." + nameof(L.Comment.Test.TestMethod2))]
        public void TestMethod2()
            {
            // TODO: Implement method test LCore.Extensions.L.Comment.Test.TestMethod2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Comment) + "." + nameof(L.Comment.Test) + "." + nameof(L.Comment.Test.TestProperty))]
        public void TestProperty()
            {
            // TODO: Implement method test LCore.Extensions.L.Comment.Test.TestProperty
            }

        }
    }