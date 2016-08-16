using System;
using System.Collections.Generic;
using System.Threading;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
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
        public void CachingDataIsFasterThanNotCaching()
            {
            const string Key = "testcache";

            L.Logic.ClearCache(Key);

            L.Logic.GetCacheData("testcache").Should().BeNull();

            bool Executed = false;
            Func<string, string> Test = new Func<string, string>(In =>
                {
                    Executed.ShouldBeFalse();
                    Thread.Sleep(millisecondsTimeout: 100);
                    Executed = true;
                    return In + "6";
                }).Cache(Key);

            /////////////////////////////////////////////////

            Test("a").ShouldBe("a6");
            Test("a").ShouldBe("a6");
            Test("a").ShouldBe("a6");
            Test("a").ShouldBe("a6");

            Executed = false;
            Test("b").ShouldBe("b6");

            long Total = 0;
            var PercentagesSaved = new List<double>();

            Dictionary<string, CacheData> Cache = L.Logic.GetCacheData("testcache");

            Cache.Values.Count.ShouldBe(Compare: 2);

            foreach (var CacheValue in Cache.Values.List())
                {
                PercentagesSaved.Add(CacheValue.PercentSaved);
                Total += CacheValue.TotalTimeSaved;
                }

            Total.Should().BeInRange(minimumValue: 300, maximumValue: 410);

            PercentagesSaved.Sum().Should().BeInRange(minimumValue: 70, maximumValue: 80);
            }
        }
    }