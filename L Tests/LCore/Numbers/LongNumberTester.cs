using System;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.LUnit;
using LCore.Numbers;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable RedundantCast

namespace L_Tests.LCore.Numbers
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber))]
    public partial class LongNumberTester : XUnitOutputTester, IDisposable
        {
        public LongNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }


        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.LongNumber.op_Implicit(Int64) => LongNumber")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber) + "." +
            nameof(LongNumber.GetValuePrecision) + "() => Number")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber) + "." +
            nameof(LongNumber.Add) + "(Int64, Int64) => Int64")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber) + "." +
            nameof(LongNumber.Subtract) + "(Int64, Int64) => Int64")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber) + "." +
            nameof(LongNumber.Multiply) + "(Int64, Int64) => Int64")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber) + "." +
            nameof(LongNumber.Divide) + "(Int64, Int64) => Object")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber) + "." +
            nameof(LongNumber.New) + "(Int64) => Number`1<Int64>")]
        public void TestLongNumber()
            {
            long Dec = 5000000;

            // Test implicits
            LongNumber TempNumber = Dec;
            Dec = TempNumber;

            $"{TempNumber}".Should().Be("5000000");

            TempNumber.GetHashCode().Should().Be(Dec.GetHashCode());
            TempNumber.NumberType.Should().Be(typeof(long));

            TempNumber.New().Should().Be(TempNumber.DefaultValue);

            INumber Temp2 = TempNumber.New(Dec);
            Temp2.GetValue().Should().Be(Dec);

            TempNumber.GetValuePrecision().Should().Be((LongNumber)1);

            TempNumber.Add((LongNumber)5).Should().BeOfType<IntNumber>().And.Be((IntNumber)(int)5000005);
            TempNumber.Subtract((LongNumber)5).Should().BeOfType<IntNumber>().And.Be((IntNumber)(int)4999995);
            TempNumber.Multiply((LongNumber)5).Should().BeOfType<IntNumber>().And.Be((IntNumber)(int)25000000);
            TempNumber.Divide((LongNumber)5).Should().BeOfType<IntNumber>().And.Be((IntNumber)(int)1000000);

            TempNumber.Add((IConvertible)5).Should().BeOfType<IntNumber>().And.Be((IntNumber)(int)5000005);
            TempNumber.Subtract((IConvertible)5).Should().BeOfType<IntNumber>().And.Be((IntNumber)(int)4999995);
            TempNumber.Multiply((IConvertible)5).Should().BeOfType<IntNumber>().And.Be((IntNumber)(int)25000000);
            TempNumber.Divide((IConvertible)5).Should().BeOfType<IntNumber>().And.Be((IntNumber)(int)1000000);
            }
        }
    }