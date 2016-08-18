using System;
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
            nameof(LogicExt.Cast) + "(Action<T1>) => Action<U1>")]
        public void Cast_Action_0()
            {
            bool Result = false;
            Action<object> Action = o =>
                {
                    o.ShouldBe(_TestString);
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
            nameof(LogicExt.Cast) + "(Action<T1, T2>) => Action<U1, U2>")]
        public void Cast_Action_1()
            {
            bool Result = false;
            Action<object, object> Action = (o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
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
            nameof(LogicExt.Cast) + "(Action<T1, T2, T3>) => Action<U1, U2, U3>")]
        public void Cast_Action_2()
            {
            bool Result = false;
            Action<object, object, object> Action = (o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
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
            nameof(LogicExt.Cast) + "(Action<T1, T2, T3, T4>) => Action<U1, U2, U3, U4>")]
        public void Cast_Action_3()
            {
            bool Result = false;
            Action<object, object, object, object> Action = (o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    o4.ShouldBe(_TestString);
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
            nameof(LogicExt.Cast) + "(Func<U1>) => Func<U2>")]
        public void Cast_Func_0()
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
            nameof(LogicExt.Cast) + "(Func<T1, U1>) => Func<T2, U2>")]
        public void Cast_Func_1()
            {
            Func<object, bool> Func = o =>
                {
                    o.ShouldBe(_TestString);
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
            nameof(LogicExt.Cast) + "(Func<T1, T2, U1>) => Func<T3, T4, U2>")]
        public void Cast_Func_2()
            {
            Func<object, object, bool> Func = (o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
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
            nameof(LogicExt.Cast) + "(Func<T1, T2, T3, U1>) => Func<T4, T5, T6, U2>")]
        public void Cast_Func_3()
            {
            Func<object, object, object, bool> Func = (o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
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
            nameof(LogicExt.Cast) + "(Func<T1, T2, T3, T4, U1>) => Func<T5, T6, T7, T8, U2>")]
        public void Cast_Func_4()
            {
            Func<object, object, object, object, bool> Func = (o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    o4.ShouldBe(_TestString);
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
            nameof(LogicExt.Surround) + "(Action<U>, Func<U>) => Action")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action<U>, Func<T1, U>) => Action<T1>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action<U>, Func<T1, T2, U>) => Action<T1, T2>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action<U>, Func<T1, T2, T3, U>) => Action<T1, T2, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action<U>, Func<T1, T2, T3, T4, U>) => Action<T1, T2, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action<T1, T2>, Func<T1>) => Action<T2>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Action<T1, T2>, Func<T2>) => Action<T1>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action<T1, T2>, Func<T3, T1>) => Action<T2, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Action<T1, T2>, Func<T3, T2>) => Action<T1, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action<T1, T2>, Func<T3, T4, T1>) => Action<T2, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Action<T1, T2>, Func<T3, T4, T2>) => Action<T1, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action<T1, T2>, Func<T3, T4, T5, T1>) => Action<T2, T3, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Action<T1, T2>, Func<T3, T4, T5, T2>) => Action<T1, T3, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action<T1, T2, T3>, Func<T1>) => Action<T2, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Action<T1, T2, T3>, Func<T2>) => Action<T1, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround3) + "(Action<T1, T2, T3>, Func<T3>) => Action<T1, T2>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action<T1, T2, T3>, Func<T4, T1>) => Action<T2, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Action<T1, T2, T3>, Func<T4, T2>) => Action<T1, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround3) + "(Action<T1, T2, T3>, Func<T4, T3>) => Action<T1, T2, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action<T1, T2, T3>, Func<T4, T5, T1>) => Action<T2, T3, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Action<T1, T2, T3>, Func<T4, T5, T2>) => Action<T1, T3, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround3) + "(Action<T1, T2, T3>, Func<T4, T5, T3>) => Action<T1, T2, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action<T1, T2, T3, T4>, Func<T1>) => Action<T2, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Action<T1, T2, T3, T4>, Func<T2>) => Action<T1, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround3) + "(Action<T1, T2, T3, T4>, Func<T3>) => Action<T1, T2, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround4) + "(Action<T1, T2, T3, T4>, Func<T4>) => Action<T1, T2, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Action<T1, T2, T3, T4>, Func<T5, T1>) => Action<T2, T3, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Action<T1, T2, T3, T4>, Func<T5, T2>) => Action<T1, T3, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround3) + "(Action<T1, T2, T3, T4>, Func<T5, T3>) => Action<T1, T2, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround4) + "(Action<T1, T2, T3, T4>, Func<T5, T4>) => Action<T1, T2, T3, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func<T1, U>, Func<T1>) => Func<U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func<T2, U>, Func<T1, T2>) => Func<T1, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func<T3, U>, Func<T1, T2, T3>) => Func<T1, T2, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func<T4, U>, Func<T1, T2, T3, T4>) => Func<T1, T2, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func<T5, U>, Func<T1, T2, T3, T4, T5>) => Func<T1, T2, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func<T1, T2, U>, Func<T1>) => Func<T2, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Func<T1, T2, U>, Func<T2>) => Func<T1, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func<T1, T2, U>, Func<T3, T1>) => Func<T2, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Func<T1, T2, U>, Func<T3, T2>) => Func<T1, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func<T1, T2, U>, Func<T3, T4, T1>) => Func<T2, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Func<T1, T2, U>, Func<T3, T4, T2>) => Func<T1, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func<T1, T2, U>, Func<T3, T4, T5, T1>) => Func<T2, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Func<T1, T2, U>, Func<T3, T4, T5, T2>) => Func<T1, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func<T1, T2, T3, U>, Func<T1>) => Func<T2, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Func<T1, T2, T3, U>, Func<T2>) => Func<T1, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround3) + "(Func<T1, T2, T3, U>, Func<T3>) => Func<T1, T2, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func<T1, T2, T3, U>, Func<T4, T1>) => Func<T2, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Func<T1, T2, T3, U>, Func<T4, T2>) => Func<T1, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround3) + "(Func<T1, T2, T3, U>, Func<T4, T3>) => Func<T1, T2, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func<T1, T2, T3, U>, Func<T4, T5, T1>) => Func<T2, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Func<T1, T2, T3, U>, Func<T4, T5, T2>) => Func<T1, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround3) + "(Func<T1, T2, T3, U>, Func<T4, T5, T3>) => Func<T1, T2, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func<T1, T2, T3, T4, U>, Func<T1>) => Func<T2, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Func<T1, T2, T3, T4, U>, Func<T2>) => Func<T1, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround3) + "(Func<T1, T2, T3, T4, U>, Func<T3>) => Func<T1, T2, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround4) + "(Func<T1, T2, T3, T4, U>, Func<T4>) => Func<T1, T2, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround) + "(Func<T1, T2, T3, T4, U>, Func<T5, T1>) => Func<T2, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround2) + "(Func<T1, T2, T3, T4, U>, Func<T5, T2>) => Func<T1, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround3) + "(Func<T1, T2, T3, T4, U>, Func<T5, T3>) => Func<T1, T2, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Surround4) + "(Func<T1, T2, T3, T4, U>, Func<T5, T4>) => Func<T1, T2, T3, T5, U>")]

        public void Surround_Action_0()
            {
            int Result = 0;

            var Test = new Action<int>(i => { Result = i; });
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Action<int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test.Surround(Test2)();
            Result.ShouldBe(Expected: 5);

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)()).ShouldFail();
            L.A(() => Test.Surround(BadTest2)()).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Surround_Action_1()
            {
            int Result = 0;

            var Test = new Action<int>(i => { Result = i; });
            var Test2 = new Func<int, int>(i => i + 5);
            var BadTest = new Action<int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test.Surround(Test2)(obj: 5);
            Result.ShouldBe(Expected: 10);

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(obj: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(obj: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Surround_Action_2()
            {
            int Result = 0;

            var Test = new Action<int>(i => { Result = i; });
            var Test2 = new Func<int, int, int>((i1, i2) => i1 * i2 + 5);
            var BadTest = new Action<int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int>((i1, i2) => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 2, arg2: 2);
            Result.ShouldBe(Expected: 9);

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Surround_Action_3()
            {
            int Result = 0;

            var Test = new Action<int>(i => { Result = i; });
            var Test2 = new Func<int, int, int, int>((i1, i2, i3) => i1 * i2 * i3 + 5);
            var BadTest = new Action<int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 2, arg2: 2, arg3: 2);
            Result.ShouldBe(Expected: 13);

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Surround_Action_4()
            {
            int Result = 0;

            var Test = new Action<int>(i => { Result = i; });
            var Test2 = new Func<int, int, int, int, int>((i1, i2, i3, i4) => i1 * i2 * i3 * i4 + 5);
            var BadTest = new Action<int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int, int, int>((i1, i2, i3, i4) => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 2, arg2: 2, arg3: 2, arg4: 2);
            Result.ShouldBe(Expected: 21);

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Surround_Action2_0()
            {
            int Result = 0;

            var Test = new Action<int, int>((i1, i2) => { Result = i1 + i2; });
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Action<int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test.Surround(Test2)(obj: 5);
            Result.ShouldBe(Expected: 10);

            // Reset 
            Result = 0;
            Test.Surround2(Test2)(obj: 8);
            Result.ShouldBe(Expected: 13);

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(obj: 5)).ShouldFail();
            L.A(() => BadTest.Surround2(Test2)(obj: 5)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(obj: 5)).ShouldFail();
            L.A(() => Test.Surround2(BadTest2)(obj: 5)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Surround_Action2_1()
            {
            int Result = 0;

            var Test = new Action<int, int>((i1, i2) => { Result = i1 + i2; });
            var Test2 = new Func<int, int>(i => i + 5);
            var BadTest = new Action<int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 1, arg2: 5);
            Result.ShouldBe(Expected: 11);

            // Reset 
            Result = 0;
            Test.Surround2(Test2)(arg1: 3, arg2: 8);
            Result.ShouldBe(Expected: 16);

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => BadTest.Surround2(Test2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test.Surround2(BadTest2)(arg1: 0, arg2: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Surround_Action2_2()
            {
            int Result = 0;

            var Test = new Action<int, int>((i1, i2) => { Result = i1 + i2; });
            var Test2 = new Func<int, int, int>((i1, i2) => i1 * i2 + 5);
            var BadTest = new Action<int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int>((i1, i2) => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 1, arg2: 5, arg3: 6);
            Result.ShouldBe(Expected: 36);

            // Reset 
            Result = 0;
            Test.Surround2(Test2)(arg1: 3, arg2: 8, arg3: 10);
            Result.ShouldBe(Expected: 88);

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest.Surround2(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Surround2(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Surround_Action2_3()
            {
            int Result = 0;

            var Test = new Action<int, int>((i1, i2) => { Result = i1 + i2; });
            var Test2 = new Func<int, int, int, int>((i1, i2, i3) => i1 * i2 * i3 + 5);
            var BadTest = new Action<int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 1, arg2: 5, arg3: 6, arg4: 8);
            Result.ShouldBe(Expected: 246);

            // Reset 
            Result = 0;
            Test.Surround2(Test2)(arg1: 3, arg2: 8, arg3: 10, arg4: 12);
            Result.ShouldBe(Expected: 968);

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest.Surround2(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Surround2(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Surround_Action3_0()
            {
            int Result = 0;

            var Test = new Action<int, int, int>((i1, i2, i3) => { Result = i1 + i2 + i3; });
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Action<int, int, int>((i1, i2, i3) => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 5, arg2: 8);
            Result.ShouldBe(Expected: 18);

            // Reset 
            Result = 0;
            Test.Surround2(Test2)(arg1: 8, arg2: 10);
            Result.ShouldBe(Expected: 23);

            // Reset 
            Result = 0;
            Test.Surround3(Test2)(arg1: 8, arg2: 10);
            Result.ShouldBe(Expected: 23);


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
        public void Surround_Action3_1()
            {
            int Result = 0;

            var Test = new Action<int, int, int>((i1, i2, i3) => { Result = i1 + i2 + i3; });
            var Test2 = new Func<int, int>(i => i + 5);
            var BadTest = new Action<int, int, int>((i1, i2, i3) => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 5, arg2: 8, arg3: 10);
            Result.ShouldBe(Expected: 28);

            // Reset 
            Result = 0;
            Test.Surround2(Test2)(arg1: 8, arg2: 10, arg3: 12);
            Result.ShouldBe(Expected: 35);

            // Reset 
            Result = 0;
            Test.Surround3(Test2)(arg1: 8, arg2: 10, arg3: 13);
            Result.ShouldBe(Expected: 36);


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
        public void Surround_Action3_2()
            {
            int Result = 0;

            var Test = new Action<int, int, int>((i1, i2, i3) => { Result = i1 + i2 + i3; });
            var Test2 = new Func<int, int, int>((i1, i2) => i1 * i2 + 5);
            var BadTest = new Action<int, int, int>((i1, i2, i3) => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int>((i1, i2) => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 5, arg2: 8, arg3: 10, arg4: 14);
            Result.ShouldBe(Expected: 158);

            // Reset 
            Result = 0;
            Test.Surround2(Test2)(arg1: 8, arg2: 10, arg3: 12, arg4: 14);
            Result.ShouldBe(Expected: 191);

            // Reset 
            Result = 0;
            Test.Surround3(Test2)(arg1: 8, arg2: 10, arg3: 13, arg4: 15);
            Result.ShouldBe(Expected: 218);

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
        public void Surround_Action4_0()
            {
            int Result = 0;

            var Test = new Action<int, int, int, int>((i1, i2, i3, i4) => { Result = i1 + i2 + i3 + i4; });
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Action<int, int, int, int>((i1, i2, i3, i4) => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 5, arg2: 8, arg3: 10);
            Result.ShouldBe(Expected: 28);

            // Reset 
            Result = 0;
            Test.Surround2(Test2)(arg1: 8, arg2: 10, arg3: 12);
            Result.ShouldBe(Expected: 35);

            // Reset 
            Result = 0;
            Test.Surround3(Test2)(arg1: 8, arg2: 10, arg3: 14);
            Result.ShouldBe(Expected: 37);

            // Reset 
            Result = 0;
            Test.Surround4(Test2)(arg1: 8, arg2: 10, arg3: 15);
            Result.ShouldBe(Expected: 38);


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
        public void Surround_Action4_1()
            {
            int Result = 0;

            var Test = new Action<int, int, int, int>((i1, i2, i3, i4) => { Result = i1 + i2 + i3 + i4; });
            var Test2 = new Func<int, int>(i => i * 5);
            var BadTest = new Action<int, int, int, int>((i1, i2, i3, i4) => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 5, arg2: 8, arg3: 10, arg4: 15);
            Result.ShouldBe(Expected: 98);

            // Reset 
            Result = 0;
            Test.Surround2(Test2)(arg1: 8, arg2: 10, arg3: 12, arg4: 15);
            Result.ShouldBe(Expected: 105);

            // Reset 
            Result = 0;
            Test.Surround3(Test2)(arg1: 8, arg2: 10, arg3: 14, arg4: 15);
            Result.ShouldBe(Expected: 107);

            // Reset 
            Result = 0;
            Test.Surround4(Test2)(arg1: 8, arg2: 10, arg3: 15, arg4: 15);
            Result.ShouldBe(Expected: 108);

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
        public void Surround_Func_0()
            {
            var Test = new Func<int, int>(i => i);
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Func<int, int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test.Surround(Test2)().ShouldBe(Expected: 5);

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)()).ShouldFail();
            L.A(() => Test.Surround(BadTest2)()).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Surround_Func_1()
            {
            var Test = new Func<int, int>(i => i);
            var Test2 = new Func<int, int>(i => i + 5);
            var BadTest = new Func<int, int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test.Surround(Test2)(arg: 5).ShouldBe(Expected: 10);

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Surround_Func_2()
            {
            var Test = new Func<int, int>(i => i);
            var Test2 = new Func<int, int, int>((i1, i2) => i1 * i2 + 5);
            var BadTest = new Action<int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int>((i1, i2) => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 2, arg2: 2).ShouldBe(Expected: 9);

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Surround_Func_3()
            {
            var Test = new Func<int, int>(i => i);
            var Test2 = new Func<int, int, int, int>((i1, i2, i3) => i1 * i2 * i3 + 5);
            var BadTest = new Func<int, int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 2, arg2: 2, arg3: 2).ShouldBe(Expected: 13);

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Surround_Func_4()
            {
            var Test = new Func<int, int>(i => i);
            var Test2 = new Func<int, int, int, int, int>((i1, i2, i3, i4) => i1 * i2 * i3 * i4 + 5);
            var BadTest = new Func<int, int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int, int, int>((i1, i2, i3, i4) => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 2, arg2: 2, arg3: 2, arg4: 2).ShouldBe(Expected: 21);

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Surround_Func2_0()
            {
            var Test = new Func<int, int, int>((i1, i2) => i1 + i2);
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Func<int, int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test.Surround(Test2)(arg: 5).ShouldBe(Expected: 10);

            Test.Surround2(Test2)(arg: 8).ShouldBe(Expected: 13);

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg: 5)).ShouldFail();
            L.A(() => BadTest.Surround2(Test2)(arg: 5)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg: 5)).ShouldFail();
            L.A(() => Test.Surround2(BadTest2)(arg: 5)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Surround_Func2_1()
            {
            var Test = new Func<int, int, int>((i1, i2) => i1 + i2);
            var Test2 = new Func<int, int>(i => i + 5);
            var BadTest = new Func<int, int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 1, arg2: 5).ShouldBe(Expected: 11);

            // Reset 
            Test.Surround2(Test2)(arg1: 3, arg2: 8).ShouldBe(Expected: 16);

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => BadTest.Surround2(Test2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test.Surround2(BadTest2)(arg1: 0, arg2: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Surround_Func2_2()
            {
            var Test = new Func<int, int, int>((i1, i2) => i1 + i2);
            var Test2 = new Func<int, int, int>((i1, i2) => i1 * i2 + 5);
            var BadTest = new Func<int, int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int>((i1, i2) => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 1, arg2: 5, arg3: 6).ShouldBe(Expected: 36);

            Test.Surround2(Test2)(arg1: 3, arg2: 8, arg3: 10).ShouldBe(Expected: 88);

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest.Surround2(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Surround2(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Surround_Func2_3()
            {
            var Test = new Func<int, int, int>((i1, i2) => i1 + i2);
            var Test2 = new Func<int, int, int, int>((i1, i2, i3) => i1 * i2 * i3 + 5);
            var BadTest = new Func<int, int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 1, arg2: 5, arg3: 6, arg4: 8).ShouldBe(Expected: 246);

            Test.Surround2(Test2)(arg1: 3, arg2: 8, arg3: 10, arg4: 12).ShouldBe(Expected: 968);

            // Exceptions are not hidden.
            L.A(() => BadTest.Surround(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest.Surround2(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Surround(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Surround2(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Surround_Func3_0()
            {
            var Test = new Func<int, int, int, int>((i1, i2, i3) => i1 + i2 + i3);
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 5, arg2: 8).ShouldBe(Expected: 18);

            Test.Surround2(Test2)(arg1: 8, arg2: 10).ShouldBe(Expected: 23);

            // Reset 
            Test.Surround3(Test2)(arg1: 8, arg2: 10).ShouldBe(Expected: 23);

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
        public void Surround_Func3_1()
            {
            var Test = new Func<int, int, int, int>((i1, i2, i3) => i1 + i2 + i3);
            var Test2 = new Func<int, int>(i => i + 5);
            var BadTest = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 5, arg2: 8, arg3: 10).ShouldBe(Expected: 28);

            Test.Surround2(Test2)(arg1: 8, arg2: 10, arg3: 12).ShouldBe(Expected: 35);

            Test.Surround3(Test2)(arg1: 8, arg2: 10, arg3: 13).ShouldBe(Expected: 36);

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
        public void Surround_Func3_2()
            {
            var Test = new Func<int, int, int, int>((i1, i2, i3) => i1 + i2 + i3);
            var Test2 = new Func<int, int, int>((i1, i2) => i1 * i2 + 5);
            var BadTest = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int>((i1, i2) => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 5, arg2: 8, arg3: 10, arg4: 14).ShouldBe(Expected: 158);

            Test.Surround2(Test2)(arg1: 8, arg2: 10, arg3: 12, arg4: 14).ShouldBe(Expected: 191);

            Test.Surround3(Test2)(arg1: 8, arg2: 10, arg3: 13, arg4: 15).ShouldBe(Expected: 218);

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
        public void Surround_Func4_0()
            {
            var Test = new Func<int, int, int, int, int>((i1, i2, i3, i4) => i1 + i2 + i3 + i4);
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Func<int, int, int, int, int>((i1, i2, i3, i4) => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 5, arg2: 8, arg3: 10).ShouldBe(Expected: 28);

            Test.Surround2(Test2)(arg1: 8, arg2: 10, arg3: 12).ShouldBe(Expected: 35);

            Test.Surround3(Test2)(arg1: 8, arg2: 10, arg3: 14).ShouldBe(Expected: 37);

            Test.Surround4(Test2)(arg1: 8, arg2: 10, arg3: 15).ShouldBe(Expected: 38);

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
        public void Surround_Func4_1()
            {
            var Test = new Func<int, int, int, int, int>((i1, i2, i3, i4) => i1 + i2 + i3 + i4);
            var Test2 = new Func<int, int>(i => i * 5);
            var BadTest = new Func<int, int, int, int, int>((i1, i2, i3, i4) => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test.Surround(Test2)(arg1: 5, arg2: 8, arg3: 10, arg4: 15).ShouldBe(Expected: 98);

            Test.Surround2(Test2)(arg1: 8, arg2: 10, arg3: 12, arg4: 15).ShouldBe(Expected: 105);

            Test.Surround3(Test2)(arg1: 8, arg2: 10, arg3: 14, arg4: 15).ShouldBe(Expected: 107);

            Test.Surround4(Test2)(arg1: 8, arg2: 10, arg3: 15, arg4: 15).ShouldBe(Expected: 108);

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
            nameof(LogicExt.Enclose2) + "(Func<T4, T5, T2>, Action<T1, T2, T3>) => Action<T1, T3, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose3) + "(Func<T4, T5, T3>, Action<T1, T2, T3>) => Action<T1, T2, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T1>, Action<T1, T2, T3, T4>) => Action<T2, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func<T2>, Action<T1, T2, T3, T4>) => Action<T1, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose3) + "(Func<T3>, Action<T1, T2, T3, T4>) => Action<T1, T2, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose4) + "(Func<T4>, Action<T1, T2, T3, T4>) => Action<T1, T2, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T5, T1>, Action<T1, T2, T3, T4>) => Action<T2, T3, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func<T5, T2>, Action<T1, T2, T3, T4>) => Action<T1, T3, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose3) + "(Func<T5, T3>, Action<T1, T2, T3, T4>) => Action<T1, T2, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose4) + "(Func<T5, T4>, Action<T1, T2, T3, T4>) => Action<T1, T2, T3, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T1>, Func<T1, U>) => Func<U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T1, T2>, Func<T2, U>) => Func<T1, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T1, T2, T3>, Func<T3, U>) => Func<T1, T2, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T1, T2, T3, T4>, Func<T4, U>) => Func<T1, T2, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T1, T2, T3, T4, T5>, Func<T5, U>) => Func<T1, T2, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T1>, Func<T1, T2, U>) => Func<T2, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func<T2>, Func<T1, T2, U>) => Func<T1, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T3, T1>, Func<T1, T2, U>) => Func<T2, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func<T3, T2>, Func<T1, T2, U>) => Func<T1, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T3, T4, T1>, Func<T1, T2, U>) => Func<T2, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func<T3, T4, T2>, Func<T1, T2, U>) => Func<T1, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T3, T4, T5, T1>, Func<T1, T2, U>) => Func<T2, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func<T3, T4, T5, T2>, Func<T1, T2, U>) => Func<T1, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T1>, Func<T1, T2, T3, U>) => Func<T2, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func<T2>, Func<T1, T2, T3, U>) => Func<T1, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose3) + "(Func<T3>, Func<T1, T2, T3, U>) => Func<T1, T2, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T4, T1>, Func<T1, T2, T3, U>) => Func<T2, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func<T4, T2>, Func<T1, T2, T3, U>) => Func<T1, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose3) + "(Func<T4, T3>, Func<T1, T2, T3, U>) => Func<T1, T2, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T4, T5, T1>, Func<T1, T2, T3, U>) => Func<T2, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func<T4, T5, T2>, Func<T1, T2, T3, U>) => Func<T1, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose3) + "(Func<T4, T5, T3>, Func<T1, T2, T3, U>) => Func<T1, T2, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T1>, Func<T1, T2, T3, T4, U>) => Func<T2, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func<T2>, Func<T1, T2, T3, T4, U>) => Func<T1, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose3) + "(Func<T3>, Func<T1, T2, T3, T4, U>) => Func<T1, T2, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose4) + "(Func<T4>, Func<T1, T2, T3, T4, U>) => Func<T1, T2, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T5, T1>, Func<T1, T2, T3, T4, U>) => Func<T2, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func<T5, T2>, Func<T1, T2, T3, T4, U>) => Func<T1, T3, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose3) + "(Func<T5, T3>, Func<T1, T2, T3, T4, U>) => Func<T1, T2, T4, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose4) + "(Func<T5, T4>, Func<T1, T2, T3, T4, U>) => Func<T1, T2, T3, T5, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T1>, Action<T1>) => Action")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T2, T1>, Action<T1>) => Action<T2>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T2, T3, T1>, Action<T1>) => Action<T2, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T2, T3, T4, T1>, Action<T1>) => Action<T2, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T2, T3, T4, T5, T1>, Action<T1>) => Action<T2, T3, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T1>, Action<T1, T2>) => Action<T2>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func<T2>, Action<T1, T2>) => Action<T1>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T3, T1>, Action<T1, T2>) => Action<T2, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func<T3, T2>, Action<T1, T2>) => Action<T1, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T3, T4, T1>, Action<T1, T2>) => Action<T2, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func<T3, T4, T2>, Action<T1, T2>) => Action<T1, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T3, T4, T5, T1>, Action<T1, T2>) => Action<T2, T3, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func<T3, T4, T5, T2>, Action<T1, T2>) => Action<T1, T3, T4, T5>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T1>, Action<T1, T2, T3>) => Action<T2, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func<T2>, Action<T1, T2, T3>) => Action<T1, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose3) + "(Func<T3>, Action<T1, T2, T3>) => Action<T1, T2>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T4, T1>, Action<T1, T2, T3>) => Action<T2, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose2) + "(Func<T4, T2>, Action<T1, T2, T3>) => Action<T1, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose3) + "(Func<T4, T3>, Action<T1, T2, T3>) => Action<T1, T2, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LogicExt) + "." +
            nameof(LogicExt.Enclose) + "(Func<T4, T5, T1>, Action<T1, T2, T3>) => Action<T2, T3, T4, T5>")]
        public void Enclose_Action_0()
            {
            int Result = 0;

            var Test = new Action<int>(i => { Result = i; });
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Action<int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test2.Enclose(Test)();
            Result.ShouldBe(Expected: 5);

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)()).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)()).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Enclose_Action_1()
            {
            int Result = 0;

            var Test = new Action<int>(i => { Result = i; });
            var Test2 = new Func<int, int>(i => i + 5);
            var BadTest = new Action<int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test2.Enclose(Test)(obj: 5);
            Result.ShouldBe(Expected: 10);

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(obj: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(obj: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Enclose_Action_2()
            {
            int Result = 0;

            var Test = new Action<int>(i => { Result = i; });
            var Test2 = new Func<int, int, int>((i1, i2) => i1 * i2 + 5);
            var BadTest = new Action<int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int>((i1, i2) => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 2, arg2: 2);
            Result.ShouldBe(Expected: 9);

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Enclose_Action_3()
            {
            int Result = 0;

            var Test = new Action<int>(i => { Result = i; });
            var Test2 = new Func<int, int, int, int>((i1, i2, i3) => i1 * i2 * i3 + 5);
            var BadTest = new Action<int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 2, arg2: 2, arg3: 2);
            Result.ShouldBe(Expected: 13);

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Enclose_Action_4()
            {
            int Result = 0;

            var Test = new Action<int>(i => { Result = i; });
            var Test2 = new Func<int, int, int, int, int>((i1, i2, i3, i4) => i1 * i2 * i3 * i4 + 5);
            var BadTest = new Action<int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int, int, int>((i1, i2, i3, i4) => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 2, arg2: 2, arg3: 2, arg4: 2);
            Result.ShouldBe(Expected: 21);

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Enclose_Action2_0()
            {
            int Result = 0;

            var Test = new Action<int, int>((i1, i2) => { Result = i1 + i2; });
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Action<int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test2.Enclose(Test)(obj: 5);
            Result.ShouldBe(Expected: 10);

            // Reset 
            Result = 0;
            Test2.Enclose2(Test)(obj: 8);
            Result.ShouldBe(Expected: 13);
            
            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(obj: 5)).ShouldFail();
            L.A(() => Test2.Enclose2(BadTest)(obj: 5)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(obj: 5)).ShouldFail();
            L.A(() => BadTest2.Enclose2(Test)(obj: 5)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Enclose_Action2_1()
            {
            int Result = 0;

            var Test = new Action<int, int>((i1, i2) => { Result = i1 + i2; });
            var Test2 = new Func<int, int>(i => i + 5);
            var BadTest = new Action<int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 1, arg2: 5);
            Result.ShouldBe(Expected: 11);

            // Reset 
            Result = 0;
            Test2.Enclose2(Test)(arg1: 3, arg2: 8);
            Result.ShouldBe(Expected: 16);
            
            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test2.Enclose2(BadTest)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose2(Test)(arg1: 0, arg2: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Enclose_Action2_2()
            {
            int Result = 0;

            var Test = new Action<int, int>((i1, i2) => { Result = i1 + i2; });
            var Test2 = new Func<int, int, int>((i1, i2) => i1 * i2 + 5);
            var BadTest = new Action<int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int>((i1, i2) => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 1, arg2: 5, arg3: 6);
            Result.ShouldBe(Expected: 36);

            // Reset 
            Result = 0;
            Test2.Enclose2(Test)(arg1: 3, arg2: 8, arg3: 10);
            Result.ShouldBe(Expected: 88);
            
            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test2.Enclose2(BadTest)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose2(Test)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Enclose_Action2_3()
            {
            int Result = 0;

            var Test = new Action<int, int>((i1, i2) => { Result = i1 + i2; });
            var Test2 = new Func<int, int, int, int>((i1, i2, i3) => i1 * i2 * i3 + 5);
            var BadTest = new Action<int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 1, arg2: 5, arg3: 6, arg4: 8);
            Result.ShouldBe(Expected: 246);

            // Reset 
            Result = 0;
            Test2.Enclose2(Test)(arg1: 3, arg2: 8, arg3: 10, arg4: 12);
            Result.ShouldBe(Expected: 968);

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test2.Enclose2(BadTest)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose2(Test)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Enclose_Action3_0()
            {
            int Result = 0;

            var Test = new Action<int, int, int>((i1, i2, i3) => { Result = i1 + i2 + i3; });
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Action<int, int, int>((i1, i2, i3) => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 5, arg2: 8);
            Result.ShouldBe(Expected: 18);

            // Reset 
            Result = 0;
            Test2.Enclose2(Test)(arg1: 8, arg2: 10);
            Result.ShouldBe(Expected: 23);

            // Reset 
            Result = 0;
            Test2.Enclose3(Test)(arg1: 8, arg2: 10);
            Result.ShouldBe(Expected: 23);

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
        public void Enclose_Action3_1()
            {
            int Result = 0;

            var Test = new Action<int, int, int>((i1, i2, i3) => { Result = i1 + i2 + i3; });
            var Test2 = new Func<int, int>(i => i + 5);
            var BadTest = new Action<int, int, int>((i1, i2, i3) => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 5, arg2: 8, arg3: 10);
            Result.ShouldBe(Expected: 28);

            // Reset 
            Result = 0;
            Test2.Enclose2(Test)(arg1: 8, arg2: 10, arg3: 12);
            Result.ShouldBe(Expected: 35);

            // Reset 
            Result = 0;
            Test2.Enclose3(Test)(arg1: 8, arg2: 10, arg3: 13);
            Result.ShouldBe(Expected: 36);

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
        public void Enclose_Action3_2()
            {
            int Result = 0;

            var Test = new Action<int, int, int>((i1, i2, i3) => { Result = i1 + i2 + i3; });
            var Test2 = new Func<int, int, int>((i1, i2) => i1 * i2 + 5);
            var BadTest = new Action<int, int, int>((i1, i2, i3) => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int>((i1, i2) => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 5, arg2: 8, arg3: 10, arg4: 14);
            Result.ShouldBe(Expected: 158);

            // Reset 
            Result = 0;
            Test2.Enclose2(Test)(arg1: 8, arg2: 10, arg3: 12, arg4: 14);
            Result.ShouldBe(Expected: 191);

            // Reset 
            Result = 0;
            Test2.Enclose3(Test)(arg1: 8, arg2: 10, arg3: 13, arg4: 15);
            Result.ShouldBe(Expected: 218);
            

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
        public void Enclose_Action4_0()
            {
            int Result = 0;

            var Test = new Action<int, int, int, int>((i1, i2, i3, i4) => { Result = i1 + i2 + i3 + i4; });
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Action<int, int, int, int>((i1, i2, i3, i4) => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 5, arg2: 8, arg3: 10);
            Result.ShouldBe(Expected: 28);

            // Reset 
            Result = 0;
            Test2.Enclose2(Test)(arg1: 8, arg2: 10, arg3: 12);
            Result.ShouldBe(Expected: 35);

            // Reset 
            Result = 0;
            Test2.Enclose3(Test)(arg1: 8, arg2: 10, arg3: 14);
            Result.ShouldBe(Expected: 37);

            // Reset 
            Result = 0;
            Test2.Enclose4(Test)(arg1: 8, arg2: 10, arg3: 15);
            Result.ShouldBe(Expected: 38);

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
        public void Enclose_Action4_1()
            {
            int Result = 0;

            var Test = new Action<int, int, int, int>((i1, i2, i3, i4) => { Result = i1 + i2 + i3 + i4; });
            var Test2 = new Func<int, int>(i => i * 5);
            var BadTest = new Action<int, int, int, int>((i1, i2, i3, i4) => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 5, arg2: 8, arg3: 10, arg4: 15);
            Result.ShouldBe(Expected: 98);

            // Reset 
            Result = 0;
            Test2.Enclose2(Test)(arg1: 8, arg2: 10, arg3: 12, arg4: 15);
            Result.ShouldBe(Expected: 105);

            // Reset 
            Result = 0;
            Test2.Enclose3(Test)(arg1: 8, arg2: 10, arg3: 14, arg4: 15);
            Result.ShouldBe(Expected: 107);

            // Reset 
            Result = 0;
            Test2.Enclose4(Test)(arg1: 8, arg2: 10, arg3: 15, arg4: 15);
            Result.ShouldBe(Expected: 108);

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
        public void Enclose_Func_0()
            {
            var Test = new Func<int, int>(i => i);
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Func<int, int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test2.Enclose(Test)().ShouldBe(Expected: 5);

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)()).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)()).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Enclose_Func_1()
            {
            var Test = new Func<int, int>(i => i);
            var Test2 = new Func<int, int>(i => i + 5);
            var BadTest = new Func<int, int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test.Enclose(Test2)(arg: 5).ShouldBe(Expected: 10);

            // Exceptions are not hidden.
            L.A(() => BadTest.Enclose(Test2)(arg: 0)).ShouldFail();
            L.A(() => Test.Enclose(BadTest2)(arg: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Enclose_Func_2()
            {
            var Test = new Func<int, int>(i => i);
            var Test2 = new Func<int, int, int>((i1, i2) => i1 * i2 + 5);
            var BadTest = new Action<int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int>((i1, i2) => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 2, arg2: 2).ShouldBe(Expected: 9);

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Enclose_Func_3()
            {
            var Test = new Func<int, int>(i => i);
            var Test2 = new Func<int, int, int, int>((i1, i2, i3) => i1 * i2 * i3 + 5);
            var BadTest = new Func<int, int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 2, arg2: 2, arg3: 2).ShouldBe(Expected: 13);

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Enclose_Func_4()
            {
            var Test = new Func<int, int>(i => i);
            var Test2 = new Func<int, int, int, int, int>((i1, i2, i3, i4) => i1 * i2 * i3 * i4 + 5);
            var BadTest = new Func<int, int>(i => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int, int, int>((i1, i2, i3, i4) => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 2, arg2: 2, arg3: 2, arg4: 2).ShouldBe(Expected: 21);
            
            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Enclose_Func2_0()
            {
            var Test = new Func<int, int, int>((i1, i2) => i1 + i2);
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Func<int, int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test2.Enclose(Test)(arg: 5).ShouldBe(Expected: 10);

            Test2.Enclose2(Test)(arg: 8).ShouldBe(Expected: 13);
            

            // Exceptions are not hidden.
            L.A(() => Test2.Enclose(BadTest)(arg: 5)).ShouldFail();
            L.A(() => Test2.Enclose2(BadTest)(arg: 5)).ShouldFail();
            L.A(() => BadTest2.Enclose(Test)(arg: 5)).ShouldFail();
            L.A(() => BadTest2.Enclose2(Test)(arg: 5)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Enclose_Func2_1()
            {
            var Test = new Func<int, int, int>((i1, i2) => i1 + i2);
            var Test2 = new Func<int, int>(i => i + 5);
            var BadTest = new Func<int, int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 1, arg2: 5).ShouldBe(Expected: 11);

            // Reset 
            Test2.Enclose2(Test)(arg1: 3, arg2: 8).ShouldBe(Expected: 16);

            // Exceptions are not hidden.
            L.A(() => BadTest.Enclose(Test2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test2.Enclose2(BadTest)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => Test.Enclose(BadTest2)(arg1: 0, arg2: 0)).ShouldFail();
            L.A(() => BadTest2.Enclose2(Test)(arg1: 0, arg2: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Enclose_Func2_2()
            {
            var Test = new Func<int, int, int>((i1, i2) => i1 + i2);
            var Test2 = new Func<int, int, int>((i1, i2) => i1 * i2 + 5);
            var BadTest = new Func<int, int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int>((i1, i2) => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 1, arg2: 5, arg3: 6).ShouldBe(Expected: 36);

            Test2.Enclose2(Test)(arg1: 3, arg2: 8, arg3: 10).ShouldBe(Expected: 88);

            // Exceptions are not hidden.
            L.A(() => BadTest.Enclose(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => BadTest.Enclose2(Test2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Enclose(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            L.A(() => Test.Enclose2(BadTest2)(arg1: 0, arg2: 0, arg3: 0)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Enclose_Func2_3()
            {
            var Test = new Func<int, int, int>((i1, i2) => i1 + i2);
            var Test2 = new Func<int, int, int, int>((i1, i2, i3) => i1 * i2 * i3 + 5);
            var BadTest = new Func<int, int, int>((i1, i2) => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 1, arg2: 5, arg3: 6, arg4: 8).ShouldBe(Expected: 246);

            Test2.Enclose2(Test)(arg1: 3, arg2: 8, arg3: 10, arg4: 12).ShouldBe(Expected: 968);

            // Exceptions are not hidden.
            L.A(() => BadTest.Enclose(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => BadTest.Enclose2(Test2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Enclose(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            L.A(() => Test.Enclose2(BadTest2)(arg1: 0, arg2: 0, arg3: 0, arg4: 0)).ShouldFail();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Enclose_Func3_0()
            {
            var Test = new Func<int, int, int, int>((i1, i2, i3) => i1 + i2 + i3);
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 5, arg2: 8).ShouldBe(Expected: 18);

            Test2.Enclose2(Test)(arg1: 8, arg2: 10).ShouldBe(Expected: 23);

            Test2.Enclose3(Test)(arg1: 8, arg2: 10).ShouldBe(Expected: 23);


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
        public void Enclose_Func3_1()
            {
            var Test = new Func<int, int, int, int>((i1, i2, i3) => i1 + i2 + i3);
            var Test2 = new Func<int, int>(i => i + 5);
            var BadTest = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 5, arg2: 8, arg3: 10).ShouldBe(Expected: 28);

            Test2.Enclose2(Test)(arg1: 8, arg2: 10, arg3: 12).ShouldBe(Expected: 35);

            Test2.Enclose3(Test)(arg1: 8, arg2: 10, arg3: 13).ShouldBe(Expected: 36);

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
        public void Enclose_Func3_2()
            {
            var Test = new Func<int, int, int, int>((i1, i2, i3) => i1 + i2 + i3);
            var Test2 = new Func<int, int, int>((i1, i2) => i1 * i2 + 5);
            var BadTest = new Func<int, int, int, int>((i1, i2, i3) => { throw new Exception(); });
            var BadTest2 = new Func<int, int, int>((i1, i2) => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 5, arg2: 8, arg3: 10, arg4: 14).ShouldBe(Expected: 158);

            Test2.Enclose2(Test)(arg1: 8, arg2: 10, arg3: 12, arg4: 14).ShouldBe(Expected: 191);

            Test2.Enclose3(Test)(arg1: 8, arg2: 10, arg3: 13, arg4: 15).ShouldBe(Expected: 218);

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
        public void Enclose_Func4_0()
            {
            var Test = new Func<int, int, int, int, int>((i1, i2, i3, i4) => i1 + i2 + i3 + i4);
            var Test2 = new Func<int>(() => 5);
            var BadTest = new Func<int, int, int, int, int>((i1, i2, i3, i4) => { throw new Exception(); });
            var BadTest2 = new Func<int>(() => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 5, arg2: 8, arg3: 10).ShouldBe(Expected: 28);

            Test2.Enclose2(Test)(arg1: 8, arg2: 10, arg3: 12).ShouldBe(Expected: 35);

            Test2.Enclose3(Test)(arg1: 8, arg2: 10, arg3: 14).ShouldBe(Expected: 37);

            Test2.Enclose4(Test)(arg1: 8, arg2: 10, arg3: 15).ShouldBe(Expected: 38);


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
        public void Enclose_Func4_1()
            {
            var Test = new Func<int, int, int, int, int>((i1, i2, i3, i4) => i1 + i2 + i3 + i4);
            var Test2 = new Func<int, int>(i => i * 5);
            var BadTest = new Func<int, int, int, int, int>((i1, i2, i3, i4) => { throw new Exception(); });
            var BadTest2 = new Func<int, int>(i => { throw new Exception(); });

            Test2.Enclose(Test)(arg1: 5, arg2: 8, arg3: 10, arg4: 15).ShouldBe(Expected: 98);

            Test2.Enclose2(Test)(arg1: 8, arg2: 10, arg3: 12, arg4: 15).ShouldBe(Expected: 105);

            Test2.Enclose3(Test)(arg1: 8, arg2: 10, arg3: 14, arg4: 15).ShouldBe(Expected: 107);

            Test2.Enclose4(Test)(arg1: 8, arg2: 10, arg3: 15, arg4: 15).ShouldBe(Expected: 108);



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