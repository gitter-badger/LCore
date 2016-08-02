using LCore.Extensions;
using System;
using FluentAssertions;
using LCore.Extensions.Optional;
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
        }
    }