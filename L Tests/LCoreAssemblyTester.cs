using System;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using L_Thread_Tests.LCore.Extensions;
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

        protected override bool EnableCodeAutoGeneration => true;

        protected override Assembly[] TestAssemblies => new[]
            {
            Assembly.GetAssembly(typeof(LCoreAssemblyTester)),
            Assembly.GetAssembly(typeof(ThreadExtTester))
            };

        public LCoreAssemblyTester([NotNull] ITestOutputHelper Output) : base(Output) { }
        }
    }