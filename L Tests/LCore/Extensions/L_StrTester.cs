using System;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart

// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedParameter.Global

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L))]
    public partial class L_StrTester : XUnitOutputTester, IDisposable
        {
        public L_StrTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        public void CharConstants()
            {
            L.Char.LowerCaseChars.Length.ShouldBe(Expected: 26);
            L.Char.UpperCaseChars.Length.ShouldBe(Expected: 26);
            L.Char.NumberChars.Length.ShouldBe(Expected: 10);
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
            L.Str.CompareNumberString("-5", "-5").ShouldBe(Expected: 0);
            L.Str.CompareNumberString("-5000.00000", "-5000.000").ShouldBe(Expected: 0);

            L.Str.CompareNumberString("-5000.000001", "-5000.000").Should().BeLessThan(expected: 0);
            L.Str.CompareNumberString("-5000.000001", "-5000.0001").Should().BeGreaterThan(expected: 0);


            L.Str.CompareNumberString("55", "501").Should().BeLessThan(expected: 0);
            L.Str.CompareNumberString("501", "55").Should().BeGreaterThan(expected: 0);

            L.Str.CompareNumberString(int.MaxValue.ToString(), "4").Should().BeGreaterThan(expected: 0);
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Str) + "." + nameof(L.Str.Char) + "(String, Int32) => Char")]
        public void Char()
            {
            L.Str.Char(Str: null, i: 0).ShouldBe(default(char));
            L.Str.Char("", i: 0).ShouldBe(default(char));
            L.Str.Char(" ", i: 1).ShouldBe(default(char));
            L.Str.Char(" ", -1).ShouldBe(default(char));
            L.Str.Char(" ", i: 0).ShouldBe(Expected: ' ');
            L.Str.Char("abc", i: 0).ShouldBe(Expected: 'a');
            L.Str.Char("abc", i: 1).ShouldBe(Expected: 'b');
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Str) + "." + nameof(L.Str.JoinLines) + "(IEnumerable<String>, String) => String")]
        public void JoinLines()
            {
            L.Str.JoinLines(Line: null, CombineStr: null).ShouldBe("");
            L.Str.JoinLines(Line: null, CombineStr: "").ShouldBe("");
            L.Str.JoinLines(new string[] { }, CombineStr: null).ShouldBe("");
            L.Str.JoinLines(new string[] { }, "").ShouldBe("");
            L.Str.JoinLines(new[] { "a", "b", "c" }, CombineStr: null).ShouldBe("abc");
            L.Str.JoinLines(new[] { "a", "b", "c" }, "").ShouldBe("abc");
            L.Str.JoinLines(new[] { "a", "b", "c" }, "\r\n").ShouldBe("a\r\nb\r\nc");
            L.Str.JoinLines(new[] { "a", "b", "c" }, ", ").ShouldBe("a, b, c");
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Str) + "." + nameof(L.Str.Pluralize) + "(String, Int32) => String")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Str) + "." + nameof(L.Str.Pluralize) + "(String, UInt32) => String")]
        public void Pluralize()
            {
            L.Str.Pluralize("apple", Count: 0).ShouldBe("apples");
            L.Str.Pluralize("apple", -1).ShouldBe("apple");
            L.Str.Pluralize("apple", Count: 1).ShouldBe("apple");
            L.Str.Pluralize("apple", Count: 2).ShouldBe("apples");
            L.Str.Pluralize("entity", Count: 0).ShouldBe("entities");
            L.Str.Pluralize("entity", -1).ShouldBe("entity");
            L.Str.Pluralize("entity", Count: 1).ShouldBe("entity");
            L.Str.Pluralize("entity", Count: 2).ShouldBe("entities");

            L.Str.Pluralize("apple", Count: 0u).ShouldBe("apples");
            L.Str.Pluralize("apple", Count: 1u).ShouldBe("apple");
            L.Str.Pluralize("apple", Count: 2u).ShouldBe("apples");
            L.Str.Pluralize("entity", Count: 0u).ShouldBe("entities");
            L.Str.Pluralize("entity", Count: 1u).ShouldBe("entity");
            L.Str.Pluralize("entity", Count: 2u).ShouldBe("entities");
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Str) + "." + nameof(L.Str.RemoveChars) + "(String, Char[]) => String")]
        public void RemoveChars()
            {
            L.Str.RemoveChars(null, ' ').ShouldBe("");
            L.Str.RemoveChars("alphabet").ShouldBe("alphabet");
            L.Str.RemoveChars("alphabet ", ' ', 'a', 'e').ShouldBe("lphbt");
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Str) + "." + nameof(L.Str.ReplaceDouble) + "(String, Char) => String")]
        public void ReplaceDouble()
            {
            L.Str.ReplaceDouble(StrIn: null, Char: ' ').ShouldBe("");
            L.Str.ReplaceDouble("", Char: ' ').ShouldBe("");
            L.Str.ReplaceDouble("      ", Char: ' ').ShouldBe(" ");
            L.Str.ReplaceDouble("-- --   -   ---   - -- ", Char: ' ').ShouldBe("-- -- - --- - -- ");
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Str) + "." + nameof(L.Str.Singularize) + "(String) => String")]
        public void Singularize()
            {
            L.Str.Singularize(Str: null).ShouldBe("");
            L.Str.Singularize("apples").ShouldBe("apple");
            L.Str.Singularize("entities").ShouldBe("entity");
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Str) + "." + nameof(L.Str.Surround) + "(String, String, String) => String")]
        public void Surround()
            {
            // TODO: Implement method test LCore.Extensions.L.Str.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Str) + "." + nameof(L.Str.ToS) + "(Object) => String")]
        public void ToS()
            {
            // TODO: Implement method test LCore.Extensions.L.Str.ToS
            }
        }
    }