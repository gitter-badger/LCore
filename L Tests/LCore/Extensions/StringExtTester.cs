using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable RedundantCast

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt))]
    public partial class StringExtTester : XUnitOutputTester, IDisposable
        {
        public StringExtTester([NotNull] ITestOutputHelper Output) : base(Output) {}

        public void Dispose() {}


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." +
            nameof(StringExt.ReplaceAll) + "(String, IDictionary<String, String>) => String")]
        public void ReplaceAll_Dictionary()
            {
            var Replacements = new Dictionary<string, string>
                {
                ["a"] = "b",
                ["long"] = "short"
                };

            const string Test = "aab long long aaa along";

            // ReSharper disable once StringLiteralTypo
            Test.ReplaceAll(Replacements).ShouldBe("bbb short short bbb bshort");

            Test.ReplaceAll((Dictionary<string, string>) null).ShouldBe(Test);

            var Replacements2 = new Dictionary<string, string>
                {
                ["a"] = "b",
                ["long"] = "a"
                };

            L.F<string, Dictionary<string, string>, string>(StringExt.ReplaceAll).ShouldFail(Test, Replacements2);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." +
            nameof(StringExt.ToStream) + "(String) => Stream")]
        public void ToStream()
            {
            // ReSharper disable once StringLiteralTypo
            const string Test = "abcdefghijklmnopqrstuvwxyz";
            var Result = Test.ToStream();

            Result.Length.ShouldBe(Test.Length);

            var Test2 = new byte[Test.Length];

            Result.Read(Test2, offset: 0, count: Test2.Length);

            Test2.Should().Equal(97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122);


            const string Test3 = null;
            var Result2 = Test3.ToStream();

            Result2.Length.ShouldBe(Expected: 0);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." +
            nameof(StringExt.Matches) + "(String, String) => List<Match>")]
        public void Matches()
            {
            const string Test = "123 456";
            List<Match> Matches = Test.Matches(@"\d+");

            Matches.Should().HaveCount(expected: 2);
            Matches[index: 0].Value.ShouldBe("123");
            Matches[index: 1].Value.ShouldBe("456");


            Test.Matches(Expression: null).Should().HaveCount(expected: 0);
            Test.Matches("").Should().HaveCount(expected: 0);
            ((string) null).Matches(Expression: null).Should().HaveCount(expected: 0);
            ((string) null).Matches("").Should().HaveCount(expected: 0);
            }


        // Attribute Tested //////////////////////////////////////////////////////////////////////////////

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Add) + "(String, Char[]) => String")]
        public void Add_String_Char_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Add) + "(String, IEnumerable<Char>) => String")]
        public void Add_String_IEnumerable_Char_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.After) + "(String, String) => String")]
        public void After()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.AfterLast) + "(String, String) => String")]
        public void AfterLast()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.AlignCenter) + "(String, Int32, Char) => String")]
        public void AlignCenter_String_Int32_Char_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.AlignCenter) + "(String, UInt32, Char) => String")]
        public void AlignCenter_String_UInt32_Char_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.AlignLeft) + "(String, Int32, Char) => String")]
        public void AlignLeft_String_Int32_Char_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.AlignLeft) + "(String, UInt32, Char) => String")]
        public void AlignLeft_String_UInt32_Char_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.AlignRight) + "(String, Int32, Char) => String")]
        public void AlignRight_String_Int32_Char_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.AlignRight) + "(String, UInt32, Char) => String")]
        public void AlignRight_String_UInt32_Char_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Before) + "(String, String) => String")]
        public void Before()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.BeforeLast) + "(String, String) => String")]
        public void BeforeLast()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.ByteArrayToString) + "(Byte[]) => String")]
        public void ByteArrayToString()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.CleanCrlf) + "(String) => String")]
        public void CleanCrlf()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.UnCleanCrlf) + "(String) => String")]
        public void UnCleanCrlf()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Combine) + "(IEnumerable<String>, String) => String")]
        public void Combine()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Concatenate) + "(String, Int32, String) => String")]
        public void Concatenate()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.ContainsAny) + "(String, IEnumerable<String>) => Boolean")]
        public void ContainsAny()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Count) + "(String, String) => UInt32")]
        public void Count()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Fill) + "(Char, Int32) => String")]
        public void Fill_Char_Int32_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Fill) + "(Char, UInt32) => String")]
        public void Fill_Char_UInt32_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.FirstCaps) + "(String) => String")]
        public void FirstCaps()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.FormatFileSize) + "(Int64, Int32) => String")]
        public void FormatFileSize_Int64_Int32_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.FormatFileSize) + "(Int32, Int32) => String")]
        public void FormatFileSize_Int32_Int32_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.HasMatch) + "(String, String[]) => Boolean")]
        public void HasMatch()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Humanize) + "(String) => String")]
        public void Humanize()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.IsEmpty) + "(String) => Boolean")]
        public void IsEmpty()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.IsNumber) + "(Char) => Boolean")]
        public void IsNumber()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.IsSymmetrical) + "(String, String, Double) => Boolean")]
        public void IsSymmetrical()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.JoinLines) + "(IEnumerable<String>, String) => String")]
        public void JoinLines()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Like) + "(String, String) => Boolean")]
        public void Like()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Lines) + "(String) => String[]")]
        public void Lines()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Pad) + "(String, Int32, Align, Char) => String")]
        public void Pad_String_Int32_Align_Char_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Pad) + "(String, UInt32, Align, Char) => String")]
        public void Pad_String_UInt32_Align_Char_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Pluralize) + "(String, Int32) => String")]
        public void Pluralize_String_Int32_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Pluralize) + "(String, UInt32) => String")]
        public void Pluralize_String_UInt32_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Pluralize) + "(String) => String")]
        public void Pluralize_String_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.RemoveAll) + "(String, String[]) => String")]
        public void RemoveAll()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.ReplaceAll) + "(String, String, String) => String")]
        public void ReplaceAll_String_String_String_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.ReplaceLineEndings) + "(String, String) => String")]
        public void ReplaceLineEndings()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Reverse) + "(String) => String")]
        public void Reverse()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Singularize) + "(String) => String")]
        public void Singularize()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Split) + "(String, String) => String[]")]
        public void Split()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.SplitWithQuotes) + "(String, Char) => List<String>")]
        public void SplitWithQuotes()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Sub) + "(String, Int32, Nullable<Int32>) => String")]
        public void Sub_String_Int32_Nullable_Int32_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Sub) + "(String, UInt32, Nullable<UInt32>) => String")]
        public void Sub_String_UInt32_Nullable_UInt32_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Surround) + "(String, String, String) => String")]
        public void Surround()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Symmetry) + "(String, String) => Double")]
        public void Symmetry()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Times) + "(String, Int32) => String")]
        public void Times_String_Int32_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Times) + "(String, UInt32) => String")]
        public void Times_String_UInt32_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Times) + "(Char, Int32) => String")]
        public void Times_Char_Int32_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Times) + "(Char, UInt32) => String")]
        public void Times_Char_UInt32_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.ToByteArray) + "(String) => Byte[]")]
        public void ToByteArray()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.ToHexString) + "(Byte[]) => String")]
        public void ToHexString()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.ToUrlSlug) + "(String) => String")]
        public void ToUrlSlug()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Trim) + "(String, String) => String")]
        public void Trim()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.TrimEnd) + "(String, String) => String")]
        public void TrimEnd()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.TrimStart) + "(String, String) => String")]
        public void TrimStart()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Words) + "(String) => String[]")]
        public void Words()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.XmlClean) + "(String) => String")]
        public void XmlClean()
            {
            // Attribute Tests Implemented
            }
        }
    }