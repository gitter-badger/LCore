using LCore.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;
using FluentAssertions;
using Xunit;
using static LCore.LUnit.LUnit.Categories;

// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedParameter.Global

namespace LCore.Tests.Extensions
    {
    [Trait(Category, StaticMethods)]
    public class RefTest
        {
        [Fact]
        public void Test_As()
            {
            L.Obj.As<IConvertible>()(arg: 1).Should().NotBeNull();
            }

        [Fact]
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