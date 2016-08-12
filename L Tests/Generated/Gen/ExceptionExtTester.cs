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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt))]
    public partial class ExceptionExtTester : XUnitOutputTester, IDisposable
        {
        public ExceptionExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Fail) + "(Action`3<T1, T2, T3>) => Action`3<T1, T2, T3>")]
        public void Fail_Action_3_T1_T2_T3_Action_3_T1_T2_T3()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Fail
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Fail) + "(Action`4<T1, T2, T3, T4>) => Action`4<T1, T2, T3, T4>")]
        public void Fail_Action_4_T1_T2_T3_T4_Action_4_T1_T2_T3_T4()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Fail
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Fail) + "(Func`1<U>) => Func`1<U>")]
        public void Fail_Func_1_U_Func_1_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Fail
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Fail) + "(Func`2<T, U>) => Func`2<T, U>")]
        public void Fail_Func_2_T_U_Func_2_T_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Fail
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Fail) + "(Func`3<T1, T2, U>) => Func`3<T1, T2, U>")]
        public void Fail_Func_3_T1_T2_U_Func_3_T1_T2_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Fail
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Fail) + "(Func`4<T1, T2, T3, U>) => Func`4<T1, T2, T3, U>")]
        public void Fail_Func_4_T1_T2_T3_U_Func_4_T1_T2_T3_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Fail
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Fail) + "(Func`5<T1, T2, T3, T4, U>) => Func`5<T1, T2, T3, T4, U>")]
        public void Fail_Func_5_T1_T2_T3_T4_U_Func_5_T1_T2_T3_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Fail
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Throw) + "(Action, String) => Action")]
        public void Throw_Action_String_Action()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Throw
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Throw) + "(Action`1<T>, String) => Action`1<T>")]
        public void Throw_Action_1_T_String_Action_1_T()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Throw
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Throw) + "(Action`2<T1, T2>, String) => Action`2<T1, T2>")]
        public void Throw_Action_2_T1_T2_String_Action_2_T1_T2()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Throw
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Throw) + "(Action`3<T1, T2, T3>, String) => Action`3<T1, T2, T3>")]
        public void Throw_Action_3_T1_T2_T3_String_Action_3_T1_T2_T3()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Throw
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Throw) + "(Action`4<T1, T2, T3, T4>, String) => Action`4<T1, T2, T3, T4>")]
        public void Throw_Action_4_T1_T2_T3_T4_String_Action_4_T1_T2_T3_T4()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Throw
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Throw) + "(Func`1<U>, String) => Func`1<U>")]
        public void Throw_Func_1_U_String_Func_1_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Throw
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Throw) + "(Func`2<T, U>, String) => Func`2<T, U>")]
        public void Throw_Func_2_T_U_String_Func_2_T_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Throw
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Throw) + "(Func`3<T1, T2, U>, String) => Func`3<T1, T2, U>")]
        public void Throw_Func_3_T1_T2_U_String_Func_3_T1_T2_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Throw
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Throw) + "(Func`4<T1, T2, T3, U>, String) => Func`4<T1, T2, T3, U>")]
        public void Throw_Func_4_T1_T2_T3_U_String_Func_4_T1_T2_T3_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Throw
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Throw) + "(Func`5<T1, T2, T3, T4, U>, String) => Func`5<T1, T2, T3, T4, U>")]
        public void Throw_Func_5_T1_T2_T3_T4_U_String_Func_5_T1_T2_T3_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Throw
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Report) + "(Action, String, E) => Action")]
        public void Report_Action_String_E_Action()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Report
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Report) + "(Action`1<T>, String, E) => Action`1<T>")]
        public void Report_Action_1_T_String_E_Action_1_T()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Report
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Report) + "(Action`2<T1, T2>, String, E) => Action`2<T1, T2>")]
        public void Report_Action_2_T1_T2_String_E_Action_2_T1_T2()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Report
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Report) + "(Action`3<T1, T2, T3>, String, E) => Action`3<T1, T2, T3>")]
        public void Report_Action_3_T1_T2_T3_String_E_Action_3_T1_T2_T3()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Report
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Report) + "(Action`4<T1, T2, T3, T4>, String, E) => Action`4<T1, T2, T3, T4>")]
        public void Report_Action_4_T1_T2_T3_T4_String_E_Action_4_T1_T2_T3_T4()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Report
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Report) + "(Func`1<U>, String, E) => Func`1<U>")]
        public void Report_Func_1_U_String_E_Func_1_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Report
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Report) + "(Func`2<T, U>, String, E) => Func`2<T, U>")]
        public void Report_Func_2_T_U_String_E_Func_2_T_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Report
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Report) + "(Func`3<T1, T2, U>, String, E) => Func`3<T1, T2, U>")]
        public void Report_Func_3_T1_T2_U_String_E_Func_3_T1_T2_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Report
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Report) + "(Func`4<T1, T2, T3, U>, String, E) => Func`4<T1, T2, T3, U>")]
        public void Report_Func_4_T1_T2_T3_U_String_E_Func_4_T1_T2_T3_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Report
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Report) + "(Func`5<T1, T2, T3, T4, U>, String, E) => Func`5<T1, T2, T3, T4, U>")]
        public void Report_Func_5_T1_T2_T3_T4_U_String_E_Func_5_T1_T2_T3_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Report
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Report) + "(Action, E) => Action")]
        public void Report_Action_E_Action()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Report
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Report) + "(Action`1<T>, E) => Action`1<T>")]
        public void Report_Action_1_T_E_Action_1_T()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Report
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Report) + "(Action`2<T1, T2>, E) => Action`2<T1, T2>")]
        public void Report_Action_2_T1_T2_E_Action_2_T1_T2()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Report
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Report) + "(Action`3<T1, T2, T3>, E) => Action`3<T1, T2, T3>")]
        public void Report_Action_3_T1_T2_T3_E_Action_3_T1_T2_T3()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Report
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Report) + "(Action`4<T1, T2, T3, T4>, E) => Action`4<T1, T2, T3, T4>")]
        public void Report_Action_4_T1_T2_T3_T4_E_Action_4_T1_T2_T3_T4()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Report
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Report) + "(Func`1<U>, E) => Func`1<U>")]
        public void Report_Func_1_U_E_Func_1_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Report
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Report) + "(Func`2<T, U>, E) => Func`2<T, U>")]
        public void Report_Func_2_T_U_E_Func_2_T_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Report
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Report) + "(Func`3<T1, T2, U>, E) => Func`3<T1, T2, U>")]
        public void Report_Func_3_T1_T2_U_E_Func_3_T1_T2_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Report
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Report) + "(Func`4<T1, T2, T3, U>, E) => Func`4<T1, T2, T3, U>")]
        public void Report_Func_4_T1_T2_T3_U_E_Func_4_T1_T2_T3_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Report
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Report) + "(Func`5<T1, T2, T3, T4, U>, E) => Func`5<T1, T2, T3, T4, U>")]
        public void Report_Func_5_T1_T2_T3_T4_U_E_Func_5_T1_T2_T3_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Report
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Handle) + "(Action) => Action")]
        public void Handle_Action_Action()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Handle
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Handle) + "(Action`1<T1>) => Action`1<T1>")]
        public void Handle_Action_1_T1_Action_1_T1()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Handle
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Handle) + "(Action`2<T1, T2>) => Action`2<T1, T2>")]
        public void Handle_Action_2_T1_T2_Action_2_T1_T2()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Handle
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Handle) + "(Action`3<T1, T2, T3>) => Action`3<T1, T2, T3>")]
        public void Handle_Action_3_T1_T2_T3_Action_3_T1_T2_T3()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Handle
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Handle) + "(Action`4<T1, T2, T3, T4>) => Action`4<T1, T2, T3, T4>")]
        public void Handle_Action_4_T1_T2_T3_T4_Action_4_T1_T2_T3_T4()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Handle
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Handle) + "(Func`1<U>) => Func`1<U>")]
        public void Handle_Func_1_U_Func_1_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Handle
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Handle) + "(Func`2<T1, U>) => Func`2<T1, U>")]
        public void Handle_Func_2_T1_U_Func_2_T1_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Handle
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Handle) + "(Func`3<T1, T2, U>) => Func`3<T1, T2, U>")]
        public void Handle_Func_3_T1_T2_U_Func_3_T1_T2_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Handle
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Handle) + "(Func`4<T1, T2, T3, U>) => Func`4<T1, T2, T3, U>")]
        public void Handle_Func_4_T1_T2_T3_U_Func_4_T1_T2_T3_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Handle
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Handle) + "(Func`5<T1, T2, T3, T4, U>) => Func`5<T1, T2, T3, T4, U>")]
        public void Handle_Func_5_T1_T2_T3_T4_U_Func_5_T1_T2_T3_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Handle
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Try) + "(Action) => Func`1<Boolean>")]
        public void Try_Action_Func_1_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Try
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Try) + "(Action`1<T1>) => Func`2<T1, Boolean>")]
        public void Try_Action_1_T1_Func_2_T1_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Try
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Try) + "(Action`2<T1, T2>) => Func`3<T1, T2, Boolean>")]
        public void Try_Action_2_T1_T2_Func_3_T1_T2_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Try
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Try) + "(Action`3<T1, T2, T3>) => Func`4<T1, T2, T3, Boolean>")]
        public void Try_Action_3_T1_T2_T3_Func_4_T1_T2_T3_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Try
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Try) + "(Action`4<T1, T2, T3, T4>) => Func`5<T1, T2, T3, T4, Boolean>")]
        public void Try_Action_4_T1_T2_T3_T4_Func_5_T1_T2_T3_T4_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Try
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Try) + "(Func`1<U>) => Func`1<U>")]
        public void Try_Func_1_U_Func_1_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Try
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Try) + "(Func`2<T1, U>) => Func`2<T1, U>")]
        public void Try_Func_2_T1_U_Func_2_T1_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Try
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Try) + "(Func`3<T1, T2, U>) => Func`3<T1, T2, U>")]
        public void Try_Func_3_T1_T2_U_Func_3_T1_T2_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Try
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Try) + "(Func`4<T1, T2, T3, U>) => Func`4<T1, T2, T3, U>")]
        public void Try_Func_4_T1_T2_T3_U_Func_4_T1_T2_T3_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Try
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Try) + "(Func`5<T1, T2, T3, T4, U>) => Func`5<T1, T2, T3, T4, U>")]
        public void Try_Func_5_T1_T2_T3_T4_U_Func_5_T1_T2_T3_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Try
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Action, Action`1<Exception>) => Action")]
        public void Catch_Action_Action_1_Exception_Action()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Action`1<T1>, Action`1<Exception>) => Action`1<T1>")]
        public void Catch_Action_1_T1_Action_1_Exception_Action_1_T1()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Action`2<T1, T2>, Action`1<Exception>) => Action`2<T1, T2>")]
        public void Catch_Action_2_T1_T2_Action_1_Exception_Action_2_T1_T2()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Action`3<T1, T2, T3>, Action`1<Exception>) => Action`3<T1, T2, T3>")]
        public void Catch_Action_3_T1_T2_T3_Action_1_Exception_Action_3_T1_T2_T3()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Action`4<T1, T2, T3, T4>, Action`1<Exception>) => Action`4<T1, T2, T3, T4>")]
        public void Catch_Action_4_T1_T2_T3_T4_Action_1_Exception_Action_4_T1_T2_T3_T4()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Func`1<U>, Action`1<Exception>) => Func`1<U>")]
        public void Catch_Func_1_U_Action_1_Exception_Func_1_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Func`2<T1, U>, Action`1<Exception>) => Func`2<T1, U>")]
        public void Catch_Func_2_T1_U_Action_1_Exception_Func_2_T1_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Func`3<T1, T2, U>, Action`1<Exception>) => Func`3<T1, T2, U>")]
        public void Catch_Func_3_T1_T2_U_Action_1_Exception_Func_3_T1_T2_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Func`4<T1, T2, T3, U>, Action`1<Exception>) => Func`4<T1, T2, T3, U>")]
        public void Catch_Func_4_T1_T2_T3_U_Action_1_Exception_Func_4_T1_T2_T3_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Func`5<T1, T2, T3, T4, U>, Action`1<Exception>) => Func`5<T1, T2, T3, T4, U>")]
        public void Catch_Func_5_T1_T2_T3_T4_U_Action_1_Exception_Func_5_T1_T2_T3_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Action, Action`1<E>) => Action")]
        public void Catch_Action_Action_1_E_Action()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Action`1<T1>, Action`1<E>) => Action`1<T1>")]
        public void Catch_Action_1_T1_Action_1_E_Action_1_T1()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Action`2<T1, T2>, Action`1<E>) => Action`2<T1, T2>")]
        public void Catch_Action_2_T1_T2_Action_1_E_Action_2_T1_T2()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Action`3<T1, T2, T3>, Action`1<E>) => Action`3<T1, T2, T3>")]
        public void Catch_Action_3_T1_T2_T3_Action_1_E_Action_3_T1_T2_T3()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Action`4<T1, T2, T3, T4>, Action`1<E>) => Action`4<T1, T2, T3, T4>")]
        public void Catch_Action_4_T1_T2_T3_T4_Action_1_E_Action_4_T1_T2_T3_T4()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Func`1<U>, Action`1<E>) => Func`1<U>")]
        public void Catch_Func_1_U_Action_1_E_Func_1_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Func`2<T1, U>, Action`1<E>) => Func`2<T1, U>")]
        public void Catch_Func_2_T1_U_Action_1_E_Func_2_T1_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Func`3<T1, T2, U>, Action`1<E>) => Func`3<T1, T2, U>")]
        public void Catch_Func_3_T1_T2_U_Action_1_E_Func_3_T1_T2_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Func`4<T1, T2, T3, U>, Action`1<E>) => Func`4<T1, T2, T3, U>")]
        public void Catch_Func_4_T1_T2_T3_U_Action_1_E_Func_4_T1_T2_T3_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Func`5<T1, T2, T3, T4, U>, Action`1<E>) => Func`5<T1, T2, T3, T4, U>")]
        public void Catch_Func_5_T1_T2_T3_T4_U_Action_1_E_Func_5_T1_T2_T3_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Func`1<U>, Func`2<E, U>) => Func`1<U>")]
        public void Catch_Func_1_U_Func_2_E_U_Func_1_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Func`2<T1, U>, Func`2<E, U>) => Func`2<T1, U>")]
        public void Catch_Func_2_T1_U_Func_2_E_U_Func_2_T1_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Func`3<T1, T2, U>, Func`2<E, U>) => Func`3<T1, T2, U>")]
        public void Catch_Func_3_T1_T2_U_Func_2_E_U_Func_3_T1_T2_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Func`4<T1, T2, T3, U>, Func`2<E, U>) => Func`4<T1, T2, T3, U>")]
        public void Catch_Func_4_T1_T2_T3_U_Func_2_E_U_Func_4_T1_T2_T3_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Func`5<T1, T2, T3, T4, U>, Func`2<E, U>) => Func`5<T1, T2, T3, T4, U>")]
        public void Catch_Func_5_T1_T2_T3_T4_U_Func_2_E_U_Func_5_T1_T2_T3_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Action) => Action")]
        public void Catch_Action_Action()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Action`1<T1>) => Action`1<T1>")]
        public void Catch_Action_1_T1_Action_1_T1()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Action`2<T1, T2>) => Action`2<T1, T2>")]
        public void Catch_Action_2_T1_T2_Action_2_T1_T2()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Action`3<T1, T2, T3>) => Action`3<T1, T2, T3>")]
        public void Catch_Action_3_T1_T2_T3_Action_3_T1_T2_T3()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Action`4<T1, T2, T3, T4>) => Action`4<T1, T2, T3, T4>")]
        public void Catch_Action_4_T1_T2_T3_T4_Action_4_T1_T2_T3_T4()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Func`1<U>) => Func`1<U>")]
        public void Catch_Func_1_U_Func_1_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Func`2<T1, U>) => Func`2<T1, U>")]
        public void Catch_Func_2_T1_U_Func_2_T1_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Func`3<T1, T2, U>) => Func`3<T1, T2, U>")]
        public void Catch_Func_3_T1_T2_U_Func_3_T1_T2_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Func`4<T1, T2, T3, U>) => Func`4<T1, T2, T3, U>")]
        public void Catch_Func_4_T1_T2_T3_U_Func_4_T1_T2_T3_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Catch) + "(Func`5<T1, T2, T3, T4, U>) => Func`5<T1, T2, T3, T4, U>")]
        public void Catch_Func_5_T1_T2_T3_T4_U_Func_5_T1_T2_T3_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Catch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Retry) + "(Action, Int32) => Action")]
        public void Retry_Action_Int32_Action()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Retry
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Retry) + "(Action`1<T>, Int32) => Action`1<T>")]
        public void Retry_Action_1_T_Int32_Action_1_T()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Retry
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Retry) + "(Action`2<T1, T2>, Int32) => Action`2<T1, T2>")]
        public void Retry_Action_2_T1_T2_Int32_Action_2_T1_T2()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Retry
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Retry) + "(Action`3<T1, T2, T3>, Int32) => Action`3<T1, T2, T3>")]
        public void Retry_Action_3_T1_T2_T3_Int32_Action_3_T1_T2_T3()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Retry
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Retry) + "(Action`4<T1, T2, T3, T4>, Int32) => Action`4<T1, T2, T3, T4>")]
        public void Retry_Action_4_T1_T2_T3_T4_Int32_Action_4_T1_T2_T3_T4()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Retry
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Retry) + "(Func`1<U>, Int32) => Func`1<U>")]
        public void Retry_Func_1_U_Int32_Func_1_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Retry
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Retry) + "(Func`2<T1, U>, Int32) => Func`2<T1, U>")]
        public void Retry_Func_2_T1_U_Int32_Func_2_T1_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Retry
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Retry) + "(Func`3<T1, T2, U>, Int32) => Func`3<T1, T2, U>")]
        public void Retry_Func_3_T1_T2_U_Int32_Func_3_T1_T2_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Retry
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Retry) + "(Func`4<T1, T2, T3, U>, Int32) => Func`4<T1, T2, T3, U>")]
        public void Retry_Func_4_T1_T2_T3_U_Int32_Func_4_T1_T2_T3_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Retry
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Retry) + "(Func`5<T1, T2, T3, T4, U>, Int32) => Func`5<T1, T2, T3, T4, U>")]
        public void Retry_Func_5_T1_T2_T3_T4_U_Int32_Func_5_T1_T2_T3_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Retry
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Debug) + "(Action`1<T1>) => Action`1<T1>")]
        public void Debug_Action_1_T1_Action_1_T1()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Debug
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Debug) + "(Action`2<T1, T2>) => Action`2<T1, T2>")]
        public void Debug_Action_2_T1_T2_Action_2_T1_T2()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Debug
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Debug) + "(Action`3<T1, T2, T3>) => Action`3<T1, T2, T3>")]
        public void Debug_Action_3_T1_T2_T3_Action_3_T1_T2_T3()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Debug
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Debug) + "(Action`4<T1, T2, T3, T4>) => Action`4<T1, T2, T3, T4>")]
        public void Debug_Action_4_T1_T2_T3_T4_Action_4_T1_T2_T3_T4()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Debug
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Debug) + "(Func`2<T1, U>) => Func`2<T1, U>")]
        public void Debug_Func_2_T1_U_Func_2_T1_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Debug
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Debug) + "(Func`3<T1, T2, U>) => Func`3<T1, T2, U>")]
        public void Debug_Func_3_T1_T2_U_Func_3_T1_T2_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Debug
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Debug) + "(Func`4<T1, T2, T3, U>) => Func`4<T1, T2, T3, U>")]
        public void Debug_Func_4_T1_T2_T3_U_Func_4_T1_T2_T3_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Debug
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Debug) + "(Func`5<T1, T2, T3, T4, U>) => Func`5<T1, T2, T3, T4, U>")]
        public void Debug_Func_5_T1_T2_T3_T4_U_Func_5_T1_T2_T3_T4_U()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Debug
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Fail) + "(Action) => Action")]
        public void Fail_Action_Action()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Fail
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Fail) + "(Action`1<T>) => Action`1<T>")]
        public void Fail_Action_1_T_Action_1_T()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Fail
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." + nameof(ExceptionExt.Fail) + "(Action`2<T1, T2>) => Action`2<T1, T2>")]
        public void Fail_Action_2_T1_T2_Action_2_T1_T2()
            {
            // TODO: Implement method test LCore.Extensions.ExceptionExt.Fail
            }

        }
    }