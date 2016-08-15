using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using LCore.Tools;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantCast
// ReSharper disable RedundantNameQualifier

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L))]
    public partial class L_ObjTester : XUnitOutputTester, IDisposable
        {
        public L_ObjTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.As) + "() => Func`2<Object, T>")]
        public void As()
            {
            const string Test = "a";

            var Test2 = L.Obj.As<object>()(Test);

            Test2.Should().Be("a");
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.Swap) + "(T&, T&)")]
        public void Swap()
            {
            string Test1 = "a";
            string Test2 = "b";

            L.Obj.Swap(ref Test1, ref Test2);

            Test1.Should().Be("b");
            Test2.Should().Be("a");
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.SafeEquals) + "(Object, Object) => Boolean")]
        public void SafeEquals()
            {
            const string Test1 = "a";
            const string Test2 = "b";

            L.Obj.SafeEquals(Test1, Test1).ShouldBeTrue();
            L.Obj.SafeEquals(Test1, "a").ShouldBeTrue();
            L.Obj.SafeEquals(Test1, Test2).ShouldBeFalse();
            L.Obj.SafeEquals(o1: null, o2: Test2).ShouldBeFalse();
            L.Obj.SafeEquals(o1: null, o2: null).ShouldBeTrue();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.New) + "(Object[]) => T")]
        public void New()
            {
            L.Obj.New<string>().Should().Be("");
            L.Obj.New<int>().Should().Be(expected: 0);
            L.Obj.New<int?>().Should().Be(expected: null);
            L.Obj.New<List<int>>().ShouldBeEquivalentTo(new List<int>());
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.IsNull) + "() => Func`2<T, Boolean>")]
        public void IsNull()
            {
            L.Obj.IsNull<object>()(arg: null).ShouldBeTrue();
            L.Obj.IsNull<object>()("").ShouldBeFalse();
            L.Obj.IsNull<object>()(arg: 1).ShouldBeFalse();
            L.Obj.IsNull<int?>()(arg: 1).ShouldBeFalse();
            L.Obj.IsNull<int?>()((int?)null).ShouldBeTrue();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.IsA) + "() => Func`2<Object, Boolean>")]
        public void IsA()
            {
            L.Obj.IsA<string>()("").ShouldBeTrue();
            L.Obj.IsA<string>()(arg: null).ShouldBeFalse();
            L.Obj.IsA<string>()((string)null).ShouldBeFalse();
            L.Obj.IsA<int>()((string)null).ShouldBeFalse();
            L.Obj.IsA<object>()(arg: "").ShouldBeTrue();
            L.Obj.IsA<object>()(arg: null).ShouldBeFalse();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.HasProperty) + "() => Func`3<Object, String, Boolean>")]
        public void HasProperty()
            {
            const string Test = "a";

            L.Obj.HasProperty()(Test, nameof(string.Length)).ShouldBeTrue();
            L.Obj.HasProperty()(Test, "derp").ShouldBeFalse();

            L.Obj.HasProperty()(Test, arg2: null).ShouldBeFalse();
            L.Obj.HasProperty()(arg1: null, arg2: nameof(object.ToString)).ShouldBeFalse();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.GetProperty) + "() => Func`3<Object, String, Object>")]
        public void GetProperty()
            {
            const string Test = "a";

            L.Obj.GetProperty()(Test, nameof(string.Length)).Should().Be(expected: 1);
            L.Obj.GetProperty()(Test, "derp").ShouldBeNull();

            L.Obj.GetProperty()(Test, arg2: null).ShouldBeNull();
            L.Obj.GetProperty()(arg1: null, arg2: nameof(object.ToString)).ShouldBeNull();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.SetProperty) + "() => Action`3<Object, String, Object>")]
        public void SetProperty()
            {
            var Test = new Set<string, string>("a", "b");

            L.Obj.SetProperty()(Test, nameof(Set<string, string>.Obj1), "c");

            L.A(() => L.Obj.SetProperty()(Test, "derp", "d")).ShouldFail();

            Test.Obj1.Should().Be("c");
            }
        }
    }