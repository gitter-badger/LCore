
using LCore.Extensions;
using Singularity.Models;
using Singularity.Extensions;
using System;

namespace Singularity.Utilities
    {
    public abstract class TypeResultAction<T>
        {
        public object PerformAction(T In, Type t = null)
            {
            if (In == null)
                return default(T);

            t = t ?? In.GetType();

            bool Nullable = t.IsNullable();

            if (Nullable)
                {
                t = t.GetGenericArguments()[0];
                }

            if (t == typeof(int))
                {
                return this.PerformAction_Int(In);
                }
            if (t == typeof(uint))
                {
                return this.PerformAction_UInt(In);
                }
            if (t == typeof(long))
                {
                return this.PerformAction_Long(In);
                }
            if (t == typeof(ulong))
                {
                return this.PerformAction_ULong(In);
                }
            if (t == typeof(short))
                {
                return this.PerformAction_Short(In);
                }
            if (t == typeof(ushort))
                {
                return this.PerformAction_UShort(In);
                }
            if (t == typeof(decimal))
                {
                return this.PerformAction_Decimal(In);
                }
            if (t == typeof(double))
                {
                return this.PerformAction_Double(In);
                }
            if (t == typeof(float))
                {
                return this.PerformAction_Float(In);
                }
            if (t == typeof(bool))
                {
                return this.PerformAction_Boolean(In);
                }
            if (t == typeof(DateTime))
                {
                return this.PerformAction_DateTime(In);
                }
            if (t == typeof(TimeSpan))
                {
                return this.PerformAction_TimeSpan(In);
                }
            if (t == typeof(string))
                {
                return this.PerformAction_String(In);
                }
            if (t.IsEnum ||
                (t.IsGenericType && t.GetGenericArguments()[0].IsEnum))
                {
                return this.PerformAction_Enum(t, In);
                }
            return t.HasInterface<IModel>() ? this.PerformAction_IModel(t, In) : this.PerformAction_Object(In);
            }

        protected abstract object PerformAction_Object(T In);

        protected abstract IModel PerformAction_IModel(Type t, T In);

        protected abstract Enum PerformAction_Enum(Type t, T In);
        protected abstract string PerformAction_String(T In);
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
        public T PerformAction(object In, Type t = null)
            {
            if (In == null)
                return default(T);

            t = t ?? In.GetType();

            bool Nullable = t.IsNullable();

            if (Nullable)
                {
                t = t.GetGenericArguments()[0];
                }

            if (t == typeof(int))
                {
                return this.PerformAction_Int((int)In);
                }
            if (t == typeof(uint))
                {
                return this.PerformAction_UInt((uint)In);
                }
            if (t == typeof(long))
                {
                return this.PerformAction_Long((long)In);
                }
            if (t == typeof(ulong))
                {
                return this.PerformAction_ULong((ulong)In);
                }
            if (t == typeof(short))
                {
                return this.PerformAction_Short((short)In);
                }
            if (t == typeof(ushort))
                {
                return this.PerformAction_UShort((ushort)In);
                }
            if (t == typeof(decimal))
                {
                return this.PerformAction_Decimal((decimal)In);
                }
            if (t == typeof(double))
                {
                return this.PerformAction_Double((double)In);
                }
            if (t == typeof(float))
                {
                return this.PerformAction_Float((float)In);
                }
            if (t == typeof(bool))
                {
                return this.PerformAction_Boolean((bool)In);
                }
            if (t == typeof(DateTime))
                {
                return this.PerformAction_DateTime((DateTime)In);
                }
            if (t == typeof(TimeSpan))
                {
                return this.PerformAction_TimeSpan((TimeSpan)In);
                }
            if (t == typeof(string))
                {
                return this.PerformAction_String((string)In);
                }
            if (t.IsEnum ||
                (t.IsGenericType && t.GetGenericArguments()[0].IsEnum))
                {
                return this.PerformAction_Enum((Enum)In);
                }
            return t.HasInterface<IModel>() ? this.PerformAction_IModel((IModel)In) : this.PerformAction_Object(In);
            }

        protected abstract T PerformAction_Object(object In);

        protected abstract T PerformAction_IModel(IModel In);

        protected abstract T PerformAction_Enum(Enum In);
        protected abstract T PerformAction_String(string In);
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
        [System.Diagnostics.DebuggerStepThrough]
        public T PerformAction(Type t)
            {
            bool Nullable = t.IsNullable();

            if (Nullable)
                {
                t = t.GetGenericArguments()[0];
                }

            if (t == typeof(int))
                {
                return this.PerformAction_Int();
                }
            if (t == typeof(uint))
                {
                return this.PerformAction_UInt();
                }
            if (t == typeof(long))
                {
                return this.PerformAction_Long();
                }
            if (t == typeof(ulong))
                {
                return this.PerformAction_ULong();
                }
            if (t == typeof(short))
                {
                return this.PerformAction_Short();
                }
            if (t == typeof(ushort))
                {
                return this.PerformAction_UShort();
                }
            if (t == typeof(decimal))
                {
                return this.PerformAction_Decimal();
                }
            if (t == typeof(double))
                {
                return this.PerformAction_Double();
                }
            if (t == typeof(float))
                {
                return this.PerformAction_Float();
                }
            if (t == typeof(bool))
                {
                return this.PerformAction_Boolean();
                }
            if (t == typeof(DateTime))
                {
                return this.PerformAction_DateTime();
                }
            if (t == typeof(TimeSpan))
                {
                return this.PerformAction_TimeSpan();
                }
            if (t == typeof(string))
                {
                return this.PerformAction_String();
                }
            if (t.IsEnum ||
                (t.IsGenericType && t.GetGenericArguments()[0].IsEnum))
                {
                return this.PerformAction_Enum(t);
                }
            return t.HasInterface<IModel>() ? this.PerformAction_IModel(t) : this.PerformAction_Object(t);
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
