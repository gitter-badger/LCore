using System;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using LCore.Numbers;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable RedundantCast
// ReSharper disable InconsistentNaming

namespace L_Tests.LCore.Numbers
    {
    public partial class UShortNumberTester : XUnitOutputTester, IDisposable
        {
        public UShortNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.UShortNumber.op_Implicit(UInt16) => UShortNumber")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UShortNumber) + "." + nameof(UShortNumber.GetValuePrecision) + "() => Number")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UShortNumber) + "." + nameof(UShortNumber.Add) + "(UInt16, UInt16) => UInt16")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UShortNumber) + "." + nameof(UShortNumber.Subtract) + "(UInt16, UInt16) => UInt16")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UShortNumber) + "." + nameof(UShortNumber.Multiply) + "(UInt16, UInt16) => UInt16")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UShortNumber) + "." + nameof(UShortNumber.Divide) + "(UInt16, UInt16) => Object")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UShortNumber) + "." + nameof(UShortNumber.New) + "(UInt16) => Number<UInt16>")]
        public void TestUShortNumber()
            {
            ushort Dec = 65;

            // Test implicits
            UShortNumber TempNumber = Dec;
            Dec = TempNumber;

            TempNumber.GetHashCode().ShouldBe(Dec.GetHashCode());
            TempNumber.NumberType.ShouldBe(typeof(ushort));

            TempNumber.New().ShouldBe(TempNumber.DefaultValue);

            $"{TempNumber}".ShouldBe("65");

            INumber Temp2 = TempNumber.New(Dec);
            Temp2.GetValue().ShouldBe(Dec);

            TempNumber.GetValuePrecision().ShouldBe((UShortNumber)1);

            TempNumber.Add((UShortNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)70);
            TempNumber.Subtract((UShortNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)60);
            TempNumber.Multiply((UShortNumber)5).Should().BeOfType<ShortNumber>().And.Be((ShortNumber)(short)325);
            TempNumber.Divide((UShortNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)13);

            TempNumber.Add((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)70);
            TempNumber.Subtract((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)60);
            TempNumber.Multiply((IConvertible)5).Should().BeOfType<ShortNumber>().And.Be((ShortNumber)(short)325);
            TempNumber.Divide((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)13);
            }
        }
    }