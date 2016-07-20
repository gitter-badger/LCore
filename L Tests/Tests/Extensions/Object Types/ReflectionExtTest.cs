
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using LCore.Naming;
using LCore.Tests;
using LCore.Dynamic;
using Xunit;
using static LCore.Extensions.L.Test.Categories;
// ReSharper disable UnusedParameter.Global
// ReSharper disable UnassignedGetOnlyAutoProperty
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable EventNeverSubscribedTo.Global
// ReSharper disable UnusedTypeParameter
// ReSharper disable RedundantArgumentDefaultValue
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable ConvertToConstant.Global
// ReSharper disable ExceptionNotDocumented
// ReSharper disable ExceptionNotDocumentedOptional

namespace L_Tests.Tests.Extensions
    {
    public class ReflectionExtTest : ExtensionTester
        {
        protected override Type[] TestType => new[] { typeof(ReflectionExt) };


        [Fact]
        [TestCategory(UnitTests)]
        public void Test_AlsoBaseTypes()
            {
            typeof(TestClass).AlsoBaseTypes().ShouldBeEquivalentTo(new[]
                {
                    typeof(TestClass),
                    typeof(TestBaseClass),
                    typeof(TestBaseClass2),
                    typeof(object)
                });

            typeof(TestBaseClass).AlsoBaseTypes().ShouldBeEquivalentTo(new[]
                {
                    typeof(TestBaseClass),
                    typeof(TestBaseClass2),
                    typeof(object)
                });

            typeof(TestBaseClass2).AlsoBaseTypes().ShouldBeEquivalentTo(new[]
                {
                    typeof(TestBaseClass2),
                    typeof(object)
                });
            }

        [Fact]
        [TestCategory(UnitTests)]
        public void Test_BaseTypes()
            {
            typeof(TestClass).BaseTypes().ShouldBeEquivalentTo(new[]
                {
                    typeof(TestBaseClass),
                    typeof(TestBaseClass2),
                    typeof(object)
                });

            typeof(TestBaseClass).BaseTypes().ShouldBeEquivalentTo(new[]
                {
                    typeof(TestBaseClass2),
                    typeof(object)
                });

            typeof(TestBaseClass2).BaseTypes().ShouldBeEquivalentTo(new[]
                {
                    typeof(object)
                });
            }

        /// <exception cref="AmbiguousMatchException">More than one method is found with the specified name and specified parameters. </exception>
        [Fact]
        [TestCategory(UnitTests)]
        public void Test_FindMethod()
            {
            // ReSharper disable ExceptionNotDocumented
            typeof(TestBaseClass2).FindMethod(null).Should().BeNull();
            typeof(TestBaseClass2).FindMethod("").Should().BeNull();
            typeof(TestBaseClass2).FindMethod("wrong").Should().BeNull();

            typeof(TestBaseClass2).FindMethod(nameof(TestBaseClass2.Test4), new Type[] { })
                .Should().NotBeNull();

            typeof(TestBaseClass2).FindMethod(nameof(TestBaseClass2.Test5), new Type[] { })
                .Should().BeNull();

            typeof(TestBaseClass2).FindMethod(nameof(TestBaseClass2.Test5), new[] { typeof(string) })
                .Should().NotBeNull();
            typeof(TestBaseClass2).FindMethod(nameof(TestBaseClass2.Test5), new[] { typeof(string), typeof(string) })
                .Should().NotBeNull();
            typeof(TestBaseClass2).FindMethod(nameof(TestBaseClass2.Test5), new[] { typeof(string), typeof(string), typeof(string) })
                .Should().NotBeNull();
            typeof(TestBaseClass2).FindMethod(nameof(TestBaseClass2.Test5), new[] { typeof(string), typeof(string), typeof(string), typeof(string) })
                .Should().NotBeNull();
            typeof(TestBaseClass2).FindMethod(nameof(TestBaseClass2.Test5), new[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) })
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
            }


        [Fact]
        [TestCategory(UnitTests)]
        public void Test_FullyQualifiedName()
            {
            typeof(TestClass).FullyQualifiedName()
                .Should().Be("L_Tests.Tests.Extensions.ReflectionExtTest.TestClass");
            L.Ref.Member<TestClass>(Test => Test.Test).FullyQualifiedName()
                .Should().Be("L_Tests.Tests.Extensions.ReflectionExtTest.TestClass.Test");

            L.Ref.Method<TestClass>(Test => Test.Test5("")).FullyQualifiedName()
                .Should().Be("L_Tests.Tests.Extensions.ReflectionExtTest.TestClass.Test5");

            typeof(TestBaseClass).FullyQualifiedName()
                .Should().Be("L_Tests.Tests.Extensions.ReflectionExtTest.TestBaseClass");
            L.Ref.Member<TestBaseClass>(Test => Test.Test2).FullyQualifiedName()
                .Should().Be("L_Tests.Tests.Extensions.ReflectionExtTest.TestBaseClass.Test2");

            L.Ref.Method<TestBaseClass>(Test => Test.Test5("")).FullyQualifiedName()
                .Should().Be("L_Tests.Tests.Extensions.ReflectionExtTest.TestBaseClass.Test5");
            }

        [Fact]
        [TestCategory(UnitTests)]
        public void Test_TestMember()
            {
            var Member = new TestMember();
            Member.FullyQualifiedName().Should().Be("");

            Member.MemberType.Should().Be(default(MemberTypes));
            Member.Name.Should().BeNull();
            Member.DeclaringType.Should().BeNull();
            Member.ReflectedType.Should().BeNull();
            Member.GetCustomAttributes(null, false).Should().BeNull();
            Member.GetCustomAttributes(false).Should().BeNull();
            Member.IsDefined(null, false).Should().BeFalse();
            }

        [Fact]
        [TestCategory(UnitTests)]
        public void Test_TestClass()
            {
            var Test = new TestClass { Test = "A" };

            Test.Test.Should().Be("A");
            Test.Test2 = "A";
            Test.Test2.Should().Be("A");
            Test.Test3 = "A";
            Test.Test3.Should().Be("A");
            Test.Test4();
            Test.Test5("");
            Test.Test5("", "");
            Test.Test5("", "", "");
            Test.Test5("", "", "", "");

            var Test2 = new TestBaseClass { Test2 = "A" };

            Test2.Test2.Should().Be("A");
            Test2.Test3 = "A";
            Test2.Test3.Should().Be("A");
            Test2.Test4();
            Test2.Test5("");
            Test2.Test5("", "");
            Test2.Test5("", "", "");
            Test2.Test5("", "", "", "");
            }

        [Fact]
        [TestCategory(UnitTests)]
        public void Test_GetAttribute()
            {
            var Member = L.Ref.Member<TestClass>(Test => Test.Test2);

            Member.GetAttribute<NotMappedAttribute>(true).Should().NotBeNull();
            Member.GetAttribute<NotMappedAttribute>(false).Should().BeNull();

            Member.GetAttribute<KeyAttribute>(true).Should().BeNull();

            Member.GetAttribute<TestedAttribute>().Should().BeNull();

            ((MemberInfo)null).GetAttribute<TestedAttribute>().Should().BeNull();
            ((MemberInfo)null).GetAttribute<TestedAttribute>(false).Should().BeNull();
            }


        [Fact]
        [TestCategory(UnitTests)]
        public void Test_GetAttributes()
            {
            var Member = L.Ref.Method<TestClass>(Test => Test.Test5(""));

            Member.GetAttributes<TestResultAttribute>(true)
                .ShouldBeEquivalentTo(new List<TestResultAttribute>
                    {
                    new TestResultAttribute(new object[] {}, 1),
                    new TestResultAttribute(new object[] {}, 2),
                    new TestResultAttribute(new object[] {}, 3),
                    new TestResultAttribute(new object[] {}, 4)
                    });

            Member.GetAttributes<TestResultAttribute>(false)
                .ShouldBeEquivalentTo(new List<TestResultAttribute>
                    {
                    new TestResultAttribute(new object[] {}, 1),
                    new TestResultAttribute(new object[] {}, 2),
                    new TestResultAttribute(new object[] {}, 3),
                    new TestResultAttribute(new object[] {}, 4)
                    });


            ((MemberInfo)null).GetAttributes<TestResultAttribute>(false)
                .ShouldBeEquivalentTo(new List<TestResultAttribute>());

            new TestMember().GetAttributes<TestResultAttribute>(false)
                .ShouldBeEquivalentTo(new List<TestResultAttribute>());

            }


        /// <exception cref="ArgumentException">Unsupported / unknown attribute provider is passed.</exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [TestCategory(UnitTests)]
        public void Test_GetAttributeTypeName()
            {
            typeof(TestClass).GetAttributeTypeName().Should().Be("L_Tests.Tests.Extensions.ReflectionExtTest+TestClass");
            L.Ref.Member<TestClass>(Class => Class.Test2).GetAttributeTypeName().Should().Be("L_Tests.Tests.Extensions.ReflectionExtTest+TestClass");
            L.Ref.Member<TestBaseClass>(Class => Class.Test2).GetAttributeTypeName().Should().Be("L_Tests.Tests.Extensions.ReflectionExtTest+TestBaseClass");
            L.Ref.Method<TestClass>(Class => Class.Test5("")).GetParameters().FirstOrDefault()
                .GetAttributeTypeName().Should().Be("L_Tests.Tests.Extensions.ReflectionExtTest+TestBaseClass2");

            new AttributeList("name", new Attribute[] { }).GetAttributeTypeName().Should().Be("name");

            L.A(() => new TestClassGeneric1<string>().GetAttributeTypeName()).ShouldFail();

            var Test = new TestClassGeneric1<string>();
            // ReSharper disable ReturnValueOfPureMethodIsNotUsed
            Test.IsDefined(null, false);
            Test.GetCustomAttributes(null, false);
            Test.GetCustomAttributes(false);
            // ReSharper restore ReturnValueOfPureMethodIsNotUsed
            }


        [Fact]
        [TestCategory(UnitTests)]
        public void Test_GetClassHierarchy()
            {
            typeof(TestClass).GetClassHierarchy().Should().Be("ReflectionExtTest.TestClass");

            ((Type)null).GetClassHierarchy().Should().Be("");
            }


        [Fact]
        [TestCategory(UnitTests)]
        public void Test_GetComparer()
            {
            L.Ref.Member<TestClass>(Test => Test.Test2).GetComparer().Should().NotBeNull();
            L.Ref.Member<TestClass>(Test => Test.Test2).GetComparer<string>().Should().NotBeNull();
            L.Ref.Member<TestClass>(Test => Test.Test2).GetComparer<object>().Should().BeNull();
            }


        [Fact]
        [TestCategory(UnitTests)]
        public void Test_GetExtensionMethods()
            {
            typeof(DateExt).GetExtensionMethods().ShouldBeEquivalentTo(new[]
                {
                // ReSharper disable InvokeAsExtensionMethod
                    L.Ref.StaticMethod(() => DateExt.DayOfWeekNumber(default(DayOfWeek))),
                    L.Ref.StaticMethod(() => DateExt.CleanDateString(DateTime.MinValue)),
                    L.Ref.StaticMethod(() => DateExt.ToSpecification(DateTime.MinValue)),
                    L.Ref.StaticMethod(() => DateExt.ToTimeString(new TimeSpan())),
                    L.Ref.StaticMethod(() => DateExt.TimeDifference(DateTime.MinValue, DateTime.MinValue,false)),
                    L.Ref.StaticMethod(() => DateExt.GetMonthName(DateTime.MinValue)),
                    L.Ref.StaticMethod(() => DateExt.IsPast(DateTime.MinValue)),
                    L.Ref.StaticMethod(() => DateExt.IsFuture(DateTime.MinValue)),
                    L.Ref.StaticMethod(() => DateExt.Average(null))
                // ReSharper restore InvokeAsExtensionMethod
                });
            }


        [Fact]
        [TestCategory(UnitTests)]
        public void Test_GetMemberType()
            {
            L.Ref.Member<TestClass>(Test => Test.Test6).GetMemberType()
                .Should().Be(typeof(string));
            L.Ref.Member<TestClass>(Test => Test.Test).GetMemberType()
                .Should().Be(typeof(string));
            L.Ref.Method<TestClass>(Test => Test.Test5("")).GetMemberType()
                .Should().Be(typeof(void));
            L.Ref.Event<TestClass>(nameof(TestClass.Test7)).GetMemberType()
                .Should().Be(typeof(EventHandler));
            }


        [Fact]
        [TestCategory(UnitTests)]
        public void Test_GetSubClass()
            {
            typeof(TestClass).GetSubClass(nameof(TestClass.TestSubClass)).Should().NotBeNull();
            typeof(TestClass).GetSubClass(nameof(TestClass.TestSubClass2)).Should().NotBeNull();
            typeof(TestClass).GetSubClass("abb").Should().BeNull();
            }


        [Fact]
        [TestCategory(UnitTests)]
        public void Test_GetSubClasses()
            {
            typeof(TestClass).GetSubClasses().ShouldBeEquivalentTo(new List<Type>
                {
                typeof(TestClass.TestSubClass),
                typeof(TestClass.TestSubClass2)
                });
            typeof(TestClass.TestSubClass2).GetSubClasses().ShouldBeEquivalentTo(new List<Type>());
            }


        [Fact]
        [TestCategory(UnitTests)]
        public void Test_GetFriendlyTypeName()
            {
            typeof(TestClass).GetFriendlyTypeName().Should().Be("Test2");
            typeof(TestBaseClass).GetFriendlyTypeName().Should().Be("Test");
            typeof(TestBaseClass2).GetFriendlyTypeName().Should().Be("Test Base Class 2");

            typeof(TestClassGeneric2<string, int>).GetFriendlyTypeName().Should().Be("TestClassGeneric2<String, Int32>");

            ((Type)null).GetFriendlyTypeName().Should().Be("");
            }


        /// <exception cref="ArgumentException">If the MemberInfo [In] cannot be found on [Obj].</exception>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [TestCategory(UnitTests)]
        public void Test_GetValue()
            {
            var Test = new TestClass { Test = "a", Test6 = "b" };

            var Member = L.Ref.Member<TestClass>(Class => Class.Test);
            var Member2 = L.Ref.Member<TestClass>(Class => Class.Test6);

            Member.GetValue(Test).Should().Be("a");

            L.A(() => Member.GetValue(null)).ShouldFail();

            Member.GetValue(Test).Should().Be("a");
            Member2.GetValue(Test).Should().Be("b");

            L.A(() => Member.GetValue(null)).ShouldFail();
            }


        [Fact]
        [TestCategory(UnitTests)]
        public void Test_GetValues()
            {
            var Test = new TestClass { Test = "a", Test6 = "b" };

            typeof(TestClass).GetValues<string>(Test).ShouldBeEquivalentTo(new List<string>
                {
                "a",
                "b",
                "6"
                });

            typeof(TestClass).GetMembers().GetValues<string>(Test).ShouldBeEquivalentTo(new List<string>
                {
                "a",
                "b",
                "6"
                });

            var Test2 = new TestClass();

            typeof(TestClass).GetMembers().GetValues<string>(Test2, false).ShouldBeEquivalentTo(new List<string>
                { "6" });
            typeof(TestClass).GetMembers().GetValues<string>(Test2, true).ShouldBeEquivalentTo(new List<string>
                {"","","","","","","","","","","","","","6"});
            }


        /// <exception cref="ArgumentNullException"></exception>
        [Fact]
        [TestCategory(UnitTests)]
        public void Test_GetTypes()
            {
            var Test = new object[] { 0, "a", (double)-3, -5.5f };

            Test.GetTypes().ShouldBeEquivalentTo(new[]
                {
                    typeof(int),
                    typeof(string),
                    typeof(double),
                    typeof(float)
                });

            Test.ToList().GetTypes().ShouldBeEquivalentTo(new List<Type>
                {
                    typeof(int),
                    typeof(string),
                    typeof(double),
                    typeof(float)
                });
            }


        [Fact]
        [TestCategory(UnitTests)]
        public void Test_HasAttribute()
            {
            ((Type)null).HasAttribute<FriendlyNameAttribute>().Should().BeFalse();
            ((Type)null).HasAttribute<FriendlyNameAttribute>(true).Should().BeFalse();
            ((Type)null).HasAttribute(typeof(FriendlyNameAttribute), true).Should().BeFalse();

            typeof(TestClass).HasAttribute<FriendlyNameAttribute>().Should().BeTrue();
            typeof(TestClass).HasAttribute<FriendlyNameAttribute>(true).Should().BeTrue();
            typeof(TestClass).HasAttribute<FriendlyNameAttribute>(false).Should().BeTrue();
            typeof(TestClass).HasAttribute<IFriendlyName>().Should().BeTrue();
            typeof(TestClass).HasAttribute<IFriendlyName>(true).Should().BeTrue();
            typeof(TestClass).HasAttribute<IFriendlyName>(false).Should().BeTrue();
            typeof(TestClass).HasAttribute<TestClassAttribute>(true).Should().BeFalse();
            typeof(TestClass).HasAttribute<TestClassAttribute>(false).Should().BeFalse();

            L.Ref.Member<TestClass>(Test => Test.Test2).HasAttribute<NotMappedAttribute>(false)
                .Should().BeFalse();
            L.Ref.Member<TestClass>(Test => Test.Test2).HasAttribute<NotMappedAttribute>(true)
                .Should().BeTrue();


            typeof(TestClass).HasAttribute(typeof(FriendlyNameAttribute), true).Should().BeTrue();
            typeof(TestClass).HasAttribute(typeof(FriendlyNameAttribute), false).Should().BeTrue();
            typeof(TestClass).HasAttribute(typeof(IFriendlyName), true).Should().BeTrue();
            typeof(TestClass).HasAttribute(typeof(IFriendlyName), false).Should().BeTrue();
            typeof(TestClass).HasAttribute(typeof(TestClassAttribute), true).Should().BeFalse();
            typeof(TestClass).HasAttribute(typeof(TestClassAttribute), false).Should().BeFalse();

            L.Ref.Member<TestClass>(Test => Test.Test2).HasAttribute(typeof(NotMappedAttribute), false)
                .Should().BeFalse();
            L.Ref.Member<TestClass>(Test => Test.Test2).HasAttribute(typeof(NotMappedAttribute), true)
                .Should().BeTrue();
            }


        
        [Fact]
        [TestCategory(UnitTests)]
        public void Test_HasInterface()
            {
            ((Type)null).HasInterface<IFriendlyName>().Should().BeFalse();
            ((Type)null).HasInterface(typeof(IFriendlyName)).Should().BeFalse();

            typeof(TestClass).HasInterface<ITest2>().Should().BeTrue();
            typeof(TestClass).HasInterface(typeof(ITest2)).Should().BeTrue();

            typeof(TestClass).HasInterface<IFriendlyName>().Should().BeFalse();
            typeof(TestClass).HasInterface(typeof(IFriendlyName)).Should().BeFalse();

            typeof(TestClass).HasInterface<ITest>().Should().BeTrue();
            typeof(TestClass).HasInterface(typeof(ITest)).Should().BeTrue();

            // Static types cant have interfaces.
            typeof(TestExt).HasInterface(typeof(ITest)).Should().BeFalse();
            typeof(TestExt).HasInterface<ITest>().Should().BeFalse();

//            typeof(BadStatic).HasInterface(typeof(ITest)).Should().BeFalse();
//            typeof(BadStatic).HasInterface<ITest>().Should().BeFalse();


            }


        /// <exception cref="ArgumentException">If an unknown MemberInfo type is passed.</exception>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [TestCategory(UnitTests)]
        public void Test_HasSetter()
            {
            ((MemberInfo)null).HasSetter().Should().BeFalse();

            L.Ref.Member<TestClass>(Test => Test.Test)
                .Should().NotBeNull().And.Subject.As<MemberInfo>()
                .HasSetter().Should().BeTrue();

            L.Ref.Member<TestClass>(Test => Test.Test2)
                .Should().NotBeNull().And.Subject.As<MemberInfo>()
                .HasSetter().Should().BeTrue();

            L.Ref.Member<TestClass>(Test => Test.Test6)
                .Should().NotBeNull().And.Subject.As<MemberInfo>()
                .HasSetter().Should().BeTrue();

            L.Ref.Constant<TestClass>(nameof(TestClass.Test8))
                .Should().NotBeNull().And.Subject.As<MemberInfo>()
                .HasSetter().Should().BeFalse();

            L.Ref.Member<TestClass>(Test => TestClass.Test9)
                .Should().NotBeNull().And.Subject.As<MemberInfo>()
                .HasSetter().Should().BeTrue();

            L.Ref.Member<TestClass>(Test => TestClass.Test10)
                .Should().NotBeNull().And.Subject.As<MemberInfo>()
                .HasSetter().Should().BeFalse();

            L.Ref.Member<TestClass>(Test => Test.Test11)
                .Should().NotBeNull().And.Subject.As<MemberInfo>()
                .HasSetter().Should().BeFalse();

            L.Ref.Member<TestClass>(Test => Test.Test12)
                .Should().NotBeNull().And.Subject.As<MemberInfo>()
                .HasSetter().Should().BeFalse();

            L.Ref.Member<TestClass>(Test => Test.Test13)
                .Should().NotBeNull().And.Subject.As<MemberInfo>()
                .HasSetter().Should().BeFalse();

            L.Ref.Method<TestClass>(Test => Test.Test5(""))
                .Should().NotBeNull().And.Subject.As<MemberInfo>()
                .HasSetter().Should().BeFalse();

            L.Ref.Event<TestClass>(nameof(TestClass.Test7))
                .Should().NotBeNull().And.Subject.As<MemberInfo>()
                .HasSetter().Should().BeFalse();

            L.A(() => new TestMember().HasSetter()).ShouldFail();
            }


        [Fact]
        [TestCategory(UnitTests)]
        public void Test_InstantiateValues()
            {
            var Test = new TestClass { Test = "a", Test6 = "b" };

            typeof(TestClass).GetValues<object>(Test).ShouldBeEquivalentTo(new List<object>
                {
                "a",
                "b",
                "6"
                });

            typeof(TestClass).InstantiateValues<string>(Test, false);
            typeof(TestClass).InstantiateValues<TestClass>(Test, false);
            typeof(TestClass).GetValues<object>(Test).ShouldBeEquivalentTo(new List<object>
                {
                "a",
                "b",
                "6"
                });


            Test = new TestClass { Test = "a", Test6 = "b" };

            typeof(TestClass).InstantiateValues<string>(Test, true);
            typeof(TestClass).InstantiateValues<TestClass>(Test, true);
            typeof(TestClass).GetValues<object>(Test).ShouldBeEquivalentTo(new List<object>
                {
                "a",
                "b",
                "6",
                "",
                "",
                "",
                new TestClass()
                });

            Test = new TestClass { Test = "a", Test6 = "b" };

            typeof(TestClass).GetMembers().InstantiateValues<string>(Test);
            typeof(TestClass).GetMembers().InstantiateValues<TestClass>(Test);
            typeof(TestClass).GetValues<object>(Test).ShouldBeEquivalentTo(new List<object>
                {
                "a",
                "b",
                "6",
                "",
                "",
                "",
                new TestClass()
                });
            }


        [Fact]
        [TestCategory(UnitTests)]
        public void Test_IsType()
            {
            ((object)null).IsType<object>().Should().BeFalse();
            ((object)null).IsType(typeof(object)).Should().BeFalse();

            "".IsType<string>().Should().BeTrue();
            "".IsType(typeof(string)).Should().BeTrue();
            "".IsType<object>().Should().BeTrue();
            "".IsType(typeof(object)).Should().BeTrue();
            "".IsType<IConvertible>().Should().BeTrue();
            "".IsType(typeof(IConvertible)).Should().BeTrue();

            typeof(string).IsType<string>().Should().BeTrue();
            typeof(string).IsType<IConvertible>().Should().BeTrue();
            typeof(string).IsType<char>().Should().BeFalse();
            typeof(string).IsType(typeof(string)).Should().BeTrue();
            typeof(string).IsType(typeof(IConvertible)).Should().BeTrue();
            typeof(string).IsType(typeof(char)).Should().BeFalse();

            typeof(TestClass).IsType<TestBaseClass>().Should().BeTrue();
            typeof(TestClass).IsType<TestBaseClass2>().Should().BeTrue();
            typeof(TestClass).IsType<object>().Should().BeTrue();
            typeof(TestClass).IsType<string>().Should().BeFalse();
            }


        [Fact]
        [TestCategory(UnitTests)]
        public void Test_Members()
            {
            typeof(TestClass).MembersOfType(typeof(string)).ShouldBeEquivalentTo(new List<MemberInfo>
                {
                L.Ref.Member<TestClass>(Test=>Test.Test),
                L.Ref.Member<TestClass>(Test=>Test.Test2),
                L.Ref.Member<TestClass>(Test=>Test.Test3),
                L.Ref.Member<TestClass>(Test=>Test.Test11),
                L.Ref.Member<TestClass>(Test=>Test.Test12),
                L.Ref.Member<TestClass>(Test=>Test.Test13),
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                L.Ref.Method<TestClass>(Test=>Test.ToString()),
                L.Ref.Member<TestClass>(Test=>Test.Test6)
                });

            typeof(TestClass).MembersOfType(typeof(string), false).ShouldBeEquivalentTo(new List<MemberInfo>());
            typeof(TestClass).MembersOfType(typeof(string), true).ShouldBeEquivalentTo(new List<MemberInfo>
                {
                L.Ref.Member<TestClass>(Test=>Test.Test),
                L.Ref.Member<TestClass>(Test=>Test.Test2),
                L.Ref.Member<TestClass>(Test=>Test.Test3),
                L.Ref.Member<TestClass>(Test=>Test.Test11),
                L.Ref.Member<TestClass>(Test=>Test.Test12),
                L.Ref.Member<TestClass>(Test=>Test.Test13),
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                L.Ref.Method<TestClass>(Test=>Test.ToString()),
                L.Ref.Member<TestClass>(Test=>Test.Test6)
                });
            }

        /// <exception cref="ArgumentException">If an unknown MemberInfo type is passed.</exception>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [TestCategory(UnitTests)]
        public void Test_MemberType()
            {
            /*
            typeof(TestClass).GetMembers().Convert(m => m.Name)
                .ShouldBeEquivalentTo(new List<string>
                    {
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    ""
                    });*/

            typeof(TestClass).GetMembers().Convert(Member => Member.MemberType())
                .ShouldBeEquivalentTo(new List<Type>
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
                });

            L.A(() => new TestMember().MemberType()).ShouldFail();
            }


        /// <exception cref="InvalidOperationException">The object could not be created, constructor was not found.</exception>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [TestCategory(UnitTests)]
        public void Test_New()
            {
            typeof(string).New<string>().Should().Be("");

            L.Ref.New<TestClass>().ShouldBeEquivalentTo(new TestClass());
            L.Ref.New<TestClassGeneric1<string>>().ShouldBeEquivalentTo(new TestClassGeneric1<string>());
            L.Ref.New<TestClassGeneric1<int>>().ShouldBeEquivalentTo(new TestClassGeneric1<int>());
            L.Ref.New<TestClassGeneric2<string, int>>("a").ShouldBeEquivalentTo(new TestClassGeneric2<string, int>("a"));

            typeof(TestClassGeneric2<,>).New(new object[] { "a" }, typeof(TestClassGeneric2<string, int>))
                .ShouldBeEquivalentTo(new TestClassGeneric2<string, int>("a"));

            typeof(TestClassGeneric2<,>).New(new object[] { "a" }, typeof(TestClassGeneric2<int, int>))
                .ShouldBeEquivalentTo(new TestClassGeneric2<int, int>("a"));

            L.A(() => typeof(TestClassGeneric2<,>).New(new object[] { "a", "a" }, typeof(TestClassGeneric2<int, int>)))
                .ShouldFail();

            L.A(() => typeof(TestClassGeneric2<,>).New(new object[] { "a", "a", "a" }, typeof(TestClassGeneric2<int, int>)))
                .ShouldFail();
            }


        /// <exception cref="ArgumentException">If the MemberInfo [In] was not found on Obj.</exception>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [TestCategory(UnitTests)]
        public void Test_SetValue()
            {
            var Test = new TestClass();

            var Member1 = L.Ref.Member<TestClass>(Class => Class.Test);
            var Member2 = L.Ref.Member<TestClass>(Class => Class.Test6);

            Member1.SetValue(Test, "a");
            Member2.SetValue(Test, "b");

            Test.Test.Should().Be("a");
            Test.Test6.Should().Be("b");

            L.A(() => Member2.SetValue(null, "a")).ShouldFail();
            }


        [Fact]
        [TestCategory(UnitTests)]
        public void Test_ToInvocationSignature()
            {
            // ReSharper disable once InvokeAsExtensionMethod
            L.Ref.StaticMethod(() => DateExt.IsFuture(DateTime.MinValue)).ToInvocationSignature().Should().Be("[DateTime].IsFuture() => Boolean");
            L.Ref.Method<TestClass>(Test => Test.Test5("")).ToInvocationSignature().Should().Be("[ReflectionExtTest.TestBaseClass2].Test5(String)");
            L.Ref.StaticMethod(() => L.Ref.FindType("")).ToInvocationSignature().Should().Be("L.Ref.FindType(String) => Type");

            ((MethodInfo)null).ToInvocationSignature().Should().Be("");
            }


        [Fact]
        [TestCategory(UnitTests)]
        public void Test_TypeEquals()
            {
            Type Test1 = null;
            var Test2 = typeof(string);
            var Test3 = typeof(TestClass);
            var Test4 = typeof(TestBaseClass);

            // ReSharper disable once ExpressionIsAlwaysNull
            Test1.TypeEquals(null).Should().BeFalse();
            Test2.TypeEquals(null).Should().BeFalse();
            Test2.TypeEquals(Test2).Should().BeTrue();
            Test3.TypeEquals(Test3).Should().BeTrue();
            Test4.TypeEquals(Test4).Should().BeTrue();
            Test3.TypeEquals(Test4).Should().BeFalse();
            Test4.TypeEquals(Test3).Should().BeFalse();
            }


        [Fact]
        [TestCategory(UnitTests)]
        public void Test_WithAttribute()
            {
            ((MemberInfo[])null).WithAttribute<NotMappedAttribute>().ShouldBeEquivalentTo(new List<MemberInfo>());

            typeof(TestClass).GetMembers().WithAttribute<NotMappedAttribute>().ShouldBeEquivalentTo(new List<MemberInfo>
                {
                L.Ref.Member<TestClass>(Test=>Test.Test),
                L.Ref.Member<TestClass>(Test=>Test.Test2)
                });
            typeof(TestClass).GetMembers().WithAttribute<ITestAttribute>().ShouldBeEquivalentTo(new List<MemberInfo>
                {
                L.Ref.Method<TestClass>(Test=>Test.Test5(""))
                });


            ((MemberInfo[])null).WithAttribute(typeof(NotMappedAttribute)).ShouldBeEquivalentTo(new List<MemberInfo>());

            typeof(TestClass).GetMembers().WithAttribute(typeof(NotMappedAttribute)).ShouldBeEquivalentTo(new List<MemberInfo>
                {
                L.Ref.Member<TestClass>(Test=>Test.Test),
                L.Ref.Member<TestClass>(Test=>Test.Test2)
                });
            typeof(TestClass).GetMembers().WithAttribute(typeof(ITestAttribute)).ShouldBeEquivalentTo(new List<MemberInfo>
                {
                L.Ref.Method<TestClass>(Test=>Test.Test5(""))
                });
            }

        [Fact]
        [TestCategory(UnitTests)]
        public void Test_WithoutAttribute()
            {
            ((MemberInfo[])null).WithoutAttribute<NotMappedAttribute>().ShouldBeEquivalentTo(new List<MemberInfo>());

            typeof(TestClass).GetMembers().Select(Member => !(Member is MethodInfo && ((MethodInfo)Member).IsSpecialName))
                .WithoutAttribute<NotMappedAttribute>().ShouldBeEquivalentTo(new List<MemberInfo>
                {
                L.Ref.Method<TestClass>(Test=>Test.Test4()),
                L.Ref.Method<TestClass>(Test=>Test.Test5("")),
                L.Ref.Method<TestClass>(Test=>Test.Test5("","")),
                L.Ref.Method<TestClass>(Test=>Test.Test5("","","")),
                L.Ref.Method<TestClass>(Test=>Test.Test5("","","","")),
                // ReSharper disable ReturnValueOfPureMethodIsNotUsed
                L.Ref.Method<TestClass>(Test=>Test.ToString()),
                L.Ref.Method<TestClass>(Test=>Test.Equals(null)),
                L.Ref.Method<TestClass>(Test=>Test.GetHashCode()),
                L.Ref.Method<TestClass>(Test=>Test.GetType()),
                // ReSharper restore ReturnValueOfPureMethodIsNotUsed
                // ReSharper disable once ObjectCreationAsStatement
                L.Ref.Constructor(()=>new TestClass()),
                L.Ref.Member<TestClass>(Test=>Test.Test3),
                L.Ref.Member<TestClass>(Test=>Test.Test11),
                L.Ref.Member<TestClass>(Test=>Test.Test12),
                L.Ref.Member<TestClass>(Test=>Test.Test13),
                L.Ref.Member<TestClass>(Test=>Test.Test14),
                L.Ref.Event<TestClass>(nameof(TestClass.Test7)),
                L.Ref.Member<TestClass>(Test=>Test.Test6)
                });
            typeof(TestClass).GetMembers().Select(Member => !(Member is MethodInfo && ((MethodInfo)Member).IsSpecialName))
                .WithoutAttribute<ITestAttribute>().ShouldBeEquivalentTo(new List<MemberInfo>
                    {
                    L.Ref.Method<TestClass>(Test=>Test.Test4()),
                    L.Ref.Method<TestClass>(Test=>Test.Test5("","")),
                    L.Ref.Method<TestClass>(Test=>Test.Test5("","","")),
                    L.Ref.Method<TestClass>(Test=>Test.Test5("","","","")),
                    // ReSharper disable ReturnValueOfPureMethodIsNotUsed
                    L.Ref.Method<TestClass>(Test=>Test.ToString()),
                    L.Ref.Method<TestClass>(Test=>Test.Equals(null)),
                    L.Ref.Method<TestClass>(Test=>Test.GetHashCode()),
                    L.Ref.Method<TestClass>(Test=>Test.GetType()),
                    // ReSharper restore ReturnValueOfPureMethodIsNotUsed
                    // ReSharper disable once ObjectCreationAsStatement
                    L.Ref.Constructor(()=>new TestClass()),
                    L.Ref.Member<TestClass>(Test=>Test.Test3),
                    L.Ref.Member<TestClass>(Test=>Test.Test11),
                    L.Ref.Member<TestClass>(Test=>Test.Test12),
                    L.Ref.Member<TestClass>(Test=>Test.Test13),
                    L.Ref.Member<TestClass>(Test=>Test.Test14),
                    L.Ref.Event<TestClass>(nameof(TestClass.Test7)),
                    L.Ref.Member<TestClass>(Test=>Test.Test6),
                    L.Ref.Member<TestClass>(Test=>Test.Test2),
                    L.Ref.Member<TestClass>(Test=>Test.Test)
                    });


            ((MemberInfo[])null).WithoutAttribute(typeof(NotMappedAttribute)).ShouldBeEquivalentTo(new List<MemberInfo>());

            typeof(TestClass).GetMembers().Select(Member => !(Member is MethodInfo && ((MethodInfo)Member).IsSpecialName))
                .WithoutAttribute(typeof(NotMappedAttribute)).ShouldBeEquivalentTo(new List<MemberInfo>
                    {
                    L.Ref.Method<TestClass>(Test=>Test.Test4()),
                    L.Ref.Method<TestClass>(Test=>Test.Test5("")),
                    L.Ref.Method<TestClass>(Test=>Test.Test5("","")),
                    L.Ref.Method<TestClass>(Test=>Test.Test5("","","")),
                    L.Ref.Method<TestClass>(Test=>Test.Test5("","","","")),
                    // ReSharper disable ReturnValueOfPureMethodIsNotUsed
                    L.Ref.Method<TestClass>(Test=>Test.ToString()),
                    L.Ref.Method<TestClass>(Test=>Test.Equals(null)),
                    L.Ref.Method<TestClass>(Test=>Test.GetHashCode()),
                    L.Ref.Method<TestClass>(Test=>Test.GetType()),
                    // ReSharper restore ReturnValueOfPureMethodIsNotUsed
                    // ReSharper disable once ObjectCreationAsStatement
                    L.Ref.Constructor(()=>new TestClass()),
                    L.Ref.Member<TestClass>(Test=>Test.Test3),
                    L.Ref.Member<TestClass>(Test=>Test.Test11),
                    L.Ref.Member<TestClass>(Test=>Test.Test12),
                    L.Ref.Member<TestClass>(Test=>Test.Test13),
                    L.Ref.Member<TestClass>(Test=>Test.Test14),
                    L.Ref.Event<TestClass>(nameof(TestClass.Test7)),
                    L.Ref.Member<TestClass>(Test=>Test.Test6)
                    });
            typeof(TestClass).GetMembers().Select(Member => !(Member is MethodInfo && ((MethodInfo)Member).IsSpecialName))
                .WithoutAttribute(typeof(ITestAttribute)).ShouldBeEquivalentTo(new List<MemberInfo>
                    {
                    L.Ref.Method<TestClass>(Test=>Test.Test4()),
                    L.Ref.Method<TestClass>(Test=>Test.Test5("","")),
                    L.Ref.Method<TestClass>(Test=>Test.Test5("","","")),
                    L.Ref.Method<TestClass>(Test=>Test.Test5("","","","")),
                    // ReSharper disable ReturnValueOfPureMethodIsNotUsed
                    L.Ref.Method<TestClass>(Test=>Test.ToString()),
                    L.Ref.Method<TestClass>(Test=>Test.Equals(null)),
                    L.Ref.Method<TestClass>(Test=>Test.GetHashCode()),
                    L.Ref.Method<TestClass>(Test=>Test.GetType()),
                    // ReSharper restore ReturnValueOfPureMethodIsNotUsed
                    // ReSharper disable once ObjectCreationAsStatement
                    L.Ref.Constructor(()=>new TestClass()),
                    L.Ref.Member<TestClass>(Test=>Test.Test3),
                    L.Ref.Member<TestClass>(Test=>Test.Test11),
                    L.Ref.Member<TestClass>(Test=>Test.Test12),
                    L.Ref.Member<TestClass>(Test=>Test.Test13),
                    L.Ref.Member<TestClass>(Test=>Test.Test14),
                    L.Ref.Event<TestClass>(nameof(TestClass.Test7)),
                    L.Ref.Member<TestClass>(Test=>Test.Test6),
                    L.Ref.Member<TestClass>(Test=>Test.Test2),
                    L.Ref.Member<TestClass>(Test=>Test.Test)
                    });
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
            }
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
        internal class TestClass : TestBaseClass, ITest2
            {
            [NotMapped]
            public string Test { get; set; }

            public override string Test2 { get; set; }
            }

        [FriendlyName("Test")]
        internal class TestBaseClass : TestBaseClass2, ITest
            {
            [NotMapped]
            public virtual string Test2 { get; set; }
            }
        internal class TestBaseClass2
            {
            public string Test3 { get; set; }

#pragma warning disable 649
            public string Test6;
#pragma warning restore 649

            public void Test4()
                {
                this.Test13 = this.Test13;
                }

            [TestResult(new object[] { }, 1)]
            [TestResult(new object[] { }, 2)]
            [TestResult(new object[] { }, 3)]
            [TestResult(new object[] { }, 4)]
            public void Test5(string Str)
                {

                }
            public void Test5(string Str, string Str2)
                {
                }
            public void Test5(string Str, string Str2, string Str3)
                {
                }
            public void Test5(string Str, string Str2, string Str3, string Str4)
                {
                }

            public event EventHandler Test7;

            public const string Test8 = "a";
            public static string Test9 = "a";
            public static readonly string Test10 = "a";
            public string Test11 { get; }
            public string Test12 { get; protected set; }
            public string Test13 { get; private set; } = "6";

            public TestClass Test14 { get; set; }

            public class TestSubClass
                {

                }
            public class TestSubClass2
                {
                }
            }

        internal interface ITest { }

        internal interface ITest2 { }

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
