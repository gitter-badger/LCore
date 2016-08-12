using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt))]
    public partial class ReflectionExtTester : XUnitOutputTester, IDisposable
        {
        public ReflectionExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.AlsoBaseTypes) + "(Type) => List`1<Type>")]
        public void AlsoBaseTypes()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.AlsoBaseTypes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.BaseTypes) + "(Type) => List`1<Type>")]
        public void BaseTypes()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.BaseTypes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.CanBeNull) + "(ParameterInfo) => Boolean")]
        public void CanBeNull()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.CanBeNull
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.FindMethod) + "(Type, String, Type[]) => MethodInfo")]
        public void FindMethod_Type_String_Type_MethodInfo()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.FindMethod
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.FindMethod) + "(Type, String) => MethodInfo")]
        public void FindMethod_Type_String_MethodInfo()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.FindMethod
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.FullyQualifiedName) + "(MemberInfo) => String")]
        public void FullyQualifiedName_MemberInfo_String()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.FullyQualifiedName
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.FullyQualifiedName) + "(ParameterInfo) => String")]
        public void FullyQualifiedName_ParameterInfo_String()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.FullyQualifiedName
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetAssembly) + "(MemberInfo) => Assembly")]
        public void GetAssembly()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetAssembly
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetAttribute) + "(ICustomAttributeProvider) => T")]
        public void GetAttribute_ICustomAttributeProvider_T()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetAttribute) + "(ICustomAttributeProvider, Boolean) => T")]
        public void GetAttribute_ICustomAttributeProvider_Boolean_T()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetAttribute
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetAttributes) + "(ICustomAttributeProvider, Boolean) => List`1<T>")]
        public void GetAttributes()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetAttributes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetAttributeTypeName) + "(ICustomAttributeProvider) => String")]
        public void GetAttributeTypeName()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetAttributeTypeName
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetClassHierarchy) + "(Type) => String")]
        public void GetClassHierarchy()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetClassHierarchy
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetComparer) + "(MemberInfo) => IComparer")]
        public void GetComparer_MemberInfo_IComparer()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetComparer
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetComparer) + "(MemberInfo) => IComparer`1<T>")]
        public void GetComparer_MemberInfo_IComparer_1_T()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetComparer
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetExtensionMethods) + "(Type) => MethodInfo[]")]
        public void GetExtensionMethods()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetExtensionMethods
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetMemberType) + "(MemberInfo) => Type")]
        public void GetMemberType()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetMemberType
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetNamespace) + "(MemberInfo) => String")]
        public void GetNamespace()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetNamespace
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetNestedNames) + "(Type) => String")]
        public void GetNestedNames()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetNestedNames
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetSubClass) + "(Type, String) => Type")]
        public void GetSubClass()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetSubClass
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetSubClasses) + "(Type) => List`1<Type>")]
        public void GetSubClasses()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetSubClasses
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetFriendlyTypeName) + "(Type) => String")]
        public void GetFriendlyTypeName()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetFriendlyTypeName
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetValue) + "(MemberInfo, Object) => Object")]
        public void GetValue()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetValues) + "(Type, Object, Boolean) => List`1<T>")]
        public void GetValues_Type_Object_Boolean_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetValues
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetValues) + "(IEnumerable`1<MemberInfo>, Object, Boolean) => List`1<T>")]
        public void GetValues_IEnumerable_1_MemberInfo_Object_Boolean_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetValues
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetTypes) + "(IEnumerable`1<T>) => List`1<Type>")]
        public void GetTypes_IEnumerable_1_T_List_1_Type()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetTypes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetTypes) + "(T[]) => Type[]")]
        public void GetTypes_T_Type()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetTypes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.HasAttribute) + "(ICustomAttributeProvider) => Boolean")]
        public void HasAttribute_ICustomAttributeProvider_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.HasAttribute
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.HasAttribute) + "(ICustomAttributeProvider, Boolean) => Boolean")]
        public void HasAttribute_ICustomAttributeProvider_Boolean_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.HasAttribute
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.HasAttribute) + "(ICustomAttributeProvider, Type, Boolean) => Boolean")]
        public void HasAttribute_ICustomAttributeProvider_Type_Boolean_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.HasAttribute
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.HasInterface) + "(Type, Type) => Boolean")]
        public void HasInterface_Type_Type_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.HasInterface
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.HasInterface) + "(Type) => Boolean")]
        public void HasInterface_Type_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.HasInterface
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.HasIndexGetter) + "(Type) => Boolean")]
        public void HasIndexGetter_Type_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.HasIndexGetter
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.HasIndexSetter) + "(Type) => Boolean")]
        public void HasIndexSetter_Type_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.HasIndexSetter
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.HasSetter) + "(MemberInfo) => Boolean")]
        public void HasSetter()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.HasSetter
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.IndexGetter) + "(Type) => PropertyInfo")]
        public void IndexGetter_Type_PropertyInfo()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.IndexGetter
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.IndexSetter) + "(Type) => PropertyInfo")]
        public void IndexSetter_Type_PropertyInfo()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.IndexSetter
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.InstantiateValues) + "(Type, Object, Boolean) => List`1<T>")]
        public void InstantiateValues_Type_Object_Boolean_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.InstantiateValues
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.InstantiateValues) + "(IEnumerable`1<MemberInfo>, Object) => List`1<T>")]
        public void InstantiateValues_IEnumerable_1_MemberInfo_Object_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.InstantiateValues
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.IsExtensionMethod) + "(MethodInfo) => Boolean")]
        public void IsExtensionMethod()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.IsExtensionMethod
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.IsNullable) + "(Type) => Boolean")]
        public void IsNullable()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.IsNullable
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.IsOperator) + "(MethodInfo) => Boolean")]
        public void IsOperator()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.IsOperator
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.IsType) + "(Object) => Boolean")]
        public void IsType_Object_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.IsType
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.IsType) + "(Object, Type) => Boolean")]
        public void IsType_Object_Type_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.IsType
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.IsType) + "(Type, Type) => Boolean")]
        public void IsType_Type_Type_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.IsType
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.IsType) + "(Type) => Boolean")]
        public void IsType_Type_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.IsType
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.IsStatic) + "(Type) => Boolean")]
        public void IsStatic()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.IsStatic
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.MembersOfType) + "(Type, Type, Boolean) => List`1<MemberInfo>")]
        public void MembersOfType()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.MembersOfType
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.MemberType) + "(MemberInfo) => Type")]
        public void MemberType()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.MemberType
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.New) + "(Type, Object[]) => T")]
        public void New_Type_Object_T()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.New
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.New) + "(Type, Object[], Type) => Object")]
        public void New_Type_Object_Type_Object()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.New
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.NewRandom) + "(Type, Object, Object) => Object")]
        public void NewRandom()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.NewRandom
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.SetValue) + "(MemberInfo, Object, Object)")]
        public void SetValue()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.SetValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.ToInvocationSignature) + "(MethodInfo, Boolean) => String")]
        public void ToInvocationSignature()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.ToInvocationSignature
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.TypeEquals) + "(Type, Type) => Boolean")]
        public void TypeEquals()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.TypeEquals
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.WithAttribute) + "(IEnumerable`1<TMember>, Boolean) => List`1<TMember>")]
        public void WithAttribute_IEnumerable_1_TMember_Boolean_List_1_TMember()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.WithAttribute
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.WithAttribute) + "(IEnumerable`1<MemberInfo>, Boolean) => List`1<MemberInfo>")]
        public void WithAttribute_IEnumerable_1_MemberInfo_Boolean_List_1_MemberInfo()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.WithAttribute
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.WithAttribute) + "(IEnumerable`1<MemberInfo>, Type, Boolean) => List`1<MemberInfo>")]
        public void WithAttribute_IEnumerable_1_MemberInfo_Type_Boolean_List_1_MemberInfo()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.WithAttribute
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.WithoutAttribute) + "(IEnumerable`1<TMember>, Boolean) => List`1<TMember>")]
        public void WithoutAttribute_IEnumerable_1_TMember_Boolean_List_1_TMember()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.WithoutAttribute
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.WithoutAttribute) + "(IEnumerable`1<MemberInfo>, Boolean) => List`1<MemberInfo>")]
        public void WithoutAttribute_IEnumerable_1_MemberInfo_Boolean_List_1_MemberInfo()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.WithoutAttribute
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.WithoutAttribute) + "(IEnumerable`1<MemberInfo>, Type, Boolean) => List`1<MemberInfo>")]
        public void WithoutAttribute_IEnumerable_1_MemberInfo_Type_Boolean_List_1_MemberInfo()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.WithoutAttribute
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.ToParameterSignature) + "(MethodInfo) => String")]
        public void ToParameterSignature()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.ToParameterSignature
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ReflectionExt) + "." + nameof(ReflectionExt.GetGenericName) + "(Type) => String")]
        public void GetGenericName()
            {
            // TODO: Implement method test LCore.Extensions.ReflectionExt.GetGenericName
            }

        }
    }