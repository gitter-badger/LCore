using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using LCore.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.Tools
    {
    public partial class Lists_2Tester : XUnitOutputTester, IDisposable
        {
        public Lists_2Tester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void ListFailures()
            {
            L.A(() => new Lists<string, int>(List1: null, List2: new List<int>())).ShouldFail();
            L.A(() => new Lists<string, int>(new List<string>(), List2: null)).ShouldFail();
            L.A(() => new Lists<string, int>(new List<string> { "a" }, new List<int>())).ShouldFail();
            }


        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.Lists<T1, T2>.Add(T1, T2)")]
        [Trait(Traits.TargetMember, "LCore.Tools.Lists<T1, T2>.GetAt(Int32) => Set<T1, T2>")]
        public void Add()
            {
            var Test = new Lists<string, int>();

            Test.Add("a", o2: 1);

            Test.Count.ShouldBe(Expected: 1);
            Test.GetAt(Index: 0).ShouldBe(new Set<string, int>("a", Obj2: 1));
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.Lists<T1, T2>.Set(Int32, T1, T2)")]
        [Trait(Traits.TargetMember, "LCore.Tools.Lists<T1, T2>.Set1(Int32, T1)")]
        [Trait(Traits.TargetMember, "LCore.Tools.Lists<T1, T2>.Set2(Int32, T2)")]
        public void Set()
            {
            var Test = new Lists<string, int>();

            Test.Add("a", o2: 1);

            Test.Count.ShouldBe(Expected: 1);
            Test.GetAt(Index: 0).ShouldBe(new Set<string, int>("a", Obj2: 1));

            Test.Set(Index: 0, Value: "b", Value2: 2);

            Test.GetAt(Index: 0).ShouldBe(new Set<string, int>("b", Obj2: 2));

            Test.Set1(Index: 0, Value: "c");

            Test.GetAt(Index: 0).ShouldBe(new Set<string, int>("c", Obj2: 2));

            Test.Set2(Index: 0, Value: 3);

            Test.GetAt(Index: 0).ShouldBe(new Set<string, int>("c", Obj2: 3));
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.Lists<T1, T2>.RemoveAt(Int32)")]
        public void RemoveAt()
            {
            var Test = new Lists<string, int>();

            var Rand = new Random();

            Test.Add("a", o2: 0);
            Test.Add("c", o2: 3);

            L.A(() => Test.Add(Guid.NewGuid().ToString(), Rand.Next())).Repeat(Times: 100)();

            Test.Count.ShouldBe(Expected: 103);

            Test.RemoveAt(Index: 0);

            Test.Count.ShouldBe(Expected: 102);
            Test.List1.Count.ShouldBe(Expected: 102);
            Test.List2.Count.ShouldBe(Expected: 102);

            Test.GetAt(Index: 0).ShouldBe(new Set<string, int>("c", Obj2: 3));
            }

        }
    }