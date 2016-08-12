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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L))]
    public partial class L_LoopTester : XUnitOutputTester, IDisposable
        {
        public L_LoopTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.While_T) + "() => Func`3<Action`1<T1>, Func`2<T1, Boolean>, Action`1<T1>>")]
        public void While_T_Func_3_Action_1_T1_Func_2_T1_Boolean_Action_1_T1()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.While_T
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.While_T) + "() => Func`3<Action`2<T1, T2>, Func`3<T1, T2, Boolean>, Action`2<T1, T2>>")]
        public void While_T_Func_3_Action_2_T1_T2_Func_3_T1_T2_Boolean_Action_2_T1_T2()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.While_T
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.While_T) + "() => Func`3<Action`3<T1, T2, T3>, Func`4<T1, T2, T3, Boolean>, Action`3<T1, T2, T3>>")]
        public void While_T_Func_3_Action_3_T1_T2_T3_Func_4_T1_T2_T3_Boolean_Action_3_T1_T2_T3()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.While_T
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.While_T) + "() => Func`3<Action`4<T1, T2, T3, T4>, Func`5<T1, T2, T3, T4, Boolean>, Action`4<T1, T2, T3, T4>>")]
        public void While_T_Func_3_Action_4_T1_T2_T3_T4_Func_5_T1_T2_T3_T4_Boolean_Action_4_T1_T2_T3_T4()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.While_T
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.L_DoWhile) + "() => Func`3<Action, Func`1<Boolean>, Action>")]
        public void L_DoWhile()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.L_DoWhile
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.L_Until) + "() => Func`3<Func`1<U>, Func`1<Boolean>, Func`1<U>>")]
        public void L_Until()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.L_Until
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.L_DoUntil) + "() => Func`3<Func`1<U>, Func`1<Boolean>, Func`1<U>>")]
        public void L_DoUntil()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.L_DoUntil
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.L_Repeat_uint) + "() => Func`3<Action, UInt32, Action>")]
        public void L_Repeat_uint()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.L_Repeat_uint
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.L_Repeat_int) + "() => Func`3<Action, Int32, Action>")]
        public void L_Repeat_int()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.L_Repeat_int
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.WhileI_T) + "() => Func`3<Action`2<Int32, T1>, Func`3<Int32, T1, Boolean>, Action`1<T1>>")]
        public void WhileI_T_Func_3_Action_2_Int32_T1_Func_3_Int32_T1_Boolean_Action_1_T1()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.WhileI_T
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.WhileI_T) + "() => Func`3<Action`3<Int32, T1, T2>, Func`4<Int32, T1, T2, Boolean>, Action`2<T1, T2>>")]
        public void WhileI_T_Func_3_Action_3_Int32_T1_T2_Func_4_Int32_T1_T2_Boolean_Action_2_T1_T2()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.WhileI_T
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.WhileI_T) + "() => Func`3<Action`4<Int32, T1, T2, T3>, Func`5<Int32, T1, T2, T3, Boolean>, Action`3<T1, T2, T3>>")]
        public void WhileI_T_Func_3_Action_4_Int32_T1_T2_T3_Func_5_Int32_T1_T2_T3_Boolean_Action_3_T1_T2_T3()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.WhileI_T
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.Until) + "() => Func`3<Func`2<Int32, U>, Func`2<Int32, Boolean>, Func`1<U>>")]
        public void Until_Func_3_Func_2_Int32_U_Func_2_Int32_Boolean_Func_1_U()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.Until
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.Until) + "() => Func`3<Func`3<Int32, T1, U>, Func`3<Int32, T1, Boolean>, Func`2<T1, U>>")]
        public void Until_Func_3_Func_3_Int32_T1_U_Func_3_Int32_T1_Boolean_Func_2_T1_U()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.Until
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.Until) + "() => Func`3<Func`4<Int32, T1, T2, U>, Func`4<Int32, T1, T2, Boolean>, Func`3<T1, T2, U>>")]
        public void Until_Func_3_Func_4_Int32_T1_T2_U_Func_4_Int32_T1_T2_Boolean_Func_3_T1_T2_U()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.Until
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.Until) + "() => Func`3<Func`5<Int32, T1, T2, T3, U>, Func`5<Int32, T1, T2, T3, Boolean>, Func`4<T1, T2, T3, U>>")]
        public void Until_Func_3_Func_5_Int32_T1_T2_T3_U_Func_5_Int32_T1_T2_T3_Boolean_Func_4_T1_T2_T3_U()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.Until
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.DoWhile) + "() => Func`3<Action`1<Int32>, Func`2<Int32, Boolean>, Action>")]
        public void DoWhile_Func_3_Action_1_Int32_Func_2_Int32_Boolean_Action()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.DoWhile
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.DoWhile) + "() => Func`3<Action`2<Int32, T1>, Func`3<Int32, T1, Boolean>, Action`1<T1>>")]
        public void DoWhile_Func_3_Action_2_Int32_T1_Func_3_Int32_T1_Boolean_Action_1_T1()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.DoWhile
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.DoWhile) + "() => Func`3<Action`3<Int32, T1, T2>, Func`4<Int32, T1, T2, Boolean>, Action`2<T1, T2>>")]
        public void DoWhile_Func_3_Action_3_Int32_T1_T2_Func_4_Int32_T1_T2_Boolean_Action_2_T1_T2()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.DoWhile
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.DoWhile) + "() => Func`3<Action`4<Int32, T1, T2, T3>, Func`5<Int32, T1, T2, T3, Boolean>, Action`3<T1, T2, T3>>")]
        public void DoWhile_Func_3_Action_4_Int32_T1_T2_T3_Func_5_Int32_T1_T2_T3_Boolean_Action_3_T1_T2_T3()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.DoWhile
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.DoUntil) + "() => Func`3<Func`2<Int32, U>, Func`2<Int32, Boolean>, Func`1<U>>")]
        public void DoUntil_Func_3_Func_2_Int32_U_Func_2_Int32_Boolean_Func_1_U()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.DoUntil
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.DoUntil) + "() => Func`3<Func`3<Int32, T1, U>, Func`3<Int32, T1, Boolean>, Func`2<T1, U>>")]
        public void DoUntil_Func_3_Func_3_Int32_T1_U_Func_3_Int32_T1_Boolean_Func_2_T1_U()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.DoUntil
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.DoUntil) + "() => Func`3<Func`4<Int32, T1, T2, U>, Func`4<Int32, T1, T2, Boolean>, Func`3<T1, T2, U>>")]
        public void DoUntil_Func_3_Func_4_Int32_T1_T2_U_Func_4_Int32_T1_T2_Boolean_Func_3_T1_T2_U()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.DoUntil
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.DoUntil) + "() => Func`3<Func`5<Int32, T1, T2, T3, U>, Func`5<Int32, T1, T2, T3, Boolean>, Func`4<T1, T2, T3, U>>")]
        public void DoUntil_Func_3_Func_5_Int32_T1_T2_T3_U_Func_5_Int32_T1_T2_T3_Boolean_Func_4_T1_T2_T3_U()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.DoUntil
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.L_Collect) + "() => Func`3<Func`1<U>, UInt32, Func`1<List`1<U>>>")]
        public void L_Collect_Func_3_Func_1_U_UInt32_Func_1_List_1_U()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.L_Collect
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.L_Collect) + "() => Func`3<Func`2<T1, U>, UInt32, Func`2<T1, List`1<U>>>")]
        public void L_Collect_Func_3_Func_2_T1_U_UInt32_Func_2_T1_List_1_U()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.L_Collect
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.L_Collect) + "() => Func`3<Func`3<T1, T2, U>, UInt32, Func`3<T1, T2, List`1<U>>>")]
        public void L_Collect_Func_3_Func_3_T1_T2_U_UInt32_Func_3_T1_T2_List_1_U()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.L_Collect
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.L_Collect) + "() => Func`3<Func`4<T1, T2, T3, U>, UInt32, Func`4<T1, T2, T3, List`1<U>>>")]
        public void L_Collect_Func_3_Func_4_T1_T2_T3_U_UInt32_Func_4_T1_T2_T3_List_1_U()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.L_Collect
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.L_Collect) + "() => Func`3<Func`5<T1, T2, T3, T4, U>, UInt32, Func`5<T1, T2, T3, T4, List`1<U>>>")]
        public void L_Collect_Func_3_Func_5_T1_T2_T3_T4_U_UInt32_Func_5_T1_T2_T3_T4_List_1_U()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.L_Collect
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.L_MergeLoop) + "() => Func`2<Action, Func`2<Int32, Boolean>>")]
        public void L_MergeLoop_Func_2_Action_Func_2_Int32_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.L_MergeLoop
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.L_MergeLoop) + "() => Func`2<Action`1<T1>, Func`3<Int32, T1, Boolean>>")]
        public void L_MergeLoop_Func_2_Action_1_T1_Func_3_Int32_T1_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.L_MergeLoop
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.L_MergeLoop) + "() => Func`2<Action`2<T1, T2>, Func`4<Int32, T1, T2, Boolean>>")]
        public void L_MergeLoop_Func_2_Action_2_T1_T2_Func_4_Int32_T1_T2_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.L_MergeLoop
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.L_MergeLoop) + "() => Func`2<Action`3<T1, T2, T3>, Func`5<Int32, T1, T2, T3, Boolean>>")]
        public void L_MergeLoop_Func_2_Action_3_T1_T2_T3_Func_5_Int32_T1_T2_T3_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.L_MergeLoop
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.L_To) + "() => Func`4<Int32, Int32, Action, Action>")]
        public void L_To()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.L_To
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.L_ToI) + "() => Func`4<Int32, Int32, Action`1<Int32>, Action>")]
        public void L_ToI()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.L_ToI
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Loop) + "." + nameof(L.Loop.L_For) + "() => Func`4<Int32, Int32, Func`2<Int32, Boolean>, Action>")]
        public void L_For()
            {
            // TODO: Implement method test LCore.Extensions.L.Loop.L_For
            }

        }
    }