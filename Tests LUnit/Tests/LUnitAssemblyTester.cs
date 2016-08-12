using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;
using Xunit;
using Xunit.Abstractions;
using static LCore.LUnit.LUnit.Categories;

namespace LCore.LUnit.Tests
    {
    [Trait(Category, AssemblyTests)]
    public class LUnitAssemblyTester : AssemblyTester
        {
        protected override Type AssemblyType => typeof(LUnit);

        protected override bool EnableCodeAutoGeneration => true;

        public LUnitAssemblyTester([NotNull] ITestOutputHelper Output) : base(Output) { }
        }
    }