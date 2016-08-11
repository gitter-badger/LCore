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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt))]
    public partial class StringExtTester : XUnitOutputTester, IDisposable
        {
        public StringExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Add))]
        public void Add_String_CharArray_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Add))]
        public void Add_String_IEnumerable_1_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.After))]
        public void After()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.AfterLast))]
        public void AfterLast()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.AlignCenter))]
        public void AlignCenter_String_Int32_Char_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.AlignCenter))]
        public void AlignCenter_String_UInt32_Char_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.AlignLeft))]
        public void AlignLeft_String_Int32_Char_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.AlignLeft))]
        public void AlignLeft_String_UInt32_Char_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.AlignRight))]
        public void AlignRight_String_Int32_Char_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.AlignRight))]
        public void AlignRight_String_UInt32_Char_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Before))]
        public void Before()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.BeforeLast))]
        public void BeforeLast()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.ByteArrayToString))]
        public void ByteArrayToString()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.CleanCrlf))]
        public void CleanCrlf()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.UnCleanCrlf))]
        public void UnCleanCrlf()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Combine))]
        public void Combine()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Concatenate))]
        public void Concatenate()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.ContainsAny))]
        public void ContainsAny()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Count))]
        public void Count()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Fill))]
        public void Fill_Char_Int32_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Fill))]
        public void Fill_Char_UInt32_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.FirstCaps))]
        public void FirstCaps()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.FormatFileSize))]
        public void FormatFileSize_Int64_Int32_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.FormatFileSize))]
        public void FormatFileSize_Int32_Int32_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.HasMatch))]
        public void HasMatch()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Humanize))]
        public void Humanize()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.IsEmpty))]
        public void IsEmpty()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.IsNumber))]
        public void IsNumber()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.IsSymmetrical))]
        public void IsSymmetrical()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.JoinLines))]
        public void JoinLines()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Like))]
        public void Like()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Lines))]
        public void Lines()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Matches))]
        public void Matches()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Matches
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Pad))]
        public void Pad_String_Int32_Align_Char_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Pad))]
        public void Pad_String_UInt32_Align_Char_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Pluralize))]
        public void Pluralize_String_Int32_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Pluralize))]
        public void Pluralize_String_UInt32_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Pluralize))]
        public void Pluralize_String_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.RemoveAll))]
        public void RemoveAll()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.ReplaceAll))]
        public void ReplaceAll_String_String_String_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.ReplaceAll))]
        public void ReplaceAll_String_IDictionary_2_String()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.ReplaceAll
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.ReplaceLineEndings))]
        public void ReplaceLineEndings()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Reverse))]
        public void Reverse()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Singularize))]
        public void Singularize()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Split))]
        public void Split()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.SplitWithQuotes))]
        public void SplitWithQuotes()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Sub))]
        public void Sub_String_Int32_Nullable_1_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Sub))]
        public void Sub_String_UInt32_Nullable_1_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Surround))]
        public void Surround()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Symmetry))]
        public void Symmetry()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Times))]
        public void Times_String_Int32_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Times))]
        public void Times_String_UInt32_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.ToByteArray))]
        public void ToByteArray()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.ToHexString))]
        public void ToHexString()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.ToStream))]
        public void ToStream()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.ToStream
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.ToUrlSlug))]
        public void ToUrlSlug()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Trim))]
        public void Trim()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.TrimEnd))]
        public void TrimEnd()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.TrimStart))]
        public void TrimStart()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Words))]
        public void Words()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.XmlClean))]
        public void XmlClean()
            {
            // Attribute Tests Implemented
            }

        }
    }