using System;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using Xunit;
using Xunit.Abstractions;

namespace LUnit_Tests.LCore.LUnit.Fluent
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt))]
    public partial class FluentExtTester : XUnitOutputTester, IDisposable
        {
        #region Test Variables

        private readonly Action _TestFail = () => { throw new ArgumentException(); };

        private readonly Action<object> _TestFail2 = o =>
            {
            o.ShouldBe("abc");
            throw new ArgumentException();
            };

        private readonly Action<object, object> _TestFail3 = (o1, o2) =>
            {
            o1.ShouldBe("abc");
            o2.ShouldBe("abc");
            throw new ArgumentException();
            };

        private readonly Action<object, object, object> _TestFail4 = (o1, o2, o3) =>
            {
            o1.ShouldBe("abc");
            o2.ShouldBe("abc");
            o3.ShouldBe("abc");
            throw new ArgumentException();
            };

        private readonly Action<object, object, object, object> _TestFail5 = (o1, o2, o3, o4) =>
            {
            o1.ShouldBe("abc");
            o2.ShouldBe("abc");
            o3.ShouldBe("abc");
            o4.ShouldBe("abc");
            throw new ArgumentException();
            };

        private readonly Func<string> _TestFailFunc = () => { throw new ArgumentException(); };

        private readonly Func<object, string> _TestFailFunc2 = o =>
            {
            o.ShouldBe("abc");
            throw new ArgumentException();
            };

        private readonly Func<object, object, string> _TestFailFunc3 = (o1, o2) =>
            {
            o1.ShouldBe("abc");
            o2.ShouldBe("abc");
            throw new ArgumentException();
            };

        private readonly Func<object, object, object, string> _TestFailFunc4 = (o1, o2, o3) =>
            {
            o1.ShouldBe("abc");
            o2.ShouldBe("abc");
            o3.ShouldBe("abc");
            throw new ArgumentException();
            };

        private readonly Func<object, object, object, object, string> _TestFailFunc5 = (o1, o2, o3, o4) =>
            {
            o1.ShouldBe("abc");
            o2.ShouldBe("abc");
            o3.ShouldBe("abc");
            o4.ShouldBe("abc");
            throw new ArgumentException();
            };

        private readonly Action _Test = () => { };
        private readonly Action<object> _Test2 = o => { o.ShouldBe("abc"); };

        private readonly Action<object, object> _Test3 = (o1, o2) =>
            {
            o1.ShouldBe("abc");
            o2.ShouldBe("abc");
            };

        private readonly Action<object, object, object> _Test4 = (o1, o2, o3) =>
            {
            o1.ShouldBe("abc");
            o2.ShouldBe("abc");
            o3.ShouldBe("abc");
            };

        private readonly Action<object, object, object, object> _Test5 = (o1, o2, o3, o4) =>
            {
            o1.ShouldBe("abc");
            o2.ShouldBe("abc");
            o3.ShouldBe("abc");
            o4.ShouldBe("abc");
            };

        private readonly Func<string> _TestFunc = () => "abc";

        private readonly Func<object, string> _TestFunc2 = o =>
            {
            o.ShouldBe("abc");
            return "abc";
            };

        private readonly Func<object, object, string> _TestFunc3 = (o1, o2) =>
            {
            o1.ShouldBe("abc");
            o2.ShouldBe("abc");
            return "abc";
            };

        private readonly Func<object, object, object, string> _TestFunc4 = (o1, o2, o3) =>
            {
            o1.ShouldBe("abc");
            o2.ShouldBe("abc");
            o3.ShouldBe("abc");
            return "abc";
            };

        private readonly Func<object, object, object, object, string> _TestFunc5 = (o1, o2, o3, o4) =>
            {
            o1.ShouldBe("abc");
            o2.ShouldBe("abc");
            o3.ShouldBe("abc");
            o4.ShouldBe("abc");
            return "abc";
            };

        #endregion

        public FluentExtTester(ITestOutputHelper Output) : base(Output) {}

        public void Dispose() {}

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldSucceed) + "(MethodInfo, Object, Object[])")]
        public void ShouldSucceed_MethodInfo_Object_Object()
            {
            var Target = new Helper();

            L.Ref.Method<Helper>(o => o.Test()).ShouldSucceed(Target, new object[] {});
            L.Ref.Method<Helper>(o => o.Test("")).ShouldSucceed(Target, new object[] {""});
            L.Ref.Method<Helper>(o => o.Test("", "")).ShouldSucceed(Target, new object[] {"", ""});
            L.Ref.Method<Helper>(o => o.Test("", "", "")).ShouldSucceed(Target, new object[] {"", "", ""});
            L.Ref.Method<Helper>(o => o.Test("", "", "", "")).ShouldSucceed(Target, new object[] {"", "", "", ""});

            L.Ref.Method<Helper>(o => o.Test()).ShouldSucceed(Target, new object[] {}, o => true);
            L.Ref.Method<Helper>(o => o.Test("")).ShouldSucceed(Target, new object[] {""}, o => true);
            L.Ref.Method<Helper>(o => o.Test("", "")).ShouldSucceed(Target, new object[] {"", ""}, o => true);
            L.Ref.Method<Helper>(o => o.Test("", "", "")).ShouldSucceed(Target, new object[] {"", "", ""}, o => true);
            L.Ref.Method<Helper>(o => o.Test("", "", "", "")).ShouldSucceed(Target, new object[] {"", "", "", ""}, o => true);

            L.Ref.Method<Helper>(o => o.Test()).ShouldSucceed(Target, new object[] {}, () => true);
            L.Ref.Method<Helper>(o => o.Test("")).ShouldSucceed(Target, new object[] {""}, () => true);
            L.Ref.Method<Helper>(o => o.Test("", "")).ShouldSucceed(Target, new object[] {"", ""}, () => true);
            L.Ref.Method<Helper>(o => o.Test("", "", "")).ShouldSucceed(Target, new object[] {"", "", ""}, () => true);
            L.Ref.Method<Helper>(o => o.Test("", "", "", "")).ShouldSucceed(Target, new object[] {"", "", "", ""}, () => true);
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldSucceed) + "(Action)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldSucceed) + "(Action`1<T1>, T1)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldSucceed) + "(Action`2<T1, T2>, T1, T2)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldSucceed) + "(Action`3<T1, T2, T3>, T1, T2, T3)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldSucceed) + "(Action`4<T1, T2, T3, T4>, T1, T2, T3, T4)")]
        public void ShouldSucceed_Action()
            {
            this._Test.ShouldSucceed();
            this._Test2.ShouldSucceed("abc");
            this._Test3.ShouldSucceed("abc", "abc");
            this._Test4.ShouldSucceed("abc", "abc", "abc");
            this._Test5.ShouldSucceed("abc", "abc", "abc", "abc");

            L.A(() => this._TestFail.ShouldSucceed()).ShouldFail();
            L.A(() => this._TestFail2.ShouldSucceed("abc")).ShouldFail();
            L.A(() => this._TestFail3.ShouldSucceed("abc", "abc")).ShouldFail();
            L.A(() => this._TestFail4.ShouldSucceed("abc", "abc", "abc")).ShouldFail();
            L.A(() => this._TestFail5.ShouldSucceed("abc", "abc", "abc", "abc")).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldSucceed) + "(Func`1<U>)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldSucceed) + "(Func`2<T1, U>, T1)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldSucceed) + "(Func`3<T1, T2, U>, T1, T2)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldSucceed) + "(Func`4<T1, T2, T3, U>, T1, T2, T3)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldSucceed) + "(Func`5<T1, T2, T3, T4, U>, T1, T2, T3, T4)")]
        public void ShouldSucceed_Func()
            {
            this._TestFunc.ShouldSucceed();
            this._TestFunc2.ShouldSucceed<string, string>("abc");
            this._TestFunc3.ShouldSucceed<string, string, string>("abc", "abc");
            this._TestFunc4.ShouldSucceed<string, string, string, string>("abc", "abc", "abc");
            this._TestFunc5.ShouldSucceed<string, string, string, string, string>("abc", "abc", "abc", "abc");

            L.A(() => this._TestFailFunc.ShouldSucceed()).ShouldFail();
            L.A(() => this._TestFailFunc2.ShouldSucceed<string, string>("abc")).ShouldFail();
            L.A(() => this._TestFailFunc3.ShouldSucceed<string, string, string>("abc", "abc")).ShouldFail();
            L.A(() => this._TestFailFunc4.ShouldSucceed<string, string, string, string>("abc", "abc", "abc")).ShouldFail();
            L.A(() => this._TestFailFunc5.ShouldSucceed<string, string, string, string, string>("abc", "abc", "abc", "abc")).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldFail) + "(Action)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldFail) + "(Action`1<T1>, T1)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldFail) + "(Action`2<T1, T2>, T1, T2)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldFail) + "(Action`3<T1, T2, T3>, T1, T2, T3)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldFail) + "(Action`4<T1, T2, T3, T4>, T1, T2, T3, T4)")]
        public void ShouldFail_Action()
            {
            this._TestFail.ShouldFail();
            this._TestFail.ShouldFail<Exception>();
            this._TestFail.ShouldFail<ArgumentException>();
            L.A(() => this._TestFail.ShouldFail<InvalidOperationException>()).ShouldFail();

            this._TestFail2.ShouldFail("abc");
            this._TestFail2.ShouldFail<object, Exception>("abc");
            this._TestFail2.ShouldFail<object, ArgumentException>("abc");
            L.A(() => this._TestFail2.ShouldFail<object, InvalidOperationException>("abc")).ShouldFail();

            this._TestFail3.ShouldFail("abc", "abc");
            this._TestFail3.ShouldFail<object, object, Exception>("abc", "abc");
            this._TestFail3.ShouldFail<object, object, ArgumentException>("abc", "abc");
            L.A(() => this._TestFail3.ShouldFail<object, object, InvalidOperationException>("abc", "abc")).ShouldFail();

            this._TestFail4.ShouldFail("abc", "abc", "abc");
            this._TestFail4.ShouldFail<object, object, object, Exception>("abc", "abc", "abc");
            this._TestFail4.ShouldFail<object, object, object, ArgumentException>("abc", "abc", "abc");
            L.A(() => this._TestFail4.ShouldFail<object, object, object, InvalidOperationException>("abc", "abc", "abc"))
                .ShouldFail();

            this._TestFail5.ShouldFail("abc", "abc", "abc", "abc");
            this._TestFail5.ShouldFail<object, object, object, object, Exception>("abc", "abc", "abc", "abc");
            this._TestFail5.ShouldFail<object, object, object, object, ArgumentException>("abc", "abc", "abc", "abc");
            L.A(() => this._TestFail5.ShouldFail<object, object, object, object, InvalidOperationException>("abc", "abc", "abc",
                "abc")).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldFail) + "(Func`1<U>)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldFail) + "(Func`2<T1, U>, T1)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldFail) + "(Func`3<T1, T2, U>, T1, T2)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldFail) + "(Func`4<T1, T2, T3, U>, T1, T2, T3)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldFail) + "(Func`5<T1, T2, T3, T4, U>, T1, T2, T3, T4)")]
        public void ShouldFail_Func()
            {
            this._TestFailFunc.ShouldFail();
            this._TestFailFunc2.ShouldFail("abc");
            this._TestFailFunc3.ShouldFail("abc", "abc");
            this._TestFailFunc4.ShouldFail("abc", "abc", "abc");
            this._TestFailFunc5.ShouldFail("abc", "abc", "abc", "abc");

            this._TestFailFunc.ShouldFail<string, Exception>();
            this._TestFailFunc2.ShouldFail<object, string, Exception>("abc");
            this._TestFailFunc3.ShouldFail<object, object, string, Exception>("abc", "abc");
            this._TestFailFunc4.ShouldFail<object, object, object, string, Exception>("abc", "abc", "abc");
            this._TestFailFunc5.ShouldFail<object, object, object, object, string, Exception>("abc", "abc", "abc", "abc");

            this._TestFailFunc.ShouldFail<string, ArgumentException>();
            this._TestFailFunc2.ShouldFail<object, string, ArgumentException>("abc");
            this._TestFailFunc3.ShouldFail<object, object, string, ArgumentException>("abc", "abc");
            this._TestFailFunc4.ShouldFail<object, object, object, string, ArgumentException>("abc", "abc", "abc");
            this._TestFailFunc5.ShouldFail<object, object, object, object, string, ArgumentException>("abc", "abc", "abc", "abc");

            L.A(() => this._TestFailFunc.ShouldFail<string, InvalidOperationException>()).ShouldFail();
            L.A(() => this._TestFailFunc2.ShouldFail<object, string, InvalidOperationException>("abc")).ShouldFail();
            L.A(() => this._TestFailFunc3.ShouldFail<object, object, string, InvalidOperationException>("abc", "abc")).ShouldFail();
            L.A(() => this._TestFailFunc4.ShouldFail<object, object, object, string, InvalidOperationException>("abc", "abc", "abc"))
                .ShouldFail();
            L.A(() => this._TestFailFunc5.ShouldFail<object, object, object, object, string, InvalidOperationException>("abc", "abc", "abc",
                "abc")).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldBe) + "(MethodInfo, Object, Object[], Object, Func`2[])")]
        public void ShouldBe_MethodInfo_Object_Object_Object_Func_2()
            {
            var Target = new Helper();

            L.Ref.Method<Helper>(o => o.Test()).ShouldBe(Target, new object[] {}, ExpectedResult: 5);
            L.Ref.Method<Helper>(o => o.Test("")).ShouldBe(Target, new object[] {""}, ExpectedResult: 5);
            L.Ref.Method<Helper>(o => o.Test("", "")).ShouldBe(Target, new object[] {"", ""}, ExpectedResult: 5);
            L.Ref.Method<Helper>(o => o.Test("", "", "")).ShouldBe(Target, new object[] {"", "", ""}, ExpectedResult: 5);
            L.Ref.Method<Helper>(o => o.Test("", "", "", "")).ShouldBe(Target, new object[] {"", "", "", ""}, ExpectedResult: 5);
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldBe) + "(Func`1<U>, U)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldBe) + "(Func`2<T1, U>, T1, U)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldBe) + "(Func`3<T1, T2, U>, T1, T2, U)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldBe) + "(Func`4<T1, T2, T3, U>, T1, T2, T3, U)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Fluent) + "." + nameof(FluentExt) + "." + nameof(FluentExt.ShouldBe) + "(Func`5<T1, T2, T3, T4, U>, T1, T2, T3, T4, U)")]
        public void ShouldBe_Func_1_U_U()
            {
            this._TestFunc.ShouldBe("abc");
            this._TestFunc2.ShouldBe("abc", "abc");
            this._TestFunc3.ShouldBe("abc", "abc", "abc");
            this._TestFunc4.ShouldBe("abc", "abc", "abc", "abc");
            this._TestFunc5.ShouldBe("abc", "abc", "abc", "abc", "abc");

            L.A(() => this._TestFunc.ShouldBe("abcd")).ShouldFail();
            L.A(() => this._TestFunc2.ShouldBe("abc", "abcd")).ShouldFail();
            L.A(() => this._TestFunc3.ShouldBe("abc", "abc", "abcd")).ShouldFail();
            L.A(() => this._TestFunc4.ShouldBe("abc", "abc", "abc", "abcd")).ShouldFail();
            L.A(() => this._TestFunc5.ShouldBe("abc", "abc", "abc", "abc", "abcd")).ShouldFail();
            }

        #region Helpers

        internal class Helper
            {
            public int Test()
                {
                return 5;
                }

            public int Test(string Str)
                {
                return 5;
                }

            public int Test(string Str, string Str2)
                {
                return 5;
                }

            public int Test(string Str, string Str2, string Str3)
                {
                return 5;
                }

            public int Test(string Str, string Str2, string Str3, string Str4)
                {
                return 5;
                }
            }

        #endregion
        }
    }