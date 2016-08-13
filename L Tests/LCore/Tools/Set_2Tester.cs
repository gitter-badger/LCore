using System;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.LUnit;
using LCore.Tools;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PossibleUnintendedReferenceComparison
// ReSharper disable RedundantCast
// ReSharper disable ConditionIsAlwaysTrueOrFalse

namespace L_Tests.LCore.Tools
    {
    [Trait(Traits.TargetClass, "LCore.Tools.Set`2")]
    public partial class Set_2Tester : XUnitOutputTester, IDisposable
        {
        private readonly Set<int, string> _Test = new Set<int, string>(Obj1: 5, Obj2: "4");
        private readonly Set<int, string> _Test2 = new Set<int, string>(Obj1: 5, Obj2: "4");
        private readonly Set<int?, string> _Test3 = new Set<int?, string>(Obj1: null, Obj2: null);

        public Set_2Tester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        public void TestSets()
            {
            var Test = new Set<int, string>(Obj1: 5, Obj2: "4");

            Test.Obj1.Should().Be(expected: 5);
            Test.Obj2.Should().Be("4");

            this._Test3.Obj1.Should().Be(expected: null);
            this._Test3.Obj2.Should().Be(expected: null);
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.Set`2.Equals(Object) => Boolean")]
        public void Equals_Object_Boolean()
            {
            this._Test.Equals(Other: null).Should().BeFalse();
            this._Test.Equals((object)null).Should().BeFalse();
            this._Test.Equals((object)this._Test2).Should().BeTrue();
            this._Test.Equals((object)this._Test).Should().BeTrue();
            this._Test.Equals("").Should().BeFalse();

            (this._Test == null).Should().BeFalse();
#pragma warning disable 252,253
            (this._Test == (object)null).Should().BeFalse();
            (this._Test == this._Test2).Should().BeTrue();
#pragma warning disable CS1718 // Comparison made to same variable
            // ReSharper disable once EqualExpressionComparison
            (this._Test == this._Test).Should().BeTrue();
#pragma warning restore CS1718 // Comparison made to same variable
            (this._Test == (object)"").Should().BeFalse();
#pragma warning restore 252,253
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.Set`2.GetHashCode() => Int32")]
        public new void GetHashCode()
            {
            this._Test.GetHashCode().Should().Be(expected: 372027467);
            this._Test2.GetHashCode().Should().Be(expected: 372027467);
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.Set`2.Equals(Set`2) => Boolean")]
        public void Equals_Set_2_Boolean()
            {
            this._Test.Equals(this._Test2).Should().BeTrue();
            this._Test2.Equals(this._Test).Should().BeTrue();
            this._Test.Equals(this._Test).Should().BeTrue();
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.Set`2.ToString() => String")]
        public new void ToString()
            {
            this._Test.ToString().Should().Be("[5,4]");
            this._Test2.ToString().Should().Be("[5,4]");
            this._Test3.ToString().Should().Be("[,]");
            }

        }
    }