
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace L_Tests
    {
    [TestClass]
    public class DictionaryExtTest : ExtensionTester
        {
        protected override Type[] TestType => new[] { typeof(DictionaryExt) };

        [TestMethod]
        public void Test_Merge()
            {
            var test = new Dictionary<string, string>
                {
                ["a"] = "b",
                ["b"] = "c",
                ["c"] = "d"
                };
            var test2 = new Dictionary<string, string>
                {
                ["d"] = "e",
                ["e"] = "f",
                ["f"] = "g"
                };

            test.Merge(test2);
            }

        [TestMethod]
        public void Test_AddRange()
            {
            var test = new Dictionary<string, string>
                {
                ["a"] = "b",
                ["b"] = "c",
                ["c"] = "d"
                };
            var test2 = new Dictionary<string, string>
                {
                ["d"] = "e",
                ["e"] = "f",
                ["f"] = "g"
                };

            test.AddRange(test2);
            }
        }
    }
