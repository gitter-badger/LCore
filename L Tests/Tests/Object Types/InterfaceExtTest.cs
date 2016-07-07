
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using LCore.Tests;

// ReSharper disable RedundantAssignment
// ReSharper disable RedundantCast

namespace L_Tests
    {
    [TestClass]
    public class InterfaceExtTest : ExtensionTester
        {
        protected override Type[] TestType => new[] { typeof(InterfaceExt) };

        [TestMethod]
        public void Test_ConvertTo()
            {
            const string test = "-5.5555";

            Func<Type, object> ConvertTo = L.F<Type, object>(type => test.ConvertTo(type));

            ConvertTo.ShouldFail(typeof(int));
            ConvertTo.ShouldFail(typeof(uint));
            ConvertTo.ShouldFail(typeof(long));
            ConvertTo.ShouldFail(typeof(short));
            ConvertTo.ShouldFail(typeof(ushort));
            ConvertTo.ShouldFail(typeof(byte));
            ConvertTo.ShouldFail(typeof(char));
            ConvertTo.ShouldFail(typeof(byte));

            var result1 = test.ConvertTo(typeof(double));
            var result2 = test.ConvertTo(typeof(float));

            result1.Should().Be((double)-5.5555);
            result2.Should().Be((float)-5.5555);


            const string test2 = "5";

            test2.ConvertTo(typeof(int)).Should().Be(5);
            test2.ConvertTo(typeof(uint)).Should().Be((uint)5);
            test2.ConvertTo(typeof(long)).Should().Be((long)5);
            test2.ConvertTo(typeof(short)).Should().Be((short)5);
            test2.ConvertTo(typeof(ushort)).Should().Be((ushort)5);
            test2.ConvertTo(typeof(byte)).Should().Be((byte)5);
            test2.ConvertTo(typeof(char)).Should().Be('5');
            }

        [TestMethod]
        public void Test_ConvertTo_T()
            {
            const string test = "-5.5555";

            L.F<IConvertible, int>(InterfaceExt.ConvertTo<int>).ShouldFail(test);
            L.F<IConvertible, uint>(InterfaceExt.ConvertTo<uint>).ShouldFail(test);
            L.F<IConvertible, long>(InterfaceExt.ConvertTo<long>).ShouldFail(test);
            L.F<IConvertible, short>(InterfaceExt.ConvertTo<short>).ShouldFail(test);
            L.F<IConvertible, ushort>(InterfaceExt.ConvertTo<ushort>).ShouldFail(test);
            L.F<IConvertible, byte>(InterfaceExt.ConvertTo<byte>).ShouldFail(test);
            L.F<IConvertible, char>(InterfaceExt.ConvertTo<char>).ShouldFail(test);
            
            double result1 = test.ConvertTo<double>();
            float result2 = test.ConvertTo<float>();

            result1.Should().Be(-5.5555);
            result2.Should().Be((float)-5.5555);


            const string test2 = "5";

            test2.ConvertTo<int>().Should().Be(5);
            test2.ConvertTo<uint>().Should().Be((uint)5);
            test2.ConvertTo<long>().Should().Be((long)5);
            test2.ConvertTo<short>().Should().Be((short)5);
            test2.ConvertTo<ushort>().Should().Be((ushort)5);
            test2.ConvertTo<byte>().Should().Be((byte)5);
            test2.ConvertTo<char>().Should().Be('5');

            InterfaceExt.ConvertTo<int>(null).Should().Be(default(int));
            }
        }
    }
