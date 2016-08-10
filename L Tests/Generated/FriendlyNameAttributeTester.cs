using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using LCore.Naming;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.Naming
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Naming) + "." + nameof(FriendlyNameAttribute))]
    public partial class FriendlyNameAttributeTester : XUnitOutputTester
        {
        public FriendlyNameAttributeTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~FriendlyNameAttributeTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Naming) + "." + nameof(FriendlyNameAttribute) + "." + nameof(FriendlyNameAttribute.FriendlyName))]
        public void get_FriendlyName()
            {
            // TODO: Implement method test LCore.Naming.FriendlyNameAttribute.get_FriendlyName
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Naming) + "." + nameof(FriendlyNameAttribute) + "." + nameof(FriendlyNameAttribute.FriendlyName))]
        public void set_FriendlyName()
            {
            // TODO: Implement method test LCore.Naming.FriendlyNameAttribute.set_FriendlyName
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Naming) + "." + nameof(FriendlyNameAttribute) + "." + nameof(FriendlyNameAttribute.FriendlyName))]
        public void FriendlyName()
            {
            // TODO: Implement method test LCore.Naming.FriendlyNameAttribute.FriendlyName
            }

        }
    }