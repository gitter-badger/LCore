using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
        /// Returns a list of the provided type [In] as well as all of [In]'s base types.
        /// </summary>
        public static List<Type> AlsoBaseTypes(this Type In)
            {
            List<Type> Out = In.BaseTypes();
            Out.Insert(0, In);
            return Out;
            }
        #endregion

        #region BaseTypes
        /// <summary>
        /// Returns a list of all of [In]'s base types.
        /// </summary>
        public static List<Type> BaseTypes(this Type In)
            {
            var Out = new List<Type>();
            while (In.BaseType != null)
                {
                Out.Add(In.BaseType);
                In = In.BaseType;
                }
            return Out;
            }
        #endregion

        #region FindMethod
        /// <summary>
        /// Finds a method by name, searching the Type [In] as well as all
        /// base types.
        /// 
        /// Optionally include a Type[] [Arguments] to specify the method arguments.
        /// </summary>
        public static MethodInfo FindMethod(this Type In, string Name, Type[] Arguments = null)
            {
            Arguments = Arguments ?? new Type[] { };

            var t = In;

            while (t != null)
                {
                if (In.GetMethod(Name, Arguments) != null)
                    return t.GetMethod(Name, Arguments);

                if (t.UnderlyingSystemType.GetMethod(Name, Arguments) != null)
                    return t.UnderlyingSystemType.GetMethod(Name, Arguments);

                t = t.BaseType;
                }

            return null;
            }
        #endregion

        #region GetAttribute
        /// <summary>
        /// Returns an attribute of type [T] if it exists.
        /// </summary>
        public static T GetAttribute<T>(this ICustomAttributeProvider p)
            where T : IPersistAttribute
            {
            bool Persist = typeof(T).HasInterface<ISubClassPersistentAttribute>();
            return p.GetAttribute<T>(Persist);
            }

        /// <summary>
        /// Returns an attribute of type [T] if it exists.
        /// </summary>
        public static T GetAttribute<T>(this ICustomAttributeProvider p, bool IncludeBaseTypes)
            {
            var o = L.Ref.GetAttribute(p.GetAttributeTypeName(), p, typeof(T), IncludeBaseTypes);

            if (o is T)
                return (T)o;

            return default(T);
            }
        #endregion

        #region GetAttributes
        /// <summary>
        /// Returns all attributes of type [T].
        /// </summary>
        public static List<T> GetAttributes<T>(this ICustomAttributeProvider p, bool IncludeBaseTypes)
            where T : class
            {
            List<T> Out = p.GetCustomAttributes(typeof(T), true).Filter<T>();
            if (IncludeBaseTypes && (p as MemberInfo)?.DeclaringType?.BaseType != null)
                {
                MemberInfo[] BaseMembers = null;

                try
                    {
                    BaseMembers = ((MemberInfo)p).DeclaringType?.BaseType?.GetMember(((MemberInfo)p).Name);
                    }
                catch
                    {
                    }

                if (!BaseMembers.IsEmpty())
                    {
                    BaseMembers.Each(m =>
                    {
                        Out.AddRange(GetAttributes<T>(m, true));
                    });
                    }
                }

            if (typeof(T).HasInterface<IL_Attribute_ReverseOrder>())
                Out.Reverse();
            return Out;
            }
        #endregion

        #region GetAttributeTypeName
        /// <summary>
        /// Returns the name of the attribute type.
        /// </summary>
        public static string GetAttributeTypeName(this ICustomAttributeProvider p)
            {
            var Type1 = p as Type;
            if (Type1 != null)
                return Type1.FullName;

            var info = p as MemberInfo;
            if (info != null)
                return info.DeclaringType?.FullName;

            var list = p as AttributeList;
            if (list != null)
                return list.TypeName;

            var parameterInfo = p as ParameterInfo;
            if (parameterInfo != null)
                return parameterInfo.Member.DeclaringType?.FullName;

            throw new Exception($"Could not get attribute type name: {p.GetType().FullName}");
            }
        #endregion

        #region GetComparer
        /// <summary>
        /// Returns a ComparableComparer to compare comparable types.
        /// </summary>
        // ReSharper disable once UnusedParameter.Global
        public static IComparer GetComparer(this MemberInfo In)
            {
            return new ComparableComparer();
            }
        /// <summary>
        /// Returns a ComparableComparer to compare comparable types.
        /// Returns a strongly typed IComparer[T] if you know the type you're comparing.
        /// </summary>
        public static IComparer<T> GetComparer<T>(this MemberInfo In)
            {
            var t = In.GetMemberType();

            if (t.TypeEquals(typeof(float)) ||
                t.TypeEquals(typeof(int)) ||
                t.TypeEquals(typeof(long)) ||
                t.TypeEquals(typeof(Guid)) ||
                t.TypeEquals(typeof(DateTime)) ||
                t.TypeEquals(typeof(bool)) ||
                t.TypeEquals(typeof(string)))
                {
                return (IComparer<T>)new ComparableComparer();
                }
            return null;
            }
        #endregion

        #region GetExtensionMethods
        /// <summary>
        /// Returns all Extension methods declared on Type [In]
        /// </summary>
        public static MethodInfo[] GetExtensionMethods(this Type In)
            {
            return
                In.GetMethods()
                    .Where(m => m.IsStatic &&
                        m.IsPublic &&
                        m.IsDefined(typeof(ExtensionAttribute), true))
                    .Array();
            }
        #endregion

        #region GetMemberType

        /// <summary>
        /// Returns the FieldType of the field, PropertyType of the property, 
        /// or ReturnType of the method.
        /// </summary>
        public static Type GetMemberType(this MemberInfo In)
            {
            var @in = In as PropertyInfo;
            if (@in != null)
                {
                return @in.PropertyType;
                }
            var info = In as FieldInfo;
            if (info != null)
                {
                return info.FieldType;
                }
            var methodInfo = In as MethodInfo;
            return methodInfo?.ReturnType;
            }

        #endregion

        #region GetSubClass
        /// <summary>
        /// Gets a subclass from a type [In] or any of its base classes.
        /// Subclass from a descendant will be used before an ancestor subclasses.
        /// </summary>
        public static Type GetSubClass(this Type In, string SubClassName)
            {
            return In.AlsoBaseTypes().Collect(t =>
            {
                var Out = t.GetNestedTypes().First(t2 => t2.Name == SubClassName);
                return Out;
            }).First();
            }
        #endregion

        #region GetSubClasses
        /// <summary>
        /// Gets a subclasses from a type [In] or any of its base classes.
        /// Subclasses from a descendant will be used before an ancestor subclasses.
        /// </summary>
        public static List<Type> GetSubClasses(this Type In)
            {
            var Out = new List<Type>();
            In.AlsoBaseTypes().Each(t =>
            {
                Out.AddRange(t.GetNestedTypes());
            });
            return Out;
            }
        #endregion

        #region GetSubClasses
        /// <summary>
        /// Returns a friendly name for a type including generic type arguments.
        /// </summary>
        public static string GetFriendlyTypeName(this Type In)
            {
            if (In == null)
                return "";

            if (In.Namespace == "System.Data.Entity.DynamicProxies")
                In = In.BaseType;

            if (In?.IsGenericType == true && In.Name.Has('`'))
                {
                string Out = "";
                Out += In.Name.Remove(In.Name.IndexOf('`'));
                Out += "<";
                Type[] Arguments = In.GetGenericArguments();

                Arguments.Each((i, arg) =>
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
            return In.HasAttribute<IL_FriendlyName>(true) ? In.GetAttribute<IL_FriendlyName>(true).FriendlyName : In?.Name.Humanize();
            }
        #endregion

        #region GetValue
        /// <summary>
        /// Returns the value from a specific object.
        /// If the field is not found an Exception will be thrown.
        /// </summary>
        public static object GetValue(this MemberInfo In, object Obj)
            {
            try
                {
                var @in = In as PropertyInfo;
                if (@in != null)
                    {
                    return @in.GetValue(Obj, null);
                    }
                var info = In as FieldInfo;
                return info?.GetValue(Obj);
                }
            catch (Exception e)
                {
                throw new Exception(In.Name, e);
                }
            }
        #endregion

        #region GetValues
        /// <summary>
        /// Returns a list of all member values, optionally include subclasses.
        /// </summary>
        public static List<T> GetValues<T>(this Type In, object Obj, bool IncludeBaseClasses = true)
            {
            List<MemberInfo> Members = In.Members(typeof(T), IncludeBaseClasses);
            return Members.GetValues<T>(Obj);
            }
        /// <summary>
        /// Returns a list of object values from a list of members.
        /// Optionally, set [Instanciate] to true to instanciate null members.
        /// </summary>
        public static List<T> GetValues<T>(this List<MemberInfo> In, object Obj, bool Instanciate = false)
            {
            var Out = new List<T>();
            Out = In.Convert(o =>
            {
                var o2 = o.GetValue(Obj);
                if (Instanciate && o2 == null)
                    {
                    o2 = o.MemberType().New();
                    o.SetValue(Obj, o2);
                    }

                if (o2?.GetType().IsType(typeof(T)) == true &&
                    !Out.Contains((T)o2))
                    {
                    return (T)o2;
                    }
                return default(T);
            });

            return Out;
            }
        #endregion

        #region GetTypes
        /// <summary>
        /// Returns a list of the types of all elements within [In].
        /// </summary>
        public static List<Type> GetTypes<T>(this List<T> In)
            {
            return In.Convert(i => i.GetType());
            }
        /// <summary>
        /// Returns an array of the types of all elements within [In].
        /// </summary>
        public static Type[] GetTypes<T>(this T[] In)
            {
            return In.Convert(i => i.GetType());
            }
        #endregion

        #region HasAttribute
        /// <summary>
        /// Returns whether a member has a certain attribute type [T].
        /// </summary>
        public static bool HasAttribute<T>(this ICustomAttributeProvider p)
            where T : IPersistAttribute
            {
            bool Persist = typeof(T).HasInterface<ISubClassPersistentAttribute>();
            return p.HasAttribute<T>(Persist);
            }
        /// <summary>
        /// Returns whether a member has a certain attribute type [T].
        /// Optionally, look on base type members for the attribute.
        /// </summary>
        public static bool HasAttribute<T>(this ICustomAttributeProvider p, bool IncludeBaseClasses)
            {
            return p.HasAttribute(typeof(T), IncludeBaseClasses);
            }
        /// <summary>
        /// Returns whether a member has a certain attribute type [a].
        /// Optionally, look on base type members for the attribute.
        /// </summary>
        public static bool HasAttribute(this ICustomAttributeProvider p, Type t, bool IncludeBaseClasses)
            {
            return L.Ref.GetAttribute(p.GetAttributeTypeName(), p, t, IncludeBaseClasses) != null;
            }
        #endregion

        #region HasInterface
        /// <summary>
        /// Returns whether or not a given type [In] implements an interface.
        /// Optionally, IncludeBaseTypes can be set to false to only look within top-level classes.
        /// </summary>
        public static bool HasInterface(this Type In, Type Interface, bool IncludeBaseTypes = true)
            {
            if (IncludeBaseTypes && In.BaseType != null)
                return In.GetInterfaces().Has(Interface) ||
                       In.BaseType.HasInterface(Interface);

            return In.GetInterfaces().Has(Interface);
            }
        /// <summary>
        /// Returns whether or not a given type [In] implements an interface.
        /// Optionally, IncludeBaseTypes can be set to false to only look within top-level classes.
        /// </summary>
        public static bool HasInterface<T>(this Type In, bool IncludeBaseTypes = true)
            {
            var Interface = typeof(T);

            if (IncludeBaseTypes && In.BaseType != null)
                return In.GetInterfaces().Has(Interface) ||
                       In.BaseType.HasInterface<T>();

            return In.GetInterfaces().Has(Interface);
            }
        #endregion

        #region HasSetterField
        /// <summary>
        /// Returns whether a MemberInfo has a setter field.
        /// </summary>
        public static bool HasSetterField(this MemberInfo In)
            {
            var @in = In as PropertyInfo;
            if (@in != null)
                return @in.CanWrite;
            var info = In as FieldInfo;
            if (info != null)
                return !info.IsLiteral && !info.IsInitOnly;
            if (In is MethodInfo)
                return false;
            throw new Exception($"Unknown type: {In.GetType().Name}");
            }

        #endregion

        #region InstanciateValues
        /// <summary>
        /// Instanciates values of properties for an object.
        /// </summary>
        public static List<T> InstanciateValues<T>(this Type In, object Obj, bool IncludeBaseClasses)
            {
            List<MemberInfo> Members = In.Members(typeof(T), IncludeBaseClasses);
            return Members.GetValues<T>(Obj, true);
            }
        /// <summary>
        /// Instanciates values of specific properties for an object.
        /// </summary>
        public static List<T> InstanciateValues<T>(this List<MemberInfo> In, object Obj)
            {
            return In.GetValues<T>(Obj, true);
            }
        #endregion

        #region IsExtensionMethod
        /// <summary>
        /// Returns whether a MethodInfo is an extension method or not.
        /// </summary>
        public static bool IsExtensionMethod(this MethodInfo In)
            {
            return In.IsDefined(typeof(ExtensionAttribute), true);
            }
        #endregion

        #region IsType
        /// <summary>
        /// Returns whether object [In] is type [T] or a subclass of [T]
        /// </summary>
        public static bool IsType<T>(this object In)
            {
            return In.GetType().IsType(typeof(T));
            }
        /// <summary>
        /// Returns whether object [In] is type [t] or a subclass of [t]
        /// </summary>
        public static bool IsType(this object In, Type t)
            {
            return In.GetType().IsType(t);
            }
        /// <summary>
        /// Returns whether type [In] is type [t] or a subclass of [t]
        /// </summary>
        public static bool IsType(this Type In, Type t)
            {
            return In?.TypeEquals(t) == true ||
                   In?.IsSubclassOf(t) == true ||
                   (t.IsInterface && In?.HasInterface(t) == true);
            }
        /// <summary>
        /// Returns whether type [In] is type [T] or a subclass of [T]
        /// </summary>
        public static bool IsType<T>(this Type In)
            {
            return In.IsType(typeof(T));
            }
        #endregion

        #region Members
        /// <summary>
        /// Return all members of type [In] who expose type [t].
        /// </summary>
        public static List<MemberInfo> Members(this Type In, Type t)
            {
            return In.Members(t, true);
            }
        /// <summary>
        /// Return all members of type [In] who expose type [t].
        /// Optionally, scan 
        /// </summary>
        public static List<MemberInfo> Members(this Type In, Type t, bool IncludeBaseClasses)
            {
            List<MemberInfo> Out = In.GetMembers().List().Select(Member =>
            {
                var t2 = Member.GetMemberType();
                return t2.IsType(t);
            });

            if (IncludeBaseClasses && In.BaseType != null)
                Out.AddRange(In.BaseType.Members(t));
            return Out;
            }
        #endregion

        #region MemberType
        /// <summary>
        /// Returns the type of the member.
        /// Uses the return value if [In] is a MethodInfo.
        /// </summary>
        public static Type MemberType(this MemberInfo In)
            {
            var Type = In.GetType();

            if (Type == typeof(PropertyInfo))
                return ((PropertyInfo)In).PropertyType;
            if (Type == typeof(FieldInfo))
                return ((FieldInfo)In).FieldType;
            if (Type == typeof(MethodInfo))
                return ((MethodInfo)In).ReturnType;

            throw new Exception($"Unknown Member Type: {In.GetType().FullName}");
            }

        #endregion

        #region New
        /// <summary>
        /// Creates a new [T] object. Optionally, pass in [Arguments] to the constructor.
        /// </summary>
        public static T New<T>(this Type In, object[] Arguments = null)
            {
            return (T)In.New(Arguments, typeof(T));
            }
        /// <summary>
        /// Creates a new object. Optionally, pass in [Arguments] to the constructor.
        /// If the object type is uses a generic type, you need to supply it using [GenericType]
        /// </summary>
        public static object New(this Type In, object[] Arguments = null, Type GenericType = null)
            {
            try
                {
                if (In.IsValueType)
                    return Activator.CreateInstance(In);

                Arguments = Arguments ?? new object[] { };

                if (In.ContainsGenericParameters && GenericType != null)
                    {
                    var TypeArgs_Base = new List<Type[]>();

                    GenericType.Traverse(t =>
                    {
                        if (t.IsGenericType)
                            TypeArgs_Base.Add(t.GetGenericArguments());

                        return t.BaseType;
                    });

                    TypeArgs_Base.Reverse();
                    TypeArgs_Base.Add(new[] { GenericType });

                    int InGenericArgs = In.GetGenericArguments().Length;

                    TypeArgs_Base.While(Types =>
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

                var Const = In.AlsoBaseTypes().First(t => t.GetConstructor(ArgTypes));

                if (Const == null)
                    {
                    throw new Exception("Could not find constructor");
                    }

                return Const.Invoke(Arguments);
                }
            catch (Exception e)
                {
                throw new Exception($"Could not instanciate type: {In.FullName}", e);
                }
            }
        #endregion

        #region SetValue
        /// <summary>
        /// Sets the member value on [Obj].
        /// </summary>
        /// <param name="In"></param>
        /// <param name="Obj"></param>
        /// <param name="Value"></param>
        public static void SetValue(this MemberInfo In, object Obj, object Value)
            {
            try
                {
                var @in = In as PropertyInfo;
                if (@in != null && @in.CanWrite)
                    {
                    @in.SetValue(Obj, Value, new object[] { });
                    return;
                    }

                var info = In as FieldInfo;
                info?.SetValue(Obj, Value);
                }
            catch (Exception e)
                {
                throw new Exception(In.Name, e);
                }
            }
        #endregion

        #region ToInvocationSignature
        /// <summary>
        /// Returns a friently invocation signature representing the MethodInfo.
        /// Ex: MethodInfo.ToInvocationSignature() => string
        ///     string.Sub(int, int) => string
        /// </summary>
        public static string ToInvocationSignature(this MethodInfo In)
            {
            string MethodName = In.Name;
            var Params = new List<string>();
            string Return = In.ReturnType.Name;
            string Start;

            Params.AddRange(In.GetParameters().Select(Param => Param.ParameterType.Name));

            if (In.IsExtensionMethod())
                {
                Start = $"{In.GetParameters()[0].ParameterType.Name.Sub(0, 1)}.";

                // Remove the first parameter (the /this/ parameter)
                Params.RemoveAt(0);
                }
            else if (In.IsStatic)
                {
                Start = $"{In.DeclaringType?.Name}.";
                }
            else
                {
                Start = $"{In.DeclaringType?.Name.ToLower()}.";
                }

            return $"{Start}{MethodName}.({Params.JoinLines(", ")}) => {Return}";
            }
        #endregion

        #region Type
        /// <summary>
        /// Returns the type of an object.
        /// </summary>
        [TestResult(new object[] { 0 }, typeof(int), GenericTypes = new[] { typeof(int) })]
        //      [TestResult(new Object[] { (String)null }, typeof(String), GenericTypes = new Type[] { typeof(String) })]
        [TestResult(new object[] { "" }, typeof(string), GenericTypes = new[] { typeof(string) })]
        // ReSharper disable once UnusedParameter.Global
        public static Type Type<T>(this T In)
            {
            return typeof(T);
            }
        #endregion

        #region TypeEquals
        /// <summary>
        /// Returns whether the two types are equal by comparing their FullName properties.
        /// </summary>
        public static bool TypeEquals(this Type In, Type Compare)
            {
            return In != null &&
                   Compare != null &&
                   In.FullName == Compare.FullName;
            }
        #endregion

        #region WithAttribute
        /// <summary>
        /// Filters an IEnumerable[MemberInfo], including any members with given 
        /// attribtute [T].
        /// </summary>
        public static IEnumerable<MemberInfo> WithAttribute<T>(this IEnumerable<MemberInfo> In)
            {
            return In.Where(m => m.HasAttribute<T>(true)).List();
            }
        /// <summary>
        /// Filters an IEnumerable[MemberInfo], including any members with given [AttributeType].
        /// </summary>
        public static List<MemberInfo> WithAttribute(this IEnumerable<MemberInfo> In, Type AttributeType)
            {
            return In.Where(m => m.HasAttribute(AttributeType, true)).List();
            }
        #endregion

        #region WithoutAttribute
        /// <summary>
        /// Filters an IEnumerable[MemberInfo], excluding any members with given 
        /// attribtute [T].
        /// </summary>
        public static IEnumerable<MemberInfo> WithoutAttribute<T>(this IEnumerable<MemberInfo> In)
            {
            return In.Where(m => !m.HasAttribute<T>(true)).List();
            }
        /// <summary>
        /// Filters an IEnumerable[MemberInfo], excluding any members with given 
        /// attribtute [T].
        /// </summary>
        public static List<MemberInfo> WithoutAttribute(this IEnumerable<MemberInfo> In, Type AttributeType)
            {
            return In.Where(m => !m.HasAttribute(AttributeType, true)).List();
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
            /// Finds a type by name in all current assembies.
            /// </summary>
            public static Type FindType(string TypeName)
                {
                var Out = Type.GetType(TypeName);

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

            #endregion

            #region GetNamespaceTypes

            /// <summary>
            /// Returns all namespace types, optionally filtering using multiple [AttributeTypes]
            /// </summary>
            public static Type[] GetNamespaceTypes(string Namespace, params Type[] AttributeTypes)
                {
                AttributeTypes = AttributeTypes ?? new Type[] { };

                IEnumerable<Type> q =
                    Assembly.GetCallingAssembly()
                        .GetTypes()
                        .Where(
                            t => (AttributeTypes.Length == 0 ||
                                  AttributeTypes.Count(type =>
                                    t.IsType(type) ||
                                    t.HasInterface(type) ||
                                    t.HasAttribute(type, true)) > 0)
                                && t.Namespace == Namespace);

                return q.ToArray();
                }

            /// <summary>
            /// Returns all namespace types, optionally filtering using multiple [AttributeTypes]
            /// </summary>
            public static Type[] GetNamespaceTypes(Type AssemblyType, string Namespace, params Type[] AttributeTypes)
                {
                IEnumerable<Type> q =
                    Assembly.GetAssembly(AssemblyType)
                        .GetTypes()
                        .Where(t => AttributeTypes.Count(
                            type => t.IsType(type) ||
                                t.HasInterface(type) ||
                                t.HasAttribute(type, true)) > 0
                            && t.Namespace == Namespace);

                return q.ToArray();
                }

            #endregion

            #endregion

            #region Lambdas +
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

            #region MemberInfo - Get Attribute
            private static readonly Func<string, ICustomAttributeProvider, Type, bool, object> _GetAttribute = (DeclaringTypeName, Prop, Attr, IncludeBaseTypes) =>
            {
                bool HasAttrib;
                object[] Objs;
                do
                    {
                    Objs = Prop.GetCustomAttributes(Attr, false);
                    HasAttrib = Objs.Length != 0;

                    if (HasAttrib)
                        return Objs[0];

                    var info = Prop as MemberInfo;
                    if (info != null)
                        {
                        if (info.DeclaringType?.BaseType == null)
                            {
                            Prop = null;
                            }
                        else
                            {
                            try
                                {
                                Prop = ((MemberInfo)Prop).DeclaringType?.BaseType?.GetProperty(((MemberInfo)Prop).Name);
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
                    var prop = Prop as MethodInfo;
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                    if (prop != null)
                        {
                        if (prop.DeclaringType?.BaseType == null)
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
                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                while (IncludeBaseTypes && !HasAttrib && Prop != null);

                object Out2 = null;

                if (!Objs.IsEmpty())
                    Out2 = Objs[0];

                return Out2;
            };
            internal static Func<string, ICustomAttributeProvider, Type, bool, object> GetAttribute = _GetAttribute
                .Cache("MemberAttributes").Require("Prop").Require2("Attr");
            #endregion

            #region As
            /// <summary>
            /// Returns a function that performs the 'as' operation.
            /// </summary>
            public static Func<object, T> As<T>()
                where T : class
                {
                return o => o as T;
                }
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