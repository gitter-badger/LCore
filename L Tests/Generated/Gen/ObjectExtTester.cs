using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.ObjectExt))]
    public partial class ObjectExtTester : XUnitOutputTester, IDisposable
        {
        public ObjectExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.ObjectExt) + "." + nameof(global::LCore.Extensions.ObjectExt.HasProperty) + "(Object, String) => Boolean")]
        public void HasProperty()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.ObjectExt) + "." + nameof(global::LCore.Extensions.ObjectExt.Objects_ToString) + "(IEnumerable`1<Object>) => String")]
        public void Objects_ToString()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.ObjectExt) + "." + nameof(global::LCore.Extensions.ObjectExt.GetProperty) + "(Object, String) => Object")]
        public void GetProperty()
            {
            // TODO: Implement method test LCore.Extensions.ObjectExt.GetProperty
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.ObjectExt) + "." + nameof(global::LCore.Extensions.ObjectExt.SetProperty) + "(Object, String, Object)")]
        public void SetProperty()
            {
            // TODO: Implement method test LCore.Extensions.ObjectExt.SetProperty
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.ObjectExt) + "." + nameof(global::LCore.Extensions.ObjectExt.Type) + "(T) => Type")]
        public void Type()
            {
            // Attribute Tests Implemented
            }

        }
    }