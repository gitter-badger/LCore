using System;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.Extensions.Optional;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedParameter.Global

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L))]
    public partial class L_AryTester : XUnitOutputTester, IDisposable
        {
        public L_AryTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ary) + "." +
            nameof(L.Ary.Array) + "() => Func<T[]>")]
        public void Array_Func_1_T()
            {
            L.Ary.Array<int>()().Should().BeOfType<int[]>().And.Subject.ToS().ShouldBe("Int32[] {  }");
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ary) + "." +
            nameof(L.Ary.Array) + "(T[]) => Func<T[]>")]
        public void Array_T_Func_1_T()
            {
            L.Ary.Array<string>()().Should().BeOfType<string[]>().And.Subject.ToS().ShouldBe("String[] {  }");
            }

        }
    }