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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber))]
    public partial class IntNumberTester : XUnitOutputTester, IDisposable
        {
        public IntNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.IntNumber.op_Implicit(Int32) => IntNumber")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber) + "." +
            nameof(IntNumber.GetValuePrecision) + "() => Number")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber) + "." + nameof(IntNumber.Add) +
            "(Int32, Int32) => Int32")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber) + "." +
            nameof(IntNumber.Subtract) + "(Int32, Int32) => Int32")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber) + "." +
            nameof(IntNumber.Multiply) + "(Int32, Int32) => Int32")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber) + "." +
            nameof(IntNumber.Divide) + "(Int32, Int32) => Object")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber) + "." + nameof(IntNumber.New) +
            "(Int32) => Number<Int32>")]
        public void TestIntNumber()
            {
            int Dec = 65;

            // Test implicits
            IntNumber TempNumber = Dec;
            Dec = TempNumber;

            TempNumber.GetHashCode().ShouldBe(Dec.GetHashCode());
            TempNumber.NumberType.ShouldBe(typeof(int));

            TempNumber.New().ShouldBe(TempNumber.DefaultValue);

            $"{TempNumber}".ShouldBe("65");

            INumber Temp2 = TempNumber.New(Dec);
            Temp2.GetValue().ShouldBe(Dec);

            TempNumber.GetValuePrecision().ShouldBe((IntNumber)1);

            TempNumber.Add((IntNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)70);
            TempNumber.Subtract((IntNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)60);
            TempNumber.Multiply((IntNumber)5).Should().BeOfType<ShortNumber>().And.Be((ShortNumber)(short)325);
            TempNumber.Divide((IntNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)13);

            TempNumber.Add((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)70);
            TempNumber.Subtract((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)60);
            TempNumber.Multiply((IConvertible)5).Should().BeOfType<ShortNumber>().And.Be((ShortNumber)(short)325);
            TempNumber.Divide((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)13);
            }
        }
    }