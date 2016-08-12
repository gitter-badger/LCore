using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt))]
    public partial class LogicExtTester : XUnitOutputTester, IDisposable
        {
        public LogicExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Cast) + "(Func`5<T1, T2, T3, T4, U1>) => Func`5<T5, T6, T7, T8, U2>")]
        public void Cast_Func_5_T1_T2_T3_T4_U1_Func_5_T5_T6_T7_T8_U2()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Cast
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`5<T2, T3, T4, T5, T1>, Action`1<T1>) => Action`4<T2, T3, T4, T5>")]
        public void Enclose_Func_5_T2_T3_T4_T5_T1_Action_1_T1_Action_4_T2_T3_T4_T5()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`1<T1>, Action`2<T1, T2>) => Action`1<T2>")]
        public void Enclose_Func_1_T1_Action_2_T1_T2_Action_1_T2()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose2) + "(Func`1<T2>, Action`2<T1, T2>) => Action`1<T1>")]
        public void Enclose2_Func_1_T2_Action_2_T1_T2_Action_1_T1()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`2<T3, T1>, Action`2<T1, T2>) => Action`2<T2, T3>")]
        public void Enclose_Func_2_T3_T1_Action_2_T1_T2_Action_2_T2_T3()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose2) + "(Func`2<T3, T2>, Action`2<T1, T2>) => Action`2<T1, T3>")]
        public void Enclose2_Func_2_T3_T2_Action_2_T1_T2_Action_2_T1_T3()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`3<T3, T4, T1>, Action`2<T1, T2>) => Action`3<T2, T3, T4>")]
        public void Enclose_Func_3_T3_T4_T1_Action_2_T1_T2_Action_3_T2_T3_T4()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose2) + "(Func`3<T3, T4, T2>, Action`2<T1, T2>) => Action`3<T1, T3, T4>")]
        public void Enclose2_Func_3_T3_T4_T2_Action_2_T1_T2_Action_3_T1_T3_T4()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`4<T3, T4, T5, T1>, Action`2<T1, T2>) => Action`4<T2, T3, T4, T5>")]
        public void Enclose_Func_4_T3_T4_T5_T1_Action_2_T1_T2_Action_4_T2_T3_T4_T5()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose2) + "(Func`4<T3, T4, T5, T2>, Action`2<T1, T2>) => Action`4<T1, T3, T4, T5>")]
        public void Enclose2_Func_4_T3_T4_T5_T2_Action_2_T1_T2_Action_4_T1_T3_T4_T5()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`1<T1>, Action`3<T1, T2, T3>) => Action`2<T2, T3>")]
        public void Enclose_Func_1_T1_Action_3_T1_T2_T3_Action_2_T2_T3()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose2) + "(Func`1<T2>, Action`3<T1, T2, T3>) => Action`2<T1, T3>")]
        public void Enclose2_Func_1_T2_Action_3_T1_T2_T3_Action_2_T1_T3()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose3) + "(Func`1<T3>, Action`3<T1, T2, T3>) => Action`2<T1, T2>")]
        public void Enclose3_Func_1_T3_Action_3_T1_T2_T3_Action_2_T1_T2()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose3
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`2<T4, T1>, Action`3<T1, T2, T3>) => Action`3<T2, T3, T4>")]
        public void Enclose_Func_2_T4_T1_Action_3_T1_T2_T3_Action_3_T2_T3_T4()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose2) + "(Func`2<T4, T2>, Action`3<T1, T2, T3>) => Action`3<T1, T3, T4>")]
        public void Enclose2_Func_2_T4_T2_Action_3_T1_T2_T3_Action_3_T1_T3_T4()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose3) + "(Func`2<T4, T3>, Action`3<T1, T2, T3>) => Action`3<T1, T2, T4>")]
        public void Enclose3_Func_2_T4_T3_Action_3_T1_T2_T3_Action_3_T1_T2_T4()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose3
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`3<T4, T5, T1>, Action`3<T1, T2, T3>) => Action`4<T2, T3, T4, T5>")]
        public void Enclose_Func_3_T4_T5_T1_Action_3_T1_T2_T3_Action_4_T2_T3_T4_T5()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose2) + "(Func`3<T4, T5, T2>, Action`3<T1, T2, T3>) => Action`4<T1, T3, T4, T5>")]
        public void Enclose2_Func_3_T4_T5_T2_Action_3_T1_T2_T3_Action_4_T1_T3_T4_T5()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose3) + "(Func`3<T4, T5, T3>, Action`3<T1, T2, T3>) => Action`4<T1, T2, T4, T5>")]
        public void Enclose3_Func_3_T4_T5_T3_Action_3_T1_T2_T3_Action_4_T1_T2_T4_T5()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose3
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`1<T1>, Action`4<T1, T2, T3, T4>) => Action`3<T2, T3, T4>")]
        public void Enclose_Func_1_T1_Action_4_T1_T2_T3_T4_Action_3_T2_T3_T4()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose2) + "(Func`1<T2>, Action`4<T1, T2, T3, T4>) => Action`3<T1, T3, T4>")]
        public void Enclose2_Func_1_T2_Action_4_T1_T2_T3_T4_Action_3_T1_T3_T4()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose3) + "(Func`1<T3>, Action`4<T1, T2, T3, T4>) => Action`3<T1, T2, T4>")]
        public void Enclose3_Func_1_T3_Action_4_T1_T2_T3_T4_Action_3_T1_T2_T4()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose3
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose4) + "(Func`1<T4>, Action`4<T1, T2, T3, T4>) => Action`3<T1, T2, T3>")]
        public void Enclose4_Func_1_T4_Action_4_T1_T2_T3_T4_Action_3_T1_T2_T3()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose4
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`2<T5, T1>, Action`4<T1, T2, T3, T4>) => Action`4<T2, T3, T4, T5>")]
        public void Enclose_Func_2_T5_T1_Action_4_T1_T2_T3_T4_Action_4_T2_T3_T4_T5()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose2) + "(Func`2<T5, T2>, Action`4<T1, T2, T3, T4>) => Action`4<T1, T3, T4, T5>")]
        public void Enclose2_Func_2_T5_T2_Action_4_T1_T2_T3_T4_Action_4_T1_T3_T4_T5()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose3) + "(Func`2<T5, T3>, Action`4<T1, T2, T3, T4>) => Action`4<T1, T2, T4, T5>")]
        public void Enclose3_Func_2_T5_T3_Action_4_T1_T2_T3_T4_Action_4_T1_T2_T4_T5()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose3
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose4) + "(Func`2<T5, T4>, Action`4<T1, T2, T3, T4>) => Action`4<T1, T2, T3, T5>")]
        public void Enclose4_Func_2_T5_T4_Action_4_T1_T2_T3_T4_Action_4_T1_T2_T3_T5()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose4
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`1<T1>, Func`2<T1, U>) => Func`1<U>")]
        public void Enclose_Func_1_T1_Func_2_T1_U_Func_1_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`2<T1, T2>, Func`2<T2, U>) => Func`2<T1, U>")]
        public void Enclose_Func_2_T1_T2_Func_2_T2_U_Func_2_T1_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`3<T1, T2, T3>, Func`2<T3, U>) => Func`3<T1, T2, U>")]
        public void Enclose_Func_3_T1_T2_T3_Func_2_T3_U_Func_3_T1_T2_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`4<T1, T2, T3, T4>, Func`2<T4, U>) => Func`4<T1, T2, T3, U>")]
        public void Enclose_Func_4_T1_T2_T3_T4_Func_2_T4_U_Func_4_T1_T2_T3_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`5<T1, T2, T3, T4, T5>, Func`2<T5, U>) => Func`5<T1, T2, T3, T4, U>")]
        public void Enclose_Func_5_T1_T2_T3_T4_T5_Func_2_T5_U_Func_5_T1_T2_T3_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`1<T1>, Func`3<T1, T2, U>) => Func`2<T2, U>")]
        public void Enclose_Func_1_T1_Func_3_T1_T2_U_Func_2_T2_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose2) + "(Func`1<T2>, Func`3<T1, T2, U>) => Func`2<T1, U>")]
        public void Enclose2_Func_1_T2_Func_3_T1_T2_U_Func_2_T1_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`2<T3, T1>, Func`3<T1, T2, U>) => Func`3<T2, T3, U>")]
        public void Enclose_Func_2_T3_T1_Func_3_T1_T2_U_Func_3_T2_T3_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose2) + "(Func`2<T3, T2>, Func`3<T1, T2, U>) => Func`3<T1, T3, U>")]
        public void Enclose2_Func_2_T3_T2_Func_3_T1_T2_U_Func_3_T1_T3_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`3<T3, T4, T1>, Func`3<T1, T2, U>) => Func`4<T2, T3, T4, U>")]
        public void Enclose_Func_3_T3_T4_T1_Func_3_T1_T2_U_Func_4_T2_T3_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose2) + "(Func`3<T3, T4, T2>, Func`3<T1, T2, U>) => Func`4<T1, T3, T4, U>")]
        public void Enclose2_Func_3_T3_T4_T2_Func_3_T1_T2_U_Func_4_T1_T3_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`4<T3, T4, T5, T1>, Func`3<T1, T2, U>) => Func`5<T2, T3, T4, T5, U>")]
        public void Enclose_Func_4_T3_T4_T5_T1_Func_3_T1_T2_U_Func_5_T2_T3_T4_T5_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose2) + "(Func`4<T3, T4, T5, T2>, Func`3<T1, T2, U>) => Func`5<T1, T3, T4, T5, U>")]
        public void Enclose2_Func_4_T3_T4_T5_T2_Func_3_T1_T2_U_Func_5_T1_T3_T4_T5_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`1<T1>, Func`4<T1, T2, T3, U>) => Func`3<T2, T3, U>")]
        public void Enclose_Func_1_T1_Func_4_T1_T2_T3_U_Func_3_T2_T3_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose2) + "(Func`1<T2>, Func`4<T1, T2, T3, U>) => Func`3<T1, T3, U>")]
        public void Enclose2_Func_1_T2_Func_4_T1_T2_T3_U_Func_3_T1_T3_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose3) + "(Func`1<T3>, Func`4<T1, T2, T3, U>) => Func`3<T1, T2, U>")]
        public void Enclose3_Func_1_T3_Func_4_T1_T2_T3_U_Func_3_T1_T2_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose3
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`2<T4, T1>, Func`4<T1, T2, T3, U>) => Func`4<T2, T3, T4, U>")]
        public void Enclose_Func_2_T4_T1_Func_4_T1_T2_T3_U_Func_4_T2_T3_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose2) + "(Func`2<T4, T2>, Func`4<T1, T2, T3, U>) => Func`4<T1, T3, T4, U>")]
        public void Enclose2_Func_2_T4_T2_Func_4_T1_T2_T3_U_Func_4_T1_T3_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose3) + "(Func`2<T4, T3>, Func`4<T1, T2, T3, U>) => Func`4<T1, T2, T4, U>")]
        public void Enclose3_Func_2_T4_T3_Func_4_T1_T2_T3_U_Func_4_T1_T2_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose3
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`3<T4, T5, T1>, Func`4<T1, T2, T3, U>) => Func`5<T2, T3, T4, T5, U>")]
        public void Enclose_Func_3_T4_T5_T1_Func_4_T1_T2_T3_U_Func_5_T2_T3_T4_T5_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose2) + "(Func`3<T4, T5, T2>, Func`4<T1, T2, T3, U>) => Func`5<T1, T3, T4, T5, U>")]
        public void Enclose2_Func_3_T4_T5_T2_Func_4_T1_T2_T3_U_Func_5_T1_T3_T4_T5_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose3) + "(Func`3<T4, T5, T3>, Func`4<T1, T2, T3, U>) => Func`5<T1, T2, T4, T5, U>")]
        public void Enclose3_Func_3_T4_T5_T3_Func_4_T1_T2_T3_U_Func_5_T1_T2_T4_T5_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose3
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`1<T1>, Func`5<T1, T2, T3, T4, U>) => Func`4<T2, T3, T4, U>")]
        public void Enclose_Func_1_T1_Func_5_T1_T2_T3_T4_U_Func_4_T2_T3_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose2) + "(Func`1<T2>, Func`5<T1, T2, T3, T4, U>) => Func`4<T1, T3, T4, U>")]
        public void Enclose2_Func_1_T2_Func_5_T1_T2_T3_T4_U_Func_4_T1_T3_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose3) + "(Func`1<T3>, Func`5<T1, T2, T3, T4, U>) => Func`4<T1, T2, T4, U>")]
        public void Enclose3_Func_1_T3_Func_5_T1_T2_T3_T4_U_Func_4_T1_T2_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose3
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose4) + "(Func`1<T4>, Func`5<T1, T2, T3, T4, U>) => Func`4<T1, T2, T3, U>")]
        public void Enclose4_Func_1_T4_Func_5_T1_T2_T3_T4_U_Func_4_T1_T2_T3_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose4
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`2<T5, T1>, Func`5<T1, T2, T3, T4, U>) => Func`5<T2, T3, T4, T5, U>")]
        public void Enclose_Func_2_T5_T1_Func_5_T1_T2_T3_T4_U_Func_5_T2_T3_T4_T5_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose2) + "(Func`2<T5, T2>, Func`5<T1, T2, T3, T4, U>) => Func`5<T1, T3, T4, T5, U>")]
        public void Enclose2_Func_2_T5_T2_Func_5_T1_T2_T3_T4_U_Func_5_T1_T3_T4_T5_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose3) + "(Func`2<T5, T3>, Func`5<T1, T2, T3, T4, U>) => Func`5<T1, T2, T4, T5, U>")]
        public void Enclose3_Func_2_T5_T3_Func_5_T1_T2_T3_T4_U_Func_5_T1_T2_T4_T5_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose3
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose4) + "(Func`2<T5, T4>, Func`5<T1, T2, T3, T4, U>) => Func`5<T1, T2, T3, T5, U>")]
        public void Enclose4_Func_2_T5_T4_Func_5_T1_T2_T3_T4_U_Func_5_T1_T2_T3_T5_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose4
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Cast) + "(Action`1<T1>) => Action`1<U1>")]
        public void Cast_Action_1_T1_Action_1_U1()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Cast
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Cast) + "(Action`2<T1, T2>) => Action`2<U1, U2>")]
        public void Cast_Action_2_T1_T2_Action_2_U1_U2()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Cast
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Cast) + "(Action`3<T1, T2, T3>) => Action`3<U1, U2, U3>")]
        public void Cast_Action_3_T1_T2_T3_Action_3_U1_U2_U3()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Cast
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Cast) + "(Action`4<T1, T2, T3, T4>) => Action`4<U1, U2, U3, U4>")]
        public void Cast_Action_4_T1_T2_T3_T4_Action_4_U1_U2_U3_U4()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Cast
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Cast) + "(Func`1<U1>) => Func`1<U2>")]
        public void Cast_Func_1_U1_Func_1_U2()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Cast
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Cast) + "(Func`2<T1, U1>) => Func`2<T2, U2>")]
        public void Cast_Func_2_T1_U1_Func_2_T2_U2()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Cast
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Cast) + "(Func`3<T1, T2, U1>) => Func`3<T3, T4, U2>")]
        public void Cast_Func_3_T1_T2_U1_Func_3_T3_T4_U2()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Cast
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Cast) + "(Func`4<T1, T2, T3, U1>) => Func`4<T4, T5, T6, U2>")]
        public void Cast_Func_4_T1_T2_T3_U1_Func_4_T4_T5_T6_U2()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Cast
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Action`1<U>, Func`1<U>) => Action")]
        public void Surround_Action_1_U_Func_1_U_Action()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Action`1<U>, Func`2<T1, U>) => Action`1<T1>")]
        public void Surround_Action_1_U_Func_2_T1_U_Action_1_T1()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Action`1<U>, Func`3<T1, T2, U>) => Action`2<T1, T2>")]
        public void Surround_Action_1_U_Func_3_T1_T2_U_Action_2_T1_T2()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Action`1<U>, Func`4<T1, T2, T3, U>) => Action`3<T1, T2, T3>")]
        public void Surround_Action_1_U_Func_4_T1_T2_T3_U_Action_3_T1_T2_T3()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Action`1<U>, Func`5<T1, T2, T3, T4, U>) => Action`4<T1, T2, T3, T4>")]
        public void Surround_Action_1_U_Func_5_T1_T2_T3_T4_U_Action_4_T1_T2_T3_T4()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Action`2<T1, T2>, Func`1<T1>) => Action`1<T2>")]
        public void Surround_Action_2_T1_T2_Func_1_T1_Action_1_T2()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround2) + "(Action`2<T1, T2>, Func`1<T2>) => Action`1<T1>")]
        public void Surround2_Action_2_T1_T2_Func_1_T2_Action_1_T1()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Action`2<T1, T2>, Func`2<T3, T1>) => Action`2<T2, T3>")]
        public void Surround_Action_2_T1_T2_Func_2_T3_T1_Action_2_T2_T3()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround2) + "(Action`2<T1, T2>, Func`2<T3, T2>) => Action`2<T1, T3>")]
        public void Surround2_Action_2_T1_T2_Func_2_T3_T2_Action_2_T1_T3()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Action`2<T1, T2>, Func`3<T3, T4, T1>) => Action`3<T2, T3, T4>")]
        public void Surround_Action_2_T1_T2_Func_3_T3_T4_T1_Action_3_T2_T3_T4()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround2) + "(Action`2<T1, T2>, Func`3<T3, T4, T2>) => Action`3<T1, T3, T4>")]
        public void Surround2_Action_2_T1_T2_Func_3_T3_T4_T2_Action_3_T1_T3_T4()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Action`2<T1, T2>, Func`4<T3, T4, T5, T1>) => Action`4<T2, T3, T4, T5>")]
        public void Surround_Action_2_T1_T2_Func_4_T3_T4_T5_T1_Action_4_T2_T3_T4_T5()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround2) + "(Action`2<T1, T2>, Func`4<T3, T4, T5, T2>) => Action`4<T1, T3, T4, T5>")]
        public void Surround2_Action_2_T1_T2_Func_4_T3_T4_T5_T2_Action_4_T1_T3_T4_T5()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Action`3<T1, T2, T3>, Func`1<T1>) => Action`2<T2, T3>")]
        public void Surround_Action_3_T1_T2_T3_Func_1_T1_Action_2_T2_T3()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround2) + "(Action`3<T1, T2, T3>, Func`1<T2>) => Action`2<T1, T3>")]
        public void Surround2_Action_3_T1_T2_T3_Func_1_T2_Action_2_T1_T3()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround3) + "(Action`3<T1, T2, T3>, Func`1<T3>) => Action`2<T1, T2>")]
        public void Surround3_Action_3_T1_T2_T3_Func_1_T3_Action_2_T1_T2()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround3
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Action`3<T1, T2, T3>, Func`2<T4, T1>) => Action`3<T2, T3, T4>")]
        public void Surround_Action_3_T1_T2_T3_Func_2_T4_T1_Action_3_T2_T3_T4()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround2) + "(Action`3<T1, T2, T3>, Func`2<T4, T2>) => Action`3<T1, T3, T4>")]
        public void Surround2_Action_3_T1_T2_T3_Func_2_T4_T2_Action_3_T1_T3_T4()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround3) + "(Action`3<T1, T2, T3>, Func`2<T4, T3>) => Action`3<T1, T2, T4>")]
        public void Surround3_Action_3_T1_T2_T3_Func_2_T4_T3_Action_3_T1_T2_T4()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround3
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Action`3<T1, T2, T3>, Func`3<T4, T5, T1>) => Action`4<T2, T3, T4, T5>")]
        public void Surround_Action_3_T1_T2_T3_Func_3_T4_T5_T1_Action_4_T2_T3_T4_T5()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround2) + "(Action`3<T1, T2, T3>, Func`3<T4, T5, T2>) => Action`4<T1, T3, T4, T5>")]
        public void Surround2_Action_3_T1_T2_T3_Func_3_T4_T5_T2_Action_4_T1_T3_T4_T5()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround3) + "(Action`3<T1, T2, T3>, Func`3<T4, T5, T3>) => Action`4<T1, T2, T4, T5>")]
        public void Surround3_Action_3_T1_T2_T3_Func_3_T4_T5_T3_Action_4_T1_T2_T4_T5()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround3
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Action`4<T1, T2, T3, T4>, Func`1<T1>) => Action`3<T2, T3, T4>")]
        public void Surround_Action_4_T1_T2_T3_T4_Func_1_T1_Action_3_T2_T3_T4()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround2) + "(Action`4<T1, T2, T3, T4>, Func`1<T2>) => Action`3<T1, T3, T4>")]
        public void Surround2_Action_4_T1_T2_T3_T4_Func_1_T2_Action_3_T1_T3_T4()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround3) + "(Action`4<T1, T2, T3, T4>, Func`1<T3>) => Action`3<T1, T2, T4>")]
        public void Surround3_Action_4_T1_T2_T3_T4_Func_1_T3_Action_3_T1_T2_T4()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround3
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround4) + "(Action`4<T1, T2, T3, T4>, Func`1<T4>) => Action`3<T1, T2, T3>")]
        public void Surround4_Action_4_T1_T2_T3_T4_Func_1_T4_Action_3_T1_T2_T3()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround4
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Action`4<T1, T2, T3, T4>, Func`2<T5, T1>) => Action`4<T2, T3, T4, T5>")]
        public void Surround_Action_4_T1_T2_T3_T4_Func_2_T5_T1_Action_4_T2_T3_T4_T5()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround2) + "(Action`4<T1, T2, T3, T4>, Func`2<T5, T2>) => Action`4<T1, T3, T4, T5>")]
        public void Surround2_Action_4_T1_T2_T3_T4_Func_2_T5_T2_Action_4_T1_T3_T4_T5()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround3) + "(Action`4<T1, T2, T3, T4>, Func`2<T5, T3>) => Action`4<T1, T2, T4, T5>")]
        public void Surround3_Action_4_T1_T2_T3_T4_Func_2_T5_T3_Action_4_T1_T2_T4_T5()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround3
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround4) + "(Action`4<T1, T2, T3, T4>, Func`2<T5, T4>) => Action`4<T1, T2, T3, T5>")]
        public void Surround4_Action_4_T1_T2_T3_T4_Func_2_T5_T4_Action_4_T1_T2_T3_T5()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround4
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Func`2<T1, U>, Func`1<T1>) => Func`1<U>")]
        public void Surround_Func_2_T1_U_Func_1_T1_Func_1_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Func`2<T2, U>, Func`2<T1, T2>) => Func`2<T1, U>")]
        public void Surround_Func_2_T2_U_Func_2_T1_T2_Func_2_T1_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Func`2<T3, U>, Func`3<T1, T2, T3>) => Func`3<T1, T2, U>")]
        public void Surround_Func_2_T3_U_Func_3_T1_T2_T3_Func_3_T1_T2_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Func`2<T4, U>, Func`4<T1, T2, T3, T4>) => Func`4<T1, T2, T3, U>")]
        public void Surround_Func_2_T4_U_Func_4_T1_T2_T3_T4_Func_4_T1_T2_T3_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Func`2<T5, U>, Func`5<T1, T2, T3, T4, T5>) => Func`5<T1, T2, T3, T4, U>")]
        public void Surround_Func_2_T5_U_Func_5_T1_T2_T3_T4_T5_Func_5_T1_T2_T3_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Func`3<T1, T2, U>, Func`1<T1>) => Func`2<T2, U>")]
        public void Surround_Func_3_T1_T2_U_Func_1_T1_Func_2_T2_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround2) + "(Func`3<T1, T2, U>, Func`1<T2>) => Func`2<T1, U>")]
        public void Surround2_Func_3_T1_T2_U_Func_1_T2_Func_2_T1_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Func`3<T1, T2, U>, Func`2<T3, T1>) => Func`3<T2, T3, U>")]
        public void Surround_Func_3_T1_T2_U_Func_2_T3_T1_Func_3_T2_T3_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround2) + "(Func`3<T1, T2, U>, Func`2<T3, T2>) => Func`3<T1, T3, U>")]
        public void Surround2_Func_3_T1_T2_U_Func_2_T3_T2_Func_3_T1_T3_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Func`3<T1, T2, U>, Func`3<T3, T4, T1>) => Func`4<T2, T3, T4, U>")]
        public void Surround_Func_3_T1_T2_U_Func_3_T3_T4_T1_Func_4_T2_T3_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround2) + "(Func`3<T1, T2, U>, Func`3<T3, T4, T2>) => Func`4<T1, T3, T4, U>")]
        public void Surround2_Func_3_T1_T2_U_Func_3_T3_T4_T2_Func_4_T1_T3_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Func`3<T1, T2, U>, Func`4<T3, T4, T5, T1>) => Func`5<T2, T3, T4, T5, U>")]
        public void Surround_Func_3_T1_T2_U_Func_4_T3_T4_T5_T1_Func_5_T2_T3_T4_T5_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround2) + "(Func`3<T1, T2, U>, Func`4<T3, T4, T5, T2>) => Func`5<T1, T3, T4, T5, U>")]
        public void Surround2_Func_3_T1_T2_U_Func_4_T3_T4_T5_T2_Func_5_T1_T3_T4_T5_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Func`4<T1, T2, T3, U>, Func`1<T1>) => Func`3<T2, T3, U>")]
        public void Surround_Func_4_T1_T2_T3_U_Func_1_T1_Func_3_T2_T3_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround2) + "(Func`4<T1, T2, T3, U>, Func`1<T2>) => Func`3<T1, T3, U>")]
        public void Surround2_Func_4_T1_T2_T3_U_Func_1_T2_Func_3_T1_T3_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround3) + "(Func`4<T1, T2, T3, U>, Func`1<T3>) => Func`3<T1, T2, U>")]
        public void Surround3_Func_4_T1_T2_T3_U_Func_1_T3_Func_3_T1_T2_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround3
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Func`4<T1, T2, T3, U>, Func`2<T4, T1>) => Func`4<T2, T3, T4, U>")]
        public void Surround_Func_4_T1_T2_T3_U_Func_2_T4_T1_Func_4_T2_T3_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround2) + "(Func`4<T1, T2, T3, U>, Func`2<T4, T2>) => Func`4<T1, T3, T4, U>")]
        public void Surround2_Func_4_T1_T2_T3_U_Func_2_T4_T2_Func_4_T1_T3_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround3) + "(Func`4<T1, T2, T3, U>, Func`2<T4, T3>) => Func`4<T1, T2, T4, U>")]
        public void Surround3_Func_4_T1_T2_T3_U_Func_2_T4_T3_Func_4_T1_T2_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround3
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Func`4<T1, T2, T3, U>, Func`3<T4, T5, T1>) => Func`5<T2, T3, T4, T5, U>")]
        public void Surround_Func_4_T1_T2_T3_U_Func_3_T4_T5_T1_Func_5_T2_T3_T4_T5_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround2) + "(Func`4<T1, T2, T3, U>, Func`3<T4, T5, T2>) => Func`5<T1, T3, T4, T5, U>")]
        public void Surround2_Func_4_T1_T2_T3_U_Func_3_T4_T5_T2_Func_5_T1_T3_T4_T5_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround3) + "(Func`4<T1, T2, T3, U>, Func`3<T4, T5, T3>) => Func`5<T1, T2, T4, T5, U>")]
        public void Surround3_Func_4_T1_T2_T3_U_Func_3_T4_T5_T3_Func_5_T1_T2_T4_T5_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround3
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Func`5<T1, T2, T3, T4, U>, Func`1<T1>) => Func`4<T2, T3, T4, U>")]
        public void Surround_Func_5_T1_T2_T3_T4_U_Func_1_T1_Func_4_T2_T3_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround2) + "(Func`5<T1, T2, T3, T4, U>, Func`1<T2>) => Func`4<T1, T3, T4, U>")]
        public void Surround2_Func_5_T1_T2_T3_T4_U_Func_1_T2_Func_4_T1_T3_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround3) + "(Func`5<T1, T2, T3, T4, U>, Func`1<T3>) => Func`4<T1, T2, T4, U>")]
        public void Surround3_Func_5_T1_T2_T3_T4_U_Func_1_T3_Func_4_T1_T2_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround3
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround4) + "(Func`5<T1, T2, T3, T4, U>, Func`1<T4>) => Func`4<T1, T2, T3, U>")]
        public void Surround4_Func_5_T1_T2_T3_T4_U_Func_1_T4_Func_4_T1_T2_T3_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround4
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround) + "(Func`5<T1, T2, T3, T4, U>, Func`2<T5, T1>) => Func`5<T2, T3, T4, T5, U>")]
        public void Surround_Func_5_T1_T2_T3_T4_U_Func_2_T5_T1_Func_5_T2_T3_T4_T5_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround2) + "(Func`5<T1, T2, T3, T4, U>, Func`2<T5, T2>) => Func`5<T1, T3, T4, T5, U>")]
        public void Surround2_Func_5_T1_T2_T3_T4_U_Func_2_T5_T2_Func_5_T1_T3_T4_T5_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround2
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround3) + "(Func`5<T1, T2, T3, T4, U>, Func`2<T5, T3>) => Func`5<T1, T2, T4, T5, U>")]
        public void Surround3_Func_5_T1_T2_T3_T4_U_Func_2_T5_T3_Func_5_T1_T2_T4_T5_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround3
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Surround4) + "(Func`5<T1, T2, T3, T4, U>, Func`2<T5, T4>) => Func`5<T1, T2, T3, T5, U>")]
        public void Surround4_Func_5_T1_T2_T3_T4_U_Func_2_T5_T4_Func_5_T1_T2_T3_T5_U()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Surround4
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`1<T1>, Action`1<T1>) => Action")]
        public void Enclose_Func_1_T1_Action_1_T1_Action()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`2<T2, T1>, Action`1<T1>) => Action`1<T2>")]
        public void Enclose_Func_2_T2_T1_Action_1_T1_Action_1_T2()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`3<T2, T3, T1>, Action`1<T1>) => Action`2<T2, T3>")]
        public void Enclose_Func_3_T2_T3_T1_Action_1_T1_Action_2_T2_T3()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." + nameof(LogicExt.Enclose) + "(Func`4<T2, T3, T4, T1>, Action`1<T1>) => Action`3<T2, T3, T4>")]
        public void Enclose_Func_4_T2_T3_T4_T1_Action_1_T1_Action_3_T2_T3_T4()
            {
            // TODO: Implement method test LCore.Extensions.LogicExt.Enclose
            }

        }
    }