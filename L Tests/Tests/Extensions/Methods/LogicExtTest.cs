
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using LCore.Tests;
using static LCore.Extensions.L.Test.Categories;

namespace L_Tests.Tests.Extensions
    {
    [TestClass]
    public class LogicExtTest : ExtensionTester
        {
        private static readonly string TestString = Guid.NewGuid().ToString();

        protected override Type[] TestType => new[] { typeof(LogicExt) };


        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Cast_0()
            {
            bool Result = false;
            Action<object> Action = o =>
                {
                    o.Should().Be(TestString);
                    Result = true;
                };
            Action<object> ActionFail = o =>
            {
                throw new Exception();
            };

            Action<string> Action2 = Action.Cast<object, string>();

            Action2(TestString);

            Result.Should().BeTrue();

            // Exceptions are passed.
            ActionFail.Cast<object, string>().ShouldFail(TestString);
            }

        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Cast_1()
            {
            bool Result = false;
            Action<object, object> Action = (o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                Result = true;
            };
            Action<object, object> ActionFail = (o1, o2) =>
            {
                throw new Exception();
            };


            Action<string, string> Action2 = Action.Cast<object, object, string, string>();

            Action2(TestString, TestString);

            Result.Should().BeTrue();

            // Exceptions are passed.
            ActionFail.Cast<object, object, string, string>().ShouldFail(TestString, TestString);
            }


        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_L_A()
            {
            L.A()();
            L.A<int>()(0);
            L.A<int, int>()(0, 0);
            L.A<int, int, int>()(0, 0, 0);
            L.A<int, int, int, int>()(0, 0, 0, 0);
            L.A<int, int, int, int, int>()(0, 0, 0, 0, 0);
            L.A<int, int, int, int, int, int>()(0, 0, 0, 0, 0, 0);
            L.A<int, int, int, int, int, int, int>()(0, 0, 0, 0, 0, 0, 0);
            L.A<int, int, int, int, int, int, int, int>()(0, 0, 0, 0, 0, 0, 0, 0);
            L.A<int, int, int, int, int, int, int, int, int>()(0, 0, 0, 0, 0, 0, 0, 0, 0);
            L.A<int, int, int, int, int, int, int, int, int, int>()(0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            L.A<int, int, int, int, int, int, int, int, int, int, int>()(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            L.A<int, int, int, int, int, int, int, int, int, int, int, int>()(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            L.A<int, int, int, int, int, int, int, int, int, int, int, int, int>()(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            L.A<int, int, int, int, int, int, int, int, int, int, int, int, int, int>()(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            L.A<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>()(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            L.A<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>()(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_L_A_1()
            {
            int Rand = new Random().Next();
            L.A(() => { })();
            L.A<int>(o1 =>
                {
                    o1.Should().Be(Rand);
                })(Rand);
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
            L.A<int, int, int, int, int, int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) =>
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
            L.A<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) =>
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
            L.A<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) =>
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
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_L_F()
            {
            L.F<int>()()
                .Should().Be(default(int));
            L.F<int, int>()(0)
                .Should().Be(default(int));
            L.F<int, int, int>()(0, 0)
                .Should().Be(default(int));
            L.F<int, int, int, int>()(0, 0, 0)
                .Should().Be(default(int));
            L.F<int, int, int, int, int>()(0, 0, 0, 0)
                .Should().Be(default(int));
            L.F<int, int, int, int, int, int>()(0, 0, 0, 0, 0)
                .Should().Be(default(int));
            L.F<int, int, int, int, int, int, int>()(0, 0, 0, 0, 0, 0)
                .Should().Be(default(int));
            L.F<int, int, int, int, int, int, int, int>()(0, 0, 0, 0, 0, 0, 0)
                .Should().Be(default(int));
            L.F<int, int, int, int, int, int, int, int, int>()(0, 0, 0, 0, 0, 0, 0, 0)
                .Should().Be(default(int));
            L.F<int, int, int, int, int, int, int, int, int, int>()(0, 0, 0, 0, 0, 0, 0, 0, 0)
                .Should().Be(default(int));
            L.F<int, int, int, int, int, int, int, int, int, int, int>()(0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                .Should().Be(default(int));
            L.F<int, int, int, int, int, int, int, int, int, int, int, int>()(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                .Should().Be(default(int));
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int>()(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                .Should().Be(default(int));
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int, int>()(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                .Should().Be(default(int));
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>()(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                .Should().Be(default(int));
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>()(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                .Should().Be(default(int));
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>()(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                .Should().Be(default(int));
            }
        [TestMethod]
        [TestCategory(UnitTests)]
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
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) =>
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
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) =>
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
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) =>
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
            L.F<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>((o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) =>
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
        }
    }
