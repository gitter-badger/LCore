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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L))]
    public partial class L_StrTester : XUnitOutputTester, IDisposable
        {
        public L_StrTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Str) + "." + nameof(L.Str.Char) + "(String, Int32) => Char")]
        public void Char()
            {
            // TODO: Implement method test LCore.Extensions.L.Str.Char
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Str) + "." + nameof(L.Str.JoinLines) + "(IEnumerable`1<String>, String) => String")]
        public void JoinLines()
            {
            // TODO: Implement method test LCore.Extensions.L.Str.JoinLines
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Str) + "." + nameof(L.Str.CompareNumberString) + "(String, String) => Int32")]
        public void CompareNumberString()
            {
            // TODO: Implement method test LCore.Extensions.L.Str.CompareNumberString
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Str) + "." + nameof(L.Str.NumericalCompare) + "(String, String) => Int32")]
        public void NumericalCompare()
            {
            // TODO: Implement method test LCore.Extensions.L.Str.NumericalCompare
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Str) + "." + nameof(L.Str.Pluralize) + "(String, Int32) => String")]
        public void Pluralize_String_Int32_String()
            {
            // TODO: Implement method test LCore.Extensions.L.Str.Pluralize
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Str) + "." + nameof(L.Str.Pluralize) + "(String, UInt32) => String")]
        public void Pluralize_String_UInt32_String()
            {
            // TODO: Implement method test LCore.Extensions.L.Str.Pluralize
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Str) + "." + nameof(L.Str.RemoveChars) + "(String, Char[]) => String")]
        public void RemoveChars()
            {
            // TODO: Implement method test LCore.Extensions.L.Str.RemoveChars
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Str) + "." + nameof(L.Str.ReplaceDouble) + "(String, Char) => String")]
        public void ReplaceDouble()
            {
            // TODO: Implement method test LCore.Extensions.L.Str.ReplaceDouble
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Str) + "." + nameof(L.Str.Singularize) + "(String) => String")]
        public void Singularize()
            {
            // TODO: Implement method test LCore.Extensions.L.Str.Singularize
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