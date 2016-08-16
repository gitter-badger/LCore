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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber))]
    public partial class DecimalNumberTester : XUnitOutputTester, IDisposable
        {
        public DecimalNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.DecimalNumber.op_Implicit(Decimal) => DecimalNumber")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." +
            nameof(DecimalNumber.GetValuePrecision) + "() => Number")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." +
            nameof(DecimalNumber.Add) + "(Decimal, Decimal) => Decimal")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." +
            nameof(DecimalNumber.Subtract) + "(Decimal, Decimal) => Decimal")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." +
            nameof(DecimalNumber.Divide) + "(Decimal, Decimal) => Object")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." +
            nameof(DecimalNumber.New) + "(Decimal) => Number`1<Decimal>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." +
            nameof(DecimalNumber.Multiply) + "(Decimal, Decimal) => Decimal")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." +
            nameof(DecimalNumber.ToString) + "() => String")]
        public void TestDecimalNumber()
            {
            decimal Dec = new decimal(value: 5.5);

            // Test implicits
            DecimalNumber TempNumber = Dec;
            Dec = TempNumber;

            TempNumber.ToString().ShouldBe("5.5");

            INumber Temp2 = TempNumber.New(Dec);
            Temp2.GetValue().ShouldBe(Dec);

            TempNumber.GetHashCode().ShouldBe(Dec.GetHashCode());
            TempNumber.NumberType.ShouldBe(typeof(decimal));

            TempNumber.New().ShouldBe(TempNumber.DefaultValue);

            TempNumber.GetValuePrecision().ShouldBe((DecimalNumber)0.1m);

            TempNumber.Add((DecimalNumber)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)10.5);
            TempNumber.Subtract((DecimalNumber)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)0.5);
            TempNumber.Multiply((DecimalNumber)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)27.5);
            TempNumber.Divide((DecimalNumber)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)1.1);

            TempNumber.Add((IConvertible)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)10.5);
            TempNumber.Subtract((IConvertible)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)0.5);
            TempNumber.Multiply((IConvertible)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)27.5);
            TempNumber.Divide((IConvertible)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)1.1);
            }

        }
    }