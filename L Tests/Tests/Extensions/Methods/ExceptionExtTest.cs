using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Tests;
using Xunit;
using Xunit.Abstractions;
using static LCore.Extensions.L.Test.Categories;

// ReSharper disable ConvertToLambdaExpression

namespace L_Tests.Tests.Extensions
    {
    [Trait(Category, UnitTests)]
    public class ExceptionExtTest : ExtensionTester
        {
        private static readonly string _TestString = Guid.NewGuid().ToString();

        protected override Type[] TestType => new[] {typeof(ExceptionExt)};

        [Fact]
        public void Test_Try_Action_0()
            {
            var A = new Action(() => { });
            var B = new Action(() => { throw new Exception(); });

            // Both actions don't fail.
            bool Result = A.Try()();
            bool Result2 = B.Try()();

            // Result was true
            Result.Should().BeTrue();

            // Result was false
            Result2.Should().BeFalse();
            }

        [Fact]
        public void Test_Try_Action_1()
            {
            var A = new Action<string>(o => { o.Should().Be(_TestString); });
            var B = new Action<string>(o =>
                {
                o.Should().Be(_TestString);

                throw new Exception();
                });

            // Both actions don't fail.
            bool Result = A.Try()(_TestString);
            bool Result2 = B.Try()(_TestString);

            // Result was true
            Result.Should().BeTrue();

            // Result was false
            Result2.Should().BeFalse();
            }

        [Fact]
        public void Test_Try_Action_2()
            {
            var A = new Action<string, string>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                });
            var B = new Action<string, string>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);

                throw new Exception();
                });

            // Both actions don't fail.
            bool Result = A.Try()(_TestString, _TestString);
            bool Result2 = B.Try()(_TestString, _TestString);

            // Result was true
            Result.Should().BeTrue();

            // Result was false
            Result2.Should().BeFalse();
            }

        [Fact]
        public void Test_Try_Action_3()
            {
            var A = new Action<string, string, string>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                });
            var B = new Action<string, string, string>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);

                throw new Exception();
                });

            // Both actions don't fail.
            bool Result = A.Try()(_TestString, _TestString, _TestString);
            bool Result2 = B.Try()(_TestString, _TestString, _TestString);

            // Result was true
            Result.Should().BeTrue();

            // Result was false
            Result2.Should().BeFalse();
            }

        [Fact]
        public void Test_Try_Action_4()
            {
            var A = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);
                });
            var B = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);

                throw new Exception();
                });

            // Both actions don't fail.
            bool Result = A.Try()(_TestString, _TestString, _TestString, _TestString);
            bool Result2 = B.Try()(_TestString, _TestString, _TestString, _TestString);

            // Result was true
            Result.Should().BeTrue();

            // Result was false
            Result2.Should().BeFalse();
            }

        [Fact]
        public void Test_Try_Func_0()
            {
            var A = new Func<int>(() => { return 5; });
            var B = new Func<int>(() => { throw new Exception(); });

            // Both actions don't fail.
            int Result = A.Try()();
            int Result2 = B.Try()();

            // Result was true
            Result.Should().Be(5);

            // Result was false
            Result2.Should().Be(default(int));
            }

        [Fact]
        public void Test_Try_Func_1()
            {
            var A = new Func<string, int>(o =>
                {
                o.Should().Be(_TestString);
                return 5;
                });
            var B = new Func<string, int>(o =>
                {
                o.Should().Be(_TestString);

                throw new Exception();
                });

            // Both actions don't fail.
            int Result = A.Try()(_TestString);
            int Result2 = B.Try()(_TestString);

            // Result was true
            Result.Should().Be(5);

            // Result was false
            Result2.Should().Be(default(int));
            }

        [Fact]
        public void Test_Try_Func_2()
            {
            var A = new Func<string, string, int>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                return 5;
                });
            var B = new Func<string, string, int>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);

                throw new Exception();
                });

            // Both actions don't fail.
            int Result = A.Try()(_TestString, _TestString);
            int Result2 = B.Try()(_TestString, _TestString);

            // Result was true
            Result.Should().Be(5);

            // Result was false
            Result2.Should().Be(default(int));
            }

        [Fact]
        public void Test_Try_Func_3()
            {
            var A = new Func<string, string, string, int>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                return 5;
                });
            var B = new Func<string, string, string, int>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);

                throw new Exception();
                });

            // Both actions don't fail.
            int Result = A.Try()(_TestString, _TestString, _TestString);
            int Result2 = B.Try()(_TestString, _TestString, _TestString);

            // Result was true
            Result.Should().Be(5);

            // Result was false
            Result2.Should().Be(default(int));
            }

        [Fact]
        public void Test_Try_Func_4()
            {
            var A = new Func<string, string, string, string, int>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);
                return 5;
                });
            var B = new Func<string, string, string, string, int>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);

                throw new Exception();
                });

            // Both actions don't fail.
            int Result = A.Try()(_TestString, _TestString, _TestString, _TestString);
            int Result2 = B.Try()(_TestString, _TestString, _TestString, _TestString);

            // Result was true
            Result.Should().Be(5);

            // Result was false
            Result2.Should().Be(default(int));
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Retry_0()
            {
            int I = 0;
            var Test = new Action(() =>
                {
                I++;
                if (I < 5)
                    throw new ArgumentException();
                });

            Test.Retry(3).ShouldFail<ArgumentException>();

            // Reset
            I = 0;
            Test.Retry(4)();
            I.Should().Be(5);

            L.A(() => Test.Retry(0)).ShouldFail();
            L.A(() => Test.Retry(-1)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Retry_Action_1()
            {
            int I = 0;
            var Test = new Action<string>(o =>
                {
                o.Should().Be(_TestString);

                I++;
                if (I < 5)
                    throw new ArgumentException();
                });

            Test.Retry(3).ShouldFail<string, ArgumentException>(_TestString);

            // Reset
            I = 0;
            Test.Retry(4)(_TestString);
            I.Should().Be(5);

            L.A(() => Test.Retry(0)).ShouldFail();
            L.A(() => Test.Retry(-1)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Retry_Action_2()
            {
            int I = 0;
            var Test = new Action<string, string>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);

                I++;
                if (I < 5)
                    throw new ArgumentException();
                });

            Test.Retry(3).ShouldFail<string, string, ArgumentException>(_TestString, _TestString);

            // Reset
            I = 0;
            Test.Retry(4)(_TestString, _TestString);
            I.Should().Be(5);

            L.A(() => Test.Retry(0)).ShouldFail();
            L.A(() => Test.Retry(-1)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Retry_Action_3()
            {
            int I = 0;
            var Test = new Action<string, string, string>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);

                I++;
                if (I < 5)
                    throw new ArgumentException();
                });

            Test.Retry(3).ShouldFail<string, string, string, ArgumentException>(_TestString, _TestString, _TestString);

            // Reset
            I = 0;
            Test.Retry(4)(_TestString, _TestString, _TestString);
            I.Should().Be(5);

            L.A(() => Test.Retry(0)).ShouldFail();
            L.A(() => Test.Retry(-1)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Retry_Action_4()
            {
            int I = 0;
            var Test = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);

                I++;
                if (I < 5)
                    throw new ArgumentException();
                });

            Test.Retry(3).ShouldFail<string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString, _TestString);

            // Reset
            I = 0;
            Test.Retry(4)(_TestString, _TestString, _TestString, _TestString);
            I.Should().Be(5);

            L.A(() => Test.Retry(0)).ShouldFail();
            L.A(() => Test.Retry(-1)).ShouldFail();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Retry_Func_0()
            {
            int I = 0;
            var Test = new Func<string>(() =>
                {
                I++;
                if (I < 5)
                    throw new ArgumentException();

                return _TestString;
                });

            Test.Retry(3).ShouldFail<string, ArgumentException>();

            // Reset
            I = 0;
            Test.Retry(4)().Should().Be(_TestString);
            I.Should().Be(5);

            L.F(() => Test.Retry(0)).ShouldFail();
            L.F(() => Test.Retry(-1)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Retry_Func_1()
            {
            int I = 0;
            var Test = new Func<string, string>(o =>
                {
                o.Should().Be(_TestString);

                I++;
                if (I < 5)
                    throw new ArgumentException();

                return _TestString;
                });

            Test.Retry(3).ShouldFail<string, string, ArgumentException>(_TestString);

            // Reset
            I = 0;
            Test.Retry(4)(_TestString);
            I.Should().Be(5);

            L.F(() => Test.Retry(0)).ShouldFail();
            L.F(() => Test.Retry(-1)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Retry_Func_2()
            {
            int I = 0;
            var Test = new Func<string, string, string>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);

                I++;
                if (I < 5)
                    throw new ArgumentException();

                return _TestString;
                });

            Test.Retry(3).ShouldFail<string, string, string, ArgumentException>(_TestString, _TestString);

            // Reset
            I = 0;
            Test.Retry(4)(_TestString, _TestString);
            I.Should().Be(5);

            L.F(() => Test.Retry(0)).ShouldFail();
            L.F(() => Test.Retry(-1)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Retry_Func_3()
            {
            int I = 0;
            var Test = new Func<string, string, string, string>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);

                I++;
                if (I < 5)
                    throw new ArgumentException();

                return _TestString;
                });

            Test.Retry(3).ShouldFail<string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString);

            // Reset
            I = 0;
            Test.Retry(4)(_TestString, _TestString, _TestString);
            I.Should().Be(5);

            L.F(() => Test.Retry(0)).ShouldFail();
            L.F(() => Test.Retry(-1)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Retry_Func_4()
            {
            int I = 0;
            var Test = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);

                I++;
                if (I < 5)
                    throw new ArgumentException();

                return _TestString;
                });

            Test.Retry(3)
                .ShouldFail<string, string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString, _TestString);

            // Reset
            I = 0;
            Test.Retry(4)(_TestString, _TestString, _TestString, _TestString);
            I.Should().Be(5);

            L.F(() => Test.Retry(0)).ShouldFail();
            L.F(() => Test.Retry(-1)).ShouldFail();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Catch_Exception_Action_0()
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
        public void Test_Catch_Exception_Action_1()
            {
            var Test = new Action<string>(o =>
                {
                o.Should().Be(_TestString);
                throw new ArgumentException();
                });
            var Test2 = new Action<string>(o => { o.Should().Be(_TestString); });
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
        public void Test_Catch_Exception_Action_2()
            {
            var Test = new Action<string, string>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                throw new ArgumentException();
                });
            var Test2 = new Action<string, string>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
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
        public void Test_Catch_Exception_Action_3()
            {
            var Test = new Action<string, string, string>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                throw new ArgumentException();
                });
            var Test2 = new Action<string, string, string>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
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
        public void Test_Catch_Exception_Action_4()
            {
            var Test = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);
                throw new ArgumentException();
                });
            var Test2 = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);
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
        public void Test_Catch_Exception_Func_0()
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
            Test2.Catch(Handler)().Should().Be(_TestString);

            Test.Catch(Rethrow_Handler).ShouldFail<string, ArgumentException>();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Catch_Exception_Func_1()
            {
            var Test = new Func<string, string>(o =>
                {
                o.Should().Be(_TestString);
                throw new ArgumentException();
                });
            var Test2 = new Func<string, string>(o =>
                {
                o.Should().Be(_TestString);
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
            Test2.Catch(Handler)(_TestString).Should().Be(_TestString);

            Test.Catch(Rethrow_Handler).ShouldFail<string, string, ArgumentException>(_TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Catch_Exception_Func_2()
            {
            var Test = new Func<string, string, string>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                throw new ArgumentException();
                });
            var Test2 = new Func<string, string, string>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
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
            Test2.Catch(Handler)(_TestString, _TestString).Should().Be(_TestString);

            Test.Catch(Rethrow_Handler).ShouldFail<string, string, string, ArgumentException>(_TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Catch_Exception_Func_3()
            {
            var Test = new Func<string, string, string, string>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                throw new ArgumentException();
                });
            var Test2 = new Func<string, string, string, string>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
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
            Test2.Catch(Handler)(_TestString, _TestString, _TestString).Should().Be(_TestString);

            Test.Catch(Rethrow_Handler).ShouldFail<string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Catch_Exception_Func_4()
            {
            var Test = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                throw new ArgumentException();
                });
            var Test2 = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
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
            Test2.Catch(Handler)(_TestString, _TestString, _TestString, _TestString).Should().Be(_TestString);

            Test.Catch(Rethrow_Handler)
                .ShouldFail<string, string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Catch_EType_Action_0()
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
        public void Test_Catch_EType_Action_1()
            {
            var Test = new Action<string>(o =>
                {
                o.Should().Be(_TestString);

                throw new ArgumentException();
                });
            var Test2 = new Action<string>(o => { o.Should().Be(_TestString); });

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
        public void Test_Catch_EType_Action_2()
            {
            var Test = new Action<string, string>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);

                throw new ArgumentException();
                });
            var Test2 = new Action<string, string>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
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
        public void Test_Catch_EType_Action_3()
            {
            var Test = new Action<string, string, string>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);

                throw new ArgumentException();
                });
            var Test2 = new Action<string, string, string>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
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
        public void Test_Catch_EType_Action_4()
            {
            var Test = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);

                throw new ArgumentException();
                });
            var Test2 = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
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
        public void Test_Catch_EType_Func_0()
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
            Test2.Catch(Handler)().Should().Be(_TestString);

            Test.Catch(Wrong_Handler).ShouldFail<string, ArgumentException>();
            Test.Catch(Rethrow_Handler).ShouldFail<string, ArgumentException>();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Catch_EType_Func_1()
            {
            var Test = new Func<string, string>(o =>
                {
                o.Should().Be(_TestString);

                throw new ArgumentException();
                });
            var Test2 = new Func<string, string>(o =>
                {
                o.Should().Be(_TestString);

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
            Test2.Catch(Handler)(_TestString).Should().Be(_TestString);

            Test.Catch(Wrong_Handler).ShouldFail<string, string, ArgumentException>(_TestString);
            Test.Catch(Rethrow_Handler).ShouldFail<string, string, ArgumentException>(_TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Catch_EType_Func_2()
            {
            var Test = new Func<string, string, string>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);

                throw new ArgumentException();
                });
            var Test2 = new Func<string, string, string>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);

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
            Test2.Catch(Handler)(_TestString, _TestString).Should().Be(_TestString);

            Test.Catch(Wrong_Handler).ShouldFail<string, string, string, ArgumentException>(_TestString, _TestString);
            Test.Catch(Rethrow_Handler).ShouldFail<string, string, string, ArgumentException>(_TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Catch_EType_Func_3()
            {
            var Test = new Func<string, string, string, string>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);

                throw new ArgumentException();
                });
            var Test2 = new Func<string, string, string, string>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);

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
            Test2.Catch(Handler)(_TestString, _TestString, _TestString).Should().Be(_TestString);

            Test.Catch(Wrong_Handler).ShouldFail<string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString);
            Test.Catch(Rethrow_Handler).ShouldFail<string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Catch_EType_Func_4()
            {
            var Test = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);

                throw new ArgumentException();
                });
            var Test2 = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);

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
            Test2.Catch(Handler)(_TestString, _TestString, _TestString, _TestString).Should().Be(_TestString);

            Test.Catch(Wrong_Handler)
                .ShouldFail<string, string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString, _TestString);
            Test.Catch(Rethrow_Handler)
                .ShouldFail<string, string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Catch_EType_Func_Func_0()
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

            Test.Catch(Handler)().Should().Be($"{_TestString}b");
            Test2.Catch(Handler)().Should().Be($"{_TestString}a");

            Test.Catch(Wrong_Handler).ShouldFail<string, ArgumentException>();
            Test.Catch(Rethrow_Handler).ShouldFail<string, ArgumentException>();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Catch_EType_Func_Func_1()
            {
            var Test = new Func<string, string>(o =>
                {
                o.Should().Be(_TestString);

                throw new ArgumentException();
                });
            var Test2 = new Func<string, string>(o =>
                {
                o.Should().Be(_TestString);

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

            Test.Catch(Handler)(_TestString).Should().Be($"{_TestString}b");
            Test2.Catch(Handler)(_TestString).Should().Be($"{_TestString}a");

            Test.Catch(Wrong_Handler).ShouldFail<string, string, ArgumentException>(_TestString);
            Test.Catch(Rethrow_Handler).ShouldFail<string, string, ArgumentException>(_TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Catch_EType_Func_Func_2()
            {
            var Test = new Func<string, string, string>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);

                throw new ArgumentException();
                });
            var Test2 = new Func<string, string, string>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);

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

            Test.Catch(Handler)(_TestString, _TestString).Should().Be($"{_TestString}b");
            Test2.Catch(Handler)(_TestString, _TestString).Should().Be($"{_TestString}a");

            Test.Catch(Wrong_Handler).ShouldFail<string, string, string, ArgumentException>(_TestString, _TestString);
            Test.Catch(Rethrow_Handler).ShouldFail<string, string, string, ArgumentException>(_TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Catch_EType_Func_Func_3()
            {
            var Test = new Func<string, string, string, string>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);

                throw new ArgumentException();
                });
            var Test2 = new Func<string, string, string, string>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);

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

            Test.Catch(Handler)(_TestString, _TestString, _TestString).Should().Be($"{_TestString}b");
            Test2.Catch(Handler)(_TestString, _TestString, _TestString).Should().Be($"{_TestString}a");

            Test.Catch(Wrong_Handler).ShouldFail<string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString);
            Test.Catch(Rethrow_Handler).ShouldFail<string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Catch_EType_Func_Func_4()
            {
            var Test = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);

                throw new ArgumentException();
                });
            var Test2 = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);

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

            Test.Catch(Handler)(_TestString, _TestString, _TestString, _TestString).Should().Be($"{_TestString}b");
            Test2.Catch(Handler)(_TestString, _TestString, _TestString, _TestString).Should().Be($"{_TestString}a");

            Test.Catch(Wrong_Handler)
                .ShouldFail<string, string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString, _TestString);
            Test.Catch(Rethrow_Handler)
                .ShouldFail<string, string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Catch_NoArgs_Action_0()
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
        public void Test_Catch_NoArgs_Action_1()
            {
            var Test = new Action<string>(o =>
                {
                o.Should().Be(_TestString);
                throw new ArgumentException();
                });
            var Test2 = new Action<string>(o => { o.Should().Be(_TestString); });

            Test.Catch<string, ArgumentException>()(_TestString);
            Test2.Catch<string, ArgumentException>()(_TestString);

            Test.Catch<string, FormatException>().ShouldFail<string, ArgumentException>(_TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Catch_NoArgs_Action_2()
            {
            var Test = new Action<string, string>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                throw new ArgumentException();
                });
            var Test2 = new Action<string, string>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                });

            Test.Catch<string, string, ArgumentException>()(_TestString, _TestString);
            Test2.Catch<string, string, ArgumentException>()(_TestString, _TestString);

            Test.Catch<string, string, FormatException>().ShouldFail<string, string, ArgumentException>(_TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Catch_NoArgs_Action_3()
            {
            var Test = new Action<string, string, string>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                throw new ArgumentException();
                });
            var Test2 = new Action<string, string, string>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                });

            Test.Catch<string, string, string, ArgumentException>()(_TestString, _TestString, _TestString);
            Test2.Catch<string, string, string, ArgumentException>()(_TestString, _TestString, _TestString);

            Test.Catch<string, string, string, FormatException>()
                .ShouldFail<string, string, string, ArgumentException>(_TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Catch_NoArgs_Action_4()
            {
            var Test = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);
                throw new ArgumentException();
                });
            var Test2 = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);
                });

            Test.Catch<string, string, string, string, ArgumentException>()(_TestString, _TestString, _TestString, _TestString);
            Test2.Catch<string, string, string, string, ArgumentException>()(_TestString, _TestString, _TestString, _TestString);

            Test.Catch<string, string, string, string, FormatException>()
                .ShouldFail<string, string, string, string, ArgumentException>(_TestString, _TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Catch_NoArgs_Func_0()
            {
            var Test = new Func<string>(() => { throw new ArgumentException(); });
            var Test2 = new Func<string>(() => { return $"{_TestString}a"; });

            Test.Catch<string, ArgumentException>()().Should().Be(default(string));
            Test2.Catch<string, ArgumentException>()().Should().Be($"{_TestString}a");

            Test.Catch<string, FormatException>().ShouldFail<string, ArgumentException>();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Catch_NoArgs_Func_1()
            {
            var Test = new Func<string, string>(o =>
                {
                o.Should().Be(_TestString);
                throw new ArgumentException();
                });
            var Test2 = new Func<string, string>(o =>
                {
                o.Should().Be(_TestString);
                return $"{_TestString}a";
                });

            Test.Catch<string, string, ArgumentException>()(_TestString).Should().Be(default(string));
            Test2.Catch<string, string, ArgumentException>()(_TestString).Should().Be($"{_TestString}a");

            Test.Catch<string, string, FormatException>().ShouldFail<string, string, ArgumentException>(_TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Catch_NoArgs_Func_2()
            {
            var Test = new Func<string, string, string>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                throw new ArgumentException();
                });
            var Test2 = new Func<string, string, string>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                return $"{_TestString}a";
                });

            Test.Catch<string, string, string, ArgumentException>()(_TestString, _TestString).Should().Be(default(string));
            Test2.Catch<string, string, string, ArgumentException>()(_TestString, _TestString).Should().Be(
                $"{_TestString}a");

            Test.Catch<string, string, string, FormatException>()
                .ShouldFail<string, string, string, ArgumentException>(_TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Catch_NoArgs_Func_3()
            {
            var Test = new Func<string, string, string, string>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                throw new ArgumentException();
                });
            var Test2 = new Func<string, string, string, string>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
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
        public void Test_Catch_NoArgs_Func_4()
            {
            var Test = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);
                throw new ArgumentException();
                });
            var Test2 = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);
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
        public void Test_Fail_Action()
            {
            var Act = new Action(() => { });

            Act();
            Act.Fail().ShouldFail<Exception>();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Fail_Action_1()
            {
            var Act = new Action<string>(o => { o.Should().Be(_TestString); });

            Act(_TestString);
            Act.Fail().ShouldFail<string, Exception>(_TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Fail_Action_2()
            {
            var Act = new Action<string, string>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                });

            Act(_TestString, _TestString);
            Act.Fail().ShouldFail<string, string, Exception>(_TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Fail_Action_3()
            {
            var Act = new Action<string, string, string>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                });

            Act(_TestString, _TestString, _TestString);
            Act.Fail().ShouldFail<string, string, string, Exception>(_TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Fail_Action_4()
            {
            var Act = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);
                });

            Act(_TestString, _TestString, _TestString, _TestString);
            Act.Fail().ShouldFail<string, string, string, string, Exception>(_TestString, _TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Fail_Func()
            {
            var Act = new Func<string>(() => { return _TestString; });

            Act();
            Act.Fail().ShouldFail<string, Exception>();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Fail_Func_1()
            {
            var Act = new Func<string, string>(o =>
                {
                o.Should().Be(_TestString);
                return _TestString;
                });

            Act(_TestString);
            Act.Fail().ShouldFail<string, string, Exception>(_TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Fail_Func_2()
            {
            var Act = new Func<string, string, string>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                return _TestString;
                });

            Act(_TestString, _TestString);
            Act.Fail().ShouldFail<string, string, string, Exception>(_TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Fail_Func_3()
            {
            var Act = new Func<string, string, string, string>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                return _TestString;
                });

            Act(_TestString, _TestString, _TestString);
            Act.Fail().ShouldFail<string, string, string, string, Exception>(_TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Fail_Func_4()
            {
            var Act = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);
                return _TestString;
                });

            Act(_TestString, _TestString, _TestString, _TestString);
            Act.Fail().ShouldFail<string, string, string, string, string, Exception>(_TestString, _TestString, _TestString, _TestString);
            }


        [Fact]
        public void Test_Report_Action_0()
            {
            var Act = new Action(() => { });
            var Handler = new Action<ArgumentException>(Ex =>
                {
                Ex.Message.Should().Be($"{_TestString}a\r\nParameter name: {_TestString}b");
                Ex.ParamName.Should().Be($"{_TestString}b");
                });
            var Handler2 = new Action<Exception>(Ex => { Ex.Message.Should().Be($"{_TestString}c"); });

            Act();
            Act.Report(new ArgumentException($"{_TestString}a", $"{_TestString}b")).Catch(Handler)();

            Act.Report($"{_TestString}c", new ArgumentException($"{_TestString}a", $"{_TestString}b")).Catch(Handler2)();
            }

        [Fact]
        public void Test_Report_Action_1()
            {
            var Act = new Action<string>(o => { o.Should().Be(_TestString); });
            var Handler = new Action<ArgumentException>(Ex =>
                {
                Ex.Message.Should().Be($"{_TestString}a\r\nParameter name: {_TestString}b");
                Ex.ParamName.Should().Be($"{_TestString}b");
                });
            var Handler2 = new Action<Exception>(Ex => { Ex.Message.Should().Be($"{_TestString}c"); });

            Act(_TestString);
            Act.Report(new ArgumentException($"{_TestString}a", $"{_TestString}b")).Catch(Handler)(_TestString);

            Act.Report($"{_TestString}c", new ArgumentException($"{_TestString}a", $"{_TestString}b")).Catch(Handler2)(_TestString);
            }

        [Fact]
        public void Test_Report_Action_2()
            {
            var Act = new Action<string, string>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                });
            var Handler = new Action<ArgumentException>(Ex =>
                {
                Ex.Message.Should().Be($"{_TestString}a\r\nParameter name: {_TestString}b");
                Ex.ParamName.Should().Be($"{_TestString}b");
                });
            var Handler2 = new Action<Exception>(Ex => { Ex.Message.Should().Be($"{_TestString}c"); });

            Act(_TestString, _TestString);
            Act.Report(new ArgumentException($"{_TestString}a", $"{_TestString}b")).Catch(Handler)(_TestString, _TestString);

            Act.Report($"{_TestString}c", new ArgumentException($"{_TestString}a", $"{_TestString}b"))
                .Catch(Handler2)(_TestString, _TestString);
            }

        [Fact]
        public void Test_Report_Action_3()
            {
            var Act = new Action<string, string, string>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                });
            var Handler = new Action<ArgumentException>(Ex =>
                {
                Ex.Message.Should().Be($"{_TestString}a\r\nParameter name: {_TestString}b");
                Ex.ParamName.Should().Be($"{_TestString}b");
                });
            var Handler2 = new Action<Exception>(Ex => { Ex.Message.Should().Be($"{_TestString}c"); });

            Act(_TestString, _TestString, _TestString);
            Act.Report(new ArgumentException($"{_TestString}a", $"{_TestString}b")).Catch(Handler)(_TestString, _TestString, _TestString);

            Act.Report($"{_TestString}c", new ArgumentException($"{_TestString}a", $"{_TestString}b"))
                .Catch(Handler2)(_TestString, _TestString, _TestString);
            }

        [Fact]
        public void Test_Report_Action_4()
            {
            var Act = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);
                });
            var Handler = new Action<ArgumentException>(Ex =>
                {
                Ex.Message.Should().Be($"{_TestString}a\r\nParameter name: {_TestString}b");
                Ex.ParamName.Should().Be($"{_TestString}b");
                });
            var Handler2 = new Action<Exception>(Ex => { Ex.Message.Should().Be($"{_TestString}c"); });

            Act(_TestString, _TestString, _TestString, _TestString);
            Act.Report(new ArgumentException($"{_TestString}a", $"{_TestString}b"))
                .Catch(Handler)(_TestString, _TestString, _TestString, _TestString);

            Act.Report($"{_TestString}c", new ArgumentException($"{_TestString}a", $"{_TestString}b"))
                .Catch(Handler2)(_TestString, _TestString, _TestString, _TestString);
            }


        [Fact]
        public void Test_Report_Func_0()
            {
            var Act = new Func<string>(() => { return $"{_TestString}a"; });
            var Handler = new Action<ArgumentException>(Ex =>
                {
                Ex.Message.Should().Be($"{_TestString}a\r\nParameter name: {_TestString}b");
                Ex.ParamName.Should().Be($"{_TestString}b");
                });
            var Handler2 = new Action<Exception>(Ex => { Ex.Message.Should().Be($"{_TestString}c"); });

            Act().Should().Be($"{_TestString}a");
            Act.Report(new ArgumentException($"{_TestString}a", $"{_TestString}b")).Catch(Handler)();

            Act.Report($"{_TestString}c", new ArgumentException($"{_TestString}a", $"{_TestString}b")).Catch(Handler2)();
            }

        [Fact]
        public void Test_Report_Func_1()
            {
            var Act = new Func<string, string>(o =>
                {
                o.Should().Be(_TestString);
                return $"{_TestString}a";
                });
            var Handler = new Action<ArgumentException>(Ex =>
                {
                Ex.Message.Should().Be($"{_TestString}a\r\nParameter name: {_TestString}b");
                Ex.ParamName.Should().Be($"{_TestString}b");
                });
            var Handler2 = new Action<Exception>(Ex => { Ex.Message.Should().Be($"{_TestString}c"); });

            Act(_TestString).Should().Be($"{_TestString}a");
            Act.Report(new ArgumentException($"{_TestString}a", $"{_TestString}b")).Catch(Handler)(_TestString);

            Act.Report($"{_TestString}c", new ArgumentException($"{_TestString}a", $"{_TestString}b")).Catch(Handler2)(_TestString);
            }

        [Fact]
        public void Test_Report_Func_2()
            {
            var Act = new Func<string, string, string>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                return $"{_TestString}a";
                });
            var Handler = new Action<ArgumentException>(Ex =>
                {
                Ex.Message.Should().Be($"{_TestString}a\r\nParameter name: {_TestString}b");
                Ex.ParamName.Should().Be($"{_TestString}b");
                });
            var Handler2 = new Action<Exception>(Ex => { Ex.Message.Should().Be($"{_TestString}c"); });

            Act(_TestString, _TestString).Should().Be($"{_TestString}a");
            Act.Report(new ArgumentException($"{_TestString}a", $"{_TestString}b")).Catch(Handler)(_TestString, _TestString);

            Act.Report($"{_TestString}c", new ArgumentException($"{_TestString}a", $"{_TestString}b"))
                .Catch(Handler2)(_TestString, _TestString);
            }

        [Fact]
        public void Test_Report_Func_3()
            {
            var Act = new Func<string, string, string, string>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                return $"{_TestString}a";
                });
            var Handler = new Action<ArgumentException>(Ex =>
                {
                Ex.Message.Should().Be($"{_TestString}a\r\nParameter name: {_TestString}b");
                Ex.ParamName.Should().Be($"{_TestString}b");
                });
            var Handler2 = new Action<Exception>(Ex => { Ex.Message.Should().Be($"{_TestString}c"); });

            Act(_TestString, _TestString, _TestString).Should().Be($"{_TestString}a");
            Act.Report(new ArgumentException($"{_TestString}a", $"{_TestString}b")).Catch(Handler)(_TestString, _TestString, _TestString);

            Act.Report($"{_TestString}c", new ArgumentException($"{_TestString}a", $"{_TestString}b"))
                .Catch(Handler2)(_TestString, _TestString, _TestString);
            }

        [Fact]
        public void Test_Report_Func_4()
            {
            var Act = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);
                return $"{_TestString}a";
                });
            var Handler = new Action<ArgumentException>(Ex =>
                {
                Ex.Message.Should().Be($"{_TestString}a\r\nParameter name: {_TestString}b");
                Ex.ParamName.Should().Be($"{_TestString}b");
                });
            var Handler2 = new Action<Exception>(Ex => { Ex.Message.Should().Be($"{_TestString}c"); });

            Act(_TestString, _TestString, _TestString, _TestString).Should().Be($"{_TestString}a");
            Act.Report(new ArgumentException($"{_TestString}a", $"{_TestString}b"))
                .Catch(Handler)(_TestString, _TestString, _TestString, _TestString);

            Act.Report($"{_TestString}c", new ArgumentException($"{_TestString}a", $"{_TestString}b"))
                .Catch(Handler2)(_TestString, _TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Throw_0()
            {
            var Act = new Action(() => { });
            var Handler = new Action<Exception>(Ex => { Ex.Message.Should().Be($"{_TestString}a"); });

            Act();
            Act.Throw($"{_TestString}a").ShouldFail();
            Act.Throw($"{_TestString}a").Catch(Handler)();

            Func<string> Func = Act.Return(_TestString);

            Func().Should().Be(_TestString);
            Func.Throw($"{_TestString}a").ShouldFail();
            Func.Throw($"{_TestString}a").Catch(Handler)();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Throw_1()
            {
            var Act = new Action<string>(o => { o.Should().Be(_TestString); });
            var Handler = new Action<Exception>(Ex => { Ex.Message.Should().Be($"{_TestString}a"); });

            Act(_TestString);
            Act.Throw($"{_TestString}a").ShouldFail(_TestString);
            Act.Throw($"{_TestString}a").Catch(Handler)(_TestString);

            Func<string, string> Func = Act.Return(_TestString);

            Func(_TestString).Should().Be(_TestString);
            Func.Throw($"{_TestString}a").ShouldFail(_TestString);
            Func.Throw($"{_TestString}a").Catch(Handler)(_TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Throw_2()
            {
            var Act = new Action<string, string>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                });
            var Handler = new Action<Exception>(Ex => { Ex.Message.Should().Be($"{_TestString}a"); });

            Act(_TestString, _TestString);
            Act.Throw($"{_TestString}a").ShouldFail(_TestString, _TestString);
            Act.Throw($"{_TestString}a").Catch(Handler)(_TestString, _TestString);

            Func<string, string, string> Func = Act.Return(_TestString);

            Func(_TestString, _TestString).Should().Be(_TestString);
            Func.Throw($"{_TestString}a").ShouldFail(_TestString, _TestString);
            Func.Throw($"{_TestString}a").Catch(Handler)(_TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Throw_3()
            {
            var Act = new Action<string, string, string>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                });
            var Handler = new Action<Exception>(Ex => { Ex.Message.Should().Be($"{_TestString}a"); });

            Act(_TestString, _TestString, _TestString);
            Act.Throw($"{_TestString}a").ShouldFail(_TestString, _TestString, _TestString);
            Act.Throw($"{_TestString}a").Catch(Handler)(_TestString, _TestString, _TestString);

            Func<string, string, string, string> Func = Act.Return(_TestString);

            Func(_TestString, _TestString, _TestString).Should().Be(_TestString);
            Func.Throw($"{_TestString}a").ShouldFail(_TestString, _TestString, _TestString);
            Func.Throw($"{_TestString}a").Catch(Handler)(_TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Throw_4()
            {
            var Act = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);
                });
            var Handler = new Action<Exception>(Ex => { Ex.Message.Should().Be($"{_TestString}a"); });

            Act(_TestString, _TestString, _TestString, _TestString);
            Act.Throw($"{_TestString}a").ShouldFail(_TestString, _TestString, _TestString, _TestString);
            Act.Throw($"{_TestString}a").Catch(Handler)(_TestString, _TestString, _TestString, _TestString);

            Func<string, string, string, string, string> Func = Act.Return(_TestString);

            Func(_TestString, _TestString, _TestString, _TestString).Should().Be(_TestString);
            Func.Throw($"{_TestString}a").ShouldFail(_TestString, _TestString, _TestString, _TestString);
            Func.Throw($"{_TestString}a").Catch(Handler)(_TestString, _TestString, _TestString, _TestString);
            }


        [Fact]
        public void Test_Handle_0()
            {
            lock (this)
                {
                Action<Exception> Temp = L.Exc.DefaultExceptionHandler;

                L.Exc.DefaultExceptionHandler = Ex =>
                    {
                    Ex.Should().BeOfType<ArgumentException>();
                    Ex.Message.Should().Be($"{_TestString}a");
                    };

                var Good_Act = new Action(() => { });
                var Bad_Act = new Action(() => { throw new ArgumentException($"{_TestString}a"); });

                Good_Act.Handle()();
                Bad_Act.Handle()();

                Good_Act.Return(_TestString).Handle()().Should().Be(_TestString);
                Bad_Act.Return(_TestString).Handle()().Should().Be(default(string));

                L.Exc.DefaultExceptionHandler = Temp;
                }
            }

        [Fact]
        public void Test_Handle_1()
            {
            lock (this)
                {
                Action<Exception> Temp = L.Exc.DefaultExceptionHandler;

                L.Exc.DefaultExceptionHandler = Ex =>
                    {
                    Ex.Should().BeOfType<ArgumentException>();
                    Ex.Message.Should().Be($"{_TestString}a");
                    };

                var Good_Act = new Action<string>(o => { o.Should().Be(_TestString); });
                var Bad_Act = new Action<string>(o =>
                    {
                    o.Should().Be(_TestString);
                    throw new ArgumentException($"{_TestString}a");
                    });

                Good_Act.Handle()(_TestString);
                Bad_Act.Handle()(_TestString);

                Good_Act.Return(_TestString).Handle()(_TestString).Should().Be(_TestString);
                Bad_Act.Return(_TestString).Handle()(_TestString).Should().Be(default(string));

                L.Exc.DefaultExceptionHandler = Temp;
                }
            }

        [Fact]
        public void Test_Handle_2()
            {
            lock (this)
                {
                Action<Exception> Temp = L.Exc.DefaultExceptionHandler;

                L.Exc.DefaultExceptionHandler = Ex =>
                    {
                    Ex.Should().BeOfType<ArgumentException>();
                    Ex.Message.Should().Be($"{_TestString}a");
                    };

                var Good_Act = new Action<string, string>((o1, o2) =>
                    {
                    o1.Should().Be(_TestString);
                    o2.Should().Be(_TestString);
                    });
                var Bad_Act = new Action<string, string>((o1, o2) =>
                    {
                    o1.Should().Be(_TestString);
                    o2.Should().Be(_TestString);
                    throw new ArgumentException($"{_TestString}a");
                    });

                Good_Act.Handle()(_TestString, _TestString);
                Bad_Act.Handle()(_TestString, _TestString);

                Good_Act.Return(_TestString).Handle()(_TestString, _TestString).Should().Be(_TestString);
                Bad_Act.Return(_TestString).Handle()(_TestString, _TestString).Should().Be(default(string));

                L.Exc.DefaultExceptionHandler = Temp;
                }
            }

        [Fact]
        public void Test_Handle_3()
            {
            lock (this)
                {
                Action<Exception> Temp = L.Exc.DefaultExceptionHandler;

                L.Exc.DefaultExceptionHandler = Ex =>
                    {
                    Ex.Should().BeOfType<ArgumentException>();
                    Ex.Message.Should().Be($"{_TestString}a");
                    };

                var Good_Act = new Action<string, string, string>((o1, o2, o3) =>
                    {
                    o1.Should().Be(_TestString);
                    o2.Should().Be(_TestString);
                    o3.Should().Be(_TestString);
                    });
                var Bad_Act = new Action<string, string, string>((o1, o2, o3) =>
                    {
                    o1.Should().Be(_TestString);
                    o2.Should().Be(_TestString);
                    o3.Should().Be(_TestString);
                    throw new ArgumentException($"{_TestString}a");
                    });

                Good_Act.Handle()(_TestString, _TestString, _TestString);
                Bad_Act.Handle()(_TestString, _TestString, _TestString);

                Good_Act.Return(_TestString).Handle()(_TestString, _TestString, _TestString).Should().Be(_TestString);
                Bad_Act.Return(_TestString).Handle()(_TestString, _TestString, _TestString).Should().Be(default(string));

                L.Exc.DefaultExceptionHandler = Temp;
                }
            }

        [Fact]
        public void Test_Handle_4()
            {
            lock (this)
                {
                Action<Exception> Temp = L.Exc.DefaultExceptionHandler;

                L.Exc.DefaultExceptionHandler = Ex =>
                    {
                    Ex.Should().BeOfType<ArgumentException>();
                    Ex.Message.Should().Be($"{_TestString}a");
                    };

                var Good_Act = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                    {
                    o1.Should().Be(_TestString);
                    o2.Should().Be(_TestString);
                    o3.Should().Be(_TestString);
                    o4.Should().Be(_TestString);
                    });
                var Bad_Act = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                    {
                    o1.Should().Be(_TestString);
                    o2.Should().Be(_TestString);
                    o3.Should().Be(_TestString);
                    o4.Should().Be(_TestString);
                    throw new ArgumentException($"{_TestString}a");
                    });

                Good_Act.Handle()(_TestString, _TestString, _TestString, _TestString);
                Bad_Act.Handle()(_TestString, _TestString, _TestString, _TestString);

                Good_Act.Return(_TestString).Handle()(_TestString, _TestString, _TestString, _TestString).Should().Be(_TestString);
                Bad_Act.Return(_TestString).Handle()(_TestString, _TestString, _TestString, _TestString).Should().Be(default(string));

                L.Exc.DefaultExceptionHandler = Temp;
                }
            }


        [Fact]
        public void Test_Debug_1()
            {
            var Good_Act = new Action<string>(o => { o.Should().Be(_TestString); });
            var Bad_Act = new Action<string>(o =>
                {
                o.Should().Be(_TestString);
                throw new ArgumentException($"{_TestString}a");
                });

            var Handler = new Action<Exception>(Ex => { Ex.Message.Should().Be($"System.String:{_TestString}"); });

            Good_Act.Debug()(_TestString);
            Good_Act.Debug().Catch(Handler)(_TestString);

            Bad_Act.Debug().Catch(Handler)(_TestString);

            Good_Act.Return($"{_TestString}a").Debug().Catch(Handler)(_TestString).Should().Be($"{_TestString}a");
            Bad_Act.Return($"{_TestString}a").Debug().Catch(Handler)(_TestString).Should().Be(default(string));
            }

        [Fact]
        public void Test_Debug_2()
            {
            var Good_Act = new Action<string, string>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                });
            var Bad_Act = new Action<string, string>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                throw new ArgumentException($"{_TestString}a");
                });

            var Handler =
                new Action<Exception>(Ex => { Ex.Message.Should().Be($"System.String:{_TestString}, System.String:{_TestString}"); });

            Good_Act.Debug()(_TestString, _TestString);
            Good_Act.Debug().Catch(Handler)(_TestString, _TestString);

            Bad_Act.Debug().Catch(Handler)(_TestString, _TestString);

            Good_Act.Return($"{_TestString}a").Debug().Catch(Handler)(_TestString, _TestString).Should().Be($"{_TestString}a");
            Bad_Act.Return($"{_TestString}a").Debug().Catch(Handler)(_TestString, _TestString).Should().Be(default(string));
            }

        [Fact]
        public void Test_Debug_3()
            {
            var Good_Act = new Action<string, string, string>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                });
            var Bad_Act = new Action<string, string, string>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                throw new ArgumentException($"{_TestString}a");
                });

            var Handler =
                new Action<Exception>(
                    Ex =>
                        {
                        Ex.Message.Should().Be($"System.String:{_TestString}, System.String:{_TestString}, System.String:{_TestString}");
                        });

            Good_Act.Debug()(_TestString, _TestString, _TestString);
            Good_Act.Debug().Catch(Handler)(_TestString, _TestString, _TestString);

            Bad_Act.Debug().Catch(Handler)(_TestString, _TestString, _TestString);

            Good_Act.Return($"{_TestString}a").Debug().Catch(Handler)(_TestString, _TestString, _TestString).Should().Be($"{_TestString}a");
            Bad_Act.Return($"{_TestString}a").Debug().Catch(Handler)(_TestString, _TestString, _TestString).Should().Be(default(string));
            }

        [Fact]
        public void Test_Debug_4()
            {
            var Good_Act = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);
                });
            var Bad_Act = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);
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