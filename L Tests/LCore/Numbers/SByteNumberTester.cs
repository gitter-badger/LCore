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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(SByteNumber))]
    public partial class SByteNumberTester : XUnitOutputTester, IDisposable
        {
        public SByteNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.SByteNumber.op_Implicit(SByte) => SByteNumber")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(SByteNumber) + "." + nameof(SByteNumber.GetValuePrecision) + "() => Number")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(SByteNumber) + "." + nameof(SByteNumber.Add) + "(SByte, SByte) => SByte")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(SByteNumber) + "." + nameof(SByteNumber.Subtract) + "(SByte, SByte) => SByte")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(SByteNumber) + "." + nameof(SByteNumber.Multiply) + "(SByte, SByte) => SByte")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(SByteNumber) + "." + nameof(SByteNumber.Divide) + "(SByte, SByte) => Object")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(SByteNumber) + "." + nameof(SByteNumber.New) + "(SByte) => Number`1<SByte>")]
        public void TestSByteNumber()
            {
            sbyte Dec = 25;

            // Test implicits
            SByteNumber TempNumber = Dec;
            Dec = TempNumber;

            TempNumber.GetHashCode().Should().Be(Dec.GetHashCode());
            TempNumber.NumberType.Should().Be(typeof(sbyte));

            $"{TempNumber}".Should().Be("25");

            TempNumber.New().Should().Be(TempNumber.DefaultValue);

            INumber Temp2 = TempNumber.New(Dec);
            Temp2.GetValue().Should().Be(Dec);

            TempNumber.GetValuePrecision().Should().Be((SByteNumber)1);

            TempNumber.Add((SByteNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)30);
            TempNumber.Subtract((SByteNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)20);
            TempNumber.Multiply((SByteNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)125);
            TempNumber.Divide((SByteNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)5);

            TempNumber.Add((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)30);
            TempNumber.Subtract((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)20);
            TempNumber.Multiply((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)125);
            TempNumber.Divide((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)5);

            }

        }
    }