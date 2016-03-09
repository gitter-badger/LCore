using System;
using LCore;
using LCore.ObjectExtensions;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using LCore.UnitTesting;

namespace LCore
    {
    public partial class L : Logic
        {
        #region Type
        public static Func<MemberFilter> Type_GetFilterAttribute = () => { return System.Type.FilterAttribute; };
        public static Func<MemberFilter> Type_GetFilterName = () => { return System.Type.FilterName; };
        public static Func<MemberFilter> Type_GetFilterNameIgnoreCase = () => { return System.Type.FilterNameIgnoreCase; };
        public static Func<Object> Type_GetMissing = () => { return System.Type.Missing; };
        public static Func<Char> Type_GetDelimiter = () => { return System.Type.Delimiter; };
        public static Func<Type[]> Type_GetEmptyTypes = () => { return System.Type.EmptyTypes; };
        public static Func<Type, MemberTypes> Type_GetMemberType = (t) => { return t.MemberType; };
        public static Func<Type, Type> Type_GetDeclaringType = (t) => { return t.DeclaringType; };
        public static Func<Type, MethodBase> Type_GetDeclaringMethod = (t) => { return t.DeclaringMethod; };
        public static Func<Type, Type> Type_GetReflectedType = (t) => { return t.ReflectedType; };
        public static Func<Type, StructLayoutAttribute> Type_GetStructLayoutAttribute = (t) => { return t.StructLayoutAttribute; };
        public static Func<Type, Guid> Type_GetGUID = (t) => { return t.GUID; };
        public static Func<Binder> Type_GetDefaultBinder = () => { return System.Type.DefaultBinder; };
        public static Func<Type, Module> Type_GetModule = (t) => { return t.Module; };
        public static Func<Type, Assembly> Type_GetAssembly = (t) => { return t.Assembly; };
        public static Func<Type, RuntimeTypeHandle> Type_GetTypeHandle = (t) => { return t.TypeHandle; };
        public static Func<Type, String> Type_GetFullName = (t) => { return t.FullName; };
        public static Func<Type, String> Type_GetNamespace = (t) => { return t.Namespace; };
        public static Func<Type, String> Type_GetAssemblyQualifiedName = (t) => { return t.AssemblyQualifiedName; };
        public static Func<Type, Type> Type_GetBaseType = (t) => { return t.BaseType; };
        public static Func<Type, ConstructorInfo> Type_GetTypeInitializer = (t) => { return t.TypeInitializer; };
        public static Func<Type, Boolean> Type_GetIsNested = (t) => { return t.IsNested; };
        public static Func<Type, TypeAttributes> Type_GetAttributes = (t) => { return t.Attributes; };
        public static Func<Type, GenericParameterAttributes> Type_GetGenericParameterAttributes = (t) => { return t.GenericParameterAttributes; };
        public static Func<Type, Boolean> Type_GetIsVisible = (t) => { return t.IsVisible; };
        public static Func<Type, Boolean> Type_GetIsNotPublic = (t) => { return t.IsNotPublic; };
        public static Func<Type, Boolean> Type_GetIsPublic = (t) => { return t.IsPublic; };
        public static Func<Type, Boolean> Type_GetIsNestedPublic = (t) => { return t.IsNestedPublic; };
        public static Func<Type, Boolean> Type_GetIsNestedPrivate = (t) => { return t.IsNestedPrivate; };
        public static Func<Type, Boolean> Type_GetIsNestedFamily = (t) => { return t.IsNestedFamily; };
        public static Func<Type, Boolean> Type_GetIsNestedAssembly = (t) => { return t.IsNestedAssembly; };
        public static Func<Type, Boolean> Type_GetIsNestedFamANDAssem = (t) => { return t.IsNestedFamANDAssem; };
        public static Func<Type, Boolean> Type_GetIsNestedFamORAssem = (t) => { return t.IsNestedFamORAssem; };
        public static Func<Type, Boolean> Type_GetIsAutoLayout = (t) => { return t.IsAutoLayout; };
        public static Func<Type, Boolean> Type_GetIsLayoutSequential = (t) => { return t.IsLayoutSequential; };
        public static Func<Type, Boolean> Type_GetIsExplicitLayout = (t) => { return t.IsExplicitLayout; };
        public static Func<Type, Boolean> Type_GetIsClass = (t) => { return t.IsClass; };
        public static Func<Type, Boolean> Type_GetIsInterface = (t) => { return t.IsInterface; };
        public static Func<Type, Boolean> Type_GetIsValueType = (t) => { return t.IsValueType; };
        public static Func<Type, Boolean> Type_GetIsAbstract = (t) => { return t.IsAbstract; };
        public static Func<Type, Boolean> Type_GetIsSealed = (t) => { return t.IsSealed; };
        public static Func<Type, Boolean> Type_GetIsEnum = (t) => { return t.IsEnum; };
        public static Func<Type, Boolean> Type_GetIsSpecialName = (t) => { return t.IsSpecialName; };
        public static Func<Type, Boolean> Type_GetIsImport = (t) => { return t.IsImport; };
        public static Func<Type, Boolean> Type_GetIsSerializable = (t) => { return t.IsSerializable; };
        public static Func<Type, Boolean> Type_GetIsAnsiClass = (t) => { return t.IsAnsiClass; };
        public static Func<Type, Boolean> Type_GetIsUnicodeClass = (t) => { return t.IsUnicodeClass; };
        public static Func<Type, Boolean> Type_GetIsAutoClass = (t) => { return t.IsAutoClass; };
        public static Func<Type, Boolean> Type_GetIsArray = (t) => { return t.IsArray; };
        public static Func<Type, Boolean> Type_GetIsGenericType = (t) => { return t.IsGenericType; };
        public static Func<Type, Boolean> Type_GetIsGenericTypeDefinition = (t) => { return t.IsGenericTypeDefinition; };
        public static Func<Type, Boolean> Type_GetIsGenericParameter = (t) => { return t.IsGenericParameter; };
        public static Func<Type, Int32> Type_GetGenericParameterPosition = (t) => { return t.GenericParameterPosition; };
        public static Func<Type, Boolean> Type_GetContainsGenericParameters = (t) => { return t.ContainsGenericParameters; };
        public static Func<Type, Boolean> Type_GetIsByRef = (t) => { return t.IsByRef; };
        public static Func<Type, Boolean> Type_GetIsPointer = (t) => { return t.IsPointer; };
        public static Func<Type, Boolean> Type_GetIsPrimitive = (t) => { return t.IsPrimitive; };
        public static Func<Type, Boolean> Type_GetIsCOMObject = (t) => { return t.IsCOMObject; };
        public static Func<Type, Boolean> Type_GetHasElementType = (t) => { return t.HasElementType; };
        public static Func<Type, Boolean> Type_GetIsContextful = (t) => { return t.IsContextful; };
        public static Func<Type, Boolean> Type_GetIsMarshalByRef = (t) => { return t.IsMarshalByRef; };
        /* Missing in Mono
        public static Func<Type, Boolean> Type_GetIsSecurityCritical = (t) => { return t.IsSecurityCritical; };
        public static Func<Type, Boolean> Type_GetIsSecuritySafeCritical = (t) => { return t.IsSecuritySafeCritical; };
        public static Func<Type, Boolean> Type_GetIsSecurityTransparent = (t) => { return t.IsSecurityTransparent; };
        public static Func<String, Type> Type_GetTypeFromProgID = (progID) => { return System.Type.GetTypeFromProgID(progID); };
        public static Func<String, Boolean, Type> Type_GetTypeFromProgID2 = (progID, throwOnError) => { return System.Type.GetTypeFromProgID(progID, throwOnError); };
        public static Func<String, String, Type> Type_GetTypeFromProgID3 = (progID, server) => { return System.Type.GetTypeFromProgID(progID, server); };
        public static Func<String, String, Boolean, Type> Type_GetTypeFromProgID4 = (progID, server, throwOnError) => { return System.Type.GetTypeFromProgID(progID, server, throwOnError); };
        public static Func<Guid, Type> Type_GetTypeFromCLSID = (clsid) => { return System.Type.GetTypeFromCLSID(clsid); };
        public static Func<Guid, Boolean, Type> Type_GetTypeFromCLSID2 = (clsid, throwOnError) => { return System.Type.GetTypeFromCLSID(clsid, throwOnError); };
        public static Func<Guid, String, Type> Type_GetTypeFromCLSID3 = (clsid, server) => { return System.Type.GetTypeFromCLSID(clsid, server); };
        public static Func<Guid, String, Boolean, Type> Type_GetTypeFromCLSID4 = (clsid, server, throwOnError) => { return System.Type.GetTypeFromCLSID(clsid, server, throwOnError); };
        */
        public static Func<Type, Type> Type_GetType = (t) => { return t.GetType(); };
        public static Func<String, Boolean, Boolean, Type> Type_GetType2 = (typeName, throwOnError, ignoreCase) => { return System.Type.GetType(typeName, throwOnError, ignoreCase); };
        public static Func<String, Boolean, Type> Type_GetType3 = (typeName, throwOnError) => { return System.Type.GetType(typeName, throwOnError); };
        public static Func<String, Type> Type_GetType4 = (typeName) => { return System.Type.GetType(typeName); };
        /* No Generic Types 
        public static Func<String, Func`2, Func`4, Type> Type_GetType5 = (typeName, assemblyResolver, typeResolver) => { return Type.GetType(typeName, assemblyResolver, typeResolver); };
        */
        /* No Generic Types 
        public static Func<String, Func`2, Func`4, Boolean, Type> Type_GetType6 = (typeName, assemblyResolver, typeResolver, throwOnError) => { return Type.GetType(typeName, assemblyResolver, typeResolver, throwOnError); };
        */
        /* Too Many Parameters :( 
        public static Func<String, Func`2, Func`4, Boolean, Boolean, Type> Type_GetType7 = (typeName, assemblyResolver, typeResolver, throwOnError, ignoreCase) => { return Type.GetType(typeName, assemblyResolver, typeResolver, throwOnError, ignoreCase); };
        */
        public static Func<String, Boolean, Boolean, Type> Type_ReflectionOnlyGetType = (typeName, throwIfNotFound, ignoreCase) => { return System.Type.ReflectionOnlyGetType(typeName, throwIfNotFound, ignoreCase); };
        public static Func<Type, Type> Type_MakePointerType = (t) => { return t.MakePointerType(); };
        public static Func<Type, Type> Type_MakeByRefType = (t) => { return t.MakeByRefType(); };
        public static Func<Type, Type> Type_MakeArrayType = (t) => { return t.MakeArrayType(); };
        public static Func<Type, Int32, Type> Type_MakeArrayType2 = (t, rank) => { return t.MakeArrayType(rank); };
        public static Func<Type, TypeCode> Type_GetTypeCode = (type) => { return System.Type.GetTypeCode(type); };
        /* Too Many Parameters :( 
        public static Func<Type, String, BindingFlags, Binder, Object, Object[], ParameterModifier[], CultureInfo, String[], Object> Type_InvokeMember = (t, name, invokeAttr, binder, target, args, modifiers, culture, namedParameters) => { return t.InvokeMember(name, invokeAttr, binder, target, args, modifiers, culture, namedParameters); };
        */
        /* Too Many Parameters :( 
        public static Func<Type, String, BindingFlags, Binder, Object, Object[], CultureInfo, Object> Type_InvokeMember2 = (t, name, invokeAttr, binder, target, args, culture) => { return t.InvokeMember(name, invokeAttr, binder, target, args, culture); };
        */
        /* Too Many Parameters :( 
        public static Func<Type, String, BindingFlags, Binder, Object, Object[], Object> Type_InvokeMember3 = (t, name, invokeAttr, binder, target, args) => { return t.InvokeMember(name, invokeAttr, binder, target, args); };
        */
        public static Func<Object, RuntimeTypeHandle> Type_GetTypeHandle2 = (o) => { return System.Type.GetTypeHandle(o); };
        public static Func<RuntimeTypeHandle, Type> Type_GetTypeFromHandle = (handle) => { return System.Type.GetTypeFromHandle(handle); };
        public static Func<Type, Int32> Type_GetArrayRank = (t) => { return t.GetArrayRank(); };
        /* Too Many Parameters :( 
        public static Func<Type, BindingFlags, Binder, CallingConventions, Type[], ParameterModifier[], ConstructorInfo> Type_GetConstructor = (t, bindingAttr, binder, callConvention, types, modifiers) => { return t.GetConstructor(bindingAttr, binder, callConvention, types, modifiers); };
        */
        /* Too Many Parameters :( 
        public static Func<Type, BindingFlags, Binder, Type[], ParameterModifier[], ConstructorInfo> Type_GetConstructor2 = (t, bindingAttr, binder, types, modifiers) => { return t.GetConstructor(bindingAttr, binder, types, modifiers); };
        */
        public static Func<Type, Type[], ConstructorInfo> Type_GetConstructor3 = (t, types) => { return t.GetConstructor(types); };
        public static Func<Type, ConstructorInfo[]> Type_GetConstructors = (t) => { return t.GetConstructors(); };
        public static Func<Type, BindingFlags, ConstructorInfo[]> Type_GetConstructors2 = (t, bindingAttr) => { return t.GetConstructors(bindingAttr); };
        /* Too Many Parameters :( 
        public static Func<Type, String, BindingFlags, Binder, CallingConventions, Type[], ParameterModifier[], MethodInfo> Type_GetMethod = (t, name, bindingAttr, binder, callConvention, types, modifiers) => { return t.GetMethod(name, bindingAttr, binder, callConvention, types, modifiers); };
        */
        /* Too Many Parameters :( 
        public static Func<Type, String, BindingFlags, Binder, Type[], ParameterModifier[], MethodInfo> Type_GetMethod2 = (t, name, bindingAttr, binder, types, modifiers) => { return t.GetMethod(name, bindingAttr, binder, types, modifiers); };
        */
        public static Func<Type, String, Type[], ParameterModifier[], MethodInfo> Type_GetMethod3 = (t, name, types, modifiers) => { return t.GetMethod(name, types, modifiers); };
        public static Func<Type, String, Type[], MethodInfo> Type_GetMethod4 = (t, name, types) => { return t.GetMethod(name, types); };
        public static Func<Type, String, BindingFlags, MethodInfo> Type_GetMethod5 = (t, name, bindingAttr) => { return t.GetMethod(name, bindingAttr); };
        public static Func<Type, String, MethodInfo> Type_GetMethod6 = (t, name) => { return t.GetMethod(name); };
        public static Func<Type, MethodInfo[]> Type_GetMethods = (t) => { return t.GetMethods(); };
        public static Func<Type, BindingFlags, MethodInfo[]> Type_GetMethods2 = (t, bindingAttr) => { return t.GetMethods(bindingAttr); };
        public static Func<Type, String, BindingFlags, FieldInfo> Type_GetField = (t, name, bindingAttr) => { return t.GetField(name, bindingAttr); };
        public static Func<Type, String, FieldInfo> Type_GetField2 = (t, name) => { return t.GetField(name); };
        public static Func<Type, FieldInfo[]> Type_GetFields = (t) => { return t.GetFields(); };
        public static Func<Type, BindingFlags, FieldInfo[]> Type_GetFields2 = (t, bindingAttr) => { return t.GetFields(bindingAttr); };
        public static Func<Type, String, Type> Type_GetInterface = (t, name) => { return t.GetInterface(name); };
        public static Func<Type, String, Boolean, Type> Type_GetInterface2 = (t, name, ignoreCase) => { return t.GetInterface(name, ignoreCase); };
        public static Func<Type, Type[]> Type_GetInterfaces = (t) => { return t.GetInterfaces(); };
        public static Func<Type, TypeFilter, Object, Type[]> Type_FindInterfaces = (t, filter, filterCriteria) => { return t.FindInterfaces(filter, filterCriteria); };
        public static Func<Type, String, EventInfo> Type_GetEvent = (t, name) => { return t.GetEvent(name); };
        public static Func<Type, String, BindingFlags, EventInfo> Type_GetEvent2 = (t, name, bindingAttr) => { return t.GetEvent(name, bindingAttr); };
        public static Func<Type, EventInfo[]> Type_GetEvents = (t) => { return t.GetEvents(); };
        public static Func<Type, BindingFlags, EventInfo[]> Type_GetEvents2 = (t, bindingAttr) => { return t.GetEvents(bindingAttr); };
        /* Too Many Parameters :( 
        public static Func<Type, String, BindingFlags, Binder, Type, Type[], ParameterModifier[], PropertyInfo> Type_GetProperty = (t, name, bindingAttr, binder, returnType, types, modifiers) => { return t.GetProperty(name, bindingAttr, binder, returnType, types, modifiers); };
        */
        /* Too Many Parameters :( 
        public static Func<Type, String, Type, Type[], ParameterModifier[], PropertyInfo> Type_GetProperty2 = (t, name, returnType, types, modifiers) => { return t.GetProperty(name, returnType, types, modifiers); };
        */
        public static Func<Type, String, BindingFlags, PropertyInfo> Type_GetProperty3 = (t, name, bindingAttr) => { return t.GetProperty(name, bindingAttr); };
        public static Func<Type, String, Type, Type[], PropertyInfo> Type_GetProperty4 = (t, name, returnType, types) => { return t.GetProperty(name, returnType, types); };
        public static Func<Type, String, Type[], PropertyInfo> Type_GetProperty5 = (t, name, types) => { return t.GetProperty(name, types); };
        public static Func<Type, String, Type, PropertyInfo> Type_GetProperty6 = (t, name, returnType) => { return t.GetProperty(name, returnType); };
        public static Func<Type, String, PropertyInfo> Type_GetProperty7 = (t, name) => { return t.GetProperty(name); };
        public static Func<Type, BindingFlags, PropertyInfo[]> Type_GetProperties2 = (t, bindingAttr) => { return t.GetProperties(bindingAttr); };
        public static Func<Type, PropertyInfo[]> Type_GetProperties = (t) => { return t.GetProperties(); };
        public static Func<Type, Type[]> Type_GetNestedTypes = (t) => { return t.GetNestedTypes(); };
        public static Func<Type, BindingFlags, Type[]> Type_GetNestedTypes2 = (t, bindingAttr) => { return t.GetNestedTypes(bindingAttr); };
        public static Func<Type, String, Type> Type_GetNestedType = (t, name) => { return t.GetNestedType(name); };
        public static Func<Type, String, BindingFlags, Type> Type_GetNestedType2 = (t, name, bindingAttr) => { return t.GetNestedType(name, bindingAttr); };
        public static Func<Type, String, MemberInfo[]> Type_GetMember = (t, name) => { return t.GetMember(name); };
        public static Func<Type, String, BindingFlags, MemberInfo[]> Type_GetMember2 = (t, name, bindingAttr) => { return t.GetMember(name, bindingAttr); };
        public static Func<Type, String, MemberTypes, BindingFlags, MemberInfo[]> Type_GetMember3 = (t, name, type, bindingAttr) => { return t.GetMember(name, type, bindingAttr); };
        public static Func<Type, MemberInfo[]> Type_GetMembers = (t) => { return t.GetMembers(); };
        public static Func<Type, BindingFlags, MemberInfo[]> Type_GetMembers2 = (t, bindingAttr) => { return t.GetMembers(bindingAttr); };
        public static Func<Type, MemberInfo[]> Type_GetDefaultMembers = (t) => { return t.GetDefaultMembers(); };
        /* Too Many Parameters :( 
        public static Func<Type, MemberTypes, BindingFlags, MemberFilter, Object, MemberInfo[]> Type_FindMembers = (t, memberType, bindingAttr, filter, filterCriteria) => { return t.FindMembers(memberType, bindingAttr, filter, filterCriteria); };
        */
        public static Func<Type, Type[]> Type_GetGenericParameterConstraints = (t) => { return t.GetGenericParameterConstraints(); };
        public static Func<Type, Type[], Type> Type_MakeGenericType = (t, typeArguments) => { return t.MakeGenericType(typeArguments); };
        public static Func<Type, Type> Type_GetElementType = (t) => { return t.GetElementType(); };
        public static Func<Type, Type[]> Type_GetGenericArguments = (t) => { return t.GetGenericArguments(); };
        public static Func<Type, Type> Type_GetGenericTypeDefinition = (t) => { return t.GetGenericTypeDefinition(); };
        public static Func<Type, Type, Boolean> Type_IsSubclassOf = (t, c) => { return t.IsSubclassOf(c); };
        public static Func<Type, Object, Boolean> Type_IsInstanceOfType = (t, o) => { return t.IsInstanceOfType(o); };
        public static Func<Type, Type, Boolean> Type_IsAssignableFrom = (t, c) => { return t.IsAssignableFrom(c); };
        public static Func<Type, String> Type_ToString = (t) => { return t.ToString(); };
        public static Func<Object[], Type[]> Type_GetTypeArray = (args) => { return System.Type.GetTypeArray(args); };
        public static Func<Type, Object, Boolean> Type_Equals = (t, o) => { return t.Equals(o); };
        public static Func<Type, Type, Boolean> Type_Equals2 = (t, o) => { return t.Equals(o); };
        /* Missing in Mono
        public static Func<Type, Type, Boolean> Type_IsEquivalentTo = (t, other) => { return t.IsEquivalentTo(other); };
        public static Func<Type, Object, String> Type_GetEnumName = (t, value) => { return t.GetEnumName(value); };
        public static Func<Type, Object, Boolean> Type_IsEnumDefined = (t, value) => { return t.IsEnumDefined(value); };
        public static Func<Type, Type> Type_GetEnumUnderlyingType = (t) => { return t.GetEnumUnderlyingType(); };
        public static Func<Type, Type> Type_GetUnderlyingSystemType = (t) => { return t.UnderlyingSystemType; };
        public static Func<Type, Type, Boolean> Type_Equals3 = (left, right) => { return left == right; };
        public static Func<Type, Type, Boolean> Type_NotEquals = (left, right) => { return left != right; };
        public static Func<Type, String[]> Type_GetEnumNames = (t) => { return t.GetEnumNames(); };
        public static Func<Type, Array> Type_GetEnumValues = (t) => { return t.GetEnumValues(); };
        */
        public static Func<Type, Int32> Type_GetHashCode = (t) => { return t.GetHashCode(); };
        public static Func<Type, Type, InterfaceMapping> Type_GetInterfaceMap = (t, interfaceType) => { return t.GetInterfaceMap(interfaceType); };
        /* Method found on base type 
        public static Func<MemberInfo, Boolean, Object[]> MemberInfo_GetCustomAttributes = (m, inherit) => { return m.GetCustomAttributes(inherit); };
        */
        /* Method found on base type 
        public static Func<MemberInfo, Type, Boolean, Object[]> MemberInfo_GetCustomAttributes2 = (m, attributeType, inherit) => { return m.GetCustomAttributes(attributeType, inherit); };
        */
        /* Method found on base type 
        public static Func<MemberInfo, Type, Boolean, Boolean> MemberInfo_IsDefined = (m, attributeType, inherit) => { return m.IsDefined(attributeType, inherit); };
        */
        /* No Generic Types 
        public static Func<MemberInfo, IList`1> MemberInfo_GetCustomAttributesData = (m) => { return m.GetCustomAttributesData(); };
        */
        /* Method found on base type 
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        #endregion
        #region MemberInfo
        public static Func<MemberInfo, MemberTypes> MemberInfo_GetMemberType = (m) => { return m.MemberType; };
        public static Func<MemberInfo, String> MemberInfo_GetName = (m) => { return m.Name; };
        public static Func<MemberInfo, Type> MemberInfo_GetDeclaringType = (m) => { return m.DeclaringType; };
        public static Func<MemberInfo, Type> MemberInfo_GetReflectedType = (m) => { return m.ReflectedType; };
        public static Func<MemberInfo, Int32> MemberInfo_GetMetadataToken = (m) => { return m.MetadataToken; };
        public static Func<MemberInfo, Module> MemberInfo_GetModule = (m) => { return m.Module; };
        public static Func<MemberInfo, Boolean, Object[]> MemberInfo_GetCustomAttributes = (m, inherit) => { return m.GetCustomAttributes(inherit); };
        public static Func<MemberInfo, Type, Boolean, Object[]> MemberInfo_GetCustomAttributes2 = (m, attributeType, inherit) => { return m.GetCustomAttributes(attributeType, inherit); };
        public static Func<MemberInfo, Type, Boolean, Boolean> MemberInfo_IsDefined = (m, attributeType, inherit) => { return m.IsDefined(attributeType, inherit); };
        /* No Generic Types 
        public static Func<MemberInfo, IList`1> MemberInfo_GetCustomAttributesData = (m) => { return m.GetCustomAttributesData(); };
        */
        /* Missing in Mono
        public static Func<MemberInfo, MemberInfo, Boolean> MemberInfo_Equals = (left, right) => { return left == right; };
        public static Func<MemberInfo, MemberInfo, Boolean> MemberInfo_NotEquals = (left, right) => { return left != right; };
         * */
        public static Func<MemberInfo, Object, Boolean> MemberInfo_Equals2 = (m, obj) => { return m.Equals(obj); };
        public static Func<MemberInfo, Int32> MemberInfo_GetHashCode = (m) => { return m.GetHashCode(); };
        /* Method found on base type 
        public static Func<Object, String> Object_ToString = (o) => { return o.ToString(); };
        */
        /* Method found on base type 
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        #endregion
        #region PropertyInfo
        public static Func<PropertyInfo, MemberTypes> PropertyInfo_GetMemberType = (p) => { return p.MemberType; };
        public static Func<PropertyInfo, Type> PropertyInfo_GetPropertyType = (p) => { return p.PropertyType; };
        public static Func<PropertyInfo, PropertyAttributes> PropertyInfo_GetAttributes = (p) => { return p.Attributes; };
        public static Func<PropertyInfo, Boolean> PropertyInfo_GetCanRead = (p) => { return p.CanRead; };
        public static Func<PropertyInfo, Boolean> PropertyInfo_GetCanWrite = (p) => { return p.CanWrite; };
        public static Func<PropertyInfo, Boolean> PropertyInfo_GetIsSpecialName = (p) => { return p.IsSpecialName; };
        /* Missing in Mono
        public static Func<PropertyInfo, PropertyInfo, Boolean> PropertyInfo_Equals = (left, right) => { return left == right; };
        public static Func<PropertyInfo, PropertyInfo, Boolean> PropertyInfo_NotEquals = (left, right) => { return left != right; };
         */
        public static Func<PropertyInfo, Object, Boolean> PropertyInfo_Equals2 = (p, obj) => { return p.Equals(obj); };
        public static Func<PropertyInfo, Int32> PropertyInfo_GetHashCode = (p) => { return p.GetHashCode(); };
        public static Func<PropertyInfo, Object> PropertyInfo_GetConstantValue = (p) => { return p.GetConstantValue(); };
        public static Func<PropertyInfo, Object> PropertyInfo_GetRawConstantValue = (p) => { return p.GetRawConstantValue(); };
        /* Too Many Parameters :( 
        public static Action<PropertyInfo, Object, Object, BindingFlags, Binder, Object[], CultureInfo> PropertyInfo_SetValue = (p, obj, value, invokeAttr, binder, index, culture) => {p.SetValue(obj, value, invokeAttr, binder, index, culture); };
        */
        public static Func<PropertyInfo, Boolean, MethodInfo[]> PropertyInfo_GetAccessors = (p, nonPublic) => { return p.GetAccessors(nonPublic); };
        public static Func<PropertyInfo, Boolean, MethodInfo> PropertyInfo_GetGetMethod = (p, nonPublic) => { return p.GetGetMethod(nonPublic); };
        public static Func<PropertyInfo, Boolean, MethodInfo> PropertyInfo_GetSetMethod = (p, nonPublic) => { return p.GetSetMethod(nonPublic); };
        public static Func<PropertyInfo, ParameterInfo[]> PropertyInfo_GetIndexParameters = (p) => { return p.GetIndexParameters(); };
        public static Func<PropertyInfo, Object, Object[], Object> PropertyInfo_GetValue = (p, obj, index) => { return p.GetValue(obj, index); };
        /* Too Many Parameters :( 
        public static Func<PropertyInfo, Object, BindingFlags, Binder, Object[], CultureInfo, Object> PropertyInfo_GetValue2 = (p, obj, invokeAttr, binder, index, culture) => { return p.GetValue(obj, invokeAttr, binder, index, culture); };
        */
        public static Action<PropertyInfo, Object, Object, Object[]> PropertyInfo_SetValue = (p, obj, value, index) => { p.SetValue(obj, value, index); };
        public static Func<PropertyInfo, Type[]> PropertyInfo_GetRequiredCustomModifiers = (p) => { return p.GetRequiredCustomModifiers(); };
        public static Func<PropertyInfo, Type[]> PropertyInfo_GetOptionalCustomModifiers = (p) => { return p.GetOptionalCustomModifiers(); };
        public static Func<PropertyInfo, MethodInfo[]> PropertyInfo_GetAccessors2 = (p) => { return p.GetAccessors(); };
        public static Func<PropertyInfo, MethodInfo> PropertyInfo_GetGetMethod2 = (p) => { return p.GetGetMethod(); };
        public static Func<PropertyInfo, MethodInfo> PropertyInfo_GetSetMethod2 = (p) => { return p.GetSetMethod(); };
        /* Method found on base type 
        public static Func<MemberInfo, Boolean, Object[]> MemberInfo_GetCustomAttributes = (m, inherit) => { return m.GetCustomAttributes(inherit); };
        */
        /* Method found on base type 
        public static Func<MemberInfo, Type, Boolean, Object[]> MemberInfo_GetCustomAttributes2 = (m, attributeType, inherit) => { return m.GetCustomAttributes(attributeType, inherit); };
        */
        /* Method found on base type 
        public static Func<MemberInfo, Type, Boolean, Boolean> MemberInfo_IsDefined = (m, attributeType, inherit) => { return m.IsDefined(attributeType, inherit); };
        */
        /* No Generic Types 
        public static Func<MemberInfo, IList`1> MemberInfo_GetCustomAttributesData = (m) => { return m.GetCustomAttributesData(); };
        */
        /* Method found on base type 
        public static Func<Object, String> Object_ToString = (o) => { return o.ToString(); };
        */
        /* Method found on base type 
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        #endregion
        #region FieldInfo
        public static Func<FieldInfo, MemberTypes> FieldInfo_GetMemberType = (f) => { return f.MemberType; };
        public static Func<FieldInfo, RuntimeFieldHandle> FieldInfo_GetFieldHandle = (f) => { return f.FieldHandle; };
        public static Func<FieldInfo, Type> FieldInfo_GetFieldType = (f) => { return f.FieldType; };
        public static Func<FieldInfo, FieldAttributes> FieldInfo_GetAttributes = (f) => { return f.Attributes; };
        public static Func<FieldInfo, Boolean> FieldInfo_GetIsPublic = (f) => { return f.IsPublic; };
        public static Func<FieldInfo, Boolean> FieldInfo_GetIsPrivate = (f) => { return f.IsPrivate; };
        public static Func<FieldInfo, Boolean> FieldInfo_GetIsFamily = (f) => { return f.IsFamily; };
        public static Func<FieldInfo, Boolean> FieldInfo_GetIsAssembly = (f) => { return f.IsAssembly; };
        public static Func<FieldInfo, Boolean> FieldInfo_GetIsFamilyAndAssembly = (f) => { return f.IsFamilyAndAssembly; };
        public static Func<FieldInfo, Boolean> FieldInfo_GetIsFamilyOrAssembly = (f) => { return f.IsFamilyOrAssembly; };
        public static Func<FieldInfo, Boolean> FieldInfo_GetIsStatic = (f) => { return f.IsStatic; };
        public static Func<FieldInfo, Boolean> FieldInfo_GetIsInitOnly = (f) => { return f.IsInitOnly; };
        public static Func<FieldInfo, Boolean> FieldInfo_GetIsLiteral = (f) => { return f.IsLiteral; };
        public static Func<FieldInfo, Boolean> FieldInfo_GetIsNotSerialized = (f) => { return f.IsNotSerialized; };
        public static Func<FieldInfo, Boolean> FieldInfo_GetIsSpecialName = (f) => { return f.IsSpecialName; };
        public static Func<FieldInfo, Boolean> FieldInfo_GetIsPinvokeImpl = (f) => { return f.IsPinvokeImpl; };
        /* Missing in Mono
        public static Func<FieldInfo, Boolean> FieldInfo_GetIsSecurityCritical = (f) => { return f.IsSecurityCritical; };
        public static Func<FieldInfo, Boolean> FieldInfo_GetIsSecuritySafeCritical = (f) => { return f.IsSecuritySafeCritical; };
        public static Func<FieldInfo, Boolean> FieldInfo_GetIsSecurityTransparent = (f) => { return f.IsSecurityTransparent; };
         */
        public static Func<RuntimeFieldHandle, FieldInfo> FieldInfo_GetFieldFromHandle = (handle) => { return FieldInfo.GetFieldFromHandle(handle); };
        public static Func<RuntimeFieldHandle, RuntimeTypeHandle, FieldInfo> FieldInfo_GetFieldFromHandle2 = (handle, declaringType) => { return FieldInfo.GetFieldFromHandle(handle, declaringType); };

        /* Missing in Mono
        public static Func<FieldInfo, FieldInfo, Boolean> FieldInfo_Equals = (left, right) => { return left == right; };
        public static Func<FieldInfo, FieldInfo, Boolean> FieldInfo_NotEquals = (left, right) => { return left != right; };
         */
        public static Func<FieldInfo, Object, Boolean> FieldInfo_Equals2 = (f, obj) => { return f.Equals(obj); };
        public static Func<FieldInfo, Int32> FieldInfo_GetHashCode = (f) => { return f.GetHashCode(); };
        public static Func<FieldInfo, Type[]> FieldInfo_GetRequiredCustomModifiers = (f) => { return f.GetRequiredCustomModifiers(); };
        public static Func<FieldInfo, Type[]> FieldInfo_GetOptionalCustomModifiers = (f) => { return f.GetOptionalCustomModifiers(); };
        /* No TypedReference
        public static Action<FieldInfo, TypedReference, Object> FieldInfo_SetValueDirect = (f, obj, value) => {f.SetValueDirect(obj, value); };
public static Func<FieldInfo, TypedReference, Object> FieldInfo_GetValueDirect = (f, obj) => { return f.GetValueDirect(obj); };
*/
        public static Func<FieldInfo, Object, Object> FieldInfo_GetValue = (f, obj) => { return f.GetValue(obj); };
        public static Func<FieldInfo, Object> FieldInfo_GetRawConstantValue = (f) => { return f.GetRawConstantValue(); };
        /* Too Many Parameters :( 
        public static Action<FieldInfo, Object, Object, BindingFlags, Binder, CultureInfo> FieldInfo_SetValue = (f, obj, value, invokeAttr, binder, culture) => {f.SetValue(obj, value, invokeAttr, binder, culture); };
        */
        public static Action<FieldInfo, Object, Object> FieldInfo_SetValue = (f, obj, value) => { f.SetValue(obj, value); };
        /* Method found on base type 
        public static Func<MemberInfo, Boolean, Object[]> MemberInfo_GetCustomAttributes = (m, inherit) => { return m.GetCustomAttributes(inherit); };
        */
        /* Method found on base type 
        public static Func<MemberInfo, Type, Boolean, Object[]> MemberInfo_GetCustomAttributes2 = (m, attributeType, inherit) => { return m.GetCustomAttributes(attributeType, inherit); };
        */
        /* Method found on base type 
        public static Func<MemberInfo, Type, Boolean, Boolean> MemberInfo_IsDefined = (m, attributeType, inherit) => { return m.IsDefined(attributeType, inherit); };
        */
        /* No Generic Types 
        public static Func<MemberInfo, IList`1> MemberInfo_GetCustomAttributesData = (m) => { return m.GetCustomAttributesData(); };
        */
        /* Method found on base type 
        public static Func<Object, String> Object_ToString = (o) => { return o.ToString(); };
        */
        /* Method found on base type 
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        #endregion
        #region MethodInfo
        public static Func<MethodInfo, MemberTypes> MethodInfo_GetMemberType = (m) => { return m.MemberType; };
        public static Func<MethodInfo, Type> MethodInfo_GetReturnType = (m) => { return m.ReturnType; };
        public static Func<MethodInfo, ParameterInfo> MethodInfo_GetReturnParameter = (m) => { return m.ReturnParameter; };
        public static Func<MethodInfo, ICustomAttributeProvider> MethodInfo_GetReturnTypeCustomAttributes = (m) => { return m.ReturnTypeCustomAttributes; };
        public static Func<MethodBase, RuntimeMethodHandle> MethodBase_GetMethodHandle = (m) => { return m.MethodHandle; };
        public static Func<MethodBase, MethodAttributes> MethodBase_GetAttributes = (m) => { return m.Attributes; };
        public static Func<MethodBase, CallingConventions> MethodBase_GetCallingConvention = (m) => { return m.CallingConvention; };
        public static Func<MethodBase, Boolean> MethodBase_GetIsGenericMethodDefinition = (m) => { return m.IsGenericMethodDefinition; };
        public static Func<MethodBase, Boolean> MethodBase_GetContainsGenericParameters = (m) => { return m.ContainsGenericParameters; };
        public static Func<MethodBase, Boolean> MethodBase_GetIsGenericMethod = (m) => { return m.IsGenericMethod; };
        /* Missing in Mono
        public static Func<MethodBase, Boolean> MethodBase_GetIsSecurityCritical = (m) => { return m.IsSecurityCritical; };
        public static Func<MethodBase, Boolean> MethodBase_GetIsSecuritySafeCritical = (m) => { return m.IsSecuritySafeCritical; };
        public static Func<MethodBase, Boolean> MethodBase_GetIsSecurityTransparent = (m) => { return m.IsSecurityTransparent; };
        public static Func<MethodInfo, MethodInfo, Boolean> MethodInfo_Equals = (left, right) => { return left == right; };
        public static Func<MethodInfo, MethodInfo, Boolean> MethodInfo_NotEquals = (left, right) => { return left != right; };
         * */
        public static Func<MethodBase, Boolean> MethodBase_GetIsPublic = (m) => { return m.IsPublic; };
        public static Func<MethodBase, Boolean> MethodBase_GetIsPrivate = (m) => { return m.IsPrivate; };
        public static Func<MethodBase, Boolean> MethodBase_GetIsFamily = (m) => { return m.IsFamily; };
        public static Func<MethodBase, Boolean> MethodBase_GetIsAssembly = (m) => { return m.IsAssembly; };
        public static Func<MethodBase, Boolean> MethodBase_GetIsFamilyAndAssembly = (m) => { return m.IsFamilyAndAssembly; };
        public static Func<MethodBase, Boolean> MethodBase_GetIsFamilyOrAssembly = (m) => { return m.IsFamilyOrAssembly; };
        public static Func<MethodBase, Boolean> MethodBase_GetIsStatic = (m) => { return m.IsStatic; };
        public static Func<MethodBase, Boolean> MethodBase_GetIsFinal = (m) => { return m.IsFinal; };
        public static Func<MethodBase, Boolean> MethodBase_GetIsVirtual = (m) => { return m.IsVirtual; };
        public static Func<MethodBase, Boolean> MethodBase_GetIsHideBySig = (m) => { return m.IsHideBySig; };
        public static Func<MethodBase, Boolean> MethodBase_GetIsAbstract = (m) => { return m.IsAbstract; };
        public static Func<MethodBase, Boolean> MethodBase_GetIsSpecialName = (m) => { return m.IsSpecialName; };
        public static Func<MethodBase, Boolean> MethodBase_GetIsConstructor = (m) => { return m.IsConstructor; };
        public static Func<MethodInfo, Object, Boolean> MethodInfo_Equals2 = (m, obj) => { return m.Equals(obj); };
        public static Func<MethodInfo, Int32> MethodInfo_GetHashCode = (m) => { return m.GetHashCode(); };
        public static Func<MethodInfo, MethodInfo> MethodInfo_GetBaseDefinition = (m) => { return m.GetBaseDefinition(); };
        public static Func<MethodInfo, Type[]> MethodInfo_GetGenericArguments = (m) => { return m.GetGenericArguments(); };
        public static Func<MethodInfo, MethodInfo> MethodInfo_GetGenericMethodDefinition = (m) => { return m.GetGenericMethodDefinition(); };
        public static Func<MethodInfo, Type[], MethodInfo> MethodInfo_MakeGenericMethod = (m, typeArguments) => { return m.MakeGenericMethod(typeArguments); };
        /* Method found on base type 
        public static Func<MethodBase, ParameterInfo[]> MethodBase_GetParameters = (m) => { return m.GetParameters(); };
        */
        /* Method found on base type 
        public static Func<MethodBase, MethodImplAttributes> MethodBase_GetMethodImplementationFlags = (m) => { return m.GetMethodImplementationFlags(); };
        */
        /* Too Many Parameters :( 
        public static Func<MethodBase, Object, BindingFlags, Binder, Object[], CultureInfo, Object> MethodBase_Invoke = (m, obj, invokeAttr, binder, parameters, culture) => { return m.Invoke(obj, invokeAttr, binder, parameters, culture); };
        */
        /* Method found on base type 
        public static Func<MethodBase, Object, Object[], Object> MethodBase_Invoke2 = (m, obj, parameters) => { return m.Invoke(obj, parameters); };
        */
        /* Method found on base type 
        public static Func<MethodBase, MethodBody> MethodBase_GetMethodBody = (m) => { return m.GetMethodBody(); };
        */
        /* Method found on base type 
        public static Func<MemberInfo, Boolean, Object[]> MemberInfo_GetCustomAttributes = (m, inherit) => { return m.GetCustomAttributes(inherit); };
        */
        /* Method found on base type 
        public static Func<MemberInfo, Type, Boolean, Object[]> MemberInfo_GetCustomAttributes2 = (m, attributeType, inherit) => { return m.GetCustomAttributes(attributeType, inherit); };
        */
        /* Method found on base type 
        public static Func<MemberInfo, Type, Boolean, Boolean> MemberInfo_IsDefined = (m, attributeType, inherit) => { return m.IsDefined(attributeType, inherit); };
        */
        /* No Generic Types 
        public static Func<MemberInfo, IList`1> MemberInfo_GetCustomAttributesData = (m) => { return m.GetCustomAttributesData(); };
        */
        /* Method found on base type 
        public static Func<Object, String> Object_ToString = (o) => { return o.ToString(); };
        */
        /* Method found on base type 
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        #endregion
        #region ParameterInfo
        public static Func<ParameterInfo, Type> ParameterInfo_GetParameterType = (p) => { return p.ParameterType; };
        public static Func<ParameterInfo, String> ParameterInfo_GetName = (p) => { return p.Name; };
        public static Func<ParameterInfo, Object> ParameterInfo_GetDefaultValue = (p) => { return p.DefaultValue; };
        public static Func<ParameterInfo, Object> ParameterInfo_GetRawDefaultValue = (p) => { return p.RawDefaultValue; };
        public static Func<ParameterInfo, Int32> ParameterInfo_GetPosition = (p) => { return p.Position; };
        public static Func<ParameterInfo, ParameterAttributes> ParameterInfo_GetAttributes = (p) => { return p.Attributes; };
        public static Func<ParameterInfo, MemberInfo> ParameterInfo_GetMember = (p) => { return p.Member; };
        public static Func<ParameterInfo, Boolean> ParameterInfo_GetIsIn = (p) => { return p.IsIn; };
        public static Func<ParameterInfo, Boolean> ParameterInfo_GetIsOut = (p) => { return p.IsOut; };
        public static Func<ParameterInfo, Boolean> ParameterInfo_GetIsLcid = (p) => { return p.IsLcid; };
        public static Func<ParameterInfo, Boolean> ParameterInfo_GetIsRetval = (p) => { return p.IsRetval; };
        public static Func<ParameterInfo, Boolean> ParameterInfo_GetIsOptional = (p) => { return p.IsOptional; };
        public static Func<ParameterInfo, Int32> ParameterInfo_GetMetadataToken = (p) => { return p.MetadataToken; };
        public static Func<ParameterInfo, Type[]> ParameterInfo_GetRequiredCustomModifiers = (p) => { return p.GetRequiredCustomModifiers(); };
        public static Func<ParameterInfo, Type[]> ParameterInfo_GetOptionalCustomModifiers = (p) => { return p.GetOptionalCustomModifiers(); };
        public static Func<ParameterInfo, String> ParameterInfo_ToString = (p) => { return p.ToString(); };
        public static Func<ParameterInfo, Boolean, Object[]> ParameterInfo_GetCustomAttributes = (p, inherit) => { return p.GetCustomAttributes(inherit); };
        public static Func<ParameterInfo, Type, Boolean, Object[]> ParameterInfo_GetCustomAttributes2 = (p, attributeType, inherit) => { return p.GetCustomAttributes(attributeType, inherit); };
        public static Func<ParameterInfo, Type, Boolean, Boolean> ParameterInfo_IsDefined = (p, attributeType, inherit) => { return p.IsDefined(attributeType, inherit); };
        /* No Generic Types 
        public static Func<ParameterInfo, IList`1> ParameterInfo_GetCustomAttributesData = (p) => { return p.GetCustomAttributesData(); };
        */
        /* Missing in Mono
        public static Func<ParameterInfo, StreamingContext, Object> ParameterInfo_GetRealObject = (p, context) => { return p.GetRealObject(context); };
         * */
        /* Method found on base type 
        public static Func<Object, Object, Boolean> Object_Equals = (o, obj) => { return o.Equals(obj); };
        */
        /* Method found on base type 
        public static Func<Object, Int32> Object_GetHashCode = (o) => { return o.GetHashCode(); };
        */
        /* Method found on base type 
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        #endregion
        #region ConstructorInfo
        public static Func<String> ConstructorInfo_GetConstructorName = () => { return ConstructorInfo.ConstructorName; };
        public static Func<String> ConstructorInfo_GetTypeConstructorName = () => { return ConstructorInfo.TypeConstructorName; };
        public static Func<ConstructorInfo, MemberTypes> ConstructorInfo_GetMemberType = (c) => { return c.MemberType; };

        /* Missing in Mono
        public static Func<ConstructorInfo, ConstructorInfo, Boolean> ConstructorInfo_Equals = (left, right) => { return left == right; };
        public static Func<ConstructorInfo, ConstructorInfo, Boolean> ConstructorInfo_NotEquals = (left, right) => { return left != right; };
         */
        public static Func<ConstructorInfo, Object, Boolean> ConstructorInfo_Equals2 = (c, obj) => { return c.Equals(obj); };
        public static Func<ConstructorInfo, Int32> ConstructorInfo_GetHashCode = (c) => { return c.GetHashCode(); };
        /* Too Many Parameters :( 
        public static Func<ConstructorInfo, BindingFlags, Binder, Object[], CultureInfo, Object> ConstructorInfo_Invoke = (c, invokeAttr, binder, parameters, culture) => { return c.Invoke(invokeAttr, binder, parameters, culture); };
        */
        public static Func<ConstructorInfo, Object[], Object> ConstructorInfo_Invoke2 = (c, parameters) => { return c.Invoke(parameters); };
        /* Method found on base type 
        public static Func<MethodBase, ParameterInfo[]> MethodBase_GetParameters = (m) => { return m.GetParameters(); };
        */
        /* Method found on base type 
        public static Func<MethodBase, MethodImplAttributes> MethodBase_GetMethodImplementationFlags = (m) => { return m.GetMethodImplementationFlags(); };
        */
        /* Too Many Parameters :( 
        public static Func<MethodBase, Object, BindingFlags, Binder, Object[], CultureInfo, Object> MethodBase_Invoke = (m, obj, invokeAttr, binder, parameters, culture) => { return m.Invoke(obj, invokeAttr, binder, parameters, culture); };
        */
        /* Method found on base type 
        public static Func<MethodBase, Type[]> MethodBase_GetGenericArguments = (m) => { return m.GetGenericArguments(); };
        */
        /* Method found on base type 
        public static Func<MethodBase, Object, Object[], Object> MethodBase_Invoke2 = (m, obj, parameters) => { return m.Invoke(obj, parameters); };
        */
        /* Method found on base type 
        public static Func<MethodBase, MethodBody> MethodBase_GetMethodBody = (m) => { return m.GetMethodBody(); };
        */
        /* Method found on base type 
        public static Func<MemberInfo, Boolean, Object[]> MemberInfo_GetCustomAttributes = (m, inherit) => { return m.GetCustomAttributes(inherit); };
        */
        /* Method found on base type 
        public static Func<MemberInfo, Type, Boolean, Object[]> MemberInfo_GetCustomAttributes2 = (m, attributeType, inherit) => { return m.GetCustomAttributes(attributeType, inherit); };
        */
        /* Method found on base type 
        public static Func<MemberInfo, Type, Boolean, Boolean> MemberInfo_IsDefined = (m, attributeType, inherit) => { return m.IsDefined(attributeType, inherit); };
        */
        /* No Generic Types 
        public static Func<MemberInfo, IList`1> MemberInfo_GetCustomAttributesData = (m) => { return m.GetCustomAttributesData(); };
        */
        /* Method found on base type 
        public static Func<Object, String> Object_ToString = (o) => { return o.ToString(); };
        */
        /* Method found on base type 
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        #endregion
        }
    public partial class Logic
        {
        /*
        public static Func<String, Type> SafeGetType = L.Type_GetType4.Catch(typeof(void).Func().Arg<Exception, Type>())
            .Cache("SafeGetType");
        */

        public static Func<Type, Boolean> Language_IsValueType = (t) =>
            {
                return t == typeof(bool) ||
                    t == typeof(byte) ||
                    t == typeof(char) ||
                    t == typeof(decimal) ||
                    t == typeof(double) ||
                    t == typeof(float) ||
                    t == typeof(int) ||
                    t == typeof(long) ||
                    t == typeof(sbyte) ||
                    t == typeof(short) ||
                    //					t == typeof(struct) ||
                    t == typeof(uint) ||
                    t == typeof(ulong) ||
                    t == typeof(ushort) ||
                    t.IsSubclassOf(typeof(Enum));
            };
        public static Func<String, String> Language_CleanOperationFunctionName = L.F<String, String>()
            .Case("op_Subtraction", "Subtract")
            .Case("op_UnaryPlus", "ShiftLeft")
            .Case("op_UnaryNegation", "ShiftRight")
            .Case("op_Addition", "Add")
            .Case("op_Equality", "Equals")
            .Case("op_Inequality", "NotEquals")
            .Case("op_LessThan", "LessThan")
            .Case("op_LessThanOrEqual", "LessThanOrEqual")
            .Case("op_GreaterThan", "GreaterThan")
            .Case("op_GreaterThanOrEqual", "GreaterThanOrEqual")
            .Else(L.Pass<String>());
        public static Func<String, String> Language_CleanOperationFunctionAction = L.F<String, String>()
            .Case("op_Subtraction", " - ")
            .Case("op_UnaryPlus", " <<")
            .Case("op_UnaryNegation", " >>")
            .Case("op_Addition", " + ")
            .Case("op_Equality", " == ")
            .Case("op_Inequality", " != ")
            .Case("op_LessThan", " < ")
            .Case("op_LessThanOrEqual", " <=")
            .Case("op_GreaterThan", " > ")
            .Case("op_GreaterThanOrEqual", " >= ")
            .Else(L.Pass<String>());

        #region MemberInfo - Get Attribute
        private static Func<String, ICustomAttributeProvider, Type, Boolean, Object> _MemberInfo_GetAttribute = (DeclaringTypeName, Prop, Attr, IncludeBaseTypes) =>
        {
            Boolean HasAttrib = false;
            Object[] Objs;
            do
                {
                Objs = Prop.GetCustomAttributes(Attr, false);
                HasAttrib = Objs.Length != 0;

                if (HasAttrib)
                    return Objs[0];

                if (Prop is MemberInfo)
                    {
                    if (((MemberInfo)Prop).DeclaringType == null ||
                        ((MemberInfo)Prop).DeclaringType.BaseType == null)
                        {
                        Prop = null;
                        }
                    else
                        {
                        try
                            {
                            Prop = ((MemberInfo)Prop).DeclaringType.BaseType.GetProperty(((MemberInfo)Prop).Name);
                            }
                        catch
                            {
                            Prop = null;
                            }
                        }
                    }
                else if (Prop is MethodInfo)
                    {
                    if (((MethodInfo)Prop).DeclaringType == null ||
                        ((MethodInfo)Prop).DeclaringType.BaseType == null)
                        {
                        Prop = null;
                        }
                    else
                        {
                        try
                            {
                            Prop = ((MethodInfo)Prop).DeclaringType.BaseType.GetProperty(((MethodInfo)Prop).Name);
                            }
                        catch
                            {
                            Prop = null;
                            }
                        }
                    }
                else
                    {
                    Prop = null;
                    }
                }
            while (IncludeBaseTypes && !HasAttrib && Prop != null);

            Object Out2 = null;

            if (!Objs.IsEmpty())
                Out2 = Objs[0];

            return Out2;
        };
        public static Func<String, ICustomAttributeProvider, Type, Boolean, Object> MemberInfo_GetAttribute = _MemberInfo_GetAttribute
            .Cache("MemberAttributes").Require("Prop").Require2("Attr");
        #endregion
        #region As
        public static Func<Object, T> As<T>()
            where T : class
            {
            return (o) => { return o as T; };
            }
        #endregion
        }
    public static class TypeExt
        {
        #region IsType
        public static Boolean IsType<T>(this Object In)
            {
            return In.GetType().IsType(typeof(T));
            }
        public static Boolean IsType(this Object In, Type t)
            {
            return In.GetType().IsType(t);
            }
        public static Boolean IsType(this Type In, Type t)
            {
            return In != null &&
                (In.TypeEquals(t) ||
                In.IsSubclassOf(t) ||
                (t.IsInterface && In.HasInterface2(t, true)));
            }
        public static Boolean IsType<T>(this Type In)
            {
            return In.IsType(typeof(T));
            }
        #endregion

        [TestResult(new Object[] { 0 }, typeof(int), GenericTypes = new Type[] { typeof(int) })]
        //      [TestResult(new Object[] { (String)null }, typeof(String), GenericTypes = new Type[] { typeof(String) })]
        [TestResult(new Object[] { "" }, typeof(String), GenericTypes = new Type[] { typeof(String) })]
        public static Type Type<T>(this T In)
            {
            return typeof(T);
            }

        public static Boolean TypeEquals(this Type In, Type Compare)
            {
            return In != null && Compare != null && In.FullName == Compare.FullName;
            }
        public static List<Type> GetTypes<T>(this List<T> In)
            {
            return In.Convert(L.Object_GetType.Cast<Object, Type, T, Type>());
            }
        public static Type[] GetTypes<T>(this T[] In)
            {
            return In.Convert(L.Object_GetType.Cast<Object, Type, T, Type>());
            }
        public static Boolean HasSetterField(this MemberInfo In)
            {
            if (In is PropertyInfo)
                return ((PropertyInfo)In).CanWrite;
            else if (In is FieldInfo)
                return !((FieldInfo)In).IsLiteral && !((FieldInfo)In).IsInitOnly;
            else if (In is MethodInfo)
                return false;
            else
                throw new Exception("Unknown type: " + In.GetType().Name);
            }
        public static T New<T>(this Type In, Object[] Arguments = null)
            {
            return (T)In.New(Arguments, typeof(T));
            }
        public static Object New(this Type In, Type GenericType = null)
            {
            return In.New(null, GenericType);
            }
        public static Object New(this Type In, Object[] Arguments, Type GenericType = null)
            {
            try
                {
                if (In.IsValueType)
                    return Activator.CreateInstance(In);

                Arguments = Arguments ?? new Object[] { };

                if (In.ContainsGenericParameters && GenericType != null)
                    {
                    List<Type[]> TypeArgs_Base = new List<Type[]>();

                    GenericType.Traverse((t) =>
                         {
                             if (t.IsGenericType)
                                 TypeArgs_Base.Add(t.GetGenericArguments());

                             return t.BaseType;
                         });

                    TypeArgs_Base.Reverse();
                    TypeArgs_Base.Add(new Type[] { GenericType });

                    int InGenericArgs = In.GetGenericArguments().Length;

                    TypeArgs_Base.While((Types) =>
                    {
                        if (InGenericArgs == Types.Length)
                            {
                            try
                                {
                                In = In.MakeGenericType(Types);
                                return false;
                                }
                            catch
                                {
                                }
                            }

                        return true;
                    });
                    }

                Type[] ArgTypes = Arguments.GetTypes();

                ConstructorInfo Const = In.AlsoBaseTypes().First((t) => { return t.GetConstructor(ArgTypes); });

                if (Const == null)
                    {
                    throw new Exception("Could not find constructor");
                    }

                return Const.Invoke(Arguments);
                }
            catch (Exception e)
                {
                throw new Exception("Could not instanciate type: " + In.FullName, e);
                }
            }
        public static Type GetMemberType(this MemberInfo In)
            {
            if (In is PropertyInfo)
                {
                return ((PropertyInfo)In).PropertyType;
                }
            else if (In is FieldInfo)
                {
                return ((FieldInfo)In).FieldType;
                }
            else if (In is MethodInfo)
                {
                return ((MethodInfo)In).ReturnType;
                }
            else
                {
                return null;
                }
            }
        public static List<MemberInfo> Members(this Type In, Type t)
            {
            return In.Members(t, true);
            }
        public static List<MemberInfo> Members(this Type In, Type t, Boolean IncludeSubclasses)
            {
            List<MemberInfo> Out = In.GetMembers().List().Select((Member) =>
            {
                Type t2 = Member.GetMemberType();
                return t2.IsType(t);
            });

            if (IncludeSubclasses && In.BaseType != null)
                Out.AddRange(In.BaseType.Members(t));
            return Out;
            }
        public static List<T> GetValues<T>(this Type In, Object Obj)
            {
            return In.GetValues<T>(Obj, true);
            }
        public static List<T> GetValues<T>(this Type In, Object Obj, Boolean IncludeSubclasses)
            {
            List<MemberInfo> Members = In.Members(typeof(T), IncludeSubclasses);
            return Members.GetValues<T>(Obj);
            }
        public static List<T> InstanciateValues<T>(this Type In, Object Obj, Boolean IncludeSubclasses)
            {
            List<MemberInfo> Members = In.Members(typeof(T), IncludeSubclasses);
            return Members.GetValues<T>(Obj, true);
            }
        public static List<T> GetValues<T>(this List<MemberInfo> In, Object Obj)
            {
            return In.GetValues<T>(Obj, false);
            }
        public static List<T> InstanciateValues<T>(this List<MemberInfo> In, Object Obj)
            {
            return In.GetValues<T>(Obj, true);
            }
        public static List<T> GetValues<T>(this List<MemberInfo> In, Object Obj, Boolean Instanciate)
            {
            List<T> Out = new List<T>();
            Out = In.Convert<MemberInfo, T>((o) =>
            {
                Object o2 = o.GetValue(Obj);
                if (Instanciate && o2 == null)
                    {
                    o2 = o.MemberType().New();
                    o.SetValue(Obj, o2);
                    }

                if (o2 != null && o2.GetType().IsType(typeof(T)) &&
                    !Out.Contains((T)o2))
                    {
                    return (T)o2;
                    }
                return default(T);
            });

            return Out;
            }
        public static void SetValue(this MemberInfo In, Object Obj, Object Value)
            {
            try
                {
                if (In is PropertyInfo && ((PropertyInfo)In).CanWrite)
                    ((PropertyInfo)In).SetValue(Obj, Value, new object[] { });
                else if (In is FieldInfo)
                    ((FieldInfo)In).SetValue(Obj, Value);
                }
            catch (Exception e)
                {
                throw new Exception(In.Name, e);
                }
            }
        public static Object GetValue(this MemberInfo In, Object Obj)
            {
            try
                {
                if (In is PropertyInfo)
                    {
                    return ((PropertyInfo)In).GetValue(Obj, null);
                    }
                else if (In is FieldInfo)
                    {
                    return ((FieldInfo)In).GetValue(Obj);
                    }
                else
                    {
                    return null;
                    }
                }
            catch (Exception e)
                {
                throw new Exception(In.Name, e);
                }
            }
        public static IComparer GetComparer(this MemberInfo In)
            {
            return (IComparer)new ComparableComparer();
            }
        public static IComparer<T> GetComparer<T>(this MemberInfo In)
            {
            Type t = In.GetMemberType();

            if (t.TypeEquals(typeof(float)) ||
                    t.TypeEquals(typeof(int)) ||
                    t.TypeEquals(typeof(long)) ||
                    t.TypeEquals(typeof(Guid)) ||
                    t.TypeEquals(typeof(DateTime)) ||
                    t.TypeEquals(typeof(Boolean)) ||
                    t.TypeEquals(typeof(String)))
                {
                return (IComparer<T>)new ComparableComparer();
                }
            else
                {
                return null;
                }
            }

        public static Boolean HasInterface2(this Type In, Type Interface, Boolean IncludeBaseTypes = true)
            {
            if (IncludeBaseTypes && In.BaseType != null)
                return In.GetInterfaces().Has(Interface) ||
                    In.BaseType.HasInterface2(Interface, IncludeBaseTypes);

            return In.GetInterfaces().Has(Interface);
            }
        public static Boolean HasInterface<T>(this Type In, Boolean IncludeBaseTypes = true)
            {
            Type Interface = typeof(T);

            if (IncludeBaseTypes && In.BaseType != null)
                return In.GetInterfaces().Has(Interface) ||
                    In.BaseType.HasInterface<T>(IncludeBaseTypes);

            return In.GetInterfaces().Has(Interface);
            }

        public static String GetAttributeTypeName(this ICustomAttributeProvider p)
            {
            if (p is Type)
                return ((Type)p).FullName;
            else if (p is MemberInfo)
                return ((MemberInfo)p).DeclaringType.FullName;
            else if (p is AttributeList)
                return ((AttributeList)p).TypeName;
            else if (p is ParameterInfo)
                return ((ParameterInfo)p).Member.DeclaringType.FullName;
            else
                {
                throw new Exception("Could not get attribute type name: " + p.GetType().FullName);
                }
            }

        public static T MemberGetAttribute<T>(this ICustomAttributeProvider p, Boolean IncludeBaseTypes)
            {
            Object o = L.MemberInfo_GetAttribute(p.GetAttributeTypeName(), p, typeof(T), IncludeBaseTypes);

            if (o is T)
                return (T)o;

            return default(T);
            }
        public static Boolean MemberHasAttribute<T>(this ICustomAttributeProvider p, Boolean IncludeBaseTypes)
            {
            return p.MemberHasAttribute(typeof(T), IncludeBaseTypes);
            }
        public static Boolean MemberHasAttribute(this ICustomAttributeProvider p, Type a, Boolean IncludeBaseTypes)
            {
            return L.MemberInfo_GetAttribute(p.GetAttributeTypeName(), p, a, IncludeBaseTypes) != null;
            }
        public static List<T> MemberGetAttributes<T>(this ICustomAttributeProvider p, Boolean IncludeBaseTypes)
            where T : class
            {
            List<T> Out = p.GetCustomAttributes(typeof(T), true).Filter<T>();
            if (IncludeBaseTypes &&
                p is MemberInfo &&
                ((MemberInfo)p) != null &&
                ((MemberInfo)p).DeclaringType != null &&
                ((MemberInfo)p).DeclaringType.BaseType != null)
                {
                MemberInfo[] BaseMembers = null;

                try
                    {
                    BaseMembers = ((MemberInfo)p).DeclaringType.BaseType.GetMember(((MemberInfo)p).Name);
                    }
                catch
                    {
                    }

                if (!BaseMembers.IsEmpty())
                    {
                    BaseMembers.Each((m) =>
                    {
                        Out.AddRange(MemberGetAttributes<T>(m, IncludeBaseTypes));
                    });
                    }
                }

            if (typeof(T).HasInterface<IL_Attribute_ReverseOrder>(true))
                Out.Reverse();
            return Out;
            }

        public static List<Type> AlsoBaseTypes(this Type In)
            {
            List<Type> Out = In.BaseTypes();
            Out.Insert(0, In);
            return Out;
            }
        public static List<Type> BaseTypes(this Type In)
            {
            List<Type> Out = new List<Type>();
            while (In.BaseType != null)
                {
                Out.Add(In.BaseType);
                In = In.BaseType;
                }
            return Out;
            }
        public static MethodInfo FindMethod(this Type In, String Name)
            {
            return In.FindMethod(Name, new Type[] { });
            }
        public static MethodInfo FindMethod(this Type In, String Name, Type[] Arguments)
            {
            Type t = In;

            while (t != null)
                {
                if (In.GetMethod(Name, Arguments) != null)
                    return t.GetMethod(Name, Arguments);

                if (t.UnderlyingSystemType != null &&
                    t.UnderlyingSystemType.GetMethod(Name, Arguments) != null)
                    return t.UnderlyingSystemType.GetMethod(Name, Arguments);

                t = t.BaseType;
                }

            return null;
            }
        public static Type MemberType(this MemberInfo In)
            {
            if (In is PropertyInfo)
                return ((PropertyInfo)In).PropertyType;
            else if (In is FieldInfo)
                return ((FieldInfo)In).FieldType;
            else if (In is MethodInfo)
                return ((MethodInfo)In).ReturnType;
            else
                throw new Exception("Unknown Member Type: " + In.GetType().FullName);
            }
        public static T GetNewSubclass<T>(this Type RootType, Object[] Params = null)
            {
            return GetNewSubclass<T>(RootType, typeof(T).Name, Params);
            }
        public static T GetNewSubclass<T>(this Type RootType, String Name, Object[] Params = null)
            {
            return RootType.GetNewSubclass<T>(RootType, Name, Params);
            }
        private static T GetNewSubclass<T>(this Type RootType, Type t, String Name, Object[] Params = null)
            {
            return RootType.GetNewSubclass<T>(new Type[] { }, t, Name, Params);
            }
        private static Dictionary<String, ConstructorInfo> GetNewSubclass_ResultCache = new Dictionary<String, ConstructorInfo>();
        private static T GetNewSubclass<T>(this Type RootType, Type[] GenericStash, Type t, String Name, Object[] Params = null)
            {
            Params = Params ?? new Object[] { };

            String CacheName = typeof(T).FullName + "_" + t.FullName + "_" + Name + "_" + Params.Length;
            if (GetNewSubclass_ResultCache.ContainsKey(CacheName))
                {
                ConstructorInfo CachedConstructor = GetNewSubclass_ResultCache[CacheName];

                return (T)CachedConstructor.Invoke(Params);
                }

            List<Type> Types = t.GetNestedTypes().List();
            T Out = default(T);
            Types.While((t2) =>
            {
                if (t2.Name == Name ||
                    t2.IsType(typeof(T)) ||
                    (t2.IsGenericType && typeof(T).IsGenericType &&
                    (t2.GetGenericTypeDefinition().IsType(typeof(T).GetGenericTypeDefinition()))))
                    {
                    Type[] GenericArgs = t2.GetGenericArguments();

                    ConstructorInfo Const = null;
                    Type[] GenericTypes = new Type[] { };
                    if (GenericArgs.Length == 1)
                        {
                        GenericTypes = new Type[] { RootType };
                        }
                    else if (GenericArgs.Length == 2 && GenericStash.Length == 1)
                        {
                        GenericTypes = new Type[] { RootType, GenericStash[0] };
                        }
                    else if (GenericArgs.Length == GenericStash.Length)
                        {
                        GenericTypes = GenericStash;
                        }

                    if (GenericTypes.Length > 0)
                        {
                        try
                            {
                            t2 = t2.MakeGenericType(GenericTypes);
                            }
                        catch
                            {
                            }
                        }
                    if (t2.ContainsGenericParameters)
                        {
                        t2 = t2.MakeGenericType(t.GetGenericArguments());
                        }

                    Const = t2.GetConstructor(Params.GetTypes());
                    GetNewSubclass_ResultCache.Add(CacheName, Const);
                    Object O = Const.Invoke(Params);
                    if (!(O is T))
                        {
                        return false;
                        }
                    Out = (T)O;
                    return false;
                    }
                return true;
            });

            if (Out != null)
                return Out;

            Type BaseType = null;
            if (t.IsGenericType && t.BaseType != null && !t.BaseType.IsGenericType)
                {
                Type[] temp = t.GetGenericArguments();
                if (GenericStash.Length > 0)
                    {
                    GenericStash = GenericStash.Add(temp);
                    }
                else
                    {
                    GenericStash = temp;
                    }

                BaseType = t.GetGenericTypeDefinition();
                if (t.TypeEquals(BaseType))
                    {
                    BaseType = null;
                    }
                }

            if (BaseType == null && t.BaseType != null && !t.BaseType.TypeEquals(t))
                {
                BaseType = t.BaseType;
                }

            if (BaseType != null)
                {
                Out = RootType.GetNewSubclass<T>(GenericStash, BaseType, Name, Params);
                }

            return Out;
            }

        public static Type GetSubClass(this Type In, String SubClassName)
            {
            return In.AlsoBaseTypes().Collect((t) =>
                {
                    Type Out = t.GetNestedTypes().First((t2) => { return t2.Name == SubClassName; });
                    return Out;
                }).First();
            }
        public static List<Type> GetSubClasses(this Type In)
            {
            List<Type> Out = new List<Type>();
            In.AlsoBaseTypes().Each((t) =>
            {
                Out.AddRange(t.GetNestedTypes());
            });
            return Out;
            }

        public static String GetFriendlyTypeName(this Type In)
            {
            if (In == null)
                {
                return "";
                }

            if (In.Namespace == "System.Data.Entity.DynamicProxies")
                In = In.BaseType;

            if (In.IsGenericType && In.Name.Has('`'))
                {
                String Out = "";
                Out += In.Name.Remove(In.Name.IndexOf('`'));
                Out += "<";
                Type[] Arguments = In.GetGenericArguments();

                Arguments.EachI((i, arg) =>
                {
                    Out += arg.GetFriendlyTypeName();
                    if (i < Arguments.Length - 1)
                        {
                        Out += ", ";
                        }
                });
                Out += ">";
                return Out;
                }
            else if (In.MemberHasAttribute<IL_FriendlyName>(true))
                return In.MemberGetAttribute<IL_FriendlyName>(true).FriendlyName;
            else
                {
                return In.Name.Humanize();
                }
            }

        public static Type FindType(String TypeName)
            {
            var Out = System.Type.GetType(TypeName);

            if (Out != null)
                return Out;

            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
                {
                Out = a.GetType(TypeName);

                if (Out != null)
                    return Out;
                }

            return null;
            }

        }
    }
