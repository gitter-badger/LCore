using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt))]
    public partial class StringExtTester : XUnitOutputTester, IDisposable
        {
        public StringExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Add) + "(String, Char[]) => String")]
        public void Add_String_Char_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Add) + "(String, IEnumerable`1<Char>) => String")]
        public void Add_String_IEnumerable_1_Char_String()
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
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Combine) + "(IEnumerable`1<String>, String) => String")]
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
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.ContainsAny) + "(String, IEnumerable`1<String>) => Boolean")]
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
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.JoinLines) + "(IEnumerable`1<String>, String) => String")]
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
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Matches) + "(String, String) => List`1<Match>")]
        public void Matches()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Matches
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
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.ReplaceAll) + "(String, IDictionary`2<String, String>) => String")]
        public void ReplaceAll_String_IDictionary_2_String_String_String()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.ReplaceAll
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
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.SplitWithQuotes) + "(String, Char) => List`1<String>")]
        public void SplitWithQuotes()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Sub) + "(String, Int32, Nullable`1<Int32>) => String")]
        public void Sub_String_Int32_Nullable_1_Int32_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Sub) + "(String, UInt32, Nullable`1<UInt32>) => String")]
        public void Sub_String_UInt32_Nullable_1_UInt32_String()
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
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.ToStream) + "(String) => Stream")]
        public void ToStream()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.ToStream
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