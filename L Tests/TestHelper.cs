using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using LCore.Extensions;
using System.Reflection;
using System.Diagnostics;
using System.Linq;
using LCore.Tests;

namespace L_Tests
    {
    public static class TestHelper
        {
        public static void RunTypeTests(this Type t)
            {
            try
                {
                Dictionary<MemberInfo, List<TestAttribute>> Tests = t.GetTestMembers();

                int TestCount = Tests.TotalCount();

                int MethodsWithoutTests = Tests.Keys.List().Count(key => Tests[key].Count == 0);

                Debug.Write("\r\n");
                Debug.Write($"{t.Name} {TestCount} Tests Defined \r\n");
                Debug.Write("\r\n");
                Debug.Write($"{t.Name} {MethodsWithoutTests} Tests Missing \r\n");
                Debug.Write("\r\n");

                Tests.Keys.List().Where(key => Tests[key].Count == 0).Each(
                    key =>
                {
                    Debug.Write($"{key.Name}\r\n");
                });

                int Passed = t.RunUnitTests();

                // Assert.AreNotEqual(Passed, 0);
                Assert.AreEqual(TestCount, Passed);
                }
            catch (Exception e)
                {
                throw new Exception(e.ToString().ReplaceAll("\r", ""));
                }
            }
        }
    }
