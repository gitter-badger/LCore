using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Assert;
using LCore.LUnit.Fluent;
using LCore.LUnit.Tests.Extensions;
using LCore.Naming;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable ArgumentsStyleLiteral

namespace LUnit_Tests.LCore.LUnit.Assert
    {
    public partial class AssertionExtTester : XUnitOutputTester, IDisposable
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

        public AssertionExtTester(ITestOutputHelper Output) : base(Output) {}

        public void Dispose() {}

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertSucceedes) + "(MethodInfo, Object, Object[])")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertSucceedes) + "(MethodInfo, Object, Object[], Func[])")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertSucceedes) + "(MethodInfo, Object, Object[], Func[])")]
        public void AssertSucceedes_MethodInfo_Object_Object()
            {
            var Target = new Helper();

            L.Ref.Method<Helper>(o => o.Test()).AssertSucceedes(Target, new object[] {});
            L.Ref.Method<Helper>(o => o.Test("")).AssertSucceedes(Target, new object[] {""});
            L.Ref.Method<Helper>(o => o.Test("", "")).AssertSucceedes(Target, new object[] {"", ""});
            L.Ref.Method<Helper>(o => o.Test("", "", "")).AssertSucceedes(Target, new object[] {"", "", ""});
            L.Ref.Method<Helper>(o => o.Test("", "", "", "")).AssertSucceedes(Target, new object[] {"", "", "", ""});

            L.Ref.Method<Helper>(o => o.Test()).AssertSucceedes(Target, new object[] {}, o => true);
            L.Ref.Method<Helper>(o => o.Test("")).AssertSucceedes(Target, new object[] {""}, o => true);
            L.Ref.Method<Helper>(o => o.Test("", "")).AssertSucceedes(Target, new object[] {"", ""}, o => true);
            L.Ref.Method<Helper>(o => o.Test("", "", "")).AssertSucceedes(Target, new object[] {"", "", ""}, o => true);
            L.Ref.Method<Helper>(o => o.Test("", "", "", "")).AssertSucceedes(Target, new object[] {"", "", "", ""}, o => true);

            L.Ref.Method<Helper>(o => o.Test()).AssertSucceedes(Target, new object[] {}, () => true);
            L.Ref.Method<Helper>(o => o.Test("")).AssertSucceedes(Target, new object[] {""}, () => true);
            L.Ref.Method<Helper>(o => o.Test("", "")).AssertSucceedes(Target, new object[] {"", ""}, () => true);
            L.Ref.Method<Helper>(o => o.Test("", "", "")).AssertSucceedes(Target, new object[] {"", "", ""}, () => true);
            L.Ref.Method<Helper>(o => o.Test("", "", "", "")).AssertSucceedes(Target, new object[] {"", "", "", ""}, () => true);
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertSucceedes) + "(Action)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertSucceedes) + "(Action<T1>, T1)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertSucceedes) + "(Action<T1, T2>, T1, T2)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertSucceedes) + "(Action<T1, T2, T3>, T1, T2, T3)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertSucceedes) + "(Action<T1, T2, T3, T4>, T1, T2, T3, T4)")]
        public void AssertSucceedes_Action()
            {
            this._Test.AssertSucceedes();
            this._Test2.AssertSucceedes("abc");
            this._Test3.AssertSucceedes("abc", "abc");
            this._Test4.AssertSucceedes("abc", "abc", "abc");
            this._Test5.AssertSucceedes("abc", "abc", "abc", "abc");

            L.A(() => this._TestFail.AssertSucceedes()).ShouldFail();
            L.A(() => this._TestFail2.AssertSucceedes("abc")).ShouldFail();
            L.A(() => this._TestFail3.AssertSucceedes("abc", "abc")).ShouldFail();
            L.A(() => this._TestFail4.AssertSucceedes("abc", "abc", "abc")).ShouldFail();
            L.A(() => this._TestFail5.AssertSucceedes("abc", "abc", "abc", "abc")).ShouldFail();
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertSucceedes) + "(Func<U>)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertSucceedes) + "(Func<T1, U>, T1)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertSucceedes) + "(Func<T1, T2, U>, T1, T2)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertSucceedes) + "(Func<T1, T2, T3, U>, T1, T2, T3)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertSucceedes) + "(Func<T1, T2, T3, T4, U>, T1, T2, T3, T4)")]
        public void AssertSucceedes_Func_1_U()
            {
            this._TestFunc.AssertSucceedes();
            this._TestFunc2.AssertSucceedes<string, string>("abc");
            this._TestFunc3.AssertSucceedes<string, string, string>("abc", "abc");
            this._TestFunc4.AssertSucceedes<string, string, string, string>("abc", "abc", "abc");
            this._TestFunc5.AssertSucceedes<string, string, string, string, string>("abc", "abc", "abc", "abc");

            L.A(() => this._TestFailFunc.AssertSucceedes()).ShouldFail();
            L.A(() => this._TestFailFunc2.AssertSucceedes<string, string>("abc")).ShouldFail();
            L.A(() => this._TestFailFunc3.AssertSucceedes<string, string, string>("abc", "abc")).ShouldFail();
            L.A(() => this._TestFailFunc4.AssertSucceedes<string, string, string, string>("abc", "abc", "abc")).ShouldFail();
            L.A(() => this._TestFailFunc5.AssertSucceedes<string, string, string, string, string>("abc", "abc", "abc", "abc")).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertFails) + "(Action)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertFails) + "(Action<T1>, T1)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertFails) + "(Action<T1, T2>, T1, T2)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertFails) + "(Action<T1, T2, T3>, T1, T2, T3)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertFails) + "(Action<T1, T2, T3, T4>, T1, T2, T3, T4)")]
        public void AssertFails_Action()
            {
            this._TestFail.AssertFails();
            this._TestFail2.AssertFails("abc");
            this._TestFail3.AssertFails("abc", "abc");
            this._TestFail4.AssertFails("abc", "abc", "abc");
            this._TestFail5.AssertFails("abc", "abc", "abc", "abc");


            this._TestFail.AssertFails<Exception>();
            this._TestFail2.AssertFails<object, Exception>("abc");
            this._TestFail3.AssertFails<object, object, Exception>("abc", "abc");
            this._TestFail4.AssertFails<object, object, object, Exception>("abc", "abc", "abc");
            this._TestFail5.AssertFails<object, object, object, object, Exception>("abc", "abc", "abc", "abc");

            this._TestFail.AssertFails<ArgumentException>();
            this._TestFail2.AssertFails<object, ArgumentException>("abc");
            this._TestFail3.AssertFails<object, object, ArgumentException>("abc", "abc");
            this._TestFail4.AssertFails<object, object, object, ArgumentException>("abc", "abc", "abc");
            this._TestFail5.AssertFails<object, object, object, object, ArgumentException>("abc", "abc", "abc", "abc");

            L.A(() => this._TestFail.AssertFails<InvalidOperationException>()).AssertFails();
            L.A(() => this._TestFail2.AssertFails<object, InvalidOperationException>("abc")).AssertFails();
            L.A(() => this._TestFail3.AssertFails<object, object, InvalidOperationException>("abc", "abc")).AssertFails();
            L.A(() => this._TestFail4.AssertFails<object, object, object, InvalidOperationException>("abc", "abc", "abc"))
                .AssertFails();
            L.A(() => this._TestFail5.AssertFails<object, object, object, object, InvalidOperationException>("abc", "abc", "abc",
                "abc")).AssertFails();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertFails) + "(Func<U>)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertFails) + "(Func<T1, U>, T1)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertFails) + "(Func<T1, T2, U>, T1, T2)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertFails) + "(Func<T1, T2, T3, U>, T1, T2, T3)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertFails) + "(Func<T1, T2, T3, T4, U>, T1, T2, T3, T4)")]
        public void AssertFails_Func_1_U()
            {
            this._TestFailFunc.AssertFails();
            this._TestFailFunc2.AssertFails("abc");
            this._TestFailFunc3.AssertFails("abc", "abc");
            this._TestFailFunc4.AssertFails("abc", "abc", "abc");
            this._TestFailFunc5.AssertFails("abc", "abc", "abc", "abc");

            this._TestFailFunc.AssertFails<string, Exception>();
            this._TestFailFunc2.AssertFails<object, string, Exception>("abc");
            this._TestFailFunc3.AssertFails<object, object, string, Exception>("abc", "abc");
            this._TestFailFunc4.AssertFails<object, object, object, string, Exception>("abc", "abc", "abc");
            this._TestFailFunc5.AssertFails<object, object, object, object, string, Exception>("abc", "abc", "abc", "abc");

            this._TestFailFunc.AssertFails<string, ArgumentException>();
            this._TestFailFunc2.AssertFails<object, string, ArgumentException>("abc");
            this._TestFailFunc3.AssertFails<object, object, string, ArgumentException>("abc", "abc");
            this._TestFailFunc4.AssertFails<object, object, object, string, ArgumentException>("abc", "abc", "abc");
            this._TestFailFunc5.AssertFails<object, object, object, object, string, ArgumentException>("abc", "abc", "abc", "abc");

            L.A(() => this._TestFailFunc.AssertFails<string, InvalidOperationException>()).AssertFails();
            L.A(() => this._TestFailFunc2.AssertFails<object, string, InvalidOperationException>("abc")).AssertFails();
            L.A(() => this._TestFailFunc3.AssertFails<object, object, string, InvalidOperationException>("abc", "abc")).AssertFails();
            L.A(() => this._TestFailFunc4.AssertFails<object, object, object, string, InvalidOperationException>("abc", "abc", "abc"))
                .AssertFails();
            L.A(() => this._TestFailFunc5.AssertFails<object, object, object, object, string, InvalidOperationException>("abc", "abc",
                "abc", "abc")).AssertFails();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertResult) + "(MethodInfo, Object, Object[], Object, Func[])")]
        public void AssertResult_MethodInfo_Object_Object_Object_Func_2()
            {
            var Target = new TestExtTest.Helper();

            L.Ref.Method<TestExtTest.Helper>(o => o.Test()).AssertResult(Target, new object[] {}, ExpectedResult: 5);
            L.Ref.Method<TestExtTest.Helper>(o => o.Test("")).AssertResult(Target, new object[] {""}, ExpectedResult: 5);
            L.Ref.Method<TestExtTest.Helper>(o => o.Test("", "")).AssertResult(Target, new object[] {"", ""}, ExpectedResult: 5);
            L.Ref.Method<TestExtTest.Helper>(o => o.Test("", "", "")).AssertResult(Target, new object[] {"", "", ""}, ExpectedResult: 5);
            L.Ref.Method<TestExtTest.Helper>(o => o.Test("", "", "", "")).AssertResult(Target, new object[] {"", "", "", ""}, ExpectedResult: 5);
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertResult) + "(Func<U>, U)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertResult) + "(Func<T1, U>, T1, U)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertResult) + "(Func<T1, T2, U>, T1, T2, U)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertResult) + "(Func<T1, T2, T3, U>, T1, T2, T3, U)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertResult) + "(Func<T1, T2, T3, T4, U>, T1, T2, T3, T4, U)")]
        public void AssertResult_Func_1_U_U()
            {
            this._TestFunc.AssertResult("abc");
            this._TestFunc2.AssertResult("abc", "abc");
            this._TestFunc3.AssertResult("abc", "abc", "abc");
            this._TestFunc4.AssertResult("abc", "abc", "abc", "abc");
            this._TestFunc5.AssertResult("abc", "abc", "abc", "abc", "abc");

            L.A(() => this._TestFunc.AssertResult("abcd")).ShouldFail();
            L.A(() => this._TestFunc2.AssertResult("abc", "abcd")).ShouldFail();
            L.A(() => this._TestFunc3.AssertResult("abc", "abc", "abcd")).ShouldFail();
            L.A(() => this._TestFunc4.AssertResult("abc", "abc", "abc", "abcd")).ShouldFail();
            L.A(() => this._TestFunc5.AssertResult("abc", "abc", "abc", "abc", "abcd")).ShouldFail();
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertFails) + "(MethodInfo, Object[], Object, Func[]<Boolean>)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertFails) + "(MethodInfo, Object[], Object, Type, Func[]<Boolean>)")]
        public void AssertFails_MethodInfo_Object_Object_Func()
            {
            var Method = typeof(Helper).GetMethod(nameof(Helper.Fail));

            var Test = new Helper();

            Method.ShouldFail(new object[] {}, Test);
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertSucceedes) + "(MethodInfo, Object, Object[], Func[]<Boolean>)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertSucceedes) + "(MethodInfo, Object, Object[], Func[]<Object, Boolean>)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertSucceedes) + "(MethodInfo, Object, Object[], Func[]<U, Boolean>)")]
        public void AssertFails_MethodInfo_Object_Object_Type_Func()
            {
            var Method = typeof(Helper).GetMethod(nameof(Helper.Fail));

            var Test = new Helper();

            Method.AssertFails(new object[] {}, Test, typeof(ArgumentException));

            L.A(() => Method.AssertFails(new object[] {}, Test, typeof(ArgumentNullException))).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertResult) + "(MethodInfo, Object, Object[], Object, Func[]<Object, Boolean>)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertResult) + "(MethodInfo, Object, Object[], U, Func[]<Object, Boolean>)")]
        public void AssertResult_MethodInfo_Object_Object_U_Func()
            {
            var Method = typeof(Helper).GetMethod(nameof(Helper.Test), new Type[] {});

            var Test = new Helper();

            Method.AssertResult(Test, new object[] {}, ExpectedResult: 5);
            L.A(() => Method.AssertResult(Test, new object[] {}, ExpectedResult: 6)).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertSource) + "(MethodInfo, Object, Object[], Object, Func[]<Object, Boolean>)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.Assert) + "." + nameof(AssertionExt) + "." + nameof(AssertionExt.AssertSource) + "(MethodInfo, Object, Object[], U, Func[]<Object, Boolean>)")]
        public void AssertSource_MethodInfo_Object_Object_Object_Func()
            {
            var Test = new List<int> {1, 2, 3, 4, 5, 1, 5, 2};

            var Method = typeof(EnumerableExt).GetMethod(nameof(EnumerableExt.Move), new[] {typeof(IList), typeof(int), typeof(int)});

            Method.AssertSource(null, new object[] {Test, 0, 1}, new List<int> {2, 1, 3, 4, 5, 1, 5, 2});
            L.A(() => Method.AssertSource(null, new object[] {Test, 3, 5}, new List<int> {1, 2, 3, 4, 5, 1})).ShouldFail();
            }
        }

    #region Helpers

    public class Helper2 : Helper {}

    [FriendlyName("")]
    [ExcludeFromCodeCoverage]
    public class Helper
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


        public int Fail()
            {
            throw new ArgumentException();
            }
        }

    #endregion
    }