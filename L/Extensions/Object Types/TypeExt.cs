using System;

using LCore.Extensions.ObjectExt;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using LCore.Tests;
using NSort;
using LCore.Naming;
using LCore.Dynamic;
using LCore.Interfaces;

namespace LCore.Extensions
    {
    public static class TypeExt
        {
        /* TODO: L: Type: Comment below this*/

        /* TODO: L: Type: Untested below this*/

        #region Extensions

        #region AlsoBaseTypes
        public static List<Type> AlsoBaseTypes(this Type In)
            {
            List<Type> Out = In.BaseTypes();
            Out.Insert(0, In);
            return Out;
            }
        #endregion
        #region BaseTypes
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
        #endregion
        #region FindMethod
        public static MethodInfo FindMethod(this Type In, string Name)
            {
            return In.FindMethod(Name, new Type[] { });
            }
        public static MethodInfo FindMethod(this Type In, string Name, Type[] Arguments)
            {
            Type t = In;

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
        #region FindType
        public static Type FindType(string TypeName)
            {
            Type Out = System.Type.GetType(TypeName);

            if (Out != null)
                return Out;

            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
                {
                Out = a.GetType(TypeName);

                if (Out != null)
                    return Out;
                }

            return null;
            }
        #endregion
        #region GetAttributeTypeName
        public static string GetAttributeTypeName(this ICustomAttributeProvider p)
            {
            Type type = p as Type;
            if (type != null)
                return type.FullName;
            MemberInfo info = p as MemberInfo;
            if (info != null)
                return info.DeclaringType?.FullName;
            AttributeList list = p as AttributeList;
            if (list != null)
                return list.TypeName;
            ParameterInfo parameterInfo = p as ParameterInfo;
            if (parameterInfo != null)
                return parameterInfo.Member.DeclaringType?.FullName;
            throw new Exception($"Could not get attribute type name: {p.GetType().FullName}");
            }

        #endregion
        #region GetComparer
        public static IComparer GetComparer(this MemberInfo In)
            {
            return new ComparableComparer();
            }
        public static IComparer<T> GetComparer<T>(this MemberInfo In)
            {
            Type t = In.GetMemberType();

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
        #region GetMemberType
        public static Type GetMemberType(this MemberInfo In)
            {
            PropertyInfo @in = In as PropertyInfo;
            if (@in != null)
                {
                return @in.PropertyType;
                }
            FieldInfo info = In as FieldInfo;
            if (info != null)
                {
                return info.FieldType;
                }
            MethodInfo methodInfo = In as MethodInfo;
            return methodInfo?.ReturnType;
            }

        #endregion
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
                ConstructorInfo CachedConstructor = GetNewSubclass_ResultCache[CacheName];

                return (T)CachedConstructor.Invoke(Params);
                }

            List<Type> Types = t.GetNestedTypes().List();
            T Out = default(T);
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

                    ConstructorInfo Const = t2.GetConstructor(Params.GetTypes());
                    GetNewSubclass_ResultCache.Add(CacheName, Const);
                    object O = Const?.Invoke(Params);
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
        #region GetSubClass
        public static Type GetSubClass(this Type In, string SubClassName)
            {
            return In.AlsoBaseTypes().Collect(t =>
                {
                    Type Out = t.GetNestedTypes().First(t2 => t2.Name == SubClassName);
                    return Out;
                }).First();
            }
        #endregion
        #region GetSubClasses
        public static List<Type> GetSubClasses(this Type In)
            {
            List<Type> Out = new List<Type>();
            In.AlsoBaseTypes().Each(t =>
            {
                Out.AddRange(t.GetNestedTypes());
            });
            return Out;
            }
        #endregion
        #region GetSubClasses
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
            return In.MemberHasAttribute<IL_FriendlyName>(true) ? In.MemberGetAttribute<IL_FriendlyName>(true).FriendlyName : In?.Name.Humanize();
            }
        #endregion
        #region GetValue
        public static object GetValue(this MemberInfo In, object Obj)
            {
            try
                {
                PropertyInfo @in = In as PropertyInfo;
                if (@in != null)
                    {
                    return @in.GetValue(Obj, null);
                    }
                FieldInfo info = In as FieldInfo;
                return info?.GetValue(Obj);
                }
            catch (Exception e)
                {
                throw new Exception(In.Name, e);
                }
            }
        #endregion
        #region GetValues
        public static List<T> GetValues<T>(this Type In, object Obj)
            {
            return In.GetValues<T>(Obj, true);
            }
        public static List<T> GetValues<T>(this Type In, object Obj, bool IncludeSubclasses)
            {
            List<MemberInfo> Members = In.Members(typeof(T), IncludeSubclasses);
            return Members.GetValues<T>(Obj);
            }
        public static List<T> GetValues<T>(this List<MemberInfo> In, object Obj)
            {
            return In.GetValues<T>(Obj, false);
            }
        public static List<T> GetValues<T>(this List<MemberInfo> In, object Obj, bool Instanciate)
            {
            List<T> Out = new List<T>();
            Out = In.Convert(o =>
            {
                object o2 = o.GetValue(Obj);
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
        public static List<Type> GetTypes<T>(this List<T> In)
            {
            return In.Convert(i => i.GetType());
            }
        public static Type[] GetTypes<T>(this T[] In)
            {
            return In.Convert(i => i.GetType());
            }
        #endregion
        #region HasInterface
        public static bool HasInterface(this Type In, Type Interface, bool IncludeBaseTypes = true)
            {
            if (IncludeBaseTypes && In.BaseType != null)
                return In.GetInterfaces().Has(Interface) ||
                    In.BaseType.HasInterface(Interface);

            return In.GetInterfaces().Has(Interface);
            }
        public static bool HasInterface<T>(this Type In, bool IncludeBaseTypes = true)
            {
            Type Interface = typeof(T);

            if (IncludeBaseTypes && In.BaseType != null)
                return In.GetInterfaces().Has(Interface) ||
                    In.BaseType.HasInterface<T>();

            return In.GetInterfaces().Has(Interface);
            }
        #endregion
        #region HasSetterField
        public static bool HasSetterField(this MemberInfo In)
            {
            PropertyInfo @in = In as PropertyInfo;
            if (@in != null)
                return @in.CanWrite;
            FieldInfo info = In as FieldInfo;
            if (info != null)
                return !info.IsLiteral && !info.IsInitOnly;
            if (In is MethodInfo)
                return false;
            throw new Exception($"Unknown type: {In.GetType().Name}");
            }

        #endregion
        #region InstanciateValues
        public static List<T> InstanciateValues<T>(this Type In, object Obj, bool IncludeSubclasses)
            {
            List<MemberInfo> Members = In.Members(typeof(T), IncludeSubclasses);
            return Members.GetValues<T>(Obj, true);
            }
        public static List<T> InstanciateValues<T>(this List<MemberInfo> In, object Obj)
            {
            return In.GetValues<T>(Obj, true);
            }
        #endregion
        #region IsType
        public static bool IsType<T>(this object In)
            {
            return In.GetType().IsType(typeof(T));
            }
        public static bool IsType(this object In, Type t)
            {
            return In.GetType().IsType(t);
            }
        public static bool IsType(this Type In, Type t)
            {
            return In?.TypeEquals(t) == true ||
                   In?.IsSubclassOf(t) == true ||
                   (t.IsInterface && In?.HasInterface(t) == true);
            }
        public static bool IsType<T>(this Type In)
            {
            return In.IsType(typeof(T));
            }
        #endregion
        #region MemberGetAttribute
        public static T MemberGetAttribute<T>(this ICustomAttributeProvider p, bool IncludeBaseTypes)
            {
            object o = Logic.Def.TypeExt.GetAttribute(p.GetAttributeTypeName(), p, typeof(T), IncludeBaseTypes);

            if (o is T)
                return (T)o;

            return default(T);
            }
        #endregion
        #region MemberGetAttributes
        public static List<T> MemberGetAttributes<T>(this ICustomAttributeProvider p, bool IncludeBaseTypes)
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
                        Out.AddRange(MemberGetAttributes<T>(m, true));
                    });
                    }
                }

            if (typeof(T).HasInterface<IL_Attribute_ReverseOrder>())
                Out.Reverse();
            return Out;
            }
        #endregion
        #region MemberHasAttribute
        public static bool MemberHasAttribute<T>(this ICustomAttributeProvider p, bool IncludeBaseTypes)
            {
            return p.MemberHasAttribute(typeof(T), IncludeBaseTypes);
            }
        public static bool MemberHasAttribute(this ICustomAttributeProvider p, Type a, bool IncludeBaseTypes)
            {
            return Logic.Def.TypeExt.GetAttribute(p.GetAttributeTypeName(), p, a, IncludeBaseTypes) != null;
            }
        #endregion
        #region Members
        public static List<MemberInfo> Members(this Type In, Type t)
            {
            return In.Members(t, true);
            }
        public static List<MemberInfo> Members(this Type In, Type t, bool IncludeSubclasses)
            {
            List<MemberInfo> Out = In.GetMembers().List().Select(Member =>
            {
                Type t2 = Member.GetMemberType();
                return t2.IsType(t);
            });

            if (IncludeSubclasses && In.BaseType != null)
                Out.AddRange(In.BaseType.Members(t));
            return Out;
            }
        #endregion
        #region MemberType
        public static Type MemberType(this MemberInfo In)
            {
            PropertyInfo @in = In as PropertyInfo;
            if (@in != null)
                return @in.PropertyType;
            FieldInfo info = In as FieldInfo;
            if (info != null)
                return info.FieldType;
            MethodInfo methodInfo = In as MethodInfo;
            if (methodInfo != null)
                return methodInfo.ReturnType;
            throw new Exception($"Unknown Member Type: {In.GetType().FullName}");
            }

        #endregion
        #region New
        public static T New<T>(this Type In, object[] Arguments = null)
            {
            return (T)In.New(Arguments, typeof(T));
            }
        public static object New(this Type In, Type GenericType = null)
            {
            return In.New(null, GenericType);
            }
        public static object New(this Type In, object[] Arguments, Type GenericType = null)
            {
            try
                {
                if (In.IsValueType)
                    return Activator.CreateInstance(In);

                Arguments = Arguments ?? new object[] { };

                if (In.ContainsGenericParameters && GenericType != null)
                    {
                    List<Type[]> TypeArgs_Base = new List<Type[]>();

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

                ConstructorInfo Const = In.AlsoBaseTypes().First(t => t.GetConstructor(ArgTypes));

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
        public static void SetValue(this MemberInfo In, object Obj, object Value)
            {
            try
                {
                PropertyInfo @in = In as PropertyInfo;
                if (@in != null && @in.CanWrite)
                    {
                    @in.SetValue(Obj, Value, new object[] { });
                    return;
                    }

                FieldInfo info = In as FieldInfo;
                info?.SetValue(Obj, Value);
                }
            catch (Exception e)
                {
                throw new Exception(In.Name, e);
                }
            }
        #endregion
        #region Type
        [TestResult(new object[] { 0 }, typeof(int), GenericTypes = new[] { typeof(int) })]
        //      [TestResult(new Object[] { (String)null }, typeof(String), GenericTypes = new Type[] { typeof(String) })]
        [TestResult(new object[] { "" }, typeof(string), GenericTypes = new[] { typeof(string) })]
        public static Type Type<T>(this T In)
            {
            return typeof(T);
            }
        #endregion
        #region TypeEquals
        public static bool TypeEquals(this Type In, Type Compare)
            {
            return In != null &&
                Compare != null &&
                In.FullName == Compare.FullName;
            }
        #endregion
        #endregion
        }
    public partial class Logic
        {
        public partial class Def
            {
            public class TypeExt
                {
                #region Lambdas
                public static Func<string, string> Language_CleanOperationFunctionName = L.F<string, string>()
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
                .Else(Pass<string>());

                public static Func<string, string> Language_CleanOperationFunctionAction = L.F<string, string>()
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
                    .Else(Pass<string>());

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

                        MemberInfo info = Prop as MemberInfo;
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
                        MethodInfo prop = Prop as MethodInfo;
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
                public static Func<string, ICustomAttributeProvider, Type, bool, object> GetAttribute = _GetAttribute
                    .Cache("MemberAttributes").Require("Prop").Require2("Attr");
                #endregion
                #region As
                public static Func<object, T> As<T>()
                    where T : class
                    {
                    return o => o as T;
                    }
                #endregion
                #endregion
                }
            }
        }
    }
