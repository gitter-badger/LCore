using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Tools
    {
    [Trait(Traits.TargetClass, "LCore.Tools.Set`2")]
    public partial class Set_2Tester : XUnitOutputTester, IDisposable
        {
        public Set_2Tester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.Set`2.Equals(Object) => Boolean")]
        public void Equals_Object_Boolean()
            {
            // TODO: Implement method test LCore.Tools.Set`2.Equals
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.Set`2.GetHashCode() => Int32")]
        public new void GetHashCode()
            {
            // TODO: Implement method test LCore.Tools.Set`2.GetHashCode
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.Set`2.Equals(Set`2) => Boolean")]
        public void Equals_Set_2_Boolean()
            {
            // TODO: Implement method test LCore.Tools.Set`2.Equals
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.Set`2.ToString() => String")]
        public new void ToString()
            {
            // TODO: Implement method test LCore.Tools.Set`2.ToString
            }

        }
    }