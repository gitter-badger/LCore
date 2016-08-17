using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using LCore.Numbers;
using Xunit;
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantCast
// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable EqualExpressionComparison

namespace L_Tests.LCore.Numbers
    {
    public class NumberTester
        {
        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Implicit(Number) => T")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Division(Number, T) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Multiply(Number, T) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Subtraction(Number, T) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Addition(Number, T) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.Add(Number) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.Subtract(Number) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.Multiply(Number) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.Divide(Number) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.New(T) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.New(Object) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.GetValue() => Object")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.Add(IConvertible) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.Subtract(IConvertible) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.Multiply(IConvertible) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.Divide(IConvertible) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.Add(T, T) => T")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.Subtract(T, T) => T")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.Multiply(T, T) => T")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.Divide(T, T) => Object")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.New() => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.CompareTo(Object) => Int32")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Equals) + "(Object) => Boolean")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.ToString) + "() => String")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_GreaterThan(Number, IComparable) => Boolean")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_LessThan(Number, IComparable) => Boolean")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_GreaterThanOrEqual(Number, IComparable) => Boolean")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_LessThanOrEqual(Number, IComparable) => Boolean")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Equality(Number, IComparable) => Boolean")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Inequality(Number, IComparable) => Boolean")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.GetHashCode) + "() => Int32")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Division(Number, IConvertible) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Division(Number, Number) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Multiply(Number, IConvertible) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Multiply(Number, Number) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Subtraction(Number, IConvertible) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Subtraction(Number, Number) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Addition(Number, IConvertible) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Addition(Number, Number) => Number")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.CompareTo) + "(Object) => Int32")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.New) + "(Object) => Number")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Divide) + "(Number) => Number")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Multiply) + "(Number) => Number")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Subtract) + "(Number) => Number")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Add) + "(Number) => Number")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Divide) + "(IConvertible) => Number")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Multiply) + "(IConvertible) => Number")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Subtract) + "(IConvertible) => Number")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Add) + "(IConvertible) => Number")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.GetValuePrecision) + "() => Number")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.GetValue) + "() => Object")]

        public void TestNumberOperations()
            {
            ((Number)(ByteNumber)5 + (byte)3).ShouldBe((ByteNumber)8);
            ((Number)(ByteNumber)5 - (byte)3).ShouldBe((ByteNumber)2);
            ((Number)(ByteNumber)5 * (byte)3).ShouldBe((ByteNumber)15);
            ((Number)(ByteNumber)5 / (byte)5).ShouldBe((ByteNumber)1);

            ((ByteNumber)5).CompareTo((byte)3).Should().BeGreaterThan(expected: 0);
            ((ByteNumber)5).CompareTo((byte)7).Should().BeLessThan(expected: 0);
            ((ByteNumber)5).CompareTo((byte)5).ShouldBe(Expected: 0);
            ((ByteNumber)5).CompareTo("5").ShouldBe(Expected: 0);

            ((ByteNumber)5 < 3).ShouldBeFalse();
            ((ByteNumber)5 < 5).ShouldBeFalse();
            ((ByteNumber)5 < 7).ShouldBeTrue();

            ((ByteNumber)5 <= 3).ShouldBeFalse();
            ((ByteNumber)5 <= 5).ShouldBeTrue();
            ((ByteNumber)5 <= 7).ShouldBeTrue();

            ((ByteNumber)5 > 3).ShouldBeTrue();
            ((ByteNumber)5 > 5).ShouldBeFalse();
            ((ByteNumber)5 > 7).ShouldBeFalse();

            ((ByteNumber)5 >= 3).ShouldBeTrue();
            ((ByteNumber)5 >= 5).ShouldBeTrue();
            ((ByteNumber)5 >= 7).ShouldBeFalse();


            ((ByteNumber)5).CompareTo((byte)7).Should().BeLessThan(expected: 0);
            ((ByteNumber)5).CompareTo((byte)5).ShouldBe(Expected: 0);
            ((ByteNumber)5).CompareTo("5").ShouldBe(Expected: 0);

            ((ByteNumber)5).Equals((Number)(ByteNumber)5).ShouldBeTrue();
            ((ByteNumber)5).Equals(Obj: null).ShouldBeFalse();

            ByteNumber Test = 5;
            Test.Equals((object)Test).ShouldBeTrue();
            Test.Equals(typeof(void)).ShouldBeFalse();


            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            L.A(() => ((ByteNumber)5).CompareTo("5.5")).ShouldFail();


            ((ByteNumber)5 + "3").ShouldBe((ByteNumber)8);
            ((ByteNumber)5 + "3.5").ShouldBe((FloatNumber)8.5f);

            ((ByteNumber)5 + "3" + "2").ShouldBe((ByteNumber)10);
            ((ByteNumber)5 * "5.5" + "3" + "5000.101").Should()
                .BeOfType<DecimalNumber>()
                .And.Be((DecimalNumber)5030.601m);
            ((ByteNumber)5 * "5.5e4" + "3" + "5000.101").Should()
                .BeOfType<DecimalNumber>()
                .And.Be((DecimalNumber)280003.101m);

            // ((ByteNumber)5 * "4.0443e-2").ShouldBe(Compare: (FloatNumber)5030.601);
            // ((ByteNumber)5 * "5.5e-3" + "3" + "5000.101").Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)5030.601m);

            ((Number)null == (Number)null).ShouldBeTrue();
            ((Number)null == (Number)(ByteNumber)5).ShouldBeFalse();
            ((Number)(ByteNumber)5 == (Number)null).ShouldBeFalse();
            ((Number)(ByteNumber)5 == (Number)(ByteNumber)5).ShouldBeTrue();
            ((Number)null != (Number)null).ShouldBeFalse();
            ((Number)null != (Number)(ByteNumber)5).ShouldBeTrue();
            ((Number)(ByteNumber)5 != (Number)null).ShouldBeTrue();
            ((Number)(ByteNumber)5 != (Number)(ByteNumber)5).ShouldBeFalse();



            }

        [ExcludeFromCodeCoverage]
        public void NumberType<TNumber, TNative>()
            where TNumber : Number<TNative>
            where TNative : struct,
                IComparable,
                IComparable<TNative>,
                IConvertible,
                IEquatable<TNative>,
                IFormattable
            {
            var Dec = (TNative)(object)(int)25;

            // Test implicits
            var TempNumber = L.Obj.New<TNumber>(Dec);
            //Dec = TempNumber;

            TempNumber.GetHashCode().ShouldBe(Dec.GetHashCode());
            TempNumber.NumberType.ShouldBe(typeof(TNative));

            TempNumber.New().ShouldBe(TempNumber.DefaultValue);

            INumber Temp2 = TempNumber.New(Dec);
            Temp2.GetValue().ShouldBe(Dec);

            TempNumber.GetValuePrecision().ShouldBe((SByteNumber)1);
            /*

                        TempNumber.Add((SByteNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(TNative)30);
                        TempNumber.Subtract((SByteNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(TNative)20);
                        TempNumber.Multiply((SByteNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(TNative)125);
                        TempNumber.Divide((SByteNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(TNative)5);

                        TempNumber.Add((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(TNative)30);
                        TempNumber.Subtract((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(TNative)20);
                        TempNumber.Multiply((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(TNative)125);
                        TempNumber.Divide((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(TNative)5);
            */

            ((ByteNumber)5 + "3").ShouldBe((ByteNumber)8);
            ((ByteNumber)5 + "3.5").ShouldBe((FloatNumber)8.5f);

            ((ByteNumber)5 + "3" + "2").ShouldBe((ByteNumber)10);
            ((ByteNumber)5 * "5.5" + "3" + "5000.101").Should()
                .BeOfType<DecimalNumber>()
                .And.Be((DecimalNumber)5030.601m);
            ((ByteNumber)5 * "5.5e4" + "3" + "5000.101").Should()
                .BeOfType<DecimalNumber>()
                .And.Be((DecimalNumber)280003.101m);

            // ((ByteNumber)5 * "4.0443e-2").ShouldBe(Compare: (FloatNumber)5030.601);
            // ((ByteNumber)5 * "5.5e-3" + "3" + "5000.101").Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)5030.601m);
            }

        // TODO: L: Number: Implement robust overflow tests.
        }
    }
