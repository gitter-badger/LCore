using System;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedParameter.Global

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt))]
    public partial class ComparableExtTester : XUnitOutputTester, IDisposable
        {
        public ComparableExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose()
            {
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." +
            nameof(ComparableExt.Max) + "(T, T[]) => T")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." +
            nameof(ComparableExt.Max) + "(IEnumerable`1<T>, Func`2<T, IComparable>) => T")]
        public void Max()
            {
            ((IComparable)null).Max().Should().Be(expected: null);
            ((IComparable)null).Max(1, 2, 3, 14, 5, 6, 7).Should().Be(expected: 14);

            50.Max(1, 2, 3, 14, 5, 6, 7).Should().Be(expected: 50);
            5.Max(1, 2, 3, 14, 5, 6, 7).Should().Be(expected: 14);

            50.55.Max(1, 2, 3, 14.55, 5, 6, 7).Should().Be(expected: 50.55);
            5.55.Max(1, 2, 3, 14.55, 5, 6, 7).Should().Be(expected: 14.55);

            "zzzbc".Max("baa", "caff", "acl", "aegeg", "grgg", "ttt").Should().Be("zzzbc");
            "aab".Max("baa", "caff", "acl", "aegeg", "grgg", "ttt").Should().Be("ttt");
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
            ((IComparable)null).Min().Should().Be(expected: null);
            ((IComparable)null).Min(1, 2, 3, 14, 5, 6, 7).Should().Be(expected: 1);

            50.Min(1, 2, 3, 14, 5, 6, 7).Should().Be(expected: 1);
            (-5).Min(1, 2, 3, 14, 5, 6, 7).Should().Be(-5);

            50.55.Min(1, 2, 3, 14.55, 5, 6, 7).Should().Be(expected: 1);
            (-5.55).Min(1, 2, 3, 14.55, 5, 6, 7).Should().Be(-5.55);

            "_aaa".Min("baa", "caff", "acl", "aegeg", "grgg", "ttt").Should().Be("_aaa");
            "ccc".Min("baa", "caff", "acl", "aegeg", "grgg", "ttt").Should().Be("acl");
            }
        }
    }