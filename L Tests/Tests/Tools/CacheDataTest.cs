using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using FluentAssertions;
using LCore.Extensions;
using LCore.Tools;
using Xunit;
using static LCore.LUnit.LUnit.Categories;

namespace LCore.Tests.Tools
    {
    [Trait(Category, LUnit.LUnit.Categories.Tools)]
    public class CacheDataTest
        {
        [Fact]
        public void Test_CacheData()
            {
            const string Key = "testcache";

            L.Logic.ClearCache(Key);

            L.Logic.GetCacheData("testcache").Should().BeNull();

            bool Executed = false;
            Func<string, string> Test = new Func<string, string>(In =>
                {
                Executed.Should().BeFalse();
                Thread.Sleep(millisecondsTimeout: 100);
                Executed = true;
                return In + "6";
                }).Cache(Key);

            /////////////////////////////////////////////////

            Test("a").Should().Be("a6");
            Test("a").Should().Be("a6");
            Test("a").Should().Be("a6");
            Test("a").Should().Be("a6");

            Executed = false;
            Test("b").Should().Be("b6");

            long Total = 0;
            var PercentagesSaved = new List<double>();

            Dictionary<string, CacheData> Cache = L.Logic.GetCacheData("testcache");

            Cache.Values.Count.Should().Be(expected: 2);

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