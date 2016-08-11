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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ConvertibleExt))]
    public partial class ConvertibleExtTester : XUnitOutputTester, IDisposable
        {
        public ConvertibleExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ConvertibleExt) + "." + nameof(ConvertibleExt.CanConvertTo))]
        public void CanConvertTo_IConvertible_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ConvertibleExt.CanConvertTo
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ConvertibleExt) + "." + nameof(ConvertibleExt.CanConvertTo))]
        public void CanConvertTo_IConvertible_Type_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ConvertibleExt.CanConvertTo
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ConvertibleExt) + "." + nameof(ConvertibleExt.CanConvertToString))]
        public void CanConvertToString()
            {
            // TODO: Implement method test LCore.Extensions.ConvertibleExt.CanConvertToString
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ConvertibleExt) + "." + nameof(ConvertibleExt.ConvertTo))]
        public void ConvertTo_IConvertible_Type_Object()
            {
            // TODO: Implement method test LCore.Extensions.ConvertibleExt.ConvertTo
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ConvertibleExt) + "." + nameof(ConvertibleExt.ConvertTo))]
        public void ConvertTo_IConvertible_Nullable_1()
            {
            // TODO: Implement method test LCore.Extensions.ConvertibleExt.ConvertTo
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ConvertibleExt) + "." + nameof(ConvertibleExt.ConvertToString))]
        public void ConvertToString()
            {
            // TODO: Implement method test LCore.Extensions.ConvertibleExt.ConvertToString
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ConvertibleExt) + "." + nameof(ConvertibleExt.TryConvertTo))]
        public void TryConvertTo()
            {
            // TODO: Implement method test LCore.Extensions.ConvertibleExt.TryConvertTo
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ConvertibleExt) + "." + nameof(ConvertibleExt.TryConvertToString))]
        public void TryConvertToString()
            {
            // TODO: Implement method test LCore.Extensions.ConvertibleExt.TryConvertToString
            }

        }
    }