using System;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable PartialTypeWithSinglePart

// ReSharper disable RedundantCast

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt))]
    public partial class LogicExtTester : XUnitOutputTester, IDisposable
        {
        private static readonly string _TestString = Guid.NewGuid().ToString();


        public LogicExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Cast) + "(Action`1<T1>) => Action`1<U1>")]
        public void Test_Cast_Action_0()
            {
            bool Result = false;
            Action<object> Action = o =>
                {
                    o.Should().Be(_TestString);
                    Result = true;
                };
            Action<object> ActionFail = o => { throw new Exception(); };

            Action<string> Action2 = Action.Cast<object, string>();

            Action2(_TestString);

            Result.ShouldBeTrue();

            // Exceptions are passed.
            ActionFail.Cast<object, string>().ShouldFail(_TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Cast) + "(Action`2<T1, T2>) => Action`2<U1, U2>")]
        public void Test_Cast_Action_1()
            {
            bool Result = false;
            Action<object, object> Action = (o1, o2) =>
                {
                    o1.Should().Be(_TestString);
                    o2.Should().Be(_TestString);
                    Result = true;
                };
            Action<object, object> ActionFail = (o1, o2) => { throw new Exception(); };


            Action<string, string> Action2 = Action.Cast<object, object, string, string>();

            Action2(_TestString, _TestString);

            Result.ShouldBeTrue();

            // Exceptions are passed.
            ActionFail.Cast<object, object, string, string>().ShouldFail(_TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Cast) + "(Action`3<T1, T2, T3>) => Action`3<U1, U2, U3>")]
        public void Test_Cast_Action_2()
            {
            bool Result = false;
            Action<object, object, object> Action = (o1, o2, o3) =>
                {
                    o1.Should().Be(_TestString);
                    o2.Should().Be(_TestString);
                    o3.Should().Be(_TestString);
                    Result = true;
                };
            Action<object, object, object> ActionFail = (o1, o2, o3) => { throw new Exception(); };


            Action<string, string, string> Action2 = Action.Cast<object, object, object, string, string, string>();

            Action2(_TestString, _TestString, _TestString);

            Result.ShouldBeTrue();

            // Exceptions are passed.
            ActionFail.Cast<object, object, object, string, string, string>().ShouldFail(_TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Cast) + "(Action`4<T1, T2, T3, T4>) => Action`4<U1, U2, U3, U4>")]
        public void Test_Cast_Action_3()
            {
            bool Result = false;
            Action<object, object, object, object> Action = (o1, o2, o3, o4) =>
                {
                    o1.Should().Be(_TestString);
                    o2.Should().Be(_TestString);
                    o3.Should().Be(_TestString);
                    o4.Should().Be(_TestString);
                    Result = true;
                };
            Action<object, object, object, object> ActionFail = (o1, o2, o3, o4) => { throw new Exception(); };


            Action<string, string, string, string> Action2 = Action.Cast<object, object, object, object, string, string, string, string>();

            Action2(_TestString, _TestString, _TestString, _TestString);

            Result.ShouldBeTrue();

            // Exceptions are passed.
            ActionFail.Cast<object, object, object, object, string, string, string, string>()
                .ShouldFail(_TestString, _TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Cast) + "(Func`1<U1>) => Func`1<U2>")]
        public void Test_Cast_Func_0()
            {
            Func<object> Func = () => true;
            Func<object> FuncFail = () => { throw new Exception(); };

            Func<bool> Func2 = Func.Cast<object, bool>();

            Func2().ShouldBeTrue();

            // Exceptions are passed.
            FuncFail.Cast<object, bool>().ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Cast) + "(Func`2<T1, U1>) => Func`2<T2, U2>")]
        public void Test_Cast_Func_1()
            {
            Func<object, bool> Func = o =>
                {
                    o.Should().Be(_TestString);
                    return true;
                };
            Func<object, bool> FuncFail = o => { throw new Exception(); };

            Func<string, bool> Func2 = Func.Cast<object, bool, string, bool>();

            Func2(_TestString).ShouldBeTrue();

            // Exceptions are passed.
            FuncFail.Cast<object, bool, string, bool>().ShouldFail(_TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Cast) + "(Func`3<T1, T2, U1>) => Func`3<T3, T4, U2>")]
        public void Test_Cast_Func_2()
            {
            Func<object, object, bool> Func = (o1, o2) =>
                {
                    o1.Should().Be(_TestString);
                    o2.Should().Be(_TestString);
                    return true;
                };
            Func<object, object, bool> FuncFail = (o1, o2) => { throw new Exception(); };

            Func<string, string, bool> Func2 = Func.Cast<object, object, bool, string, string, bool>();

            Func2(_TestString, _TestString).ShouldBeTrue();

            // Exceptions are passed.
            FuncFail.Cast<object, object, bool, string, string, bool>().ShouldFail(_TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Cast) + "(Func`4<T1, T2, T3, U1>) => Func`4<T4, T5, T6, U2>")]
        public void Test_Cast_Func_3()
            {
            Func<object, object, object, bool> Func = (o1, o2, o3) =>
                {
                    o1.Should().Be(_TestString);
                    o2.Should().Be(_TestString);
                    o3.Should().Be(_TestString);
                    return true;
                };
            Func<object, object, object, bool> FuncFail = (o1, o2, o3) => { throw new Exception(); };

            Func<string, string, string, bool> Func2 = Func.Cast<object, object, object, bool, string, string, string, bool>();

            Func2(_TestString, _TestString, _TestString).ShouldBeTrue();

            // Exceptions are passed.
            FuncFail.Cast<object, object, object, bool, string, string, string, bool>().ShouldFail(_TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Cast) + "(Func`5<T1, T2, T3, T4, U1>) => Func`5<T5, T6, T7, T8, U2>")]
        public void Test_Cast_Func_4()
            {
            Func<object, object, object, object, bool> Func = (o1, o2, o3, o4) =>
                {
                    o1.Should().Be(_TestString);
                    o2.Should().Be(_TestString);
                    o3.Should().Be(_TestString);
                    o4.Should().Be(_TestString);
                    return true;
                };
            Func<object, object, object, object, bool> FuncFail = (o1, o2, o3, o4) => { throw new Exception(); };

            Func<string, string, string, string, bool> Func2 =
                Func.Cast<object, object, object, object, bool, string, string, string, string, bool>();

            Func2(_TestString, _TestString, _TestString, _TestString).ShouldBeTrue();

            // Exceptions are passed.
            FuncFail.Cast<object, object, object, object, bool, string, string, string, string, bool>()
                .ShouldFail(_TestString, _TestString, _TestString, _TestString);
            }


        #region Surround

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action`1<U>, Func`1<U>) => Action")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action`1<U>, Func`2<T1, U>) => Action`1<T1>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action`1<U>, Func`3<T1, T2, U>) => Action`2<T1, T2>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action`1<U>, Func`4<T1, T2, T3, U>) => Action`3<T1, T2, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action`1<U>, Func`5<T1, T2, T3, T4, U>) => Action`4<T1, T2, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action`2<T1, T2>, Func`1<T1>) => Action`1<T2>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Action`2<T1, T2>, Func`1<T2>) => Action`1<T1>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action`2<T1, T2>, Func`2<T3, T1>) => Action`2<T2, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Action`2<T1, T2>, Func`2<T3, T2>) => Action`2<T1, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action`2<T1, T2>, Func`3<T3, T4, T1>) => Action`3<T2, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Action`2<T1, T2>, Func`3<T3, T4, T2>) => Action`3<T1, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action`2<T1, T2>, Func`4<T3, T4, T5, T1>) => Action`4<T2, T3, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Action`2<T1, T2>, Func`4<T3, T4, T5, T2>) => Action`4<T1, T3, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action`3<T1, T2, T3>, Func`1<T1>) => Action`2<T2, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Action`3<T1, T2, T3>, Func`1<T2>) => Action`2<T1, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround3) + "(Action`3<T1, T2, T3>, Func`1<T3>) => Action`2<T1, T2>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action`3<T1, T2, T3>, Func`2<T4, T1>) => Action`3<T2, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Action`3<T1, T2, T3>, Func`2<T4, T2>) => Action`3<T1, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround3) + "(Action`3<T1, T2, T3>, Func`2<T4, T3>) => Action`3<T1, T2, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action`3<T1, T2, T3>, Func`3<T4, T5, T1>) => Action`4<T2, T3, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Action`3<T1, T2, T3>, Func`3<T4, T5, T2>) => Action`4<T1, T3, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround3) + "(Action`3<T1, T2, T3>, Func`3<T4, T5, T3>) => Action`4<T1, T2, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action`4<T1, T2, T3, T4>, Func`1<T1>) => Action`3<T2, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Action`4<T1, T2, T3, T4>, Func`1<T2>) => Action`3<T1, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround3) + "(Action`4<T1, T2, T3, T4>, Func`1<T3>) => Action`3<T1, T2, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround4) + "(Action`4<T1, T2, T3, T4>, Func`1<T4>) => Action`3<T1, T2, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action`4<T1, T2, T3, T4>, Func`2<T5, T1>) => Action`4<T2, T3, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Action`4<T1, T2, T3, T4>, Func`2<T5, T2>) => Action`4<T1, T3, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround3) + "(Action`4<T1, T2, T3, T4>, Func`2<T5, T3>) => Action`4<T1, T2, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround4) + "(Action`4<T1, T2, T3, T4>, Func`2<T5, T4>) => Action`4<T1, T2, T3, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func`2<T1, U>, Func`1<T1>) => Func`1<U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func`2<T2, U>, Func`2<T1, T2>) => Func`2<T1, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func`2<T3, U>, Func`3<T1, T2, T3>) => Func`3<T1, T2, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func`2<T4, U>, Func`4<T1, T2, T3, T4>) => Func`4<T1, T2, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func`2<T5, U>, Func`5<T1, T2, T3, T4, T5>) => Func`5<T1, T2, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func`3<T1, T2, U>, Func`1<T1>) => Func`2<T2, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Func`3<T1, T2, U>, Func`1<T2>) => Func`2<T1, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func`3<T1, T2, U>, Func`2<T3, T1>) => Func`3<T2, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Func`3<T1, T2, U>, Func`2<T3, T2>) => Func`3<T1, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func`3<T1, T2, U>, Func`3<T3, T4, T1>) => Func`4<T2, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Func`3<T1, T2, U>, Func`3<T3, T4, T2>) => Func`4<T1, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func`3<T1, T2, U>, Func`4<T3, T4, T5, T1>) => Func`5<T2, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Func`3<T1, T2, U>, Func`4<T3, T4, T5, T2>) => Func`5<T1, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func`4<T1, T2, T3, U>, Func`1<T1>) => Func`3<T2, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Func`4<T1, T2, T3, U>, Func`1<T2>) => Func`3<T1, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround3) + "(Func`4<T1, T2, T3, U>, Func`1<T3>) => Func`3<T1, T2, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func`4<T1, T2, T3, U>, Func`2<T4, T1>) => Func`4<T2, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Func`4<T1, T2, T3, U>, Func`2<T4, T2>) => Func`4<T1, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround3) + "(Func`4<T1, T2, T3, U>, Func`2<T4, T3>) => Func`4<T1, T2, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func`4<T1, T2, T3, U>, Func`3<T4, T5, T1>) => Func`5<T2, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Func`4<T1, T2, T3, U>, Func`3<T4, T5, T2>) => Func`5<T1, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround3) + "(Func`4<T1, T2, T3, U>, Func`3<T4, T5, T3>) => Func`5<T1, T2, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func`5<T1, T2, T3, T4, U>, Func`1<T1>) => Func`4<T2, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Func`5<T1, T2, T3, T4, U>, Func`1<T2>) => Func`4<T1, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround3) + "(Func`5<T1, T2, T3, T4, U>, Func`1<T3>) => Func`4<T1, T2, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround4) + "(Func`5<T1, T2, T3, T4, U>, Func`1<T4>) => Func`4<T1, T2, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func`5<T1, T2, T3, T4, U>, Func`2<T5, T1>) => Func`5<T2, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Func`5<T1, T2, T3, T4, U>, Func`2<T5, T2>) => Func`5<T1, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround3) + "(Func`5<T1, T2, T3, T4, U>, Func`2<T5, T3>) => Func`5<T1, T2, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround4) + "(Func`5<T1, T2, T3, T4, U>, Func`2<T5, T4>) => Func`5<T1, T2, T3, T5, U>")]

        public void Test_Surround_Action_0()
            {
            int Result = 0;

            var Test = new Action<int>(i => { Result = i; });
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Action<int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test.Surround(Test2)();
            Result.Should().Be(expected: 5);

            L.A(() => Test.Surround((Func<int>)null)).ShouldFail();
            L.A(() => ((Action<int>)null).Surround(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)()).ShouldFail();
            L.A(() => Test.Surround(BadTest2)()).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Action_1()
            {
            int Result = 0;

            var Test = new Action<int>(i => { Result = i; });
            var Test2 = new Func<int, int>(i => i + 5);
            var BadTest = new Action<int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test.Surround(Test2)(obj: 5);
            Result.Should().Be(expected: 10);

            L.A(() => Test.Surround((Func<int, int>)null)).ShouldFail();
            L.A(() => ((Action<int>)null).Surround(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(obj: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(obj: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Action_2()
            {
            int Result = 0;

            var Test = new Action<int>(i => { Result = i; });
            var Test2 = new Func<int, int, int>((i1, i2) => i1 * i2 + 5);
            var BadTest = new Action<int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int>((i1, i2) => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 2, arg2: 2);
            Result.Should().Be(expected: 9);

            L.A(() => Test.Surround((Func<int, int, int>)null)).ShouldFail();
            L.A(() => ((Action<int>)null).Surround(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Action_3()
            {
            int Result = 0;

            var Test = new Action<int>(i => { Result = i; });
            var Test2 = new Func<int, int, int, int>((i1, i2, i3) => i1 * i2 * i3 + 5);
            var BadTest = new Action<int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 2, arg2: 2, arg3: 2);
            Result.Should().Be(expected: 13);

            L.A(() => Test.Surround((Func<int, int, int, int>)null)).ShouldFail();
            L.A(() => ((Action<int>)null).Surround(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Action_4()
            {
            int Result = 0;

            var Test = new Action<int>(i => { Result = i; });
            var Test2 = new Func<int, int, int, int, int>((i1, i2, i3, i4) => i1 * i2 * i3 * i4 + 5);
            var BadTest = new Action<int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int, int, int>((i1, i2, i3, i4) => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 2, arg2: 2, arg3: 2, arg4: 2);
            Result.Should().Be(expected: 21);

            L.A(() => Test.Surround((Func<int, int, int, int, int>)null)).ShouldFail();
            L.A(() => ((Action<int>)null).Surround(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Action2_0()
            {
            int Result = 0;

            var Test = new Action<int, int>((i1, i2) => { Result = i1 + i2; });
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Action<int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test.Surround(Test2)(obj: 5);
            Result.Should().Be(expected: 10);

            // Reset 
            Result = 0;
            Test.Surround2(Test2)(obj: 8);
            Result.Should().Be(expected: 13);

            L.A(() => Test.Surround((Func<int>)null)).ShouldFail();
            L.A(() => Test.Surround2((Func<int>)null)).ShouldFail();
            L.A(() => ((Action<int, int>)null).Surround(Test2)).ShouldFail();
            L.A(() => ((Action<int, int>)null).Surround2(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(obj: 5)).ShouldFail();
            L.A(() => BadTest.Surround2(Test2)(obj: 5)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(obj: 5)).ShouldFail();
            L.A(() => Test.Surround2(BadTest2)(obj: 5)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Action2_1()
            {
            int Result = 0;

            var Test = new Action<int, int>((i1, i2) => { Result = i1 + i2; });
            var Test2 = new Func<int, int>(i => i + 5);
            var BadTest = new Action<int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 1, arg2: 5);
            Result.Should().Be(expected: 11);

            // Reset 
            Result = 0;
            Test.Surround2(Test2)(arg1: 3, arg2: 8);
            Result.Should().Be(expected: 16);

            L.A(() => Test.Surround((Func<int, int>)null)).ShouldFail();
            L.A(() => Test.Surround2((Func<int, int>)null)).ShouldFail();
            L.A(() => ((Action<int, int>)null).Surround(Test2)).ShouldFail();
            L.A(() => ((Action<int, int>)null).Surround2(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => BadTest.Surround2(Test2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test.Surround2(BadTest2)(arg1: 0, arg2: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Action2_2()
            {
            int Result = 0;

            var Test = new Action<int, int>((i1, i2) => { Result = i1 + i2; });
            var Test2 = new Func<int, int, int>((i1, i2) => i1 * i2 + 5);
            var BadTest = new Action<int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int>((i1, i2) => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 1, arg2: 5, arg3: 6);
            Result.Should().Be(expected: 36);

            // Reset 
            Result = 0;
            Test.Surround2(Test2)(arg1: 3, arg2: 8, arg3: 10);
            Result.Should().Be(expected: 88);

            L.A(() => Test.Surround((Func<int, int, int>)null)).ShouldFail();
            L.A(() => Test.Surround2((Func<int, int, int>)null)).ShouldFail();
            L.A(() => ((Action<int, int>)null).Surround(Test2)).ShouldFail();
            L.A(() => ((Action<int, int>)null).Surround2(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest.Surround2(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Surround2(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Action2_3()
            {
            int Result = 0;

            var Test = new Action<int, int>((i1, i2) => { Result = i1 + i2; });
            var Test2 = new Func<int, int, int, int>((i1, i2, i3) => i1 * i2 * i3 + 5);
            var BadTest = new Action<int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 1, arg2: 5, arg3: 6, arg4: 8);
            Result.Should().Be(expected: 246);

            // Reset 
            Result = 0;
            Test.Surround2(Test2)(arg1: 3, arg2: 8, arg3: 10, arg4: 12);
            Result.Should().Be(expected: 968);

            L.A(() => Test.Surround((Func<int, int, int, int>)null)).ShouldFail();
            L.A(() => Test.Surround2((Func<int, int, int, int>)null)).ShouldFail();
            L.A(() => ((Action<int, int>)null).Surround(Test2)).ShouldFail();
            L.A(() => ((Action<int, int>)null).Surround2(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest.Surround2(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Surround2(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Action3_0()
            {
            int Result = 0;

            var Test = new Action<int, int, int>((i1, i2, i3) => { Result = i1 + i2 + i3; });
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Action<int, int, int>((i1, i2, i3) => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 5, arg2: 8);
            Result.Should().Be(expected: 18);

            // Reset 
            Result = 0;
            Test.Surround2(Test2)(arg1: 8, arg2: 10);
            Result.Should().Be(expected: 23);

            // Reset 
            Result = 0;
            Test.Surround3(Test2)(arg1: 8, arg2: 10);
            Result.Should().Be(expected: 23);

            L.A(() => Test.Surround((Func<int>)null)).ShouldFail();
            L.A(() => Test.Surround2((Func<int>)null)).ShouldFail();
            L.A(() => Test.Surround3((Func<int>)null)).ShouldFail();
            L.A(() => ((Action<int, int, int>)null).Surround(Test2)).ShouldFail();
            L.A(() => ((Action<int, int, int>)null).Surround2(Test2)).ShouldFail();
            L.A(() => ((Action<int, int, int>)null).Surround3(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => BadTest.Surround2(Test2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => BadTest.Surround3(Test2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test.Surround2(BadTest2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test.Surround3(BadTest2)(arg1: 0, arg2: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Action3_1()
            {
            int Result = 0;

            var Test = new Action<int, int, int>((i1, i2, i3) => { Result = i1 + i2 + i3; });
            var Test2 = new Func<int, int>(i => i + 5);
            var BadTest = new Action<int, int, int>((i1, i2, i3) => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 5, arg2: 8, arg3: 10);
            Result.Should().Be(expected: 28);

            // Reset 
            Result = 0;
            Test.Surround2(Test2)(arg1: 8, arg2: 10, arg3: 12);
            Result.Should().Be(expected: 35);

            // Reset 
            Result = 0;
            Test.Surround3(Test2)(arg1: 8, arg2: 10, arg3: 13);
            Result.Should().Be(expected: 36);

            L.A(() => Test.Surround((Func<int, int>)null)).ShouldFail();
            L.A(() => Test.Surround2((Func<int, int>)null)).ShouldFail();
            L.A(() => Test.Surround3((Func<int, int>)null)).ShouldFail();
            L.A(() => ((Action<int, int, int>)null).Surround(Test2)).ShouldFail();
            L.A(() => ((Action<int, int, int>)null).Surround2(Test2)).ShouldFail();
            L.A(() => ((Action<int, int, int>)null).Surround3(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest.Surround2(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest.Surround3(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Surround2(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Surround3(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Action3_2()
            {
            int Result = 0;

            var Test = new Action<int, int, int>((i1, i2, i3) => { Result = i1 + i2 + i3; });
            var Test2 = new Func<int, int, int>((i1, i2) => i1 * i2 + 5);
            var BadTest = new Action<int, int, int>((i1, i2, i3) => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int>((i1, i2) => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 5, arg2: 8, arg3: 10, arg4: 14);
            Result.Should().Be(expected: 158);

            // Reset 
            Result = 0;
            Test.Surround2(Test2)(arg1: 8, arg2: 10, arg3: 12, arg4: 14);
            Result.Should().Be(expected: 191);

            // Reset 
            Result = 0;
            Test.Surround3(Test2)(arg1: 8, arg2: 10, arg3: 13, arg4: 15);
            Result.Should().Be(expected: 218);

            L.A(() => Test.Surround((Func<int, int, int>)null)).ShouldFail();
            L.A(() => Test.Surround2((Func<int, int, int>)null)).ShouldFail();
            L.A(() => Test.Surround3((Func<int, int, int>)null)).ShouldFail();
            L.A(() => ((Action<int, int, int>)null).Surround(Test2)).ShouldFail();
            L.A(() => ((Action<int, int, int>)null).Surround2(Test2)).ShouldFail();
            L.A(() => ((Action<int, int, int>)null).Surround3(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest.Surround2(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest.Surround3(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Surround2(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Surround3(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Action4_0()
            {
            int Result = 0;

            var Test = new Action<int, int, int, int>((i1, i2, i3, i4) => { Result = i1 + i2 + i3 + i4; });
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Action<int, int, int, int>((i1, i2, i3, i4) => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 5, arg2: 8, arg3: 10);
            Result.Should().Be(expected: 28);

            // Reset 
            Result = 0;
            Test.Surround2(Test2)(arg1: 8, arg2: 10, arg3: 12);
            Result.Should().Be(expected: 35);

            // Reset 
            Result = 0;
            Test.Surround3(Test2)(arg1: 8, arg2: 10, arg3: 14);
            Result.Should().Be(expected: 37);

            // Reset 
            Result = 0;
            Test.Surround4(Test2)(arg1: 8, arg2: 10, arg3: 15);
            Result.Should().Be(expected: 38);

            L.A(() => Test.Surround((Func<int>)null)).ShouldFail();
            L.A(() => Test.Surround2((Func<int>)null)).ShouldFail();
            L.A(() => Test.Surround3((Func<int>)null)).ShouldFail();
            L.A(() => Test.Surround4((Func<int>)null)).ShouldFail();
            L.A(() => ((Action<int, int, int, int>)null).Surround(Test2)).ShouldFail();
            L.A(() => ((Action<int, int, int, int>)null).Surround2(Test2)).ShouldFail();
            L.A(() => ((Action<int, int, int, int>)null).Surround3(Test2)).ShouldFail();
            L.A(() => ((Action<int, int, int, int>)null).Surround4(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest.Surround2(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest.Surround3(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest.Surround4(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Surround2(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Surround3(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Surround4(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Action4_1()
            {
            int Result = 0;

            var Test = new Action<int, int, int, int>((i1, i2, i3, i4) => { Result = i1 + i2 + i3 + i4; });
            var Test2 = new Func<int, int>(i => i * 5);
            var BadTest = new Action<int, int, int, int>((i1, i2, i3, i4) => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 5, arg2: 8, arg3: 10, arg4: 15);
            Result.Should().Be(expected: 98);

            // Reset 
            Result = 0;
            Test.Surround2(Test2)(arg1: 8, arg2: 10, arg3: 12, arg4: 15);
            Result.Should().Be(expected: 105);

            // Reset 
            Result = 0;
            Test.Surround3(Test2)(arg1: 8, arg2: 10, arg3: 14, arg4: 15);
            Result.Should().Be(expected: 107);

            // Reset 
            Result = 0;
            Test.Surround4(Test2)(arg1: 8, arg2: 10, arg3: 15, arg4: 15);
            Result.Should().Be(expected: 108);

            L.A(() => Test.Surround((Func<int, int>)null)).ShouldFail();
            L.A(() => Test.Surround2((Func<int, int>)null)).ShouldFail();
            L.A(() => Test.Surround3((Func<int, int>)null)).ShouldFail();
            L.A(() => Test.Surround4((Func<int, int>)null)).ShouldFail();
            L.A(() => ((Action<int, int, int, int>)null).Surround(Test2)).ShouldFail();
            L.A(() => ((Action<int, int, int, int>)null).Surround2(Test2)).ShouldFail();
            L.A(() => ((Action<int, int, int, int>)null).Surround3(Test2)).ShouldFail();
            L.A(() => ((Action<int, int, int, int>)null).Surround4(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest.Surround2(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest.Surround3(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest.Surround4(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Surround2(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Surround3(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Surround4(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Func_0()
            {
            var Test = new Func<int, int>(i => i);
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Func<int, int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test.Surround(Test2)().Should().Be(expected: 5);

            L.A(() => Test.Surround((Func<int>)null)).ShouldFail();
            L.A(() => ((Func<int, int>)null).Surround(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)()).ShouldFail();
            L.A(() => Test.Surround(BadTest2)()).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Func_1()
            {
            var Test = new Func<int, int>(i => i);
            var Test2 = new Func<int, int>(i => i + 5);
            var BadTest = new Func<int, int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test.Surround(Test2)(arg: 5).Should().Be(expected: 10);

            L.A(() => Test.Surround((Func<int, int>)null)).ShouldFail();
            L.A(() => ((Func<int, int>)null).Surround(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Func_2()
            {
            var Test = new Func<int, int>(i => i);
            var Test2 = new Func<int, int, int>((i1, i2) => i1 * i2 + 5);
            var BadTest = new Action<int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int>((i1, i2) => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 2, arg2: 2).Should().Be(expected: 9);

            L.A(() => Test.Surround((Func<int, int, int>)null)).ShouldFail();
            L.A(() => ((Func<int, int>)null).Surround(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Func_3()
            {
            var Test = new Func<int, int>(i => i);
            var Test2 = new Func<int, int, int, int>((i1, i2, i3) => i1 * i2 * i3 + 5);
            var BadTest = new Func<int, int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 2, arg2: 2, arg3: 2).Should().Be(expected: 13);

            L.A(() => Test.Surround((Func<int, int, int, int>)null)).ShouldFail();
            L.A(() => ((Func<int, int>)null).Surround(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Func_4()
            {
            var Test = new Func<int, int>(i => i);
            var Test2 = new Func<int, int, int, int, int>((i1, i2, i3, i4) => i1 * i2 * i3 * i4 + 5);
            var BadTest = new Func<int, int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int, int, int>((i1, i2, i3, i4) => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 2, arg2: 2, arg3: 2, arg4: 2).Should().Be(expected: 21);

            L.A(() => Test.Surround((Func<int, int, int, int, int>)null)).ShouldFail();
            L.A(() => ((Func<int, int>)null).Surround(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Func2_0()
            {
            var Test = new Func<int, int, int>((i1, i2) => i1 + i2);
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Func<int, int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test.Surround(Test2)(arg: 5).Should().Be(expected: 10);

            Test.Surround2(Test2)(arg: 8).Should().Be(expected: 13);

            L.A(() => Test.Surround((Func<int>)null)).ShouldFail();
            L.A(() => Test.Surround2((Func<int>)null)).ShouldFail();
            L.A(() => ((Func<int, int, int>)null).Surround(Test2)).ShouldFail();
            L.A(() => ((Func<int, int, int>)null).Surround2(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg: 5)).ShouldFail();
            L.A(() => BadTest.Surround2(Test2)(arg: 5)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg: 5)).ShouldFail();
            L.A(() => Test.Surround2(BadTest2)(arg: 5)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Func2_1()
            {
            var Test = new Func<int, int, int>((i1, i2) => i1 + i2);
            var Test2 = new Func<int, int>(i => i + 5);
            var BadTest = new Func<int, int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 1, arg2: 5).Should().Be(expected: 11);

            // Reset 
            Test.Surround2(Test2)(arg1: 3, arg2: 8).Should().Be(expected: 16);

            L.A(() => Test.Surround((Func<int, int>)null)).ShouldFail();
            L.A(() => Test.Surround2((Func<int, int>)null)).ShouldFail();
            L.A(() => ((Func<int, int, int>)null).Surround(Test2)).ShouldFail();
            L.A(() => ((Func<int, int, int>)null).Surround2(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => BadTest.Surround2(Test2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test.Surround2(BadTest2)(arg1: 0, arg2: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Func2_2()
            {
            var Test = new Func<int, int, int>((i1, i2) => i1 + i2);
            var Test2 = new Func<int, int, int>((i1, i2) => i1 * i2 + 5);
            var BadTest = new Func<int, int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int>((i1, i2) => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 1, arg2: 5, arg3: 6).Should().Be(expected: 36);

            Test.Surround2(Test2)(arg1: 3, arg2: 8, arg3: 10).Should().Be(expected: 88);

            L.A(() => Test.Surround((Func<int, int, int>)null)).ShouldFail();
            L.A(() => Test.Surround2((Func<int, int, int>)null)).ShouldFail();
            L.A(() => ((Func<int, int, int>)null).Surround(Test2)).ShouldFail();
            L.A(() => ((Func<int, int, int>)null).Surround2(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest.Surround2(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Surround2(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Func2_3()
            {
            var Test = new Func<int, int, int>((i1, i2) => i1 + i2);
            var Test2 = new Func<int, int, int, int>((i1, i2, i3) => i1 * i2 * i3 + 5);
            var BadTest = new Func<int, int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 1, arg2: 5, arg3: 6, arg4: 8).Should().Be(expected: 246);

            Test.Surround2(Test2)(arg1: 3, arg2: 8, arg3: 10, arg4: 12).Should().Be(expected: 968);

            L.A(() => Test.Surround((Func<int, int, int, int>)null)).ShouldFail();
            L.A(() => Test.Surround2((Func<int, int, int, int>)null)).ShouldFail();
            L.A(() => ((Func<int, int, int>)null).Surround(Test2)).ShouldFail();
            L.A(() => ((Func<int, int, int>)null).Surround2(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest.Surround2(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Surround2(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Func3_0()
            {
            var Test = new Func<int, int, int, int>((i1, i2, i3) => i1 + i2 + i3);
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 5, arg2: 8).Should().Be(expected: 18);

            Test.Surround2(Test2)(arg1: 8, arg2: 10).Should().Be(expected: 23);

            // Reset 
            Test.Surround3(Test2)(arg1: 8, arg2: 10).Should().Be(expected: 23);

            L.A(() => Test.Surround((Func<int>)null)).ShouldFail();
            L.A(() => Test.Surround2((Func<int>)null)).ShouldFail();
            L.A(() => Test.Surround3((Func<int>)null)).ShouldFail();
            L.A(() => ((Func<int, int, int, int>)null).Surround(Test2)).ShouldFail();
            L.A(() => ((Func<int, int, int, int>)null).Surround2(Test2)).ShouldFail();
            L.A(() => ((Func<int, int, int, int>)null).Surround3(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => BadTest.Surround2(Test2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => BadTest.Surround3(Test2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test.Surround2(BadTest2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test.Surround3(BadTest2)(arg1: 0, arg2: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Func3_1()
            {
            var Test = new Func<int, int, int, int>((i1, i2, i3) => i1 + i2 + i3);
            var Test2 = new Func<int, int>(i => i + 5);
            var BadTest = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 5, arg2: 8, arg3: 10).Should().Be(expected: 28);

            Test.Surround2(Test2)(arg1: 8, arg2: 10, arg3: 12).Should().Be(expected: 35);

            Test.Surround3(Test2)(arg1: 8, arg2: 10, arg3: 13).Should().Be(expected: 36);

            L.A(() => Test.Surround((Func<int, int>)null)).ShouldFail();
            L.A(() => Test.Surround2((Func<int, int>)null)).ShouldFail();
            L.A(() => Test.Surround3((Func<int, int>)null)).ShouldFail();
            L.A(() => ((Func<int, int, int, int>)null).Surround(Test2)).ShouldFail();
            L.A(() => ((Func<int, int, int, int>)null).Surround2(Test2)).ShouldFail();
            L.A(() => ((Func<int, int, int, int>)null).Surround3(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest.Surround2(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest.Surround3(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Surround2(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Surround3(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Func3_2()
            {
            var Test = new Func<int, int, int, int>((i1, i2, i3) => i1 + i2 + i3);
            var Test2 = new Func<int, int, int>((i1, i2) => i1 * i2 + 5);
            var BadTest = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int>((i1, i2) => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 5, arg2: 8, arg3: 10, arg4: 14).Should().Be(expected: 158);

            Test.Surround2(Test2)(arg1: 8, arg2: 10, arg3: 12, arg4: 14).Should().Be(expected: 191);

            Test.Surround3(Test2)(arg1: 8, arg2: 10, arg3: 13, arg4: 15).Should().Be(expected: 218);

            L.A(() => Test.Surround((Func<int, int, int>)null)).ShouldFail();
            L.A(() => Test.Surround2((Func<int, int, int>)null)).ShouldFail();
            L.A(() => Test.Surround3((Func<int, int, int>)null)).ShouldFail();
            L.A(() => ((Func<int, int, int, int>)null).Surround(Test2)).ShouldFail();
            L.A(() => ((Func<int, int, int, int>)null).Surround2(Test2)).ShouldFail();
            L.A(() => ((Func<int, int, int, int>)null).Surround3(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest.Surround2(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest.Surround3(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Surround2(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Surround3(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Func4_0()
            {
            var Test = new Func<int, int, int, int, int>((i1, i2, i3, i4) => i1 + i2 + i3 + i4);
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Func<int, int, int, int, int>((i1, i2, i3, i4) => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 5, arg2: 8, arg3: 10).Should().Be(expected: 28);

            Test.Surround2(Test2)(arg1: 8, arg2: 10, arg3: 12).Should().Be(expected: 35);

            Test.Surround3(Test2)(arg1: 8, arg2: 10, arg3: 14).Should().Be(expected: 37);

            Test.Surround4(Test2)(arg1: 8, arg2: 10, arg3: 15).Should().Be(expected: 38);

            L.A(() => Test.Surround((Func<int>)null)).ShouldFail();
            L.A(() => Test.Surround2((Func<int>)null)).ShouldFail();
            L.A(() => Test.Surround3((Func<int>)null)).ShouldFail();
            L.A(() => Test.Surround4((Func<int>)null)).ShouldFail();
            L.A(() => ((Func<int, int, int, int, int>)null).Surround(Test2)).ShouldFail();
            L.A(() => ((Func<int, int, int, int, int>)null).Surround2(Test2)).ShouldFail();
            L.A(() => ((Func<int, int, int, int, int>)null).Surround3(Test2)).ShouldFail();
            L.A(() => ((Func<int, int, int, int, int>)null).Surround4(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest.Surround2(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest.Surround3(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest.Surround4(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Surround2(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Surround3(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Surround4(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Surround_Func4_1()
            {
            var Test = new Func<int, int, int, int, int>((i1, i2, i3, i4) => i1 + i2 + i3 + i4);
            var Test2 = new Func<int, int>(i => i * 5);
            var BadTest = new Func<int, int, int, int, int>((i1, i2, i3, i4) => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 5, arg2: 8, arg3: 10, arg4: 15).Should().Be(expected: 98);

            Test.Surround2(Test2)(arg1: 8, arg2: 10, arg3: 12, arg4: 15).Should().Be(expected: 105);

            Test.Surround3(Test2)(arg1: 8, arg2: 10, arg3: 14, arg4: 15).Should().Be(expected: 107);

            Test.Surround4(Test2)(arg1: 8, arg2: 10, arg3: 15, arg4: 15).Should().Be(expected: 108);

            L.A(() => Test.Surround((Func<int, int>)null)).ShouldFail();
            L.A(() => Test.Surround2((Func<int, int>)null)).ShouldFail();
            L.A(() => Test.Surround3((Func<int, int>)null)).ShouldFail();
            L.A(() => Test.Surround4((Func<int, int>)null)).ShouldFail();
            L.A(() => ((Func<int, int, int, int, int>)null).Surround(Test2)).ShouldFail();
            L.A(() => ((Func<int, int, int, int, int>)null).Surround2(Test2)).ShouldFail();
            L.A(() => ((Func<int, int, int, int, int>)null).Surround3(Test2)).ShouldFail();
            L.A(() => ((Func<int, int, int, int, int>)null).Surround4(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest.Surround2(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest.Surround3(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest.Surround4(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Surround2(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Surround3(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Surround4(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            }

        #endregion

        #region Enclose

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func`3<T4, T5, T2>, Action`3<T1, T2, T3>) => Action`4<T1, T3, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose3) + "(Func`3<T4, T5, T3>, Action`3<T1, T2, T3>) => Action`4<T1, T2, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`1<T1>, Action`4<T1, T2, T3, T4>) => Action`3<T2, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func`1<T2>, Action`4<T1, T2, T3, T4>) => Action`3<T1, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose3) + "(Func`1<T3>, Action`4<T1, T2, T3, T4>) => Action`3<T1, T2, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose4) + "(Func`1<T4>, Action`4<T1, T2, T3, T4>) => Action`3<T1, T2, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`2<T5, T1>, Action`4<T1, T2, T3, T4>) => Action`4<T2, T3, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func`2<T5, T2>, Action`4<T1, T2, T3, T4>) => Action`4<T1, T3, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose3) + "(Func`2<T5, T3>, Action`4<T1, T2, T3, T4>) => Action`4<T1, T2, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose4) + "(Func`2<T5, T4>, Action`4<T1, T2, T3, T4>) => Action`4<T1, T2, T3, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`1<T1>, Func`2<T1, U>) => Func`1<U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`2<T1, T2>, Func`2<T2, U>) => Func`2<T1, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`3<T1, T2, T3>, Func`2<T3, U>) => Func`3<T1, T2, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`4<T1, T2, T3, T4>, Func`2<T4, U>) => Func`4<T1, T2, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`5<T1, T2, T3, T4, T5>, Func`2<T5, U>) => Func`5<T1, T2, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`1<T1>, Func`3<T1, T2, U>) => Func`2<T2, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func`1<T2>, Func`3<T1, T2, U>) => Func`2<T1, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`2<T3, T1>, Func`3<T1, T2, U>) => Func`3<T2, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func`2<T3, T2>, Func`3<T1, T2, U>) => Func`3<T1, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`3<T3, T4, T1>, Func`3<T1, T2, U>) => Func`4<T2, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func`3<T3, T4, T2>, Func`3<T1, T2, U>) => Func`4<T1, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`4<T3, T4, T5, T1>, Func`3<T1, T2, U>) => Func`5<T2, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func`4<T3, T4, T5, T2>, Func`3<T1, T2, U>) => Func`5<T1, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`1<T1>, Func`4<T1, T2, T3, U>) => Func`3<T2, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func`1<T2>, Func`4<T1, T2, T3, U>) => Func`3<T1, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose3) + "(Func`1<T3>, Func`4<T1, T2, T3, U>) => Func`3<T1, T2, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`2<T4, T1>, Func`4<T1, T2, T3, U>) => Func`4<T2, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func`2<T4, T2>, Func`4<T1, T2, T3, U>) => Func`4<T1, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose3) + "(Func`2<T4, T3>, Func`4<T1, T2, T3, U>) => Func`4<T1, T2, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`3<T4, T5, T1>, Func`4<T1, T2, T3, U>) => Func`5<T2, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func`3<T4, T5, T2>, Func`4<T1, T2, T3, U>) => Func`5<T1, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose3) + "(Func`3<T4, T5, T3>, Func`4<T1, T2, T3, U>) => Func`5<T1, T2, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`1<T1>, Func`5<T1, T2, T3, T4, U>) => Func`4<T2, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func`1<T2>, Func`5<T1, T2, T3, T4, U>) => Func`4<T1, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose3) + "(Func`1<T3>, Func`5<T1, T2, T3, T4, U>) => Func`4<T1, T2, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose4) + "(Func`1<T4>, Func`5<T1, T2, T3, T4, U>) => Func`4<T1, T2, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`2<T5, T1>, Func`5<T1, T2, T3, T4, U>) => Func`5<T2, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func`2<T5, T2>, Func`5<T1, T2, T3, T4, U>) => Func`5<T1, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose3) + "(Func`2<T5, T3>, Func`5<T1, T2, T3, T4, U>) => Func`5<T1, T2, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose4) + "(Func`2<T5, T4>, Func`5<T1, T2, T3, T4, U>) => Func`5<T1, T2, T3, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`1<T1>, Action`1<T1>) => Action")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`2<T2, T1>, Action`1<T1>) => Action`1<T2>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`3<T2, T3, T1>, Action`1<T1>) => Action`2<T2, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`4<T2, T3, T4, T1>, Action`1<T1>) => Action`3<T2, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`5<T2, T3, T4, T5, T1>, Action`1<T1>) => Action`4<T2, T3, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`1<T1>, Action`2<T1, T2>) => Action`1<T2>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func`1<T2>, Action`2<T1, T2>) => Action`1<T1>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`2<T3, T1>, Action`2<T1, T2>) => Action`2<T2, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func`2<T3, T2>, Action`2<T1, T2>) => Action`2<T1, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`3<T3, T4, T1>, Action`2<T1, T2>) => Action`3<T2, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func`3<T3, T4, T2>, Action`2<T1, T2>) => Action`3<T1, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`4<T3, T4, T5, T1>, Action`2<T1, T2>) => Action`4<T2, T3, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func`4<T3, T4, T5, T2>, Action`2<T1, T2>) => Action`4<T1, T3, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`1<T1>, Action`3<T1, T2, T3>) => Action`2<T2, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func`1<T2>, Action`3<T1, T2, T3>) => Action`2<T1, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose3) + "(Func`1<T3>, Action`3<T1, T2, T3>) => Action`2<T1, T2>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`2<T4, T1>, Action`3<T1, T2, T3>) => Action`3<T2, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func`2<T4, T2>, Action`3<T1, T2, T3>) => Action`3<T1, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose3) + "(Func`2<T4, T3>, Action`3<T1, T2, T3>) => Action`3<T1, T2, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func`3<T4, T5, T1>, Action`3<T1, T2, T3>) => Action`4<T2, T3, T4, T5>")]
        public void Test_Enclose_Action_0()
            {
            int Result = 0;

            var Test = new Action<int>(i => { Result = i; });
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Action<int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test2.Enclose(Test)();
            Result.Should().Be(expected: 5);

            L.A(() => ((Func<int>)null).Enclose(Test)).ShouldFail();
            L.A(() => Test2.Enclose((Action<int>)null)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)()).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)()).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Action_1()
            {
            int Result = 0;

            var Test = new Action<int>(i => { Result = i; });
            var Test2 = new Func<int, int>(i => i + 5);
            var BadTest = new Action<int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test2.Enclose(Test)(obj: 5);
            Result.Should().Be(expected: 10);

            L.A(() => ((Func<int, int>)null).Enclose(Test)).ShouldFail();
            L.A(() => Test2.Enclose((Action<int>)null)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(obj: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(obj: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Action_2()
            {
            int Result = 0;

            var Test = new Action<int>(i => { Result = i; });
            var Test2 = new Func<int, int, int>((i1, i2) => i1 * i2 + 5);
            var BadTest = new Action<int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int>((i1, i2) => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 2, arg2: 2);
            Result.Should().Be(expected: 9);

            L.A(() => ((Func<int, int, int>)null).Enclose(Test)).ShouldFail();
            L.A(() => Test2.Enclose((Action<int>)null)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Action_3()
            {
            int Result = 0;

            var Test = new Action<int>(i => { Result = i; });
            var Test2 = new Func<int, int, int, int>((i1, i2, i3) => i1 * i2 * i3 + 5);
            var BadTest = new Action<int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 2, arg2: 2, arg3: 2);
            Result.Should().Be(expected: 13);

            L.A(() => ((Func<int, int, int, int>)null).Enclose(Test)).ShouldFail();
            L.A(() => Test2.Enclose((Action<int>)null)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Action_4()
            {
            int Result = 0;

            var Test = new Action<int>(i => { Result = i; });
            var Test2 = new Func<int, int, int, int, int>((i1, i2, i3, i4) => i1 * i2 * i3 * i4 + 5);
            var BadTest = new Action<int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int, int, int>((i1, i2, i3, i4) => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 2, arg2: 2, arg3: 2, arg4: 2);
            Result.Should().Be(expected: 21);

            L.A(() => ((Func<int, int, int, int, int>)null).Enclose(Test)).ShouldFail();
            L.A(() => Test2.Enclose((Action<int>)null)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Action2_0()
            {
            int Result = 0;

            var Test = new Action<int, int>((i1, i2) => { Result = i1 + i2; });
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Action<int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test2.Enclose(Test)(obj: 5);
            Result.Should().Be(expected: 10);

            // Reset 
            Result = 0;
            Test2.Enclose2(Test)(obj: 8);
            Result.Should().Be(expected: 13);

            L.A(() => ((Func<int>)null).Enclose(Test)).ShouldFail();
            L.A(() => ((Func<int>)null).Enclose2(Test)).ShouldFail();
            L.A(() => Test2.Enclose((Action<int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose2((Action<int, int>)null)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(obj: 5)).ShouldFail();
            L.A(() => Test2.Enclose2(BadTest)(obj: 5)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(obj: 5)).ShouldFail();
            L.A(() => BadTest2.Enclose2(Test)(obj: 5)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Action2_1()
            {
            int Result = 0;

            var Test = new Action<int, int>((i1, i2) => { Result = i1 + i2; });
            var Test2 = new Func<int, int>(i => i + 5);
            var BadTest = new Action<int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 1, arg2: 5);
            Result.Should().Be(expected: 11);

            // Reset 
            Result = 0;
            Test2.Enclose2(Test)(arg1: 3, arg2: 8);
            Result.Should().Be(expected: 16);

            L.A(() => ((Func<int, int>)null).Enclose(Test)).ShouldFail();
            L.A(() => ((Func<int, int>)null).Enclose2(Test)).ShouldFail();
            L.A(() => Test2.Enclose((Action<int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose2((Action<int, int>)null)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test2.Enclose2(BadTest)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose2(Test)(arg1: 0, arg2: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Action2_2()
            {
            int Result = 0;

            var Test = new Action<int, int>((i1, i2) => { Result = i1 + i2; });
            var Test2 = new Func<int, int, int>((i1, i2) => i1 * i2 + 5);
            var BadTest = new Action<int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int>((i1, i2) => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 1, arg2: 5, arg3: 6);
            Result.Should().Be(expected: 36);

            // Reset 
            Result = 0;
            Test2.Enclose2(Test)(arg1: 3, arg2: 8, arg3: 10);
            Result.Should().Be(expected: 88);

            L.A(() => ((Func<int, int, int>)null).Enclose(Test)).ShouldFail();
            L.A(() => ((Func<int, int, int>)null).Enclose2(Test)).ShouldFail();
            L.A(() => Test2.Enclose((Action<int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose2((Action<int, int>)null)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test2.Enclose2(BadTest)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose2(Test)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Action2_3()
            {
            int Result = 0;

            var Test = new Action<int, int>((i1, i2) => { Result = i1 + i2; });
            var Test2 = new Func<int, int, int, int>((i1, i2, i3) => i1 * i2 * i3 + 5);
            var BadTest = new Action<int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 1, arg2: 5, arg3: 6, arg4: 8);
            Result.Should().Be(expected: 246);

            // Reset 
            Result = 0;
            Test2.Enclose2(Test)(arg1: 3, arg2: 8, arg3: 10, arg4: 12);
            Result.Should().Be(expected: 968);

            L.A(() => ((Func<int, int, int, int>)null).Enclose(Test)).ShouldFail();
            L.A(() => ((Func<int, int, int, int>)null).Enclose2(Test)).ShouldFail();
            L.A(() => Test2.Enclose((Action<int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose2((Action<int, int>)null)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test2.Enclose2(BadTest)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose2(Test)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Action3_0()
            {
            int Result = 0;

            var Test = new Action<int, int, int>((i1, i2, i3) => { Result = i1 + i2 + i3; });
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Action<int, int, int>((i1, i2, i3) => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 5, arg2: 8);
            Result.Should().Be(expected: 18);

            // Reset 
            Result = 0;
            Test2.Enclose2(Test)(arg1: 8, arg2: 10);
            Result.Should().Be(expected: 23);

            // Reset 
            Result = 0;
            Test2.Enclose3(Test)(arg1: 8, arg2: 10);
            Result.Should().Be(expected: 23);

            L.A(() => ((Func<int>)null).Enclose(Test)).ShouldFail();
            L.A(() => ((Func<int>)null).Enclose2(Test)).ShouldFail();
            L.A(() => ((Func<int>)null).Enclose3(Test)).ShouldFail();
            L.A(() => Test2.Enclose((Action<int, int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose2((Action<int, int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose3((Action<int, int, int>)null)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test2.Enclose2(BadTest)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test2.Enclose3(BadTest)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose2(Test)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose3(Test)(arg1: 0, arg2: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Action3_1()
            {
            int Result = 0;

            var Test = new Action<int, int, int>((i1, i2, i3) => { Result = i1 + i2 + i3; });
            var Test2 = new Func<int, int>(i => i + 5);
            var BadTest = new Action<int, int, int>((i1, i2, i3) => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 5, arg2: 8, arg3: 10);
            Result.Should().Be(expected: 28);

            // Reset 
            Result = 0;
            Test2.Enclose2(Test)(arg1: 8, arg2: 10, arg3: 12);
            Result.Should().Be(expected: 35);

            // Reset 
            Result = 0;
            Test2.Enclose3(Test)(arg1: 8, arg2: 10, arg3: 13);
            Result.Should().Be(expected: 36);

            L.A(() => ((Func<int, int>)null).Enclose(Test)).ShouldFail();
            L.A(() => ((Func<int, int>)null).Enclose2(Test)).ShouldFail();
            L.A(() => ((Func<int, int>)null).Enclose3(Test)).ShouldFail();
            L.A(() => Test2.Enclose((Action<int, int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose2((Action<int, int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose3((Action<int, int, int>)null)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test2.Enclose2(BadTest)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test2.Enclose3(BadTest)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose2(Test)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose3(Test)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Action3_2()
            {
            int Result = 0;

            var Test = new Action<int, int, int>((i1, i2, i3) => { Result = i1 + i2 + i3; });
            var Test2 = new Func<int, int, int>((i1, i2) => i1 * i2 + 5);
            var BadTest = new Action<int, int, int>((i1, i2, i3) => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int>((i1, i2) => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 5, arg2: 8, arg3: 10, arg4: 14);
            Result.Should().Be(expected: 158);

            // Reset 
            Result = 0;
            Test2.Enclose2(Test)(arg1: 8, arg2: 10, arg3: 12, arg4: 14);
            Result.Should().Be(expected: 191);

            // Reset 
            Result = 0;
            Test2.Enclose3(Test)(arg1: 8, arg2: 10, arg3: 13, arg4: 15);
            Result.Should().Be(expected: 218);

            L.A(() => ((Func<int, int, int>)null).Enclose(Test)).ShouldFail();
            L.A(() => ((Func<int, int, int>)null).Enclose2(Test)).ShouldFail();
            L.A(() => ((Func<int, int, int>)null).Enclose3(Test)).ShouldFail();
            L.A(() => Test2.Enclose((Action<int, int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose2((Action<int, int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose3((Action<int, int, int>)null)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test2.Enclose2(BadTest)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test2.Enclose3(BadTest)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose2(Test)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose3(Test)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Action4_0()
            {
            int Result = 0;

            var Test = new Action<int, int, int, int>((i1, i2, i3, i4) => { Result = i1 + i2 + i3 + i4; });
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Action<int, int, int, int>((i1, i2, i3, i4) => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 5, arg2: 8, arg3: 10);
            Result.Should().Be(expected: 28);

            // Reset 
            Result = 0;
            Test2.Enclose2(Test)(arg1: 8, arg2: 10, arg3: 12);
            Result.Should().Be(expected: 35);

            // Reset 
            Result = 0;
            Test2.Enclose3(Test)(arg1: 8, arg2: 10, arg3: 14);
            Result.Should().Be(expected: 37);

            // Reset 
            Result = 0;
            Test2.Enclose4(Test)(arg1: 8, arg2: 10, arg3: 15);
            Result.Should().Be(expected: 38);

            L.A(() => ((Func<int>)null).Enclose(Test)).ShouldFail();
            L.A(() => ((Func<int>)null).Enclose2(Test)).ShouldFail();
            L.A(() => ((Func<int>)null).Enclose3(Test)).ShouldFail();
            L.A(() => ((Func<int>)null).Enclose4(Test)).ShouldFail();
            L.A(() => Test2.Enclose((Action<int, int, int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose2((Action<int, int, int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose3((Action<int, int, int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose4((Action<int, int, int, int>)null)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test2.Enclose2(BadTest)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test2.Enclose3(BadTest)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test2.Enclose4(BadTest)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose2(Test)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose3(Test)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose4(Test)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Action4_1()
            {
            int Result = 0;

            var Test = new Action<int, int, int, int>((i1, i2, i3, i4) => { Result = i1 + i2 + i3 + i4; });
            var Test2 = new Func<int, int>(i => i * 5);
            var BadTest = new Action<int, int, int, int>((i1, i2, i3, i4) => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 5, arg2: 8, arg3: 10, arg4: 15);
            Result.Should().Be(expected: 98);

            // Reset 
            Result = 0;
            Test2.Enclose2(Test)(arg1: 8, arg2: 10, arg3: 12, arg4: 15);
            Result.Should().Be(expected: 105);

            // Reset 
            Result = 0;
            Test2.Enclose3(Test)(arg1: 8, arg2: 10, arg3: 14, arg4: 15);
            Result.Should().Be(expected: 107);

            // Reset 
            Result = 0;
            Test2.Enclose4(Test)(arg1: 8, arg2: 10, arg3: 15, arg4: 15);
            Result.Should().Be(expected: 108);

            L.A(() => ((Func<int, int>)null).Enclose(Test)).ShouldFail();
            L.A(() => ((Func<int, int>)null).Enclose2(Test)).ShouldFail();
            L.A(() => ((Func<int, int>)null).Enclose3(Test)).ShouldFail();
            L.A(() => ((Func<int, int>)null).Enclose4(Test)).ShouldFail();
            L.A(() => Test2.Enclose((Action<int, int, int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose2((Action<int, int, int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose3((Action<int, int, int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose4((Action<int, int, int, int>)null)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test2.Enclose2(BadTest)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test2.Enclose3(BadTest)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test2.Enclose4(BadTest)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose2(Test)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose3(Test)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose4(Test)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Func_0()
            {
            var Test = new Func<int, int>(i => i);
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Func<int, int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test2.Enclose(Test)().Should().Be(expected: 5);

            L.A(() => ((Func<int>)null).Enclose(Test)).ShouldFail();
            L.A(() => Test2.Enclose((Func<int, int>)null)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)()).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)()).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Func_1()
            {
            var Test = new Func<int, int>(i => i);
            var Test2 = new Func<int, int>(i => i + 5);
            var BadTest = new Func<int, int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test.Enclose(Test2)(arg: 5).Should().Be(expected: 10);

            L.A(() => Test.Enclose((Func<int, int>)null)).ShouldFail();
            L.A(() => ((Func<int, int>)null).Enclose(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Enclose(Test2)(arg: 0)).ShouldFail();
            L.A(() => Test.Enclose(BadTest2)(arg: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Func_2()
            {
            var Test = new Func<int, int>(i => i);
            var Test2 = new Func<int, int, int>((i1, i2) => i1 * i2 + 5);
            var BadTest = new Action<int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int>((i1, i2) => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 2, arg2: 2).Should().Be(expected: 9);

            L.A(() => Test.Enclose((Func<int, int, int>)null)).ShouldFail();
            L.A(() => ((Func<int, int>)null).Enclose(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Func_3()
            {
            var Test = new Func<int, int>(i => i);
            var Test2 = new Func<int, int, int, int>((i1, i2, i3) => i1 * i2 * i3 + 5);
            var BadTest = new Func<int, int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 2, arg2: 2, arg3: 2).Should().Be(expected: 13);

            L.A(() => ((Func<int, int, int, int>)null).Enclose(Test)).ShouldFail();
            L.A(() => Test2.Enclose((Func<int, int>)null)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Func_4()
            {
            var Test = new Func<int, int>(i => i);
            var Test2 = new Func<int, int, int, int, int>((i1, i2, i3, i4) => i1 * i2 * i3 * i4 + 5);
            var BadTest = new Func<int, int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int, int, int>((i1, i2, i3, i4) => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 2, arg2: 2, arg3: 2, arg4: 2).Should().Be(expected: 21);

            L.A(() => ((Func<int, int, int, int, int>)null).Enclose(Test)).ShouldFail();
            L.A(() => Test2.Enclose((Func<int, int>)null)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Func2_0()
            {
            var Test = new Func<int, int, int>((i1, i2) => i1 + i2);
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Func<int, int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test2.Enclose(Test)(arg: 5).Should().Be(expected: 10);

            Test2.Enclose2(Test)(arg: 8).Should().Be(expected: 13);

            L.A(() => ((Func<int>)null).Enclose(Test)).ShouldFail();
            L.A(() => ((Func<int>)null).Enclose2(Test)).ShouldFail();
            L.A(() => Test2.Enclose((Func<int, int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose2((Func<int, int, int>)null)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg: 5)).ShouldFail();
            L.A(() => Test2.Enclose2(BadTest)(arg: 5)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg: 5)).ShouldFail();
            L.A(() => BadTest2.Enclose2(Test)(arg: 5)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Func2_1()
            {
            var Test = new Func<int, int, int>((i1, i2) => i1 + i2);
            var Test2 = new Func<int, int>(i => i + 5);
            var BadTest = new Func<int, int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 1, arg2: 5).Should().Be(expected: 11);

            // Reset 
            Test2.Enclose2(Test)(arg1: 3, arg2: 8).Should().Be(expected: 16);

            L.A(() => ((Func<int, int>)null).Enclose(Test)).ShouldFail();
            L.A(() => ((Func<int, int>)null).Enclose2(Test)).ShouldFail();
            L.A(() => ((Func<int, int, int>)null).Enclose(Test2)).ShouldFail();
            L.A(() => Test2.Enclose2((Func<int, int, int>)null)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Enclose(Test2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test2.Enclose2(BadTest)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test.Enclose(BadTest2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose2(Test)(arg1: 0, arg2: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Func2_2()
            {
            var Test = new Func<int, int, int>((i1, i2) => i1 + i2);
            var Test2 = new Func<int, int, int>((i1, i2) => i1 * i2 + 5);
            var BadTest = new Func<int, int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int>((i1, i2) => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 1, arg2: 5, arg3: 6).Should().Be(expected: 36);

            Test2.Enclose2(Test)(arg1: 3, arg2: 8, arg3: 10).Should().Be(expected: 88);

            L.A(() => Test.Enclose((Func<int, int, int>)null)).ShouldFail();
            L.A(() => Test.Enclose2((Func<int, int, int>)null)).ShouldFail();
            L.A(() => ((Func<int, int, int>)null).Enclose(Test2)).ShouldFail();
            L.A(() => ((Func<int, int, int>)null).Enclose2(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Enclose(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest.Enclose2(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Enclose(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Enclose2(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Func2_3()
            {
            var Test = new Func<int, int, int>((i1, i2) => i1 + i2);
            var Test2 = new Func<int, int, int, int>((i1, i2, i3) => i1 * i2 * i3 + 5);
            var BadTest = new Func<int, int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 1, arg2: 5, arg3: 6, arg4: 8).Should().Be(expected: 246);

            Test2.Enclose2(Test)(arg1: 3, arg2: 8, arg3: 10, arg4: 12).Should().Be(expected: 968);

            L.A(() => Test.Enclose((Func<int, int, int, int>)null)).ShouldFail();
            L.A(() => Test.Enclose2((Func<int, int, int, int>)null)).ShouldFail();
            L.A(() => ((Func<int, int, int>)null).Enclose(Test2)).ShouldFail();
            L.A(() => ((Func<int, int, int>)null).Enclose2(Test2)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => BadTest.Enclose(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest.Enclose2(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Enclose(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Enclose2(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Func3_0()
            {
            var Test = new Func<int, int, int, int>((i1, i2, i3) => i1 + i2 + i3);
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 5, arg2: 8).Should().Be(expected: 18);

            Test2.Enclose2(Test)(arg1: 8, arg2: 10).Should().Be(expected: 23);

            Test2.Enclose3(Test)(arg1: 8, arg2: 10).Should().Be(expected: 23);

            L.A(() => ((Func<int>)null).Enclose(Test)).ShouldFail();
            L.A(() => ((Func<int>)null).Enclose2(Test)).ShouldFail();
            L.A(() => ((Func<int>)null).Enclose3(Test)).ShouldFail();
            L.A(() => Test2.Enclose((Func<int, int, int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose2((Func<int, int, int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose3((Func<int, int, int, int>)null)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test2.Enclose2(BadTest)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test2.Enclose3(BadTest)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose2(Test)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose3(Test)(arg1: 0, arg2: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Func3_1()
            {
            var Test = new Func<int, int, int, int>((i1, i2, i3) => i1 + i2 + i3);
            var Test2 = new Func<int, int>(i => i + 5);
            var BadTest = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 5, arg2: 8, arg3: 10).Should().Be(expected: 28);

            Test2.Enclose2(Test)(arg1: 8, arg2: 10, arg3: 12).Should().Be(expected: 35);

            Test2.Enclose3(Test)(arg1: 8, arg2: 10, arg3: 13).Should().Be(expected: 36);

            L.A(() => ((Func<int, int>)null).Enclose(Test)).ShouldFail();
            L.A(() => ((Func<int, int>)null).Enclose2(Test)).ShouldFail();
            L.A(() => ((Func<int, int>)null).Enclose3(Test)).ShouldFail();
            L.A(() => Test2.Enclose((Func<int, int, int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose2((Func<int, int, int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose3((Func<int, int, int, int>)null)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test2.Enclose2(BadTest)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test2.Enclose3(BadTest)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose2(Test)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose3(Test)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Func3_2()
            {
            var Test = new Func<int, int, int, int>((i1, i2, i3) => i1 + i2 + i3);
            var Test2 = new Func<int, int, int>((i1, i2) => i1 * i2 + 5);
            var BadTest = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int>((i1, i2) => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 5, arg2: 8, arg3: 10, arg4: 14).Should().Be(expected: 158);

            Test2.Enclose2(Test)(arg1: 8, arg2: 10, arg3: 12, arg4: 14).Should().Be(expected: 191);

            Test2.Enclose3(Test)(arg1: 8, arg2: 10, arg3: 13, arg4: 15).Should().Be(expected: 218);

            L.A(() => ((Func<int, int, int>)null).Enclose(Test)).ShouldFail();
            L.A(() => ((Func<int, int, int>)null).Enclose2(Test)).ShouldFail();
            L.A(() => ((Func<int, int, int>)null).Enclose3(Test)).ShouldFail();
            L.A(() => Test2.Enclose((Func<int, int, int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose2((Func<int, int, int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose3((Func<int, int, int, int>)null)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test2.Enclose2(BadTest)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test2.Enclose3(BadTest)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose2(Test)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose3(Test)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Func4_0()
            {
            var Test = new Func<int, int, int, int, int>((i1, i2, i3, i4) => i1 + i2 + i3 + i4);
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Func<int, int, int, int, int>((i1, i2, i3, i4) => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 5, arg2: 8, arg3: 10).Should().Be(expected: 28);

            Test2.Enclose2(Test)(arg1: 8, arg2: 10, arg3: 12).Should().Be(expected: 35);

            Test2.Enclose3(Test)(arg1: 8, arg2: 10, arg3: 14).Should().Be(expected: 37);

            Test2.Enclose4(Test)(arg1: 8, arg2: 10, arg3: 15).Should().Be(expected: 38);

            L.A(() => ((Func<int>)null).Enclose(Test)).ShouldFail();
            L.A(() => ((Func<int>)null).Enclose2(Test)).ShouldFail();
            L.A(() => ((Func<int>)null).Enclose3(Test)).ShouldFail();
            L.A(() => ((Func<int>)null).Enclose4(Test)).ShouldFail();
            L.A(() => Test2.Enclose((Func<int, int, int, int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose2((Func<int, int, int, int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose3((Func<int, int, int, int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose4((Func<int, int, int, int, int>)null)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test2.Enclose2(BadTest)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test2.Enclose3(BadTest)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test2.Enclose4(BadTest)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose2(Test)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose3(Test)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose4(Test)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Enclose_Func4_1()
            {
            var Test = new Func<int, int, int, int, int>((i1, i2, i3, i4) => i1 + i2 + i3 + i4);
            var Test2 = new Func<int, int>(i => i * 5);
            var BadTest = new Func<int, int, int, int, int>((i1, i2, i3, i4) => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 5, arg2: 8, arg3: 10, arg4: 15).Should().Be(expected: 98);

            Test2.Enclose2(Test)(arg1: 8, arg2: 10, arg3: 12, arg4: 15).Should().Be(expected: 105);

            Test2.Enclose3(Test)(arg1: 8, arg2: 10, arg3: 14, arg4: 15).Should().Be(expected: 107);

            Test2.Enclose4(Test)(arg1: 8, arg2: 10, arg3: 15, arg4: 15).Should().Be(expected: 108);

            L.A(() => ((Func<int, int>)null).Enclose(Test)).ShouldFail();
            L.A(() => ((Func<int, int>)null).Enclose2(Test)).ShouldFail();
            L.A(() => ((Func<int, int>)null).Enclose3(Test)).ShouldFail();
            L.A(() => ((Func<int, int>)null).Enclose4(Test)).ShouldFail();
            L.A(() => Test2.Enclose((Func<int, int, int, int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose2((Func<int, int, int, int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose3((Func<int, int, int, int, int>)null)).ShouldFail();
            L.A(() => Test2.Enclose4((Func<int, int, int, int, int>)null)).ShouldFail();

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test2.Enclose2(BadTest)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test2.Enclose3(BadTest)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test2.Enclose4(BadTest)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose2(Test)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose3(Test)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose4(Test)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            }

        #endregion
        }
    }