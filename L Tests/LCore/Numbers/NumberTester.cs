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
    [Trait(Traits.TargetClass, "LCore.Numbers.Number")]
    [Trait(Traits.TargetClass, "LCore.Numbers.Number`1")]
    [Trait(Traits.TargetClass, "LCore.Numbers.Number`2")]
    public partial class NumberTester : XUnitOutputTester, IDisposable
        {
        public NumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Division(Number, IConvertible) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Division(Number, Number) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Multiply(Number, IConvertible) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Multiply(Number, Number) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Subtraction(Number, IConvertible) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Subtraction(Number, Number) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Addition(Number, IConvertible) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Addition(Number, Number) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number`2.op_Implicit(Number`2) => T")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number`1.op_Division(Number`1, T) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number`1.op_Multiply(Number`1, T) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number`1.op_Subtraction(Number`1, T) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number`1.op_Addition(Number`1, T) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number`1.Add(Number) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number`1.Subtract(Number) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number`1.Multiply(Number) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number`1.Divide(Number) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number`1.New(T) => Number`1")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number`1.New(Object) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number`1.GetValue() => Object")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number`1.Add(IConvertible) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number`1.Subtract(IConvertible) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number`1.Multiply(IConvertible) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number`1.Divide(IConvertible) => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number`1.Add(T, T) => T")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number`1.Subtract(T, T) => T")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number`1.Multiply(T, T) => T")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number`1.Divide(T, T) => Object")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number`1.New() => Number")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number`1.CompareTo(Object) => Int32")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Equals) + "(Object) => Boolean")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.ToString) + "() => String")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_GreaterThan(Number, IComparable) => Boolean")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_LessThan(Number, IComparable) => Boolean")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_GreaterThanOrEqual(Number, IComparable) => Boolean")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_LessThanOrEqual(Number, IComparable) => Boolean")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Equality(Number, IComparable) => Boolean")]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Inequality(Number, IComparable) => Boolean")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.GetHashCode) + "() => Int32")]
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
        public void op_Addition_Number_Number_Number()
            {
            ((Number<byte>)(ByteNumber)5 + (byte)3).Should().Be((ByteNumber)8);
            ((Number<byte>)(ByteNumber)5 - (byte)3).Should().Be((ByteNumber)2);
            ((Number<byte>)(ByteNumber)5 * (byte)3).Should().Be((ByteNumber)15);
            ((Number<byte>)(ByteNumber)5 / (byte)5).Should().Be((ByteNumber)1);

            ((Number)(ByteNumber)5 + (IConvertible)3).Should().Be((ByteNumber)8);
            ((Number)(ByteNumber)5 + (Number)(ByteNumber)3).Should().Be((ByteNumber)8);
            ((Number)(ByteNumber)5 + (Number)null).Should().Be((ByteNumber)5);
            ((Number)null + (Number)(ByteNumber)5).Should().Be((ByteNumber)5);
            ((Number)null + (Number)null).Should().Be((ByteNumber)0);
            ((Number)null + (IConvertible)5).Should().Be((ByteNumber)5);
            ((Number)null + (IConvertible)null).Should().Be((ByteNumber)0);

            ((Number)(ByteNumber)5 * (IConvertible)3).Should().Be((ByteNumber)15);
            ((Number)(ByteNumber)5 * (Number)(ByteNumber)3).Should().Be((ByteNumber)15);
            ((Number)(ByteNumber)5 * (Number)null).Should().Be((ByteNumber)0);
            ((Number)null * (Number)(ByteNumber)5).Should().Be((ByteNumber)0);
            ((Number)null * (Number)null).Should().Be((ByteNumber)0);
            ((Number)null * (IConvertible)5).Should().Be((ByteNumber)0);
            ((Number)null * (IConvertible)null).Should().Be((ByteNumber)0);

            ((Number)(ByteNumber)5 / (IConvertible)5).Should().Be((ByteNumber)1);
            ((Number)(ByteNumber)5 / (Number)(ByteNumber)5).Should().Be((ByteNumber)1);
            ((Number)(ByteNumber)5 / (Number)null).Should().Be((ByteNumber)5);
            ((Number)null / (Number)(ByteNumber)5).Should().Be((ByteNumber)0);
            ((Number)null / (Number)null).Should().Be((ByteNumber)0);
            ((Number)null / (IConvertible)5).Should().Be((ByteNumber)0);
            ((Number)null / (IConvertible)null).Should().Be((ByteNumber)0);

            ((Number)(ByteNumber)5 - (IConvertible)3).Should().Be((ByteNumber)2);
            ((Number)(ByteNumber)5 - (Number)(ByteNumber)3).Should().Be((ByteNumber)2);
            ((Number)(ByteNumber)5 - (Number)null).Should().Be((ByteNumber)5);
            // TODO: Enable overflow tests
            //((Number)null - (Number)(ByteNumber)5).Should().Be((SByteNumber)(sbyte)-5);
            ((Number)null - (Number)null).Should().Be((ByteNumber)0);
            //((Number)null - (IConvertible)5).Should().Be((SByteNumber)(sbyte)-5);
            ((Number)null - (IConvertible)null).Should().Be((ByteNumber)0);
            }
        }
    }