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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt))]
    public partial class DictionaryExtTester : XUnitOutputTester, IDisposable
        {
        public DictionaryExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." + nameof(DictionaryExt.Flip))]
        public void Flip()
            {
            // TODO: Implement method test LCore.Extensions.DictionaryExt.Flip
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." + nameof(DictionaryExt.Merge))]
        public void Merge()
            {
            // TODO: Implement method test LCore.Extensions.DictionaryExt.Merge
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." + nameof(DictionaryExt.AddRange))]
        public void AddRange()
            {
            // TODO: Implement method test LCore.Extensions.DictionaryExt.AddRange
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." + nameof(DictionaryExt.GetAllValues))]
        public void GetAllValues()
            {
            // TODO: Implement method test LCore.Extensions.DictionaryExt.GetAllValues
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." + nameof(DictionaryExt.SafeAdd))]
        public void SafeAdd()
            {
            // TODO: Implement method test LCore.Extensions.DictionaryExt.SafeAdd
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." + nameof(DictionaryExt.SafeSet))]
        public void SafeSet()
            {
            // TODO: Implement method test LCore.Extensions.DictionaryExt.SafeSet
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." + nameof(DictionaryExt.SafeGet))]
        public void SafeGet()
            {
            // TODO: Implement method test LCore.Extensions.DictionaryExt.SafeGet
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." + nameof(DictionaryExt.SafeRemove))]
        public void SafeRemove()
            {
            // TODO: Implement method test LCore.Extensions.DictionaryExt.SafeRemove
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." + nameof(DictionaryExt.ToDictionary))]
        public void ToDictionary_IEnumerable_1_Dictionary_2()
            {
            // TODO: Implement method test LCore.Extensions.DictionaryExt.ToDictionary
            }

        }
    }