using System;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.Numbers;
using Xunit;
using Xunit.Abstractions;
using LCore.LUnit.Fluent;

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(NumberExt))]
    public partial class NumberExtTester : XUnitOutputTester, IDisposable
        {
        public NumberExtTester([NotNull] ITestOutputHelper Output) : base(Output) {}

        public void Dispose() {}

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
            1.DecimalPlaces().ShouldBe(Compare: 0u);
            ((short) 1).DecimalPlaces().ShouldBe(Compare: 0u);
            1L.DecimalPlaces().ShouldBe(Compare: 0u);
            1uL.DecimalPlaces().ShouldBe(Compare: 0u);
            ((char) 0).DecimalPlaces().ShouldBe(Compare: 0u);
            ((char) 0).DecimalPlaces().ShouldBe(Compare: 0u);
            ((byte) 0).DecimalPlaces().ShouldBe(Compare: 0u);
            ((sbyte) 0).DecimalPlaces().ShouldBe(Compare: 0u);

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
        }
    }