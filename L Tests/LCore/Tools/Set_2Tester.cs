using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.LUnit;
using LCore.LUnit.Fluent;
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
        public Set_2Tester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }
        private readonly Set<int, string> _Test = new Set<int, string>(Obj1: 5, Obj2: "4");
        private readonly Set<int, string> _Test2 = new Set<int, string>(Obj1: 5, Obj2: "4");
        private readonly Set<int?, string> _Test3 = new Set<int?, string>(Obj1: null, Obj2: null);

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.Set`2.Equals(Object) => Boolean")]
        [Trait(Traits.TargetMember, "LCore.Tools.Set`2.op_Equality(Set`2, Set`2) => Boolean")]
        [Trait(Traits.TargetMember, "LCore.Tools.Set`2.op_Inequality(Set`2, Set`2) => Boolean")]
        public void Equals_Object_Boolean()
            {
            this._Test.Equals(Other: null).ShouldBeFalse();
            this._Test.Equals((object)null).ShouldBeFalse();
            this._Test.Equals((object)this._Test2).ShouldBeTrue();
            this._Test.Equals((object)this._Test).ShouldBeTrue();
            this._Test.Equals("").ShouldBeFalse();

#pragma warning disable 252, 253
#pragma warning disable CS1718 // Comparison made to same variable
            // ReSharper disable EqualExpressionComparison
            (this._Test == null).ShouldBeFalse();
            (this._Test == (object)null).ShouldBeFalse();
            (this._Test == this._Test2).ShouldBeTrue();
            (this._Test == this._Test).ShouldBeTrue();
            (this._Test == (object)"").ShouldBeFalse();

            (this._Test != null).ShouldBeTrue();
            (this._Test != (object)null).ShouldBeTrue();
            (this._Test != this._Test2).ShouldBeFalse();
            (this._Test != this._Test).ShouldBeFalse();
            (this._Test != (object)"").ShouldBeTrue();
            // ReSharper restore EqualExpressionComparison
#pragma warning restore CS1718 // Comparison made to same variable
#pragma warning restore 252, 253
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.Set`2.Equals(Set`2) => Boolean")]
        public void Equals_Set_2_Boolean()
            {
            this._Test.Equals(this._Test2).ShouldBeTrue();
            this._Test2.Equals(this._Test).ShouldBeTrue();
            this._Test.Equals(this._Test).ShouldBeTrue();
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.Set`2.GetHashCode() => Int32")]
        public new void GetHashCode()
            {
            this._Test.GetHashCode().Should().Be(expected: 372027467);
            this._Test2.GetHashCode().Should().Be(expected: 372027467);
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.Set`2.op_Implicit(Set`2) => Tuple`2<T1, T2>")]
        public void op_Implicit_Set_2_Tuple_2_T1_T2()
            {
            var Tuple = (Tuple<int, string>)this._Test;

            var Set = (Set<int, string>)Tuple;

            (Set == this._Test).ShouldBeTrue();
            // TODO: Implement method test LCore.Tools.Set`2.op_Implicit
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.Set`2.op_Implicit(Tuple`2<T1, T2>) => Set`2")]
        public void op_Implicit_Tuple_2_T1_T2_Set_2()
            {
            // TODO: Implement method test LCore.Tools.Set`2.op_Implicit
            }

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
        [Trait(Traits.TargetMember, "LCore.Tools.Set`2.ToString() => String")]
        public new void ToString()
            {
            this._Test.ToString().Should().Be("[5,4]");
            this._Test2.ToString().Should().Be("[5,4]");
            this._Test3.ToString().Should().Be("[,]");
            }
        }
    }