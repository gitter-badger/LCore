using System;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using LCore.Numbers;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable RedundantCast

namespace L_Tests.LCore.Numbers
    {
    public partial class ByteNumberTester : XUnitOutputTester, IDisposable
        {
        public ByteNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.ByteNumber.op_Implicit(Byte) => ByteNumber")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ByteNumber) + "." +
            nameof(ByteNumber.GetValuePrecision) + "() => Number")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ByteNumber) + "." +
            nameof(ByteNumber.Add) + "(Byte, Byte) => Byte")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ByteNumber) + "." +
            nameof(ByteNumber.Subtract) + "(Byte, Byte) => Byte")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ByteNumber) + "." +
            nameof(ByteNumber.Multiply) + "(Byte, Byte) => Byte")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ByteNumber) + "." +
            nameof(ByteNumber.Divide) + "(Byte, Byte) => Object")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ByteNumber) + "." +
            nameof(ByteNumber.New) + "(Byte) => Number<Byte>")]
        public void TestByteNumber()
            {
            byte Dec = 35;

            // Test implicits
            ByteNumber TempNumber = Dec;
            Dec = TempNumber;

            $"{TempNumber}".ShouldBe("35");

            TempNumber.GetHashCode().ShouldBe(Dec.GetHashCode());
            TempNumber.NumberType.ShouldBe(typeof(byte));

            TempNumber.New().Should().BeOfType<ByteNumber>().And.Be(TempNumber.DefaultValue);

            INumber Temp2 = TempNumber.New(Dec);
            Temp2.GetValue().ShouldBe(Dec);

            TempNumber.GetValuePrecision().ShouldBe((ByteNumber)1);

            TempNumber.Add((ByteNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)40);
            TempNumber.Subtract((ByteNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)30);
            TempNumber.Multiply((ByteNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)175);
            TempNumber.Divide((ByteNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)7);

            TempNumber.Add((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)40);
            TempNumber.Subtract((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)30);
            TempNumber.Multiply((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)175);
            TempNumber.Divide((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)7);
            }
        }
    }