using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable RedundantNameQualifier
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable UnusedAutoPropertyAccessor.Local
#pragma warning disable 169

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass,
        nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.ObjectExt))]
    public partial class ObjectExtTester : XUnitOutputTester, IDisposable
        {
        public ObjectExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        #region LCore.Extensions.ObjectExt

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.ObjectExt) +
            "." + nameof(global::LCore.Extensions.ObjectExt.HasProperty) + "(Object, String) => Boolean")]
        public void HasProperty()
            {
            const string Test = "";

            Test.HasProperty(nameof(string.Length)).ShouldBeTrue();
            Test.HasProperty("no i dont").ShouldBeFalse();
            Test.HasProperty("").ShouldBeFalse();
            Test.HasProperty(PropertyName: null).ShouldBeFalse();
            ((string)null).HasProperty(nameof(string.Length)).ShouldBeFalse();
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.ObjectExt) +
            "." + nameof(global::LCore.Extensions.ObjectExt.GetProperty) + "(Object, String) => Object")]
        public void GetProperty()
            {
            const string Test = "test test test test test test test test test";

            Test.GetProperty(nameof(string.Length)).ShouldBe(Compare: 44);

            Test.GetProperty(PropertyName: null).Should().BeNull();

            Test.GetProperty("").Should().BeNull();

            Test.GetProperty("bad property").Should().BeNull();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.ObjectExt) +
            "." + nameof(global::LCore.Extensions.ObjectExt.SetProperty) + "(Object, String, Object)")]
        public void SetProperty()
            {
            var Test = new TestClass();

            Test.SetProperty(nameof(TestClass.A), PropertyValue: 999);

            Test.A.ShouldBe(Compare: 999);

            L.A(() => Test.SetProperty(nameof(TestClass.A), "nope")).ShouldFail();
            L.A(() => Test.SetProperty("no prop", PropertyValue: 999)).ShouldFail();
            }

        #endregion


        #region Helper classes

        [ExcludeFromCodeCoverage]
        private class TestMaster
            {
            public TestClass A { get; set; }
            public TestClass B { get; set; }
            public TestMaster C { get; set; }
            }
        [ExcludeFromCodeCoverage]
        private class TestClass
            {
            public int? A { get; set; }
            public int? B { get; set; }
            public int? C { get; set; }
            }

        [ExcludeFromCodeCoverage]
        private class TestSubclass : TestClass
            {
            public int? D { get; set; }
            public int? E { get; set; }
            }

        [ExcludeFromCodeCoverage]
        private class TestClassReadOnly
            {
            public int? A { get; private set; }
            public int? B { get; private set; }
            public int? C { get; private set; }

            public TestClassReadOnly(int A, int B, int C)
                {
                this.A = A;
                this.B = B;
                this.C = C;
                }
            }


        [ExcludeFromCodeCoverage]
        private class TestClassError
            {
            public int? A { get; set; }
            public int? B { get; set; }

            /// <exception cref="Exception" accessor="get">oh no</exception>
            public int? C
                {
                get { throw new Exception("oh no"); }
                }

            public int D = 5;
            public int E = 7;
            }

        #endregion
        }
    }