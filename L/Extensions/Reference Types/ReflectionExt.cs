using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using LCore.Dynamic;
using LCore.Extensions.Optional;
using LCore.Interfaces;
using LCore.Naming;
using LCore.Tests;
using NSort;

// ReSharper disable UnusedMember.Global

namespace LCore.Extensions
    {
    /// <summary>
    /// Provides extension methods for reflection classes:
    /// Type, MemberInfo, MethodInfo, PropertyInfo, FieldInfo
    /// </summary>
    [ExtensionProvider]
    public static class ReflectionExt
        {
        #region Extensions +

        #region AlsoBaseTypes

        /// <summary>
        /// Returns a list of the provided type <paramref name="In" /> as well as all of <paramref name="In" />'s base types.
        /// </summary>
        [Tested]
        public static List<Type> AlsoBaseTypes([CanBeNull] this Type In)
            {
            List<Type> Out = In.BaseTypes();
            Out.Insert(0, In);
            return Out;
            }

        #endregion

        #region BaseTypes

        /// <summary>
        /// Returns a list of all of <paramref name="In" />'s base types.
        /// </summary>
        [Tested]
        public static List<Type> BaseTypes([CanBeNull] this Type In)
            {
            var Out = new List<Type>();
            while (In?.BaseType != null)
                {
                Out.Add(In.BaseType);
                In = In.BaseType;
                }
            return Out;
            }

        #endregion

        #region FindMethod

        /// <summary>
        /// Finds a method by name, searching the Type <paramref name="In" /> as well as all
        /// base types.
        /// Optionally include a Type[] <paramref name="Arguments" /> to specify the method arguments.
        /// </summary>
        /// <exception cref="AmbiguousMatchException">More than one method is found with the specified name and specified parameters. </exception>
        [Tested]
        [CanBeNull]
        public static MethodInfo FindMethod([CanBeNull] this Type In, [CanBeNull] string Name, [CanBeNull] Type[] Arguments = null)
            {
            Name = Name ?? "";

            Arguments = Arguments ?? new Type[] {};

            var Type = In;

            while (Type != null)
                {
                if (In.GetMethod(Name, Arguments) != null)
                    return Type.GetMethod(Name, Arguments);

                if (Type.UnderlyingSystemType.GetMethod(Name, Arguments) != null)
                    return Type.UnderlyingSystemType.GetMethod(Name, Arguments);

                Type = Type.BaseType;
                }

            return null;
            }

        /// <summary>
        /// Finds a method by name, searching the Type <paramref name="In" /> as well as all
        /// base types.
        /// Supply Type parameters to locate a method by its parameter types.
        /// </summary>
        /// <exception cref="AmbiguousMatchException">More than one method is found with the specified name and specified parameters. </exception>
        [Tested]
        [CanBeNull]
        public static MethodInfo FindMethod<T>([CanBeNull] this Type In, [CanBeNull] string Name)
            {
            return In.FindMethod(Name, new[] {typeof(T)});
            }

        /// <summary>
        /// Finds a method by name, searching the Type <paramref name="In" /> as well as all
        /// base types.
        /// Supply Type parameters to locate a method by its parameter types.
        /// </summary>
        /// <exception cref="AmbiguousMatchException">More than one method is found with the specified name and specified parameters. </exception>
        [Tested]
        [CanBeNull]
        public static MethodInfo FindMethod<T1, T2>([CanBeNull] this Type In, [CanBeNull] string Name)
            {
            return In.FindMethod(Name, new[] {typeof(T1), typeof(T2)});
            }

        /// <summary>
        /// Finds a method by name, searching the Type <paramref name="In" /> as well as all
        /// base types.
        /// Supply Type parameters to locate a method by its parameter types.
        /// </summary>
        /// <exception cref="AmbiguousMatchException">More than one method is found with the specified name and specified parameters. </exception>
        [Tested]
        [CanBeNull]
        public static MethodInfo FindMethod<T1, T2, T3>([CanBeNull] this Type In, [CanBeNull] string Name)
            {
            return In.FindMethod(Name, new[] {typeof(T1), typeof(T2), typeof(T3)});
            }

        /// <summary>
        /// Finds a method by name, searching the Type <paramref name="In" /> as well as all
        /// base types.
        /// Supply Type parameters to locate a method by its parameter types.
        /// </summary>
        /// <exception cref="AmbiguousMatchException">More than one method is found with the specified name and specified parameters. </exception>
        [Tested]
        [CanBeNull]
        public static MethodInfo FindMethod<T1, T2, T3, T4>([CanBeNull] this Type In, [CanBeNull] string Name)
            {
            return In.FindMethod(Name, new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4)});
            }

        #endregion

        #region FullyQualifiedName

        /// <summary>
        /// Returns the fully qualified name for a member
        /// </summary>
        [Tested]
        public static string FullyQualifiedName([CanBeNull] this MemberInfo In)
            {
            if (In is TypeInfo)
                {
                return ((TypeInfo) In).FullName.ReplaceAll("+", ".");
                }
            if (In is PropertyInfo || In is FieldInfo || In is EventInfo || In is MethodInfo)
                {
                string BaseName = (In.ReflectedType ?? In.DeclaringType)?.FullName;
                return $"{BaseName}.{In.Name}".ReplaceAll("+", ".");
                }
            return "";
            }

        #endregion

        #region GetAttribute

        /// <summary>
        /// Returns an attribute of type <typeparamref name="T" /> if it exists.
        /// </summary>
        [Tested]
        [TestMethodGenerics(typeof(FriendlyNameAttribute))]
        //[TestResult(new object[] { null }, default(IPersistAttribute))]
        [CanBeNull]
        public static T GetAttribute<T>([CanBeNull] this ICustomAttributeProvider AttributeProvider)
            where T : IPersistAttribute
            {
            if (AttributeProvider == null)
                return default(T);

            bool Persist = typeof(T).HasInterface<ISubClassPersistentAttribute>();
            return AttributeProvider.GetAttribute<T>(Persist);
            }

        /// <summary>
        /// Returns an attribute of type <typeparamref name="T" /> if it exists.
        /// </summary>
        [Tested]
        [CanBeNull]
        public static T GetAttribute<T>([CanBeNull] this ICustomAttributeProvider AttributeProvider, bool IncludeBaseTypes)
            {
            if (AttributeProvider == null)
                return default(T);

            // ReSharper disable once EventExceptionNotDocumented
            var Attribute = L.Ref.GetAttribute(AttributeProvider.GetAttributeTypeName(), AttributeProvider, typeof(T), IncludeBaseTypes);

            if (Attribute is T)
                return (T) Attribute;

            return default(T);
            }

        #endregion

        #region GetAttributes

        /// <summary>
        /// Returns all attributes of type <typeparamref name="T" />.
        /// </summary>
        [Tested]
        public static List<T> GetAttributes<T>([CanBeNull] this ICustomAttributeProvider AttributeProvider, bool IncludeBaseTypes)
            where T : class
            {
            List<T> Out = AttributeProvider?.GetCustomAttributes(typeof(T), IncludeBaseTypes).Filter<T>() ?? new List<T>();

            if (typeof(T).HasInterface<IReverseAttributeOrder>())
                Out.Reverse();

            return Out;
            }

        #endregion

        #region GetAttributeTypeName

        /// <summary>
        /// Returns the name of the attribute type.
        /// </summary>
        /// <exception cref="ArgumentException">Unsupported / unknown attribute provider is passed.</exception>
        [Tested]
        public static string GetAttributeTypeName([CanBeNull] this ICustomAttributeProvider AttributeProvider)
            {
            if (AttributeProvider == null)
                return "";

            var Type1 = AttributeProvider as Type;
            if (Type1 != null)
                return Type1.FullName;

            var Info = AttributeProvider as MemberInfo;
            if (Info != null)
                return Info.DeclaringType?.FullName;

            var List = AttributeProvider as AttributeList;
            if (List != null)
                return List.TypeName;

            var ParameterInfo = AttributeProvider as ParameterInfo;
            if (ParameterInfo != null)
                return ParameterInfo.Member.DeclaringType?.FullName;

            throw new ArgumentException($"Could not get attribute type name: {AttributeProvider.GetType().FullName}",
                nameof(AttributeProvider));
            }

        #endregion

        #region GetClassHierarchy

        /// <summary>
        /// Returns the full hierarchy of classes if <paramref name="In" /> is a nested class.
        /// Ex. "L.Comment.Test"
        /// </summary>
        [Tested]
        public static string GetClassHierarchy([CanBeNull] this Type In)
            {
            return In?.FullName.AfterLast(".").ReplaceAll("+", ".") ?? "";
            }

        #endregion

        #region GetComparer

        /// <summary>
        /// Returns a ComparableComparer to compare comparable types.
        /// </summary>
        [Tested]
        // ReSharper disable once UnusedParameter.Global
        public static IComparer GetComparer([CanBeNull] this MemberInfo In)
            {
            return new ComparableComparer();
            }

        /// <summary>
        /// Returns a ComparableComparer to compare comparable types.
        /// Returns a strongly typed IComparer<typeparamref name="T" /> if you know the type you're comparing.
        /// </summary>
        [Tested]
        [CanBeNull]
        public static IComparer<T> GetComparer<T>([CanBeNull] this MemberInfo In)
            {
            var Type = In.GetMemberType();

            if (Type != null && Type.HasInterface<IComparable>() && typeof(T) != typeof(object))
                {
                return (IComparer<T>) new ComparableComparer();
                }
            return null;
            }

        #endregion

        #region GetExtensionMethods

        /// <summary>
        /// Returns all Extension methods declared on Type <paramref name="In" />
        /// </summary>
        [Tested]
        public static MethodInfo[] GetExtensionMethods([CanBeNull] this Type In)
            {
            return In?.GetMethods()
                .Select(Method => Method.IsStatic &&
                                  Method.IsPublic &&
                                  Method.IsDefined(typeof(ExtensionAttribute), true))
                .Array();
            }

        #endregion

        #region GetMemberType

        /// <summary>
        /// Returns the FieldType of the field, PropertyType of the property, 
        /// or ReturnType of the method.
        /// </summary>
        [Tested]
        [CanBeNull]
        public static Type GetMemberType([CanBeNull] this MemberInfo In)
            {
            var EventInfo = In as EventInfo;
            if (EventInfo != null)
                {
                return EventInfo.EventHandlerType;
                }
            var PropertyInfo = In as PropertyInfo;
            if (PropertyInfo != null)
                {
                return PropertyInfo.PropertyType;
                }
            var FieldInfo = In as FieldInfo;
            if (FieldInfo != null)
                {
                return FieldInfo.FieldType;
                }

            var MethodInfo = In as MethodInfo;
            return MethodInfo?.ReturnType;
            }

        #endregion

        #region GetSubClass

        /// <summary>
        /// Gets a subclass from a type <paramref name="In" /> or any of its base classes.
        /// Subclass from a descendant will be used before an ancestor subclasses.
        /// </summary>
        [Tested]
        public static Type GetSubClass([CanBeNull] this Type In, [CanBeNull] string SubClassName)
            {
            return In.AlsoBaseTypes().Collect(Type =>
                {
                var Out = Type.GetNestedTypes().First(NestedType => NestedType.Name == SubClassName);
                return Out;
                }).First();
            }

        #endregion

        #region GetSubClasses

        /// <summary>
        /// Gets a subclasses from a type <paramref name="In" /> or any of its base classes.
        /// Subclasses from a descendant will be used before an ancestor subclasses.
        /// </summary>
        [Tested]
        public static List<Type> GetSubClasses([CanBeNull] this Type In)
            {
            var Out = new List<Type>();
            In.AlsoBaseTypes().Each(Type => { Out.AddRange(Type.GetNestedTypes()); });
            return Out;
            }

        #endregion

        #region GetFriendlyTypeName

        /// <summary>
        /// Returns a friendly name for a type including generic type arguments.
        /// </summary>
        [Tested]
        public static string GetFriendlyTypeName([CanBeNull] this Type In)
            {
            if (In == null)
                return "";

            if (In.Namespace == "System.Data.Entity.DynamicProxies" || In.Name.Contains("Proxy"))
                In = In.BaseType;

            if (In?.IsGenericType == true && In.Name.Has('`'))
                {
                string Out = "";
                Out += In.Name.Remove(In.Name.IndexOf('`'));
                Out += "<";
                Type[] Arguments = In.GetGenericArguments();

                Arguments.Each((i, Argument) =>
                    {
                    Out += Argument.Name;
                    if (i < Arguments.Length - 1)
                        {
                        Out += ", ";
                        }
                    });
                Out += ">";
                return Out;
                }
            return In.GetAttribute<IFriendlyName>()?.FriendlyName ?? In?.Name.Humanize();
            }

        #endregion

        #region GetValue

        /// <summary>
        /// Returns the value from a specific object.
        /// If the field is not found an Exception will be thrown.
        /// </summary>
        /// <exception cref="ArgumentException">If the MemberInfo <paramref name="In" /> cannot be found on <paramref name="Obj" />.</exception>
        [Tested]
        [CanBeNull]
        public static object GetValue([CanBeNull] this MemberInfo In, [CanBeNull] object Obj)
            {
            try
                {
                var PropertyInfo = In as PropertyInfo;
                if (PropertyInfo != null)
                    {
                    return PropertyInfo.GetValue(Obj, null);
                    }
                var FieldInfo = In as FieldInfo;
                return FieldInfo?.GetValue(Obj);
                }
            catch (Exception Ex)
                {
                throw new ArgumentException(In?.Name, nameof(In), Ex);
                }
            }

        #endregion

        #region GetValues

        /// <summary>
        /// Returns a list of all member values, optionally include subclasses.
        /// </summary>
        [Tested]
        public static List<T> GetValues<T>([CanBeNull] this Type In, [CanBeNull] object Obj, bool IncludeBaseClasses = true)
            {
            if (In == null)
                return new List<T>();

            List<MemberInfo> Members = In.MembersOfType(typeof(T), IncludeBaseClasses);
            return Members.RemoveDuplicate(Member => Member.Name).GetValues<T>(Obj);
            }

        /// <summary>
        /// Returns a list of object values from a list of members.
        /// Optionally, set <paramref name="Instantiate" /> to true to instantiate null members.
        /// </summary>
        [Tested]
        public static List<T> GetValues<T>([CanBeNull] this IEnumerable<MemberInfo> In, [CanBeNull] object Obj, bool Instantiate = false)
            {
            var Out = new List<T>();

            if (Obj == null)
                return Out;

            Out = In.Convert(o =>
                {
                var Obj2 = o.GetValue(Obj);
                if (Instantiate && Obj2 == null)
                    {
                    Obj2 = o.MemberType().New();
                    o.SetValue(Obj, Obj2);
                    }

                if (Obj2?.GetType().IsType(typeof(T)) == true &&
                    !Out.Contains((T) Obj2))
                    {
                    return (T) Obj2;
                    }
                return default(T);
                });

            return Out;
            }

        #endregion

        #region GetTestData

        /// <summary>
        /// Creates a new TypeTests object, detailing the test coverage of the provided type.
        /// </summary>
        [Tested]
        public static TypeTests GetTestData([CanBeNull] this Type In)
            {
            return new TypeTests(In);
            }

        #endregion

        #region GetTypes

        /// <summary>
        /// Returns a list of the types of all elements within <paramref name="In" />.
        /// </summary>
        public static List<Type> GetTypes<T>([CanBeNull] this IEnumerable<T> In)
            {
            return In.Convert(i => i.GetType());
            }

        /// <summary>
        /// Returns an array of the types of all elements within <paramref name="In" />.
        /// </summary>
        public static Type[] GetTypes<T>([CanBeNull] this T[] In)
            {
            return In.Convert(i => i.GetType());
            }

        #endregion

        #region HasAttribute

        /// <summary>
        /// Returns whether a member has a certain attribute type <typeparamref name="T" />.
        /// </summary>
        [Tested]
        public static bool HasAttribute<T>([CanBeNull] this ICustomAttributeProvider AttributeProvider)
            where T : IPersistAttribute
            {
            if (AttributeProvider == null)
                return false;

            bool Persist = typeof(T).HasInterface<ISubClassPersistentAttribute>();
            return AttributeProvider.HasAttribute<T>(Persist);
            }

        /// <summary>
        /// Returns whether a member has a certain attribute type <typeparamref name="T" />.
        /// Optionally, look on base type members for the attribute.
        /// </summary>
        [Tested]
        public static bool HasAttribute<T>([CanBeNull] this ICustomAttributeProvider AttributeProvider, bool IncludeBaseClasses)
            {
            return AttributeProvider != null && AttributeProvider.HasAttribute(typeof(T), IncludeBaseClasses);
            }

        /// <summary>
        /// Returns whether a member has a certain attribute type <paramref name="AttributeProvider" />.
        /// Optionally, look on base type members for the attribute.
        /// </summary>
        [Tested]
        public static bool HasAttribute([CanBeNull] this ICustomAttributeProvider AttributeProvider, [CanBeNull] Type Type,
            bool IncludeBaseClasses)
            {
            if (AttributeProvider == null)
                return false;

            // ReSharper disable once EventExceptionNotDocumented
            return L.Ref.GetAttribute(AttributeProvider.GetAttributeTypeName(), AttributeProvider, Type, IncludeBaseClasses) != null;
            }

        #endregion

        #region HasInterface

        /// <summary>
        /// Returns whether or not a given type <paramref name="In" /> implements an interface.
        /// Optionally, IncludeBaseTypes can be set to false to only look within top-level classes.
        /// </summary>
        [Tested]
        public static bool HasInterface([CanBeNull] this Type In, [CanBeNull] Type Interface)
            {
            if (In == null || Interface == null)
                return false;

            return In.GetInterfaces().Has(Interface);
            }

        /// <summary>
        /// Returns whether or not a given type <paramref name="In" /> implements an interface.
        /// Optionally, IncludeBaseTypes can be set to false to only look within top-level classes.
        /// </summary>
        [Tested]
        public static bool HasInterface<T>([CanBeNull] this Type In)
            {
            if (In == null)
                return false;

            var Interface = typeof(T);

            return In.GetInterfaces().Has(Interface);
            }

        #endregion

        #region HasIndexGetter

        /// <summary>
        /// Determines if a Type <paramref name="Type"/> has an Indexer
        /// of the specified type: <paramref name="Type"/>[<typeparamref name="TKey"/>] == <typeparamref name="TValue"/>
        /// </summary>
        [Tested]
        public static bool HasIndexGetter<TKey, TValue>([CanBeNull] this Type Type)
            {
            return Type.IndexGetter<TKey, TValue>() != null;
            }

        /// <summary>
        /// Determines if a Type <paramref name="Type"/> has an Indexer
        /// of the specified type: <paramref name="Type"/>[<typeparamref name="TKey"/>] == object
        /// </summary>
        [Tested]
        public static bool HasIndexGetter<TKey>([CanBeNull] this Type Type)
            {
            return Type.IndexGetter<TKey>() != null;
            }

        #endregion

        #region HasIndexSetter

        /// <summary>
        /// Determines if a Type <paramref name="Type"/> has an Indexer
        /// of the specified type: <paramref name="Type"/>[<typeparamref name="TKey"/>] == <typeparamref name="TValue"/>
        /// </summary>
        [Tested]
        public static bool HasIndexSetter<TKey, TValue>([CanBeNull] this Type Type)
            {
            return Type.IndexSetter<TKey, TValue>() != null;
            }

        /// <summary>
        /// Determines if a Type <paramref name="Type"/> has an Indexer
        /// of the specified type: <paramref name="Type"/>[<typeparamref name="TKey"/>] == object
        /// </summary>
        [Tested]
        public static bool HasIndexSetter<TKey>([CanBeNull] this Type Type)
            {
            return Type.IndexSetter<TKey>() != null;
            }

        #endregion

        #region HasSetter

        /// <summary>
        /// Returns whether a MemberInfo has a setter.
        /// </summary>
        /// <exception cref="ArgumentException">If an unknown MemberInfo type is passed.</exception>
        [Tested]
        public static bool HasSetter([CanBeNull] this MemberInfo In)
            {
            if (In == null)
                return false;

            var PropertyInfo = In as PropertyInfo;

            if (PropertyInfo != null)
                return PropertyInfo.CanWrite && PropertyInfo.SetMethod != null && PropertyInfo.SetMethod.IsPublic;

            var FieldInfo = In as FieldInfo;

            if (FieldInfo != null)
                return !FieldInfo.IsLiteral && !FieldInfo.IsInitOnly;

            if (In is MethodInfo || In is EventInfo)
                return false;

            throw new ArgumentException($"Unknown type: {In.GetType().Name}", nameof(In));
            }

        #endregion

        #region IndexGetter

        /// <summary>
        /// Returns an Indexer of the specified type, if a getter is available.
        /// <paramref name="Type"/>[<typeparamref name="TKey"/>] == <typeparamref name="TValue"/>
        /// </summary>
        [CanBeNull]
        [Tested]
        public static PropertyInfo IndexGetter<TKey, TValue>([CanBeNull] this Type Type)
            {
            return Type?.GetMembers().First<PropertyInfo>(
                Member => Member.Name == "Item" &&
                          Member.CanRead &&
                          Member.GetMethod.ReturnType == typeof(TValue) &&
                          Member.GetMethod.GetParameters().Length == 1 &&
                          Member.GetMethod.GetParameters()[0].ParameterType == typeof(TKey));
            }

        /// <summary>
        /// Returns an Indexer of the specified type, if a getter is available.
        /// <paramref name="Type"/>[<typeparamref name="TKey"/>] == object
        /// </summary>
        [CanBeNull]
        [Tested]
        public static PropertyInfo IndexGetter<TKey>([CanBeNull] this Type Type)
            {
            return Type?.GetMembers().First<PropertyInfo>(
                Member => Member.Name == "Item" &&
                          Member.CanRead &&
                          Member.GetMethod.GetParameters().Length == 1 &&
                          Member.GetMethod.GetParameters()[0].ParameterType == typeof(TKey));
            }

        #endregion

        #region IndexSetter

        /// <summary>
        /// Returns an Indexer of the specified type, if a setter is available.
        /// <paramref name="Type"/>[<typeparamref name="TKey"/>] == <typeparamref name="TValue"/>
        /// </summary>
        [CanBeNull]
        public static PropertyInfo IndexSetter<TKey, TValue>([CanBeNull] this Type Type)
            {
            return Type?.GetMembers().First<PropertyInfo>(
                Member => Member.Name == "Item" &&
                          Member.CanWrite &&
                          Member.SetMethod.GetParameters().Length == 2 &&
                          Member.SetMethod.GetParameters()[0].ParameterType == typeof(TKey) &&
                          Member.SetMethod.GetParameters()[1].ParameterType == typeof(TValue));
            }

        /// <summary>
        /// Returns an Indexer of the specified type, if a setter is available.
        /// <paramref name="Type"/>[<typeparamref name="TKey"/>] == object
        /// </summary>
        [CanBeNull]
        public static PropertyInfo IndexSetter<TKey>([CanBeNull] this Type Type)
            {
            return Type?.GetMembers().First<PropertyInfo>(
                Member => Member.Name == "Item" &&
                          Member.CanWrite &&
                          Member.SetMethod.GetParameters().Length == 2 &&
                          Member.SetMethod.GetParameters()[0].ParameterType == typeof(TKey));
            }

        #endregion

        #region InstanciateValues

        /// <summary>
        /// Instantiates values of properties for an object.
        /// </summary>
        [Tested]
        // ReSharper disable once UnusedMethodReturnValue.Global
        public static List<T> InstantiateValues<T>([CanBeNull] this Type In, [CanBeNull] object Obj, bool IncludeBaseClasses)
            {
            if (In == null || Obj == null)
                return new List<T>();

            List<MemberInfo> Members = In.MembersOfType(typeof(T), IncludeBaseClasses);
            return Members.GetValues<T>(Obj, true);
            }

        /// <summary>
        /// Instantiates values of specific properties for an object.
        /// </summary>
        [Tested]
        // ReSharper disable once UnusedMethodReturnValue.Global
        public static List<T> InstantiateValues<T>([CanBeNull] this IEnumerable<MemberInfo> In, [CanBeNull] object Obj)
            {
            if (In == null || Obj == null)
                return new List<T>();

            return In.GetValues<T>(Obj, true);
            }

        #endregion

        #region IsExtensionMethod

        /// <summary>
        /// Returns whether a MethodInfo is an extension method or not.
        /// </summary>
        public static bool IsExtensionMethod([CanBeNull] this MethodInfo In)
            {
            return In?.IsDefined(typeof(ExtensionAttribute), true) == true;
            }

        #endregion

        #region IsNullable

        /// <summary>
        /// Determines if <paramref name="Type"/> is a nullable type.
        /// Ex: int?, bool?, (Nullable[int], Nullable[bool])
        /// </summary>
        public static bool IsNullable([CanBeNull] this Type Type)
            {
            //return Type != null && Type.IsType(typeof(Nullable<>));
            return Type?.IsGenericType == true &&
                   Type.GetGenericTypeDefinition() == typeof(Nullable<>);
            }

        #endregion

        #region IsType

        /// <summary>
        /// Returns whether object <paramref name="In" /> is type <typeparamref name="T" /> or a subclass of <typeparamref name="T" />
        /// </summary>
        [Tested]
        public static bool IsType<T>([CanBeNull] this object In)
            {
            return In != null && In.GetType().IsType(typeof(T));
            }

        /// <summary>
        /// Returns whether object <paramref name="In" /> is type <paramref name="Type" /> or a subclass of <paramref name="Type" />
        /// </summary>
        [Tested]
        public static bool IsType([CanBeNull] this object In, [CanBeNull] Type Type)
            {
            if (In == null || Type == null)
                return false;

            return In.GetType().IsType(Type);
            }

        /// <summary>
        /// Returns whether type <paramref name="In" /> is type <paramref name="Type" /> or a subclass of <paramref name="Type" />
        /// </summary>
        [Tested]
        public static bool IsType([CanBeNull] this Type In, [CanBeNull] Type Type)
            {
            if (In == null || Type == null)
                return false;

            return In.TypeEquals(Type) ||
                   In.IsSubclassOf(Type) ||
                   (Type.IsInterface && In.HasInterface(Type));
            }

        /// <summary>
        /// Returns whether type <paramref name="In" /> is type <typeparamref name="T" /> or a subclass of <typeparamref name="T" />
        /// </summary>
        [Tested]
        public static bool IsType<T>([CanBeNull] this Type In)
            {
            return In != null && In.IsType(typeof(T));
            }

        #endregion

        #region MembersOfType

        /// <summary>
        /// Return all members of type <paramref name="In" /> who expose type <paramref name="Type" />.
        /// Optionally, scan base classes.
        /// </summary>
        [Tested]
        public static List<MemberInfo> MembersOfType([CanBeNull] this Type In, [CanBeNull] Type Type, bool IncludeBaseClasses = true)
            {
            if (In == null || Type == null)
                return new List<MemberInfo>();

            return (IncludeBaseClasses
                ? In.GetMembers()
                : In.GetMembers(BindingFlags.DeclaredOnly))
                .List().Select(Member =>
                    {
                    var MemberType = Member.GetMemberType();
                    return MemberType.IsType(Type) &&
                           (!(Member is MethodInfo) || !((MethodInfo) Member).IsSpecialName);
                    });
            }

        #endregion

        #region MemberType

        /// <summary>
        /// Returns the type of the member.
        /// Uses the return value if <paramref name="In" /> is a MethodInfo.
        /// </summary>
        /// <exception cref="ArgumentException">If an unknown MemberInfo type is passed.</exception>
        [Tested]
        [CanBeNull]
        public static Type MemberType([CanBeNull] this MemberInfo In)
            {
            var Type = In?.GetType();

            while (Type != null && (Type.Name.StartsWith("Runtime") || Type.Name == "RtFieldInfo"))
                Type = Type.BaseType;

            if (Type == typeof(PropertyInfo))
                return ((PropertyInfo) In).PropertyType;
            if (Type == typeof(FieldInfo))
                return ((FieldInfo) In).FieldType;
            if (Type == typeof(MethodInfo))
                return ((MethodInfo) In).ReturnType;
            if (Type == typeof(EventInfo))
                return ((EventInfo) In).EventHandlerType;
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (Type == typeof(ConstructorInfo))
                return Type.DeclaringType;

            return null;
            }

        #endregion

        #region New

        /// <summary>
        /// Creates a new <typeparamref name="T" /> object. Optionally, pass in <paramref name="Arguments" /> to the constructor.
        /// </summary>
        [Tested]
        [CanBeNull]
        public static T New<T>([CanBeNull] this Type In, [CanBeNull] object[] Arguments = null)
            {
            return (T) In.New(Arguments, typeof(T));
            }

        /// <summary>
        /// Creates a new object. Optionally, pass in <paramref name="Arguments" /> to the constructor.
        /// If the object type is uses a generic type, you need to supply it using <paramref name="GenericType" />
        /// </summary>
        /// <exception cref="InvalidOperationException">The object could not be created, constructor was not found.</exception>
        [Tested]
        [CanBeNull]
        public static object New([CanBeNull] this Type In, [CanBeNull] object[] Arguments = null, [CanBeNull] Type GenericType = null)
            {
            try
                {
                if (In == null || In == typeof(void))
                    return null;

                if (In == typeof(string))
                    return "";

                if (In.IsValueType)
                    return Activator.CreateInstance(In);

                Arguments = Arguments ?? new object[] {};

                if (In.ContainsGenericParameters && GenericType != null)
                    {
                    var TypeArgs_Base = new List<Type[]>();

                    GenericType.Traverse(Type =>
                        {
                        if (Type.IsGenericType)
                            TypeArgs_Base.Add(Type.GetGenericArguments());

                        return Type.BaseType;
                        });

                    TypeArgs_Base.Reverse();
                    TypeArgs_Base.Add(new[] {GenericType});

                    int InGenericArgs = In.GetGenericArguments().Length;

                    TypeArgs_Base.While(Types =>
                        {
                        return InGenericArgs != Types.Length ||
                               L.F(() =>
                                   {
                                   In = In.MakeGenericType(Types);
                                   return false;
                                   }).Try()();
                        });
                    }

                Type[] ArgTypes = Arguments.GetTypes();

                var Const = In.AlsoBaseTypes().Convert(Type => Type.GetConstructor(ArgTypes)).First();

                if (Const == null)
                    {
                    throw new InvalidOperationException("Could not find constructor");
                    }

                return Const.Invoke(Arguments);
                }
            catch (Exception Ex)
                {
                throw new InvalidOperationException($"Could not instanciate type: {In?.FullName ?? "[null]"}", Ex);
                }
            }

        #endregion

        #region NewRandom

        /// <summary>
        /// Creates a new random object for many simple types.
        /// </summary>
        [CanBeNull]
        public static object NewRandom(this Type Type, object Minimum = null, object Maximum = null)
            {
            return L.Ref.NewRandom(Type, Minimum, Maximum);
            }

        #endregion

        #region SetValue

        /// <summary>
        /// Sets the member value on <paramref name="Obj" />.
        /// </summary>
        /// <param name="In"></param>
        /// <param name="Obj"></param>
        /// <param name="Value"></param>
        /// <exception cref="ArgumentException">If the MemberInfo <paramref name="In" /> was not found on Obj.</exception>
        [Tested]
        public static void SetValue([CanBeNull] this MemberInfo In, [CanBeNull] object Obj, [CanBeNull] object Value)
            {
            try
                {
                var PropertyInfo = In as PropertyInfo;
                if (PropertyInfo != null && PropertyInfo.CanWrite)
                    {
                    PropertyInfo.SetValue(Obj, Value, new object[] {});
                    return;
                    }

                var FieldInfo = In as FieldInfo;
                FieldInfo?.SetValue(Obj, Value);
                }
            catch (Exception Ex)
                {
                throw new ArgumentException(In?.Name, Ex);
                }
            }

        #endregion

        #region ToInvocationSignature

        /// <summary>
        /// Returns a friendly invocation signature representing the MethodInfo.
        /// Ex: MethodInfo.ToInvocationSignature() => string
        ///     string.Sub(int, int) => string
        /// </summary>
        public static string ToInvocationSignature([CanBeNull] this MethodInfo In)
            {
            if (In == null)
                return "";

            string MethodName = In.Name;
            var Params = new List<string>();
            string Return = In.ReturnType.GetClassHierarchy();
            string Start;

            Params.AddRange(In.GetParameters().Convert(Param => Param.ParameterType.Name));

            if (In.IsExtensionMethod())
                {
                Start = $"[{In.GetParameters()[0].ParameterType.GetClassHierarchy()}].";
                // Remove the first parameter (the /this/ parameter)
                Params.RemoveAt(0);
                }
            else if (In.IsStatic)
                {
                Start = $"{In.DeclaringType?.GetClassHierarchy()}.";
                }
            else
                {
                Start = $"[{In.DeclaringType?.GetClassHierarchy()}].";
                }

            return In.ReturnType == typeof(void)
                ? $"{Start}{MethodName}({Params.JoinLines(", ")})"
                : $"{Start}{MethodName}({Params.JoinLines(", ")}) => {Return}";
            }

        #endregion

        #region TypeEquals

        /// <summary>
        /// Returns whether the two types are equal by comparing their Fully Qualified Names.
        /// </summary>
        [Tested]
        public static bool TypeEquals([CanBeNull] this Type In, [CanBeNull] Type Compare)
            {
            return In != null &&
                   Compare != null &&
                   In.FullyQualifiedName() == Compare.FullyQualifiedName();
            }

        #endregion

        #region WithAttribute

        /// <summary>
        /// Filters an IEnumerable`MemberInfo, including any members with given 
        /// attribute <typeparamref name="T" />.
        /// </summary>
        [Tested]
        public static IEnumerable<MemberInfo> WithAttribute<T>([CanBeNull] this IEnumerable<MemberInfo> In, bool IncludeBaseTypes = true)
            {
            return In.Select(Member => Member.HasAttribute<T>(IncludeBaseTypes)).List();
            }

        /// <summary>
        /// Filters an IEnumerable`MemberInfo, including any members with given <paramref name="AttributeType" />.
        /// </summary>
        [Tested]
        public static List<MemberInfo> WithAttribute([CanBeNull] this IEnumerable<MemberInfo> In, [CanBeNull] Type AttributeType,
            bool IncludeBaseTypes = true)
            {
            return In.Select(Member => Member.HasAttribute(AttributeType, IncludeBaseTypes)).List();
            }

        #endregion

        #region WithoutAttribute

        /// <summary>
        /// Filters an IEnumerable`MemberInfo, excluding any members with given 
        /// attribute <typeparamref name="T" />.
        /// </summary>
        [Tested]
        public static IEnumerable<MemberInfo> WithoutAttribute<T>([CanBeNull] this IEnumerable<MemberInfo> In, bool IncludeBaseTypes = true)
            {
            return In.Select(Member => !Member.HasAttribute<T>(IncludeBaseTypes)).List();
            }

        /// <summary>
        /// Filters an IEnumerable`MemberInfo, excluding any members with given 
        /// attribute <paramref name="AttributeType" />.
        /// </summary>
        [Tested]
        public static List<MemberInfo> WithoutAttribute([CanBeNull] this IEnumerable<MemberInfo> In, [CanBeNull] Type AttributeType,
            bool IncludeBaseTypes = true)
            {
            return In.Select(Member => !Member.HasAttribute(AttributeType, IncludeBaseTypes)).List();
            }

        #endregion

        #endregion
        }

    public static partial class L
        {
        /// <summary>
        /// Contains static methods and lambdas pertaining to Reflection.
        /// </summary>
        public static class Ref
            {
            #region Static Methods +

            #region FindType

            /// <summary>
            /// Finds a type by name in all current assemblies.
            /// </summary>
            public static Type FindType(string TypeName)
                {
                var Out = Type.GetType(TypeName);

                if (Out != null)
                    return Out;

                foreach (var Assembly in AppDomain.CurrentDomain.GetAssemblies())
                    {
                    Out = Assembly.GetType(TypeName);

                    if (Out != null)
                        return Out;
                    }

                return null;
                }

            #endregion

            #region GetNamespaceTypes

            /// <summary>
            /// Returns all namespace types, optionally filtering using multiple <paramref name="AttributeTypes" />
            /// </summary>
            public static Type[] GetNamespaceTypes(string Namespace, [CanBeNull] params Type[] AttributeTypes)
                {
                AttributeTypes = AttributeTypes ?? new Type[] {};

                IEnumerable<Type> Types =
                    Assembly.GetCallingAssembly()
                        .GetTypes()
                        .Select(Type => (AttributeTypes.Length == 0 ||
                                         AttributeTypes.Count(AttrType =>
                                             Type.IsType(AttrType) ||
                                             Type.HasInterface(AttrType) ||
                                             Type.HasAttribute(AttrType, true)) > 0)
                                        && Type.Namespace == Namespace
                                        && !Type.HasAttribute<CompilerGeneratedAttribute>(true));

                return Types.Array();
                }

            /// <summary>
            /// Returns all namespace types, optionally filtering using multiple <paramref name="AttributeTypes" />
            /// </summary>
            public static Type[] GetNamespaceTypes(Assembly Assembly, string Namespace, params Type[] AttributeTypes)
                {
                IEnumerable<Type> Types =
                    Assembly.GetTypes()
                        .Select(Type => AttributeTypes.Count(
                            AttrType => Type.IsType(AttrType) ||
                                        Type.HasInterface(AttrType) ||
                                        Type.HasAttribute(AttrType, true)) > 0
                                        && Type.Namespace == Namespace);

                return Types.Array();
                }

            #endregion

            #endregion

            /// <summary>
            /// Retrieve a ConstructorInfo using a lambda statement.
            /// Ex. L.Ref.Constructor(() => new Class(""));
            /// </summary>
            public static ConstructorInfo Constructor<T>(Expression<Func<T>> Expr)
                {
                return ((NewExpression) Expr.Body).Constructor;
                }

            /// <summary>
            /// Retrieve a MemberInfo using a lambda statement.
            /// Ex. L.Ref.Member`Class(t => t.Member);
            /// </summary>
            public static MemberInfo Member<T>(Expression<Func<T, object>> Expr)
                {
                var Out = (Expr.Body as MemberExpression)?.Member;

                if (Out != null)
                    {
                    var TypeCursor = typeof(T);
                    while (TypeCursor != null)
                        {
                        var TopLevelMember = typeof(T).GetMember(Out.Name).First();

                        if (TopLevelMember != null)
                            {
                            Out = TopLevelMember;
                            break;
                            }

                        TypeCursor = TypeCursor.BaseType;
                        }
                    }

                return Out;
                }

            /// <summary>
            /// Retrieve a MethodInfo using a lambda statement.
            /// Ex. L.Ref.Method`Class(t => t.Method(""));
            /// </summary>
            public static MethodInfo Method<T>(Expression<Action<T>> Expr)
                {
                var Out = ((MethodCallExpression) Expr.Body).Method;

                var TypeCursor = typeof(T);
                while (TypeCursor != null)
                    {
                    // Ambiguous match not possible here as parameters are present.
                    // ReSharper disable once ExceptionNotDocumented
                    var TopLevelMember = typeof(T).GetMethod(Out.Name, Out.GetParameters().Convert(Param => Param.ParameterType));

                    if (TopLevelMember != null)
                        {
                        Out = TopLevelMember;
                        break;
                        }

                    TypeCursor = TypeCursor.BaseType;
                    }

                return Out;
                }

            /// <summary>
            /// Retrieve a statically declared MethodInfo using a lambda statement.
            /// Ex. L.Ref.StaticMethod(() => Class.StaticMethod(""));
            /// </summary>
            public static MethodInfo StaticMethod(Expression<Action> Expr)
                {
                return ((MethodCallExpression) Expr.Body).Method;
                }


            /// <summary>
            /// Retrieve a constantly declared MethodInfo using a string name.
            /// Ex. L.Ref.Constant`Class(nameof(Class.ConstantName));
            /// </summary>
            public static MemberInfo Constant<T>(string ConstantName)
                {
                return typeof(T).GetMember(ConstantName,
                    BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static)
                    .First();
                }

            /// <summary>
            /// Retrieve a EventInfo using a string name.
            /// Ex. L.Ref.Constant`Class(nameof(Class.EventName));
            /// </summary>
            public static EventInfo Event<T>(string EventName)
                {
                var Out = (EventInfo) typeof(T).GetMember(EventName).First();

                if (Out != null)
                    {
                    var TypeCursor = typeof(T);
                    while (TypeCursor != null)
                        {
                        var TopLevelMember = typeof(T).GetEvent(Out.Name);

                        if (TopLevelMember != null)
                            {
                            Out = TopLevelMember;
                            break;
                            }

                        TypeCursor = TypeCursor.BaseType;
                        }
                    }

                return Out;
                }

            /// <summary>
            /// Retrieves a new <typeparamref name="T" />, passing <paramref name="Parameters" /> to the constructor.
            /// </summary>
            public static T New<T>(params object[] Parameters)
                {
                return typeof(T).New<T>(Parameters);
                }

            /// <summary>
            /// Creates a new random <typeparamref name="T"/> for many simple types.
            /// </summary>
            public static T NewRandom<T>(T? Minimum = null, T? Maximum = null)
                where T : struct
                {
                return (T) NewRandom(typeof(T), Minimum, Maximum);
                }

            internal static readonly Dictionary<Type, Func<Type, object[], object>> NewRandom_ArrayTypes = new Dictionary
                <Type, Func<Type, object[], object>>
                {
                [typeof(Array)] = (ItemType, Items) =>
                    {
                    var Out = (Array) ItemType.MakeArrayType().New(new object[] {Items.Length});
                    object Out2 = Out.Collect((i, Item) => Items[i]).Array();

                    return Out2;
                    },
                [typeof(List)] = (ItemType, Items) =>
                    {
                    object Out = (IList) typeof(List<>).MakeGenericType(ItemType).New();

                    Items.List().Each(Item => ((IList) Out)?.Add(Item));

                    return Out;
                    }
                };

            internal static readonly Dictionary<Type, Func<Type, object, object, object>> NewRandom_InterfaceCreators =
                new Dictionary<Type, Func<Type, object, object, object>>
                    {
                    [typeof(IEnumerable)] = (Type, Min, Max) =>
                        {
                        Func<Type, object[], object> ArrayType = NewRandom_ArrayTypes.Values.Random();
                        var SelectedType = NewRandom_TypeCreators.Keys.Random();

                        var RandomItems = new List<object>();

                        int RandomCount = (int) NewRandom(typeof(int), 1, 50);

                        A(() => { RandomItems.Add(NewRandom(SelectedType, Min, Max)); }).Repeat(RandomCount)();

                        // ReSharper disable once ConvertIfStatementToReturnStatement
                        // ReSharper disable once UseNullPropagation
                        if (ArrayType != null)
                            return ArrayType(SelectedType, RandomItems.Array());

                        return null;
                        },
                    [typeof(IEnumerable<>)] = (Type, Min, Max) =>
                        {
                        if (Type.GetGenericArguments().Length == 1)
                            {
                            var EnumerableType = !Type.IsGenericTypeDefinition
                                ? Type.GetGenericArguments()[0] ?? Type
                                : NewRandom_TypeCreators.Keys.Random();

                            Func<Type, object[], object> ArrayTypeCreator = NewRandom_ArrayTypes.Values.Random();

                            var RandomItems = new List<object>();

                            int RandomCount = (int) NewRandom(typeof(int), 1, 50);

                            A(() => { RandomItems.Add(NewRandom(EnumerableType, Min, Max)); }).Repeat(RandomCount)();

                            // ReSharper disable once ConvertIfStatementToReturnStatement
                            // ReSharper disable once UseNullPropagation
                            if (ArrayTypeCreator != null)
                                return ArrayTypeCreator(EnumerableType, RandomItems.Array());
                            }

                        return null;
                        }
                    };

            /// <summary>
            /// Type creators for random data.
            /// 
            /// The value function is a Function which takes the Type, 
            /// </summary>
            public static readonly Dictionary<Type, Func<object, object, object>> NewRandom_TypeCreators =
                new Dictionary<Type, Func<object, object, object>>
                    {
                    [typeof(Guid)] = (Min, Max) => new Guid(),
                    [typeof(string)] = (Min, Max) => new Guid().ToString(),
                    [typeof(double)] = (Min, Max) =>
                        {
                        double Minimum = (double?) Min ?? (double) int.MinValue;
                        double Maximum = (double?) Max ?? (double) int.MaxValue;

                        return new Random().NextDouble()*Minimum - Maximum;
                        },
                    [typeof(char)] = (Min, Max) =>
                        {
                        char Minimum = (char?) Min ?? char.MinValue;
                        char Maximum = (char?) Max ?? char.MaxValue;

                        return (char) new Random().Next(Minimum, Maximum);
                        },
                    [typeof(byte)] = (Min, Max) =>
                        {
                        byte Minimum = (byte?) Min ?? byte.MinValue;
                        byte Maximum = (byte?) Max ?? byte.MaxValue;

                        return (byte) new Random().Next(Minimum, Maximum);
                        },
                    [typeof(sbyte)] = (Min, Max) =>
                        {
                        sbyte Minimum = (sbyte?) Min ?? sbyte.MinValue;
                        sbyte Maximum = (sbyte?) Max ?? sbyte.MaxValue;

                        return (sbyte) new Random().Next(Minimum, Maximum);
                        },
                    [typeof(short)] = (Min, Max) =>
                        {
                        short Minimum = (short?) Min ?? short.MinValue;
                        short Maximum = (short?) Max ?? short.MaxValue;

                        return (short) new Random().Next(Minimum, Maximum);
                        },
                    [typeof(ushort)] = (Min, Max) =>
                        {
                        ushort Minimum = (ushort?) Min ?? ushort.MinValue;
                        ushort Maximum = (ushort?) Max ?? ushort.MaxValue;

                        return (ushort) new Random().Next(Minimum, Maximum);
                        },
                    [typeof(long)] = (Min, Max) =>
                        {
                        long Minimum = (long?) Min ?? int.MinValue;
                        long Maximum = (long?) Max ?? int.MaxValue;
                        int MinimumInt = Minimum.ConvertTo<int>() ?? int.MinValue;
                        int MaximumInt = Maximum.ConvertTo<int>() ?? int.MaxValue;

                        return (long) new Random().Next(MinimumInt, MaximumInt);
                        },
                    [typeof(int)] = (Min, Max) =>
                        {
                        int Minimum = (int?) Min ?? int.MinValue;
                        int Maximum = (int?) Max ?? int.MaxValue;

                        return new Random().Next(Minimum, Maximum);
                        },
                    [typeof(uint)] = (Min, Max) =>
                        {
                        int Minimum = (int) ((uint?) Min ?? uint.MinValue);
                        int Maximum = (int) ((uint?) Max ?? (uint) int.MaxValue);

                        return (uint) new Random().Next(Minimum, Maximum);
                        }
                    };

            /// <summary>
            /// Creates a new random object of type <paramref name="Type"/> for many simple types.
            /// </summary>
            public static object NewRandom(Type Type, object Minimum = null, object Maximum = null)
                {
                var Rand = new Random();

                if (Minimum != null || Maximum != null)
                    {
                    if (Minimum is IConvertible)
                        Minimum = ((IConvertible) Minimum).ConvertTo(Type) ?? Minimum;

                    if (Maximum is IConvertible)
                        Maximum = ((IConvertible) Maximum).ConvertTo(Type) ?? Maximum;
                    /*
                                        if (Minimum.IsType(Type) && Maximum.IsType(Type))
                                            if (Minimum is IConvertible && ((IConvertible)Minimum).CanConvertTo(typeof(int)) &&
                                                Maximum is IConvertible && ((IConvertible)Maximum).CanConvertTo(typeof(int)))
                                                return Rand.Next(((IConvertible)Minimum).ConvertTo<int>() ?? int.MinValue,
                                                    ((IConvertible)Maximum).ConvertTo<int>() ?? int.MinValue).ConvertTo(Type);

                                        if (Minimum.IsType(Type))
                                            if (Minimum is IConvertible && ((IConvertible)Minimum).CanConvertTo(typeof(int)))
                                                return Rand.Next(((IConvertible)Minimum).ConvertTo<int>() ?? int.MinValue, int.MaxValue)
                                                    .ConvertTo(Type);

                                        if (Maximum.IsType(Type))
                                            if (Maximum is IConvertible && ((IConvertible)Maximum).CanConvertTo(typeof(int)))
                                                return Rand.Next(int.MinValue,
                                                    ((IConvertible)Minimum).ConvertTo<int>() ?? int.MinValue)
                                                    .ConvertTo(Type);*/
                    }


                // TODO: Create from object constructor and initialize properties.

                // TODO: Create dynamic object from Interface and initialize properties.


                if (NewRandom_TypeCreators.ContainsKey(Type) ||
                    (Type.IsGenericType &&
                     Type.GetGenericTypeDefinition() == Type))
                    return NewRandom_TypeCreators[Type](Minimum, Maximum);

                var InterfaceType = NewRandom_InterfaceCreators.Keys.First(KeyType => KeyType.HasInterface(Type));
                // ReSharper disable once ConvertIfStatementToReturnStatement
                if (InterfaceType != null)
                    return NewRandom_InterfaceCreators[InterfaceType](InterfaceType, Minimum, Maximum);

                // Lastly, try to convert to the type
                if (Type.HasInterface<IConvertible>())
                    {
                    var Result =
                        Rand.Next((int?) Minimum ?? char.MinValue, (int?) Maximum ?? char.MaxValue).ConvertTo(Type);

                    if (Result.IsType(Type) || Result != null)
                        return Result;
                    }

                return null;
                }

            #region Lambdas +

            // ReSharper disable CommentTypo
            /*
            internal static readonly Func<string, string> Language_CleanOperationFunctionName = F<string, string>()
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
                .Else(Logic.Pass<string>());

            internal static readonly Func<string, string> Language_CleanOperationFunctionAction = F<string, string>()
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
                .Else(Logic.Pass<string>());
    */
            // ReSharper restore CommentTypo

            #region MemberInfo - Get Attribute

            private static readonly Func<string, ICustomAttributeProvider, Type, bool, object> _GetAttribute =
                (DeclaringTypeName, Prop, Attr, IncludeBaseTypes) =>
                    {
                    bool HasAttribute;
                    object[] Objs;
                    do
                        {
                        Objs = Prop.GetCustomAttributes(Attr, false);
                        HasAttribute = Objs.Length != 0;

                        if (HasAttribute)
                            return Objs[0];

                        var MemberInfo = Prop as MemberInfo;
                        if (MemberInfo != null)
                            {
                            if (MemberInfo.DeclaringType?.BaseType == null)
                                {
                                Prop = null;
                                }
                            else
                                {
                                try
                                    {
                                    Prop = ((MemberInfo) Prop).DeclaringType?.BaseType?.GetProperty(((MemberInfo) Prop).Name);
                                    }
                                catch
                                    {
                                    Prop = null;
                                    }
                                }
                            continue;
                            }
                        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                        // ReSharper disable once ExpressionIsAlwaysNull
                        var MethodInfo = Prop as MethodInfo;
                        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                        if (MethodInfo != null)
                            {
                            if (MethodInfo.DeclaringType?.BaseType == null)
                                {
                                Prop = null;
                                }
                            else
                                {
                                try
                                    {
                                    Prop = ((MethodInfo) Prop).DeclaringType.BaseType.GetProperty(((MethodInfo) Prop).Name);
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
                        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                    while (IncludeBaseTypes && !HasAttribute && Prop != null);

                    object Out2 = null;

                    if (!Objs.IsEmpty())
                        Out2 = Objs[0];

                    return Out2;
                    };

            internal static readonly Func<string, ICustomAttributeProvider, Type, bool, object> GetAttribute = _GetAttribute
                .Cache("MemberAttributes").Require("Prop").Require2("Attr");

            #endregion

            #endregion

            /*
            #region GetNewSubclass
            public static T GetNewSubclass<T>(this Type RootType, object[] Params = null)
                {
                return GetNewSubclass<T>(RootType, typeof(T).Name, Params);
                }
            public static T GetNewSubclass<T>(this Type RootType, string Name, object[] Params = null)
                {
                return RootType.GetNewSubclass<T>(RootType, Name, Params);
                }
            private static T GetNewSubclass<T>(this Type RootType, Type t, string Name, object[] Params = null)
                {
                return RootType.GetNewSubclass<T>(new Type[] { }, t, Name, Params);
                }
            private static readonly Dictionary<string, ConstructorInfo> GetNewSubclass_ResultCache = new Dictionary<string, ConstructorInfo>();
            private static T GetNewSubclass<T>(this Type RootType, Type[] GenericStash, Type t, string Name, object[] Params = null)
                {
                Params = Params ?? new object[] { };

                string CacheName = $"{typeof(T).FullName}_{t.FullName}_{Name}_{Params.Length}";
                if (GetNewSubclass_ResultCache.ContainsKey(CacheName))
                    {
                    var CachedConstructor = GetNewSubclass_ResultCache[CacheName];

                    return (T)CachedConstructor.Invoke(Params);
                    }

                List<Type> Types = t.GetNestedTypes().List();
                var Out = default(T);
                Types.While(t2 =>
                    {
                        if (t2.Name == Name ||
                            t2.IsType(typeof(T)) ||
                            (t2.IsGenericType && typeof(T).IsGenericType &&
                             t2.GetGenericTypeDefinition().IsType(typeof(T).GetGenericTypeDefinition())))
                            {
                            Type[] GenericArgs = t2.GetGenericArguments();

                            Type[] GenericTypes = { };
                            if (GenericArgs.Length == 1)
                                {
                                GenericTypes = new[] { RootType };
                                }
                            else if (GenericArgs.Length == 2 && GenericStash.Length == 1)
                                {
                                GenericTypes = new[] { RootType, GenericStash[0] };
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

                            var Const = t2.GetConstructor(Params.GetTypes());
                            GetNewSubclass_ResultCache.Add(CacheName, Const);
                            var O = Const?.Invoke(Params);
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
                if (t.IsGenericType && t.BaseType?.IsGenericType != true)
                    {
                    Type[] temp = t.GetGenericArguments();
                    GenericStash = GenericStash.Length > 0 ? GenericStash.Add(temp) : temp;

                    BaseType = t.GetGenericTypeDefinition();
                    if (t.TypeEquals(BaseType))
                        {
                        BaseType = null;
                        }
                    }

                if (BaseType == null && t.BaseType?.TypeEquals(t) != true)
                    {
                    BaseType = t.BaseType;
                    }

                if (BaseType != null)
                    {
                    Out = RootType.GetNewSubclass<T>(GenericStash, BaseType, Name, Params);
                    }

                return Out;
                }
            #endregion
            */
            }
        }
    }