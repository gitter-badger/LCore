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

// ReSharper disable ThrowingSystemException
// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable ConvertToConstant.Local

namespace L_Tests.Tests.Extensions
    {
    [Trait(Category, UnitTests)]
    public class BooleanExtTest : ExtensionTester
        {
        private static readonly string _TestString = Guid.NewGuid().ToString();

        protected override Type[] TestType => new[] {typeof(BooleanExt)};

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Not_0()
            {
            // True works 
            Func<bool> Func = L.Bool.True;
            Func.Not()().Should().BeFalse();

            // False works
            Func<bool> Func2 = () => false;
            Func2.Not()().Should().BeTrue();

            // Exceptions are not hidden
            Func<bool> Func3 = () => { throw new Exception(); };
            Func3.Not().ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Not_1()
            {
            // True works 
            Func<object, bool> Func = o =>
                {
                // Variables are passed.
                o.Should().BeSameAs(_TestString);
                return true;
                };
            Func.Not()(_TestString).Should().BeFalse();

            // False works
            Func<object, bool> Func2 = o =>
                {
                // Variables are passed.
                o.Should().BeSameAs(_TestString);
                return false;
                };
            Func2.Not()(_TestString).Should().BeTrue();

            // Exceptions are not hidden
            Func<object, bool> Func3 = o => { throw new Exception(); };
            Func3.Not().ShouldFail(null);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Not_2()
            {
            // True works 
            Func<object, object, bool> Func = (o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return true;
                };
            Func.Not()(_TestString, _TestString).Should().BeFalse();

            // False works
            Func<object, object, bool> Func2 = (o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return false;
                };
            Func2.Not()(_TestString, _TestString).Should().BeTrue();

            // Exceptions are not hidden
            Func<object, object, bool> Func3 = (o1, o2) => { throw new Exception(); };
            Func3.Not().ShouldFail(null, null);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Not_3()
            {
            // True works 
            Func<object, object, object, bool> Func = (o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return true;
                };
            Func.Not()(_TestString, _TestString, _TestString).Should().BeFalse();

            // False works
            Func<object, object, object, bool> Func2 = (o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return false;
                };
            Func2.Not()(_TestString, _TestString, _TestString).Should().BeTrue();

            // Exceptions are not hidden
            Func<object, object, object, bool> Func3 = (o1, o2, o3) => { throw new Exception(); };
            Func3.Not().ShouldFail(null, null, null);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Not_4()
            {
            // True works 
            Func<object, object, object, object, bool> Func = (o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return true;
                };
            Func.Not()(_TestString, _TestString, _TestString, _TestString).Should().BeFalse();

            // False works
            Func<object, object, object, object, bool> Func2 = (o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return false;
                };
            Func2.Not()(_TestString, _TestString, _TestString, _TestString).Should().Be(true);

            // Exceptions are not hidden
            Func<object, object, object, object, bool> Func3 = (o1, o2, o3, o4) => { throw new Exception(); };
            Func3.Not().ShouldFail(null, null, null, null);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_If_Action_0()
            {
            // False works
            bool Result = true;
            var Action = new Action(() => { Result = false; });

            Action.If(L.Bool.False)();
            Result.Should().BeTrue();

            Action.If(L.Bool.True)();
            Result.Should().BeFalse();

            // true works
            bool Result2 = false;
            var Action2 = new Action(() => { Result2 = true; });

            Action2.If(L.Bool.True)();
            Result2.Should().BeTrue();

            // Exceptions are not hidden
            Action Action3 = () => { throw new Exception(); };
            Action3.If(L.Bool.True).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_If_Action_1()
            {
            var Condition = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.Should().BeSameAs(_TestString);
                return false;
                });
            // False works
            bool Result = false;
            var Action = new Action(() => { Result = true; });

            Action.If(Condition)(_TestString);
            Result.Should().BeFalse();

            Action.If(Condition.Not())(_TestString);
            Result.Should().BeTrue();

            // true works
            var Condition2 = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.Should().BeSameAs(_TestString);
                return true;
                });
            bool Result2 = false;
            var Action2 = new Action(() => { Result2 = true; });

            Action2.If(Condition2)(_TestString);
            Result2.Should().BeTrue();

            // Exceptions are not hidden
            Action Action3 = () => { throw new Exception(); };
            Action3.If(Condition2).ShouldFail(_TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_If_Action_2()
            {
            var Condition = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return false;
                });
            // False works
            bool Result = false;
            var Action = new Action(() => { Result = true; });

            Action.If(Condition)(_TestString, _TestString);
            Result.Should().BeFalse();

            Action.If(Condition.Not())(_TestString, _TestString);
            Result.Should().BeTrue();

            // true works
            var Condition2 = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return true;
                });
            bool Result2 = false;
            var Action2 = new Action(() => { Result2 = true; });

            Action2.If(Condition2)(_TestString, _TestString);
            Result2.Should().BeTrue();

            // Exceptions are not hidden
            Action Act3 = () => { throw new Exception(); };
            Act3.If(Condition2).ShouldFail(_TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_If_Action_3()
            {
            var Condition = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return false;
                });
            // False works
            bool Result = false;
            var Act = new Action(() => { Result = true; });

            Act.If(Condition)(_TestString, _TestString, _TestString);
            Result.Should().BeFalse();

            Act.If(Condition.Not())(_TestString, _TestString, _TestString);
            Result.Should().BeTrue();

            // true works
            var Condition2 = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return true;
                });
            bool Result2 = false;
            var Act2 = new Action(() => { Result2 = true; });

            Act2.If(Condition2)(_TestString, _TestString, _TestString);
            Result2.Should().BeTrue();

            // Exceptions are not hidden
            Action Act3 = () => { throw new Exception(); };
            Act3.If(Condition2).ShouldFail(_TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_If_Action_4()
            {
            var Condition = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return false;
                });
            // False works
            bool Result = false;
            var Act = new Action(() => { Result = true; });

            Act.If(Condition)(_TestString, _TestString, _TestString, _TestString);
            Result.Should().BeFalse();

            Act.If(Condition.Not())(_TestString, _TestString, _TestString, _TestString);
            Result.Should().BeTrue();

            // true works
            var Condition2 = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return true;
                });
            bool Result2 = false;
            var Act2 = new Action(() => { Result2 = true; });

            Act2.If(Condition2)(_TestString, _TestString, _TestString, _TestString);
            Result2.Should().BeTrue();

            // Exceptions are not hidden
            Action Act3 = () => { throw new Exception(); };
            Act3.If(Condition2).ShouldFail(_TestString, _TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_If_Func_0()
            {
            // False works
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.If(L.Bool.False)();
            Result.Should().BeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.If(L.Bool.True)();
            Result2.Should().Be(_TestString);

            // true works
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.If(L.Bool.True)();
            Result3.Should().BeTrue();

            // Result passes through
            Result4.Should().Be(_TestString);

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(L.Bool.True).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_If_Func_1()
            {
            // False works
            var Condition = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.Should().BeSameAs(_TestString);
                return false;
                });
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.If(Condition)(_TestString);
            Result.Should().BeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.If(Condition.Not())(_TestString);
            Result2.Should().Be(_TestString);

            // true works
            var Condition2 = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.Should().BeSameAs(_TestString);
                return true;
                });
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.If(Condition2)(_TestString);
            Result3.Should().BeTrue();

            // Result passes through
            Result4.Should().Be(_TestString);

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(Condition2).ShouldFail(_TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_If_Func_2()
            {
            // False works
            var Condition = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return false;
                });
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.If(Condition)(_TestString, _TestString);
            Result.Should().BeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.If(Condition.Not())(_TestString, _TestString);
            Result2.Should().Be(_TestString);

            // true works
            var Condition2 = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return true;
                });
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.If(Condition2)(_TestString, _TestString);
            Result3.Should().BeTrue();

            // Result passes through
            Result4.Should().Be(_TestString);

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(Condition2).ShouldFail(_TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_If_Func_3()
            {
            // False works
            var Condition = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return false;
                });
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.If(Condition)(_TestString, _TestString, _TestString);
            Result.Should().BeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.If(Condition.Not())(_TestString, _TestString, _TestString);
            Result2.Should().Be(_TestString);

            // true works
            var Condition2 = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return true;
                });
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.If(Condition2)(_TestString, _TestString, _TestString);
            Result3.Should().BeTrue();

            // Result passes through
            Result4.Should().Be(_TestString);

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(Condition2).ShouldFail(_TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_If_Func_4()
            {
            // False works
            var Condition = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return false;
                });
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.If(Condition)(_TestString, _TestString, _TestString, _TestString);
            Result.Should().BeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.If(Condition.Not())(_TestString, _TestString, _TestString, _TestString);
            Result2.Should().Be(_TestString);

            // true works
            var Condition2 = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return true;
                });
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.If(Condition2)(_TestString, _TestString, _TestString, _TestString);
            Result3.Should().BeTrue();

            // Result passes through
            Result4.Should().Be(_TestString);

            // Exceptions are not hidden
            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(Condition2).ShouldFail(_TestString, _TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_If_Action_Multiple_0()
            {
            // False works - AND is applied
            bool Result = true;
            var Act = new Action(() =>
                {
                Result = false;
                throw new Exception();
                });

            bool Result2 = Act.If(L.Bool.True, L.Bool.True, L.Bool.False)();
            Result.Should().BeTrue();

            // Result does not pass through
            Result2.Should().BeFalse();
            Act.If(L.Bool.True, L.Bool.True, L.Bool.True).ShouldFail();

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Action(() => { Result3 = true; });

            bool Result4 = Act2.If(L.Bool.True, L.Bool.True, L.Bool.True)();
            Result3.Should().BeTrue();

            // Result passes through
            Result4.Should().BeTrue();

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(L.Bool.True, L.Bool.True, L.Bool.True).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_If_Action_Multiple_1()
            {
            var True = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.Should().Be(_TestString);
                return true;
                });

            var False = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.Should().Be(_TestString);
                return false;
                });

            // False works - AND is applied
            bool Result = true;
            var Act = new Action(() =>
                {
                Result = false;
                throw new Exception();
                });

            bool Result2 = Act.If(True, True, False)(_TestString);
            Result.Should().BeTrue();
            Act.If(True, True, True).ShouldFail(_TestString);

            // Result works
            Result2.Should().BeFalse();

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Action(() => { Result3 = true; });

            bool Result4 = Act2.If(True, True, True)(_TestString);
            Result3.Should().BeTrue();

            // Result works
            Result4.Should().BeTrue();

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(True, True, True).ShouldFail(_TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_If_Action_Multiple_2()
            {
            var True = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return true;
                });

            var False = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return false;
                });

            // False works - AND is applied
            bool Result = true;
            var Act = new Action(() =>
                {
                Result = false;
                throw new Exception();
                });

            bool Result2 = Act.If(True, True, False)(_TestString, _TestString);
            Result.Should().BeTrue();
            Act.If(True, True, True).ShouldFail(_TestString, _TestString);

            // Result works
            Result2.Should().BeFalse();

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Action(() => { Result3 = true; });

            bool Result4 = Act2.If(True, True, True)(_TestString, _TestString);
            Result3.Should().BeTrue();

            // Result works
            Result4.Should().BeTrue();

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(True, True, True).ShouldFail(_TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_If_Action_Multiple_3()
            {
            var True = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return true;
                });

            var False = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return false;
                });

            // False works - AND is applied
            bool Result = true;
            var Act = new Action(() =>
                {
                Result = false;
                throw new Exception();
                });

            bool Result2 = Act.If(True, True, False)(_TestString, _TestString, _TestString);
            Result.Should().BeTrue();
            Act.If(True, True, True).ShouldFail(_TestString, _TestString, _TestString);

            // Result works
            Result2.Should().BeFalse();

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Action(() => { Result3 = true; });

            bool Result4 = Act2.If(True, True, True)(_TestString, _TestString, _TestString);
            Result3.Should().BeTrue();

            // Result works
            Result4.Should().BeTrue();

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(True, True, True).ShouldFail(_TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_If_Action_Multiple_4()
            {
            var True = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return true;
                });

            var False = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return false;
                });

            // False works - AND is applied
            bool Result = true;
            var Act = new Action(() =>
                {
                Result = false;
                throw new Exception();
                });

            bool Result2 = Act.If(True, True, False)(_TestString, _TestString, _TestString, _TestString);
            Result.Should().BeTrue();
            Act.If(True, True, True).ShouldFail(_TestString, _TestString, _TestString, _TestString);

            // Result works
            Result2.Should().BeFalse();

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Action(() => { Result3 = true; });

            bool Result4 = Act2.If(True, True, True)(_TestString, _TestString, _TestString, _TestString);
            Result3.Should().BeTrue();

            // Result works
            Result4.Should().BeTrue();

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(True, True, True).ShouldFail(_TestString, _TestString, _TestString, _TestString);
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_If_Func_Multiple_0()
            {
            // False works - AND is applied
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.If(L.Bool.True, L.Bool.True, L.Bool.False)();
            Result.Should().BeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.If(L.Bool.True, L.Bool.True, L.Bool.True)();
            Result2.Should().Be(_TestString);

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.If(L.Bool.True, L.Bool.True, L.Bool.True)();
            Result3.Should().BeTrue();

            // Result passes through
            Result4.Should().Be(_TestString);

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(L.Bool.True, L.Bool.True, L.Bool.True).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_If_Func_Multiple_1()
            {
            var True = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.Should().Be(_TestString);
                return true;
                });

            var False = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.Should().Be(_TestString);
                return false;
                });

            // False works - AND is applied
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.If(True, True, False)(_TestString);
            Result.Should().BeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.If(True, True, True)(_TestString);
            Result2.Should().Be(_TestString);

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.If(True, True, True)(_TestString);
            Result3.Should().BeTrue();

            // Result passes through
            Result4.Should().Be(_TestString);

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(True, True, True).ShouldFail(_TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_If_Func_Multiple_2()
            {
            var True = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return true;
                });

            var False = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return false;
                });

            // False works - AND is applied
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.If(True, True, False)(_TestString, _TestString);
            Result.Should().BeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.If(True, True, True)(_TestString, _TestString);
            Result2.Should().Be(_TestString);

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.If(True, True, True)(_TestString, _TestString);
            Result3.Should().BeTrue();

            // Result passes through
            Result4.Should().Be(_TestString);

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(True, True, True).ShouldFail(_TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_If_Func_Multiple_3()
            {
            var True = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return true;
                });

            var False = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return false;
                });

            // False works - AND is applied
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.If(True, True, False)(_TestString, _TestString, _TestString);
            Result.Should().BeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.If(True, True, True)(_TestString, _TestString, _TestString);
            Result2.Should().Be(_TestString);

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.If(True, True, True)(_TestString, _TestString, _TestString);
            Result3.Should().BeTrue();

            // Result passes through
            Result4.Should().Be(_TestString);

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(True, True, True).ShouldFail(_TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_If_Func_Multiple_4()
            {
            var True = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return true;
                });

            var False = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return false;
                });

            // False works - AND is applied
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.If(True, True, False)(_TestString, _TestString, _TestString, _TestString);
            Result.Should().BeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.If(True, True, True)(_TestString, _TestString, _TestString, _TestString);
            Result2.Should().Be(_TestString);

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.If(True, True, True)(_TestString, _TestString, _TestString, _TestString);
            Result3.Should().BeTrue();

            // Result passes through
            Result4.Should().Be(_TestString);

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(True, True, True).ShouldFail(_TestString, _TestString, _TestString, _TestString);
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Else_If_0()
            {
            var False = new Func<bool>(() => false);
            var True = new Func<bool>(() => true);

            bool ActionRun = false;

            var ActionMustNotRun = new Action(() => { throw new Exception(); });
            var ActionMustNotRun2 = new Func<bool>(() => { throw new Exception(); });

            var ActionMustRun = new Action(() => { ActionRun = true; });
            var ActionMustRun2 = new Func<bool>(() =>
                {
                ActionRun = true;
                return false;
                });

            // Action did not run.
            True.ElseIf(ActionMustNotRun2, ActionMustNotRun)();

            False.ElseIf(True, ActionMustNotRun).ShouldFail();
            False.ElseIf(ActionMustNotRun2, True).ShouldFail();

            // Action did run.
            False.ElseIf(True, ActionMustRun)();
            ActionRun.Should().BeTrue();

            ActionRun = false;

            // Action did run.
            False.ElseIf(ActionMustRun2, L.E)();
            ActionRun.Should().BeTrue();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Else_If_1()
            {
            var False = new Func<object, bool>(o => false);
            var True = new Func<object, bool>(o => true);

            bool ActionRun = false;

            var ActionMustNotRun = new Action<object>(o => { throw new Exception(); });
            var ActionMustNotRun2 = new Func<object, bool>(o => { throw new Exception(); });

            var ActionMustRun = new Action<object>(o =>
                {
                // Variables are passed.
                o.Should().Be(_TestString);

                ActionRun = true;
                });
            var ActionMustRun2 = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.Should().Be(_TestString);

                ActionRun = true;
                return false;
                });

            // Action did not run.
            True.ElseIf(ActionMustNotRun2, ActionMustNotRun)(_TestString);

            False.ElseIf(True, ActionMustNotRun).ShouldFail(_TestString);
            False.ElseIf(ActionMustNotRun2, True).ShouldFail(_TestString);

            // Action did run.
            False.ElseIf(True, ActionMustRun)(_TestString);
            ActionRun.Should().BeTrue();

            ActionRun = false;

            // Action did run.
            False.ElseIf(ActionMustRun2, ActionMustRun)(_TestString);
            ActionRun.Should().BeTrue();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Else_If_2()
            {
            var False = new Func<object, object, bool>((o1, o2) => false);
            var True = new Func<object, object, bool>((o1, o2) => true);

            bool ActionRun = false;

            var ActionMustNotRun = new Action<object, object>((o1, o2) => { throw new Exception(); });
            var ActionMustNotRun2 = new Func<object, object, bool>((o1, o2) => { throw new Exception(); });

            var ActionMustRun = new Action<object, object>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);

                ActionRun = true;
                });
            var ActionMustRun2 = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);

                ActionRun = true;
                return false;
                });

            // Action did not run.
            True.ElseIf(ActionMustNotRun2, ActionMustNotRun)(_TestString, _TestString);

            // Action did run.
            False.ElseIf(True, ActionMustRun)(_TestString, _TestString);
            ActionRun.Should().BeTrue();

            False.ElseIf(True, ActionMustNotRun).ShouldFail(_TestString, _TestString);
            False.ElseIf(ActionMustNotRun2, True).ShouldFail(_TestString, _TestString);

            ActionRun = false;

            // Action did run.
            False.ElseIf(ActionMustRun2, ActionMustRun)(_TestString, _TestString);
            ActionRun.Should().BeTrue();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Else_If_3()
            {
            var False = new Func<object, object, object, bool>((o1, o2, o3) => false);
            var True = new Func<object, object, object, bool>((o1, o2, o3) => true);

            bool ActionRun = false;

            var ActionMustNotRun = new Action<object, object, object>((o1, o2, o3) => { throw new Exception(); });
            var ActionMustNotRun2 = new Func<object, object, object, bool>((o1, o2, o3) => { throw new Exception(); });

            var ActionMustRun = new Action<object, object, object>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);

                ActionRun = true;
                });
            var ActionMustRun2 = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);

                ActionRun = true;
                return false;
                });

            // Action did not run.
            True.ElseIf(ActionMustNotRun2, ActionMustNotRun)(_TestString, _TestString, _TestString);

            // Action did run.
            False.ElseIf(True, ActionMustRun)(_TestString, _TestString, _TestString);
            ActionRun.Should().BeTrue();

            False.ElseIf(True, ActionMustNotRun).ShouldFail(_TestString, _TestString, _TestString);
            False.ElseIf(ActionMustNotRun2, True).ShouldFail(_TestString, _TestString, _TestString);

            ActionRun = false;

            // Action did run.
            False.ElseIf(ActionMustRun2, ActionMustRun)(_TestString, _TestString, _TestString);
            ActionRun.Should().BeTrue();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Else_If_4()
            {
            var False = new Func<object, object, object, object, bool>((o1, o2, o3, o4) => false);
            var True = new Func<object, object, object, object, bool>((o1, o2, o3, o4) => true);

            bool ActionRun = false;

            var ActionMustNotRun = new Action<object, object, object, object>((o1, o2, o3, o4) => { throw new Exception(); });
            var ActionMustNotRun2 = new Func<object, object, object, object, bool>((o1, o2, o3, o4) => { throw new Exception(); });

            var ActionMustRun = new Action<object, object, object, object>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);

                ActionRun = true;
                });
            var ActionMustRun2 = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);

                ActionRun = true;
                return false;
                });

            // Action did not run.
            True.ElseIf(ActionMustNotRun2, ActionMustNotRun)(_TestString, _TestString, _TestString, _TestString);

            // Action did run.
            False.ElseIf(True, ActionMustRun)(_TestString, _TestString, _TestString, _TestString);
            ActionRun.Should().BeTrue();

            False.ElseIf(True, ActionMustNotRun).ShouldFail(_TestString, _TestString, _TestString, _TestString);
            False.ElseIf(ActionMustNotRun2, True).ShouldFail(_TestString, _TestString, _TestString, _TestString);

            ActionRun = false;

            // Action did run.
            False.ElseIf(ActionMustRun2, ActionMustRun)(_TestString, _TestString, _TestString, _TestString);
            ActionRun.Should().BeTrue();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Else_If_Func_0()
            {
            var False = new Func<bool>(() => false);
            var True = new Func<bool>(() => true);

            bool ActionRun = false;

            var ActionMustNotRun = new Func<bool>(() => { throw new Exception(); });

            var ActionMustRun = new Func<bool>(() =>
                {
                ActionRun = true;
                return false;
                });

            // Action did not run.
            True.ElseIf(ActionMustNotRun, ActionMustNotRun)();

            False.ElseIf(ActionMustNotRun, True).ShouldFail();
            False.ElseIf(True, ActionMustNotRun).ShouldFail();

            // Action did run.
            False.ElseIf(True, ActionMustRun)();
            ActionRun.Should().BeTrue();

            ActionRun = false;

            // Action did run.
            False.ElseIf(ActionMustRun, L.Bool.True)();
            ActionRun.Should().BeTrue();

            // Result was passed.
            bool Result = False.ElseIf(True, True)();
            Result.Should().BeTrue();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Else_If_Func_1()
            {
            var False = new Func<object, bool>(o => false);
            var True = new Func<object, bool>(o => true);

            bool ActionRun = false;

            var ActionMustNotRun = new Func<object, bool>(o => { throw new Exception(); });

            var ActionMustRun = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.Should().Be(_TestString);

                ActionRun = true;
                return false;
                });

            // Action did not run.
            True.ElseIf(ActionMustNotRun, ActionMustNotRun)(_TestString);

            // Action did run.
            False.ElseIf(True, ActionMustRun)(_TestString);
            ActionRun.Should().BeTrue();

            False.ElseIf(ActionMustNotRun, True).ShouldFail(_TestString);
            False.ElseIf(True, ActionMustNotRun).ShouldFail(_TestString);

            ActionRun = false;

            // Action did run.
            False.ElseIf(ActionMustRun, ActionMustRun)(_TestString);
            ActionRun.Should().BeTrue();

            // Result was passed.
            bool Result = False.ElseIf(True, True)(_TestString);
            Result.Should().BeTrue();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Else_If_Func_2()
            {
            var False = new Func<object, object, bool>((o1, o2) => false);
            var True = new Func<object, object, bool>((o1, o2) => true);

            bool ActionRun = false;

            var ActionMustNotRun = new Func<object, object, bool>((o1, o2) => { throw new Exception(); });

            var ActionMustRun = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);

                ActionRun = true;
                return false;
                });

            // Action did not run.
            True.ElseIf(ActionMustNotRun, ActionMustNotRun)(_TestString, _TestString);

            // Action did run.
            False.ElseIf(True, ActionMustRun)(_TestString, _TestString);
            ActionRun.Should().BeTrue();

            False.ElseIf(ActionMustNotRun, True).ShouldFail(_TestString, _TestString);
            False.ElseIf(True, ActionMustNotRun).ShouldFail(_TestString, _TestString);

            ActionRun = false;

            // Action did run.
            False.ElseIf(ActionMustRun, ActionMustRun)(_TestString, _TestString);
            ActionRun.Should().BeTrue();

            // Result was passed.
            bool Result = False.ElseIf(True, True)(_TestString, _TestString);
            Result.Should().BeTrue();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Else_If_Func_3()
            {
            var False = new Func<object, object, object, bool>((o1, o2, o3) => false);
            var True = new Func<object, object, object, bool>((o1, o2, o3) => true);

            bool ActionRun = false;

            var ActionMustNotRun = new Func<object, object, object, bool>((o1, o2, o3) => { throw new Exception(); });

            var ActionMustRun = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);

                ActionRun = true;
                return false;
                });

            // Action did not run.
            True.ElseIf(ActionMustNotRun, ActionMustNotRun)(_TestString, _TestString, _TestString);

            // Action did run.
            False.ElseIf(True, ActionMustRun)(_TestString, _TestString, _TestString);
            ActionRun.Should().BeTrue();

            False.ElseIf(ActionMustNotRun, True).ShouldFail(_TestString, _TestString, _TestString);
            False.ElseIf(True, ActionMustNotRun).ShouldFail(_TestString, _TestString, _TestString);

            ActionRun = false;

            // Action did run.
            False.ElseIf(ActionMustRun, ActionMustRun)(_TestString, _TestString, _TestString);
            ActionRun.Should().BeTrue();

            // Result was passed.
            bool Result = False.ElseIf(True, True)(_TestString, _TestString, _TestString);
            Result.Should().BeTrue();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Else_If_Func_4()
            {
            var False = new Func<object, object, object, object, bool>((o1, o2, o3, o4) => false);
            var True = new Func<object, object, object, object, bool>((o1, o2, o3, o4) => true);

            bool ActionRun = false;

            var ActionMustNotRun = new Func<object, object, object, object, bool>((o1, o2, o3, o4) => { throw new Exception(); });

            var ActionMustRun = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);

                ActionRun = true;
                return false;
                });

            // Action did not run.
            True.ElseIf(ActionMustNotRun, ActionMustNotRun)(_TestString, _TestString, _TestString, _TestString);

            // Action did run.
            False.ElseIf(True, ActionMustRun)(_TestString, _TestString, _TestString, _TestString);
            ActionRun.Should().BeTrue();

            False.ElseIf(ActionMustNotRun, True).ShouldFail(_TestString, _TestString, _TestString, _TestString);
            False.ElseIf(True, ActionMustNotRun).ShouldFail(_TestString, _TestString, _TestString, _TestString);

            ActionRun = false;

            // Action did run.
            False.ElseIf(ActionMustRun, ActionMustRun)(_TestString, _TestString, _TestString, _TestString);
            ActionRun.Should().BeTrue();

            // Result was passed.
            bool Result = False.ElseIf(True, True)(_TestString, _TestString, _TestString, _TestString);
            Result.Should().BeTrue();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Unless_Action_0()
            {
            // False works
            bool Result = true;
            var Act = new Action(() =>
                {
                Result = false;
                throw new Exception();
                });

            Act.Unless(L.Bool.True, L.Bool.False)();
            Result.Should().BeTrue();
            L.A(() => Act.Unless(L.Bool.False)()).ShouldFail();

            // true works
            bool Result2 = false;
            var Act2 = new Action(() => { Result2 = true; });

            Act2.Unless(L.Bool.False, L.Bool.False)();
            Result2.Should().BeTrue();

            // Exceptions are not hidden
            Action Act3 = () => { throw new Exception(); };
            Act3.Unless(L.Bool.False, L.Bool.False).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Unless_Action_1()
            {
            var Condition = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.Should().BeSameAs(_TestString);
                return true;
                });
            // False works
            bool Result = false;
            var Act = new Action(() =>
                {
                Result = true;
                throw new Exception();
                });

            Act.Unless(Condition, Condition.Not())(_TestString);
            Result.Should().BeFalse();
            L.A(() => Act.Unless(L.Bool.False, L.Bool.False)()).ShouldFail();

            // true works
            var Condition2 = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.Should().BeSameAs(_TestString);
                return false;
                });
            bool Result2 = false;
            var Act2 = new Action(() => { Result2 = true; });

            Act2.Unless(Condition2, Condition2)(_TestString);
            Result2.Should().BeTrue();

            // Exceptions are not hidden
            Action Act3 = () => { throw new Exception(); };
            Act3.Unless(Condition2, Condition2).ShouldFail(_TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Unless_Action_2()
            {
            var Condition = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return true;
                });
            // False works
            bool Result = false;
            var Act = new Action(() =>
                {
                Result = true;
                throw new Exception();
                });

            Act.Unless(Condition, Condition.Not())(_TestString, _TestString);
            Result.Should().BeFalse();
            Act.Unless(Condition.Not(), Condition.Not()).ShouldFail(_TestString, _TestString);

            // true works
            var Condition2 = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return false;
                });
            bool Result2 = false;
            var Act2 = new Action(() => { Result2 = true; });

            Act2.Unless(Condition2, Condition2)(_TestString, _TestString);
            Result2.Should().BeTrue();

            // Exceptions are not hidden
            // Exceptions are not hidden
            Action Act3 = () => { throw new Exception(); };
            Act3.Unless(Condition2, Condition2).ShouldFail(_TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Unless_Action_3()
            {
            var Condition = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return true;
                });
            // False works
            bool Result = false;
            var Act = new Action(() =>
                {
                Result = true;
                throw new Exception();
                });

            Act.Unless(Condition, Condition.Not())(_TestString, _TestString, _TestString);
            Result.Should().BeFalse();
            Act.Unless(Condition.Not(), Condition.Not()).ShouldFail(_TestString, _TestString, _TestString);

            // true works
            var Condition2 = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return false;
                });
            bool Result2 = false;
            var Act2 = new Action(() => { Result2 = true; });

            Act2.Unless(Condition2, Condition2)(_TestString, _TestString, _TestString);
            Result2.Should().BeTrue();

            // Exceptions are not hidden
            // Exceptions are not hidden
            Action Act3 = () => { throw new Exception(); };
            Act3.Unless(Condition2, Condition2).ShouldFail(_TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Unless_Action_4()
            {
            var Condition = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return true;
                });
            // False works
            bool Result = false;
            var Act = new Action(() =>
                {
                Result = true;
                throw new Exception();
                });

            Act.Unless(Condition, Condition.Not())(_TestString, _TestString, _TestString, _TestString);
            Result.Should().BeFalse();
            Act.Unless(Condition.Not(), Condition.Not()).ShouldFail(_TestString, _TestString, _TestString, _TestString);

            // true works
            var Condition2 = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return false;
                });
            bool Result2 = false;
            var Act2 = new Action(() => { Result2 = true; });

            Act2.Unless(Condition2, Condition2)(_TestString, _TestString, _TestString, _TestString);
            Result2.Should().BeTrue();

            // Exceptions are not hidden
            Action Act3 = () => { throw new Exception(); };
            Act3.Unless(Condition2, Condition2).ShouldFail(_TestString, _TestString, _TestString, _TestString);
            }


        [Fact]
        public void Test_Or_0()
            {
            var True = new Func<bool>(() => true);
            var False = new Func<bool>(() => false);

            new[] {False, False, False, False}.Or()().Should().BeFalse();
            new[] {False, False, False, True}.Or()().Should().BeTrue();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Or_1()
            {
            var True = new Func<object, bool>(o =>
                {
                o.Should().Be(_TestString);
                return true;
                });
            var False = new Func<object, bool>(o =>
                {
                o.Should().Be(_TestString);
                return false;
                });
            var NotRun = new Func<object, bool>(o =>
                {
                o.Should().Be(_TestString);
                throw new Exception();
                });

            new[] {False, False, False, False}.Or()(_TestString).Should().BeFalse();
            new[] {False, False, False, True}.Or()(_TestString).Should().BeTrue();

            // True blocks execution of later items
            new[] {False, False, True, NotRun}.Or()(_TestString).Should().BeTrue();
            L.A(() => new[] {False, False, False, NotRun}.Or()(_TestString)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Or_2()
            {
            var True = new Func<object, object, bool>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                return true;
                });
            var False = new Func<object, object, bool>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                return false;
                });
            var NotRun = new Func<object, object, bool>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                throw new Exception();
                });

            new[] {False, False, False, False}.Or()(_TestString, _TestString).Should().BeFalse();
            new[] {False, False, False, True}.Or()(_TestString, _TestString).Should().BeTrue();

            // True blocks execution of later items
            new[] {False, False, True, NotRun}.Or()(_TestString, _TestString).Should().BeTrue();
            L.A(() => new[] {False, False, False, NotRun}.Or()(_TestString, _TestString)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Or_3()
            {
            var True = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                return true;
                });
            var False = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                return false;
                });
            var NotRun = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                throw new Exception();
                });

            new[] {False, False, False, False}.Or()(_TestString, _TestString, _TestString).Should().BeFalse();
            new[] {False, False, False, True}.Or()(_TestString, _TestString, _TestString).Should().BeTrue();

            // True blocks execution of later items
            new[] {False, False, True, NotRun}.Or()(_TestString, _TestString, _TestString).Should().BeTrue();
            L.A(() => new[] {False, False, False, NotRun}.Or()(_TestString, _TestString, _TestString)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Or_4()
            {
            var True = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);
                return true;
                });
            var False = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);
                return false;
                });
            var NotRun = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);
                throw new Exception();
                });

            new[] {False, False, False, False}.Or()(_TestString, _TestString, _TestString, _TestString).Should().BeFalse();
            new[] {False, False, False, True}.Or()(_TestString, _TestString, _TestString, _TestString).Should().BeTrue();

            // True blocks execution of later items
            new[] {False, False, True, NotRun}.Or()(_TestString, _TestString, _TestString, _TestString).Should().BeTrue();
            L.A(() => new[] {False, False, False, NotRun}.Or()(_TestString, _TestString, _TestString, _TestString)).ShouldFail();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Else_0()
            {
            var True = new Func<bool>(() => true);
            var False = new Func<bool>(() => false);
            var Act = new Action(() => { });
            var DontExecute = new Action(() => { throw new Exception(); });

            Act.If(True).ElseIf(True, DontExecute).Else(DontExecute)();

            DontExecute.If(False).ElseIf(False, DontExecute).Else(Act)();

            L.A(() => Act.If(False).ElseIf(False, DontExecute).Else(DontExecute)()).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Else_1()
            {
            var True = new Func<object, bool>(o =>
                {
                o.Should().Be(_TestString);
                return true;
                });
            var False = new Func<object, bool>(o =>
                {
                o.Should().Be(_TestString);
                return false;
                });
            var Act = new Action<object>(o => { o.Should().Be(_TestString); });
            var DontExecute = new Action<object>(o =>
                {
                o.Should().Be(_TestString);
                throw new Exception();
                });

            True.Else(DontExecute)(_TestString);

            False.Else(Act)(_TestString);

            L.A(() => False.Else(DontExecute)(_TestString)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Else_2()
            {
            var True = new Func<object, object, bool>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                return true;
                });
            var False = new Func<object, object, bool>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                return false;
                });
            var Act = new Action<object, object>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                });
            var DontExecute = new Action<object, object>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                throw new Exception();
                });

            True.Else(DontExecute)(_TestString, _TestString);

            False.Else(Act)(_TestString, _TestString);

            L.A(() => False.Else(DontExecute)(_TestString, _TestString)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Else_3()
            {
            var True = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                return true;
                });
            var False = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                return false;
                });
            var Act = new Action<object, object, object>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                });
            var DontExecute = new Action<object, object, object>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                throw new Exception();
                });

            True.Else(DontExecute)(_TestString, _TestString, _TestString);

            False.Else(Act)(_TestString, _TestString, _TestString);

            L.A(() => False.Else(DontExecute)(_TestString, _TestString, _TestString)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Else_4()
            {
            var True = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);
                return true;
                });
            var False = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);
                return false;
                });
            var Act = new Action<object, object, object, object>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);
                });
            var DontExecute = new Action<object, object, object, object>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                o4.Should().Be(_TestString);
                throw new Exception();
                });

            True.Else(DontExecute)(_TestString, _TestString, _TestString, _TestString);

            False.Else(Act)(_TestString, _TestString, _TestString, _TestString);

            L.A(() => False.Else(DontExecute)(_TestString, _TestString, _TestString, _TestString)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Else_U_0()
            {
            var True = new Func<bool>(() => true);
            var False = new Func<bool>(() => false);
            var Act = new Func<int>(() => 5);
            var DontExecute = new Func<int>(() => { throw new Exception(); });
            int Result = 10;


            Act.If(True).ElseIf(True, DontExecute).Else(Result)().Should().Be(5);
            Act.If(False).ElseIf(False, DontExecute).Else(Result)().Should().Be(10);

            DontExecute.If(False).ElseIf(False, DontExecute).Else(Result)().Should().Be(10);

            L.A(() => Act.If(False).ElseIf(True, DontExecute).Else(Result)()).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Else_U_1()
            {
            var True = new Func<object, int>(o =>
                {
                o.Should().Be(_TestString);
                return 1;
                });
            var False = new Func<object, int>(o =>
                {
                o.Should().Be(_TestString);
                return default(int);
                });
            var DontExecute = new Func<object, int>(o =>
                {
                o.Should().Be(_TestString);
                throw new Exception();
                });

            int Result = 10;

            True.Else(DontExecute)(_TestString).Should().Be(1);
            False.Else(Result)(_TestString).Should().Be(10);

            L.A(() => False.Else(DontExecute)(_TestString)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Else_U_2()
            {
            var True = new Func<object, object, int>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                return 1;
                });
            var False = new Func<object, object, int>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                return default(int);
                });
            var DontExecute = new Func<object, object, int>((o1, o2) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                throw new Exception();
                });

            int Result = 10;

            True.Else(DontExecute)(_TestString, _TestString).Should().Be(1);
            False.Else(Result)(_TestString, _TestString).Should().Be(10);

            L.A(() => False.Else(DontExecute)(_TestString, _TestString)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Else_U_3()
            {
            var True = new Func<object, object, object, int>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                return 1;
                });
            var False = new Func<object, object, object, int>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                return default(int);
                });
            var DontExecute = new Func<object, object, object, int>((o1, o2, o3) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                throw new Exception();
                });

            int Result = 10;

            True.Else(DontExecute)(_TestString, _TestString, _TestString).Should().Be(1);
            False.Else(Result)(_TestString, _TestString, _TestString).Should().Be(10);

            L.A(() => False.Else(DontExecute)(_TestString, _TestString, _TestString)).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Else_U_4()
            {
            var True = new Func<object, object, object, object, int>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                return 1;
                });
            var False = new Func<object, object, object, object, int>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                return default(int);
                });
            var DontExecute = new Func<object, object, object, object, int>((o1, o2, o3, o4) =>
                {
                o1.Should().Be(_TestString);
                o2.Should().Be(_TestString);
                o3.Should().Be(_TestString);
                throw new Exception();
                });

            int Result = 10;

            True.Else(DontExecute)(_TestString, _TestString, _TestString, _TestString).Should().Be(1);
            False.Else(Result)(_TestString, _TestString, _TestString, _TestString).Should().Be(10);

            L.A(() => False.Else(DontExecute)(_TestString, _TestString, _TestString, _TestString)).ShouldFail();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Unless_Func_Multiple_0()
            {
            // False works - AND is applied
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.Unless(L.Bool.True, L.Bool.False, L.Bool.False)();
            Result.Should().BeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.Unless(L.Bool.False, L.Bool.False, L.Bool.False)();
            Result2.Should().Be(_TestString);

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.Unless(L.Bool.False, L.Bool.False, L.Bool.False)();
            Result3.Should().BeTrue();

            // Result passes through
            Result4.Should().Be(_TestString);

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.Unless(L.Bool.False, L.Bool.False, L.Bool.False).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Unless_Func_Multiple_1()
            {
            var True = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.Should().Be(_TestString);
                return true;
                });

            var False = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.Should().Be(_TestString);
                return false;
                });

            // False works - AND is applied
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.Unless(True, False, False)(_TestString);
            Result.Should().BeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.Unless(False, False, False)(_TestString);
            Result2.Should().Be(_TestString);

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.Unless(False, False, False)(_TestString);
            Result3.Should().BeTrue();

            // Result passes through
            Result4.Should().Be(_TestString);

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.Unless(False, False, False).ShouldFail(_TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Unless_Func_Multiple_2()
            {
            var True = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return true;
                });

            var False = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return false;
                });

            // False works - AND is applied
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.Unless(True, False, False)(_TestString, _TestString);
            Result.Should().BeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.Unless(False, False, False)(_TestString, _TestString);
            Result2.Should().Be(_TestString);

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.Unless(False, False, False)(_TestString, _TestString);
            Result3.Should().BeTrue();

            // Result passes through
            Result4.Should().Be(_TestString);

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.Unless(False, False, False).ShouldFail(_TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Unless_Func_Multiple_3()
            {
            var True = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return true;
                });

            var False = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return false;
                });

            // False works - AND is applied
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.Unless(True, False, False)(_TestString, _TestString, _TestString);
            Result.Should().BeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.Unless(False, False, False)(_TestString, _TestString, _TestString);
            Result2.Should().Be(_TestString);

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.Unless(False, False, False)(_TestString, _TestString, _TestString);
            Result3.Should().BeTrue();

            // Result passes through
            Result4.Should().Be(_TestString);

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.Unless(False, False, False).ShouldFail(_TestString, _TestString, _TestString);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Unless_Func_Multiple_4()
            {
            var True = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return true;
                });

            var False = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return false;
                });

            // False works - AND is applied
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.Unless(True, False, False)(_TestString, _TestString, _TestString, _TestString);
            Result.Should().BeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.Unless(False, False, False)(_TestString, _TestString, _TestString, _TestString);
            Result2.Should().Be(_TestString);

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.Unless(False, False, False)(_TestString, _TestString, _TestString, _TestString);
            Result3.Should().BeTrue();

            // Result passes through
            Result4.Should().Be(_TestString);

            // Exceptions are not hidden
            Func<string> Action3 = () => { throw new Exception(); };
            Action3.Unless(False, False, False).ShouldFail(_TestString, _TestString, _TestString, _TestString);
            }

        public BooleanExtTest([NotNull] ITestOutputHelper Output) : base(Output) {}
        }
    }