
using LCore.Extensions;
using LMVC.Models;
using System;
using JetBrains.Annotations;

namespace LMVC.Utilities
    {
    public abstract class TypeResultAction<T>
        {
        [CanBeNull]
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

        [CanBeNull]
        protected abstract object PerformAction_Object(T In);

        [CanBeNull]
        protected abstract IModel PerformAction_IModel(Type Type, T In);

        [CanBeNull]
        protected abstract Enum PerformAction_Enum(Type Type, T In);
        [CanBeNull]
        protected abstract string PerformAction_String(T In);
        [CanBeNull]
        protected abstract TimeSpan? PerformAction_TimeSpan(T In);
        [CanBeNull]
        protected abstract DateTime? PerformAction_DateTime(T In);

        [CanBeNull]
        protected abstract bool? PerformAction_Boolean(T In);
        [CanBeNull]
        protected abstract float? PerformAction_Float(T In);
        [CanBeNull]
        protected abstract double? PerformAction_Double(T In);
        [CanBeNull]
        protected abstract decimal? PerformAction_Decimal(T In);
        [CanBeNull]
        protected abstract ushort? PerformAction_UShort(T In);
        [CanBeNull]
        protected abstract short? PerformAction_Short(T In);
        [CanBeNull]
        protected abstract ulong? PerformAction_ULong(T In);
        [CanBeNull]
        protected abstract long? PerformAction_Long(T In);
        [CanBeNull]
        protected abstract uint? PerformAction_UInt(T In);
        [CanBeNull]
        protected abstract int? PerformAction_Int(T In);
        }

    public abstract class TypeArgumentAction<T>
        {
        [CanBeNull]
        public T PerformAction([CanBeNull]object In, [CanBeNull]Type Type = null)
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

        [CanBeNull]
        protected abstract T PerformAction_Object(object In);

        [CanBeNull]
        protected abstract T PerformAction_IModel(IModel In);

        [CanBeNull]
        protected abstract T PerformAction_Enum(Enum In);
        [CanBeNull]
        protected abstract T PerformAction_String(string In);
        [CanBeNull]
        protected abstract T PerformAction_TimeSpan(TimeSpan In);
        [CanBeNull]
        protected abstract T PerformAction_DateTime(DateTime In);

        [CanBeNull]
        protected abstract T PerformAction_Boolean(bool In);
        [CanBeNull]
        protected abstract T PerformAction_Float(float In);
        [CanBeNull]
        protected abstract T PerformAction_Double(double In);
        [CanBeNull]
        protected abstract T PerformAction_Decimal(decimal In);
        [CanBeNull]
        protected abstract T PerformAction_UShort(ushort In);
        [CanBeNull]
        protected abstract T PerformAction_Short(short In);
        [CanBeNull]
        protected abstract T PerformAction_ULong(ulong In);
        [CanBeNull]
        protected abstract T PerformAction_Long(long In);
        [CanBeNull]
        protected abstract T PerformAction_UInt(uint In);
        [CanBeNull]
        protected abstract T PerformAction_Int(int In);
        }

    public abstract class TypeAction<T>
        {
        [System.Diagnostics.DebuggerStepThrough]
        [CanBeNull]
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

        [CanBeNull]
        protected abstract T PerformAction_Object(Type Type);

        [CanBeNull]
        protected abstract T PerformAction_IModel(Type Type);

        [CanBeNull]
        protected abstract T PerformAction_Enum(Type EnumType);
        [CanBeNull]
        protected abstract T PerformAction_String();
        [CanBeNull]
        protected abstract T PerformAction_TimeSpan();
        [CanBeNull]
        protected abstract T PerformAction_DateTime();

        [CanBeNull]
        protected abstract T PerformAction_Boolean();
        [CanBeNull]
        protected abstract T PerformAction_Float();
        [CanBeNull]
        protected abstract T PerformAction_Double();
        [CanBeNull]
        protected abstract T PerformAction_Decimal();
        [CanBeNull]
        protected abstract T PerformAction_UShort();
        [CanBeNull]
        protected abstract T PerformAction_Short();
        [CanBeNull]
        protected abstract T PerformAction_ULong();
        [CanBeNull]
        protected abstract T PerformAction_Long();
        [CanBeNull]
        protected abstract T PerformAction_UInt();
        [CanBeNull]
        protected abstract T PerformAction_Int();
        }
    }
