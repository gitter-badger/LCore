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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L))]
    public partial class L_NumTester : XUnitOutputTester
        {
        public L_NumTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~L_NumTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Num) + "." + nameof(L.Num.MostPreciseType))]
        public void get_MostPreciseType()
            {
            // TODO: Implement method test LCore.Extensions.L.Num.get_MostPreciseType
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Num) + "." + nameof(L.Num.NumberTypes))]
        public void get_NumberTypes()
            {
            // TODO: Implement method test LCore.Extensions.L.Num.get_NumberTypes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Num) + "." + nameof(L.Num.ScientificNotationToNumber))]
        public void ScientificNotationToNumber()
            {
            // TODO: Implement method test LCore.Extensions.L.Num.ScientificNotationToNumber
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Num) + "." + nameof(L.Num.NumberTypes))]
        public void NumberTypes()
            {
            // TODO: Implement method test LCore.Extensions.L.Num.NumberTypes
            }

        }
    }