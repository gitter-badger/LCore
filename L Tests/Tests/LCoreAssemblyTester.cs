using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;
using static LCore.LUnit.LUnit.Categories;

namespace L_Tests.Tests
    {
    [Trait(Category, AssemblyTest)]
    public class LCoreAssemblyTester : AssemblyTester
        {
        protected override Type AssemblyType => typeof(L);


        public LCoreAssemblyTester([NotNull] ITestOutputHelper Output) : base(Output) {}
        }
    }