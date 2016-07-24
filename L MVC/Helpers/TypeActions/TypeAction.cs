
using LCore.Extensions;
using LMVC.Models;
using System;
using JetBrains.Annotations;

namespace LMVC.Utilities
    {
    public abstract class TypeResultAction<T>
        {
        public object PerformAction([CanBeNull]T In, Type Type = null)
            {
            if (In == null)
                return default(T);

            Type = Type ?? In.GetType();

            bool Nullable = Type.IsNullable();

            if (Nullable)
                {
                Type = Type.GetGenericArguments()[0];
                }

            if (Type == typeof(int))
                {
                return this.PerformAction_Int(In);
                }
            if (Type == typeof(uint))
                {
                return this.PerformAction_UInt(In);
                }
            if (Type == typeof(long))
                {
                return this.PerformAction_Long(In);
                }
            if (Type == typeof(ulong))
                {
                return this.PerformAction_ULong(In);
                }
            if (Type == typeof(short))
                {
                return this.PerformAction_Short(In);
                }
            if (Type == typeof(ushort))
                {
                return this.PerformAction_UShort(In);
                }
            if (Type == typeof(decimal))
                {
                return this.PerformAction_Decimal(In);
                }
            if (Type == typeof(double))
                {
                return this.PerformAction_Double(In);
                }
            if (Type == typeof(float))
                {
                return this.PerformAction_Float(In);
                }
            if (Type == typeof(bool))
                {
                return this.PerformAction_Boolean(In);
                }
            if (Type == typeof(DateTime))
                {
                return this.PerformAction_DateTime(In);
                }
            if (Type == typeof(TimeSpan))
                {
                return this.PerformAction_TimeSpan(In);
                }
            if (Type == typeof(string))
                {
                return this.PerformAction_String(In);
                }
            if (Type.IsEnum ||
                (Type.IsGenericType && Type.GetGenericArguments()[0].IsEnum))
                {
                return this.PerformAction_Enum(Type, In);
                }
            return Type.HasInterface<IModel>() ? this.PerformAction_IModel(Type, In) : this.PerformAction_Object(In);
            }

        protected abstract object PerformAction_Object(T In);

        protected abstract IModel PerformAction_IModel(Type Type, T In);

        protected abstract Enum PerformAction_Enum(Type Type, T In);
        protected abstract string PerformAction_String(T In);
        protected abstract TimeSpan? PerformAction_TimeSpan(T In);
        protected abstract DateTime? PerformAction_DateTime(T In);

        protected abstract bool? PerformAction_Boolean(T In);
        protected abstract float? PerformAction_Float(T In);
        protected abstract double? PerformAction_Double(T In);
        protected abstract decimal? PerformAction_Decimal(T In);
        protected abstract ushort? PerformAction_UShort(T In);
        protected abstract short? PerformAction_Short(T In);
        protected abstract ulong? PerformAction_ULong(T In);
        protected abstract long? PerformAction_Long(T In);
        protected abstract uint? PerformAction_UInt(T In);
        protected abstract int? PerformAction_Int(T In);
        }

    public abstract class TypeArgumentAction<T>
        {
        public T PerformAction(object In, Type Type = null)
            {
            if (In == null)
                return default(T);

            Type = Type ?? In.GetType();

            bool Nullable = Type.IsNullable();

            if (Nullable)
                {
                Type = Type.GetGenericArguments()[0];
                }

            if (Type == typeof(int))
                {
                return this.PerformAction_Int((int)In);
                }
            if (Type == typeof(uint))
                {
                return this.PerformAction_UInt((uint)In);
                }
            if (Type == typeof(long))
                {
                return this.PerformAction_Long((long)In);
                }
            if (Type == typeof(ulong))
                {
                return this.PerformAction_ULong((ulong)In);
                }
            if (Type == typeof(short))
                {
                return this.PerformAction_Short((short)In);
                }
            if (Type == typeof(ushort))
                {
                return this.PerformAction_UShort((ushort)In);
                }
            if (Type == typeof(decimal))
                {
                return this.PerformAction_Decimal((decimal)In);
                }
            if (Type == typeof(double))
                {
                return this.PerformAction_Double((double)In);
                }
            if (Type == typeof(float))
                {
                return this.PerformAction_Float((float)In);
                }
            if (Type == typeof(bool))
                {
                return this.PerformAction_Boolean((bool)In);
                }
            if (Type == typeof(DateTime))
                {
                return this.PerformAction_DateTime((DateTime)In);
                }
            if (Type == typeof(TimeSpan))
                {
                return this.PerformAction_TimeSpan((TimeSpan)In);
                }
            if (Type == typeof(string))
                {
                return this.PerformAction_String((string)In);
                }
            if (Type.IsEnum ||
                (Type.IsGenericType && Type.GetGenericArguments()[0].IsEnum))
                {
                return this.PerformAction_Enum((Enum)In);
                }
            return Type.HasInterface<IModel>() ? this.PerformAction_IModel((IModel)In) : this.PerformAction_Object(In);
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
        public T PerformAction(Type Type)
            {
            bool Nullable = Type.IsNullable();

            if (Nullable)
                {
                Type = Type.GetGenericArguments()[0];
                }

            if (Type == typeof(int))
                {
                return this.PerformAction_Int();
                }
            if (Type == typeof(uint))
                {
                return this.PerformAction_UInt();
                }
            if (Type == typeof(long))
                {
                return this.PerformAction_Long();
                }
            if (Type == typeof(ulong))
                {
                return this.PerformAction_ULong();
                }
            if (Type == typeof(short))
                {
                return this.PerformAction_Short();
                }
            if (Type == typeof(ushort))
                {
                return this.PerformAction_UShort();
                }
            if (Type == typeof(decimal))
                {
                return this.PerformAction_Decimal();
                }
            if (Type == typeof(double))
                {
                return this.PerformAction_Double();
                }
            if (Type == typeof(float))
                {
                return this.PerformAction_Float();
                }
            if (Type == typeof(bool))
                {
                return this.PerformAction_Boolean();
                }
            if (Type == typeof(DateTime))
                {
                return this.PerformAction_DateTime();
                }
            if (Type == typeof(TimeSpan))
                {
                return this.PerformAction_TimeSpan();
                }
            if (Type == typeof(string))
                {
                return this.PerformAction_String();
                }
            if (Type.IsEnum ||
                (Type.IsGenericType && Type.GetGenericArguments()[0].IsEnum))
                {
                return this.PerformAction_Enum(Type);
                }
            return Type.HasInterface<IModel>() ? this.PerformAction_IModel(Type) : this.PerformAction_Object(Type);
            }

        protected abstract T PerformAction_Object(Type Type);

        protected abstract T PerformAction_IModel(Type Type);

        protected abstract T PerformAction_Enum(Type EnumType);
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
