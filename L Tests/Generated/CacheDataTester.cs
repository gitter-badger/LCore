using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using LCore.Tools;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.Tools
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(CacheData))]
    public partial class CacheDataTester : XUnitOutputTester
        {
        public CacheDataTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~CacheDataTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(CacheData) + "." + nameof(CacheData.AddTime))]
        public void AddTime()
            {
            // TODO: Implement method test LCore.Tools.CacheData.AddTime
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(CacheData) + "." + nameof(CacheData.TotalTimeSaved))]
        public void get_TotalTimeSaved()
            {
            // TODO: Implement method test LCore.Tools.CacheData.get_TotalTimeSaved
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(CacheData) + "." + nameof(CacheData.PercentSaved))]
        public void get_PercentSaved()
            {
            // TODO: Implement method test LCore.Tools.CacheData.get_PercentSaved
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(CacheData) + "." + nameof(CacheData.TotalTimeSaved))]
        public void TotalTimeSaved()
            {
            // TODO: Implement method test LCore.Tools.CacheData.TotalTimeSaved
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(CacheData) + "." + nameof(CacheData.PercentSaved))]
        public void PercentSaved()
            {
            // TODO: Implement method test LCore.Tools.CacheData.PercentSaved
            }

        }
    }