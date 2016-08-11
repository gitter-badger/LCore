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
    [Trait(Traits.TargetMember, "LCore.Tools.Lists`2")]
    public partial class Lists_2Tester : XUnitOutputTester, IDisposable
        {
        public Lists_2Tester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.Lists`2.Add")]
        public void Add()
            {
            // TODO: Implement method test LCore.Tools.Lists`2.Add
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.Lists`2.Set")]
        public void Set()
            {
            // TODO: Implement method test LCore.Tools.Lists`2.Set
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.Lists`2.Set1")]
        public void Set1()
            {
            // TODO: Implement method test LCore.Tools.Lists`2.Set1
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.Lists`2.Set2")]
        public void Set2()
            {
            // TODO: Implement method test LCore.Tools.Lists`2.Set2
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.Lists`2.GetAt")]
        public void GetAt()
            {
            // TODO: Implement method test LCore.Tools.Lists`2.GetAt
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.Lists`2.RemoveAt")]
        public void RemoveAt()
            {
            // TODO: Implement method test LCore.Tools.Lists`2.RemoveAt
            }

        }
    }