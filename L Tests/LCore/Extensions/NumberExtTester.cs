using System;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.Numbers;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt))]
    public partial class NumberExtTester : XUnitOutputTester, IDisposable
        {
        public NumberExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." +
                                    nameof(NumberExt.DecimalPlaces) + "(Int32) => UInt32")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." +
                                    nameof(NumberExt.DecimalPlaces) + "(Int16) => UInt32")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." +
                                    nameof(NumberExt.DecimalPlaces) + "(Int64) => UInt32")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." +
                                    nameof(NumberExt.DecimalPlaces) + "(UInt32) => UInt32")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." +
                                    nameof(NumberExt.DecimalPlaces) + "(UInt16) => UInt32")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." +
                                    nameof(NumberExt.DecimalPlaces) + "(UInt64) => UInt32")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." +
                                    nameof(NumberExt.DecimalPlaces) + "(Char) => UInt32")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." +
                                    nameof(NumberExt.DecimalPlaces) + "(Byte) => UInt32")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." +
                                    nameof(NumberExt.DecimalPlaces) + "(SByte) => UInt32")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." +
                                    nameof(NumberExt.DecimalPlaces) + "(Decimal) => UInt16")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." +
                                    nameof(NumberExt.DecimalPlaces) + "(Double) => UInt16")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt) + "." +
                                    nameof(NumberExt.DecimalPlaces) + "(Single) => UInt16")]
        public void DecimalPlaces()
            {
            1.DecimalPlaces().Should().Be(expected: 0);
            ((short)1).DecimalPlaces().Should().Be(expected: 0);
            1L.DecimalPlaces().Should().Be(expected: 0);
            1uL.DecimalPlaces().Should().Be(expected: 0);
            ((char)0).DecimalPlaces().Should().Be(expected: 0);
            ((char)0).DecimalPlaces().Should().Be(expected: 0);
            ((byte)0).DecimalPlaces().Should().Be(expected: 0);
            ((sbyte)0).DecimalPlaces().Should().Be(expected: 0);

            5.5m.DecimalPlaces().Should().Be(expected: 1);
            5.50032m.DecimalPlaces().Should().Be(expected: 5);
            5.50042032m.DecimalPlaces().Should().Be(expected: 8);
            5.501042032m.DecimalPlaces().Should().Be(expected: 9);

            (-5.5m).DecimalPlaces().Should().Be(expected: 1);
            (-5.50032m).DecimalPlaces().Should().Be(expected: 5);
            (-5.50042032m).DecimalPlaces().Should().Be(expected: 8);
            (-5.501042032m).DecimalPlaces().Should().Be(expected: 9);

            5.5d.DecimalPlaces().Should().Be(expected: 1);
            5.50032d.DecimalPlaces().Should().Be(expected: 5);
            5.50042032d.DecimalPlaces().Should().Be(expected: 8);
            5.501042032d.DecimalPlaces().Should().Be(expected: 9);

            (-5.5d).DecimalPlaces().Should().Be(expected: 1);
            (-5.50032d).DecimalPlaces().Should().Be(expected: 5);
            (-5.50042032d).DecimalPlaces().Should().Be(expected: 8);
            (-5.501042032d).DecimalPlaces().Should().Be(expected: 9);

            5.5f.DecimalPlaces().Should().Be(expected: 1);
            5.50032f.DecimalPlaces().Should().Be(expected: 5);
            5.50042032f.DecimalPlaces().Should().Be(expected: 5);
            5.501042032f.DecimalPlaces().Should().Be(expected: 6);
            (-5.5f).DecimalPlaces().Should().Be(expected: 1);
            (-5.50032f).DecimalPlaces().Should().Be(expected: 5);
            (-5.50042032f).DecimalPlaces().Should().Be(expected: 5);
            (-5.501042032f).DecimalPlaces().Should().Be(expected: 6);

            float.MinValue.DecimalPlaces().Should().Be(expected: 0);
            double.MinValue.DecimalPlaces().Should().Be(expected: 0);
            decimal.MinValue.DecimalPlaces().Should().Be(expected: 0);

            float.Epsilon.DecimalPlaces().Should().Be(expected: 51);
            double.Epsilon.DecimalPlaces().Should().Be(expected: 338);
            ((IConvertible)new DecimalNumber().TypePrecision.GetValue()).ConvertTo<decimal>()?.DecimalPlaces().Should().Be(expected: 28);

            50d.DecimalPlaces().Should().Be(expected: 0);
            50.0m.DecimalPlaces().Should().Be(expected: 0);
            50f.DecimalPlaces().Should().Be(expected: 0);
            }

        }
    }