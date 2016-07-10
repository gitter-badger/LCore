
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using LCore.Tests;
using static LCore.Extensions.L.Test.Categories;
// ReSharper disable ExpressionIsAlwaysNull

// ReSharper disable RedundantAssignment
// ReSharper disable RedundantCast

namespace L_Tests.Tests.Extensions
    {
    [TestClass]
    public class ConvertibleExtTest : ExtensionTester
        {
        protected override Type[] TestType => new[] { typeof(ConvertibleExt) };

        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_ConvertTo()
            {
            const string Test = "-5.5555";

            Func<Type, object> ConvertTo = L.F<Type, object>(type => Test.ConvertTo(type));

            ConvertTo.ShouldFail(typeof(int));
            ConvertTo.ShouldFail(typeof(uint));
            ConvertTo.ShouldFail(typeof(long));
            ConvertTo.ShouldFail(typeof(short));
            ConvertTo.ShouldFail(typeof(ushort));
            ConvertTo.ShouldFail(typeof(byte));
            ConvertTo.ShouldFail(typeof(char));
            ConvertTo.ShouldFail(typeof(byte));

            var Result1 = Test.ConvertTo(typeof(double));
            var Result2 = Test.ConvertTo(typeof(float));

            Result1.Should().Be((double)-5.5555);
            Result2.Should().Be((float)-5.5555);


            const string Test2 = "5";

            Test2.ConvertTo(typeof(int)).Should().Be(5);
            Test2.ConvertTo(typeof(uint)).Should().Be((uint)5);
            Test2.ConvertTo(typeof(long)).Should().Be((long)5);
            Test2.ConvertTo(typeof(short)).Should().Be((short)5);
            Test2.ConvertTo(typeof(ushort)).Should().Be((ushort)5);
            Test2.ConvertTo(typeof(byte)).Should().Be((byte)5);
            Test2.ConvertTo(typeof(char)).Should().Be('5');
            }

        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_ConvertTo_T()
            {
            const string Test = "-5.5555";

            L.F<IConvertible, int>(ConvertibleExt.ConvertTo<int>).ShouldFail(Test);
            L.F<IConvertible, uint>(ConvertibleExt.ConvertTo<uint>).ShouldFail(Test);
            L.F<IConvertible, long>(ConvertibleExt.ConvertTo<long>).ShouldFail(Test);
            L.F<IConvertible, short>(ConvertibleExt.ConvertTo<short>).ShouldFail(Test);
            L.F<IConvertible, ushort>(ConvertibleExt.ConvertTo<ushort>).ShouldFail(Test);
            L.F<IConvertible, byte>(ConvertibleExt.ConvertTo<byte>).ShouldFail(Test);
            L.F<IConvertible, char>(ConvertibleExt.ConvertTo<char>).ShouldFail(Test);

            double Result1 = Test.ConvertTo<double>();
            float Result2 = Test.ConvertTo<float>();

            Result1.Should().Be(-5.5555);
            Result2.Should().Be((float)-5.5555);


            const string Test2 = "5";

            Test2.ConvertTo<int>().Should().Be(5);
            Test2.ConvertTo<uint>().Should().Be((uint)5);
            Test2.ConvertTo<long>().Should().Be((long)5);
            Test2.ConvertTo<short>().Should().Be((short)5);
            Test2.ConvertTo<ushort>().Should().Be((ushort)5);
            Test2.ConvertTo<byte>().Should().Be((byte)5);
            Test2.ConvertTo<char>().Should().Be('5');

            ConvertibleExt.ConvertTo<int>(null).Should().Be(default(int));
            }

        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_CanConvertTo()
            {
            IConvertible Test = "5";

            new[] {
                Test.CanConvertTo<int>(),
                Test.CanConvertTo<double>(),
                Test.CanConvertTo<short>(),
                Test.CanConvertTo<float>(),
                Test.CanConvertTo<long>(),
                Test.CanConvertTo<byte>(),
                Test.CanConvertTo<char>(),
                Test.CanConvertTo<uint>(),
                Test.CanConvertTo<ushort>(),
                Test.CanConvertTo<ulong>()
                }.ShouldAllBeEquivalentTo(true);

            Test = 5.5f;

            new[] {
                Test.CanConvertTo<double>(),
                Test.CanConvertTo<float>(),
                Test.CanConvertTo<string>()
                }.ShouldAllBeEquivalentTo(true);

            new[] {
                Test.CanConvertTo<ushort>(),
                Test.CanConvertTo<uint>(),
                Test.CanConvertTo<char>(),
                Test.CanConvertTo<short>(),
                Test.CanConvertTo<long>(),
                Test.CanConvertTo<byte>(),
                Test.CanConvertTo<ulong>(),
                Test.CanConvertTo<int>()
                }.ShouldAllBeEquivalentTo(false);

            Test = -5;

            new[] {
                Test.CanConvertTo<double>(),
                Test.CanConvertTo<float>(),
                Test.CanConvertTo<short>(),
                Test.CanConvertTo<long>(),
                Test.CanConvertTo<int>(),
                Test.CanConvertTo<string>()
                }.ShouldAllBeEquivalentTo(true);

            new[] {
                Test.CanConvertTo<ushort>(),
                Test.CanConvertTo<char>(),
                Test.CanConvertTo<uint>(),
                Test.CanConvertTo<byte>(),
                Test.CanConvertTo<ulong>()
                }.ShouldAllBeEquivalentTo(false);


            Test = -5.5f;

            new[] {
                Test.CanConvertTo<double>(),
                Test.CanConvertTo<float>(),
                Test.CanConvertTo<string>()
                }.ShouldAllBeEquivalentTo(true);

            new[] {
                Test.CanConvertTo<short>(),
                Test.CanConvertTo<long>(),
                Test.CanConvertTo<int>(),
                Test.CanConvertTo<ushort>(),
                Test.CanConvertTo<char>(),
                Test.CanConvertTo<uint>(),
                Test.CanConvertTo<byte>(),
                Test.CanConvertTo<ulong>()
                }.ShouldAllBeEquivalentTo(false);

            Test = null;

            // ReSharper disable ExpressionIsAlwaysNull
            new[] {
                Test.CanConvertTo<short>(),
                Test.CanConvertTo<long>(),
                Test.CanConvertTo<int>(),
                Test.CanConvertTo<ushort>(),
                Test.CanConvertTo<char>(),
                Test.CanConvertTo<uint>(),
                Test.CanConvertTo<byte>(),
                Test.CanConvertTo<ulong>(),
                Test.CanConvertTo<double>(),
                Test.CanConvertTo<float>(),
                Test.CanConvertTo<string>()
                }.ShouldAllBeEquivalentTo(false);
            // ReSharper restore ExpressionIsAlwaysNull
            }


        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_TryConvertTo()
            {
            IConvertible Test = "5";

            Test.TryConvertTo<short>().Should().Be((short)5);
            Test.TryConvertTo<long>().Should().Be((long)5);
            Test.TryConvertTo<int>().Should().Be((int)5);
            Test.TryConvertTo<ushort>().Should().Be((ushort)5);
            Test.TryConvertTo<ulong>().Should().Be((ulong)5);
            Test.TryConvertTo<uint>().Should().Be((uint)5);
            Test.TryConvertTo<float>().Should().Be((float)5);
            Test.TryConvertTo<double>().Should().Be((double)5);
            Test.TryConvertTo<char>().Should().Be('5');
            Test.TryConvertTo<string>().Should().Be("5");

            Test = "-5.5";

            Test.TryConvertTo<short>().Should().Be("-5.5");
            Test.TryConvertTo<long>().Should().Be("-5.5");
            Test.TryConvertTo<int>().Should().Be("-5.5");
            Test.TryConvertTo<ushort>().Should().Be("-5.5");
            Test.TryConvertTo<ulong>().Should().Be("-5.5");
            Test.TryConvertTo<uint>().Should().Be("-5.5");
            Test.TryConvertTo<char>().Should().Be("-5.5");
            Test.TryConvertTo<string>().Should().Be("-5.5");
            Test.TryConvertTo<float>().Should().Be(-5.5f);
            Test.TryConvertTo<double>().Should().Be((double)-5.5);

            Test = null;

            Test.TryConvertTo<string>().Should().Be(null);
            }
        }
    }
