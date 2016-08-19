using System;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable RedundantExtendsListEntry

// ReSharper disable EmptyDestructor

// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.Extensions
    {
    public partial class BooleanExtTester : XUnitOutputTester
        {
        private static readonly string _TestString = Guid.NewGuid().ToString();

        public BooleanExtTester([NotNull] ITestOutputHelper Output) : base(Output) {}

        ~BooleanExtTester() {}

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." + nameof(BooleanExt.Or) + "(IEnumerable<Func<Boolean>>) => Func<Boolean>")]
        public void Or_IEnumerable_1_Func_1()
            {
            var True = new Func<bool>(() => true);
            var False = new Func<bool>(() => false);

            new[] {False, False, False, False}.Or()().ShouldBeFalse();
            new[] {False, False, False, True}.Or()().ShouldBeTrue();
            }

        [Fact]
        [Trait(Traits.TargetMember,nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +nameof(BooleanExt.Or) + "(IEnumerable<Func<T1, Boolean>>) => Func<T1, Boolean>")]
        public void Or_IEnumerable_1_Func_2()
            {
            var True = new Func<object, bool>(o =>
                {
                o.ShouldBe(_TestString);
                return true;
                });
            var False = new Func<object, bool>(o =>
                {
                o.ShouldBe(_TestString);
                return false;
                });
            var NotRun = new Func<object, bool>(o =>
                {
                o.ShouldBe(_TestString);
                throw new Exception();
                });

            new[] {False, False, False, False}.Or()(_TestString).ShouldBeFalse();
            new[] {False, False, False, True}.Or()(_TestString).ShouldBeTrue();

            // True blocks execution of later items
            new[] {False, False, True, NotRun}.Or()(_TestString).ShouldBeTrue();
            L.A(() => new[] {False, False, False, NotRun}.Or()(_TestString)).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember,nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +nameof(BooleanExt.Or) + "(IEnumerable<Func<T1, T2, Boolean>>) => Func<T1, T2, Boolean>")]
        public void Or_IEnumerable_1_Func_3()
            {
            var True = new Func<object, object, bool>((o1, o2) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                return true;
                });
            var False = new Func<object, object, bool>((o1, o2) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                return false;
                });
            var NotRun = new Func<object, object, bool>((o1, o2) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                throw new Exception();
                });

            new[] {False, False, False, False}.Or()(_TestString, _TestString).ShouldBeFalse();
            new[] {False, False, False, True}.Or()(_TestString, _TestString).ShouldBeTrue();

            // True blocks execution of later items
            new[] {False, False, True, NotRun}.Or()(_TestString, _TestString).ShouldBeTrue();
            L.A(() => new[] {False, False, False, NotRun}.Or()(_TestString, _TestString)).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember,nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +nameof(BooleanExt.Or) + "(IEnumerable<Func<T1, T2, T3, Boolean>>) => Func<T1, T2, T3, Boolean>")]
        public void Or_IEnumerable_1_Func_4()
            {
            var True = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                o3.ShouldBe(_TestString);
                return true;
                });
            var False = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                o3.ShouldBe(_TestString);
                return false;
                });
            var NotRun = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                o3.ShouldBe(_TestString);
                throw new Exception();
                });

            new[] {False, False, False, False}.Or()(_TestString, _TestString, _TestString).ShouldBeFalse();
            new[] {False, False, False, True}.Or()(_TestString, _TestString, _TestString).ShouldBeTrue();

            // True blocks execution of later items
            new[] {False, False, True, NotRun}.Or()(_TestString, _TestString, _TestString).ShouldBeTrue();
            L.A(() => new[] {False, False, False, NotRun}.Or()(_TestString, _TestString, _TestString)).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember,nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +nameof(BooleanExt.Or) +"(IEnumerable<Func<T1, T2, T3, T4, Boolean>>) => Func<T1, T2, T3, T4, Boolean>")]
        public void Or_IEnumerable_1_Func_5()
            {
            var True = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                o3.ShouldBe(_TestString);
                o4.ShouldBe(_TestString);
                return true;
                });
            var False = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                o3.ShouldBe(_TestString);
                o4.ShouldBe(_TestString);
                return false;
                });
            var NotRun = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                o3.ShouldBe(_TestString);
                o4.ShouldBe(_TestString);
                throw new Exception();
                });

            new[] {False, False, False, False}.Or()(_TestString, _TestString, _TestString, _TestString).ShouldBeFalse();
            new[] {False, False, False, True}.Or()(_TestString, _TestString, _TestString, _TestString).ShouldBeTrue();

            // True blocks execution of later items
            new[] {False, False, True, NotRun}.Or()(_TestString, _TestString, _TestString, _TestString).ShouldBeTrue();
            L.A(() => new[] {False, False, False, NotRun}.Or()(_TestString, _TestString, _TestString, _TestString))
                .ShouldFail();
            }


        [Fact]
        [Trait(Traits.TargetMember,nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +nameof(BooleanExt.Not) + "(Func<Boolean>) => Func<Boolean>")]
        public void Not_Func_1_Func_1()
            {
            // True works 
            Func<bool> Func = L.Bool.True;
            Func.Not()().ShouldBeFalse();

            // False works
            Func<bool> Func2 = () => false;
            Func2.Not()().ShouldBeTrue();

            // Exceptions are not hidden
            Func<bool> Func3 = () => { throw new Exception(); };
            Func3.Not().ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember,nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +nameof(BooleanExt.Not) + "(Func<T1, Boolean>) => Func<T1, Boolean>")]
        public void Not_Func_2_Func_2()
            {
            // True works 
            Func<object, bool> Func = o =>
                {
                // Variables are passed.
                o.Should().BeSameAs(_TestString);
                return true;
                };
            Func.Not()(_TestString).ShouldBeFalse();

            // False works
            Func<object, bool> Func2 = o =>
                {
                // Variables are passed.
                o.Should().BeSameAs(_TestString);
                return false;
                };
            Func2.Not()(_TestString).ShouldBeTrue();

            // Exceptions are not hidden
            Func<object, bool> Func3 = o => { throw new Exception(); };
            Func3.Not().ShouldFail(o1: null);
            }

        [Fact]
        [Trait(Traits.TargetMember,nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +nameof(BooleanExt.Not) + "(Func<T1, T2, Boolean>) => Func<T1, T2, Boolean>")]
        public void Not_Func_3_Func_3()
            {
            // True works 
            Func<object, object, bool> Func = (o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return true;
                };
            Func.Not()(_TestString, _TestString).ShouldBeFalse();

            // False works
            Func<object, object, bool> Func2 = (o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return false;
                };
            Func2.Not()(_TestString, _TestString).ShouldBeTrue();

            // Exceptions are not hidden
            Func<object, object, bool> Func3 = (o1, o2) => { throw new Exception(); };
            Func3.Not().ShouldFail(o1: null, o2: null);
            }

        [Fact]
        [Trait(Traits.TargetMember,nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +nameof(BooleanExt.Not) + "(Func<T1, T2, T3, Boolean>) => Func<T1, T2, T3, Boolean>")]
        public void Not_Func_4_Func_4()
            {
            // True works 
            Func<object, object, object, bool> Func = (o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return true;
                };
            Func.Not()(_TestString, _TestString, _TestString).ShouldBeFalse();

            // False works
            Func<object, object, object, bool> Func2 = (o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return false;
                };
            Func2.Not()(_TestString, _TestString, _TestString).ShouldBeTrue();

            // Exceptions are not hidden
            Func<object, object, object, bool> Func3 = (o1, o2, o3) => { throw new Exception(); };
            Func3.Not().ShouldFail(o1: null, o2: null, o3: null);
            }

        [Fact]
        [Trait(Traits.TargetMember,nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +nameof(BooleanExt.Not) + "(Func<T1, T2, T3, T4, Boolean>) => Func<T1, T2, T3, T4, Boolean>")]
        public void Not_Func_5_Func_5()
            {
            // True works 
            Func<object, object, object, object, bool> Func = (o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return true;
                };
            Func.Not()(_TestString, _TestString, _TestString, _TestString).ShouldBeFalse();

            // False works
            Func<object, object, object, object, bool> Func2 = (o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return false;
                };
            Func2.Not()(_TestString, _TestString, _TestString, _TestString).ShouldBeTrue();

            // Exceptions are not hidden
            Func<object, object, object, object, bool> Func3 = (o1, o2, o3, o4) => { throw new Exception(); };
            Func3.Not().ShouldFail(o1: null, o2: null, o3: null, o4: null);
            }


        [Fact]
        [Trait(Traits.TargetMember,nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +nameof(BooleanExt.If) + "(Action, Func<Boolean>) => Func<Boolean>")]
        public void If_Action_Func_1_Func_1()
            {
            // False works
            bool Result = true;
            var Action = new Action(() => { Result = false; });

            Action.If(L.Bool.False)();
            Result.ShouldBeTrue();

            Action.If(L.Bool.True)();
            Result.ShouldBeFalse();

            // true works
            bool Result2 = false;
            var Action2 = new Action(() => { Result2 = true; });

            Action2.If(L.Bool.True)();
            Result2.ShouldBeTrue();

            // Exceptions are not hidden
            Action Action3 = () => { throw new Exception(); };
            Action3.If(L.Bool.True).ShouldFail();

            // Null Tests
            ((Action) null).If(L.Bool.True);
            Action3.If((Func<bool>) null);
            }

        [Fact]
        [Trait(Traits.TargetMember,nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +nameof(BooleanExt.If) + "(Action, Func<T, Boolean>) => Func<T, Boolean>")]
        public void If_Action_Func_2_Func_2()
            {
            var Condition = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.Should().BeSameAs(_TestString);
                return false;
                });
            // False works
            bool Result = false;
            var Action = new Action(() => { Result = true; });

            Action.If(Condition)(_TestString);
            Result.ShouldBeFalse();

            Action.If(Condition.Not())(_TestString);
            Result.ShouldBeTrue();

            // true works
            var Condition2 = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.Should().BeSameAs(_TestString);
                return true;
                });
            bool Result2 = false;
            var Action2 = new Action(() => { Result2 = true; });

            Action2.If(Condition2)(_TestString);
            Result2.ShouldBeTrue();

            // Exceptions are not hidden
            Action Action3 = () => { throw new Exception(); };
            Action3.If(Condition2).ShouldFail(_TestString);
            }

        [Fact]
        [Trait(Traits.TargetMember,nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +nameof(BooleanExt.If) + "(Action, Func<T1, T2, Boolean>) => Func<T1, T2, Boolean>")]
        public void If_Action_Func_3_Func_3()
            {
            var Condition = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return false;
                });
            // False works
            bool Result = false;
            var Action = new Action(() => { Result = true; });

            Action.If(Condition)(_TestString, _TestString);
            Result.ShouldBeFalse();

            Action.If(Condition.Not())(_TestString, _TestString);
            Result.ShouldBeTrue();

            // true works
            var Condition2 = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return true;
                });
            bool Result2 = false;
            var Action2 = new Action(() => { Result2 = true; });

            Action2.If(Condition2)(_TestString, _TestString);
            Result2.ShouldBeTrue();

            // Exceptions are not hidden
            Action Act3 = () => { throw new Exception(); };
            Act3.If(Condition2).ShouldFail(_TestString, _TestString);
            }

        [Fact]
        [Trait(Traits.TargetMember,nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +nameof(BooleanExt.If) + "(Action, Func<T1, T2, T3, Boolean>) => Func<T1, T2, T3, Boolean>")]
        public void If_Action_Func_4_Func_4()
            {
            var Condition = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return false;
                });
            // False works
            bool Result = false;
            var Act = new Action(() => { Result = true; });

            Act.If(Condition)(_TestString, _TestString, _TestString);
            Result.ShouldBeFalse();

            Act.If(Condition.Not())(_TestString, _TestString, _TestString);
            Result.ShouldBeTrue();

            // true works
            var Condition2 = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return true;
                });
            bool Result2 = false;
            var Act2 = new Action(() => { Result2 = true; });

            Act2.If(Condition2)(_TestString, _TestString, _TestString);
            Result2.ShouldBeTrue();

            // Exceptions are not hidden
            Action Act3 = () => { throw new Exception(); };
            Act3.If(Condition2).ShouldFail(_TestString, _TestString, _TestString);
            }

        [Fact]
        [Trait(Traits.TargetMember,nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +nameof(BooleanExt.If) + "(Action, Func<T1, T2, T3, T4, Boolean>) => Func<T1, T2, T3, T4, Boolean>")]
        public void If_Action_Func_5_Func_5()
            {
            var Condition = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return false;
                });
            // False works
            bool Result = false;
            var Act = new Action(() => { Result = true; });

            Act.If(Condition)(_TestString, _TestString, _TestString, _TestString);
            Result.ShouldBeFalse();

            Act.If(Condition.Not())(_TestString, _TestString, _TestString, _TestString);
            Result.ShouldBeTrue();

            // true works
            var Condition2 = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return true;
                });
            bool Result2 = false;
            var Act2 = new Action(() => { Result2 = true; });

            Act2.If(Condition2)(_TestString, _TestString, _TestString, _TestString);
            Result2.ShouldBeTrue();

            // Exceptions are not hidden
            Action Act3 = () => { throw new Exception(); };
            Act3.If(Condition2).ShouldFail(_TestString, _TestString, _TestString, _TestString);
            }


        [Fact]
        [Trait(Traits.TargetMember,nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +nameof(BooleanExt.If) + "(Func<T>, Func<Boolean>) => Func<T>")]
        public void If_Func_1_Func_1_Func_1()
            {
            // False works
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.If(L.Bool.False)();
            Result.ShouldBeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.If(L.Bool.True)();
            Result2.ShouldBe(_TestString);

            // true works
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.If(L.Bool.True)();
            Result3.ShouldBeTrue();

            // Result passes through
            Result4.ShouldBe(_TestString);

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(L.Bool.True).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember,nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +nameof(BooleanExt.If) + "(Func<T1>, Func<T2, Boolean>) => Func<T2, T1>")]
        public void If_Func_1_Func_2_Func_2()
            {
            // False works
            var Condition = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.Should().BeSameAs(_TestString);
                return false;
                });
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.If(Condition)(_TestString);
            Result.ShouldBeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.If(Condition.Not())(_TestString);
            Result2.ShouldBe(_TestString);

            // true works
            var Condition2 = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.Should().BeSameAs(_TestString);
                return true;
                });
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.If(Condition2)(_TestString);
            Result3.ShouldBeTrue();

            // Result passes through
            Result4.ShouldBe(_TestString);

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(Condition2).ShouldFail(_TestString);
            }

        [Fact]
        [Trait(Traits.TargetMember,nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +nameof(BooleanExt.If) + "(Func<T1>, Func<T2, T3, Boolean>) => Func<T2, T3, T1>")]
        public void If_Func_1_Func_3_Func_3()
            {
            // False works
            var Condition = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return false;
                });
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.If(Condition)(_TestString, _TestString);
            Result.ShouldBeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.If(Condition.Not())(_TestString, _TestString);
            Result2.ShouldBe(_TestString);

            // true works
            var Condition2 = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return true;
                });
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.If(Condition2)(_TestString, _TestString);
            Result3.ShouldBeTrue();

            // Result passes through
            Result4.ShouldBe(_TestString);

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(Condition2).ShouldFail(_TestString, _TestString);
            }

        [Fact]
        [Trait(Traits.TargetMember,nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +nameof(BooleanExt.If) + "(Func<T1>, Func<T2, T3, T4, Boolean>) => Func<T2, T3, T4, T1>")]
        public void If_Func_1_Func_4_Func_4()
            {
            // False works
            var Condition = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return false;
                });
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.If(Condition)(_TestString, _TestString, _TestString);
            Result.ShouldBeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.If(Condition.Not())(_TestString, _TestString, _TestString);
            Result2.ShouldBe(_TestString);

            // true works
            var Condition2 = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return true;
                });
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.If(Condition2)(_TestString, _TestString, _TestString);
            Result3.ShouldBeTrue();

            // Result passes through
            Result4.ShouldBe(_TestString);

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(Condition2).ShouldFail(_TestString, _TestString, _TestString);
            }

        [Fact]
        [Trait(Traits.TargetMember,nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +nameof(BooleanExt.If) + "(Func<T1>, Func<T2, T3, T4, T5, Boolean>) => Func<T2, T3, T4, T5, T1>")]
        public void If_Func_1_Func_5_Func_5()
            {
            // False works
            var Condition = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return false;
                });
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.If(Condition)(_TestString, _TestString, _TestString, _TestString);
            Result.ShouldBeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.If(Condition.Not())(_TestString, _TestString, _TestString, _TestString);
            Result2.ShouldBe(_TestString);

            // true works
            var Condition2 = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return true;
                });
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.If(Condition2)(_TestString, _TestString, _TestString, _TestString);
            Result3.ShouldBeTrue();

            // Result passes through
            Result4.ShouldBe(_TestString);

            // Exceptions are not hidden
            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(Condition2).ShouldFail(_TestString, _TestString, _TestString, _TestString);
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." + nameof(BooleanExt.Unless) + "(Action, Func<Boolean>[]) => Func<Boolean>")]
        public void Unless_Func_1_Func_1Array_Func_1()
            {
            // False works - AND is applied
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.Unless(L.Bool.True, L.Bool.False, L.Bool.False)();
            Result.ShouldBeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.Unless(L.Bool.False, L.Bool.False, L.Bool.False)();
            Result2.ShouldBe(_TestString);

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.Unless(L.Bool.False, L.Bool.False, L.Bool.False)();
            Result3.ShouldBeTrue();

            // Result passes through
            Result4.ShouldBe(_TestString);

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.Unless(L.Bool.False, L.Bool.False, L.Bool.False).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." + nameof(BooleanExt.Unless) + "(Action, Func<T, Boolean>[]) => Func<T, Boolean>")]
        public void Unless_Func_1_Func_2Array_Func_2()
            {
            var True = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.ShouldBe(_TestString);
                return true;
                });

            var False = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.ShouldBe(_TestString);
                return false;
                });

            // False works - AND is applied
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.Unless(True, False, False)(_TestString);
            Result.ShouldBeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.Unless(False, False, False)(_TestString);
            Result2.ShouldBe(_TestString);

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.Unless(False, False, False)(_TestString);
            Result3.ShouldBeTrue();

            // Result passes through
            Result4.ShouldBe(_TestString);

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.Unless(False, False, False).ShouldFail(_TestString);
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." + nameof(BooleanExt.Unless) + "(Action, Func<T1, T2, Boolean>[]) => Func<T1, T2, Boolean>")]
        public void Unless_Func_1_Func_3Array_Func_3()
            {
            var True = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return true;
                });

            var False = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return false;
                });

            // False works - AND is applied
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.Unless(True, False, False)(_TestString, _TestString);
            Result.ShouldBeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.Unless(False, False, False)(_TestString, _TestString);
            Result2.ShouldBe(_TestString);

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.Unless(False, False, False)(_TestString, _TestString);
            Result3.ShouldBeTrue();

            // Result passes through
            Result4.ShouldBe(_TestString);

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.Unless(False, False, False).ShouldFail(_TestString, _TestString);
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." + nameof(BooleanExt.Unless) + "(Action, Func<T1, T2, T3, Boolean>[]) => Func<T1, T2, T3, Boolean>")]
        public void Unless_Func_1_Func_4Array_Func_4()
            {
            var True = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return true;
                });

            var False = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return false;
                });

            // False works - AND is applied
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.Unless(True, False, False)(_TestString, _TestString, _TestString);
            Result.ShouldBeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.Unless(False, False, False)(_TestString, _TestString, _TestString);
            Result2.ShouldBe(_TestString);

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.Unless(False, False, False)(_TestString, _TestString, _TestString);
            Result3.ShouldBeTrue();

            // Result passes through
            Result4.ShouldBe(_TestString);

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.Unless(False, False, False).ShouldFail(_TestString, _TestString, _TestString);
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." + nameof(BooleanExt.Unless) + "(Action, Func<T1, T2, T3, T4, Boolean>[]) => Func<T1, T2, T3, T4, Boolean>")]
        public void Unless_Func_1_Func_5Array_Func_5()
            {
            var True = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return true;
                });

            var False = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return false;
                });

            // False works - AND is applied
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.Unless(True, False, False)(_TestString, _TestString, _TestString, _TestString);
            Result.ShouldBeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.Unless(False, False, False)(_TestString, _TestString, _TestString, _TestString);
            Result2.ShouldBe(_TestString);

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.Unless(False, False, False)(_TestString, _TestString, _TestString, _TestString);
            Result3.ShouldBeTrue();

            // Result passes through
            Result4.ShouldBe(_TestString);

            // Exceptions are not hidden
            Func<string> Action3 = () => { throw new Exception(); };
            Action3.Unless(False, False, False).ShouldFail(_TestString, _TestString, _TestString, _TestString);
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." + nameof(BooleanExt.Unless) + "(Func<T>, Func<Boolean>[]) => Func<T>")]
        public void Unless_Action_Func_1Array_Func_1()
            {
            // False works
            bool Result = true;
            var Act = new Action(() =>
                {
                Result = false;
                throw new Exception();
                });

            Act.Unless(L.Bool.True, L.Bool.False)();
            Result.ShouldBeTrue();
            L.A(() => Act.Unless(L.Bool.False)()).ShouldFail();

            // true works
            bool Result2 = false;
            var Act2 = new Action(() => { Result2 = true; });

            Act2.Unless(L.Bool.False, L.Bool.False)();
            Result2.ShouldBeTrue();

            // Exceptions are not hidden
            Action Act3 = () => { throw new Exception(); };
            Act3.Unless(L.Bool.False, L.Bool.False).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." + nameof(BooleanExt.Unless) + "(Func<T1>, Func<T2, Boolean>[]) => Func<T2, T1>")]
        public void Unless_Action_Func_2Array_Func_2()
            {
            var Condition = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.Should().BeSameAs(_TestString);
                return true;
                });
            // False works
            bool Result = false;
            var Act = new Action(() =>
                {
                Result = true;
                throw new Exception();
                });

            Act.Unless(Condition, Condition.Not())(_TestString);
            Result.ShouldBeFalse();
            L.A(() => Act.Unless(L.Bool.False, L.Bool.False)()).ShouldFail();

            // true works
            var Condition2 = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.Should().BeSameAs(_TestString);
                return false;
                });
            bool Result2 = false;
            var Act2 = new Action(() => { Result2 = true; });

            Act2.Unless(Condition2, Condition2)(_TestString);
            Result2.ShouldBeTrue();

            // Exceptions are not hidden
            Action Act3 = () => { throw new Exception(); };
            Act3.Unless(Condition2, Condition2).ShouldFail(_TestString);
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." + nameof(BooleanExt.Unless) + "(Func<T1>, Func<T2, T3, Boolean>[]) => Func<T2, T3, T1>")]
        public void Unless_Action_Func_3Array_Func_3()
            {
            var Condition = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return true;
                });
            // False works
            bool Result = false;
            var Act = new Action(() =>
                {
                Result = true;
                throw new Exception();
                });

            Act.Unless(Condition, Condition.Not())(_TestString, _TestString);
            Result.ShouldBeFalse();
            Act.Unless(Condition.Not(), Condition.Not()).ShouldFail(_TestString, _TestString);

            // true works
            var Condition2 = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return false;
                });
            bool Result2 = false;
            var Act2 = new Action(() => { Result2 = true; });

            Act2.Unless(Condition2, Condition2)(_TestString, _TestString);
            Result2.ShouldBeTrue();

            // Exceptions are not hidden
            // Exceptions are not hidden
            Action Act3 = () => { throw new Exception(); };
            Act3.Unless(Condition2, Condition2).ShouldFail(_TestString, _TestString);
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." + nameof(BooleanExt.Unless) + "(Func<T1>, Func<T2, T3, T4, Boolean>[]) => Func<T2, T3, T4, T1>")]
        public void Unless_Action_Func_4Array_Func_4()
            {
            var Condition = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return true;
                });
            // False works
            bool Result = false;
            var Act = new Action(() =>
                {
                Result = true;
                throw new Exception();
                });

            Act.Unless(Condition, Condition.Not())(_TestString, _TestString, _TestString);
            Result.ShouldBeFalse();
            Act.Unless(Condition.Not(), Condition.Not()).ShouldFail(_TestString, _TestString, _TestString);

            // true works
            var Condition2 = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return false;
                });
            bool Result2 = false;
            var Act2 = new Action(() => { Result2 = true; });

            Act2.Unless(Condition2, Condition2)(_TestString, _TestString, _TestString);
            Result2.ShouldBeTrue();

            // Exceptions are not hidden
            // Exceptions are not hidden
            Action Act3 = () => { throw new Exception(); };
            Act3.Unless(Condition2, Condition2).ShouldFail(_TestString, _TestString, _TestString);
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." + nameof(BooleanExt.Unless) + "(Func<T1>, Func<T2, T3, T4, T5, Boolean>[]) => Func<T2, T3, T4, T5, T1>")]
        public void Unless_Action_Func_5Array_Func_5()
            {
            var Condition = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return true;
                });
            // False works
            bool Result = false;
            var Act = new Action(() =>
                {
                Result = true;
                throw new Exception();
                });

            Act.Unless(Condition, Condition.Not())(_TestString, _TestString, _TestString, _TestString);
            Result.ShouldBeFalse();
            Act.Unless(Condition.Not(), Condition.Not()).ShouldFail(_TestString, _TestString, _TestString, _TestString);

            // true works
            var Condition2 = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return false;
                });
            bool Result2 = false;
            var Act2 = new Action(() => { Result2 = true; });

            Act2.Unless(Condition2, Condition2)(_TestString, _TestString, _TestString, _TestString);
            Result2.ShouldBeTrue();

            // Exceptions are not hidden
            Action Act3 = () => { throw new Exception(); };
            Act3.Unless(Condition2, Condition2).ShouldFail(_TestString, _TestString, _TestString, _TestString);
            }


        [Fact]
        [Trait(Traits.TargetMember,nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +nameof(BooleanExt.If) + "(Action, Func[]) => Func<Boolean>")]
        public void If_Action_Func_1Array_Func_1()
            {
            // False works - AND is applied
            bool Result = true;
            var Act = new Action(() =>
                {
                Result = false;
                throw new Exception();
                });

            bool Result2 = Act.If(L.Bool.True, L.Bool.True, L.Bool.False)();
            Result.ShouldBeTrue();

            // Result does not pass through
            Result2.ShouldBeFalse();
            Act.If(L.Bool.True, L.Bool.True, L.Bool.True).ShouldFail();

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Action(() => { Result3 = true; });

            bool Result4 = Act2.If(L.Bool.True, L.Bool.True, L.Bool.True)();
            Result3.ShouldBeTrue();

            // Result passes through
            Result4.ShouldBeTrue();

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(L.Bool.True, L.Bool.True, L.Bool.True).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember,nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +nameof(BooleanExt.If) + "(Action, Func[]) => Func<T, Boolean>")]
        public void If_Action_Func_2Array_Func_2()
            {
            var True = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.ShouldBe(_TestString);
                return true;
                });

            var False = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.ShouldBe(_TestString);
                return false;
                });

            // False works - AND is applied
            bool Result = true;
            var Act = new Action(() =>
                {
                Result = false;
                throw new Exception();
                });

            bool Result2 = Act.If(True, True, False)(_TestString);
            Result.ShouldBeTrue();
            Act.If(True, True, True).ShouldFail(_TestString);

            // Result works
            Result2.ShouldBeFalse();

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Action(() => { Result3 = true; });

            bool Result4 = Act2.If(True, True, True)(_TestString);
            Result3.ShouldBeTrue();

            // Result works
            Result4.ShouldBeTrue();

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(True, True, True).ShouldFail(_TestString);
            }

        [Fact]
        [Trait(Traits.TargetMember,nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +nameof(BooleanExt.If) + "(Action, Func[]) => Func<T1, T2, Boolean>")]
        public void If_Action_Func_3Array_Func_3()
            {
            var True = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return true;
                });

            var False = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return false;
                });

            // False works - AND is applied
            bool Result = true;
            var Act = new Action(() =>
                {
                Result = false;
                throw new Exception();
                });

            bool Result2 = Act.If(True, True, False)(_TestString, _TestString);
            Result.ShouldBeTrue();
            Act.If(True, True, True).ShouldFail(_TestString, _TestString);

            // Result works
            Result2.ShouldBeFalse();

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Action(() => { Result3 = true; });

            bool Result4 = Act2.If(True, True, True)(_TestString, _TestString);
            Result3.ShouldBeTrue();

            // Result works
            Result4.ShouldBeTrue();

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(True, True, True).ShouldFail(_TestString, _TestString);
            }

        [Fact]
        [Trait(Traits.TargetMember,nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +nameof(BooleanExt.If) + "(Action, Func[]) => Func<T1, T2, T3, Boolean>")]
        public void If_Action_Func_4Array_Func_4()
            {
            var True = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return true;
                });

            var False = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return false;
                });

            // False works - AND is applied
            bool Result = true;
            var Act = new Action(() =>
                {
                Result = false;
                throw new Exception();
                });

            bool Result2 = Act.If(True, True, False)(_TestString, _TestString, _TestString);
            Result.ShouldBeTrue();
            Act.If(True, True, True).ShouldFail(_TestString, _TestString, _TestString);

            // Result works
            Result2.ShouldBeFalse();

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Action(() => { Result3 = true; });

            bool Result4 = Act2.If(True, True, True)(_TestString, _TestString, _TestString);
            Result3.ShouldBeTrue();

            // Result works
            Result4.ShouldBeTrue();

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(True, True, True).ShouldFail(_TestString, _TestString, _TestString);
            }

        [Fact]
        [Trait(Traits.TargetMember,nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +nameof(BooleanExt.If) + "(Action, Func[]) => Func<T1, T2, T3, T4, Boolean>")]
        public void If_Action_Func_5Array_Func_5()
            {
            var True = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return true;
                });

            var False = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return false;
                });

            // False works - AND is applied
            bool Result = true;
            var Act = new Action(() =>
                {
                Result = false;
                throw new Exception();
                });

            bool Result2 = Act.If(True, True, False)(_TestString, _TestString, _TestString, _TestString);
            Result.ShouldBeTrue();
            Act.If(True, True, True).ShouldFail(_TestString, _TestString, _TestString, _TestString);

            // Result works
            Result2.ShouldBeFalse();

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Action(() => { Result3 = true; });

            bool Result4 = Act2.If(True, True, True)(_TestString, _TestString, _TestString, _TestString);
            Result3.ShouldBeTrue();

            // Result works
            Result4.ShouldBeTrue();

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(True, True, True).ShouldFail(_TestString, _TestString, _TestString, _TestString);
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.If) + "(Func<T>, Func[]) => Func<T>")]
        public void If_Func_1_Func_1Array_Func_1()
            {
            // False works - AND is applied
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.If(L.Bool.True, L.Bool.True, L.Bool.False)();
            Result.ShouldBeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.If(L.Bool.True, L.Bool.True, L.Bool.True)();
            Result2.ShouldBe(_TestString);

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.If(L.Bool.True, L.Bool.True, L.Bool.True)();
            Result3.ShouldBeTrue();

            // Result passes through
            Result4.ShouldBe(_TestString);

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(L.Bool.True, L.Bool.True, L.Bool.True).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.If) + "(Func<T1>, Func[]) => Func<T2, T1>")]
        public void If_Func_1_Func_2Array_Func_2()
            {
            var True = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.ShouldBe(_TestString);
                return true;
                });

            var False = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.ShouldBe(_TestString);
                return false;
                });

            // False works - AND is applied
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.If(True, True, False)(_TestString);
            Result.ShouldBeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.If(True, True, True)(_TestString);
            Result2.ShouldBe(_TestString);

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.If(True, True, True)(_TestString);
            Result3.ShouldBeTrue();

            // Result passes through
            Result4.ShouldBe(_TestString);

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(True, True, True).ShouldFail(_TestString);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.If) + "(Func<T1>, Func[]) => Func<T2, T3, T1>")]
        public void If_Func_1_Func_3Array_Func_3()
            {
            var True = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return true;
                });

            var False = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                return false;
                });

            // False works - AND is applied
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.If(True, True, False)(_TestString, _TestString);
            Result.ShouldBeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.If(True, True, True)(_TestString, _TestString);
            Result2.ShouldBe(_TestString);

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.If(True, True, True)(_TestString, _TestString);
            Result3.ShouldBeTrue();

            // Result passes through
            Result4.ShouldBe(_TestString);

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(True, True, True).ShouldFail(_TestString, _TestString);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.If) + "(Func<T1>, Func[]) => Func<T2, T3, T4, T1>")]
        public void If_Func_1_Func_4Array_Func_4()
            {
            var True = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return true;
                });

            var False = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                return false;
                });

            // False works - AND is applied
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.If(True, True, False)(_TestString, _TestString, _TestString);
            Result.ShouldBeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.If(True, True, True)(_TestString, _TestString, _TestString);
            Result2.ShouldBe(_TestString);

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.If(True, True, True)(_TestString, _TestString, _TestString);
            Result3.ShouldBeTrue();

            // Result passes through
            Result4.ShouldBe(_TestString);

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(True, True, True).ShouldFail(_TestString, _TestString, _TestString);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.If) + "(Func<T1>, Func[]) => Func<T2, T3, T4, T5, T1>")]
        public void If_Func_1_Func_5Array_Func_5()
            {
            var True = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return true;
                });

            var False = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);
                o4.Should().BeSameAs(_TestString);
                return false;
                });

            // False works - AND is applied
            bool Result = true;
            var Act = new Func<string>(() =>
                {
                Result = false;
                return _TestString;
                });

            string Result2 = Act.If(True, True, False)(_TestString, _TestString, _TestString, _TestString);
            Result.ShouldBeTrue();

            // Result does not pass through
            Result2.Should().BeNull();

            Result2 = Act.If(True, True, True)(_TestString, _TestString, _TestString, _TestString);
            Result2.ShouldBe(_TestString);

            // true works - AND is applied
            bool Result3 = false;
            var Act2 = new Func<string>(() =>
                {
                Result3 = true;
                return _TestString;
                });

            string Result4 = Act2.If(True, True, True)(_TestString, _TestString, _TestString, _TestString);
            Result3.ShouldBeTrue();

            // Result passes through
            Result4.ShouldBe(_TestString);

            // Exceptions are not hidden
            Func<string> Act3 = () => { throw new Exception(); };
            Act3.If(True, True, True).ShouldFail(_TestString, _TestString, _TestString, _TestString);
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.ElseIf) + "(Func<Boolean>, Func<Boolean>, Action) => Func<Boolean>")]
        public void ElseIf_Func_1_Func_1_Action_Func_1()
            {
            var False = new Func<bool>(() => false);
            var True = new Func<bool>(() => true);

            bool ActionRun = false;

            var ActionMustNotRun = new Action(() => { throw new Exception(); });
            var ActionMustNotRun2 = new Func<bool>(() => { throw new Exception(); });

            var ActionMustRun = new Action(() => { ActionRun = true; });
            var ActionMustRun2 = new Func<bool>(() =>
                {
                ActionRun = true;
                return false;
                });

            // Action did not run.
            True.ElseIf(ActionMustNotRun2, ActionMustNotRun)();

            False.ElseIf(True, ActionMustNotRun).ShouldFail();
            False.ElseIf(ActionMustNotRun2, True).ShouldFail();

            // Action did run.
            False.ElseIf(True, ActionMustRun)();
            ActionRun.ShouldBeTrue();

            ActionRun = false;

            // Action did run.
            False.ElseIf(ActionMustRun2, L.E)();
            ActionRun.ShouldBeTrue();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.ElseIf) + "(Func<T, Boolean>, Func<T, Boolean>, Action<T>) => Func<T, Boolean>")]
        public void ElseIf_Func_2_Func_2_Action_1_Func_2()
            {
            var False = new Func<object, bool>(o => false);
            var True = new Func<object, bool>(o => true);

            bool ActionRun = false;

            var ActionMustNotRun = new Action<object>(o => { throw new Exception(); });
            var ActionMustNotRun2 = new Func<object, bool>(o => { throw new Exception(); });

            var ActionMustRun = new Action<object>(o =>
                {
                // Variables are passed.
                o.ShouldBe(_TestString);

                ActionRun = true;
                });
            var ActionMustRun2 = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.ShouldBe(_TestString);

                ActionRun = true;
                return false;
                });

            // Action did not run.
            True.ElseIf(ActionMustNotRun2, ActionMustNotRun)(_TestString);

            False.ElseIf(True, ActionMustNotRun).ShouldFail(_TestString);
            False.ElseIf(ActionMustNotRun2, True).ShouldFail(_TestString);

            // Action did run.
            False.ElseIf(True, ActionMustRun)(_TestString);
            ActionRun.ShouldBeTrue();

            ActionRun = false;

            // Action did run.
            False.ElseIf(ActionMustRun2, ActionMustRun)(_TestString);
            ActionRun.ShouldBeTrue();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.ElseIf) +
            "(Func<T1, T2, Boolean>, Func<T1, T2, Boolean>, Action<T1, T2>) => Func<T1, T2, Boolean>")]
        public void ElseIf_Func_3_Func_3_Action_2_Func_3()
            {
            var False = new Func<object, object, bool>((o1, o2) => false);
            var True = new Func<object, object, bool>((o1, o2) => true);

            bool ActionRun = false;

            var ActionMustNotRun = new Action<object, object>((o1, o2) => { throw new Exception(); });
            var ActionMustNotRun2 = new Func<object, object, bool>((o1, o2) => { throw new Exception(); });

            var ActionMustRun = new Action<object, object>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);

                ActionRun = true;
                });
            var ActionMustRun2 = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);

                ActionRun = true;
                return false;
                });

            // Action did not run.
            True.ElseIf(ActionMustNotRun2, ActionMustNotRun)(_TestString, _TestString);

            // Action did run.
            False.ElseIf(True, ActionMustRun)(_TestString, _TestString);
            ActionRun.ShouldBeTrue();

            False.ElseIf(True, ActionMustNotRun).ShouldFail(_TestString, _TestString);
            False.ElseIf(ActionMustNotRun2, True).ShouldFail(_TestString, _TestString);

            ActionRun = false;

            // Action did run.
            False.ElseIf(ActionMustRun2, ActionMustRun)(_TestString, _TestString);
            ActionRun.ShouldBeTrue();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.ElseIf) +
            "(Func<T1, T2, T3, Boolean>, Func<T1, T2, T3, Boolean>, Action<T1, T2, T3>) => Func<T1, T2, T3, Boolean>")]
        public void ElseIf_Func_4_Func_4_Action_3_Func_4()
            {
            var False = new Func<object, object, object, bool>((o1, o2, o3) => false);
            var True = new Func<object, object, object, bool>((o1, o2, o3) => true);

            bool ActionRun = false;

            var ActionMustNotRun = new Action<object, object, object>((o1, o2, o3) => { throw new Exception(); });
            var ActionMustNotRun2 = new Func<object, object, object, bool>((o1, o2, o3) => { throw new Exception(); });

            var ActionMustRun = new Action<object, object, object>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);

                ActionRun = true;
                });
            var ActionMustRun2 = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);

                ActionRun = true;
                return false;
                });

            // Action did not run.
            True.ElseIf(ActionMustNotRun2, ActionMustNotRun)(_TestString, _TestString, _TestString);

            // Action did run.
            False.ElseIf(True, ActionMustRun)(_TestString, _TestString, _TestString);
            ActionRun.ShouldBeTrue();

            False.ElseIf(True, ActionMustNotRun).ShouldFail(_TestString, _TestString, _TestString);
            False.ElseIf(ActionMustNotRun2, True).ShouldFail(_TestString, _TestString, _TestString);

            ActionRun = false;

            // Action did run.
            False.ElseIf(ActionMustRun2, ActionMustRun)(_TestString, _TestString, _TestString);
            ActionRun.ShouldBeTrue();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.ElseIf) +
            "(Func<T1, T2, T3, T4, Boolean>, Func<T1, T2, T3, T4, Boolean>, Action<T1, T2, T3, T4>) => Func<T1, T2, T3, T4, Boolean>")]
        public void ElseIf_Func_5_Func_5_Action_4_Func_5()
            {
            var False = new Func<object, object, object, object, bool>((o1, o2, o3, o4) => false);
            var True = new Func<object, object, object, object, bool>((o1, o2, o3, o4) => true);

            bool ActionRun = false;

            var ActionMustNotRun = new Action<object, object, object, object>((o1, o2, o3, o4) => { throw new Exception(); });
            var ActionMustNotRun2 = new Func<object, object, object, object, bool>((o1, o2, o3, o4) => { throw new Exception(); });

            var ActionMustRun = new Action<object, object, object, object>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);

                ActionRun = true;
                });
            var ActionMustRun2 = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);

                ActionRun = true;
                return false;
                });

            // Action did not run.
            True.ElseIf(ActionMustNotRun2, ActionMustNotRun)(_TestString, _TestString, _TestString, _TestString);

            // Action did run.
            False.ElseIf(True, ActionMustRun)(_TestString, _TestString, _TestString, _TestString);
            ActionRun.ShouldBeTrue();

            False.ElseIf(True, ActionMustNotRun).ShouldFail(_TestString, _TestString, _TestString, _TestString);
            False.ElseIf(ActionMustNotRun2, True).ShouldFail(_TestString, _TestString, _TestString, _TestString);

            ActionRun = false;

            // Action did run.
            False.ElseIf(ActionMustRun2, ActionMustRun)(_TestString, _TestString, _TestString, _TestString);
            ActionRun.ShouldBeTrue();
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.ElseIf) + "(Func<U>, Func<Boolean>, Func<U>) => Func<U>")]
        public void ElseIf_Func_1_Func_1_Func_1_Func_1()
            {
            var False = new Func<bool>(() => false);
            var True = new Func<bool>(() => true);

            bool ActionRun = false;

            var ActionMustNotRun = new Func<bool>(() => { throw new Exception(); });

            var ActionMustRun = new Func<bool>(() =>
                {
                ActionRun = true;
                return false;
                });

            // Action did not run.
            True.ElseIf(ActionMustNotRun, ActionMustNotRun)();

            False.ElseIf(ActionMustNotRun, True).ShouldFail();
            False.ElseIf(True, ActionMustNotRun).ShouldFail();

            // Action did run.
            False.ElseIf(True, ActionMustRun)();
            ActionRun.ShouldBeTrue();

            ActionRun = false;

            // Action did run.
            False.ElseIf(ActionMustRun, L.Bool.True)();
            ActionRun.ShouldBeTrue();

            // Result was passed.
            bool Result = False.ElseIf(True, True)();
            Result.ShouldBeTrue();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.ElseIf) + "(Func<T, U>, Func<T, Boolean>, Func<T, U>) => Func<T, U>")]
        public void ElseIf_Func_2_Func_2_Func_2_Func_2()
            {
            var False = new Func<object, bool>(o => false);
            var True = new Func<object, bool>(o => true);

            bool ActionRun = false;

            var ActionMustNotRun = new Func<object, bool>(o => { throw new Exception(); });

            var ActionMustRun = new Func<object, bool>(o =>
                {
                // Variables are passed.
                o.ShouldBe(_TestString);

                ActionRun = true;
                return false;
                });

            // Action did not run.
            True.ElseIf(ActionMustNotRun, ActionMustNotRun)(_TestString);

            // Action did run.
            False.ElseIf(True, ActionMustRun)(_TestString);
            ActionRun.ShouldBeTrue();

            False.ElseIf(ActionMustNotRun, True).ShouldFail(_TestString);
            False.ElseIf(True, ActionMustNotRun).ShouldFail(_TestString);

            ActionRun = false;

            // Action did run.
            False.ElseIf(ActionMustRun, ActionMustRun)(_TestString);
            ActionRun.ShouldBeTrue();

            // Result was passed.
            bool Result = False.ElseIf(True, True)(_TestString);
            Result.ShouldBeTrue();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.ElseIf) +
            "(Func<T1, T2, U>, Func<T1, T2, Boolean>, Func<T1, T2, U>) => Func<T1, T2, U>")]
        public void ElseIf_Func_3_Func_3_Func_3_Func_3()
            {
            var False = new Func<object, object, bool>((o1, o2) => false);
            var True = new Func<object, object, bool>((o1, o2) => true);

            bool ActionRun = false;

            var ActionMustNotRun = new Func<object, object, bool>((o1, o2) => { throw new Exception(); });

            var ActionMustRun = new Func<object, object, bool>((o1, o2) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);

                ActionRun = true;
                return false;
                });

            // Action did not run.
            True.ElseIf(ActionMustNotRun, ActionMustNotRun)(_TestString, _TestString);

            // Action did run.
            False.ElseIf(True, ActionMustRun)(_TestString, _TestString);
            ActionRun.ShouldBeTrue();

            False.ElseIf(ActionMustNotRun, True).ShouldFail(_TestString, _TestString);
            False.ElseIf(True, ActionMustNotRun).ShouldFail(_TestString, _TestString);

            ActionRun = false;

            // Action did run.
            False.ElseIf(ActionMustRun, ActionMustRun)(_TestString, _TestString);
            ActionRun.ShouldBeTrue();

            // Result was passed.
            bool Result = False.ElseIf(True, True)(_TestString, _TestString);
            Result.ShouldBeTrue();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.ElseIf) +
            "(Func<T1, T2, T3, U>, Func<T1, T2, T3, Boolean>, Func<T1, T2, T3, U>) => Func<T1, T2, T3, U>")]
        public void ElseIf_Func_4_Func_4_Func_4_Func_4()
            {
            var False = new Func<object, object, object, bool>((o1, o2, o3) => false);
            var True = new Func<object, object, object, bool>((o1, o2, o3) => true);

            bool ActionRun = false;

            var ActionMustNotRun = new Func<object, object, object, bool>((o1, o2, o3) => { throw new Exception(); });

            var ActionMustRun = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);

                ActionRun = true;
                return false;
                });

            // Action did not run.
            True.ElseIf(ActionMustNotRun, ActionMustNotRun)(_TestString, _TestString, _TestString);

            // Action did run.
            False.ElseIf(True, ActionMustRun)(_TestString, _TestString, _TestString);
            ActionRun.ShouldBeTrue();

            False.ElseIf(ActionMustNotRun, True).ShouldFail(_TestString, _TestString, _TestString);
            False.ElseIf(True, ActionMustNotRun).ShouldFail(_TestString, _TestString, _TestString);

            ActionRun = false;

            // Action did run.
            False.ElseIf(ActionMustRun, ActionMustRun)(_TestString, _TestString, _TestString);
            ActionRun.ShouldBeTrue();

            // Result was passed.
            bool Result = False.ElseIf(True, True)(_TestString, _TestString, _TestString);
            Result.ShouldBeTrue();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.ElseIf) +
            "(Func<T1, T2, T3, T4, U>, Func<T1, T2, T3, T4, Boolean>, Func<T1, T2, T3, T4, U>) => Func<T1, T2, T3, T4, U>")]
        public void ElseIf_Func_5_Func_5_Func_5_Func_5()
            {
            var False = new Func<object, object, object, object, bool>((o1, o2, o3, o4) => false);
            var True = new Func<object, object, object, object, bool>((o1, o2, o3, o4) => true);

            bool ActionRun = false;

            var ActionMustNotRun = new Func<object, object, object, object, bool>((o1, o2, o3, o4) => { throw new Exception(); });

            var ActionMustRun = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                // Variables are passed.
                o1.Should().BeSameAs(_TestString);
                o2.Should().BeSameAs(_TestString);
                o3.Should().BeSameAs(_TestString);

                ActionRun = true;
                return false;
                });

            // Action did not run.
            True.ElseIf(ActionMustNotRun, ActionMustNotRun)(_TestString, _TestString, _TestString, _TestString);

            // Action did run.
            False.ElseIf(True, ActionMustRun)(_TestString, _TestString, _TestString, _TestString);
            ActionRun.ShouldBeTrue();

            False.ElseIf(ActionMustNotRun, True).ShouldFail(_TestString, _TestString, _TestString, _TestString);
            False.ElseIf(True, ActionMustNotRun).ShouldFail(_TestString, _TestString, _TestString, _TestString);

            ActionRun = false;

            // Action did run.
            False.ElseIf(ActionMustRun, ActionMustRun)(_TestString, _TestString, _TestString, _TestString);
            ActionRun.ShouldBeTrue();

            // Result was passed.
            bool Result = False.ElseIf(True, True)(_TestString, _TestString, _TestString, _TestString);
            Result.ShouldBeTrue();
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.Else) + "(Func<Boolean>, Action) => Action")]
        public void Else_Func_1_Action_Action()
            {
            var True = new Func<bool>(() => true);
            var False = new Func<bool>(() => false);
            var Act = new Action(() => { });
            var DontExecute = new Action(() => { throw new Exception(); });

            Act.If(True).ElseIf(True, DontExecute).Else(DontExecute)();

            DontExecute.If(False).ElseIf(False, DontExecute).Else(Act)();

            L.A(() => Act.If(False).ElseIf(False, DontExecute).Else(DontExecute)()).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.Else) + "(Func<T1, Boolean>, Action<T1>) => Action<T1>")]
        public void Else_Func_2_Action_1_Action_1()
            {
            var True = new Func<object, bool>(o =>
                {
                o.ShouldBe(_TestString);
                return true;
                });
            var False = new Func<object, bool>(o =>
                {
                o.ShouldBe(_TestString);
                return false;
                });
            var Act = new Action<object>(o => { o.ShouldBe(_TestString); });
            var DontExecute = new Action<object>(o =>
                {
                o.ShouldBe(_TestString);
                throw new Exception();
                });

            True.Else(DontExecute)(_TestString);

            False.Else(Act)(_TestString);

            L.A(() => False.Else(DontExecute)(_TestString)).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.Else) + "(Func<T1, T2, Boolean>, Action<T1, T2>) => Action<T1, T2>")]
        public void Else_Func_3_Action_2_Action_2()
            {
            var True = new Func<object, object, bool>((o1, o2) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                return true;
                });
            var False = new Func<object, object, bool>((o1, o2) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                return false;
                });
            var Act = new Action<object, object>((o1, o2) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                });
            var DontExecute = new Action<object, object>((o1, o2) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                throw new Exception();
                });

            True.Else(DontExecute)(_TestString, _TestString);

            False.Else(Act)(_TestString, _TestString);

            L.A(() => False.Else(DontExecute)(_TestString, _TestString)).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.Else) + "(Func<T1, T2, T3, Boolean>, Action<T1, T2, T3>) => Action<T1, T2, T3>")]
        public void Else_Func_4_Action_3_Action_3()
            {
            var True = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                o3.ShouldBe(_TestString);
                return true;
                });
            var False = new Func<object, object, object, bool>((o1, o2, o3) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                o3.ShouldBe(_TestString);
                return false;
                });
            var Act = new Action<object, object, object>((o1, o2, o3) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                o3.ShouldBe(_TestString);
                });
            var DontExecute = new Action<object, object, object>((o1, o2, o3) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                o3.ShouldBe(_TestString);
                throw new Exception();
                });

            True.Else(DontExecute)(_TestString, _TestString, _TestString);

            False.Else(Act)(_TestString, _TestString, _TestString);

            L.A(() => False.Else(DontExecute)(_TestString, _TestString, _TestString)).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.Else) +
            "(Func<T1, T2, T3, T4, Boolean>, Action<T1, T2, T3, T4>) => Action<T1, T2, T3, T4>")]
        public void Else_Func_5_Action_4_Action_4()
            {
            var True = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                o3.ShouldBe(_TestString);
                o4.ShouldBe(_TestString);
                return true;
                });
            var False = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                o3.ShouldBe(_TestString);
                o4.ShouldBe(_TestString);
                return false;
                });
            var Act = new Action<object, object, object, object>((o1, o2, o3, o4) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                o3.ShouldBe(_TestString);
                o4.ShouldBe(_TestString);
                });
            var DontExecute = new Action<object, object, object, object>((o1, o2, o3, o4) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                o3.ShouldBe(_TestString);
                o4.ShouldBe(_TestString);
                throw new Exception();
                });

            True.Else(DontExecute)(_TestString, _TestString, _TestString, _TestString);

            False.Else(Act)(_TestString, _TestString, _TestString, _TestString);

            L.A(() => False.Else(DontExecute)(_TestString, _TestString, _TestString, _TestString)).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.Else) + "(Func<U>, Func<U>) => Func<U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.Else) + "(Func<U>, U) => Func<U>")]
        public void Else_Func_1_Func_1_Func_1()
            {
            var True = new Func<bool>(() => true);
            var False = new Func<bool>(() => false);
            var Act = new Func<int>(() => 5);
            var DontExecute = new Func<int>(() => { throw new Exception(); });
            const int Result = 10;


            Act.If(True).ElseIf(True, DontExecute).Else(Result)().ShouldBe(Expected: 5);
            Act.If(False).ElseIf(False, DontExecute).Else(Result)().ShouldBe(Expected: 10);

            DontExecute.If(False).ElseIf(False, DontExecute).Else(Result)().ShouldBe(Expected: 10);

            L.A(() => Act.If(False).ElseIf(True, DontExecute).Else(Result)()).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.Else) + "(Func<T1, U>, Func<T1, U>) => Func<T1, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.Else) + "(Func<T1, U>, U) => Func<T1, U>")]
        public void Else_Func_2_Func_2_Func_2()
            {
            var True = new Func<object, int>(o =>
                {
                o.ShouldBe(_TestString);
                return 1;
                });
            var False = new Func<object, int>(o =>
                {
                o.ShouldBe(_TestString);
                return default(int);
                });
            var DontExecute = new Func<object, int>(o =>
                {
                o.ShouldBe(_TestString);
                throw new Exception();
                });

            const int Result = 10;

            True.Else(DontExecute)(_TestString).ShouldBe(Expected: 1);
            False.Else(Result)(_TestString).ShouldBe(Expected: 10);

            L.A(() => False.Else(DontExecute)(_TestString)).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.Else) + "(Func<T1, T2, U>, Func<T1, T2, U>) => Func<T1, T2, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.Else) + "(Func<T1, T2, U>, U) => Func<T1, T2, U>")]
        public void Else_Func_3_Func_3_Func_3()
            {
            var True = new Func<object, object, int>((o1, o2) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                return 1;
                });
            var False = new Func<object, object, int>((o1, o2) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                return default(int);
                });
            var DontExecute = new Func<object, object, int>((o1, o2) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                throw new Exception();
                });

            const int Result = 10;

            True.Else(DontExecute)(_TestString, _TestString).ShouldBe(Expected: 1);
            False.Else(Result)(_TestString, _TestString).ShouldBe(Expected: 10);

            L.A(() => False.Else(DontExecute)(_TestString, _TestString)).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.Else) + "(Func<T1, T2, T3, U>, Func<T1, T2, T3, U>) => Func<T1, T2, T3, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.Else) + "(Func<T1, T2, T3, U>, U) => Func<T1, T2, T3, U>")]
        public void Else_Func_4_Func_4_Func_4()
            {
            var True = new Func<object, object, object, int>((o1, o2, o3) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                o3.ShouldBe(_TestString);
                return 1;
                });
            var False = new Func<object, object, object, int>((o1, o2, o3) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                o3.ShouldBe(_TestString);
                return default(int);
                });
            var DontExecute = new Func<object, object, object, int>((o1, o2, o3) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                o3.ShouldBe(_TestString);
                throw new Exception();
                });

            const int Result = 10;

            True.Else(DontExecute)(_TestString, _TestString, _TestString).ShouldBe(Expected: 1);
            False.Else(Result)(_TestString, _TestString, _TestString).ShouldBe(Expected: 10);

            L.A(() => False.Else(DontExecute)(_TestString, _TestString, _TestString)).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.Else) +
            "(Func<T1, T2, T3, T4, U>, Func<T1, T2, T3, T4, U>) => Func<T1, T2, T3, T4, U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." +
            nameof(BooleanExt.Else) + "(Func<T1, T2, T3, T4, U>, U) => Func<T1, T2, T3, T4, U>")]
        public void Else_Func_5_Func_5_Func_5()
            {
            var True = new Func<object, object, object, object, int>((o1, o2, o3, o4) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                o3.ShouldBe(_TestString);
                return 1;
                });
            var False = new Func<object, object, object, object, int>((o1, o2, o3, o4) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                o3.ShouldBe(_TestString);
                return default(int);
                });
            var DontExecute = new Func<object, object, object, object, int>((o1, o2, o3, o4) =>
                {
                o1.ShouldBe(_TestString);
                o2.ShouldBe(_TestString);
                o3.ShouldBe(_TestString);
                throw new Exception();
                });

            const int Result = 10;

            True.Else(DontExecute)(_TestString, _TestString, _TestString, _TestString).ShouldBe(Expected: 1);
            False.Else(Result)(_TestString, _TestString, _TestString, _TestString).ShouldBe(Expected: 10);

            L.A(() => False.Else(DontExecute)(_TestString, _TestString, _TestString, _TestString)).ShouldFail();
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." + nameof(BooleanExt.And) + "(IEnumerable<Func<Boolean>>) => Func<Boolean>")]
        public void And_IEnumerable_Func_Boolean_Func_Boolean()
            {
            var True = new Func<bool>(() => true);
            var False = new Func<bool>(() => false);
            var Fail = new Func<bool>(() => { throw new Exception(); });


            new[] {True, True, True, True}.And()().ShouldBeTrue();
            new[] {True, True, True, null}.And()().ShouldBeFalse();
            new[] {True, True, True, False}.And()().ShouldBeFalse();

            ((Func<bool>[]) null).And()().ShouldBeFalse();
            L.A(() => new[] {True, Fail, True, True}.And()()).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." + nameof(BooleanExt.And) + "(IEnumerable<Func<T1, Boolean>>) => Func<T1, Boolean>")]
        public void And_IEnumerable_Func_T1_Boolean_Func_T1_Boolean()
            {
            var True = new Func<string, bool>(o =>
                {
                o.ShouldBe("abc");
                return true;
                });
            var False = new Func<string, bool>(o =>
                {
                o.ShouldBe("abc");
                return false;
                });
            var Fail = new Func<string, bool>(o =>
                {
                o.ShouldBe("abc");
                throw new Exception();
                });


            new[] {True, True, True, True}.And()("abc").ShouldBeTrue();
            new[] {True, True, True, null}.And()("abc").ShouldBeFalse();
            new[] {True, True, True, False}.And()("abc").ShouldBeFalse();

            ((Func<string, bool>[]) null).And()("abc").ShouldBeFalse();

            L.A(() => new[] {True, Fail, True, True}.And()("abc")).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." + nameof(BooleanExt.And) + "(IEnumerable<Func<T1, T2, Boolean>>) => Func<T1, T2, Boolean>")]
        public void And_IEnumerable_Func_T1_T2_Boolean_Func_T1_T2_Boolean()
            {
            var True = new Func<string, string, bool>((o1, o2) =>
                {
                o1.ShouldBe("abc");
                o2.ShouldBe("abc");
                return true;
                });
            var False = new Func<string, string, bool>((o1, o2) =>
                {
                o1.ShouldBe("abc");
                o2.ShouldBe("abc");
                return false;
                });
            var Fail = new Func<string, string, bool>((o1, o2) =>
                {
                o1.ShouldBe("abc");
                o2.ShouldBe("abc");
                throw new Exception();
                });


            new[] {True, True, True, True}.And()("abc", "abc").ShouldBeTrue();
            new[] {True, True, True, null}.And()("abc", "abc").ShouldBeFalse();
            new[] {True, True, True, False}.And()("abc", "abc").ShouldBeFalse();

            ((Func<string, string, bool>[]) null).And()("abc", "abc").ShouldBeFalse();

            L.A(() => new[] {True, Fail, True, True}.And()("abc", "abc")).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." + nameof(BooleanExt.And) + "(IEnumerable<Func<T1, T2, T3, Boolean>>) => Func<T1, T2, T3, Boolean>")]
        public void And_IEnumerable_Func_T1_T2_T3_Boolean_Func_T1_T2_T3_Boolean()
            {
            var True = new Func<string, string, string, bool>((o1, o2, o3) =>
                {
                o1.ShouldBe("abc");
                o2.ShouldBe("abc");
                o3.ShouldBe("abc");
                return true;
                });
            var False = new Func<string, string, string, bool>((o1, o2, o3) =>
                {
                o1.ShouldBe("abc");
                o2.ShouldBe("abc");
                o3.ShouldBe("abc");
                return false;
                });
            var Fail = new Func<string, string, string, bool>((o1, o2, o3) =>
                {
                o1.ShouldBe("abc");
                o2.ShouldBe("abc");
                o3.ShouldBe("abc");
                throw new Exception();
                });


            new[] {True, True, True, True}.And()("abc", "abc", "abc").ShouldBeTrue();
            new[] {True, True, True, null}.And()("abc", "abc", "abc").ShouldBeFalse();
            new[] {True, True, True, False}.And()("abc", "abc", "abc").ShouldBeFalse();

            ((Func<string, string, string, bool>[]) null).And()("abc", "abc", "abc").ShouldBeFalse();

            L.A(() => new[] {True, Fail, True, True}.And()("abc", "abc", "abc")).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(BooleanExt) + "." + nameof(BooleanExt.And) + "(IEnumerable<Func<T1, T2, T3, T4, Boolean>>) => Func<T1, T2, T3, T4, Boolean>")]
        public void And_IEnumerable_Func_T1_T2_T3_T4_Boolean_Func_T1_T2_T3_T4_Boolean()
            {
            var True = new Func<string, string, string, string, bool>((o1, o2, o3, o4) =>
                {
                o1.ShouldBe("abc");
                o2.ShouldBe("abc");
                o3.ShouldBe("abc");
                o4.ShouldBe("abc");
                return true;
                });
            var False = new Func<string, string, string, string, bool>((o1, o2, o3, o4) =>
                {
                o1.ShouldBe("abc");
                o2.ShouldBe("abc");
                o3.ShouldBe("abc");
                o4.ShouldBe("abc");
                return false;
                });
            var Fail = new Func<string, string, string, string, bool>((o1, o2, o3, o4) =>
                {
                o1.ShouldBe("abc");
                o2.ShouldBe("abc");
                o3.ShouldBe("abc");
                o4.ShouldBe("abc");
                throw new Exception();
                });


            new[] {True, True, True, True}.And()("abc", "abc", "abc", "abc").ShouldBeTrue();
            new[] {True, True, True, null}.And()("abc", "abc", "abc", "abc").ShouldBeFalse();
            new[] {True, True, True, False}.And()("abc", "abc", "abc", "abc").ShouldBeFalse();

            ((Func<string, string, string, string, bool>[]) null).And()("abc", "abc", "abc", "abc").ShouldBeFalse();

            L.A(() => new[] {True, Fail, True, True}.And()("abc", "abc", "abc", "abc")).ShouldFail();
            }
        }
    }