using System;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.LUnit;
using LCore.Numbers;
using Xunit;
using Xunit.Abstractions;
using LCore.LUnit.Fluent;
// ReSharper disable RedundantCast

namespace L_Tests.LCore.Numbers
    {
    public partial class DoubleNumberTester : XUnitOutputTester, IDisposable
        {
        public DoubleNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.DoubleNumber.op_Implicit(Double) => DoubleNumber")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DoubleNumber) + "." + nameof(DoubleNumber.GetValuePrecision) + "() => Number")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DoubleNumber) + "." + nameof(DoubleNumber.Add) + "(Double, Double) => Double")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DoubleNumber) + "." + nameof(DoubleNumber.Subtract) + "(Double, Double) => Double")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DoubleNumber) + "." + nameof(DoubleNumber.Multiply) + "(Double, Double) => Double")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DoubleNumber) + "." + nameof(DoubleNumber.Divide) + "(Double, Double) => Object")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DoubleNumber) + "." + nameof(DoubleNumber.New) + "(Double) => Number<Double>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DoubleNumber) + "." + nameof(DoubleNumber.ToString) + "() => String")]
        public void TestDoubleNumber()
            {
            double Dec = 5.5;

            // Test implicits
            DoubleNumber TempNumber = Dec;
            Dec = TempNumber;

            TempNumber.GetHashCode().ShouldBe(Dec.GetHashCode());
            TempNumber.NumberType.ShouldBe(typeof(double));

            TempNumber.New().ShouldBe(TempNumber.DefaultValue);

            TempNumber.ToString().ShouldBe("5.5");

            INumber Temp2 = TempNumber.New(Dec);
            Temp2.GetValue().ShouldBe(Dec);

            TempNumber.GetValuePrecision().ShouldBe((DoubleNumber)0.1d);

            TempNumber.Add((DoubleNumber)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)10.5);
            TempNumber.Subtract((DoubleNumber)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)0.5);
            TempNumber.Multiply((DoubleNumber)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)27.5);
            TempNumber.Divide((DoubleNumber)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)1.1);

            TempNumber.Add((IConvertible)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)10.5);
            TempNumber.Subtract((IConvertible)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)0.5);
            TempNumber.Multiply((IConvertible)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)27.5);
            TempNumber.Divide((IConvertible)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)1.1);
            }

        }
    }