using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;
using static LCore.LUnit.LUnit.Categories;

namespace LCore.Tests
    {
    [Trait(Category, AssemblyTests)]
    public class LCoreAssemblyTester : AssemblyTester
        {
        protected override Type AssemblyType => typeof(L);

        protected override bool EnforceNullabilityAttributes => true;

        public LCoreAssemblyTester([NotNull] ITestOutputHelper Output) : base(Output) {}
        }
    }