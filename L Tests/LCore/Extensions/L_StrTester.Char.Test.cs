using System;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedParameter.Global

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L))]
    public partial class L_StrTester : XUnitOutputTester, IDisposable
        {
        public L_StrTester([NotNull] ITestOutputHelper Output) : base(Output) {}

        public void Dispose() {}
        
        [Fact]
        public void CharConstants()
            {
            L.Char.LowerCaseChars.Length.ShouldBe(Compare: 26);
            L.Char.UpperCaseChars.Length.ShouldBe(Compare: 26);
            L.Char.NumberChars.Length.ShouldBe(Compare: 10);
            L.Char.SpecialChars.Length.Should().BeGreaterOrEqualTo(expected: 10);
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Str) + "." + nameof(L.Str.CompareNumberString) + "(String, String) => Int32")]
        public void NumericalCompare()
            {
            L.Str.CompareNumberString("5", "10").Should().BeLessThan(expected: 0);
            L.Str.CompareNumberString("15", "10").Should().BeGreaterThan(expected: 0);
            L.Str.CompareNumberString("-5", "10").Should().BeLessThan(expected: 0);
            L.Str.CompareNumberString("5", "-10").Should().BeGreaterThan(expected: 0);
            L.Str.CompareNumberString("-5", "-10").Should().BeGreaterThan(expected: 0);
            L.Str.CompareNumberString("-5", "-5").ShouldBe(Compare: 0);
            L.Str.CompareNumberString("-5000.00000", "-5000.000").ShouldBe(Compare: 0);

            L.Str.CompareNumberString("-5000.000001", "-5000.000").Should().BeLessThan(expected: 0);
            L.Str.CompareNumberString("-5000.000001", "-5000.0001").Should().BeGreaterThan(expected: 0);


            L.Str.CompareNumberString("55", "501").Should().BeLessThan(expected: 0);
            L.Str.CompareNumberString("501", "55").Should().BeGreaterThan(expected: 0);

            L.Str.CompareNumberString(int.MaxValue.ToString(), "4").Should().BeGreaterThan(expected: 0);
            }

        }
    }