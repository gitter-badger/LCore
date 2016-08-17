using System;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable ConvertToLambdaExpression

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt))]
    public partial class ExceptionExtTester : XUnitOutputTester, IDisposable
        {
        private static readonly string _TestString = Guid.NewGuid().ToString();

        public ExceptionExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Try) + "(Action) => Func<Boolean>")]
        public void Try_Action_0()
            {
            var A = new Action(() => { });
            var B = new Action(() => { throw new Exception(); });

            // Both actions don't fail.
            bool Result = A.Try()();
            bool Result2 = B.Try()();

            // Result was true
            Result.ShouldBeTrue();

            // Result was false
            Result2.ShouldBeFalse();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Try) + "(Action<T1>) => Func<T1, Boolean>")]
        public void Try_Action_1()
            {
            var A = new Action<string>(o => { o.ShouldBe(_TestString); });
            var B = new Action<string>(o =>
                {
                    o.ShouldBe(_TestString);

                    throw new Exception();
                });

            // Both actions don't fail.
            bool Result = A.Try()(_TestString);
            bool Result2 = B.Try()(_TestString);

            // Result was true
            Result.ShouldBeTrue();

            // Result was false
            Result2.ShouldBeFalse();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Try) + "(Action<T1, T2>) => Func<T1, T2, Boolean>")]
        public void Try_Action_2()
            {
            var A = new Action<string, string>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                });
            var B = new Action<string, string>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);

                    throw new Exception();
                });

            // Both actions don't fail.
            bool Result = A.Try()(_TestString, _TestString);
            bool Result2 = B.Try()(_TestString, _TestString);

            // Result was true
            Result.ShouldBeTrue();

            // Result was false
            Result2.ShouldBeFalse();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Try) + "(Action<T1, T2, T3>) => Func<T1, T2, T3, Boolean>")]
        public void Try_Action_3()
            {
            var A = new Action<string, string, string>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                });
            var B = new Action<string, string, string>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);

                    throw new Exception();
                });

            // Both actions don't fail.
            bool Result = A.Try()(_TestString, _TestString, _TestString);
            bool Result2 = B.Try()(_TestString, _TestString, _TestString);

            // Result was true
            Result.ShouldBeTrue();

            // Result was false
            Result2.ShouldBeFalse();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Try) + "(Action<T1, T2, T3, T4>) => Func<T1, T2, T3, T4, Boolean>")]
        public void Try_Action_4()
            {
            var A = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    o4.ShouldBe(_TestString);
                });
            var B = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    o4.ShouldBe(_TestString);

                    throw new Exception();
                });

            // Both actions don't fail.
            bool Result = A.Try()(_TestString, _TestString, _TestString, _TestString);
            bool Result2 = B.Try()(_TestString, _TestString, _TestString, _TestString);

            // Result was true
            Result.ShouldBeTrue();

            // Result was false
            Result2.ShouldBeFalse();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Try) + "(Func<U>) => Func<U>")]
        public void Try_Func_0()
            {
            var A = new Func<int>(() => { return 5; });
            var B = new Func<int>(() => { throw new Exception(); });

            // Both actions don't fail.
            int Result = A.Try()();
            int Result2 = B.Try()();

            // Result was true
            Result.ShouldBe(Compare: 5);

            // Result was false
            Result2.ShouldBe(default(int));
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Try) + "(Func<T1, U>) => Func<T1, U>")]
        public void Try_Func_1()
            {
            var A = new Func<string, int>(o =>
                {
                    o.ShouldBe(_TestString);
                    return 5;
                });
            var B = new Func<string, int>(o =>
                {
                    o.ShouldBe(_TestString);

                    throw new Exception();
                });

            // Both actions don't fail.
            int Result = A.Try()(_TestString);
            int Result2 = B.Try()(_TestString);

            // Result was true
            Result.ShouldBe(Compare: 5);

            // Result was false
            Result2.ShouldBe(default(int));
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Try) + "(Func<T1, T2, U>) => Func<T1, T2, U>")]
        public void Try_Func_2()
            {
            var A = new Func<string, string, int>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    return 5;
                });
            var B = new Func<string, string, int>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);

                    throw new Exception();
                });

            // Both actions don't fail.
            int Result = A.Try()(_TestString, _TestString);
            int Result2 = B.Try()(_TestString, _TestString);

            // Result was true
            Result.ShouldBe(Compare: 5);

            // Result was false
            Result2.ShouldBe(default(int));
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Try) + "(Func<T1, T2, T3, U>) => Func<T1, T2, T3, U>")]
        public void Try_Func_3()
            {
            var A = new Func<string, string, string, int>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    return 5;
                });
            var B = new Func<string, string, string, int>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);

                    throw new Exception();
                });

            // Both actions don't fail.
            int Result = A.Try()(_TestString, _TestString, _TestString);
            int Result2 = B.Try()(_TestString, _TestString, _TestString);

            // Result was true
            Result.ShouldBe(Compare: 5);

            // Result was false
            Result2.ShouldBe(default(int));
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Try) + "(Func<T1, T2, T3, T4, U>) => Func<T1, T2, T3, T4, U>")]
        public void Try_Func_4()
            {
            var A = new Func<string, string, string, string, int>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    o4.ShouldBe(_TestString);
                    return 5;
                });
            var B = new Func<string, string, string, string, int>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    o4.ShouldBe(_TestString);

                    throw new Exception();
                });

            // Both actions don't fail.
            int Result = A.Try()(_TestString, _TestString, _TestString, _TestString);
            int Result2 = B.Try()(_TestString, _TestString, _TestString, _TestString);

            // Result was true
            Result.ShouldBe(Compare: 5);

            // Result was false
            Result2.ShouldBe(default(int));
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Retry) + "(Action, Int32) => Action")]
        public void Retry_0()
            {
            int I = 0;
            var Test = new Action(() =>
                {
                    I++;
                    if (I < 5)
                        throw new ArgumentException();
                });

            Test.Retry(Tries: 3).ShouldFail<ArgumentException>();

            // Reset
            I = 0;
            Test.Retry(Tries: 4)();
            I.ShouldBe(Compare: 5);

            L.A(() => Test.Retry(Tries: 0)).ShouldFail();
            L.A(() => Test.Retry(-1)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Retry) + "(Action<T>, Int32) => Action<T>")]
        public void Retry_Action_1()
            {
            int I = 0;
            var Test = new Action<string>(o =>
                {
                    o.ShouldBe(_TestString);

                    I++;
                    if (I < 5)
                        throw new ArgumentException();
                });

            Test.Retry(Tries: 3).ShouldFail<string, ArgumentException>(_TestString);

            // Reset
            I = 0;
            Test.Retry(Tries: 4)(_TestString);
            I.ShouldBe(Compare: 5);

            L.A(() => Test.Retry(Tries: 0)).ShouldFail();
            L.A(() => Test.Retry(-1)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Retry) + "(Action<T1, T2>, Int32) => Action<T1, T2>")]
        public void Retry_Action_2()
            {
            int I = 0;
            var Test = new Action<string, string>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);

                    I++;
                    if (I < 5)
                        throw new ArgumentException();
                });

            Test.Retry(Tries: 3).ShouldFail<string, string, ArgumentException>(_TestString, _TestString);

            // Reset
            I = 0;
            Test.Retry(Tries: 4)(_TestString, _TestString);
            I.ShouldBe(Compare: 5);

            L.A(() => Test.Retry(Tries: 0)).ShouldFail();
            L.A(() => Test.Retry(-1)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Retry) + "(Action<T1, T2, T3>, Int32) => Action<T1, T2, T3>")]
        public void Retry_Action_3()
            {
            int I = 0;
            var Test = new Action<string, string, string>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);

                    I++;
                    if (I < 5)
                        throw new ArgumentException();
                });

            Test.Retry(Tries: 3).ShouldFail<string, string, string, ArgumentException>(_TestString, _TestString, _TestString);

            // Reset
            I = 0;
            Test.Retry(Tries: 4)(_TestString, _TestString, _TestString);
            I.ShouldBe(Compare: 5);

            L.A(() => Test.Retry(Tries: 0)).ShouldFail();
            L.A(() => Test.Retry(-1)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Retry) + "(Action<T1, T2, T3, T4>, Int32) => Action<T1, T2, T3, T4>")]
        public void Retry_Action_4()
            {
            int I = 0;
            var Test = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    o4.ShouldBe(_TestString);

                    I++;
                    if (I < 5)
                        throw new ArgumentException();
                });

            Test.Retry(Tries: 3).ShouldFail<string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString, _TestString);

            // Reset
            I = 0;
            Test.Retry(Tries: 4)(_TestString, _TestString, _TestString, _TestString);
            I.ShouldBe(Compare: 5);

            L.A(() => Test.Retry(Tries: 0)).ShouldFail();
            L.A(() => Test.Retry(-1)).ShouldFail();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Retry) + "(Func<U>, Int32) => Func<U>")]
        public void Retry_Func_0()
            {
            int I = 0;
            var Test = new Func<string>(() =>
                {
                    I++;
                    if (I < 5)
                        throw new ArgumentException();

                    return _TestString;
                });

            Test.Retry(Tries: 3).ShouldFail<string, ArgumentException>();

            // Reset
            I = 0;
            Test.Retry(Tries: 4)().ShouldBe(_TestString);
            I.ShouldBe(Compare: 5);

            L.F(() => Test.Retry(Tries: 0)).ShouldFail();
            L.F(() => Test.Retry(-1)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Retry) + "(Func<T1, U>, Int32) => Func<T1, U>")]
        public void Retry_Func_1()
            {
            int I = 0;
            var Test = new Func<string, string>(o =>
                {
                    o.ShouldBe(_TestString);

                    I++;
                    if (I < 5)
                        throw new ArgumentException();

                    return _TestString;
                });

            Test.Retry(Tries: 3).ShouldFail<string, string, ArgumentException>(_TestString);

            // Reset
            I = 0;
            Test.Retry(Tries: 4)(_TestString);
            I.ShouldBe(Compare: 5);

            L.F(() => Test.Retry(Tries: 0)).ShouldFail();
            L.F(() => Test.Retry(-1)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Retry) + "(Func<T1, T2, U>, Int32) => Func<T1, T2, U>")]
        public void Retry_Func_2()
            {
            int I = 0;
            var Test = new Func<string, string, string>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);

                    I++;
                    if (I < 5)
                        throw new ArgumentException();

                    return _TestString;
                });

            Test.Retry(Tries: 3).ShouldFail<string, string, string, ArgumentException>(_TestString, _TestString);

            // Reset
            I = 0;
            Test.Retry(Tries: 4)(_TestString, _TestString);
            I.ShouldBe(Compare: 5);

            L.F(() => Test.Retry(Tries: 0)).ShouldFail();
            L.F(() => Test.Retry(-1)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Retry) + "(Func<T1, T2, T3, U>, Int32) => Func<T1, T2, T3, U>")]
        public void Retry_Func_3()
            {
            int I = 0;
            var Test = new Func<string, string, string, string>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);

                    I++;
                    if (I < 5)
                        throw new ArgumentException();

                    return _TestString;
                });

            Test.Retry(Tries: 3).ShouldFail<string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString);

            // Reset
            I = 0;
            Test.Retry(Tries: 4)(_TestString, _TestString, _TestString);
            I.ShouldBe(Compare: 5);

            L.F(() => Test.Retry(Tries: 0)).ShouldFail();
            L.F(() => Test.Retry(-1)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Retry) + "(Func<T1, T2, T3, T4, U>, Int32) => Func<T1, T2, T3, T4, U>")]
        public void Retry_Func_4()
            {
            int I = 0;
            var Test = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    o4.ShouldBe(_TestString);

                    I++;
                    if (I < 5)
                        throw new ArgumentException();

                    return _TestString;
                });

            Test.Retry(Tries: 3)
                .ShouldFail<string, string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString, _TestString);

            // Reset
            I = 0;
            Test.Retry(Tries: 4)(_TestString, _TestString, _TestString, _TestString);
            I.ShouldBe(Compare: 5);

            L.F(() => Test.Retry(Tries: 0)).ShouldFail();
            L.F(() => Test.Retry(-1)).ShouldFail();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Action, Action<E>) => Action")]
        public void Catch_Exception_Action_0()
            {
            var Test = new Action(() => { throw new ArgumentException(); });
            var Test2 = new Action(() => { });
            var Handler = new Action<Exception>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                });
            var Rethrow_Handler = new Action<Exception>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw Ex;
                });

            Test.Catch(Handler)();
            Test2.Catch(Handler)();

            Test.Catch(Rethrow_Handler).ShouldFail<ArgumentException>();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Action<T1>, Action<E>) => Action<T1>")]
        public void Catch_Exception_Action_1()
            {
            var Test = new Action<string>(o =>
                {
                    o.ShouldBe(_TestString);
                    throw new ArgumentException();
                });
            var Test2 = new Action<string>(o => { o.ShouldBe(_TestString); });
            var Handler = new Action<Exception>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                });
            var Rethrow_Handler = new Action<Exception>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw Ex;
                });

            Test.Catch(Handler)(_TestString);
            Test2.Catch(Handler)(_TestString);

            Test.Catch(Rethrow_Handler).ShouldFail<string, ArgumentException>(_TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Action<T1, T2>, Action<E>) => Action<T1, T2>")]
        public void Catch_Exception_Action_2()
            {
            var Test = new Action<string, string>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    throw new ArgumentException();
                });
            var Test2 = new Action<string, string>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                });
            var Handler = new Action<Exception>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                });
            var Rethrow_Handler = new Action<Exception>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw Ex;
                });

            Test.Catch(Handler)(_TestString, _TestString);
            Test2.Catch(Handler)(_TestString, _TestString);

            Test.Catch(Rethrow_Handler).ShouldFail<string, string, ArgumentException>(_TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Action<T1, T2, T3>, Action<E>) => Action<T1, T2, T3>")]
        public void Catch_Exception_Action_3()
            {
            var Test = new Action<string, string, string>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    throw new ArgumentException();
                });
            var Test2 = new Action<string, string, string>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                });
            var Handler = new Action<Exception>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                });
            var Rethrow_Handler = new Action<Exception>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw Ex;
                });

            Test.Catch(Handler)(_TestString, _TestString, _TestString);
            Test2.Catch(Handler)(_TestString, _TestString, _TestString);

            Test.Catch(Rethrow_Handler).ShouldFail<string, string, string, ArgumentException>(_TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Action<T1, T2, T3, T4>, Action<E>) => Action<T1, T2, T3, T4>")]
        public void Catch_Exception_Action_4()
            {
            var Test = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    o4.ShouldBe(_TestString);
                    throw new ArgumentException();
                });
            var Test2 = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    o4.ShouldBe(_TestString);
                });
            var Handler = new Action<Exception>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                });
            var Rethrow_Handler = new Action<Exception>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw Ex;
                });

            Test.Catch(Handler)(_TestString, _TestString, _TestString, _TestString);
            Test2.Catch(Handler)(_TestString, _TestString, _TestString, _TestString);

            Test.Catch(Rethrow_Handler)
                .ShouldFail<string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Func<U>, Action<Exception>) => Func<U>")]
        public void Catch_Exception_Func_0()
            {
            var Test = new Func<string>(() => { throw new ArgumentException(); });
            var Test2 = new Func<string>(() => { return _TestString; });
            var Handler = new Action<Exception>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                });
            var Rethrow_Handler = new Action<Exception>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw Ex;
                });

            Test.Catch(Handler)();
            Test2.Catch(Handler)().ShouldBe(_TestString);

            Test.Catch(Rethrow_Handler).ShouldFail<string, ArgumentException>();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Func<T1, U>, Action<Exception>) => Func<T1, U>")]
        public void Catch_Exception_Func_1()
            {
            var Test = new Func<string, string>(o =>
                {
                    o.ShouldBe(_TestString);
                    throw new ArgumentException();
                });
            var Test2 = new Func<string, string>(o =>
                {
                    o.ShouldBe(_TestString);
                    return _TestString;
                });
            var Handler = new Action<Exception>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                });
            var Rethrow_Handler = new Action<Exception>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw Ex;
                });

            Test.Catch(Handler)(_TestString);
            Test2.Catch(Handler)(_TestString).ShouldBe(_TestString);

            Test.Catch(Rethrow_Handler).ShouldFail<string, string, ArgumentException>(_TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Func<T1, T2, U>, Action<Exception>) => Func<T1, T2, U>")]
        public void Catch_Exception_Func_2()
            {
            var Test = new Func<string, string, string>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    throw new ArgumentException();
                });
            var Test2 = new Func<string, string, string>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    return _TestString;
                });
            var Handler = new Action<Exception>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                });
            var Rethrow_Handler = new Action<Exception>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw Ex;
                });

            Test.Catch(Handler)(_TestString, _TestString);
            Test2.Catch(Handler)(_TestString, _TestString).ShouldBe(_TestString);

            Test.Catch(Rethrow_Handler).ShouldFail<string, string, string, ArgumentException>(_TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Func<T1, T2, T3, U>, Action<Exception>) => Func<T1, T2, T3, U>")]
        public void Catch_Exception_Func_3()
            {
            var Test = new Func<string, string, string, string>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    throw new ArgumentException();
                });
            var Test2 = new Func<string, string, string, string>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    return _TestString;
                });
            var Handler = new Action<Exception>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                });
            var Rethrow_Handler = new Action<Exception>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw Ex;
                });

            Test.Catch(Handler)(_TestString, _TestString, _TestString);
            Test2.Catch(Handler)(_TestString, _TestString, _TestString).ShouldBe(_TestString);

            Test.Catch(Rethrow_Handler).ShouldFail<string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Func<T1, T2, T3, T4, U>, Action<Exception>) => Func<T1, T2, T3, T4, U>")]
        public void Catch_Exception_Func_4()
            {
            var Test = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    throw new ArgumentException();
                });
            var Test2 = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    return _TestString;
                });
            var Handler = new Action<Exception>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                });
            var Rethrow_Handler = new Action<Exception>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw Ex;
                });

            Test.Catch(Handler)(_TestString, _TestString, _TestString, _TestString);
            Test2.Catch(Handler)(_TestString, _TestString, _TestString, _TestString).ShouldBe(_TestString);

            Test.Catch(Rethrow_Handler)
                .ShouldFail<string, string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Func<U>, Action<E>) => Func<U>")]
        public void Catch_EType_Action_0()
            {
            var Test = new Action(() => { throw new ArgumentException(); });
            var Test2 = new Action(() => { });

            var Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                });

            Action<FormatException> Wrong_Handler = L.A<FormatException>();

            var Rethrow_Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw Ex;
                });

            Test.Catch(Handler)();
            Test2.Catch(Handler)();

            Test.Catch(Wrong_Handler).ShouldFail<ArgumentException>();
            Test.Catch(Rethrow_Handler).ShouldFail<ArgumentException>();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Func<T1, U>, Action<E>) => Func<T1, U>")]
        public void Catch_EType_Action_1()
            {
            var Test = new Action<string>(o =>
                {
                    o.ShouldBe(_TestString);

                    throw new ArgumentException();
                });
            var Test2 = new Action<string>(o => { o.ShouldBe(_TestString); });

            var Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                });

            Action<FormatException> Wrong_Handler = L.A<FormatException>();

            var Rethrow_Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw Ex;
                });

            Test.Catch(Handler)(_TestString);
            Test2.Catch(Handler)(_TestString);

            Test.Catch(Wrong_Handler).ShouldFail<string, ArgumentException>(_TestString);
            Test.Catch(Rethrow_Handler).ShouldFail<string, ArgumentException>(_TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Func<T1, T2, U>, Action<E>) => Func<T1, T2, U>")]
        public void Catch_EType_Action_2()
            {
            var Test = new Action<string, string>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);

                    throw new ArgumentException();
                });
            var Test2 = new Action<string, string>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                });

            var Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                });

            Action<FormatException> Wrong_Handler = L.A<FormatException>();

            var Rethrow_Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw Ex;
                });

            Test.Catch(Handler)(_TestString, _TestString);
            Test2.Catch(Handler)(_TestString, _TestString);

            Test.Catch(Wrong_Handler).ShouldFail<string, string, ArgumentException>(_TestString, _TestString);
            Test.Catch(Rethrow_Handler).ShouldFail<string, string, ArgumentException>(_TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Func<T1, T2, T3, U>, Action<E>) => Func<T1, T2, T3, U>")]
        public void Catch_EType_Action_3()
            {
            var Test = new Action<string, string, string>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);

                    throw new ArgumentException();
                });
            var Test2 = new Action<string, string, string>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                });

            var Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                });

            Action<FormatException> Wrong_Handler = L.A<FormatException>();

            var Rethrow_Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw Ex;
                });

            Test.Catch(Handler)(_TestString, _TestString, _TestString);
            Test2.Catch(Handler)(_TestString, _TestString, _TestString);

            Test.Catch(Wrong_Handler).ShouldFail<string, string, string, ArgumentException>(_TestString, _TestString, _TestString);
            Test.Catch(Rethrow_Handler).ShouldFail<string, string, string, ArgumentException>(_TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Func<T1, T2, T3, T4, U>, Action<E>) => Func<T1, T2, T3, T4, U>")]
        public void Catch_EType_Action_4()
            {
            var Test = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);

                    throw new ArgumentException();
                });
            var Test2 = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                });

            var Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                });

            Action<FormatException> Wrong_Handler = L.A<FormatException>();

            var Rethrow_Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw Ex;
                });

            Test.Catch(Handler)(_TestString, _TestString, _TestString, _TestString);
            Test2.Catch(Handler)(_TestString, _TestString, _TestString, _TestString);

            Test.Catch(Wrong_Handler)
                .ShouldFail<string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString, _TestString);
            Test.Catch(Rethrow_Handler)
                .ShouldFail<string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString, _TestString);
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Func<U>, Func<E, U>) => Func<U>")]
        public void Catch_EType_Func_0()
            {
            var Test = new Func<string>(() => { throw new ArgumentException(); });
            var Test2 = new Func<string>(() => { return _TestString; });

            var Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                });

            Action<FormatException> Wrong_Handler = L.A<FormatException>();

            var Rethrow_Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw Ex;
                });

            Test.Catch(Handler)();
            Test2.Catch(Handler)().ShouldBe(_TestString);

            Test.Catch(Wrong_Handler).ShouldFail<string, ArgumentException>();
            Test.Catch(Rethrow_Handler).ShouldFail<string, ArgumentException>();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Func<T1, U>, Func<E, U>) => Func<T1, U>")]
        public void Catch_EType_Func_1()
            {
            var Test = new Func<string, string>(o =>
                {
                    o.ShouldBe(_TestString);

                    throw new ArgumentException();
                });
            var Test2 = new Func<string, string>(o =>
                {
                    o.ShouldBe(_TestString);

                    return _TestString;
                });

            var Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                });

            Action<FormatException> Wrong_Handler = L.A<FormatException>();

            var Rethrow_Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw Ex;
                });

            Test.Catch(Handler)(_TestString);
            Test2.Catch(Handler)(_TestString).ShouldBe(_TestString);

            Test.Catch(Wrong_Handler).ShouldFail<string, string, ArgumentException>(_TestString);
            Test.Catch(Rethrow_Handler).ShouldFail<string, string, ArgumentException>(_TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Func<T1, T2, U>, Func<E, U>) => Func<T1, T2, U>")]
        public void Catch_EType_Func_2()
            {
            var Test = new Func<string, string, string>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);

                    throw new ArgumentException();
                });
            var Test2 = new Func<string, string, string>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);

                    return _TestString;
                });

            var Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                });

            Action<FormatException> Wrong_Handler = L.A<FormatException>();

            var Rethrow_Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw Ex;
                });

            Test.Catch(Handler)(_TestString, _TestString);
            Test2.Catch(Handler)(_TestString, _TestString).ShouldBe(_TestString);

            Test.Catch(Wrong_Handler).ShouldFail<string, string, string, ArgumentException>(_TestString, _TestString);
            Test.Catch(Rethrow_Handler).ShouldFail<string, string, string, ArgumentException>(_TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Func<T1, T2, T3, U>, Func<E, U>) => Func<T1, T2, T3, U>")]
        public void Catch_EType_Func_3()
            {
            var Test = new Func<string, string, string, string>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);

                    throw new ArgumentException();
                });
            var Test2 = new Func<string, string, string, string>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);

                    return _TestString;
                });

            var Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                });

            Action<FormatException> Wrong_Handler = L.A<FormatException>();

            var Rethrow_Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw Ex;
                });

            Test.Catch(Handler)(_TestString, _TestString, _TestString);
            Test2.Catch(Handler)(_TestString, _TestString, _TestString).ShouldBe(_TestString);

            Test.Catch(Wrong_Handler).ShouldFail<string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString);
            Test.Catch(Rethrow_Handler).ShouldFail<string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Func<T1, T2, T3, T4, U>, Func<E, U>) => Func<T1, T2, T3, T4, U>")]
        public void Catch_EType_Func_4()
            {
            var Test = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    o4.ShouldBe(_TestString);

                    throw new ArgumentException();
                });
            var Test2 = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    o4.ShouldBe(_TestString);

                    return _TestString;
                });

            var Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                });

            Action<FormatException> Wrong_Handler = L.A<FormatException>();

            var Rethrow_Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw Ex;
                });

            Test.Catch(Handler)(_TestString, _TestString, _TestString, _TestString);
            Test2.Catch(Handler)(_TestString, _TestString, _TestString, _TestString).ShouldBe(_TestString);

            Test.Catch(Wrong_Handler)
                .ShouldFail<string, string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString, _TestString);
            Test.Catch(Rethrow_Handler)
                .ShouldFail<string, string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Action, Action<Exception>) => Action")]
        public void Catch_EType_Func_Func_0()
            {
            var Test = new Func<string>(() => { throw new ArgumentException(); });
            var Test2 = new Func<string>(() => { return $"{_TestString}a"; });

            var Handler = new Func<ArgumentException, string>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    return $"{_TestString}b";
                });

            Func<FormatException, string> Wrong_Handler = L.F<FormatException, string>();

            var Rethrow_Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw Ex;
                });

            Test.Catch(Handler)().ShouldBe($"{_TestString}b");
            Test2.Catch(Handler)().ShouldBe($"{_TestString}a");

            Test.Catch(Wrong_Handler).ShouldFail<string, ArgumentException>();
            Test.Catch(Rethrow_Handler).ShouldFail<string, ArgumentException>();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Action<T1>, Action<Exception>) => Action<T1>")]
        public void Catch_EType_Func_Func_1()
            {
            var Test = new Func<string, string>(o =>
                {
                    o.ShouldBe(_TestString);

                    throw new ArgumentException();
                });
            var Test2 = new Func<string, string>(o =>
                {
                    o.ShouldBe(_TestString);

                    return $"{_TestString}a";
                });

            var Handler = new Func<ArgumentException, string>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    return $"{_TestString}b";
                });

            Func<FormatException, string> Wrong_Handler = L.F<FormatException, string>();

            var Rethrow_Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw Ex;
                });

            Test.Catch(Handler)(_TestString).ShouldBe($"{_TestString}b");
            Test2.Catch(Handler)(_TestString).ShouldBe($"{_TestString}a");

            Test.Catch(Wrong_Handler).ShouldFail<string, string, ArgumentException>(_TestString);
            Test.Catch(Rethrow_Handler).ShouldFail<string, string, ArgumentException>(_TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Action<T1, T2>, Action<Exception>) => Action<T1, T2>")]
        public void Catch_EType_Func_Func_2()
            {
            var Test = new Func<string, string, string>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);

                    throw new ArgumentException();
                });
            var Test2 = new Func<string, string, string>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);

                    return $"{_TestString}a";
                });

            var Handler = new Func<ArgumentException, string>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    return $"{_TestString}b";
                });

            Func<FormatException, string> Wrong_Handler = L.F<FormatException, string>();

            var Rethrow_Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw Ex;
                });

            Test.Catch(Handler)(_TestString, _TestString).ShouldBe($"{_TestString}b");
            Test2.Catch(Handler)(_TestString, _TestString).ShouldBe($"{_TestString}a");

            Test.Catch(Wrong_Handler).ShouldFail<string, string, string, ArgumentException>(_TestString, _TestString);
            Test.Catch(Rethrow_Handler).ShouldFail<string, string, string, ArgumentException>(_TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Action<T1, T2, T3>, Action<Exception>) => Action<T1, T2, T3>")]
        public void Catch_EType_Func_Func_3()
            {
            var Test = new Func<string, string, string, string>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);

                    throw new ArgumentException();
                });
            var Test2 = new Func<string, string, string, string>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);

                    return $"{_TestString}a";
                });

            var Handler = new Func<ArgumentException, string>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    return $"{_TestString}b";
                });

            Func<FormatException, string> Wrong_Handler = L.F<FormatException, string>();

            var Rethrow_Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw Ex;
                });

            Test.Catch(Handler)(_TestString, _TestString, _TestString).ShouldBe($"{_TestString}b");
            Test2.Catch(Handler)(_TestString, _TestString, _TestString).ShouldBe($"{_TestString}a");

            Test.Catch(Wrong_Handler).ShouldFail<string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString);
            Test.Catch(Rethrow_Handler).ShouldFail<string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Action<T1, T2, T3, T4>, Action<Exception>) => Action<T1, T2, T3, T4>")]
        public void Catch_EType_Func_Func_4()
            {
            var Test = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    o4.ShouldBe(_TestString);

                    throw new ArgumentException();
                });
            var Test2 = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    o4.ShouldBe(_TestString);

                    return $"{_TestString}a";
                });

            var Handler = new Func<ArgumentException, string>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    return $"{_TestString}b";
                });

            Func<FormatException, string> Wrong_Handler = L.F<FormatException, string>();

            var Rethrow_Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw Ex;
                });

            Test.Catch(Handler)(_TestString, _TestString, _TestString, _TestString).ShouldBe($"{_TestString}b");
            Test2.Catch(Handler)(_TestString, _TestString, _TestString, _TestString).ShouldBe($"{_TestString}a");

            Test.Catch(Wrong_Handler)
                .ShouldFail<string, string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString, _TestString);
            Test.Catch(Rethrow_Handler)
                .ShouldFail<string, string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Action) => Action")]
        public void Catch_NoArgs_Action_0()
            {
            var Test = new Action(() => { throw new ArgumentException(); });
            var Test2 = new Action(() => { });

            Test.Catch<ArgumentException>()();
            Test2.Catch<ArgumentException>()();

            Test.Catch<FormatException>().ShouldFail<ArgumentException>();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Action<T1>) => Action<T1>")]
        public void Catch_NoArgs_Action_1()
            {
            var Test = new Action<string>(o =>
                {
                    o.ShouldBe(_TestString);
                    throw new ArgumentException();
                });
            var Test2 = new Action<string>(o => { o.ShouldBe(_TestString); });

            Test.Catch<string, ArgumentException>()(_TestString);
            Test2.Catch<string, ArgumentException>()(_TestString);

            Test.Catch<string, FormatException>().ShouldFail<string, ArgumentException>(_TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Action<T1, T2>) => Action<T1, T2>")]
        public void Catch_NoArgs_Action_2()
            {
            var Test = new Action<string, string>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    throw new ArgumentException();
                });
            var Test2 = new Action<string, string>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                });

            Test.Catch<string, string, ArgumentException>()(_TestString, _TestString);
            Test2.Catch<string, string, ArgumentException>()(_TestString, _TestString);

            Test.Catch<string, string, FormatException>().ShouldFail<string, string, ArgumentException>(_TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Action<T1, T2, T3>) => Action<T1, T2, T3>")]
        public void Catch_NoArgs_Action_3()
            {
            var Test = new Action<string, string, string>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    throw new ArgumentException();
                });
            var Test2 = new Action<string, string, string>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                });

            Test.Catch<string, string, string, ArgumentException>()(_TestString, _TestString, _TestString);
            Test2.Catch<string, string, string, ArgumentException>()(_TestString, _TestString, _TestString);

            Test.Catch<string, string, string, FormatException>()
                .ShouldFail<string, string, string, ArgumentException>(_TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Action<T1, T2, T3, T4>) => Action<T1, T2, T3, T4>")]
        public void Catch_NoArgs_Action_4()
            {
            var Test = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    o4.ShouldBe(_TestString);
                    throw new ArgumentException();
                });
            var Test2 = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    o4.ShouldBe(_TestString);
                });

            Test.Catch<string, string, string, string, ArgumentException>()(_TestString, _TestString, _TestString, _TestString);
            Test2.Catch<string, string, string, string, ArgumentException>()(_TestString, _TestString, _TestString, _TestString);

            Test.Catch<string, string, string, string, FormatException>()
                .ShouldFail<string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Func<U>) => Func<U>")]
        public void Catch_NoArgs_Func_0()
            {
            var Test = new Func<string>(() => { throw new ArgumentException(); });
            var Test2 = new Func<string>(() => { return $"{_TestString}a"; });

            Test.Catch<string, ArgumentException>()().ShouldBe(default(string));
            Test2.Catch<string, ArgumentException>()().ShouldBe($"{_TestString}a");

            Test.Catch<string, FormatException>().ShouldFail<string, ArgumentException>();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Func<T1, U>) => Func<T1, U>")]
        public void Catch_NoArgs_Func_1()
            {
            var Test = new Func<string, string>(o =>
                {
                    o.ShouldBe(_TestString);
                    throw new ArgumentException();
                });
            var Test2 = new Func<string, string>(o =>
                {
                    o.ShouldBe(_TestString);
                    return $"{_TestString}a";
                });

            Test.Catch<string, string, ArgumentException>()(_TestString).ShouldBe(default(string));
            Test2.Catch<string, string, ArgumentException>()(_TestString).ShouldBe($"{_TestString}a");

            Test.Catch<string, string, FormatException>().ShouldFail<string, string, ArgumentException>(_TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Func<T1, T2, U>) => Func<T1, T2, U>")]
        public void Catch_NoArgs_Func_2()
            {
            var Test = new Func<string, string, string>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    throw new ArgumentException();
                });
            var Test2 = new Func<string, string, string>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    return $"{_TestString}a";
                });

            Test.Catch<string, string, string, ArgumentException>()(_TestString, _TestString).ShouldBe(default(string));
            Test2.Catch<string, string, string, ArgumentException>()(_TestString, _TestString).ShouldBe($"{_TestString}a");

            Test.Catch<string, string, string, FormatException>()
                .ShouldFail<string, string, string, ArgumentException>(_TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Func<T1, T2, T3, U>) => Func<T1, T2, T3, U>")]
        public void Catch_NoArgs_Func_3()
            {
            var Test = new Func<string, string, string, string>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    throw new ArgumentException();
                });
            var Test2 = new Func<string, string, string, string>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    return $"{_TestString}a";
                });

            Test.Catch<string, string, string, string, ArgumentException>()(_TestString, _TestString, _TestString)
                .Should()
                .Be(default(string));
            Test2.Catch<string, string, string, string, ArgumentException>()(_TestString, _TestString, _TestString)
                .Should()
                .Be($"{_TestString}a");

            Test.Catch<string, string, string, string, FormatException>()
                .ShouldFail<string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Catch) + "(Func<T1, T2, T3, T4, U>) => Func<T1, T2, T3, T4, U>")]
        public void Catch_NoArgs_Func_4()
            {
            var Test = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    o4.ShouldBe(_TestString);
                    throw new ArgumentException();
                });
            var Test2 = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    o4.ShouldBe(_TestString);
                    return $"{_TestString}a";
                });

            Test.Catch<string, string, string, string, string, ArgumentException>()(_TestString, _TestString, _TestString, _TestString)
                .Should()
                .Be(default(string));
            Test2.Catch<string, string, string, string, string, ArgumentException>()(_TestString, _TestString, _TestString, _TestString)
                .Should()
                .Be($"{_TestString}a");

            Test.Catch<string, string, string, string, string, FormatException>()
                .ShouldFail<string, string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString, _TestString);
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Fail) + "(Action) => Action")]
        public void Fail_Action()
            {
            var Act = new Action(() => { });

            Act();
            Act.Fail().ShouldFail<Exception>();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Fail) + "(Action<T>) => Action<T>")]
        public void Fail_Action_1()
            {
            var Act = new Action<string>(o => { o.ShouldBe(_TestString); });

            Act(_TestString);
            Act.Fail().ShouldFail<string, Exception>(_TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Fail) + "(Action<T1, T2>) => Action<T1, T2>")]
        public void Fail_Action_2()
            {
            var Act = new Action<string, string>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                });

            Act(_TestString, _TestString);
            Act.Fail().ShouldFail<string, string, Exception>(_TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Fail) + "(Action<T1, T2, T3>) => Action<T1, T2, T3>")]
        public void Fail_Action_3()
            {
            var Act = new Action<string, string, string>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                });

            Act(_TestString, _TestString, _TestString);
            Act.Fail().ShouldFail<string, string, string, Exception>(_TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Fail) + "(Action<T1, T2, T3, T4>) => Action<T1, T2, T3, T4>")]
        public void Fail_Action_4()
            {
            var Act = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    o4.ShouldBe(_TestString);
                });

            Act(_TestString, _TestString, _TestString, _TestString);
            Act.Fail().ShouldFail<string, string, string, string, Exception>(_TestString, _TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Fail) + "(Func<U>) => Func<U>")]
        public void Fail_Func()
            {
            var Act = new Func<string>(() => { return _TestString; });

            Act();
            Act.Fail().ShouldFail<string, Exception>();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Fail) + "(Func<T, U>) => Func<T, U>")]
        public void Fail_Func_1()
            {
            var Act = new Func<string, string>(o =>
                {
                    o.ShouldBe(_TestString);
                    return _TestString;
                });

            Act(_TestString);
            Act.Fail().ShouldFail<string, string, Exception>(_TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Fail) + "(Func<T1, T2, U>) => Func<T1, T2, U>")]
        public void Fail_Func_2()
            {
            var Act = new Func<string, string, string>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    return _TestString;
                });

            Act(_TestString, _TestString);
            Act.Fail().ShouldFail<string, string, string, Exception>(_TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Fail) + "(Func<T1, T2, T3, U>) => Func<T1, T2, T3, U>")]
        public void Fail_Func_3()
            {
            var Act = new Func<string, string, string, string>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    return _TestString;
                });

            Act(_TestString, _TestString, _TestString);
            Act.Fail().ShouldFail<string, string, string, string, Exception>(_TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Fail) + "(Func<T1, T2, T3, T4, U>) => Func<T1, T2, T3, T4, U>")]
        public void Fail_Func_4()
            {
            var Act = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    o4.ShouldBe(_TestString);
                    return _TestString;
                });

            Act(_TestString, _TestString, _TestString, _TestString);
            Act.Fail().ShouldFail<string, string, string, string, string, Exception>(_TestString, _TestString, _TestString, _TestString);
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Report) + "(Action, String, E) => Action")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Report) + "(Action, E) => Action")]
        public void Report_Action_0()
            {
            var Act = new Action(() => { });
            var Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Message.ShouldBe($"{_TestString}a\r\nParameter name: {_TestString}b");
                    Ex.ParamName.ShouldBe($"{_TestString}b");
                });
            var Handler2 = new Action<Exception>(Ex => { Ex.Message.ShouldBe($"{_TestString}c"); });

            Act();
            Act.Report(new ArgumentException($"{_TestString}a", $"{_TestString}b")).Catch(Handler)();

            Act.Report($"{_TestString}c", new ArgumentException($"{_TestString}a", $"{_TestString}b")).Catch(Handler2)();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Report) + "(Action<T>, String, E) => Action<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Report) + "(Action<T>, E) => Action<T>")]
        public void Report_Action_1()
            {
            var Act = new Action<string>(o => { o.ShouldBe(_TestString); });
            var Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Message.ShouldBe($"{_TestString}a\r\nParameter name: {_TestString}b");
                    Ex.ParamName.ShouldBe($"{_TestString}b");
                });
            var Handler2 = new Action<Exception>(Ex => { Ex.Message.ShouldBe($"{_TestString}c"); });

            Act(_TestString);
            Act.Report(new ArgumentException($"{_TestString}a", $"{_TestString}b")).Catch(Handler)(_TestString);

            Act.Report($"{_TestString}c", new ArgumentException($"{_TestString}a", $"{_TestString}b")).Catch(Handler2)(_TestString);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Report) + "(Action<T1, T2>, String, E) => Action<T1, T2>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Report) + "(Action<T1, T2>, E) => Action<T1, T2>")]
        public void Report_Action_2()
            {
            var Act = new Action<string, string>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                });
            var Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Message.ShouldBe($"{_TestString}a\r\nParameter name: {_TestString}b");
                    Ex.ParamName.ShouldBe($"{_TestString}b");
                });
            var Handler2 = new Action<Exception>(Ex => { Ex.Message.ShouldBe($"{_TestString}c"); });

            Act(_TestString, _TestString);
            Act.Report(new ArgumentException($"{_TestString}a", $"{_TestString}b")).Catch(Handler)(_TestString, _TestString);

            Act.Report($"{_TestString}c", new ArgumentException($"{_TestString}a", $"{_TestString}b"))
                .Catch(Handler2)(_TestString, _TestString);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Report) + "(Action<T1, T2, T3>, String, E) => Action<T1, T2, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Report) + "(Action<T1, T2, T3>, E) => Action<T1, T2, T3>")]
        public void Report_Action_3()
            {
            var Act = new Action<string, string, string>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                });
            var Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Message.ShouldBe($"{_TestString}a\r\nParameter name: {_TestString}b");
                    Ex.ParamName.ShouldBe($"{_TestString}b");
                });
            var Handler2 = new Action<Exception>(Ex => { Ex.Message.ShouldBe($"{_TestString}c"); });

            Act(_TestString, _TestString, _TestString);
            Act.Report(new ArgumentException($"{_TestString}a", $"{_TestString}b")).Catch(Handler)(_TestString, _TestString, _TestString);

            Act.Report($"{_TestString}c", new ArgumentException($"{_TestString}a", $"{_TestString}b"))
                .Catch(Handler2)(_TestString, _TestString, _TestString);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Report) + "(Action<T1, T2, T3, T4>, String, E) => Action<T1, T2, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Report) + "(Action<T1, T2, T3, T4>, E) => Action<T1, T2, T3, T4>")]
        public void Report_Action_4()
            {
            var Act = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    o4.ShouldBe(_TestString);
                });
            var Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Message.ShouldBe($"{_TestString}a\r\nParameter name: {_TestString}b");
                    Ex.ParamName.ShouldBe($"{_TestString}b");
                });
            var Handler2 = new Action<Exception>(Ex => { Ex.Message.ShouldBe($"{_TestString}c"); });

            Act(_TestString, _TestString, _TestString, _TestString);
            Act.Report(new ArgumentException($"{_TestString}a", $"{_TestString}b"))
                .Catch(Handler)(_TestString, _TestString, _TestString, _TestString);

            Act.Report($"{_TestString}c", new ArgumentException($"{_TestString}a", $"{_TestString}b"))
                .Catch(Handler2)(_TestString, _TestString, _TestString, _TestString);
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Report) + "(Func<U>, E) => Func<U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Report) + "(Func<U>, String, E) => Func<U>")]
        public void Report_Func_0()
            {
            var Act = new Func<string>(() => { return $"{_TestString}a"; });
            var Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Message.ShouldBe($"{_TestString}a\r\nParameter name: {_TestString}b");
                    Ex.ParamName.ShouldBe($"{_TestString}b");
                });
            var Handler2 = new Action<Exception>(Ex => { Ex.Message.ShouldBe($"{_TestString}c"); });

            Act().ShouldBe($"{_TestString}a");
            Act.Report(new ArgumentException($"{_TestString}a", $"{_TestString}b")).Catch(Handler)();

            Act.Report($"{_TestString}c", new ArgumentException($"{_TestString}a", $"{_TestString}b")).Catch(Handler2)();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Report) + "(Func<T, U>, E) => Func<T, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Report) + "(Func<T, U>, String, E) => Func<T, U>")]
        public void Report_Func_1()
            {
            var Act = new Func<string, string>(o =>
                {
                    o.ShouldBe(_TestString);
                    return $"{_TestString}a";
                });
            var Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Message.ShouldBe($"{_TestString}a\r\nParameter name: {_TestString}b");
                    Ex.ParamName.ShouldBe($"{_TestString}b");
                });
            var Handler2 = new Action<Exception>(Ex => { Ex.Message.ShouldBe($"{_TestString}c"); });

            Act(_TestString).ShouldBe($"{_TestString}a");
            Act.Report(new ArgumentException($"{_TestString}a", $"{_TestString}b")).Catch(Handler)(_TestString);

            Act.Report($"{_TestString}c", new ArgumentException($"{_TestString}a", $"{_TestString}b")).Catch(Handler2)(_TestString);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Report) + "(Func<T1, T2, U>, E) => Func<T1, T2, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Report) + "(Func<T1, T2, U>, String, E) => Func<T1, T2, U>")]
        public void Report_Func_2()
            {
            var Act = new Func<string, string, string>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    return $"{_TestString}a";
                });
            var Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Message.ShouldBe($"{_TestString}a\r\nParameter name: {_TestString}b");
                    Ex.ParamName.ShouldBe($"{_TestString}b");
                });
            var Handler2 = new Action<Exception>(Ex => { Ex.Message.ShouldBe($"{_TestString}c"); });

            Act(_TestString, _TestString).ShouldBe($"{_TestString}a");
            Act.Report(new ArgumentException($"{_TestString}a", $"{_TestString}b")).Catch(Handler)(_TestString, _TestString);

            Act.Report($"{_TestString}c", new ArgumentException($"{_TestString}a", $"{_TestString}b"))
                .Catch(Handler2)(_TestString, _TestString);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Report) + "(Func<T1, T2, T3, U>, E) => Func<T1, T2, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Report) + "(Func<T1, T2, T3, U>, String, E) => Func<T1, T2, T3, U>")]
        public void Report_Func_3()
            {
            var Act = new Func<string, string, string, string>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    return $"{_TestString}a";
                });
            var Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Message.ShouldBe($"{_TestString}a\r\nParameter name: {_TestString}b");
                    Ex.ParamName.ShouldBe($"{_TestString}b");
                });
            var Handler2 = new Action<Exception>(Ex => { Ex.Message.ShouldBe($"{_TestString}c"); });

            Act(_TestString, _TestString, _TestString).ShouldBe($"{_TestString}a");
            Act.Report(new ArgumentException($"{_TestString}a", $"{_TestString}b")).Catch(Handler)(_TestString, _TestString, _TestString);

            Act.Report($"{_TestString}c", new ArgumentException($"{_TestString}a", $"{_TestString}b"))
                .Catch(Handler2)(_TestString, _TestString, _TestString);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Report) + "(Func<T1, T2, T3, T4, U>, String, E) => Func<T1, T2, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Report) + "(Func<T1, T2, T3, T4, U>, E) => Func<T1, T2, T3, T4, U>")]
        public void Report_Func_4()
            {
            var Act = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    o4.ShouldBe(_TestString);
                    return $"{_TestString}a";
                });
            var Handler = new Action<ArgumentException>(Ex =>
                {
                    Ex.Message.ShouldBe($"{_TestString}a\r\nParameter name: {_TestString}b");
                    Ex.ParamName.ShouldBe($"{_TestString}b");
                });
            var Handler2 = new Action<Exception>(Ex => { Ex.Message.ShouldBe($"{_TestString}c"); });

            Act(_TestString, _TestString, _TestString, _TestString).ShouldBe($"{_TestString}a");
            Act.Report(new ArgumentException($"{_TestString}a", $"{_TestString}b"))
                .Catch(Handler)(_TestString, _TestString, _TestString, _TestString);

            Act.Report($"{_TestString}c", new ArgumentException($"{_TestString}a", $"{_TestString}b"))
                .Catch(Handler2)(_TestString, _TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Throw) + "(Action, String) => Action")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Throw) + "(Func<U>, String) => Func<U>")]
        public void Throw_0()
            {
            var Act = new Action(() => { });
            var Handler = new Action<Exception>(Ex => { Ex.Message.ShouldBe($"{_TestString}a"); });

            Act();
            Act.Throw($"{_TestString}a").ShouldFail();
            Act.Throw($"{_TestString}a").Catch(Handler)();

            Func<string> Func = Act.Return(_TestString);

            Func().ShouldBe(_TestString);
            Func.Throw($"{_TestString}a").ShouldFail();
            Func.Throw($"{_TestString}a").Catch(Handler)();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Throw) + "(Func<T, U>, String) => Func<T, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Throw) + "(Action<T>, String) => Action<T>")]
        public void Throw_1()
            {
            var Act = new Action<string>(o => { o.ShouldBe(_TestString); });
            var Handler = new Action<Exception>(Ex => { Ex.Message.ShouldBe($"{_TestString}a"); });

            Act(_TestString);
            Act.Throw($"{_TestString}a").ShouldFail(_TestString);
            Act.Throw($"{_TestString}a").Catch(Handler)(_TestString);

            Func<string, string> Func = Act.Return(_TestString);

            Func(_TestString).ShouldBe(_TestString);
            Func.Throw($"{_TestString}a").ShouldFail(_TestString);
            Func.Throw($"{_TestString}a").Catch(Handler)(_TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Throw) + "(Func<T1, T2, U>, String) => Func<T1, T2, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Throw) + "(Action<T1, T2>, String) => Action<T1, T2>")]
        public void Throw_2()
            {
            var Act = new Action<string, string>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                });
            var Handler = new Action<Exception>(Ex => { Ex.Message.ShouldBe($"{_TestString}a"); });

            Act(_TestString, _TestString);
            Act.Throw($"{_TestString}a").ShouldFail(_TestString, _TestString);
            Act.Throw($"{_TestString}a").Catch(Handler)(_TestString, _TestString);

            Func<string, string, string> Func = Act.Return(_TestString);

            Func(_TestString, _TestString).ShouldBe(_TestString);
            Func.Throw($"{_TestString}a").ShouldFail(_TestString, _TestString);
            Func.Throw($"{_TestString}a").Catch(Handler)(_TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Throw) + "(Func<T1, T2, T3, U>, String) => Func<T1, T2, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Throw) + "(Action<T1, T2, T3>, String) => Action<T1, T2, T3>")]
        public void Throw_3()
            {
            var Act = new Action<string, string, string>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                });
            var Handler = new Action<Exception>(Ex => { Ex.Message.ShouldBe($"{_TestString}a"); });

            Act(_TestString, _TestString, _TestString);
            Act.Throw($"{_TestString}a").ShouldFail(_TestString, _TestString, _TestString);
            Act.Throw($"{_TestString}a").Catch(Handler)(_TestString, _TestString, _TestString);

            Func<string, string, string, string> Func = Act.Return(_TestString);

            Func(_TestString, _TestString, _TestString).ShouldBe(_TestString);
            Func.Throw($"{_TestString}a").ShouldFail(_TestString, _TestString, _TestString);
            Func.Throw($"{_TestString}a").Catch(Handler)(_TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Throw) + "(Action<T1, T2, T3, T4>, String) => Action<T1, T2, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Throw) + "(Func<T1, T2, T3, T4, U>, String) => Func<T1, T2, T3, T4, U>")]
        public void Throw_4()
            {
            var Act = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    o4.ShouldBe(_TestString);
                });
            var Handler = new Action<Exception>(Ex => { Ex.Message.ShouldBe($"{_TestString}a"); });

            Act(_TestString, _TestString, _TestString, _TestString);
            Act.Throw($"{_TestString}a").ShouldFail(_TestString, _TestString, _TestString, _TestString);
            Act.Throw($"{_TestString}a").Catch(Handler)(_TestString, _TestString, _TestString, _TestString);

            Func<string, string, string, string, string> Func = Act.Return(_TestString);

            Func(_TestString, _TestString, _TestString, _TestString).ShouldBe(_TestString);
            Func.Throw($"{_TestString}a").ShouldFail(_TestString, _TestString, _TestString, _TestString);
            Func.Throw($"{_TestString}a").Catch(Handler)(_TestString, _TestString, _TestString, _TestString);
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Handle) + "(Action) => Action")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Handle) + "(Func<U>) => Func<U>")]
        public void Handle_0()
            {
            lock (this)
                {
                Action<Exception> Temp = L.Exc.DefaultExceptionHandler;

                L.Exc.DefaultExceptionHandler = Ex =>
                    {
                        Ex.Should().BeOfType<ArgumentException>();
                        Ex.Message.ShouldBe($"{_TestString}a");
                    };

                var Good_Act = new Action(() => { });
                var Bad_Act = new Action(() => { throw new ArgumentException($"{_TestString}a"); });

                Good_Act.Handle()();
                Bad_Act.Handle()();

                Good_Act.Return(_TestString).Handle()().ShouldBe(_TestString);
                Bad_Act.Return(_TestString).Handle()().ShouldBe(default(string));

                L.Exc.DefaultExceptionHandler = Temp;
                }
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Handle) + "(Action<T1>) => Action<T1>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Handle) + "(Func<T1, U>) => Func<T1, U>")]
        public void Handle_1()
            {
            lock (this)
                {
                Action<Exception> Temp = L.Exc.DefaultExceptionHandler;

                L.Exc.DefaultExceptionHandler = Ex =>
                    {
                        Ex.Should().BeOfType<ArgumentException>();
                        Ex.Message.ShouldBe($"{_TestString}a");
                    };

                var Good_Act = new Action<string>(o => { o.ShouldBe(_TestString); });
                var Bad_Act = new Action<string>(o =>
                    {
                        o.ShouldBe(_TestString);
                        throw new ArgumentException($"{_TestString}a");
                    });

                Good_Act.Handle()(_TestString);
                Bad_Act.Handle()(_TestString);

                Good_Act.Return(_TestString).Handle()(_TestString).ShouldBe(_TestString);
                Bad_Act.Return(_TestString).Handle()(_TestString).ShouldBe(default(string));

                L.Exc.DefaultExceptionHandler = Temp;
                }
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Handle) + "(Action<T1, T2>) => Action<T1, T2>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Handle) + "(Func<T1, T2, U>) => Func<T1, T2, U>")]
        public void Handle_2()
            {
            lock (this)
                {
                Action<Exception> Temp = L.Exc.DefaultExceptionHandler;

                L.Exc.DefaultExceptionHandler = Ex =>
                    {
                        Ex.Should().BeOfType<ArgumentException>();
                        Ex.Message.ShouldBe($"{_TestString}a");
                    };

                var Good_Act = new Action<string, string>((o1, o2) =>
                    {
                        o1.ShouldBe(_TestString);
                        o2.ShouldBe(_TestString);
                    });
                var Bad_Act = new Action<string, string>((o1, o2) =>
                    {
                        o1.ShouldBe(_TestString);
                        o2.ShouldBe(_TestString);
                        throw new ArgumentException($"{_TestString}a");
                    });

                Good_Act.Handle()(_TestString, _TestString);
                Bad_Act.Handle()(_TestString, _TestString);

                Good_Act.Return(_TestString).Handle()(_TestString, _TestString).ShouldBe(_TestString);
                Bad_Act.Return(_TestString).Handle()(_TestString, _TestString).ShouldBe(default(string));

                L.Exc.DefaultExceptionHandler = Temp;
                }
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Handle) + "(Action<T1, T2, T3>) => Action<T1, T2, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Handle) + "(Func<T1, T2, T3, U>) => Func<T1, T2, T3, U>")]
        public void Handle_3()
            {
            lock (this)
                {
                Action<Exception> Temp = L.Exc.DefaultExceptionHandler;

                L.Exc.DefaultExceptionHandler = Ex =>
                    {
                        Ex.Should().BeOfType<ArgumentException>();
                        Ex.Message.ShouldBe($"{_TestString}a");
                    };

                var Good_Act = new Action<string, string, string>((o1, o2, o3) =>
                    {
                        o1.ShouldBe(_TestString);
                        o2.ShouldBe(_TestString);
                        o3.ShouldBe(_TestString);
                    });
                var Bad_Act = new Action<string, string, string>((o1, o2, o3) =>
                    {
                        o1.ShouldBe(_TestString);
                        o2.ShouldBe(_TestString);
                        o3.ShouldBe(_TestString);
                        throw new ArgumentException($"{_TestString}a");
                    });

                Good_Act.Handle()(_TestString, _TestString, _TestString);
                Bad_Act.Handle()(_TestString, _TestString, _TestString);

                Good_Act.Return(_TestString).Handle()(_TestString, _TestString, _TestString).ShouldBe(_TestString);
                Bad_Act.Return(_TestString).Handle()(_TestString, _TestString, _TestString).ShouldBe(default(string));

                L.Exc.DefaultExceptionHandler = Temp;
                }
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Handle) + "(Action<T1, T2, T3, T4>) => Action<T1, T2, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Handle) + "(Func<T1, T2, T3, T4, U>) => Func<T1, T2, T3, T4, U>")]
        public void Handle_4()
            {
            lock (this)
                {
                Action<Exception> Temp = L.Exc.DefaultExceptionHandler;

                L.Exc.DefaultExceptionHandler = Ex =>
                    {
                        Ex.Should().BeOfType<ArgumentException>();
                        Ex.Message.ShouldBe($"{_TestString}a");
                    };

                var Good_Act = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                    {
                        o1.ShouldBe(_TestString);
                        o2.ShouldBe(_TestString);
                        o3.ShouldBe(_TestString);
                        o4.ShouldBe(_TestString);
                    });
                var Bad_Act = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                    {
                        o1.ShouldBe(_TestString);
                        o2.ShouldBe(_TestString);
                        o3.ShouldBe(_TestString);
                        o4.ShouldBe(_TestString);
                        throw new ArgumentException($"{_TestString}a");
                    });

                Good_Act.Handle()(_TestString, _TestString, _TestString, _TestString);
                Bad_Act.Handle()(_TestString, _TestString, _TestString, _TestString);

                Good_Act.Return(_TestString).Handle()(_TestString, _TestString, _TestString, _TestString).ShouldBe(_TestString);
                Bad_Act.Return(_TestString).Handle()(_TestString, _TestString, _TestString, _TestString).ShouldBe(default(string));

                L.Exc.DefaultExceptionHandler = Temp;
                }
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Debug) + "(Action<T1>) => Action<T1>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Debug) + "(Func<T1, U>) => Func<T1, U>")]
        public void Debug_1()
            {
            var Good_Act = new Action<string>(o => { o.ShouldBe(_TestString); });
            var Bad_Act = new Action<string>(o =>
                {
                    o.ShouldBe(_TestString);
                    throw new ArgumentException($"{_TestString}a");
                });

            var Handler = new Action<Exception>(Ex => { Ex.Message.ShouldBe($"System.String:{_TestString}"); });

            Good_Act.Debug()(_TestString);
            Good_Act.Debug().Catch(Handler)(_TestString);

            Bad_Act.Debug().Catch(Handler)(_TestString);

            Good_Act.Return($"{_TestString}a").Debug().Catch(Handler)(_TestString).ShouldBe($"{_TestString}a");
            Bad_Act.Return($"{_TestString}a").Debug().Catch(Handler)(_TestString).ShouldBe(default(string));
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Debug) + "(Action<T1, T2>) => Action<T1, T2>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Debug) + "(Func<T1, T2, U>) => Func<T1, T2, U>")]
        public void Debug_2()
            {
            var Good_Act = new Action<string, string>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                });
            var Bad_Act = new Action<string, string>((o1, o2) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    throw new ArgumentException($"{_TestString}a");
                });

            var Handler =
                new Action<Exception>(Ex => { Ex.Message.ShouldBe($"System.String:{_TestString}, System.String:{_TestString}"); });

            Good_Act.Debug()(_TestString, _TestString);
            Good_Act.Debug().Catch(Handler)(_TestString, _TestString);

            Bad_Act.Debug().Catch(Handler)(_TestString, _TestString);

            Good_Act.Return($"{_TestString}a").Debug().Catch(Handler)(_TestString, _TestString).ShouldBe($"{_TestString}a");
            Bad_Act.Return($"{_TestString}a").Debug().Catch(Handler)(_TestString, _TestString).ShouldBe(default(string));
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Debug) + "(Action<T1, T2, T3>) => Action<T1, T2, T3>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Debug) + "(Func<T1, T2, T3, U>) => Func<T1, T2, T3, U>")]
        public void Debug_3()
            {
            var Good_Act = new Action<string, string, string>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                });
            var Bad_Act = new Action<string, string, string>((o1, o2, o3) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    throw new ArgumentException($"{_TestString}a");
                });

            var Handler =
                new Action<Exception>(
                    Ex =>
                        {
                            Ex.Message.ShouldBe($"System.String:{_TestString}, System.String:{_TestString}, System.String:{_TestString}");
                        });

            Good_Act.Debug()(_TestString, _TestString, _TestString);
            Good_Act.Debug().Catch(Handler)(_TestString, _TestString, _TestString);

            Bad_Act.Debug().Catch(Handler)(_TestString, _TestString, _TestString);

            Good_Act.Return($"{_TestString}a").Debug().Catch(Handler)(_TestString, _TestString, _TestString).ShouldBe($"{_TestString}a");
            Bad_Act.Return($"{_TestString}a").Debug().Catch(Handler)(_TestString, _TestString, _TestString).ShouldBe(default(string));
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Debug) + "(Action<T1, T2, T3, T4>) => Action<T1, T2, T3, T4>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ExceptionExt) + "." +
            nameof(ExceptionExt.Debug) + "(Func<T1, T2, T3, T4, U>) => Func<T1, T2, T3, T4, U>")]
        public void Debug_4()
            {
            var Good_Act = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    o4.ShouldBe(_TestString);
                });
            var Bad_Act = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.ShouldBe(_TestString);
                    o2.ShouldBe(_TestString);
                    o3.ShouldBe(_TestString);
                    o4.ShouldBe(_TestString);
                    throw new ArgumentException($"{_TestString}a");
                });

            var Handler =
                new Action<Exception>(
                    Ex =>
                        {
                            Ex.Message.Should()
                                .Be(
                                    $"System.String:{_TestString}, System.String:{_TestString}, System.String:{_TestString}, System.String:{_TestString}");
                        });

            Good_Act.Debug()(_TestString, _TestString, _TestString, _TestString);
            Good_Act.Debug().Catch(Handler)(_TestString, _TestString, _TestString, _TestString);

            Bad_Act.Debug().Catch(Handler)(_TestString, _TestString, _TestString, _TestString);

            Good_Act.Return($"{_TestString}a")
                .Debug()
                .Catch(Handler)(_TestString, _TestString, _TestString, _TestString)
                .Should()
                .Be($"{_TestString}a");
            Bad_Act.Return($"{_TestString}a")
                .Debug()
                .Catch(Handler)(_TestString, _TestString, _TestString, _TestString)
                .Should()
                .Be(default(string));
            }
        }
    }