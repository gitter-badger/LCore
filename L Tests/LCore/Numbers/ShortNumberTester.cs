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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber))]
    public partial class ShortNumberTester : XUnitOutputTester, IDisposable
        {
        public ShortNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.ShortNumber.op_Implicit(Int16) => ShortNumber")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber) + "." +
            nameof(ShortNumber.GetValuePrecision) + "() => Number")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber) + "." +
            nameof(ShortNumber.Add) + "(Int16, Int16) => Int16")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber) + "." +
            nameof(ShortNumber.Subtract) + "(Int16, Int16) => Int16")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber) + "." +
            nameof(ShortNumber.Multiply) + "(Int16, Int16) => Int16")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber) + "." +
            nameof(ShortNumber.Divide) + "(Int16, Int16) => Object")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber) + "." +
            nameof(ShortNumber.New) + "(Int16) => Number`1<Int16>")]
        public void TestShortNumber()
            {
            short Dec = 65;

            // Test implicits
            ShortNumber TempNumber = Dec;
            Dec = TempNumber;

            TempNumber.GetHashCode().Should().Be(Dec.GetHashCode());
            TempNumber.NumberType.Should().Be(typeof(short));

            TempNumber.New().Should().Be(TempNumber.DefaultValue);

            $"{TempNumber}".Should().Be("65");

            INumber Temp2 = TempNumber.New(Dec);
            Temp2.GetValue().Should().Be(Dec);

            TempNumber.GetValuePrecision().Should().Be((ShortNumber)1);

            TempNumber.Add((ShortNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)70);
            TempNumber.Subtract((ShortNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)60);
            TempNumber.Multiply((ShortNumber)5).Should().BeOfType<ShortNumber>().And.Be((ShortNumber)(short)325);
            TempNumber.Divide((ShortNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)13);

            TempNumber.Add((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)70);
            TempNumber.Subtract((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)60);
            TempNumber.Multiply((IConvertible)5).Should().BeOfType<ShortNumber>().And.Be((ShortNumber)(short)325);
            TempNumber.Divide((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)13);
            }

        }
    }