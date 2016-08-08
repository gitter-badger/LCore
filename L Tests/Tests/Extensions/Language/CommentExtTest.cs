﻿using LCore.Extensions;
using System;
using System.Reflection;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.LUnit;
using LCore.Tools;
using Xunit;
using Xunit.Abstractions;
using static LCore.LUnit.LUnit.Categories;
// ReSharper disable PossibleNullReferenceException

// ReSharper disable ReturnValueOfPureMethodIsNotUsed

// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable ConvertToConstant.Local

namespace LCore.Tests.Extensions
    {
    [Trait(Category, UnitTests)]
    public class CommentExtTest : XUnitOutputTester
        {
        [Fact]
        public void Test_GetComments()
            {
            // ReSharper disable once RedundantAssignment
            var Comments = typeof(L.Comment).GetComments();

            // Test xml member cache
            Comments = typeof(L.Comment).GetComments();

            Comments.Summary.Should().Be(@"
            Contains values and test members for CommentExt
            ");


            var Comments2 = typeof(L.Comment.Test).GetMember(nameof(L.Comment.Test.TestMethod)).First().GetComments();

            Comments2.Summary.Should().Be(@"
            Test class
            ");
            Comments2.Returns.Should().Be("Returns");
            Comments2.Value.Should().Be("value");
            Comments2.Remarks.Should().Be("Remark");
            Comments2.Examples.Should().Equal("some code", "more code");
            Comments2.Parameters.Should().Equal(
                new Set<string, string>("A", "param1"),
                new Set<string, string>("B", "param2"));
            Comments2.Exceptions.Should().Equal(
                new Set<string, string>("T:System.Exception", "exception 1"),
                new Set<string, string>("T:System.ArgumentException", "exception 2"));
            Comments2.Permissions.Should().Equal(
                new Set<string, string>("T:System.Security.PermissionSet", "permission 1"),
                new Set<string, string>("T:System.Security.CodeAccessPermission", "permission 2"));
            Comments2.TypeParameters.Should().Equal(new Set<string, string>("T", "Type"));

            var Comments3 = typeof(L.Comment.Test).GetMember(nameof(L.Comment.Test.TestProperty)).First().GetComments();

            Comments3.Summary.Should().Be(@"
            TestProperty 
            ");

            var Comments4 = typeof(L.Comment.Test).GetMember(nameof(L.Comment.Test.TestField)).First().GetComments();

            Comments4.Summary.Should().Be(@"
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

            var Comments5 = typeof(L.Comment.Test).GetMember(nameof(L.Comment.Test.TestMethod2)).First().GetComments();
            Comments5.Includes.Should().Equal(new Set<string, string>("filepath", "[@name=\"filename\"]"));
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

        public CommentExtTest([NotNull] ITestOutputHelper Output) : base(Output) { }
        }
    }