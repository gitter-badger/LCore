using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Dynamic;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using LCore.Naming;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable UnusedParameter.Global

// ReSharper disable ArgumentsStyleLiteral

// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantArgumentDefaultValue
// ReSharper disable UnusedTypeParameter
// ReSharper disable UnassignedGetOnlyAutoProperty

namespace L_Tests.LCore.Extensions
    {
    public partial class ReflectionExtTester : XUnitOutputTester, IDisposable
        {
        public ReflectionExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.AlsoBaseTypes) + "(Type) => List<Type>")]
        public void AlsoBaseTypes()
            {
            typeof(TestClass).AlsoBaseTypes()
                .Should()
                .Equal(typeof(TestClass), typeof(TestBaseClass), typeof(TestBaseClass2), typeof(object));

            typeof(TestBaseClass).AlsoBaseTypes()
                .Should()
                .Equal(typeof(TestBaseClass), typeof(TestBaseClass2), typeof(object));

            typeof(TestBaseClass2).AlsoBaseTypes().Should().Equal(typeof(TestBaseClass2), typeof(object));
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.BaseTypes) + "(Type) => List<Type>")]
        public void BaseTypes()
            {
            typeof(TestClass).BaseTypes().Should().Equal(typeof(TestBaseClass), typeof(TestBaseClass2), typeof(object));

            typeof(TestBaseClass).BaseTypes().Should().Equal(typeof(TestBaseClass2), typeof(object));

            typeof(TestBaseClass2).BaseTypes().Should().Equal(typeof(object));
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.FindMethod) + "(Type, String, Type[]) => MethodInfo")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.FindMethod) + "(Type, String) => MethodInfo")]
        public void FindMethod()
            {
            typeof(TestBaseClass2).FindMethod("wrong").Should().BeNull();

            typeof(TestBaseClass2).FindMethod(nameof(TestBaseClass2.Test4), new Type[] { })
                .Should().NotBeNull();

            typeof(TestBaseClass2).FindMethod(nameof(TestBaseClass2.Test5), new Type[] { })
                .Should().BeNull();

            typeof(TestBaseClass2).FindMethod(nameof(TestBaseClass2.Test5), new[] { typeof(string) })
                .Should().NotBeNull();
            typeof(TestBaseClass2).FindMethod(nameof(TestBaseClass2.Test5), new[] { typeof(string), typeof(string) })
                .Should().NotBeNull();
            typeof(TestBaseClass2).FindMethod(nameof(TestBaseClass2.Test5),
                new[] { typeof(string), typeof(string), typeof(string) })
                .Should().NotBeNull();
            typeof(TestBaseClass2).FindMethod(nameof(TestBaseClass2.Test5),
                new[] { typeof(string), typeof(string), typeof(string), typeof(string) })
                .Should().NotBeNull();
            typeof(TestBaseClass2).FindMethod(nameof(TestBaseClass2.Test5),
                new[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) })
                .Should().BeNull();

            typeof(TestBaseClass2).FindMethod<string>(nameof(TestBaseClass2.Test5))
                .Should().NotBeNull();
            typeof(TestBaseClass2).FindMethod<string, string>(nameof(TestBaseClass2.Test5))
                .Should().NotBeNull();
            typeof(TestBaseClass2).FindMethod<string, string, string>(nameof(TestBaseClass2.Test5))
                .Should().NotBeNull();
            typeof(TestBaseClass2).FindMethod<string, string, string, string>(nameof(TestBaseClass2.Test5))
                .Should().NotBeNull();
            typeof(TestBaseClass2).FindMethod<string, string, string, int>(nameof(TestBaseClass2.Test5))
                .Should().BeNull();

            typeof(TestBaseClass2).FindMethod(nameof(TestBaseClass2.Test5), new[] { typeof(string) })
                .Should().NotBeNull();

            // ReSharper disable once RedundantNameQualifier
            typeof(TestBaseClass2).FindMethod(nameof(object.ToString))
                .Should().NotBeNull();
            // ReSharper restore ExceptionNotDocumented

            typeof(int).FindMethod("ToString").Should().NotBeNull();

            // Tests underlying type method finding
            typeof(int).FindMethod("Equals", new[] { typeof(object), typeof(object) }).Should().NotBeNull();
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.FullyQualifiedName) + "(MemberInfo) => String")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.FullyQualifiedName) + "(ParameterInfo) => String")]
        public void FullyQualifiedName()
            {
            typeof(TestClass).FullyQualifiedName()
                .ShouldBe("L_Tests.LCore.Extensions.ReflectionExtTester.TestClass");
            L.Ref.Member<TestClass>(Test => Test.Test).FullyQualifiedName()
                .ShouldBe("L_Tests.LCore.Extensions.ReflectionExtTester.TestClass.Test");

            L.Ref.Method<TestClass>(Test => Test.Test5("")).FullyQualifiedName()
                .ShouldBe("L_Tests.LCore.Extensions.ReflectionExtTester.TestClass.Test5");

            typeof(TestBaseClass).FullyQualifiedName()
                .ShouldBe("L_Tests.LCore.Extensions.ReflectionExtTester.TestBaseClass");
            L.Ref.Member<TestBaseClass>(Test => Test.Test2).FullyQualifiedName()
                .ShouldBe("L_Tests.LCore.Extensions.ReflectionExtTester.TestBaseClass.Test2");

            L.Ref.Method<TestBaseClass>(Test => Test.Test5("")).FullyQualifiedName()
                .ShouldBe("L_Tests.LCore.Extensions.ReflectionExtTester.TestBaseClass.Test5");
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.GetAttribute) + "(ICustomAttributeProvider) => T")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.GetAttribute) + "(ICustomAttributeProvider, Boolean) => T")]
        public void GetAttribute()
            {
            var Member = L.Ref.Member<TestClass>(Test => Test.Test2);


            Member.GetAttribute<NotMappedAttribute>(IncludeBaseTypes: true).Should().NotBeNull();
            Member.GetAttribute<NotMappedAttribute>(IncludeBaseTypes: false).Should().BeNull();

            Member.GetAttribute<KeyAttribute>(IncludeBaseTypes: true).Should().BeNull();

            Member.GetAttribute<ITestedAttribute>().Should().BeNull();

            ((ICustomAttributeProvider)null).GetAttribute<FriendlyNameAttribute>().Should().BeNull();
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.GetAttributes) + "(ICustomAttributeProvider, Boolean) => List<T>")]
        public void GetAttributes()
            {
            var Member = L.Ref.Method<TestClass>(Test => Test.Test5(""));

            Member.GetAttributes<TestResultAttribute>(IncludeBaseTypes: true)
                .ShouldBeEquivalentTo(new List<TestResultAttribute>
                    {
                    new TestResultAttribute(new object[] {}, ExpectedResult: 1),
                    new TestResultAttribute(new object[] {}, ExpectedResult: 2),
                    new TestResultAttribute(new object[] {}, ExpectedResult: 3),
                    new TestResultAttribute(new object[] {}, ExpectedResult: 4)
                    });

            Member.GetAttributes<TestResultAttribute>(IncludeBaseTypes: false)
                .ShouldBeEquivalentTo(new List<TestResultAttribute>
                    {
                    new TestResultAttribute(new object[] {}, ExpectedResult: 1),
                    new TestResultAttribute(new object[] {}, ExpectedResult: 2),
                    new TestResultAttribute(new object[] {}, ExpectedResult: 3),
                    new TestResultAttribute(new object[] {}, ExpectedResult: 4)
                    }
                );


            new TestMember().GetAttributes<TestResultAttribute>(IncludeBaseTypes: false)
                .Should().Equal();
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.GetAttributeTypeName) + "(ICustomAttributeProvider) => String")]
        public void GetAttributeTypeName()
            {
            typeof(TestClass).GetAttributeTypeName().ShouldBe("L_Tests.LCore.Extensions.ReflectionExtTester+TestClass");
            L.Ref.Member<TestClass>(Class => Class.Test2)
                .GetAttributeTypeName()
                .Should()
                .Be("L_Tests.LCore.Extensions.ReflectionExtTester+TestClass");
            L.Ref.Member<TestBaseClass>(Class => Class.Test2)
                .GetAttributeTypeName()
                .Should()
                .Be("L_Tests.LCore.Extensions.ReflectionExtTester+TestBaseClass");
            L.Ref.Method<TestClass>(Class => Class.Test5("")).GetParameters().First()
                .GetAttributeTypeName().ShouldBe("L_Tests.LCore.Extensions.ReflectionExtTester+TestBaseClass2");

            new AttributeList("name", new Attribute[] { }).GetAttributeTypeName().ShouldBe("name");

            L.A(() => new TestClassGeneric1<string>().GetAttributeTypeName()).ShouldFail();

            var Test = new TestClassGeneric1<string>();
            // ReSharper disable ReturnValueOfPureMethodIsNotUsed
            Test.IsDefined(AttributeType: null, Inherit: false);
            Test.GetCustomAttributes(AttributeType: null, Inherit: false);
            Test.GetCustomAttributes(Inherit: false);
            // ReSharper restore ReturnValueOfPureMethodIsNotUsed
            }
        

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.GetComparer) + "(MemberInfo) => IComparer")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.GetComparer) + "(MemberInfo) => IComparer<T>")]
        public void GetComparer()
            {
            L.Ref.Member<TestClass>(Test => Test.Test2).GetComparer().Should().NotBeNull();
            L.Ref.Member<TestClass>(Test => Test.Test2).GetComparer<string>().Should().NotBeNull();
            L.Ref.Member<TestClass>(Test => Test.Test2).GetComparer<object>().Should().BeNull();
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.GetExtensionMethods) + "(Type) => MethodInfo[]")]
        public void GetExtensionMethods()
            {
            typeof(DateExt).GetExtensionMethods().Should().Equal(
                // ReSharper disable InvokeAsExtensionMethod
                // ReSharper disable once ArgumentsStyleLiteral
                L.Ref.StaticMethod(() => DateExt.Average(null)),
                L.Ref.StaticMethod(() => DateExt.DayOfWeekNumber(default(DayOfWeek))),
                L.Ref.StaticMethod(() => DateExt.CleanDateString(DateTime.MinValue)),
                L.Ref.StaticMethod(() => DateExt.ToSpecification(DateTime.MinValue)),
                L.Ref.StaticMethod(() => DateExt.GetMonthName(DateTime.MinValue)),
                L.Ref.StaticMethod(() => DateExt.ToTimeString(new TimeSpan())),
                // ReSharper disable once ArgumentsStyleLiteral
                L.Ref.StaticMethod(() => DateExt.TimeDifference(DateTime.MinValue, DateTime.MinValue, false)),
                L.Ref.StaticMethod(() => DateExt.IsPast(DateTime.MinValue)),
                L.Ref.StaticMethod(() => DateExt.IsFuture(DateTime.MinValue))
                // ReSharper restore InvokeAsExtensionMethod
                );
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.GetMemberType) + "(MemberInfo) => Type")]
        public void GetMemberType()
            {
            L.Ref.Member<TestClass>(Test => Test.Test6).GetMemberType()
                .ShouldBe(typeof(string));
            L.Ref.Member<TestClass>(Test => Test.Test).GetMemberType()
                .ShouldBe(typeof(string));
            L.Ref.Method<TestClass>(Test => Test.Test5("")).GetMemberType()
                .ShouldBe(typeof(void));
            L.Ref.Event<TestClass>(nameof(TestClass.Test7)).GetMemberType()
                .ShouldBe(typeof(EventHandler));
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.GetSubClass) + "(Type, String) => Type")]
        public void GetSubClass()
            {
            typeof(TestClass).GetSubClass(nameof(TestClass.TestSubClass)).Should().NotBeNull();
            typeof(TestClass).GetSubClass(nameof(TestClass.TestSubClass2)).Should().NotBeNull();
            typeof(TestClass).GetSubClass("abb").Should().BeNull();
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.GetSubClasses) + "(Type) => List<Type>")]
        public void GetSubClasses()
            {
            typeof(TestClass).GetSubClasses().Should().Equal(
                typeof(TestClass.TestSubClass),
                typeof(TestClass.TestSubClass2)
                );
            typeof(TestClass.TestSubClass2).GetSubClasses().Should().Equal();
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.GetFriendlyTypeName) + "(Type) => String")]
        public void GetFriendlyTypeName()
            {
            typeof(TestClass).GetFriendlyTypeName().ShouldBe("Test2");
            typeof(TestBaseClass).GetFriendlyTypeName().ShouldBe("Test");
            typeof(TestBaseClass2).GetFriendlyTypeName().ShouldBe("Test Base Class 2");

            typeof(TestClassGeneric2<string, int>).GetFriendlyTypeName().ShouldBe("TestClassGeneric2<String, Int32>");
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.GetValue) + "(MemberInfo, Object) => Object")]
        public void GetValue()
            {
            var Test = new TestClass { Test = "a", Test6 = "b" };

            var Member = L.Ref.Member<TestClass>(Class => Class.Test);
            var Member2 = L.Ref.Member<TestClass>(Class => Class.Test6);

            Member.GetValue(Test).ShouldBe("a");

            L.A(() => Member.GetValue(Obj: null)).ShouldFail();

            Member.GetValue(Test).ShouldBe("a");
            Member2.GetValue(Test).ShouldBe("b");

            L.A(() => Member.GetValue(Obj: null)).ShouldFail();
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.GetValues) + "(Type, Object, Boolean) => List<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.GetValues) + "(IEnumerable<MemberInfo>, Object, Boolean) => List<T>")]
        public void GetValues()
            {
            var Test = new TestClass { Test = "a", Test6 = "b" };

            typeof(TestClass).GetValues<string>(Test).Should().Equal("a", "6", "b");

            typeof(TestClass).GetMembers().GetValues<string>(Test).Should().Equal("a", "6", "b");

            var Test2 = new TestClass();

            typeof(TestClass).GetMembers().GetValues<string>(Test2, Instantiate: false).Should().Equal("6");

            typeof(TestClass).GetMembers()
                .GetValues<string>(Test2, Instantiate: true)
                .Should()
                .Equal("", "", "", "", "", "", "", "", "", "", "", "", "6", "");
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.GetTypes) + "(IEnumerable<T>) => List<Type>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.GetTypes) + "(T[]) => Type[]")]
        public void GetTypes()
            {
            var Test = new object[] { 0, "a", (double)-3, -5.5f };

            Test.GetTypes().Should().Equal(typeof(int), typeof(string), typeof(double), typeof(float));

            Test.List().GetTypes().Should().Equal(new List<Type>
                {
                typeof(int),
                typeof(string),
                typeof(double),
                typeof(float)
                });
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.HasAttribute) + "(ICustomAttributeProvider) => Boolean")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.HasAttribute) + "(ICustomAttributeProvider, Boolean) => Boolean")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.HasAttribute) + "(ICustomAttributeProvider, Type, Boolean) => Boolean")]
        public void HasAttribute()
            {
            ((Type)null).HasAttribute<FriendlyNameAttribute>().ShouldBeFalse();
            ((Type)null).HasAttribute<FriendlyNameAttribute>(IncludeBaseClasses: true).ShouldBeFalse();
            ((Type)null).HasAttribute(typeof(FriendlyNameAttribute), IncludeBaseClasses: true).ShouldBeFalse();

            typeof(TestClass).HasAttribute<FriendlyNameAttribute>().ShouldBeTrue();
            typeof(TestClass).HasAttribute<FriendlyNameAttribute>(IncludeBaseClasses: true).ShouldBeTrue();
            typeof(TestClass).HasAttribute<FriendlyNameAttribute>(IncludeBaseClasses: false).ShouldBeTrue();
            typeof(TestClass).HasAttribute<IFriendlyName>().ShouldBeTrue();
            typeof(TestClass).HasAttribute<IFriendlyName>(IncludeBaseClasses: true).ShouldBeTrue();
            typeof(TestClass).HasAttribute<IFriendlyName>(IncludeBaseClasses: false).ShouldBeTrue();
            typeof(TestClass).HasAttribute<TestClassAttribute>(IncludeBaseClasses: true).ShouldBeFalse();
            typeof(TestClass).HasAttribute<TestClassAttribute>(IncludeBaseClasses: false).ShouldBeFalse();

            L.Ref.Member<TestClass>(Test => Test.Test2).HasAttribute<NotMappedAttribute>(IncludeBaseClasses: false)
                .ShouldBeFalse();
            L.Ref.Member<TestClass>(Test => Test.Test2).HasAttribute<NotMappedAttribute>(IncludeBaseClasses: true)
                .ShouldBeTrue();


            typeof(TestClass).HasAttribute(typeof(FriendlyNameAttribute), IncludeBaseClasses: true).ShouldBeTrue();
            typeof(TestClass).HasAttribute(typeof(FriendlyNameAttribute), IncludeBaseClasses: false).ShouldBeTrue();
            typeof(TestClass).HasAttribute(typeof(IFriendlyName), IncludeBaseClasses: true).ShouldBeTrue();
            typeof(TestClass).HasAttribute(typeof(IFriendlyName), IncludeBaseClasses: false).ShouldBeTrue();
            typeof(TestClass).HasAttribute(typeof(TestClassAttribute), IncludeBaseClasses: true).ShouldBeFalse();
            typeof(TestClass).HasAttribute(typeof(TestClassAttribute), IncludeBaseClasses: false).ShouldBeFalse();

            L.Ref.Member<TestClass>(Test => Test.Test2)
                .HasAttribute(typeof(NotMappedAttribute), IncludeBaseClasses: false)
                .ShouldBeFalse();
            L.Ref.Member<TestClass>(Test => Test.Test2)
                .HasAttribute(typeof(NotMappedAttribute), IncludeBaseClasses: true)
                .ShouldBeTrue();
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.HasInterface) + "(Type, Type) => Boolean")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.HasInterface) + "(Type) => Boolean")]
        public void HasInterface()
            {
            ((Type)null).HasInterface<IFriendlyName>().ShouldBeFalse();
            ((Type)null).HasInterface(typeof(IFriendlyName)).ShouldBeFalse();

            typeof(TestClass).HasInterface<ITest2>().ShouldBeTrue();
            typeof(TestClass).HasInterface(typeof(ITest2)).ShouldBeTrue();

            typeof(TestClass).HasInterface<IFriendlyName>().ShouldBeFalse();
            typeof(TestClass).HasInterface(typeof(IFriendlyName)).ShouldBeFalse();

            typeof(TestClass).HasInterface<ITest>().ShouldBeTrue();
            typeof(TestClass).HasInterface(typeof(ITest)).ShouldBeTrue();

            // Static types cant have interfaces.
            typeof(TestExt).HasInterface(typeof(ITest)).ShouldBeFalse();
            typeof(TestExt).HasInterface<ITest>().ShouldBeFalse();

            //            typeof(BadStatic).HasInterface(typeof(ITest)).ShouldBeFalse();
            //            typeof(BadStatic).HasInterface<ITest>().ShouldBeFalse();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.HasIndexGetter) + "(Type) => Boolean")]
        public void HasIndexGetter()
            {
            typeof(TestClassIndexer).HasIndexGetter<int>().ShouldBeTrue();
            typeof(TestClassIndexer).HasIndexGetter<string>().ShouldBeTrue();
            typeof(TestClassIndexer).HasIndexGetter<object>().ShouldBeFalse();

            typeof(TestClassIndexer).HasIndexGetter<int, string>().ShouldBeTrue();
            typeof(TestClassIndexer).HasIndexGetter<string, int?>().ShouldBeTrue();
            typeof(TestClassIndexer).HasIndexGetter<string, string>().ShouldBeFalse();
            typeof(TestClassIndexer).HasIndexGetter<int, int>().ShouldBeFalse();
            typeof(TestClassIndexer).HasIndexGetter<object, object>().ShouldBeFalse();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.HasIndexSetter) + "(Type) => Boolean")]
        public void HasIndexSetter()
            {
            typeof(TestClassIndexer).HasIndexSetter<int, string>().ShouldBeTrue();
            typeof(TestClassIndexer).HasIndexSetter<string, int?>().ShouldBeFalse();
            typeof(TestClassIndexer).HasIndexSetter<string, string>().ShouldBeFalse();
            typeof(TestClassIndexer).HasIndexSetter<int, int>().ShouldBeFalse();
            typeof(TestClassIndexer).HasIndexSetter<object, object>().ShouldBeFalse();
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.HasSetter) + "(MemberInfo) => Boolean")]
        public void HasSetter()
            {
            ((MemberInfo)null).HasSetter().ShouldBeFalse();

            L.Ref.Member<TestClass>(Test => Test.Test)
                .Should().NotBeNull().And.Subject.As<MemberInfo>()
                .HasSetter().ShouldBeTrue();

            L.Ref.Member<TestClass>(Test => Test.Test2)
                .Should().NotBeNull().And.Subject.As<MemberInfo>()
                .HasSetter().ShouldBeTrue();

            L.Ref.Member<TestClass>(Test => Test.Test6)
                .Should().NotBeNull().And.Subject.As<MemberInfo>()
                .HasSetter().ShouldBeTrue();

            L.Ref.Constant<TestClass>(nameof(TestClass.Test8))
                .Should().NotBeNull().And.Subject.As<MemberInfo>()
                .HasSetter().ShouldBeFalse();

            L.Ref.Member<TestClass>(Test => TestClass.Test9)
                .Should().NotBeNull().And.Subject.As<MemberInfo>()
                .HasSetter().ShouldBeTrue();

            L.Ref.Member<TestClass>(Test => TestClass.Test10)
                .Should().NotBeNull().And.Subject.As<MemberInfo>()
                .HasSetter().ShouldBeFalse();

            L.Ref.Member<TestClass>(Test => Test.Test11)
                .Should().NotBeNull().And.Subject.As<MemberInfo>()
                .HasSetter().ShouldBeFalse();

            L.Ref.Member<TestClass>(Test => Test.Test12)
                .Should().NotBeNull().And.Subject.As<MemberInfo>()
                .HasSetter().ShouldBeFalse();

            L.Ref.Member<TestClass>(Test => Test.Test13)
                .Should().NotBeNull().And.Subject.As<MemberInfo>()
                .HasSetter().ShouldBeFalse();

            L.Ref.Method<TestClass>(Test => Test.Test5(""))
                .Should().NotBeNull().And.Subject.As<MemberInfo>()
                .HasSetter().ShouldBeFalse();

            L.Ref.Event<TestClass>(nameof(TestClass.Test7))
                .Should().NotBeNull().And.Subject.As<MemberInfo>()
                .HasSetter().ShouldBeFalse();

            L.A(() => new TestMember().HasSetter()).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.IndexGetter) + "(Type) => PropertyInfo")]
        public void IndexGetter()
            {
            var Test = new TestClassIndexer();

            typeof(TestClassIndexer).IndexGetter<int>().Should().BeAssignableTo<PropertyInfo>()
                .And.Should().NotBeNull();
            typeof(TestClassIndexer).IndexGetter<string>().Should().BeAssignableTo<PropertyInfo>()
                .And.Should().NotBeNull();
            typeof(TestClassIndexer).IndexGetter<object>().Should().BeNull();

            (typeof(TestClassIndexer).IndexGetter<int, string>().Should().BeAssignableTo<PropertyInfo>()
                .And.Should().NotBeNull()
                .And.Subject as PropertyInfo)?.GetMethod.Invoke(Test, new object[] { 5 }).ShouldBe("5");
            typeof(TestClassIndexer).IndexGetter<string, int?>().Should().BeAssignableTo<PropertyInfo>()
                .And.Should().NotBeNull();
            typeof(TestClassIndexer).IndexGetter<string, string>().Should().BeNull();
            typeof(TestClassIndexer).IndexGetter<int, int>().Should().BeNull();
            typeof(TestClassIndexer).IndexGetter<object, object>().Should().BeNull();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.IndexSetter) + "(Type) => PropertyInfo")]
        public void IndexSetter()
            {
            var Test = new TestClassIndexer();

            (typeof(TestClassIndexer).IndexSetter<int>().Should().BeAssignableTo<PropertyInfo>()
                .And.Should().NotBeNull()
                .And.Subject as PropertyInfo)?.SetMethod.Invoke(Test, new object[] { 5, "5" });
            typeof(TestClassIndexer).IndexSetter<string>().Should().BeNull();
            typeof(TestClassIndexer).IndexSetter<object>().Should().BeNull();

            (typeof(TestClassIndexer).IndexSetter<int, string>().Should().BeAssignableTo<PropertyInfo>()
                .And.Should().NotBeNull()
                .And.Subject as PropertyInfo)?.SetMethod.Invoke(Test, new object[] { 5, "5" });
            typeof(TestClassIndexer).IndexSetter<string, int?>().Should().BeNull();
            typeof(TestClassIndexer).IndexSetter<string, string>().Should().BeNull();
            typeof(TestClassIndexer).IndexSetter<int, int>().Should().BeNull();
            typeof(TestClassIndexer).IndexSetter<object, object>().Should().BeNull();
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.InstantiateValues) + "(Type, Object, Boolean) => List<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.InstantiateValues) + "(IEnumerable<MemberInfo>, Object) => List<T>")]
        public void InstantiateValues()
            {
            var Test = new TestClass { Test = "a", Test6 = "b" };

            typeof(TestClass).GetValues<object>(Test).Should().Equal(
                "a",
                "6",
                "b"
                );

            typeof(TestClass).InstantiateValues<string>(Test, IncludeBaseClasses: false);
            typeof(TestClass).InstantiateValues<TestClass>(Test, IncludeBaseClasses: false);
            typeof(TestClass).GetValues<object>(Test).Should().Equal("a", "6", "b");


            Test = new TestClass { Test = "a", Test6 = "b" };

            typeof(TestClass).InstantiateValues<string>(Test, IncludeBaseClasses: true);
            typeof(TestClass).InstantiateValues<TestClass>(Test, IncludeBaseClasses: true);
            typeof(TestClass).GetValues<object>(Test).ShouldBeEquivalentTo(
                new List<object> { "a", "6", "b", "", "", "", new TestClass() });

            Test = new TestClass { Test = "a", Test6 = "b" };

            typeof(TestClass).GetMembers().InstantiateValues<string>(Test);
            typeof(TestClass).GetMembers().InstantiateValues<TestClass>(Test);
            typeof(TestClass).GetValues<object>(Test).ShouldBeEquivalentTo(
                new List<object> { "a", "6", "b", "", "", "", new TestClass() });
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.IsType) + "(Object) => Boolean")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.IsType) + "(Object, Type) => Boolean")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.IsType) + "(Type, Type) => Boolean")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.IsType) + "(Type) => Boolean")]
        public void IsType()
            {
            ((object)null).IsType<object>().ShouldBeFalse();
            ((object)null).IsType(typeof(object)).ShouldBeFalse();

            "".IsType<string>().ShouldBeTrue();
            "".IsType(typeof(string)).ShouldBeTrue();
            "".IsType<object>().ShouldBeTrue();
            "".IsType(typeof(object)).ShouldBeTrue();
            "".IsType<IConvertible>().ShouldBeTrue();
            "".IsType(typeof(IConvertible)).ShouldBeTrue();

            typeof(string).IsType<string>().ShouldBeTrue();
            typeof(string).IsType<IConvertible>().ShouldBeTrue();
            typeof(string).IsType<char>().ShouldBeFalse();
            typeof(string).IsType(typeof(string)).ShouldBeTrue();
            typeof(string).IsType(typeof(IConvertible)).ShouldBeTrue();
            typeof(string).IsType(typeof(char)).ShouldBeFalse();

            typeof(TestClass).IsType<TestBaseClass>().ShouldBeTrue();
            typeof(TestClass).IsType<TestBaseClass2>().ShouldBeTrue();
            typeof(TestClass).IsType<object>().ShouldBeTrue();
            typeof(TestClass).IsType<string>().ShouldBeFalse();
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.MembersOfType) + "(Type, Type, Boolean) => List<MemberInfo>")]
        public void MembersOfType()
            {
            typeof(TestClass).MembersOfType(typeof(string)).ShouldBeEquivalentTo(new List<MemberInfo>
                {
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                L.Ref.Method<TestClass>(Test => Test.ToString()),
                L.Ref.Member<TestClass>(Test => Test.Test),
                L.Ref.Member<TestClass>(Test => Test.Test2),
                L.Ref.Member<TestClass>(Test => Test.Test3),
                L.Ref.Member<TestClass>(Test => Test.Test11),
                L.Ref.Member<TestClass>(Test => Test.Test12),
                L.Ref.Member<TestClass>(Test => Test.Test13),
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                L.Ref.Member<TestClass>(Test => Test.Test6)
                }
                );

            typeof(TestClass).MembersOfType(typeof(string), IncludeBaseClasses: false).Should().Equal();
            typeof(TestClass).MembersOfType(typeof(string), IncludeBaseClasses: true)
                .ShouldBeEquivalentTo(new List<MemberInfo>
                    {
                    // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                    L.Ref.Method<TestClass>(Test => Test.ToString()),
                    L.Ref.Member<TestClass>(Test => Test.Test),
                    L.Ref.Member<TestClass>(Test => Test.Test2),
                    L.Ref.Member<TestClass>(Test => Test.Test3),
                    L.Ref.Member<TestClass>(Test => Test.Test11),
                    L.Ref.Member<TestClass>(Test => Test.Test12),
                    L.Ref.Member<TestClass>(Test => Test.Test13),
                    // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                    L.Ref.Member<TestClass>(Test => Test.Test6)
                    }
                );
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.MemberType) + "(MemberInfo) => Type")]
        public void MemberType()
            {
            typeof(TestClass).GetMembers().Convert(Member => Member.MemberType())
                .ShouldBeEquivalentTo(new[]
                    {
                    typeof(void),
                    typeof(void),
                    typeof(void),
                    typeof(void),
                    typeof(void),
                    typeof(void),
                    typeof(void),
                    typeof(void),
                    typeof(void),
                    typeof(void),
                    typeof(void),
                    typeof(string),
                    typeof(string),
                    typeof(string),
                    typeof(string),
                    typeof(string),
                    typeof(TestClass),
                    typeof(string),
                    typeof(string),
                    typeof(bool),
                    typeof(int),
                    typeof(Type),
                    null,
                    typeof(string),
                    typeof(string),
                    typeof(string),
                    typeof(string),
                    typeof(string),
                    typeof(string),
                    typeof(TestClass),
                    typeof(EventHandler),
                    typeof(string)
                    }
                );

            new TestMember().MemberType().Should().BeNull();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.New) + "(Type, Object[]) => T")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.New) + "(Type, Object[], Type) => Object")]
        public void New()
            {
            typeof(string).New<string>().ShouldBe("");

            L.Obj.New<TestClass>().ShouldBeEquivalentTo(new TestClass());
            L.Obj.New<TestBaseClass2>("").ShouldBeEquivalentTo(new TestBaseClass2());
            L.Obj.New<TestBaseClass2>("", "").ShouldBeEquivalentTo(new TestBaseClass2());
            L.Obj.New<TestBaseClass2>("", "", "").ShouldBeEquivalentTo(new TestBaseClass2());
            L.Obj.New<TestBaseClass2>("", "", "", "").ShouldBeEquivalentTo(new TestBaseClass2());

            L.Obj.New<TestClassGeneric1<string>>().ShouldBeEquivalentTo(new TestClassGeneric1<string>());
            L.Obj.New<TestClassGeneric1<int>>().ShouldBeEquivalentTo(new TestClassGeneric1<int>());
            L.Obj.New<TestClassGeneric2<string, int>>("a").ShouldBeEquivalentTo(new TestClassGeneric2<string, int>("a"));

            typeof(TestClassGeneric2<,>).New(new object[] { "a" }, typeof(TestClassGeneric2<string, int>))
                .ShouldBeEquivalentTo(new TestClassGeneric2<string, int>("a"));

            typeof(TestClassGeneric2<,>).New(new object[] { "a" }, typeof(TestClassGeneric2<int, int>))
                .ShouldBeEquivalentTo(new TestClassGeneric2<int, int>("a"));
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.SetValue) + "(MemberInfo, Object, Object)")]
        public void SetValue()
            {
            var Test = new TestClass();

            var Member1 = L.Ref.Member<TestClass>(Class => Class.Test);
            var Member2 = L.Ref.Member<TestClass>(Class => Class.Test6);

            Member1.SetValue(Test, "a");
            Member2.SetValue(Test, "b");

            Test.Test.ShouldBe("a");
            Test.Test6.ShouldBe("b");

            L.A(() => Member2.SetValue(Obj: null, Value: "a")).ShouldFail();
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.ToInvocationSignature) + "(MethodInfo, Boolean) => String")]
        public void ToInvocationSignature()
            {
            // ReSharper disable once InvokeAsExtensionMethod
            L.Ref.StaticMethod(() => DateExt.IsFuture(DateTime.MinValue))
                .ToInvocationSignature()
                .Should()
                .Be("DateExt.IsFuture(DateTime) => Boolean");
            L.Ref.Method<TestClass>(Test => Test.Test5(""))
                .ToInvocationSignature()
                .Should()
                .Be("ReflectionExtTester.TestBaseClass2.Test5(String)");
            L.Ref.StaticMethod(() => L.Ref.FindType(""))
                .ToInvocationSignature()
                .Should()
                .Be("L.Ref.FindType(String, Assembly[]) => Type");
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.TypeEquals) + "(Type, Type) => Boolean")]
        public void TypeEquals()
            {
            Type Test1 = null;
            var Test2 = typeof(string);
            var Test3 = typeof(TestClass);
            var Test4 = typeof(TestBaseClass);

            // ReSharper disable once ExpressionIsAlwaysNull
            Test1.TypeEquals(Compare: null).ShouldBeFalse();
            Test2.TypeEquals(Compare: null).ShouldBeFalse();
            Test2.TypeEquals(Test2).ShouldBeTrue();
            Test3.TypeEquals(Test3).ShouldBeTrue();
            Test4.TypeEquals(Test4).ShouldBeTrue();
            Test3.TypeEquals(Test4).ShouldBeFalse();
            Test4.TypeEquals(Test3).ShouldBeFalse();
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.WithAttribute) + "(IEnumerable<TMember>, Boolean) => List<TMember>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.WithAttribute) + "(IEnumerable<MemberInfo>, Boolean) => List<MemberInfo>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.WithAttribute) + "(IEnumerable<MemberInfo>, Type, Boolean) => List<MemberInfo>")]
        public void WithAttribute()
            {
            typeof(TestClass).GetMembers().WithAttribute<NotMappedAttribute>().ShouldBeEquivalentTo(new List<MemberInfo> {
                L.Ref.Member<TestClass>(Test => Test.Test),
                L.Ref.Member<TestClass>(Test => Test.Test2)}
                );
            typeof(TestClass).GetMembers().WithAttribute<ILUnitAttribute>().Should().Equal(
                L.Ref.Method<TestClass>(Test => Test.Test5(""))
                );


            typeof(TestClass).GetMembers()
                .WithAttribute(typeof(NotMappedAttribute))
                .ShouldBeEquivalentTo(new List<MemberInfo>
                    {
                    L.Ref.Member<TestClass>(Test => Test.Test),
                    L.Ref.Member<TestClass>(Test => Test.Test2)
                    }
                );

            typeof(TestClass).GetMembers().WithAttribute(typeof(ILUnitAttribute)).Should().Equal(
                L.Ref.Method<TestClass>(Test => Test.Test5(""))
                );
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.WithoutAttribute) + "(IEnumerable<TMember>, Boolean) => List<TMember>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.WithoutAttribute) + "(IEnumerable<MemberInfo>, Boolean) => List<MemberInfo>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." +
            nameof(ReflectionExt.WithoutAttribute) + "(IEnumerable<MemberInfo>, Type, Boolean) => List<MemberInfo>")]
        public void WithoutAttribute()
            {
            typeof(TestClass).GetMembers()
                .Select(Member => !(Member is MethodInfo && ((MethodInfo)Member).IsSpecialName))
                .WithoutAttribute<NotMappedAttribute>().ShouldBeEquivalentTo(new List<MemberInfo>
                    {
                    L.Ref.Method<TestClass>(Test => Test.Test4()),
                    L.Ref.Method<TestClass>(Test => Test.Test5("")),
                    L.Ref.Method<TestClass>(Test => Test.Test5("", "")),
                    L.Ref.Method<TestClass>(Test => Test.Test5("", "", "")),
                    L.Ref.Method<TestClass>(Test => Test.Test5("", "", "", "")),
                    // ReSharper disable ReturnValueOfPureMethodIsNotUsed
                    L.Ref.Method<TestClass>(Test => Test.ToString()),
                    // ReSharper disable once ArgumentsStyleLiteral
                    L.Ref.Method<TestClass>(Test => Test.Equals(null)),
                    L.Ref.Method<TestClass>(Test => Test.GetHashCode()),
                    L.Ref.Method<TestClass>(Test => Test.GetType()),
                    // ReSharper restore ReturnValueOfPureMethodIsNotUsed
                    // ReSharper disable once ObjectCreationAsStatement
                    L.Ref.Constructor(() => new TestClass()),
                    L.Ref.Member<TestClass>(Test => Test.Test3),
                    L.Ref.Member<TestClass>(Test => Test.Test11),
                    L.Ref.Member<TestClass>(Test => Test.Test12),
                    L.Ref.Member<TestClass>(Test => Test.Test13),
                    L.Ref.Member<TestClass>(Test => Test.Test14),
                    L.Ref.Event<TestClass>(nameof(TestClass.Test7)),
                    L.Ref.Member<TestClass>(Test => Test.Test6)
                    }
                );
            typeof(TestClass).GetMembers()
                .Select(Member => !(Member is MethodInfo && ((MethodInfo)Member).IsSpecialName))
                .WithoutAttribute<ILUnitAttribute>().ShouldBeEquivalentTo(new List<MemberInfo>
                    {
                    L.Ref.Method<TestClass>(Test => Test.Test4()),
                    L.Ref.Method<TestClass>(Test => Test.Test5("", "")),
                    L.Ref.Method<TestClass>(Test => Test.Test5("", "", "")),
                    L.Ref.Method<TestClass>(Test => Test.Test5("", "", "", "")),
                    // ReSharper disable ReturnValueOfPureMethodIsNotUsed
                    L.Ref.Method<TestClass>(Test => Test.ToString()),
                    // ReSharper disable once ArgumentsStyleLiteral
                    L.Ref.Method<TestClass>(Test => Test.Equals(null)),
                    L.Ref.Method<TestClass>(Test => Test.GetHashCode()),
                    L.Ref.Method<TestClass>(Test => Test.GetType()),
                    // ReSharper restore ReturnValueOfPureMethodIsNotUsed
                    // ReSharper disable once ObjectCreationAsStatement
                    L.Ref.Constructor(() => new TestClass()),
                    L.Ref.Member<TestClass>(Test => Test.Test),
                    L.Ref.Member<TestClass>(Test => Test.Test2),
                    L.Ref.Member<TestClass>(Test => Test.Test3),
                    L.Ref.Member<TestClass>(Test => Test.Test11),
                    L.Ref.Member<TestClass>(Test => Test.Test12),
                    L.Ref.Member<TestClass>(Test => Test.Test13),
                    L.Ref.Member<TestClass>(Test => Test.Test14),
                    L.Ref.Event<TestClass>(nameof(TestClass.Test7)),
                    L.Ref.Member<TestClass>(Test => Test.Test6)
                    }
                );


            typeof(TestClass).GetMembers()
                .Select(Member => !(Member is MethodInfo && ((MethodInfo)Member).IsSpecialName))
                .WithoutAttribute(typeof(NotMappedAttribute)).ShouldBeEquivalentTo(new List<MemberInfo>
                    {
                    L.Ref.Method<TestClass>(Test => Test.Test4()),
                    L.Ref.Method<TestClass>(Test => Test.Test5("")),
                    L.Ref.Method<TestClass>(Test => Test.Test5("", "")),
                    L.Ref.Method<TestClass>(Test => Test.Test5("", "", "")),
                    L.Ref.Method<TestClass>(Test => Test.Test5("", "", "", "")),
                    // ReSharper disable ReturnValueOfPureMethodIsNotUsed
                    L.Ref.Method<TestClass>(Test => Test.ToString()),
                    // ReSharper disable once ArgumentsStyleLiteral
                    L.Ref.Method<TestClass>(Test => Test.Equals(null)),
                    L.Ref.Method<TestClass>(Test => Test.GetHashCode()),
                    L.Ref.Method<TestClass>(Test => Test.GetType()),
                    // ReSharper restore ReturnValueOfPureMethodIsNotUsed
                    // ReSharper disable once ObjectCreationAsStatement
                    L.Ref.Constructor(() => new TestClass()),
                    L.Ref.Member<TestClass>(Test => Test.Test3),
                    L.Ref.Member<TestClass>(Test => Test.Test11),
                    L.Ref.Member<TestClass>(Test => Test.Test12),
                    L.Ref.Member<TestClass>(Test => Test.Test13),
                    L.Ref.Member<TestClass>(Test => Test.Test14),
                    L.Ref.Event<TestClass>(nameof(TestClass.Test7)),
                    L.Ref.Member<TestClass>(Test => Test.Test6)
                    }
                );
            typeof(TestClass).GetMembers()
                .Select(Member => !(Member is MethodInfo && ((MethodInfo)Member).IsSpecialName))
                .WithoutAttribute(typeof(ILUnitAttribute)).ShouldBeEquivalentTo(new List<MemberInfo>
                    {
                    L.Ref.Method<TestClass>(Test => Test.Test4()),
                    L.Ref.Method<TestClass>(Test => Test.Test5("", "")),
                    L.Ref.Method<TestClass>(Test => Test.Test5("", "", "")),
                    L.Ref.Method<TestClass>(Test => Test.Test5("", "", "", "")),
                    // ReSharper disable ReturnValueOfPureMethodIsNotUsed
                    L.Ref.Method<TestClass>(Test => Test.ToString()),
                    // ReSharper disable once ArgumentsStyleLiteral
                    L.Ref.Method<TestClass>(Test => Test.Equals(null)),
                    L.Ref.Method<TestClass>(Test => Test.GetHashCode()),
                    L.Ref.Method<TestClass>(Test => Test.GetType()),
                    // ReSharper restore ReturnValueOfPureMethodIsNotUsed
                    // ReSharper disable once ObjectCreationAsStatement
                    L.Ref.Constructor(() => new TestClass()),
                    L.Ref.Member<TestClass>(Test => Test.Test),
                    L.Ref.Member<TestClass>(Test => Test.Test2),
                    L.Ref.Member<TestClass>(Test => Test.Test3),
                    L.Ref.Member<TestClass>(Test => Test.Test11),
                    L.Ref.Member<TestClass>(Test => Test.Test12),
                    L.Ref.Member<TestClass>(Test => Test.Test13),
                    L.Ref.Member<TestClass>(Test => Test.Test14),
                    L.Ref.Event<TestClass>(nameof(TestClass.Test7)),
                    L.Ref.Member<TestClass>(Test => Test.Test6)
                    }
                );
            }

        [Fact]
        public void Mock_Proxy()
            {
            var Mock = new Mock<TestClass>();

            Mock.SetupAllProperties();


            Mock.Object.Should().BeAssignableTo<TestClass>();

            Mock.Object.GetType().GetFriendlyTypeName().ShouldBe("Test2");
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.IsNullable) + "(Type) => Boolean")]
        public void IsNullable()
            {
            typeof(int).IsNullable().ShouldBeFalse();
            typeof(int?).IsNullable().ShouldBeTrue();
            typeof(string).IsNullable().ShouldBeFalse();
            typeof(IConvertible).IsNullable().ShouldBeFalse();
            ((Type)null).IsNullable().ShouldBeFalse();
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.CanBeNull) + "(ParameterInfo) => Boolean")]
        public void CanBeNull()
            {
            var Method = L.Ref.Method<TestClassGeneric1<string>>(Test => Test.TestMethod("", "", false));

            ParameterInfo[] Parameters = Method.GetParameters();

            Parameters[0].CanBeNull().ShouldBeTrue();
            Parameters[1].CanBeNull().ShouldBeTrue();
            Parameters[2].CanBeNull().ShouldBeTrue();


            var Method2 = L.Ref.Method<TestClassGeneric1<int>>(Test => Test.TestMethod(0, "", false));

            ParameterInfo[] Parameters2 = Method2.GetParameters();

            Parameters2[0].CanBeNull().ShouldBeFalse();
            Parameters2[1].CanBeNull().ShouldBeTrue();
            Parameters2[2].CanBeNull().ShouldBeTrue();

            ((ParameterInfo)null).CanBeNull().ShouldBeFalse();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetAssembly) + "(MemberInfo) => Assembly")]
        public void GetAssembly()
            {
            typeof(TestClass).GetAssembly()?.GetName().Name.ShouldBe("L Tests");
            typeof(L).GetAssembly()?.GetName().Name.ShouldBe("L");
            typeof(object).GetAssembly()?.GetName().Name.ShouldBe("mscorlib");

            ((Type)null).GetAssembly().ShouldBeNull();

            typeof(TestClass).GetMembers()[0].GetAssembly()?.GetName().Name.ShouldBe("L Tests");
            typeof(TestClass).GetMethods()[0].GetAssembly()?.GetName().Name.ShouldBe("L Tests");
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetNamespace) + "(MemberInfo) => String")]
        public void GetNamespace()
            {
            typeof(TestClass).GetNamespace().ShouldBe("L_Tests.LCore.Extensions");
            typeof(L).GetNamespace().ShouldBe("LCore.Extensions");
            typeof(object).GetNamespace().ShouldBe("System");

            ((Type)null).GetNamespace().ShouldBe("");

            typeof(TestClass).GetMembers()[0].GetNamespace().ShouldBe("L_Tests.LCore.Extensions");
            typeof(TestClass).GetMethods()[0].GetNamespace().ShouldBe("L_Tests.LCore.Extensions");
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetNestedNames) + "(Type) => String")]
        public void GetNestedNames()
            {
            typeof(L.Comment.Test).GetNestedNames().ShouldBe("L.Comment.Test");
            typeof(TestClass).GetNestedNames().ShouldBe("ReflectionExtTester.TestClass");
            typeof(L).GetNestedNames().ShouldBe("L");
            typeof(object).GetNestedNames().ShouldBe("Object");
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.IsExtensionMethod) + "(MethodInfo) => Boolean")]
        public void IsExtensionMethod()
            {
            typeof(StringExt).GetMethods().Select(ReflectionExt.IsDeclaredMember).All(ReflectionExt.IsExtensionMethod).ShouldBeTrue();
            typeof(TestClass).GetMethods().Select(ReflectionExt.IsDeclaredMember).All(Method => Method.IsExtensionMethod()).ShouldBeFalse();

            ((MethodInfo)null).IsExtensionMethod().ShouldBeFalse();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.IsStatic) + "(Type) => Boolean")]
        public void IsStatic()
            {
            typeof(L.Comment.Test).IsStatic().ShouldBeTrue();
            typeof(TestClass).IsStatic().ShouldBeFalse();
            typeof(L).IsStatic().ShouldBeTrue();
            typeof(object).IsStatic().ShouldBeFalse();
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetRootPath) + "(Assembly) => String")]
        public void GetRootPath()
            {
            this._Output.WriteLine(typeof(L).GetAssembly().GetRootPath());
            Directory.GetFiles(typeof(L).GetAssembly().GetRootPath()).Has(File => File.EndsWith(".csproj")).ShouldBeTrue();
            Directory.GetFiles(typeof(ReflectionExtTester).GetAssembly().GetRootPath()).Has(File => File.EndsWith(".csproj")).ShouldBeTrue();
            }


        #region Helpers

        /*
            internal static class BadStatic
                {
                /// <exception cref="Exception">Condition.</exception>
                static BadStatic()
                    {
                    throw new Exception();
                    }
                }*/


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Helpers()
            {
            var Test = new TestClass { Test = "A" };

            Test.Test.ShouldBe("A");
            Test.Test2 = "A";
            Test.Test2.ShouldBe("A");
            Test.Test3 = "A";
            Test.Test3.ShouldBe("A");
            Test.Test4();
            Test.Test5("");
            Test.Test5("", "");
            Test.Test5("", "", "");
            Test.Test5("", "", "", "");

            var Test2 = new TestBaseClass { Test2 = "A" };

            Test2.Test2.ShouldBe("A");
            Test2.Test3 = "A";
            Test2.Test3.ShouldBe("A");
            Test2.Test4();
            Test2.Test5("");
            Test2.Test5("", "");
            Test2.Test5("", "", "");
            Test2.Test5("", "", "", "");

            // ReSharper disable once ObjectCreationAsStatement
            L.A(() => new TestClassGeneric2<int, int>("", "", "")).ShouldFail();
            }

        [ExcludeFromCodeCoverage]
        internal class TestClassGeneric1<T1> : TestClass, ICustomAttributeProvider
            {
            public object[] GetCustomAttributes(Type AttributeType, bool Inherit)
                {
                return null;
                }

            public object[] GetCustomAttributes(bool Inherit)
                {
                return null;
                }

            public bool IsDefined(Type AttributeType, bool Inherit)
                {
                return false;
                }


            public void TestMethod(T1 Arg, object Arg2, bool Arg3 = false) { }
            }

        [ExcludeFromCodeCoverage]
        internal class TestClassGeneric2<T1, T2> : TestClass
            {
            public TestClassGeneric2(string Test)
                {
                this.Test = Test;
                }

            /// <exception cref="ArgumentException">Condition.</exception>
            public TestClassGeneric2(string Test, string Test2, string Test3)
                {
                // ReSharper disable once ThrowingSystemException
                throw new ArgumentException();
                }
            }

        [FriendlyName("Test2")]
        [ExcludeFromCodeCoverage]
        public class TestClassIndexer : TestBaseClass
            {
            public string this[int i]
                {
                get { return $"{i}"; }
                // ReSharper disable once ValueParameterNotUsed
                set { }
                }

            public int? this[string i] => i.ConvertTo<int>();
            public string this[bool Bool] => $"{Bool}";
            }

        [FriendlyName("Test2")]
        public class TestClass : TestBaseClass, ITest2
            {
            [NotMapped]
            public string Test { get; set; }

            public override string Test2 { get; set; }
            }

        [FriendlyName("Test")]
        public class TestBaseClass : TestBaseClass2, ITest
            {
            [NotMapped]
            public virtual string Test2 { get; set; }
            }

        [ExcludeFromCodeCoverage]
        public class TestBaseClass2
            {
            public string Test3 { get; set; }

#pragma warning disable 649
            public string Test6;
#pragma warning restore 649

            public void Test4()
                {
                this.Test13 = this.Test13;
                }

            [TestResult(new object[] { }, ExpectedResult: 1)]
            [TestResult(new object[] { }, ExpectedResult: 2)]
            [TestResult(new object[] { }, ExpectedResult: 3)]
            [TestResult(new object[] { }, ExpectedResult: 4)]
            public void Test5(string Str) { }

            public void Test5(string Str, string Str2) { }
            public void Test5(string Str, string Str2, string Str3) { }
            public void Test5(string Str, string Str2, string Str3, string Str4) { }

            public event EventHandler Test7;

            public const string Test8 = "a";
            public static string Test9 = "a";
            public static readonly string Test10 = "a";
            public string Test11 { get; }
            public string Test12 { get; protected set; }
            public string Test13 { get; private set; } = "6";

            public TestClass Test14 { get; set; }

            public TestBaseClass2() { }
            public TestBaseClass2(string Str) { }
            public TestBaseClass2(string Str, string Str2) { }
            public TestBaseClass2(string Str, string Str2, string Str3) { }
            public TestBaseClass2(string Str, string Str2, string Str3, string Str4) { }

            public class TestSubClass { }

            public class TestSubClass2 { }
            }

        internal interface ITest { }

        internal interface ITest2 { }

        [ExcludeFromCodeCoverage]
        internal class TestMember : MemberInfo
            {
            public override object[] GetCustomAttributes(bool Inherit)
                {
                return null;
                }

            public override bool IsDefined(Type AttributeType, bool Inherit)
                {
                return false;
                }

            public override MemberTypes MemberType { get; }
            public override string Name { get; }
            public override Type DeclaringType { get; }
            public override Type ReflectedType { get; }

            public override object[] GetCustomAttributes(Type AttributeType, bool Inherit)
                {
                return null;
                }
            }

        #endregion
        }
    }