using System;
using System.Collections.Generic;
using System.Reflection;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.Tests;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedParameter.Global

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L))]
    public partial class L_RefTester : XUnitOutputTester, IDisposable
        {
        public L_RefTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }
        
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." +
            nameof(L.Ref.GetNamespaceTypes) + "(String, Type[]) => Type[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." +
            nameof(L.Ref.GetNamespaceTypes) + "(Type, String, Type[]) => Type[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." +
            nameof(L.Ref.GetNamespaceTypes) + "(Assembly, String, Type[]) => Type[]")]
        public void Test_GetNamespaceTypes()
            {
            L.Ref.GetNamespaceTypes("LCore.Tests").ShouldBeEquivalentTo(new List<Type>
                {
                typeof(LCoreAssemblyTester)
                });

            L.Ref.GetNamespaceTypes("LCore", typeof(L)).Should().Equal();

            L.Ref.GetNamespaceTypes(typeof(L), "LCore.Extensions", typeof(L)).ShouldBeEquivalentTo(new List<Type>
                {
                typeof(L)
                });

            L.Ref.GetNamespaceTypes(Assembly.GetAssembly(typeof(L)), "LCore.Extensions", typeof(L)).ShouldBeEquivalentTo(new List<Type>
                {
                typeof(L)
                });
            }
        }
    }