using System;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    public partial class LTester : XUnitOutputTester, IDisposable
        {
        public LTester([NotNull] ITestOutputHelper Output) : base(Output) {}

        public void Dispose() {}

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "() => Action")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "() => Action<T1>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "() => Action<T1, T2>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "() => Action<T1, T2, T3>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "() => Action<T1, T2, T3, T4>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "() => Action<T1, T2, T3, T4, T5>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "() => Action<T1, T2, T3, T4, T5, T6>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "() => Action<T1, T2, T3, T4, T5, T6, T7>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "() => Action<T1, T2, T3, T4, T5, T6, T7, T8>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "() => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "() => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "() => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "() => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "() => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "() => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "() => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "() => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "(Action) => Action")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "(Action<T1>) => Action<T1>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "(Action<T1, T2>) => Action<T1, T2>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "(Action<T1, T2, T3>) => Action<T1, T2, T3>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "(Action<T1, T2, T3, T4>) => Action<T1, T2, T3, T4>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "(Action<T1, T2, T3, T4, T5>) => Action<T1, T2, T3, T4, T5>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "(Action<T1, T2, T3, T4, T5, T6>) => Action<T1, T2, T3, T4, T5, T6>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "(Action<T1, T2, T3, T4, T5, T6, T7>) => Action<T1, T2, T3, T4, T5, T6, T7>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "(Action<T1, T2, T3, T4, T5, T6, T7, T8>) => Action<T1, T2, T3, T4, T5, T6, T7, T8>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>) => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>) => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>) => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>) => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>) => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>) => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>) => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.A) + "(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>) => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "(Action) => Action")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "(Action<T1>) => Action<T1>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "(Action<T1, T2>) => Action<T1, T2>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "(Action<T1, T2, T3>) => Action<T1, T2, T3>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "(Action<T1, T2, T3, T4>) => Action<T1, T2, T3, T4>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "(Action<T1, T2, T3, T4, T5>) => Action<T1, T2, T3, T4, T5>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "(Action<T1, T2, T3, T4, T5, T6>) => Action<T1, T2, T3, T4, T5, T6>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "(Action<T1, T2, T3, T4, T5, T6, T7>) => Action<T1, T2, T3, T4, T5, T6, T7>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "(Action<T1, T2, T3, T4, T5, T6, T7, T8>) => Action<T1, T2, T3, T4, T5, T6, T7, T8>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>) => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>) => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>) => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>) => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>) => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>) => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>) => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>) => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "() => Action<T1>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "() => Action<T1, T2>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "() => Action<T1, T2, T3>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "() => Action<T1, T2, T3, T4>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "() => Action<T1, T2, T3, T4, T5>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "() => Action<T1, T2, T3, T4, T5, T6>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "() => Action<T1, T2, T3, T4, T5, T6, T7>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "() => Action<T1, T2, T3, T4, T5, T6, T7, T8>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "() => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "() => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "() => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "() => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "() => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "() => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "() => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Action) + "() => Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>")]
        public void L_A()
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
            L.A<int>(o1 => { o1.ShouldBe(Rand); })(Rand);
            L.A<int, int>((o1, o2) =>
                {
                o1.ShouldBe(Rand);
                o2.ShouldBe(Rand);
                })(Rand, Rand);
            L.A<int, int, int>((o1, o2, o3) =>
                {
                o1.ShouldBe(Rand);
                o2.ShouldBe(Rand);
                o3.ShouldBe(Rand);
                })(Rand, Rand, Rand);
            L.A<int, int, int, int>((o1, o2, o3, o4) =>
                {
                o1.ShouldBe(Rand);
                o2.ShouldBe(Rand);
                o3.ShouldBe(Rand);
                o4.ShouldBe(Rand);
                })(Rand, Rand, Rand, Rand);
            L.A<int, int, int, int, int>((o1, o2, o3, o4, o5) =>
                {
                o1.ShouldBe(Rand);
                o2.ShouldBe(Rand);
                o3.ShouldBe(Rand);
                o4.ShouldBe(Rand);
                o5.ShouldBe(Rand);
                })(Rand, Rand, Rand, Rand, Rand);
            L.A<int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6) =>
                {
                o1.ShouldBe(Rand);
                o2.ShouldBe(Rand);
                o3.ShouldBe(Rand);
                o4.ShouldBe(Rand);
                o5.ShouldBe(Rand);
                o6.ShouldBe(Rand);
                })(Rand, Rand, Rand, Rand, Rand, Rand);
            L.A<int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7) =>
                {
                o1.ShouldBe(Rand);
                o2.ShouldBe(Rand);
                o3.ShouldBe(Rand);
                o4.ShouldBe(Rand);
                o5.ShouldBe(Rand);
                o6.ShouldBe(Rand);
                o7.ShouldBe(Rand);
                })(Rand, Rand, Rand, Rand, Rand, Rand, Rand);
            L.A<int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8) =>
                {
                o1.ShouldBe(Rand);
                o2.ShouldBe(Rand);
                o3.ShouldBe(Rand);
                o4.ShouldBe(Rand);
                o5.ShouldBe(Rand);
                o6.ShouldBe(Rand);
                o7.ShouldBe(Rand);
                o8.ShouldBe(Rand);
                })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand);
            L.A<int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8, o9) =>
                {
                o1.ShouldBe(Rand);
                o2.ShouldBe(Rand);
                o3.ShouldBe(Rand);
                o4.ShouldBe(Rand);
                o5.ShouldBe(Rand);
                o6.ShouldBe(Rand);
                o7.ShouldBe(Rand);
                o8.ShouldBe(Rand);
                o9.ShouldBe(Rand);
                })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand);
            L.A<int, int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) =>
                {
                o1.ShouldBe(Rand);
                o2.ShouldBe(Rand);
                o3.ShouldBe(Rand);
                o4.ShouldBe(Rand);
                o5.ShouldBe(Rand);
                o6.ShouldBe(Rand);
                o7.ShouldBe(Rand);
                o8.ShouldBe(Rand);
                o9.ShouldBe(Rand);
                o10.ShouldBe(Rand);
                })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand);
            L.A<int, int, int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) =>
                {
                o1.ShouldBe(Rand);
                o2.ShouldBe(Rand);
                o3.ShouldBe(Rand);
                o4.ShouldBe(Rand);
                o5.ShouldBe(Rand);
                o6.ShouldBe(Rand);
                o7.ShouldBe(Rand);
                o8.ShouldBe(Rand);
                o9.ShouldBe(Rand);
                o10.ShouldBe(Rand);
                o11.ShouldBe(Rand);
                })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand);
            L.A<int, int, int, int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) =>
                {
                o1.ShouldBe(Rand);
                o2.ShouldBe(Rand);
                o3.ShouldBe(Rand);
                o4.ShouldBe(Rand);
                o5.ShouldBe(Rand);
                o6.ShouldBe(Rand);
                o7.ShouldBe(Rand);
                o8.ShouldBe(Rand);
                o9.ShouldBe(Rand);
                o10.ShouldBe(Rand);
                o11.ShouldBe(Rand);
                o12.ShouldBe(Rand);
                })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand);
            L.A<int, int, int, int, int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) =>
                {
                o1.ShouldBe(Rand);
                o2.ShouldBe(Rand);
                o3.ShouldBe(Rand);
                o4.ShouldBe(Rand);
                o5.ShouldBe(Rand);
                o6.ShouldBe(Rand);
                o7.ShouldBe(Rand);
                o8.ShouldBe(Rand);
                o9.ShouldBe(Rand);
                o10.ShouldBe(Rand);
                o11.ShouldBe(Rand);
                o12.ShouldBe(Rand);
                o13.ShouldBe(Rand);
                })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand);
            L.A<int, int, int, int, int, int, int, int, int, int, int, int, int, int>(
                (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) =>
                    {
                    o1.ShouldBe(Rand);
                    o2.ShouldBe(Rand);
                    o3.ShouldBe(Rand);
                    o4.ShouldBe(Rand);
                    o5.ShouldBe(Rand);
                    o6.ShouldBe(Rand);
                    o7.ShouldBe(Rand);
                    o8.ShouldBe(Rand);
                    o9.ShouldBe(Rand);
                    o10.ShouldBe(Rand);
                    o11.ShouldBe(Rand);
                    o12.ShouldBe(Rand);
                    o13.ShouldBe(Rand);
                    o14.ShouldBe(Rand);
                    })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand);
            L.A<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>(
                (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) =>
                    {
                    o1.ShouldBe(Rand);
                    o2.ShouldBe(Rand);
                    o3.ShouldBe(Rand);
                    o4.ShouldBe(Rand);
                    o5.ShouldBe(Rand);
                    o6.ShouldBe(Rand);
                    o7.ShouldBe(Rand);
                    o8.ShouldBe(Rand);
                    o9.ShouldBe(Rand);
                    o10.ShouldBe(Rand);
                    o11.ShouldBe(Rand);
                    o12.ShouldBe(Rand);
                    o13.ShouldBe(Rand);
                    o14.ShouldBe(Rand);
                    o15.ShouldBe(Rand);
                    })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand);
            L.A<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>(
                (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) =>
                    {
                    o1.ShouldBe(Rand);
                    o2.ShouldBe(Rand);
                    o3.ShouldBe(Rand);
                    o4.ShouldBe(Rand);
                    o5.ShouldBe(Rand);
                    o6.ShouldBe(Rand);
                    o7.ShouldBe(Rand);
                    o8.ShouldBe(Rand);
                    o9.ShouldBe(Rand);
                    o10.ShouldBe(Rand);
                    o11.ShouldBe(Rand);
                    o12.ShouldBe(Rand);
                    o13.ShouldBe(Rand);
                    o14.ShouldBe(Rand);
                    o15.ShouldBe(Rand);
                    o16.ShouldBe(Rand);
                    })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand);
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "(Func<U>) => Func<U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "(Func<T1, U>) => Func<T1, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "(Func<T1, T2, U>) => Func<T1, T2, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "(Func<T1, T2, T3, U>) => Func<T1, T2, T3, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "(Func<T1, T2, T3, T4, U>) => Func<T1, T2, T3, T4, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "(Func<T1, T2, T3, T4, T5, U>) => Func<T1, T2, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "(Func<T1, T2, T3, T4, T5, T6, U>) => Func<T1, T2, T3, T4, T5, T6, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "(Func<T1, T2, T3, T4, T5, T6, T7, U>) => Func<T1, T2, T3, T4, T5, T6, T7, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "(Func<T1, T2, T3, T4, T5, T6, T7, T8, U>) => Func<T1, T2, T3, T4, T5, T6, T7, T8, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>) => Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>) => Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>) => Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>) => Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>) => Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>) => Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>) => Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>) => Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "() => Func<U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "() => Func<T1, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "() => Func<T1, T2, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "() => Func<T1, T2, T3, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "() => Func<T1, T2, T3, T4, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "() => Func<T1, T2, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "() => Func<T1, T2, T3, T4, T5, T6, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "() => Func<T1, T2, T3, T4, T5, T6, T7, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "() => Func<T1, T2, T3, T4, T5, T6, T7, T8, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "() => Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "() => Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "() => Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "() => Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "() => Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "() => Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "() => Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.F) + "() => Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Function) + "(Func<U>) => Func<U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Function) + "(Func<T1, U>) => Func<T1, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Function) + "(Func<T1, T2, U>) => Func<T1, T2, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Function) + "(Func<T1, T2, T3, U>) => Func<T1, T2, T3, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Function) + "(Func<T1, T2, T3, T4, U>) => Func<T1, T2, T3, T4, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Function) + "(Func<T1, T2, T3, T4, T5, U>) => Func<T1, T2, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Function) + "(Func<T1, T2, T3, T4, T5, T6, U>) => Func<T1, T2, T3, T4, T5, T6, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Function) + "(Func<T1, T2, T3, T4, T5, T6, T7, U>) => Func<T1, T2, T3, T4, T5, T6, T7, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Function) + "(Func<T1, T2, T3, T4, T5, T6, T7, T8, U>) => Func<T1, T2, T3, T4, T5, T6, T7, T8, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Function) + "(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>) => Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Function) + "(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>) => Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Function) + "(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>) => Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Function) + "(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>) => Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Function) + "(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>) => Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Function) + "(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>) => Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Function) + "(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>) => Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Logic) + "." + nameof(L.Logic.Function) + "(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>) => Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>")]
        public void L_F()
            {
            L.F<int>()()
                .ShouldBe(default(int));
            L.F<int, int>()(arg: 0)
                .ShouldBe(default(int));
            L.F<int, int, int>()(arg1: 0, arg2: 0)
                .ShouldBe(default(int));
            L.F<int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0)
                .ShouldBe(default(int));
            L.F<int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0)
                .ShouldBe(default(int));
            L.F<int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0)
                .ShouldBe(default(int));
            L.F<int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0)
                .ShouldBe(default(int));
            L.F<int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0)
                .ShouldBe(default(int));
            L.F<int, int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0)
                .ShouldBe(default(int));
            L.F<int, int, int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0, arg9: 0)
                .ShouldBe(default(int));
            L.F<int, int, int, int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0, arg9: 0, arg10: 0)
                .ShouldBe(default(int));
            L.F<int, int, int, int, int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0, arg9: 0, arg10: 0, arg11: 0)
                .ShouldBe(default(int));
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0, arg9: 0, arg10: 0, arg11: 0, arg12: 0)
                .ShouldBe(default(int));
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0, arg9: 0, arg10: 0, arg11: 0, arg12: 0, arg13: 0)
                .ShouldBe(default(int));
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0, arg9: 0, arg10: 0, arg11: 0, arg12: 0, arg13: 0, arg14: 0)
                .ShouldBe(default(int));
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0, arg9: 0, arg10: 0, arg11: 0, arg12: 0, arg13: 0, arg14: 0,
                arg15: 0)
                .ShouldBe(default(int));
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>()(arg1: 0, arg2: 0, arg3: 0, arg4: 0, arg5: 0, arg6: 0, arg7: 0, arg8: 0, arg9: 0, arg10: 0, arg11: 0, arg12: 0, arg13: 0,
                arg14: 0, arg15: 0, arg16: 0)
                .ShouldBe(default(int));

            int Rand = new Random().Next();

            L.F(() => Rand)().ShouldBe(Rand);
            L.F<int, int>(o1 =>
                {
                o1.ShouldBe(Rand);
                return Rand;
                })(Rand).ShouldBe(Rand);
            L.F<int, int, int>((o1, o2) =>
                {
                o1.ShouldBe(Rand);
                o2.ShouldBe(Rand);
                return Rand;
                })(Rand, Rand).ShouldBe(Rand);
            L.F<int, int, int, int>((o1, o2, o3) =>
                {
                o1.ShouldBe(Rand);
                o2.ShouldBe(Rand);
                o3.ShouldBe(Rand);
                return Rand;
                })(Rand, Rand, Rand).ShouldBe(Rand);
            L.F<int, int, int, int, int>((o1, o2, o3, o4) =>
                {
                o1.ShouldBe(Rand);
                o2.ShouldBe(Rand);
                o3.ShouldBe(Rand);
                o4.ShouldBe(Rand);
                return Rand;
                })(Rand, Rand, Rand, Rand).ShouldBe(Rand);
            L.F<int, int, int, int, int, int>((o1, o2, o3, o4, o5) =>
                {
                o1.ShouldBe(Rand);
                o2.ShouldBe(Rand);
                o3.ShouldBe(Rand);
                o4.ShouldBe(Rand);
                o5.ShouldBe(Rand);
                return Rand;
                })(Rand, Rand, Rand, Rand, Rand).ShouldBe(Rand);
            L.F<int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6) =>
                {
                o1.ShouldBe(Rand);
                o2.ShouldBe(Rand);
                o3.ShouldBe(Rand);
                o4.ShouldBe(Rand);
                o5.ShouldBe(Rand);
                o6.ShouldBe(Rand);
                return Rand;
                })(Rand, Rand, Rand, Rand, Rand, Rand).ShouldBe(Rand);
            L.F<int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7) =>
                {
                o1.ShouldBe(Rand);
                o2.ShouldBe(Rand);
                o3.ShouldBe(Rand);
                o4.ShouldBe(Rand);
                o5.ShouldBe(Rand);
                o6.ShouldBe(Rand);
                o7.ShouldBe(Rand);
                return Rand;
                })(Rand, Rand, Rand, Rand, Rand, Rand, Rand).ShouldBe(Rand);
            L.F<int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8) =>
                {
                o1.ShouldBe(Rand);
                o2.ShouldBe(Rand);
                o3.ShouldBe(Rand);
                o4.ShouldBe(Rand);
                o5.ShouldBe(Rand);
                o6.ShouldBe(Rand);
                o7.ShouldBe(Rand);
                o8.ShouldBe(Rand);
                return Rand;
                })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand).ShouldBe(Rand);
            L.F<int, int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8, o9) =>
                {
                o1.ShouldBe(Rand);
                o2.ShouldBe(Rand);
                o3.ShouldBe(Rand);
                o4.ShouldBe(Rand);
                o5.ShouldBe(Rand);
                o6.ShouldBe(Rand);
                o7.ShouldBe(Rand);
                o8.ShouldBe(Rand);
                o9.ShouldBe(Rand);
                return Rand;
                })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand).ShouldBe(Rand);
            L.F<int, int, int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) =>
                {
                o1.ShouldBe(Rand);
                o2.ShouldBe(Rand);
                o3.ShouldBe(Rand);
                o4.ShouldBe(Rand);
                o5.ShouldBe(Rand);
                o6.ShouldBe(Rand);
                o7.ShouldBe(Rand);
                o8.ShouldBe(Rand);
                o9.ShouldBe(Rand);
                o10.ShouldBe(Rand);
                return Rand;
                })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand).ShouldBe(Rand);
            L.F<int, int, int, int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) =>
                {
                o1.ShouldBe(Rand);
                o2.ShouldBe(Rand);
                o3.ShouldBe(Rand);
                o4.ShouldBe(Rand);
                o5.ShouldBe(Rand);
                o6.ShouldBe(Rand);
                o7.ShouldBe(Rand);
                o8.ShouldBe(Rand);
                o9.ShouldBe(Rand);
                o10.ShouldBe(Rand);
                o11.ShouldBe(Rand);
                return Rand;
                })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand).ShouldBe(Rand);
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) =>
                {
                o1.ShouldBe(Rand);
                o2.ShouldBe(Rand);
                o3.ShouldBe(Rand);
                o4.ShouldBe(Rand);
                o5.ShouldBe(Rand);
                o6.ShouldBe(Rand);
                o7.ShouldBe(Rand);
                o8.ShouldBe(Rand);
                o9.ShouldBe(Rand);
                o10.ShouldBe(Rand);
                o11.ShouldBe(Rand);
                o12.ShouldBe(Rand);
                return Rand;
                })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand).ShouldBe(Rand);
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int, int>(
                (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) =>
                    {
                    o1.ShouldBe(Rand);
                    o2.ShouldBe(Rand);
                    o3.ShouldBe(Rand);
                    o4.ShouldBe(Rand);
                    o5.ShouldBe(Rand);
                    o6.ShouldBe(Rand);
                    o7.ShouldBe(Rand);
                    o8.ShouldBe(Rand);
                    o9.ShouldBe(Rand);
                    o10.ShouldBe(Rand);
                    o11.ShouldBe(Rand);
                    o12.ShouldBe(Rand);
                    o13.ShouldBe(Rand);
                    return Rand;
                    })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand).ShouldBe(Rand);
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>(
                (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) =>
                    {
                    o1.ShouldBe(Rand);
                    o2.ShouldBe(Rand);
                    o3.ShouldBe(Rand);
                    o4.ShouldBe(Rand);
                    o5.ShouldBe(Rand);
                    o6.ShouldBe(Rand);
                    o7.ShouldBe(Rand);
                    o8.ShouldBe(Rand);
                    o9.ShouldBe(Rand);
                    o10.ShouldBe(Rand);
                    o11.ShouldBe(Rand);
                    o12.ShouldBe(Rand);
                    o13.ShouldBe(Rand);
                    o14.ShouldBe(Rand);
                    return Rand;
                    })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand).ShouldBe(Rand);
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>(
                (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) =>
                    {
                    o1.ShouldBe(Rand);
                    o2.ShouldBe(Rand);
                    o3.ShouldBe(Rand);
                    o4.ShouldBe(Rand);
                    o5.ShouldBe(Rand);
                    o6.ShouldBe(Rand);
                    o7.ShouldBe(Rand);
                    o8.ShouldBe(Rand);
                    o9.ShouldBe(Rand);
                    o10.ShouldBe(Rand);
                    o11.ShouldBe(Rand);
                    o12.ShouldBe(Rand);
                    o13.ShouldBe(Rand);
                    o14.ShouldBe(Rand);
                    o15.ShouldBe(Rand);
                    return Rand;
                    })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand).ShouldBe(Rand);
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>(
                (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) =>
                    {
                    o1.ShouldBe(Rand);
                    o2.ShouldBe(Rand);
                    o3.ShouldBe(Rand);
                    o4.ShouldBe(Rand);
                    o5.ShouldBe(Rand);
                    o6.ShouldBe(Rand);
                    o7.ShouldBe(Rand);
                    o8.ShouldBe(Rand);
                    o9.ShouldBe(Rand);
                    o10.ShouldBe(Rand);
                    o11.ShouldBe(Rand);
                    o12.ShouldBe(Rand);
                    o13.ShouldBe(Rand);
                    o14.ShouldBe(Rand);
                    o15.ShouldBe(Rand);
                    o16.ShouldBe(Rand);
                    return Rand;
                    })(Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand, Rand).ShouldBe(Rand);
            }
        }
    }