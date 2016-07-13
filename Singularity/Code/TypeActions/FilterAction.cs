
using LCore.Extensions;
using Singularity.Extensions;
using Singularity.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Singularity.Utilities
    {
    public class FilterExpression<T> : TypeAction<Expression<Func<T, bool>>>
        {
        private SearchOperation Operation { get; }
        private LambdaExpression Accessor { get; }
        private ModelMetadata Meta { get; }

        public FilterExpression(SearchOperation Operation, LambdaExpression Accessor, ModelMetadata Meta)
            {
            this.Operation = Operation;
            this.Accessor = Accessor;
            this.Meta = Meta;
            }

        /// <exception cref="ArgumentException">Invalid Value</exception>
        protected override Expression<Func<T, bool>> PerformAction_Boolean()
            {
            string SearchLower = this.Operation.Search.ToLower();

            if (SearchLower == "y" || SearchLower == "yes" || SearchLower == "true")
                return this.Accessor.GetOperatorExpression<T>(this.Operation.Operator, true);
            if (SearchLower == "n" || SearchLower == "no" || SearchLower == "false")
                return this.Accessor.GetOperatorExpression<T>(this.Operation.Operator, false);
            throw new ArgumentException($"Invalid value: {SearchLower}");
            }

        /// <exception cref="OverflowException">
        ///         <paramref>
        ///             <name>value</name>
        ///         </paramref>
        ///     represents a number that is less than <see cref="F:System.Int32.MinValue" /> or greater than <see cref="F:System.Int32.MaxValue" />. </exception>
        protected override Expression<Func<T, bool>> PerformAction_Int()
            {
            if (this.Operation.OperatorStr == "<>" || this.Operation.OperatorStr == "><")
                {
                bool Nullable = this.Meta.ModelType == typeof(int?);

                if (Nullable)
                    {
                    string[] Split = this.Operation.Search.Split(" ");

                    int? Min = Convert.ToInt32(Split[0]);
                    int? Max = Convert.ToInt32(Split[1]);

                    if (Min > Max)
                        L.Obj.Swap(ref Min, ref Max);

                    if (this.Operation.OperatorStr == "<>")
                        return this.Accessor.ExpressionWithout<T, int?>(Min, Max);
                    if (this.Operation.OperatorStr == "><")
                        return this.Accessor.ExpressionWithin<T, int?>(Min, Max);
                    }
                else
                    {
                    string[] Split = this.Operation.Search.Split(" ");

                    int Min = Convert.ToInt32(Split[0]);
                    int Max = Convert.ToInt32(Split[1]);

                    if (Min > Max)
                        L.Obj.Swap(ref Min, ref Max);

                    if (this.Operation.OperatorStr == "<>")
                        return this.Accessor.ExpressionWithout<T, int>(Min, Max);
                    if (this.Operation.OperatorStr == "><")
                        return this.Accessor.ExpressionWithin<T, int>(Min, Max);
                    }
                }
            else
                {
                int SearchInt;

                if (int.TryParse(this.Operation.Search, out SearchInt))
                    {
                    return this.Accessor.GetOperatorExpression<T>(this.Operation.Operator, SearchInt);
                    }
                }
            return null;
            }
        /// <exception cref="OverflowException">
        ///         <paramref>
        ///             <name>value</name>
        ///         </paramref>
        ///     represents a number that is less than <see cref="F:System.Int32.MinValue" /> or greater than <see cref="F:System.Int32.MaxValue" />. </exception>
        protected override Expression<Func<T, bool>> PerformAction_UInt()
            {
            if (this.Operation.OperatorStr == "<>" || this.Operation.OperatorStr == "><")
                {
                bool Nullable = this.Meta.ModelType == typeof(uint?);

                if (Nullable)
                    {
                    string[] Split = this.Operation.Search.Split(" ");

                    uint? Min = Convert.ToUInt32(Split[0]);
                    uint? Max = Convert.ToUInt32(Split[1]);

                    if (Min > Max)
                        L.Obj.Swap(ref Min, ref Max);

                    if (this.Operation.OperatorStr == "<>")
                        return this.Accessor.ExpressionWithout<T, uint?>(Min, Max);
                    if (this.Operation.OperatorStr == "><")
                        return this.Accessor.ExpressionWithin<T, uint?>(Min, Max);
                    }
                else
                    {
                    string[] Split = this.Operation.Search.Split(" ");

                    uint Min = Convert.ToUInt32(Split[0]);
                    uint Max = Convert.ToUInt32(Split[1]);

                    if (Min > Max)
                        L.Obj.Swap(ref Min, ref Max);

                    if (this.Operation.OperatorStr == "<>")
                        return this.Accessor.ExpressionWithout<T, uint>(Min, Max);
                    if (this.Operation.OperatorStr == "><")
                        return this.Accessor.ExpressionWithin<T, uint>(Min, Max);
                    }
                }
            else
                {
                uint SearchUInt = Convert.ToUInt32(this.Operation.Search);

                return this.Accessor.GetOperatorExpression<T>(this.Operation.Operator, SearchUInt);
                }
            return null;
            }
        /// <exception cref="OverflowException">
        ///         <paramref>
        ///             <name>value</name>
        ///         </paramref>
        ///     represents a number that is less than <see cref="F:System.Int32.MinValue" /> or greater than <see cref="F:System.Int32.MaxValue" />. </exception>
        protected override Expression<Func<T, bool>> PerformAction_Long()
            {
            if (this.Operation.OperatorStr == "<>" || this.Operation.OperatorStr == "><")
                {
                bool Nullable = this.Meta.ModelType == typeof(long?);

                if (Nullable)
                    {
                    string[] Split = this.Operation.Search.Split(" ");

                    long? Min = Convert.ToInt64(Split[0]);
                    long? Max = Convert.ToInt64(Split[1]);

                    if (Min > Max)
                        L.Obj.Swap(ref Min, ref Max);

                    if (this.Operation.OperatorStr == "<>")
                        return this.Accessor.ExpressionWithout<T, long?>(Min, Max);
                    if (this.Operation.OperatorStr == "><")
                        return this.Accessor.ExpressionWithin<T, long?>(Min, Max);
                    }
                else
                    {
                    string[] Split = this.Operation.Search.Split(" ");

                    long Min = Convert.ToInt64(Split[0]);
                    long Max = Convert.ToInt64(Split[1]);

                    if (Min > Max)
                        L.Obj.Swap(ref Min, ref Max);

                    if (this.Operation.OperatorStr == "<>")
                        return this.Accessor.ExpressionWithout<T, long>(Min, Max);
                    if (this.Operation.OperatorStr == "><")
                        return this.Accessor.ExpressionWithin<T, long>(Min, Max);
                    }
                }
            else
                {
                long SearchLong = Convert.ToInt64(this.Operation.Search);

                return this.Accessor.GetOperatorExpression<T>(this.Operation.Operator, SearchLong);
                }
            return null;
            }
        /// <exception cref="OverflowException">
        ///         <paramref>
        ///             <name>value</name>
        ///         </paramref>
        ///     represents a number that is less than <see cref="F:System.Int32.MinValue" /> or greater than <see cref="F:System.Int32.MaxValue" />. </exception>
        protected override Expression<Func<T, bool>> PerformAction_ULong()
            {
            if (this.Operation.OperatorStr == "<>" || this.Operation.OperatorStr == "><")
                {
                bool Nullable = this.Meta.ModelType == typeof(ulong?);

                if (Nullable)
                    {
                    string[] Split = this.Operation.Search.Split(" ");

                    ulong? Min = Convert.ToUInt64(Split[0]);
                    ulong? Max = Convert.ToUInt64(Split[1]);

                    if (Min > Max)
                        L.Obj.Swap(ref Min, ref Max);

                    if (this.Operation.OperatorStr == "<>")
                        return this.Accessor.ExpressionWithout<T, ulong?>(Min, Max);
                    if (this.Operation.OperatorStr == "><")
                        return this.Accessor.ExpressionWithin<T, ulong?>(Min, Max);
                    }
                else
                    {
                    string[] Split = this.Operation.Search.Split(" ");

                    ulong Min = Convert.ToUInt64(Split[0]);
                    ulong Max = Convert.ToUInt64(Split[1]);

                    if (Min > Max)
                        L.Obj.Swap(ref Min, ref Max);

                    if (this.Operation.OperatorStr == "<>")
                        return this.Accessor.ExpressionWithout<T, ulong>(Min, Max);
                    if (this.Operation.OperatorStr == "><")
                        return this.Accessor.ExpressionWithin<T, ulong>(Min, Max);
                    }

                }
            else
                {
                ulong SearchULong = Convert.ToUInt64(this.Operation.Search);

                return this.Accessor.GetOperatorExpression<T>(this.Operation.Operator, SearchULong);
                }
            return null;
            }
        /// <exception cref="OverflowException">
        ///         <paramref>
        ///             <name>value</name>
        ///         </paramref>
        ///     represents a number that is less than <see cref="F:System.Int32.MinValue" /> or greater than <see cref="F:System.Int32.MaxValue" />. </exception>
        protected override Expression<Func<T, bool>> PerformAction_Short()
            {
            if (this.Operation.OperatorStr == "<>" || this.Operation.OperatorStr == "><")
                {
                bool Nullable = this.Meta.ModelType == typeof(short?);

                if (Nullable)
                    {
                    string[] Split = this.Operation.Search.Split(" ");

                    short? Min = Convert.ToInt16(Split[0]);
                    short? Max = Convert.ToInt16(Split[1]);

                    if (Min > Max)
                        L.Obj.Swap(ref Min, ref Max);

                    if (this.Operation.OperatorStr == "<>")
                        return this.Accessor.ExpressionWithout<T, short?>(Min, Max);
                    if (this.Operation.OperatorStr == "><")
                        return this.Accessor.ExpressionWithin<T, short?>(Min, Max);
                    }
                else
                    {
                    string[] Split = this.Operation.Search.Split(" ");

                    short Min = Convert.ToInt16(Split[0]);
                    short Max = Convert.ToInt16(Split[1]);

                    if (Min > Max)
                        L.Obj.Swap(ref Min, ref Max);

                    if (this.Operation.OperatorStr == "<>")
                        return this.Accessor.ExpressionWithout<T, short>(Min, Max);
                    if (this.Operation.OperatorStr == "><")
                        return this.Accessor.ExpressionWithin<T, short>(Min, Max);
                    }
                }
            else
                {
                short SearchShort = Convert.ToInt16(this.Operation.Search);

                this.Accessor.GetOperatorExpression<T>(this.Operation.Operator, SearchShort);
                }
            return null;
            }
        /// <exception cref="OverflowException">
        ///         <paramref>
        ///             <name>value</name>
        ///         </paramref>
        ///     represents a number that is less than <see cref="F:System.Int32.MinValue" /> or greater than <see cref="F:System.Int32.MaxValue" />. </exception>
        protected override Expression<Func<T, bool>> PerformAction_UShort()
            {
            if (this.Operation.OperatorStr == "<>" || this.Operation.OperatorStr == "><")
                {
                bool Nullable = this.Meta.ModelType == typeof(ushort?);

                if (Nullable)
                    {
                    string[] Split = this.Operation.Search.Split(" ");

                    ushort? Min = Convert.ToUInt16(Split[0]);
                    ushort? Max = Convert.ToUInt16(Split[1]);

                    if (Min > Max)
                        L.Obj.Swap(ref Min, ref Max);

                    if (this.Operation.OperatorStr == "<>")
                        return this.Accessor.ExpressionWithout<T, ushort?>(Min, Max);
                    if (this.Operation.OperatorStr == "><")
                        return this.Accessor.ExpressionWithin<T, ushort?>(Min, Max);
                    }
                else
                    {
                    string[] Split = this.Operation.Search.Split(" ");

                    ushort Min = Convert.ToUInt16(Split[0]);
                    ushort Max = Convert.ToUInt16(Split[1]);

                    if (Min > Max)
                        L.Obj.Swap(ref Min, ref Max);

                    if (this.Operation.OperatorStr == "<>")
                        return this.Accessor.ExpressionWithout<T, ushort>(Min, Max);
                    if (this.Operation.OperatorStr == "><")
                        return this.Accessor.ExpressionWithin<T, ushort>(Min, Max);
                    }
                }
            else
                {
                ushort SearchUShort = Convert.ToUInt16(this.Operation.Search);

                return this.Accessor.GetOperatorExpression<T>(this.Operation.Operator, SearchUShort);
                }
            return null;
            }
        /// <exception cref="OverflowException">
        ///         <paramref>
        ///             <name>value</name>
        ///         </paramref>
        ///     represents a number that is less than <see cref="F:System.Int32.MinValue" /> or greater than <see cref="F:System.Int32.MaxValue" />. </exception>
        protected override Expression<Func<T, bool>> PerformAction_Decimal()
            {
            if (this.Operation.OperatorStr == "<>" || this.Operation.OperatorStr == "><")
                {
                bool Nullable = this.Meta.ModelType == typeof(decimal?);

                if (Nullable)
                    {
                    string[] Split = this.Operation.Search.Split(" ");

                    decimal? Min = Convert.ToDecimal(Split[0]);
                    decimal? Max = Convert.ToDecimal(Split[1]);

                    if (Min > Max)
                        L.Obj.Swap(ref Min, ref Max);

                    if (this.Operation.OperatorStr == "<>")
                        return this.Accessor.ExpressionWithout<T, decimal?>(Min, Max);
                    if (this.Operation.OperatorStr == "><")
                        return this.Accessor.ExpressionWithin<T, decimal?>(Min, Max);
                    }
                else
                    {
                    string[] Split = this.Operation.Search.Split(" ");

                    decimal Min = Convert.ToDecimal(Split[0]);
                    decimal Max = Convert.ToDecimal(Split[1]);

                    if (Min > Max)
                        L.Obj.Swap(ref Min, ref Max);

                    if (this.Operation.OperatorStr == "<>")
                        return this.Accessor.ExpressionWithout<T, decimal>(Min, Max);
                    if (this.Operation.OperatorStr == "><")
                        return this.Accessor.ExpressionWithin<T, decimal>(Min, Max);
                    }
                }
            else
                {
                decimal SearchDecimal = Convert.ToDecimal(this.Operation.Search);

                return this.Accessor.GetOperatorExpression<T>(this.Operation.Operator, SearchDecimal);
                }
            return null;
            }
        /// <exception cref="OverflowException">
        ///         <paramref>
        ///             <name>value</name>
        ///         </paramref>
        ///     represents a number that is less than <see cref="F:System.Int32.MinValue" /> or greater than <see cref="F:System.Int32.MaxValue" />. </exception>
        protected override Expression<Func<T, bool>> PerformAction_Double()
            {
            if (this.Operation.OperatorStr == "<>" || this.Operation.OperatorStr == "><")
                {
                bool Nullable = this.Meta.ModelType == typeof(double?);

                if (Nullable)
                    {
                    string[] Split = this.Operation.Search.Split(" ");

                    double? Min = Convert.ToDouble(Split[0]);
                    double? Max = Convert.ToDouble(Split[1]);

                    if (Min > Max)
                        L.Obj.Swap(ref Min, ref Max);

                    if (this.Operation.OperatorStr == "<>")
                        return this.Accessor.ExpressionWithout<T, double?>(Min, Max);
                    if (this.Operation.OperatorStr == "><")
                        return this.Accessor.ExpressionWithin<T, double?>(Min, Max);
                    }
                else
                    {
                    string[] Split = this.Operation.Search.Split(" ");

                    double Min = Convert.ToDouble(Split[0]);
                    double Max = Convert.ToDouble(Split[1]);

                    if (Min > Max)
                        L.Obj.Swap(ref Min, ref Max);

                    if (this.Operation.OperatorStr == "<>")
                        return this.Accessor.ExpressionWithout<T, double>(Min, Max);
                    if (this.Operation.OperatorStr == "><")
                        return this.Accessor.ExpressionWithin<T, double>(Min, Max);
                    }
                }
            else
                {
                double SearchDouble = Convert.ToDouble(this.Operation.Search);

                return this.Accessor.GetOperatorExpression<T>(this.Operation.Operator, SearchDouble);
                }
            return null;
            }
        /// <exception cref="OverflowException">
        ///         <paramref>
        ///             <name>value</name>
        ///         </paramref>
        ///     represents a number that is less than <see cref="F:System.Int32.MinValue" /> or greater than <see cref="F:System.Int32.MaxValue" />. </exception>
        protected override Expression<Func<T, bool>> PerformAction_Float()
            {
            if (this.Operation.OperatorStr == "<>" || this.Operation.OperatorStr == "><")
                {
                bool Nullable = this.Meta.ModelType == typeof(float?);

                if (Nullable)
                    {
                    string[] Split = this.Operation.Search.Split(" ");

                    float? Min = Convert.ToSingle(Split[0]);
                    float? Max = Convert.ToSingle(Split[1]);

                    if (Min > Max)
                        L.Obj.Swap(ref Min, ref Max);

                    if (this.Operation.OperatorStr == "<>")
                        return this.Accessor.ExpressionWithout<T, float?>(Min, Max);
                    if (this.Operation.OperatorStr == "><")
                        return this.Accessor.ExpressionWithin<T, float?>(Min, Max);
                    }
                else
                    {
                    string[] Split = this.Operation.Search.Split(" ");

                    float Min = Convert.ToSingle(Split[0]);
                    float Max = Convert.ToSingle(Split[1]);

                    if (Min > Max)
                        L.Obj.Swap(ref Min, ref Max);

                    if (this.Operation.OperatorStr == "<>")
                        return this.Accessor.ExpressionWithout<T, float>(Min, Max);
                    if (this.Operation.OperatorStr == "><")
                        return this.Accessor.ExpressionWithin<T, float>(Min, Max);
                    }
                }
            else
                {
                float SearchFloat = Convert.ToSingle(this.Operation.Search);

                return this.Accessor.GetOperatorExpression<T>(this.Operation.Operator, SearchFloat);
                }
            return null;
            }

        /// <exception cref="ApplicationException">Used * characters more than 2 times</exception>
        protected override Expression<Func<T, bool>> PerformAction_String()
            {
            if (this.Operation.OperatorStr == "~")
                {
                return
                    ((Expression<Func<T, string>>)this.Accessor)
                    .WhereFilter($"*{this.Operation.Search.RemoveAll("*")}*", this.Operation.Property);
                }
            return this.Accessor.GetOperatorExpression<T>(this.Operation.Operator, this.Operation.Search);
            }

        /// <exception cref="OverflowException">
        ///         <paramref>
        ///             <name>value</name>
        ///         </paramref>
        ///     represents a number that is less than <see cref="F:System.Int32.MinValue" /> or greater than <see cref="F:System.Int32.MaxValue" />. </exception>
        protected override Expression<Func<T, bool>> PerformAction_Enum(Type EnumType)
            {
            if (this.Operation.OperatorStr == "~")
                {
                var Type = this.Meta.ModelType;
                if (this.Meta.ModelType.IsGenericType && this.Meta.ModelType.GetGenericArguments()[0].IsEnum)
                    {
                    Type = this.Meta.ModelType.GetGenericArguments()[0];
                    }

                string[] Names = Type.GetEnumNames();
                object[] Values = Type.GetEnumValues().Array<object>();

                int?[] ValueInts = Values.Convert(Value => (int?)Convert.ChangeType(Value, ((Enum)Value).GetTypeCode()));


                var SelectedValues = new List<object>();

                for (int Index = 0; Index < Names.Length; Index++)
                    {
                    if (Names[Index].ToLower().Contains(this.Operation.Search.ToLower()))
                        SelectedValues.Add(ValueInts[Index]);
                    }

                List<Expression<Func<T, bool>>> Ors = SelectedValues.Convert(
                    Value => (Expression<Func<T, bool>>)
                    Expression.Lambda(
                        Expression.Equal(
                            Expression.Convert(this.Accessor.Body, typeof(int?)),
                            Expression.Convert(Expression.Constant(Value), typeof(int?))), this.Accessor.Parameters[0]));

                Expression CombinedOrs = Ors.Or();

                return
                    (Expression<Func<T, bool>>)Expression.Lambda(
                    Expression.Equal(
                        Expression.Convert(this.Accessor.Body, typeof(int?)),
                        CombinedOrs), this.Accessor.Parameters[0]);
                /*
                Expression.Enum
                return 
                    QueryExt.WhereFilter<T>(
                    (Expression<Func<T, String>>)Accessor,
                    $"*{this.Operation.Search.RemoveAll("*")}*",
                    Operation.Property));
                    */
                }
            return this.Accessor.GetOperatorExpression<T>(this.Operation.Operator, this.Operation.Search);
            }

        /// <exception cref="OverflowException">
        ///         <paramref>
        ///             <name>value</name>
        ///         </paramref>
        ///     represents a number that is less than <see cref="F:System.Int32.MinValue" /> or greater than <see cref="F:System.Int32.MaxValue" />. </exception>
        protected override Expression<Func<T, bool>> PerformAction_TimeSpan()
            {
            var SearchTime = TimeSpan.Parse(this.Operation.Search);

            return this.Accessor.GetOperatorExpression<T>(this.Operation.Operator, SearchTime);
            }
        protected override Expression<Func<T, bool>> PerformAction_DateTime()
            {
            if (this.Operation.OperatorStr == "<>" || this.Operation.OperatorStr == "><")
                {
                bool Nullable = this.Meta.ModelType == typeof(DateTime?);

                if (Nullable)
                    {
                    string[] Split = this.Operation.Search.Split(" ");

                    DateTime? Min = Convert.ToDateTime(Split[0]);
                    DateTime? Max = Convert.ToDateTime(Split[1]);

                    if (((DateTime)Min).Ticks > ((DateTime)Max).Ticks)
                        L.Obj.Swap(ref Min, ref Max);

                    if (this.Operation.OperatorStr == "<>")
                        return this.Accessor.ExpressionWithout<T, DateTime?>(Min, Max);
                    if (this.Operation.OperatorStr == "><")
                        return this.Accessor.ExpressionWithin<T, DateTime?>(Min, Max);
                    }
                else
                    {
                    string[] Split = this.Operation.Search.Split(" ");

                    var Min = Convert.ToDateTime(Split[0]);
                    var Max = Convert.ToDateTime(Split[1]);

                    if (Min.Ticks > Max.Ticks)
                        L.Obj.Swap(ref Min, ref Max);

                    if (this.Operation.OperatorStr == "<>")
                        return this.Accessor.ExpressionWithout<T, DateTime>(Min, Max);
                    if (this.Operation.OperatorStr == "><")
                        return this.Accessor.ExpressionWithin<T, DateTime>(Min, Max);
                    }
                }
            else
                {
                var SearchDate = Convert.ToDateTime(this.Operation.Search);

                return this.Accessor.GetOperatorExpression<T>(this.Operation.Operator, SearchDate);
                }
            return null;
            }

        
        protected override Expression<Func<T, bool>> PerformAction_IModel(Type Type)
            {
            /*
            if (Operation.OperatorStr == "~")
                {
             */
            return QueryExt.GlobalSearchRecursive<T>(this.Operation.Search);
            /*
                }
            else
                {
                return Accessor.GetOperatorExpression<T>(Operation.Operator, Operation.Search);
                }
             */
            }


        /// <exception cref="ArgumentException">Type not supported.</exception>
        protected override Expression<Func<T, bool>> PerformAction_Object(Type Type)
            {
            if (Type.PreferGeneric().HasInterface<IModel>())
                {
                // Covers one-to-many fields
                return null;
                }

            throw new ArgumentException($"Type not supported: {Type.Name}");
            }
        }
    }
