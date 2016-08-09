using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt))]
    public partial class ReflectionExtTester : XUnitOutputTester
        {
        public ReflectionExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~ReflectionExtTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.AlsoBaseTypes))]
        public void AlsoBaseTypes()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.AlsoBaseTypes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.BaseTypes))]
        public void BaseTypes()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.BaseTypes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.CanBeNull))]
        public void CanBeNull()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.CanBeNull
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.FindMethod))]
        public void FindMethod_Type_String_Type_MethodInfo()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.FindMethod
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.FindMethod))]
        public void FindMethod_Type_String_MethodInfo()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.FindMethod
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.FullyQualifiedName))]
        public void FullyQualifiedName_MemberInfo_String()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.FullyQualifiedName
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.FullyQualifiedName))]
        public void FullyQualifiedName_ParameterInfo_String()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.FullyQualifiedName
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetAssembly))]
        public void GetAssembly()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetAssembly
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetAttribute))]
        public void GetAttribute_ICustomAttributeProvider_T()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetAttribute
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetAttribute))]
        public void GetAttribute_ICustomAttributeProvider_Boolean_T()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetAttribute
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetAttributes))]
        public void GetAttributes()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetAttributes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetAttributeTypeName))]
        public void GetAttributeTypeName()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetAttributeTypeName
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetClassHierarchy))]
        public void GetClassHierarchy()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetClassHierarchy
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetComparer))]
        public void GetComparer_MemberInfo_IComparer()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetComparer
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetComparer))]
        public void GetComparer_MemberInfo_IComparer_1()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetComparer
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetExtensionMethods))]
        public void GetExtensionMethods()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetExtensionMethods
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetMemberType))]
        public void GetMemberType()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetMemberType
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetNamespace))]
        public void GetNamespace()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetNamespace
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetNestedNames))]
        public void GetNestedNames()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetNestedNames
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetSubClass))]
        public void GetSubClass()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetSubClass
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetSubClasses))]
        public void GetSubClasses()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetSubClasses
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetFriendlyTypeName))]
        public void GetFriendlyTypeName()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetFriendlyTypeName
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetValue))]
        public void GetValue()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetValues))]
        public void GetValues_Type_Object_Boolean_List_1()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetValues
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetValues))]
        public void GetValues_IEnumerable_1_Object_Boolean_List_1()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetValues
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetTypes))]
        public void GetTypes_IEnumerable_1_List_1()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetTypes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetTypes))]
        public void GetTypes_T_Type()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetTypes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.HasAttribute))]
        public void HasAttribute_ICustomAttributeProvider_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.HasAttribute
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.HasAttribute))]
        public void HasAttribute_ICustomAttributeProvider_Boolean_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.HasAttribute
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.HasAttribute))]
        public void HasAttribute_ICustomAttributeProvider_Type_Boolean_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.HasAttribute
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.HasInterface))]
        public void HasInterface_Type_Type_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.HasInterface
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.HasInterface))]
        public void HasInterface_Type_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.HasInterface
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.HasIndexGetter))]
        public void HasIndexGetter_Type_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.HasIndexGetter
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.HasIndexSetter))]
        public void HasIndexSetter_Type_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.HasIndexSetter
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.HasSetter))]
        public void HasSetter()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.HasSetter
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.IndexGetter))]
        public void IndexGetter_Type_PropertyInfo()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.IndexGetter
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.IndexSetter))]
        public void IndexSetter_Type_PropertyInfo()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.IndexSetter
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.InstantiateValues))]
        public void InstantiateValues_Type_Object_Boolean_List_1()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.InstantiateValues
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.InstantiateValues))]
        public void InstantiateValues_IEnumerable_1_Object_List_1()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.InstantiateValues
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.IsExtensionMethod))]
        public void IsExtensionMethod()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.IsExtensionMethod
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.IsNullable))]
        public void IsNullable()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.IsNullable
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.IsOperator))]
        public void IsOperator()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.IsOperator
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.IsType))]
        public void IsType_Object_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.IsType
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.IsType))]
        public void IsType_Object_Type_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.IsType
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.IsType))]
        public void IsType_Type_Type_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.IsType
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.IsType))]
        public void IsType_Type_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.IsType
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.IsStatic))]
        public void IsStatic()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.IsStatic
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.MembersOfType))]
        public void MembersOfType()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.MembersOfType
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.MemberType))]
        public void MemberType()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.MemberType
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.New))]
        public void New_Type_Object_T()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.New
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.New))]
        public void New_Type_Object_Type_Object()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.New
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.NewRandom))]
        public void NewRandom()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.NewRandom
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.SetValue))]
        public void SetValue()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.SetValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.ToInvocationSignature))]
        public void ToInvocationSignature()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.ToInvocationSignature
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.TypeEquals))]
        public void TypeEquals()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.TypeEquals
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.WithAttribute))]
        public void WithAttribute_IEnumerable_1_Boolean_List_1()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.WithAttribute
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.WithAttribute))]
        public void WithAttribute_IEnumerable_1_Type_Boolean_List_1()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.WithAttribute
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.WithoutAttribute))]
        public void WithoutAttribute_IEnumerable_1_Boolean_List_1()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.WithoutAttribute
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.WithoutAttribute))]
        public void WithoutAttribute_IEnumerable_1_Type_Boolean_List_1()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.WithoutAttribute
            }

        }
    }