using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace LCore
    {
    public partial class Logic
        {
        #region Base Lambdas
        #region IComparable
        public static Func<IComparable, Object, Int32> IComparable_CompareTo = (i, obj) => { return i.CompareTo(obj); };
        #endregion
        #region IFormattable
        public static Func<IFormattable, String, IFormatProvider, String> IFormattable_ToString = (i, format, formatProvider) => { return i.ToString(format, formatProvider); };
        #endregion
        #region IConvertible
        public static Func<IConvertible, TypeCode> IConvertible_GetTypeCode = (i) => { return i.GetTypeCode(); };
        public static Func<IConvertible, IFormatProvider, Boolean> IConvertible_ToBoolean = (i, provider) => { return i.ToBoolean(provider); };
        public static Func<IConvertible, IFormatProvider, Char> IConvertible_ToChar = (i, provider) => { return i.ToChar(provider); };
        public static Func<IConvertible, IFormatProvider, SByte> IConvertible_ToSByte = (i, provider) => { return i.ToSByte(provider); };
        public static Func<IConvertible, IFormatProvider, Byte> IConvertible_ToByte = (i, provider) => { return i.ToByte(provider); };
        public static Func<IConvertible, IFormatProvider, Int16> IConvertible_ToInt16 = (i, provider) => { return i.ToInt16(provider); };
        public static Func<IConvertible, IFormatProvider, UInt16> IConvertible_ToUInt16 = (i, provider) => { return i.ToUInt16(provider); };
        public static Func<IConvertible, IFormatProvider, Int32> IConvertible_ToInt32 = (i, provider) => { return i.ToInt32(provider); };
        public static Func<IConvertible, IFormatProvider, UInt32> IConvertible_ToUInt32 = (i, provider) => { return i.ToUInt32(provider); };
        public static Func<IConvertible, IFormatProvider, Int64> IConvertible_ToInt64 = (i, provider) => { return i.ToInt64(provider); };
        public static Func<IConvertible, IFormatProvider, UInt64> IConvertible_ToUInt64 = (i, provider) => { return i.ToUInt64(provider); };
        public static Func<IConvertible, IFormatProvider, Single> IConvertible_ToSingle = (i, provider) => { return i.ToSingle(provider); };
        public static Func<IConvertible, IFormatProvider, Double> IConvertible_ToDouble = (i, provider) => { return i.ToDouble(provider); };
        public static Func<IConvertible, IFormatProvider, Decimal> IConvertible_ToDecimal = (i, provider) => { return i.ToDecimal(provider); };
        public static Func<IConvertible, IFormatProvider, DateTime> IConvertible_ToDateTime = (i, provider) => { return i.ToDateTime(provider); };
        public static Func<IConvertible, IFormatProvider, String> IConvertible_ToString = (i, provider) => { return i.ToString(provider); };
        public static Func<IConvertible, Type, IFormatProvider, Object> IConvertible_ToType = (i, conversionType, provider) => { return i.ToType(conversionType, provider); };
        #endregion
        #region ICustomAttributeProvider
        public static Func<ICustomAttributeProvider, Type, Boolean, Object[]> ICustomAttributeProvider_GetCustomAttributes = (i, attributeType, inherit) => { return i.GetCustomAttributes(attributeType, inherit); };
        public static Func<ICustomAttributeProvider, Boolean, Object[]> ICustomAttributeProvider_GetCustomAttributes2 = (i, inherit) => { return i.GetCustomAttributes(inherit); };
        public static Func<ICustomAttributeProvider, Type, Boolean, Boolean> ICustomAttributeProvider_IsDefined = (i, attributeType, inherit) => { return i.IsDefined(attributeType, inherit); };
        #endregion
        #region IReflect
        public static Func<IReflect, Type> IReflect_GetUnderlyingSystemType = (i) => { return i.UnderlyingSystemType; };
        /* Too Many Parameters :( 
        public static Func<IReflect, String, BindingFlags, Binder, Type[], ParameterModifier[], MethodInfo> IReflect_GetMethod = (i, name, bindingAttr, binder, types, modifiers) => { return i.GetMethod(name, bindingAttr, binder, types, modifiers); };
        */
        public static Func<IReflect, String, BindingFlags, MethodInfo> IReflect_GetMethod2 = (i, name, bindingAttr) => { return i.GetMethod(name, bindingAttr); };
        public static Func<IReflect, BindingFlags, MethodInfo[]> IReflect_GetMethods = (i, bindingAttr) => { return i.GetMethods(bindingAttr); };
        public static Func<IReflect, String, BindingFlags, FieldInfo> IReflect_GetField = (i, name, bindingAttr) => { return i.GetField(name, bindingAttr); };
        public static Func<IReflect, BindingFlags, FieldInfo[]> IReflect_GetFields = (i, bindingAttr) => { return i.GetFields(bindingAttr); };
        public static Func<IReflect, String, BindingFlags, PropertyInfo> IReflect_GetProperty = (i, name, bindingAttr) => { return i.GetProperty(name, bindingAttr); };
        /* Too Many Parameters :( 
        public static Func<IReflect, String, BindingFlags, Binder, Type, Type[], ParameterModifier[], PropertyInfo> IReflect_GetProperty2 = (i, name, bindingAttr, binder, returnType, types, modifiers) => { return i.GetProperty(name, bindingAttr, binder, returnType, types, modifiers); };
        */
        public static Func<IReflect, BindingFlags, PropertyInfo[]> IReflect_GetProperties = (i, bindingAttr) => { return i.GetProperties(bindingAttr); };
        public static Func<IReflect, String, BindingFlags, MemberInfo[]> IReflect_GetMember = (i, name, bindingAttr) => { return i.GetMember(name, bindingAttr); };
        public static Func<IReflect, BindingFlags, MemberInfo[]> IReflect_GetMembers = (i, bindingAttr) => { return i.GetMembers(bindingAttr); };
        /* Too Many Parameters :( 
        public static Func<IReflect, String, BindingFlags, Binder, Object, Object[], ParameterModifier[], CultureInfo, String[], Object> IReflect_InvokeMember = (i, name, invokeAttr, binder, target, args, modifiers, culture, namedParameters) => { return i.InvokeMember(name, invokeAttr, binder, target, args, modifiers, culture, namedParameters); };
        */
        #endregion
        #region IObjectReference
        public static Func<IObjectReference, StreamingContext, Object> IObjectReference_GetRealObject = (i, context) => { return i.GetRealObject(context); };
        #endregion
        #endregion
        }
    public static class InterfaceExt
        {
        public static Object ConvertTo(this IConvertible In, Type t) 
            {
            if (In == null)
                return null;

            return Convert.ChangeType(In, t);
            }

        public static T ConvertTo<T>(this IConvertible In) where T : IConvertible
            {
            if (In == null)
                return default(T);

            return (T)Convert.ChangeType(In, typeof(T));
            }
        }
    }