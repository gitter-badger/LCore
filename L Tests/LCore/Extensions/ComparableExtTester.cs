using System;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedParameter.Global

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt))]
    public partial class ComparableExtTester : XUnitOutputTester, IDisposable
        {
        public ComparableExtTester([NotNull] ITestOutputHelper Output) : base(Output) {}

        public void Dispose() {}

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." +
            nameof(ComparableExt.Max) + "(T, T[]) => T")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." +
            nameof(ComparableExt.Max) + "(IEnumerable`1<T>, Func`2<T, IComparable>) => T")]
        public void Max()
            {
            ((IComparable) null).Max().ShouldBe(Compare: null);
            ((IComparable) null).Max(1, 2, 3, 14, 5, 6, 7).ShouldBe(Compare: 14);

            50.Max(1, 2, 3, 14, 5, 6, 7).ShouldBe(Compare: 50);
            5.Max(1, 2, 3, 14, 5, 6, 7).ShouldBe(Compare: 14);

            50.55.Max(1, 2, 3, 14.55, 5, 6, 7).ShouldBe(Compare: 50.55);
            5.55.Max(1, 2, 3, 14.55, 5, 6, 7).ShouldBe(Compare: 14.55);

            "zzzbc".Max("baa", "caff", "acl", "aegeg", "grgg", "ttt").ShouldBe("zzzbc");
            "aab".Max("baa", "caff", "acl", "aegeg", "grgg", "ttt").ShouldBe("ttt");
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." +
            nameof(ComparableExt.Min) + "(T, T[]) => T")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." +
            nameof(ComparableExt.Min) + "(IEnumerable`1<T>, Func`2<T, IComparable>) => T")]
        public void Min()
            {
            ((IComparable) null).Min().ShouldBe(Compare: null);
            ((IComparable) null).Min(1, 2, 3, 14, 5, 6, 7).ShouldBe(Compare: 1);

            50.Min(1, 2, 3, 14, 5, 6, 7).ShouldBe(Compare: 1);
            (-5).Min(1, 2, 3, 14, 5, 6, 7).ShouldBe(-5);

            50.55.Min(1, 2, 3, 14.55, 5, 6, 7).ShouldBe(Compare: 1);
            (-5.55).Min(1, 2, 3, 14.55, 5, 6, 7).ShouldBe(-5.55);

            "_aaa".Min("baa", "caff", "acl", "aegeg", "grgg", "ttt").ShouldBe("_aaa");
            "ccc".Min("baa", "caff", "acl", "aegeg", "grgg", "ttt").ShouldBe("acl");
            }
        }
    }