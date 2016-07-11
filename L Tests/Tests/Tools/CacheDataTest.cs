using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using FluentAssertions;
using LCore.Extensions;
using LCore.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace L_Tests.Tests.Tools
    {
    [TestClass]
    public class CacheDataTest
        {
        [TestMethod]
        [TestCategory(L.Test.Categories.Tools)]
        public void Test_CacheData()
            {
            const string Key = "testcache";

            L.Logic.ClearCache(Key);

            L.Logic.GetCacheData("testcache").Should().BeNull();

            bool Executed = false;
            Func<string, string> Test = new Func<string, string>(s =>
                {
                    Executed.Should().BeFalse();
                    Thread.Sleep(100);
                    Executed = true;
                    return s + "6";
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

            Cache.Values.Count.Should().Be(2);

            foreach (var CacheValue in Cache.Values.List())
                {
                PercentagesSaved.Add(CacheValue.PercentSaved);
                Total += CacheValue.TotalTimeSaved;
                }

            Total.Should().BeInRange(300, 400);

            PercentagesSaved.Sum().Should().BeInRange(70, 80);
            }
        }
    }