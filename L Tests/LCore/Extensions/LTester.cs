using System;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L))]
    public partial class LTester : XUnitOutputTester, IDisposable
        {
        public LTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "() => Action")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "() => Action`1<T1>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "() => Action`2<T1, T2>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "() => Action`3<T1, T2, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "() => Action`4<T1, T2, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "() => Action`5<T1, T2, T3, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "() => Action`6<T1, T2, T3, T4, T5, T6>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "() => Action`7<T1, T2, T3, T4, T5, T6, T7>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "() => Action`8<T1, T2, T3, T4, T5, T6, T7, T8>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "() => Action`9<T1, T2, T3, T4, T5, T6, T7, T8, T9>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "() => Action`10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "() => Action`11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "() => Action`12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "() => Action`13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "() => Action`14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "() => Action`15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "() => Action`16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "(Action) => Action")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "(Action`1<T1>) => Action`1<T1>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "(Action`2<T1, T2>) => Action`2<T1, T2>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "(Action`3<T1, T2, T3>) => Action`3<T1, T2, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "(Action`4<T1, T2, T3, T4>) => Action`4<T1, T2, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "(Action`5<T1, T2, T3, T4, T5>) => Action`5<T1, T2, T3, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "(Action`6<T1, T2, T3, T4, T5, T6>) => Action`6<T1, T2, T3, T4, T5, T6>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "(Action`7<T1, T2, T3, T4, T5, T6, T7>) => Action`7<T1, T2, T3, T4, T5, T6, T7>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "(Action`8<T1, T2, T3, T4, T5, T6, T7, T8>) => Action`8<T1, T2, T3, T4, T5, T6, T7, T8>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "(Action`9<T1, T2, T3, T4, T5, T6, T7, T8, T9>) => Action`9<T1, T2, T3, T4, T5, T6, T7, T8, T9>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "(Action`10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>) => Action`10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>"
            )]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "(Action`11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>) => Action`11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>"
            )]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "(Action`12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>) => Action`12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>"
            )]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "(Action`13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>) => Action`13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>"
            )]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "(Action`14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>) => Action`14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>"
            )]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "(Action`15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>) => Action`15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>"
            )]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) +
            "(Action`16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>) => Action`16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>"
            )]
        public void Test_L_A()
            {
            L.A()();
            L.A<int>()(obj: 0);
            L.A<int, int>()(arg1: 0, arg2: 0);
            L.A<int, int, int>()(arg1: 0, arg2: 0, arg3: 0);
            L.A<int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0);
            L.A<int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0);
            L.A<int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0);
            L.A<int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0);
            L.A<int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0);
            L.A<int, int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0, arg9: 0);
            L.A<int, int, int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0, arg9: 0, arg10: 0);
            L.A<int, int, int, int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0, arg9: 0, arg10: 0, arg11: 0);
            L.A<int, int, int, int, int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0, arg9: 0, arg10: 0, arg11: 0, arg12: 0);
            L.A<int, int, int, int, int, int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0, arg9: 0, arg10: 0, arg11: 0, arg12: 0, arg13: 0);
            L.A<int, int, int, int, int, int, int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0, arg9: 0, arg10: 0, arg11: 0, arg12: 0, arg13: 0, arg14: 0);
            L.A<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0, arg9: 0, arg10: 0, arg11: 0, arg12: 0, arg13: 0, arg14: 0, arg15: 0);
            L.A<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0, arg9: 0, arg10: 0, arg11: 0, arg12: 0, arg13: 0, arg14: 0,
                arg15: 0, arg16: 0);

            int Rand = new Random().Next();
            L.A(() => { })();
            L.A<int>(o1 => { o1.Should().Be(Rand); })(Rand);
            L.A<int, int>((o1, o2) =>
                {
                o1.Should().Be(Rand);
                o2.Should().Be(Rand);
                })(Rand, Rand);
            L.A<int, int, int>((o1, o2, o3) =>
                {
                o1.Should().Be(Rand);
                o2.Should().Be(Rand);
                o3.Should().Be(Rand);
                })(Rand, Rand, Rand);
            L.A<int, int, int, int>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(Rand);
                o2.Should().Be(Rand);
                o3.Should().Be(Rand);
                o4.Should().Be(Rand);
                })(Rand, Rand, Rand, Rand);
            L.A<int, int, int, int, int>((o1, o2, o3, o4, o5) =>
                {
                o1.Should().Be(Rand);
                o2.Should().Be(Rand);
                o3.Should().Be(Rand);
                o4.Should().Be(Rand);
                o5.Should().Be(Rand);
                })(Rand, Rand, Rand, Rand, Rand);
            L.A<int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6) =>
                {
                o1.Should().Be(Rand);
                o2.Should().Be(Rand);
                o3.Should().Be(Rand);
                o4.Should().Be(Rand);
                o5.Should().Be(Rand);
                o6.Should().Be(Rand);
                })(Rand, Rand, Rand, Rand, Rand, Rand);
            L.A<int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7) =>
                {
                o1.Should().Be(Rand);
                o2.Should().Be(Rand);
                o3.Should().Be(Rand);
                o4.Should().Be(Rand);
                o5.Should().Be(Rand);
                o6.Should().Be(Rand);
                o7.Should().Be(Rand);
                })(Rand, Rand, Rand, Rand, Rand, Rand, Rand);
            L.A<int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8) =>
                {
                o1.Should().Be(Rand);
                o2.Should().Be(Rand);
                o3.Should().Be(Rand);
                o4.Should().Be(Rand);
                o5.Should().Be(Rand);
                o6.Should().Be(Rand);
                o7.Should().Be(Rand);
                o8.Should().Be(Rand);
                })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand);
            L.A<int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8, o9) =>
                {
                o1.Should().Be(Rand);
                o2.Should().Be(Rand);
                o3.Should().Be(Rand);
                o4.Should().Be(Rand);
                o5.Should().Be(Rand);
                o6.Should().Be(Rand);
                o7.Should().Be(Rand);
                o8.Should().Be(Rand);
                o9.Should().Be(Rand);
                })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand);
            L.A<int, int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) =>
                {
                o1.Should().Be(Rand);
                o2.Should().Be(Rand);
                o3.Should().Be(Rand);
                o4.Should().Be(Rand);
                o5.Should().Be(Rand);
                o6.Should().Be(Rand);
                o7.Should().Be(Rand);
                o8.Should().Be(Rand);
                o9.Should().Be(Rand);
                o10.Should().Be(Rand);
                })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand);
            L.A<int, int, int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) =>
                {
                o1.Should().Be(Rand);
                o2.Should().Be(Rand);
                o3.Should().Be(Rand);
                o4.Should().Be(Rand);
                o5.Should().Be(Rand);
                o6.Should().Be(Rand);
                o7.Should().Be(Rand);
                o8.Should().Be(Rand);
                o9.Should().Be(Rand);
                o10.Should().Be(Rand);
                o11.Should().Be(Rand);
                })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand);
            L.A<int, int, int, int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) =>
                {
                o1.Should().Be(Rand);
                o2.Should().Be(Rand);
                o3.Should().Be(Rand);
                o4.Should().Be(Rand);
                o5.Should().Be(Rand);
                o6.Should().Be(Rand);
                o7.Should().Be(Rand);
                o8.Should().Be(Rand);
                o9.Should().Be(Rand);
                o10.Should().Be(Rand);
                o11.Should().Be(Rand);
                o12.Should().Be(Rand);
                })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand);
            L.A<int, int, int, int, int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) =>
                {
                o1.Should().Be(Rand);
                o2.Should().Be(Rand);
                o3.Should().Be(Rand);
                o4.Should().Be(Rand);
                o5.Should().Be(Rand);
                o6.Should().Be(Rand);
                o7.Should().Be(Rand);
                o8.Should().Be(Rand);
                o9.Should().Be(Rand);
                o10.Should().Be(Rand);
                o11.Should().Be(Rand);
                o12.Should().Be(Rand);
                o13.Should().Be(Rand);
                })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand);
            L.A<int, int, int, int, int, int, int, int, int, int, int, int, int, int>(
                (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) =>
                    {
                    o1.Should().Be(Rand);
                    o2.Should().Be(Rand);
                    o3.Should().Be(Rand);
                    o4.Should().Be(Rand);
                    o5.Should().Be(Rand);
                    o6.Should().Be(Rand);
                    o7.Should().Be(Rand);
                    o8.Should().Be(Rand);
                    o9.Should().Be(Rand);
                    o10.Should().Be(Rand);
                    o11.Should().Be(Rand);
                    o12.Should().Be(Rand);
                    o13.Should().Be(Rand);
                    o14.Should().Be(Rand);
                    })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand);
            L.A<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>(
                (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) =>
                    {
                    o1.Should().Be(Rand);
                    o2.Should().Be(Rand);
                    o3.Should().Be(Rand);
                    o4.Should().Be(Rand);
                    o5.Should().Be(Rand);
                    o6.Should().Be(Rand);
                    o7.Should().Be(Rand);
                    o8.Should().Be(Rand);
                    o9.Should().Be(Rand);
                    o10.Should().Be(Rand);
                    o11.Should().Be(Rand);
                    o12.Should().Be(Rand);
                    o13.Should().Be(Rand);
                    o14.Should().Be(Rand);
                    o15.Should().Be(Rand);
                    })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand);
            L.A<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>(
                (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) =>
                    {
                    o1.Should().Be(Rand);
                    o2.Should().Be(Rand);
                    o3.Should().Be(Rand);
                    o4.Should().Be(Rand);
                    o5.Should().Be(Rand);
                    o6.Should().Be(Rand);
                    o7.Should().Be(Rand);
                    o8.Should().Be(Rand);
                    o9.Should().Be(Rand);
                    o10.Should().Be(Rand);
                    o11.Should().Be(Rand);
                    o12.Should().Be(Rand);
                    o13.Should().Be(Rand);
                    o14.Should().Be(Rand);
                    o15.Should().Be(Rand);
                    o16.Should().Be(Rand);
                    })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand);
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "(Func`1<U>) => Func`1<U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "(Func`2<T1, U>) => Func`2<T1, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "(Func`3<T1, T2, U>) => Func`3<T1, T2, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "(Func`4<T1, T2, T3, U>) => Func`4<T1, T2, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "(Func`5<T1, T2, T3, T4, U>) => Func`5<T1, T2, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "(Func`6<T1, T2, T3, T4, T5, U>) => Func`6<T1, T2, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "(Func`7<T1, T2, T3, T4, T5, T6, U>) => Func`7<T1, T2, T3, T4, T5, T6, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "(Func`8<T1, T2, T3, T4, T5, T6, T7, U>) => Func`8<T1, T2, T3, T4, T5, T6, T7, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "(Func`9<T1, T2, T3, T4, T5, T6, T7, T8, U>) => Func`9<T1, T2, T3, T4, T5, T6, T7, T8, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "(Func`10<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>) => Func`10<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "(Func`11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>) => Func`11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>"
            )]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "(Func`12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>) => Func`12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>"
            )]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "(Func`13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>) => Func`13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>"
            )]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "(Func`14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>) => Func`14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>"
            )]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "(Func`15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>) => Func`15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>"
            )]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "(Func`16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>) => Func`16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>"
            )]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "(Func`17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>) => Func`17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>"
            )]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "() => Func`1<U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "() => Func`2<T1, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "() => Func`3<T1, T2, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "() => Func`4<T1, T2, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "() => Func`5<T1, T2, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "() => Func`6<T1, T2, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "() => Func`7<T1, T2, T3, T4, T5, T6, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "() => Func`8<T1, T2, T3, T4, T5, T6, T7, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "() => Func`9<T1, T2, T3, T4, T5, T6, T7, T8, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "() => Func`10<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "() => Func`11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "() => Func`12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "() => Func`13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "() => Func`14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "() => Func`15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "() => Func`16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) +
            "() => Func`17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>")]
        public void Test_L_F()
            {
            L.F<int>()()
                .Should().Be(default(int));
            L.F<int, int>()(arg: 0)
                .Should().Be(default(int));
            L.F<int, int, int>()(arg1: 0, arg2: 0)
                .Should().Be(default(int));
            L.F<int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0)
                .Should().Be(default(int));
            L.F<int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0)
                .Should().Be(default(int));
            L.F<int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0)
                .Should().Be(default(int));
            L.F<int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0)
                .Should().Be(default(int));
            L.F<int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0)
                .Should().Be(default(int));
            L.F<int, int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0)
                .Should().Be(default(int));
            L.F<int, int, int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0, arg9: 0)
                .Should().Be(default(int));
            L.F<int, int, int, int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0, arg9: 0, arg10: 0)
                .Should().Be(default(int));
            L.F<int, int, int, int, int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0, arg9: 0, arg10: 0, arg11: 0)
                .Should().Be(default(int));
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0, arg9: 0, arg10: 0, arg11: 0, arg12: 0)
                .Should().Be(default(int));
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0, arg9: 0, arg10: 0, arg11: 0, arg12: 0, arg13: 0)
                .Should().Be(default(int));
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0, arg9: 0, arg10: 0, arg11: 0, arg12: 0, arg13: 0, arg14: 0)
                .Should().Be(default(int));
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0, arg9: 0, arg10: 0, arg11: 0, arg12: 0, arg13: 0, arg14: 0,
                arg15: 0)
                .Should().Be(default(int));
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0, arg9: 0, arg10: 0, arg11: 0, arg12: 0, arg13: 0,
                arg14: 0, arg15: 0, arg16: 0)
                .Should().Be(default(int));

            int Rand = new Random().Next();

            L.F(() => Rand)().Should().Be(Rand);
            L.F<int, int>(o1 =>
                {
                o1.Should().Be(Rand);
                return Rand;
                })(Rand).Should().Be(Rand);
            L.F<int, int, int>((o1, o2) =>
                {
                o1.Should().Be(Rand);
                o2.Should().Be(Rand);
                return Rand;
                })(Rand, Rand).Should().Be(Rand);
            L.F<int, int, int, int>((o1, o2, o3) =>
                {
                o1.Should().Be(Rand);
                o2.Should().Be(Rand);
                o3.Should().Be(Rand);
                return Rand;
                })(Rand, Rand, Rand).Should().Be(Rand);
            L.F<int, int, int, int, int>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(Rand);
                o2.Should().Be(Rand);
                o3.Should().Be(Rand);
                o4.Should().Be(Rand);
                return Rand;
                })(Rand, Rand, Rand, Rand).Should().Be(Rand);
            L.F<int, int, int, int, int, int>((o1, o2, o3, o4, o5) =>
                {
                o1.Should().Be(Rand);
                o2.Should().Be(Rand);
                o3.Should().Be(Rand);
                o4.Should().Be(Rand);
                o5.Should().Be(Rand);
                return Rand;
                })(Rand, Rand, Rand, Rand, Rand).Should().Be(Rand);
            L.F<int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6) =>
                {
                o1.Should().Be(Rand);
                o2.Should().Be(Rand);
                o3.Should().Be(Rand);
                o4.Should().Be(Rand);
                o5.Should().Be(Rand);
                o6.Should().Be(Rand);
                return Rand;
                })(Rand, Rand, Rand, Rand, Rand, Rand).Should().Be(Rand);
            L.F<int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7) =>
                {
                o1.Should().Be(Rand);
                o2.Should().Be(Rand);
                o3.Should().Be(Rand);
                o4.Should().Be(Rand);
                o5.Should().Be(Rand);
                o6.Should().Be(Rand);
                o7.Should().Be(Rand);
                return Rand;
                })(Rand, Rand, Rand, Rand, Rand, Rand, Rand).Should().Be(Rand);
            L.F<int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8) =>
                {
                o1.Should().Be(Rand);
                o2.Should().Be(Rand);
                o3.Should().Be(Rand);
                o4.Should().Be(Rand);
                o5.Should().Be(Rand);
                o6.Should().Be(Rand);
                o7.Should().Be(Rand);
                o8.Should().Be(Rand);
                return Rand;
                })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand).Should().Be(Rand);
            L.F<int, int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8, o9) =>
                {
                o1.Should().Be(Rand);
                o2.Should().Be(Rand);
                o3.Should().Be(Rand);
                o4.Should().Be(Rand);
                o5.Should().Be(Rand);
                o6.Should().Be(Rand);
                o7.Should().Be(Rand);
                o8.Should().Be(Rand);
                o9.Should().Be(Rand);
                return Rand;
                })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand).Should().Be(Rand);
            L.F<int, int, int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) =>
                {
                o1.Should().Be(Rand);
                o2.Should().Be(Rand);
                o3.Should().Be(Rand);
                o4.Should().Be(Rand);
                o5.Should().Be(Rand);
                o6.Should().Be(Rand);
                o7.Should().Be(Rand);
                o8.Should().Be(Rand);
                o9.Should().Be(Rand);
                o10.Should().Be(Rand);
                return Rand;
                })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand).Should().Be(Rand);
            L.F<int, int, int, int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) =>
                {
                o1.Should().Be(Rand);
                o2.Should().Be(Rand);
                o3.Should().Be(Rand);
                o4.Should().Be(Rand);
                o5.Should().Be(Rand);
                o6.Should().Be(Rand);
                o7.Should().Be(Rand);
                o8.Should().Be(Rand);
                o9.Should().Be(Rand);
                o10.Should().Be(Rand);
                o11.Should().Be(Rand);
                return Rand;
                })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand).Should().Be(Rand);
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) =>
                {
                o1.Should().Be(Rand);
                o2.Should().Be(Rand);
                o3.Should().Be(Rand);
                o4.Should().Be(Rand);
                o5.Should().Be(Rand);
                o6.Should().Be(Rand);
                o7.Should().Be(Rand);
                o8.Should().Be(Rand);
                o9.Should().Be(Rand);
                o10.Should().Be(Rand);
                o11.Should().Be(Rand);
                o12.Should().Be(Rand);
                return Rand;
                })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand).Should().Be(Rand);
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int, int>(
                (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) =>
                    {
                    o1.Should().Be(Rand);
                    o2.Should().Be(Rand);
                    o3.Should().Be(Rand);
                    o4.Should().Be(Rand);
                    o5.Should().Be(Rand);
                    o6.Should().Be(Rand);
                    o7.Should().Be(Rand);
                    o8.Should().Be(Rand);
                    o9.Should().Be(Rand);
                    o10.Should().Be(Rand);
                    o11.Should().Be(Rand);
                    o12.Should().Be(Rand);
                    o13.Should().Be(Rand);
                    return Rand;
                    })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand).Should().Be(Rand);
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>(
                (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) =>
                    {
                    o1.Should().Be(Rand);
                    o2.Should().Be(Rand);
                    o3.Should().Be(Rand);
                    o4.Should().Be(Rand);
                    o5.Should().Be(Rand);
                    o6.Should().Be(Rand);
                    o7.Should().Be(Rand);
                    o8.Should().Be(Rand);
                    o9.Should().Be(Rand);
                    o10.Should().Be(Rand);
                    o11.Should().Be(Rand);
                    o12.Should().Be(Rand);
                    o13.Should().Be(Rand);
                    o14.Should().Be(Rand);
                    return Rand;
                    })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand).Should().Be(Rand);
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>(
                (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) =>
                    {
                    o1.Should().Be(Rand);
                    o2.Should().Be(Rand);
                    o3.Should().Be(Rand);
                    o4.Should().Be(Rand);
                    o5.Should().Be(Rand);
                    o6.Should().Be(Rand);
                    o7.Should().Be(Rand);
                    o8.Should().Be(Rand);
                    o9.Should().Be(Rand);
                    o10.Should().Be(Rand);
                    o11.Should().Be(Rand);
                    o12.Should().Be(Rand);
                    o13.Should().Be(Rand);
                    o14.Should().Be(Rand);
                    o15.Should().Be(Rand);
                    return Rand;
                    })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand).Should().Be(Rand);
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>(
                (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) =>
                    {
                    o1.Should().Be(Rand);
                    o2.Should().Be(Rand);
                    o3.Should().Be(Rand);
                    o4.Should().Be(Rand);
                    o5.Should().Be(Rand);
                    o6.Should().Be(Rand);
                    o7.Should().Be(Rand);
                    o8.Should().Be(Rand);
                    o9.Should().Be(Rand);
                    o10.Should().Be(Rand);
                    o11.Should().Be(Rand);
                    o12.Should().Be(Rand);
                    o13.Should().Be(Rand);
                    o14.Should().Be(Rand);
                    o15.Should().Be(Rand);
                    o16.Should().Be(Rand);
                    return Rand;
                    })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand).Should().Be(Rand);
            }
        }
    }