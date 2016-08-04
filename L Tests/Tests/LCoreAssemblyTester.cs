using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using LCore.Extensions;
using Xunit.Abstractions;

namespace L_Tests.Tests
    {
    public class LCoreAssemblyTester : AssemblyTester
        {
        protected override Type AssemblyType => typeof(L);


        public LCoreAssemblyTester([NotNull] ITestOutputHelper Output) : base(Output) {}
        }
    }