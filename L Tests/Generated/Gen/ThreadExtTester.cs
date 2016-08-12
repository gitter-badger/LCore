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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt))]
    public partial class ThreadExtTester : XUnitOutputTester, IDisposable
        {
        public ThreadExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.Async) + "(Action) => Action")]
        public void Async_Action_Action()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.Async
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.Async) + "(Action`1<T>) => Action`1<T>")]
        public void Async_Action_1_T_Action_1_T()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.Async
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.Async) + "(Action, ThreadPriority) => Action")]
        public void Async_Action_ThreadPriority_Action()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.Async
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.Async) + "(Action`1<T>, ThreadPriority) => Action`1<T>")]
        public void Async_Action_1_T_ThreadPriority_Action_1_T()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.Async
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.Async) + "(Action, TimeSpan, ThreadPriority) => Action")]
        public void Async_Action_TimeSpan_ThreadPriority_Action()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.Async
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.Async) + "(Action`1<T>, TimeSpan, ThreadPriority) => Action`1<T>")]
        public void Async_Action_1_T_TimeSpan_ThreadPriority_Action_1_T()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.Async
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.Async) + "(Action, Int32, ThreadPriority) => Action")]
        public void Async_Action_Int32_ThreadPriority_Action()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.Async
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.Async) + "(Action`1<T>, Int32, ThreadPriority) => Action`1<T>")]
        public void Async_Action_1_T_Int32_ThreadPriority_Action_1_T()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.Async
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.Async) + "(Action, UInt32, ThreadPriority) => Action")]
        public void Async_Action_UInt32_ThreadPriority_Action()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.Async
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.Async) + "(Action`1<T>, UInt32, ThreadPriority) => Action`1<T>")]
        public void Async_Action_1_T_UInt32_ThreadPriority_Action_1_T()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.Async
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.Async) + "(Action, Int64, ThreadPriority) => Action")]
        public void Async_Action_Int64_ThreadPriority_Action()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.Async
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.Async) + "(Action`1<T>, Int64, ThreadPriority) => Action`1<T>")]
        public void Async_Action_1_T_Int64_ThreadPriority_Action_1_T()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.Async
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.Async) + "(Action, UInt64, ThreadPriority) => Action")]
        public void Async_Action_UInt64_ThreadPriority_Action()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.Async
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.Async) + "(Action`1<T>, UInt64, ThreadPriority) => Action`1<T>")]
        public void Async_Action_1_T_UInt64_ThreadPriority_Action_1_T()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.Async
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.AsyncResult) + "(Func`1<U>, Action`1<U>) => Action")]
        public void AsyncResult_Func_1_U_Action_1_U_Action()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.AsyncResult
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.AsyncResult) + "(Func`2<T1, U>, Action`1<U>) => Action`1<T1>")]
        public void AsyncResult_Func_2_T1_U_Action_1_U_Action_1_T1()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.AsyncResult
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.AsyncResult) + "(Func`1<U>, Action`1<U>, ThreadPriority) => Action")]
        public void AsyncResult_Func_1_U_Action_1_U_ThreadPriority_Action()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.AsyncResult
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.AsyncResult) + "(Func`2<T1, U>, Action`1<U>, ThreadPriority) => Action`1<T1>")]
        public void AsyncResult_Func_2_T1_U_Action_1_U_ThreadPriority_Action_1_T1()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.AsyncResult
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.AsyncResult) + "(Func`1<U>, Action`1<U>, TimeSpan, ThreadPriority) => Action")]
        public void AsyncResult_Func_1_U_Action_1_U_TimeSpan_ThreadPriority_Action()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.AsyncResult
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.AsyncResult) + "(Func`2<T1, U>, Action`1<U>, TimeSpan, ThreadPriority) => Action`1<T1>")]
        public void AsyncResult_Func_2_T1_U_Action_1_U_TimeSpan_ThreadPriority_Action_1_T1()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.AsyncResult
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.AsyncResult) + "(Func`1<U>, Action`1<U>, Int32, ThreadPriority) => Action")]
        public void AsyncResult_Func_1_U_Action_1_U_Int32_ThreadPriority_Action()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.AsyncResult
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.AsyncResult) + "(Func`2<T1, U>, Action`1<U>, Int32, ThreadPriority) => Action`1<T1>")]
        public void AsyncResult_Func_2_T1_U_Action_1_U_Int32_ThreadPriority_Action_1_T1()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.AsyncResult
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.AsyncResult) + "(Func`1<U>, Action`1<U>, UInt32, ThreadPriority) => Action")]
        public void AsyncResult_Func_1_U_Action_1_U_UInt32_ThreadPriority_Action()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.AsyncResult
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.AsyncResult) + "(Func`2<T1, U>, Action`1<U>, UInt32, ThreadPriority) => Action`1<T1>")]
        public void AsyncResult_Func_2_T1_U_Action_1_U_UInt32_ThreadPriority_Action_1_T1()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.AsyncResult
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.AsyncResult) + "(Func`1<U>, Action`1<U>, Int64, ThreadPriority) => Action")]
        public void AsyncResult_Func_1_U_Action_1_U_Int64_ThreadPriority_Action()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.AsyncResult
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.AsyncResult) + "(Func`2<T1, U>, Action`1<U>, Int64, ThreadPriority) => Action`1<T1>")]
        public void AsyncResult_Func_2_T1_U_Action_1_U_Int64_ThreadPriority_Action_1_T1()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.AsyncResult
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.AsyncResult) + "(Func`1<U>, Action`1<U>, UInt64, ThreadPriority) => Action")]
        public void AsyncResult_Func_1_U_Action_1_U_UInt64_ThreadPriority_Action()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.AsyncResult
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.AsyncResult) + "(Func`2<T1, U>, Action`1<U>, UInt64, ThreadPriority) => Action`1<T1>")]
        public void AsyncResult_Func_2_T1_U_Action_1_U_UInt64_ThreadPriority_Action_1_T1()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.AsyncResult
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.CountExecutions) + "(Action, UInt32) => UInt32")]
        public void CountExecutions()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.CountExecutions
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.Profile) + "(Action, UInt32) => TimeSpan")]
        public void Profile_Action_UInt32_TimeSpan()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.Profile
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.Profile) + "(Func`1<U>, UInt32) => MethodProfileData`1<U>")]
        public void Profile_Func_1_U_UInt32_MethodProfileData_1_U()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.Profile
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.Profile) + "(Action, String) => Action")]
        public void Profile_Action_String_Action()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.Profile
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.Profile) + "(Action`1<T1>, String) => Action`1<T1>")]
        public void Profile_Action_1_T1_String_Action_1_T1()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.Profile
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.Profile) + "(Func`1<U>, String) => Func`1<U>")]
        public void Profile_Func_1_U_String_Func_1_U()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.Profile
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." + nameof(ThreadExt.Profile) + "(Func`2<T1, U>, String) => Func`2<T1, U>")]
        public void Profile_Func_2_T1_U_String_Func_2_T1_U()
            {
            // TODO: Implement method test LCore.Extensions.ThreadExt.Profile
            }

        }
    }