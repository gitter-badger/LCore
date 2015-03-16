using LCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCL
    {
    public abstract class TypeResultAction<T>
        {
        public Object PerformAction(T In, Type t = null)
            {
            if (In == null)
                return default(T);

            t = t ?? In.GetType();

            Boolean Nullable = t.IsNullable();

            if (Nullable)
                {
                t = t.GetGenericArguments()[0];
                }

            if (t == typeof(int))
                {
                return PerformAction_Int(In);
                }
            else if (t == typeof(uint))
                {
                return PerformAction_UInt(In);
                }
            else if (t == typeof(long))
                {
                return PerformAction_Long(In);
                }
            else if (t == typeof(ulong))
                {
                return PerformAction_ULong(In);
                }
            else if (t == typeof(short))
                {
                return PerformAction_Short(In);
                }
            else if (t == typeof(ushort))
                {
                return PerformAction_UShort(In);
                }
            else if (t == typeof(decimal))
                {
                return PerformAction_Decimal(In);
                }
            else if (t == typeof(double))
                {
                return PerformAction_Double(In);
                }
            else if (t == typeof(float))
                {
                return PerformAction_Float(In);
                }
            else if (t == typeof(Boolean))
                {
                return PerformAction_Boolean(In);
                }
            else if (t == typeof(DateTime))
                {
                return PerformAction_DateTime(In);
                }
            else if (t == typeof(TimeSpan))
                {
                return PerformAction_TimeSpan(In);
                }
            else if (t == typeof(String))
                {
                return PerformAction_String(In);
                }
            else if (t.IsEnum ||
                 (t.IsGenericType && t.GetGenericArguments()[0].IsEnum))
                {
                return PerformAction_Enum(t, In);
                }
            else if (t.HasInterface(typeof(IModel), false))
                {
                return PerformAction_IModel(t, In);
                }
            else
                {
                return PerformAction_Object(In);
                }
            }

        protected abstract Object PerformAction_Object(T In);

        protected abstract IModel PerformAction_IModel(Type t, T In);

        protected abstract Enum PerformAction_Enum(Type t, T In);
        protected abstract String PerformAction_String(T In);
        protected abstract TimeSpan PerformAction_TimeSpan(T In);
        protected abstract DateTime PerformAction_DateTime(T In);

        protected abstract bool PerformAction_Boolean(T In);
        protected abstract float PerformAction_Float(T In);
        protected abstract double PerformAction_Double(T In);
        protected abstract decimal PerformAction_Decimal(T In);
        protected abstract ushort PerformAction_UShort(T In);
        protected abstract short PerformAction_Short(T In);
        protected abstract ulong PerformAction_ULong(T In);
        protected abstract long PerformAction_Long(T In);
        protected abstract uint PerformAction_UInt(T In);
        protected abstract int PerformAction_Int(T In);
        }

    public abstract class TypeArgumentAction<T>
        {
        public T PerformAction(Object In, Type t = null)
            {
            if (In == null)
                return default(T);

            t = t ?? In.GetType();

            Boolean Nullable = t.IsNullable();

            if (Nullable)
                {
                t = t.GetGenericArguments()[0];
                }

            if (t == typeof(int))
                {
                return PerformAction_Int((int)In);
                }
            else if (t == typeof(uint))
                {
                return PerformAction_UInt((uint)In);
                }
            else if (t == typeof(long))
                {
                return PerformAction_Long((long)In);
                }
            else if (t == typeof(ulong))
                {
                return PerformAction_ULong((ulong)In);
                }
            else if (t == typeof(short))
                {
                return PerformAction_Short((short)In);
                }
            else if (t == typeof(ushort))
                {
                return PerformAction_UShort((ushort)In);
                }
            else if (t == typeof(decimal))
                {
                return PerformAction_Decimal((decimal)In);
                }
            else if (t == typeof(double))
                {
                return PerformAction_Double((double)In);
                }
            else if (t == typeof(float))
                {
                return PerformAction_Float((float)In);
                }
            else if (t == typeof(Boolean))
                {
                return PerformAction_Boolean((Boolean)In);
                }
            else if (t == typeof(DateTime))
                {
                return PerformAction_DateTime((DateTime)In);
                }
            else if (t == typeof(TimeSpan))
                {
                return PerformAction_TimeSpan((TimeSpan)In);
                }
            else if (t == typeof(String))
                {
                return PerformAction_String((String)In);
                }
            else if (t.IsEnum ||
                 (t.IsGenericType && t.GetGenericArguments()[0].IsEnum))
                {
                return PerformAction_Enum((Enum)In);
                }
            else if (t.HasInterface(typeof(IModel), false))
                {
                return PerformAction_IModel((IModel)In);
                }
            else
                {
                return PerformAction_Object(In);
                }
            }

        protected abstract T PerformAction_Object(Object In);

        protected abstract T PerformAction_IModel(IModel In);

        protected abstract T PerformAction_Enum(Enum In);
        protected abstract T PerformAction_String(String In);
        protected abstract T PerformAction_TimeSpan(TimeSpan In);
        protected abstract T PerformAction_DateTime(DateTime In);

        protected abstract T PerformAction_Boolean(bool In);
        protected abstract T PerformAction_Float(float In);
        protected abstract T PerformAction_Double(double In);
        protected abstract T PerformAction_Decimal(decimal In);
        protected abstract T PerformAction_UShort(ushort In);
        protected abstract T PerformAction_Short(short In);
        protected abstract T PerformAction_ULong(ulong In);
        protected abstract T PerformAction_Long(long In);
        protected abstract T PerformAction_UInt(uint In);
        protected abstract T PerformAction_Int(int In);
        }

    public abstract class TypeAction<T>
        {
        public T PerformAction(Type t)
            {
            Boolean Nullable = t.IsNullable();

            if (Nullable)
                {
                t = t.GetGenericArguments()[0];
                }

            if (t == typeof(int))
                {
                return PerformAction_Int();
                }
            else if (t == typeof(uint))
                {
                return PerformAction_UInt();
                }
            else if (t == typeof(long))
                {
                return PerformAction_Long();
                }
            else if (t == typeof(ulong))
                {
                return PerformAction_ULong();
                }
            else if (t == typeof(short))
                {
                return PerformAction_Short();
                }
            else if (t == typeof(ushort))
                {
                return PerformAction_UShort();
                }
            else if (t == typeof(decimal))
                {
                return PerformAction_Decimal();
                }
            else if (t == typeof(double))
                {
                return PerformAction_Double();
                }
            else if (t == typeof(float))
                {
                return PerformAction_Float();
                }
            else if (t == typeof(Boolean))
                {
                return PerformAction_Boolean();
                }
            else if (t == typeof(DateTime))
                {
                return PerformAction_DateTime();
                }
            else if (t == typeof(TimeSpan))
                {
                return PerformAction_TimeSpan();
                }
            else if (t == typeof(String))
                {
                return PerformAction_String();
                }
            else if (t.IsEnum ||
                 (t.IsGenericType && t.GetGenericArguments()[0].IsEnum))
                {
                return PerformAction_Enum(t);
                }
            else if (t.HasInterface(typeof(IModel), false))
                {
                return PerformAction_IModel(t);
                }
            else
                {
                return PerformAction_Object(t);
                }
            }

        protected abstract T PerformAction_Object(Type t);

        protected abstract T PerformAction_IModel(Type t);

        protected abstract T PerformAction_Enum(Type t);
        protected abstract T PerformAction_String();
        protected abstract T PerformAction_TimeSpan();
        protected abstract T PerformAction_DateTime();

        protected abstract T PerformAction_Boolean();
        protected abstract T PerformAction_Float();
        protected abstract T PerformAction_Double();
        protected abstract T PerformAction_Decimal();
        protected abstract T PerformAction_UShort();
        protected abstract T PerformAction_Short();
        protected abstract T PerformAction_ULong();
        protected abstract T PerformAction_Long();
        protected abstract T PerformAction_UInt();
        protected abstract T PerformAction_Int();
        }
    }
