using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using Xunit;
using Xunit.Abstractions;
using static LCore.LUnit.LUnit.Categories;

// ReSharper disable RedundantCast

namespace LCore.Tests.Extensions
    {
    [Trait(Category, UnitTests)]
    public class LogicExtTest : XUnitOutputTester
        {
        private static readonly string _TestString = Guid.NewGuid().ToString();
        

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
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

        [Fact]
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
            }

        [Fact]
        public void Test_L_A_1()
            {
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
            }

        [Fact]
        public void Test_L_F_1()
            {
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

        #region Surround

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
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

        public LogicExtTest([NotNull] ITestOutputHelper Output) : base(Output) { }
        }
    }