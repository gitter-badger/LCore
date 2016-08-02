using LCore.Extensions;
using System;
using System.Collections.Generic;
using FluentAssertions;
using LCore.Extensions.Optional;
using LCore.Interfaces;
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
            L.Ref.GetNamespaceTypes("L_Tests").ShouldBeEquivalentTo(new List<Type>()
                {
                typeof(ExtensionTester),
                typeof(ExtensionTester),
                typeof(ExtensionTester),
                typeof(ExtensionTester),
                typeof(ExtensionTester),
                typeof(ExtensionTester),
                typeof(ExtensionTester),
                typeof(ExtensionTester),
                typeof(ExtensionTester),
                });

            L.Ref.GetNamespaceTypes("L_Tests", typeof(ExtensionTester)).Should().Equal(typeof(void));
            }
        }
    }