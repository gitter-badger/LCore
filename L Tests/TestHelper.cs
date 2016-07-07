using System;
using System.Collections.Generic;
using LCore.Extensions;
using System.Reflection;
using System.Diagnostics;
using FluentAssertions;
using LCore.Tests;

namespace L_Tests
    {
    public static class TestHelper
        {
        public static void RunTypeTests(this Type t)
            {
            Dictionary<MemberInfo, List<TestAttribute>> Tests = t.GetTestMembers();

            int TestCount = Tests.TotalCount();
            
            List<string> Missing = Tests.Keys.List().Select(key => Tests[key].Count == 0).Convert(m => m.Name);
            List<string> Missing2 = Missing.RemoveDuplicates();

            if (Missing.Count > 0)
                {
                Debug.Write("\r\n");
                Missing2.Each(method => 
                    Debug.Write($"   {method.Pad(18)}   ({Missing.Count(method)})\r\n"));
                Debug.Write("\r\n");
                }

            int Passed = t.RunUnitTests();

            TestCount.Should().Be(Passed);
            }
        }
    }
