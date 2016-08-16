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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(FloatNumber))]
    public partial class FloatNumberTester : XUnitOutputTester, IDisposable
        {
        public FloatNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }


        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.FloatNumber.op_Implicit(Single) => FloatNumber")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(FloatNumber) + "." +
            nameof(FloatNumber.GetValuePrecision) + "() => Number")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(FloatNumber) + "." +
            nameof(FloatNumber.Add) + "(Single, Single) => Single")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(FloatNumber) + "." +
            nameof(FloatNumber.Subtract) + "(Single, Single) => Single")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(FloatNumber) + "." +
            nameof(FloatNumber.Multiply) + "(Single, Single) => Single")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(FloatNumber) + "." +
            nameof(FloatNumber.Divide) + "(Single, Single) => Object")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(FloatNumber) + "." +
            nameof(FloatNumber.New) + "(Single) => Number`1<Single>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(FloatNumber) + "." +
            nameof(FloatNumber.ToString) + "() => String")]
        public void TestFloatNumber()
            {
            float Dec = 5f;

            // Test implicits
            FloatNumber TempNumber = Dec;
            Dec = TempNumber;

            $"{TempNumber}".ShouldBe("5");

            TempNumber.GetHashCode().ShouldBe(Dec.GetHashCode());
            TempNumber.NumberType.ShouldBe(typeof(float));

            TempNumber.New().ShouldBe(TempNumber.DefaultValue);

            INumber Temp2 = TempNumber.New(Dec);
            Temp2.GetValue().ShouldBe(Dec);

            TempNumber.GetValuePrecision().ShouldBe((FloatNumber)1f);

            TempNumber.Add((FloatNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)10);
            TempNumber.Subtract((FloatNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)0);
            TempNumber.Multiply((FloatNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)25);
            TempNumber.Divide((FloatNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)1);

            TempNumber.Add((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)10);
            TempNumber.Subtract((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)0);
            TempNumber.Multiply((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)25);
            TempNumber.Divide((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)1);
            }
        }
    }