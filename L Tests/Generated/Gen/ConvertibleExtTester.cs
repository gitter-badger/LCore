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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ConvertibleExt))]
    public partial class ConvertibleExtTester : XUnitOutputTester, IDisposable
        {
        public ConvertibleExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ConvertibleExt) + "." + nameof(ConvertibleExt.CanConvertTo) + "(IConvertible) => Boolean")]
        public void CanConvertTo_IConvertible_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ConvertibleExt.CanConvertTo
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ConvertibleExt) + "." + nameof(ConvertibleExt.CanConvertTo) + "(IConvertible, Type) => Boolean")]
        public void CanConvertTo_IConvertible_Type_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ConvertibleExt.CanConvertTo
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ConvertibleExt) + "." + nameof(ConvertibleExt.CanConvertToString) + "(IConvertible) => Boolean")]
        public void CanConvertToString()
            {
            // TODO: Implement method test LCore.Extensions.ConvertibleExt.CanConvertToString
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ConvertibleExt) + "." + nameof(ConvertibleExt.ConvertTo) + "(IConvertible, Type) => Object")]
        public void ConvertTo_IConvertible_Type_Object()
            {
            // TODO: Implement method test LCore.Extensions.ConvertibleExt.ConvertTo
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ConvertibleExt) + "." + nameof(ConvertibleExt.ConvertTo) + "(IConvertible) => Nullable`1<T>")]
        public void ConvertTo_IConvertible_Nullable_1_T()
            {
            // TODO: Implement method test LCore.Extensions.ConvertibleExt.ConvertTo
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ConvertibleExt) + "." + nameof(ConvertibleExt.ConvertToString) + "(IConvertible) => String")]
        public void ConvertToString()
            {
            // TODO: Implement method test LCore.Extensions.ConvertibleExt.ConvertToString
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ConvertibleExt) + "." + nameof(ConvertibleExt.TryConvertTo) + "(IConvertible) => IConvertible")]
        public void TryConvertTo()
            {
            // TODO: Implement method test LCore.Extensions.ConvertibleExt.TryConvertTo
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ConvertibleExt) + "." + nameof(ConvertibleExt.TryConvertToString) + "(IConvertible) => IConvertible")]
        public void TryConvertToString()
            {
            // TODO: Implement method test LCore.Extensions.ConvertibleExt.TryConvertToString
            }

        }
    }