using LCore.Extensions;
using System;
using FluentAssertions;
using Xunit;
using static LCore.LUnit.LUnit.Categories;

// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedParameter.Global

namespace LCore.Tests.Extensions
    {
    [Trait(Category, StaticMethods)]
    public class StrTest
        {
        [Fact]
        public void Test_L_Str()
            {
            L.Str.Empty().Should().Be("");
            }
        }
    }