using LCore.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;
using FluentAssertions;
using Xunit;
using static LCore.Extensions.L.Test.Categories;

// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedParameter.Global

namespace L_Tests.Tests.Extensions
    {
    [Trait(Category, StaticMethods)]
    public class RefTest
        {
        [Fact]
        public void Test_As()
            {
            L.Obj.As<IConvertible>()(1).Should().NotBeNull();
            }

        [Fact]
        public void Test_GetNamespaceTypes()
            {
            L.Ref.GetNamespaceTypes("L_Tests").ShouldBeEquivalentTo(new List<Type>
                {
                typeof(ExtensionTester)
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