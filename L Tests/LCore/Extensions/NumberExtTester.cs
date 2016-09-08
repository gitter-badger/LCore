using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.Numbers;
using Xunit;
using Xunit.Abstractions;
using LCore.LUnit.Fluent;
// ReSharper disable PossibleNullReferenceException

// ReSharper disable PossibleInvalidOperationException
// ReSharper disable ArgumentsStyleLiteral
// ReSharper disable InvokeAsExtensionMethod

namespace L_Tests.LCore.Extensions
    {
    public partial class NumberExtTester : XUnitOutputTester, IDisposable
        {
        public NumberExtTester([NotNull] ITestOutputHelper Output) : base(Output) {}

        public void Dispose() {}

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.DecimalPlaces) + "(Int32) => UInt32")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.DecimalPlaces) + "(Int16) => UInt32")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.DecimalPlaces) + "(Int64) => UInt32")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.DecimalPlaces) + "(UInt32) => UInt32")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.DecimalPlaces) + "(UInt16) => UInt32")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.DecimalPlaces) + "(UInt64) => UInt32")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.DecimalPlaces) + "(Char) => UInt32")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.DecimalPlaces) + "(Byte) => UInt32")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.DecimalPlaces) + "(SByte) => UInt32")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.DecimalPlaces) + "(Decimal) => UInt16")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.DecimalPlaces) + "(Double) => UInt16")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.DecimalPlaces) + "(Single) => UInt16")]
        public void DecimalPlaces()
            {
            1.DecimalPlaces().ShouldBe(Expected: 0u);
            ((short) 1).DecimalPlaces().ShouldBe(Expected: 0u);
            1L.DecimalPlaces().ShouldBe(Expected: 0u);
            1uL.DecimalPlaces().ShouldBe(Expected: 0u);
            ((char) 0).DecimalPlaces().ShouldBe(Expected: 0u);
            ((char) 0).DecimalPlaces().ShouldBe(Expected: 0u);
            ((byte) 0).DecimalPlaces().ShouldBe(Expected: 0u);
            ((sbyte) 0).DecimalPlaces().ShouldBe(Expected: 0u);

            5.5m.DecimalPlaces().ShouldBe((ushort) 1);
            5.50032m.DecimalPlaces().ShouldBe((ushort) 5);
            5.50042032m.DecimalPlaces().ShouldBe((ushort) 8);
            5.501042032m.DecimalPlaces().ShouldBe((ushort) 9);

            (-5.5m).DecimalPlaces().ShouldBe((ushort) 1);
            (-5.50032m).DecimalPlaces().ShouldBe((ushort) 5);
            (-5.50042032m).DecimalPlaces().ShouldBe((ushort) 8);
            (-5.501042032m).DecimalPlaces().ShouldBe((ushort) 9);

            5.5d.DecimalPlaces().ShouldBe((ushort) 1);
            5.50032d.DecimalPlaces().ShouldBe((ushort) 5);
            5.50042032d.DecimalPlaces().ShouldBe((ushort) 8);
            5.501042032d.DecimalPlaces().ShouldBe((ushort) 9);

            (-5.5d).DecimalPlaces().ShouldBe((ushort) 1);
            (-5.50032d).DecimalPlaces().ShouldBe((ushort) 5);
            (-5.50042032d).DecimalPlaces().ShouldBe((ushort) 8);
            (-5.501042032d).DecimalPlaces().ShouldBe((ushort) 9);

            5.5f.DecimalPlaces().ShouldBe((ushort) 1);
            5.50032f.DecimalPlaces().ShouldBe((ushort) 5);
            5.50042032f.DecimalPlaces().ShouldBe((ushort) 5);
            5.501042032f.DecimalPlaces().ShouldBe((ushort) 6);
            (-5.5f).DecimalPlaces().ShouldBe((ushort) 1);
            (-5.50032f).DecimalPlaces().ShouldBe((ushort) 5);
            (-5.50042032f).DecimalPlaces().ShouldBe((ushort) 5);
            (-5.501042032f).DecimalPlaces().ShouldBe((ushort) 6);

            float.MinValue.DecimalPlaces().ShouldBe((ushort) 0);
            double.MinValue.DecimalPlaces().ShouldBe((ushort) 0);
            decimal.MinValue.DecimalPlaces().ShouldBe((ushort) 0);

            float.Epsilon.DecimalPlaces().ShouldBe((ushort) 51);
            double.Epsilon.DecimalPlaces().ShouldBe((ushort) 338);
            ((IConvertible) new DecimalNumber().TypePrecision.GetValue()).ConvertTo<decimal>()?.DecimalPlaces().ShouldBe((ushort) 28);

            50d.DecimalPlaces().ShouldBe((ushort) 0);
            50.0m.DecimalPlaces().ShouldBe((ushort) 0);
            50f.DecimalPlaces().ShouldBe((ushort) 0);
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Round) + "(Decimal) => Int64")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Round) + "(Decimal, Int32) => Double")]
        public void Round_Decimal_Int64()
            {
            // Since decimals are not allowed in attributes we are reduced to being very sneaky.

            var Round = L.Ref.StaticMethod(() => NumberExt.Round(0d));
            var Round2 = L.Ref.StaticMethod(() => NumberExt.Round(0d, 1));

            var RoundTest = L.Ref.StaticMethod(() => NumberExt.Round(0m));
            var RoundTest2 = L.Ref.StaticMethod(() => NumberExt.Round(0m, 1));

            List<ITestResultAttribute> RoundAttributes = Round.GetAttributes<ITestResultAttribute>(false);

            RoundAttributes.Each(Attr =>
                {
                long Result = (long) RoundTest.Invoke(null, new object[] {(decimal) (Attr.Parameters[0] as IConvertible).ConvertTo<decimal>()});

                Result.ShouldBe(Attr.ExpectedResult);
                });

            List<ITestResultAttribute> Round2Attributes = Round2.GetAttributes<ITestResultAttribute>(false);

            Round2Attributes.Each(Attr =>
                {
                double Result = (double) RoundTest2.Invoke(null, new object[] {(decimal) (Attr.Parameters[0] as IConvertible).ConvertTo<decimal>(), (int) Attr.Parameters[1]});

                Result.ShouldBe(Attr.ExpectedResult);
                });
            }


        // Attribute Tested //////////////////////////////////////////////////////////////////////////////

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Pow) + "(UInt16, Double) => Double")]
        public void Pow_UInt16_Double_Double()
            {
            // Attribute Tests Implemented
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.AddEach) + "(IEnumerable<Int32>, Int32) => List<Int32>")]
        public void AddEach()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Abs) + "(Int32) => UInt32")]
        public void Abs_Int32_UInt32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Abs) + "(UInt32) => UInt32")]
        public void Abs_UInt32_UInt32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Abs) + "(Int64) => UInt64")]
        public void Abs_Int64_UInt64()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Abs) + "(UInt64) => UInt64")]
        public void Abs_UInt64_UInt64()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Abs) + "(Int16) => UInt16")]
        public void Abs_Int16_UInt16()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Abs) + "(UInt16) => UInt16")]
        public void Abs_UInt16_UInt16()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Abs) + "(Double) => Double")]
        public void Abs_Double_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Abs) + "(Single) => Single")]
        public void Abs_Single_Single()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Abs) + "(SByte) => Byte")]
        public void Abs_SByte_Byte()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Abs) + "(Byte) => Byte")]
        public void Abs_Byte_Byte()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Abs) + "(Decimal) => Decimal")]
        public void Abs_Decimal_Decimal()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.AsPercent) + "(Single) => Int32")]
        public void AsPercent_Single_Int32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.AsPercent) + "(Double) => Int32")]
        public void AsPercent_Double_Int32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Average) + "(IEnumerable<Int32>) => Double")]
        public void Average_IEnumerable_1_Int32_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Average) + "(IEnumerable<UInt32>) => Double")]
        public void Average_IEnumerable_1_UInt32_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Average) + "(IEnumerable<Int64>) => Double")]
        public void Average_IEnumerable_1_Int64_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Average) + "(IEnumerable<UInt64>) => Double")]
        public void Average_IEnumerable_1_UInt64_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Average) + "(IEnumerable<Single>) => Double")]
        public void Average_IEnumerable_1_Single_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Average) + "(IEnumerable<Double>) => Double")]
        public void Average_IEnumerable_1_Double_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Floor) + "(Single) => Int32")]
        public void Floor_Single_Int32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Floor) + "(Single, Int32) => Single")]
        public void Floor_Single_Int32_Single()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Floor) + "(Double) => Int64")]
        public void Floor_Double_Int64()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Floor) + "(Double, Int32) => Double")]
        public void Floor_Double_Int32_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.IsEven) + "(Int32) => Boolean")]
        public void IsEven_Int32_Boolean()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.IsEven) + "(Int64) => Boolean")]
        public void IsEven_Int64_Boolean()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.IsEven) + "(Int16) => Boolean")]
        public void IsEven_Int16_Boolean()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.IsEven) + "(UInt32) => Boolean")]
        public void IsEven_UInt32_Boolean()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.IsEven) + "(UInt64) => Boolean")]
        public void IsEven_UInt64_Boolean()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.IsEven) + "(Byte) => Boolean")]
        public void IsEven_Byte_Boolean()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.IsEven) + "(SByte) => Boolean")]
        public void IsEven_SByte_Boolean()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.PercentageOf) + "(Single, Single) => Int32")]
        public void PercentageOf_Single_Single_Int32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.PercentageOf) + "(Double, Double) => Int32")]
        public void PercentageOf_Double_Double_Int32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.PercentageOf) + "(Int32, Int32) => Int32")]
        public void PercentageOf_Int32_Int32_Int32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.PercentageOf) + "(UInt32, UInt32) => Int32")]
        public void PercentageOf_UInt32_UInt32_Int32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.PercentageOf) + "(Int16, Int16) => Int32")]
        public void PercentageOf_Int16_Int16_Int32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.PercentageOf) + "(Int64, Int64) => Int32")]
        public void PercentageOf_Int64_Int64_Int32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Pow) + "(Double, Double) => Double")]
        public void Pow_Double_Double_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Pow) + "(Int32, Double) => Double")]
        public void Pow_Int32_Double_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Pow) + "(UInt32, Double) => Double")]
        public void Pow_UInt32_Double_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Pow) + "(Int16, Double) => Double")]
        public void Pow_Int16_Double_Double()
            {
            // Attribute Tests Implemented
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Pow) + "(Int64, Double) => Double")]
        public void Pow_Int64_Double_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Pow) + "(UInt64, Double) => Double")]
        public void Pow_UInt64_Double_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Pow) + "(SByte, Double) => Double")]
        public void Pow_SByte_Double_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Pow) + "(Byte, Double) => Double")]
        public void Pow_Byte_Double_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Round) + "(Single) => Int32")]
        public void Round_Single_Int32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Round) + "(Single, Int32) => Single")]
        public void Round_Single_Int32_Single()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Round) + "(Double) => Int64")]
        public void Round_Double_Int64()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Round) + "(Double, Int32) => Double")]
        public void Round_Double_Int32_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sqrt) + "(Int32) => Double")]
        public void Sqrt_Int32_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sqrt) + "(Int64) => Double")]
        public void Sqrt_Int64_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sqrt) + "(Int16) => Double")]
        public void Sqrt_Int16_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sqrt) + "(Double) => Double")]
        public void Sqrt_Double_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sqrt) + "(Single) => Double")]
        public void Sqrt_Single_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sqrt) + "(UInt32) => Double")]
        public void Sqrt_UInt32_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sqrt) + "(UInt64) => Double")]
        public void Sqrt_UInt64_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sqrt) + "(UInt16) => Double")]
        public void Sqrt_UInt16_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sqrt) + "(Byte) => Double")]
        public void Sqrt_Byte_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sqrt) + "(SByte) => Double")]
        public void Sqrt_SByte_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sqrt) + "(Decimal) => Double")]
        public void Sqrt_Decimal_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.SubtractEach) + "(List<Int32>, Int32) => List<Int32>")]
        public void SubtractEach()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sum) + "(IEnumerable<Int32>) => Int32")]
        public void Sum_IEnumerable_1_Int32_Int32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sum) + "(IEnumerable<UInt32>) => UInt32")]
        public void Sum_IEnumerable_1_UInt32_UInt32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sum) + "(IEnumerable<Int64>) => Int64")]
        public void Sum_IEnumerable_1_Int64_Int64()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sum) + "(IEnumerable<UInt64>) => UInt64")]
        public void Sum_IEnumerable_1_UInt64_UInt64()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sum) + "(IEnumerable<Single>) => Single")]
        public void Sum_IEnumerable_1_Single_Single()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sum) + "(IEnumerable<Double>) => Double")]
        public void Sum_IEnumerable_1_Double_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.To) + "(Int32, Int32) => Int32[]")]
        public void To_Int32_Int32_Int32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.To) + "(UInt32, UInt32) => UInt32[]")]
        public void To_UInt32_UInt32_UInt32()
            {
            // Attribute Tests Implemented
            }
        }
    }