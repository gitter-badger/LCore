using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using LCore.Tools;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Tools
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(CacheData))]
    public partial class CacheDataTester : XUnitOutputTester, IDisposable
        {
        public CacheDataTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(CacheData) + "." + nameof(CacheData.AddTime) + "(Int64)")]
        public void AddTime()
            {
            // TODO: Implement method test LCore.Tools.CacheData.AddTime
            }

        }
    }