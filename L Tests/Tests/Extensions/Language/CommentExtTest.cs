
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using LCore.Tools;
using static LCore.Extensions.L.Test.Categories;
// ReSharper disable ReturnValueOfPureMethodIsNotUsed

// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable ConvertToConstant.Local

namespace L_Tests.Tests.Extensions
    {

    [TestClass]
    public class CommentExtTest : ExtensionTester
        {
        protected override Type[] TestType => new[] { typeof(CommentExt) };
        
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_GetComments()
            {
            // ReSharper disable once RedundantAssignment
            var Comments = typeof(L.Comment).GetComments();

            // Test xml member cache
            Comments = typeof(L.Comment).GetComments();

            Comments.Summary.ShouldBeEquivalentTo(@"
            Contains values and test members for CommentExt
            ");


            var Comments2 = typeof(L.Comment.Test).GetMember(nameof(L.Comment.Test.TestMethod)).FirstOrDefault().GetComments();

            Comments2.Summary.ShouldBeEquivalentTo(@"
            Test class
            ");
            Comments2.Returns.Should().Be("Returns");
            Comments2.Value.Should().Be("value");
            Comments2.Remarks.Should().Be("Remark");
            Comments2.Examples.ShouldBeEquivalentTo(new[] { "some code", "more code" });
            Comments2.Parameters.ShouldBeEquivalentTo(
                new[]
                    {
                        new Set<string, string>("A", "param1"),
                        new Set<string, string>("B", "param2")
                    }
                );
            Comments2.Exceptions.ShouldBeEquivalentTo(
                new[]
                    {
                        new Set<string, string>("T:System.Exception", "exception 1"),
                        new Set<string, string>("T:System.ArgumentException", "exception 2")
                    }
                );
            Comments2.Permissions.ShouldBeEquivalentTo(
                new[]
                    {
                        new Set<string, string>("T:System.Security.PermissionSet", "permission 1"),
                        new Set<string, string>("T:System.Security.CodeAccessPermission", "permission 2")
                    }
                );
            Comments2.TypeParameters.ShouldBeEquivalentTo(
                new[]
                    {
                        new Set<string, string>("T", "Type")
                    }
                );
            Comments2.Includes.ShouldBeEquivalentTo(new Set<string, string>[] { });

            var Comments3 = typeof(L.Comment.Test).GetMember(nameof(L.Comment.Test.TestProperty)).FirstOrDefault().GetComments();

            Comments3.Summary.ShouldBeEquivalentTo(@"
            TestProperty 
            ");

            var Comments4 = typeof(L.Comment.Test).GetMember(nameof(L.Comment.Test.TestField)).FirstOrDefault().GetComments();

            Comments4.Summary.ShouldBeEquivalentTo(@"
            TestField
            ");

            typeof(CommentExtTest).GetComments().Should().BeNull();

            var Test = new TestInvalidMemberInfo();
            Test.GetCustomAttributes(false).Should().BeNull();
            Test.IsDefined(null, false).Should().BeFalse();
            Test.GetCustomAttributes(null, false).Should().BeNull();
            Test.MemberType.Should().Be(default(MemberTypes));
            Test.Name.Should().BeNull();
            Test.DeclaringType.Should().BeNull();
            Test.ReflectedType.Should().BeNull();

            Test.GetComments().Should().BeNull();
            }

        private class TestInvalidMemberInfo : MemberInfo
            {
            public override object[] GetCustomAttributes(bool Inherit)
                {
                return null;
                }
            public override bool IsDefined(Type AttributeType, bool Inherit)
                {
                return false;
                }
            public override object[] GetCustomAttributes(Type AttributeType, bool Inherit)
                {
                return null;
                }

            // ReSharper disable UnassignedGetOnlyAutoProperty
            public override MemberTypes MemberType { get; }
            public override string Name { get; }
            public override Type DeclaringType { get; }
            public override Type ReflectedType { get; }
            // ReSharper restore UnassignedGetOnlyAutoProperty
            }
        }
    }

