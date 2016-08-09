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
    public partial class StringExtTester : XUnitOutputTester
        {
        public StringExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~StringExtTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Add))]
        public void Add_String_Char_String()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Add
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Add))]
        public void Add_String_IEnumerable_1_String()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Add
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.After))]
        public void After()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.After
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.AfterLast))]
        public void AfterLast()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.AfterLast
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.AlignCenter))]
        public void AlignCenter_String_Int32_Char_String()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.AlignCenter
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.AlignCenter))]
        public void AlignCenter_String_UInt32_Char_String()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.AlignCenter
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.AlignLeft))]
        public void AlignLeft_String_Int32_Char_String()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.AlignLeft
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.AlignLeft))]
        public void AlignLeft_String_UInt32_Char_String()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.AlignLeft
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.AlignRight))]
        public void AlignRight_String_Int32_Char_String()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.AlignRight
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.AlignRight))]
        public void AlignRight_String_UInt32_Char_String()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.AlignRight
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Before))]
        public void Before()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Before
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.BeforeLast))]
        public void BeforeLast()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.BeforeLast
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.ByteArrayToString))]
        public void ByteArrayToString()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.ByteArrayToString
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.CleanCrlf))]
        public void CleanCrlf()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.CleanCrlf
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.UnCleanCrlf))]
        public void UnCleanCrlf()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.UnCleanCrlf
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Combine))]
        public void Combine()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Combine
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Concatenate))]
        public void Concatenate()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Concatenate
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.ContainsAny))]
        public void ContainsAny()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.ContainsAny
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Count))]
        public void Count()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Count
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Fill))]
        public void Fill_Char_Int32_String()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Fill
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Fill))]
        public void Fill_Char_UInt32_String()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Fill
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.FirstCaps))]
        public void FirstCaps()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.FirstCaps
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.FormatFileSize))]
        public void FormatFileSize_Int64_Int32_String()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.FormatFileSize
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.FormatFileSize))]
        public void FormatFileSize_Int32_Int32_String()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.FormatFileSize
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.HasMatch))]
        public void HasMatch()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.HasMatch
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Humanize))]
        public void Humanize()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Humanize
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.IsEmpty))]
        public void IsEmpty()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.IsEmpty
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.IsNumber))]
        public void IsNumber()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.IsNumber
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.IsSymmetrical))]
        public void IsSymmetrical()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.IsSymmetrical
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.JoinLines))]
        public void JoinLines()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.JoinLines
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Like))]
        public void Like()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Like
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Lines))]
        public void Lines()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Lines
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
            // TODO: Implement method test LCore.Extensions.StringExt.Pad
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Pad))]
        public void Pad_String_UInt32_Align_Char_String()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Pad
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Pluralize))]
        public void Pluralize_String_Int32_String()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Pluralize
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Pluralize))]
        public void Pluralize_String_UInt32_String()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Pluralize
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Pluralize))]
        public void Pluralize_String_String()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Pluralize
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.RemoveAll))]
        public void RemoveAll()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.RemoveAll
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.ReplaceAll))]
        public void ReplaceAll_String_String_String_String()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.ReplaceAll
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
            // TODO: Implement method test LCore.Extensions.StringExt.ReplaceLineEndings
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Reverse))]
        public void Reverse()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Reverse
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Singularize))]
        public void Singularize()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Singularize
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Split))]
        public void Split()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Split
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.SplitWithQuotes))]
        public void SplitWithQuotes()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.SplitWithQuotes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Sub))]
        public void Sub_String_Int32_Nullable_1_String()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Sub
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Sub))]
        public void Sub_String_UInt32_Nullable_1_String()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Sub
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Surround))]
        public void Surround()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Surround
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Symmetry))]
        public void Symmetry()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Symmetry
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Times))]
        public void Times_String_Int32_String()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Times
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Times))]
        public void Times_String_UInt32_String()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Times
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.ToByteArray))]
        public void ToByteArray()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.ToByteArray
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.ToHexString))]
        public void ToHexString()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.ToHexString
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
            // TODO: Implement method test LCore.Extensions.StringExt.ToUrlSlug
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Trim))]
        public void Trim()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Trim
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.TrimEnd))]
        public void TrimEnd()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.TrimEnd
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.TrimStart))]
        public void TrimStart()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.TrimStart
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.Words))]
        public void Words()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.Words
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." + nameof(StringExt.XmlClean))]
        public void XmlClean()
            {
            // TODO: Implement method test LCore.Extensions.StringExt.XmlClean
            }

        }
    }