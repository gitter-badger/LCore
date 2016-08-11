using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt))]
    public partial class NumberExtTester : XUnitOutputTester, IDisposable
        {
        public NumberExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.AddEach))]
        public void AddEach()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Abs))]
        public void Abs_Int32_UInt32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Abs))]
        public void Abs_UInt32_UInt32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Abs))]
        public void Abs_Int64_UInt64()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Abs))]
        public void Abs_UInt64_UInt64()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Abs))]
        public void Abs_Int16_UInt16()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Abs))]
        public void Abs_UInt16_UInt16()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Abs))]
        public void Abs_Double_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Abs))]
        public void Abs_Single_Single()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Abs))]
        public void Abs_SByte_Byte()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Abs))]
        public void Abs_Byte_Byte()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Abs))]
        public void Abs_Decimal_Decimal()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.AsPercent))]
        public void AsPercent_Single_Int32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.AsPercent))]
        public void AsPercent_Double_Int32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Average))]
        public void Average_IEnumerable_1_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.ConvertToBestMatch))]
        public void ConvertToBestMatch()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.DecimalPlaces))]
        public void DecimalPlaces_Int32_UInt32()
            {
            // TODO: Implement method test LCore.Extensions.NumberExt.DecimalPlaces
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.DecimalPlaces))]
        public void DecimalPlaces_Int16_UInt32()
            {
            // TODO: Implement method test LCore.Extensions.NumberExt.DecimalPlaces
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.DecimalPlaces))]
        public void DecimalPlaces_Int64_UInt32()
            {
            // TODO: Implement method test LCore.Extensions.NumberExt.DecimalPlaces
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.DecimalPlaces))]
        public void DecimalPlaces_UInt32_UInt32()
            {
            // TODO: Implement method test LCore.Extensions.NumberExt.DecimalPlaces
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.DecimalPlaces))]
        public void DecimalPlaces_UInt16_UInt32()
            {
            // TODO: Implement method test LCore.Extensions.NumberExt.DecimalPlaces
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.DecimalPlaces))]
        public void DecimalPlaces_UInt64_UInt32()
            {
            // TODO: Implement method test LCore.Extensions.NumberExt.DecimalPlaces
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.DecimalPlaces))]
        public void DecimalPlaces_Char_UInt32()
            {
            // TODO: Implement method test LCore.Extensions.NumberExt.DecimalPlaces
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.DecimalPlaces))]
        public void DecimalPlaces_Byte_UInt32()
            {
            // TODO: Implement method test LCore.Extensions.NumberExt.DecimalPlaces
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.DecimalPlaces))]
        public void DecimalPlaces_SByte_UInt32()
            {
            // TODO: Implement method test LCore.Extensions.NumberExt.DecimalPlaces
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.DecimalPlaces))]
        public void DecimalPlaces_Decimal_UInt16()
            {
            // TODO: Implement method test LCore.Extensions.NumberExt.DecimalPlaces
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.DecimalPlaces))]
        public void DecimalPlaces_Double_UInt16()
            {
            // TODO: Implement method test LCore.Extensions.NumberExt.DecimalPlaces
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.DecimalPlaces))]
        public void DecimalPlaces_Single_UInt16()
            {
            // TODO: Implement method test LCore.Extensions.NumberExt.DecimalPlaces
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Floor))]
        public void Floor_Single_Int32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Floor))]
        public void Floor_Single_Int32_Single()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Floor))]
        public void Floor_Double_Int64()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Floor))]
        public void Floor_Double_Int32_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.IsEven))]
        public void IsEven_Int32_Boolean()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.IsEven))]
        public void IsEven_Int64_Boolean()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.IsEven))]
        public void IsEven_Int16_Boolean()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.IsEven))]
        public void IsEven_UInt32_Boolean()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.IsEven))]
        public void IsEven_UInt64_Boolean()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.IsEven))]
        public void IsEven_Byte_Boolean()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.IsEven))]
        public void IsEven_SByte_Boolean()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.PercentageOf))]
        public void PercentageOf_Single_Single_Int32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.PercentageOf))]
        public void PercentageOf_Double_Double_Int32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.PercentageOf))]
        public void PercentageOf_Int32_Int32_Int32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.PercentageOf))]
        public void PercentageOf_UInt32_UInt32_Int32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.PercentageOf))]
        public void PercentageOf_Int16_Int16_Int32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.PercentageOf))]
        public void PercentageOf_Int64_Int64_Int32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Pow))]
        public void Pow_Double_Double_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Pow))]
        public void Pow_Int32_Double_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Pow))]
        public void Pow_UInt32_Double_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Pow))]
        public void Pow_Int16_Double_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Pow))]
        public void Pow_UInt16_Double_Double()
            {
            // TODO: Implement method test LCore.Extensions.NumberExt.Pow
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Pow))]
        public void Pow_Int64_Double_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Pow))]
        public void Pow_UInt64_Double_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Pow))]
        public void Pow_SByte_Double_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Pow))]
        public void Pow_Byte_Double_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Round))]
        public void Round_Single_Int32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Round))]
        public void Round_Single_Int32_Single()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Round))]
        public void Round_Double_Int64()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Round))]
        public void Round_Double_Int32_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Round))]
        public void Round_Decimal_Int64()
            {
            // TODO: Implement method test LCore.Extensions.NumberExt.Round
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Round))]
        public void Round_Decimal_Int32_Double()
            {
            // TODO: Implement method test LCore.Extensions.NumberExt.Round
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sqrt))]
        public void Sqrt_Int32_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sqrt))]
        public void Sqrt_Int64_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sqrt))]
        public void Sqrt_Int16_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sqrt))]
        public void Sqrt_Double_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sqrt))]
        public void Sqrt_Single_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sqrt))]
        public void Sqrt_UInt32_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sqrt))]
        public void Sqrt_UInt64_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sqrt))]
        public void Sqrt_UInt16_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sqrt))]
        public void Sqrt_Byte_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sqrt))]
        public void Sqrt_SByte_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sqrt))]
        public void Sqrt_Decimal_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.SubtractEach))]
        public void SubtractEach()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sum))]
        public void Sum_IEnumerable_1_Int32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sum))]
        public void Sum_IEnumerable_1_Int64()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sum))]
        public void Sum_IEnumerable_1_Single()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Sum))]
        public void Sum_IEnumerable_1_Double()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.To))]
        public void To_Int32_Int32_Int32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.To))]
        public void To_UInt32_UInt32_UInt32()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Wrap))]
        public void Wrap_Nullable_1_Number()
            {
            // TODO: Implement method test LCore.Extensions.NumberExt.Wrap
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Wrap))]
        public void Wrap_T_Number()
            {
            // TODO: Implement method test LCore.Extensions.NumberExt.Wrap
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." + nameof(NumberExt.Wrap))]
        public void Wrap_String_Number()
            {
            // TODO: Implement method test LCore.Extensions.NumberExt.Wrap
            }

        }
    }