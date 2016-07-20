using System;
using FluentAssertions;
using Xunit;

namespace L_MVC_Tests.Layouts
    {
    public class RoutesTest
        {
        [Fact]
        public void Test_Layouts()
            {
            LMVC.Routes.Layouts.Admin.Should().Be("~/Views/Shared/Admin/_Admin.cshtml");
            LMVC.Routes.Layouts.Main.Should().Be("~/Views/Shared/_Main.cshtml");
            }
        }
    }
