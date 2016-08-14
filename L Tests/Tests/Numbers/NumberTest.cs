using LCore.Extensions;
using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using LCore.Numbers;
using LCore.LUnit.Fluent;
using Xunit;
using static LCore.LUnit.LUnit.Categories;
// ReSharper disable PartialTypeWithSinglePart

// ReSharper disable UnusedVariable
// ReSharper disable EqualExpressionComparison

// ReSharper disable ThrowingSystemException
// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable ConvertToConstant.Local
// ReSharper disable RedundantAssignment
// ReSharper disable RedundantCast

namespace LCore.Tests.Extensions
    {
    [Trait(Category, LUnit.LUnit.Categories.Tools)]
    public class NumberTest
        {
        [Fact]
        public void TestNumberOperations()
            {

            ((Number)(ByteNumber)5 + (byte)3).Should().Be((ByteNumber)8);
            ((Number)(ByteNumber)5 - (byte)3).Should().Be((ByteNumber)2);
            ((Number)(ByteNumber)5 * (byte)3).Should().Be((ByteNumber)15);
            ((Number)(ByteNumber)5 / (byte)5).Should().Be((ByteNumber)1);

            ((ByteNumber)5).CompareTo((byte)3).Should().BeGreaterThan(expected: 0);
            ((ByteNumber)5).CompareTo((byte)7).Should().BeLessThan(expected: 0);
            ((ByteNumber)5).CompareTo((byte)5).Should().Be(expected: 0);
            ((ByteNumber)5).CompareTo("5").Should().Be(expected: 0);

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
            ((ByteNumber)5).CompareTo((byte)5).Should().Be(expected: 0);
            ((ByteNumber)5).CompareTo("5").Should().Be(expected: 0);

            ((ByteNumber)5).Equals((Number)(ByteNumber)5).ShouldBeTrue();
            ((ByteNumber)5).Equals(Obj: null).ShouldBeFalse();

            ByteNumber Test = 5;
            Test.Equals((object)Test).ShouldBeTrue();
            Test.Equals(typeof(void)).ShouldBeFalse();


            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            L.A(() => ((ByteNumber)5).CompareTo("5.5")).ShouldFail();


            ((ByteNumber)5 + "3").Should().Be((ByteNumber)8);
            ((ByteNumber)5 + "3.5").Should().Be((FloatNumber)8.5f);

            ((ByteNumber)5 + "3" + "2").Should().Be((ByteNumber)10);
            ((ByteNumber)5 * "5.5" + "3" + "5000.101").Should()
                .BeOfType<DecimalNumber>()
                .And.Be((DecimalNumber)5030.601m);
            ((ByteNumber)5 * "5.5e4" + "3" + "5000.101").Should()
                .BeOfType<DecimalNumber>()
                .And.Be((DecimalNumber)280003.101m);

            // ((ByteNumber)5 * "4.0443e-2").Should().Be((FloatNumber)5030.601);
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
        public void Test_NumberType<TNumber, TNative>()
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

            TempNumber.GetHashCode().Should().Be(Dec.GetHashCode());
            TempNumber.NumberType.Should().Be(typeof(TNative));

            TempNumber.New().Should().Be(TempNumber.DefaultValue);

            INumber Temp2 = TempNumber.New(Dec);
            Temp2.GetValue().Should().Be(Dec);

            TempNumber.GetValuePrecision().Should().Be((SByteNumber)1);
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

            ((ByteNumber)5 + "3").Should().Be((ByteNumber)8);
            ((ByteNumber)5 + "3.5").Should().Be((FloatNumber)8.5f);

            ((ByteNumber)5 + "3" + "2").Should().Be((ByteNumber)10);
            ((ByteNumber)5 * "5.5" + "3" + "5000.101").Should()
                .BeOfType<DecimalNumber>()
                .And.Be((DecimalNumber)5030.601m);
            ((ByteNumber)5 * "5.5e4" + "3" + "5000.101").Should()
                .BeOfType<DecimalNumber>()
                .And.Be((DecimalNumber)280003.101m);

            // ((ByteNumber)5 * "4.0443e-2").Should().Be((FloatNumber)5030.601);
            // ((ByteNumber)5 * "5.5e-3" + "3" + "5000.101").Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)5030.601m);
            }

        // TODO: L: Number: Implement robust overflow tests.
        }
    }
