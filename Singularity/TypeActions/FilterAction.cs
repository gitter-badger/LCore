using LCore;
using Singularity.Extensions;
using Singularity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Singularity.Utilities
    {
    public class FilterExpression<T> : TypeAction<Expression<Func<T, Boolean>>>
        {
        SearchOperation Operation { get; set; }
        LambdaExpression Accessor { get; set; }
        ModelMetadata Meta { get; set; }

        public FilterExpression(SearchOperation Operation, LambdaExpression Accessor, ModelMetadata Meta)
            {
            this.Operation = Operation;
            this.Accessor = Accessor;
            this.Meta = Meta;
            }

        protected override Expression<Func<T, Boolean>> PerformAction_Boolean()
            {
            String SearchLower = Operation.Search.ToLower();

            if (SearchLower == "y" || SearchLower == "yes" || SearchLower == "true")
                return Accessor.GetOperatorExpression<T>(Operation.Operator, true);
            else if (SearchLower == "n" || SearchLower == "no" || SearchLower == "false")
                return Accessor.GetOperatorExpression<T>(Operation.Operator, false);
            else
                throw new Exception("Invalid value: " + SearchLower);
            }

        protected override Expression<Func<T, Boolean>> PerformAction_Int()
            {
            if (Operation.OperatorStr == "<>" ||
                Operation.OperatorStr == "><")
                {
                Boolean Nullable = Meta.ModelType == typeof(int?);

                if (Nullable)
                    {
                    String[] Split = Operation.Search.Split(" ");

                    int? Min = Convert.ToInt32(Split[0]);
                    int? Max = Convert.ToInt32(Split[1]);

                    if (Min > Max)
                        ObjectExt.Swap(ref Min, ref Max);

                    if (Operation.OperatorStr == "<>")
                        return Accessor.ExpressionWithout<T, int?>(Min, Max);
                    else if (Operation.OperatorStr == "><")
                        return Accessor.ExpressionWithin<T, int?>(Min, Max);
                    }
                else
                    {
                    String[] Split = Operation.Search.Split(" ");

                    int Min = Convert.ToInt32(Split[0]);
                    int Max = Convert.ToInt32(Split[1]);

                    if (Min > Max)
                        ObjectExt.Swap(ref Min, ref Max);

                    if (Operation.OperatorStr == "<>")
                        return Accessor.ExpressionWithout<T, int>(Min, Max);
                    else if (Operation.OperatorStr == "><")
                        return Accessor.ExpressionWithin<T, int>(Min, Max);
                    }
                }
            else
                {
                int SearchInt;

                if (Int32.TryParse(Operation.Search, out SearchInt))
                    {
                    return Accessor.GetOperatorExpression<T>(Operation.Operator, SearchInt);
                    }
                }
            return null;
            }
        protected override Expression<Func<T, Boolean>> PerformAction_UInt()
            {
            if (Operation.OperatorStr == "<>" ||
                Operation.OperatorStr == "><")
                {
                Boolean Nullable = Meta.ModelType == typeof(uint?);

                if (Nullable)
                    {
                    String[] Split = Operation.Search.Split(" ");

                    uint? Min = Convert.ToUInt32(Split[0]);
                    uint? Max = Convert.ToUInt32(Split[1]);

                    if (Min > Max)
                        ObjectExt.Swap(ref Min, ref Max);

                    if (Operation.OperatorStr == "<>")
                        return Accessor.ExpressionWithout<T, uint?>(Min, Max);
                    else if (Operation.OperatorStr == "><")
                        return Accessor.ExpressionWithin<T, uint?>(Min, Max);
                    }
                else
                    {
                    String[] Split = Operation.Search.Split(" ");

                    uint Min = Convert.ToUInt32(Split[0]);
                    uint Max = Convert.ToUInt32(Split[1]);

                    if (Min > Max)
                        ObjectExt.Swap(ref Min, ref Max);

                    if (Operation.OperatorStr == "<>")
                        return Accessor.ExpressionWithout<T, uint>(Min, Max);
                    else if (Operation.OperatorStr == "><")
                        return Accessor.ExpressionWithin<T, uint>(Min, Max);
                    }
                }
            else
                {
                uint SearchUInt = Convert.ToUInt32(Operation.Search);

                return Accessor.GetOperatorExpression<T>(Operation.Operator, SearchUInt);
                }
            return null;
            }
        protected override Expression<Func<T, Boolean>> PerformAction_Long()
            {
            if (Operation.OperatorStr == "<>" ||
                Operation.OperatorStr == "><")
                {
                Boolean Nullable = Meta.ModelType == typeof(long?);

                if (Nullable)
                    {
                    String[] Split = Operation.Search.Split(" ");

                    long? Min = Convert.ToInt64(Split[0]);
                    long? Max = Convert.ToInt64(Split[1]);

                    if (Min > Max)
                        ObjectExt.Swap(ref Min, ref Max);

                    if (Operation.OperatorStr == "<>")
                        return Accessor.ExpressionWithout<T, long?>(Min, Max);
                    else if (Operation.OperatorStr == "><")
                        return Accessor.ExpressionWithin<T, long?>(Min, Max);
                    }
                else
                    {
                    String[] Split = Operation.Search.Split(" ");

                    long Min = Convert.ToInt64(Split[0]);
                    long Max = Convert.ToInt64(Split[1]);

                    if (Min > Max)
                        ObjectExt.Swap(ref Min, ref Max);

                    if (Operation.OperatorStr == "<>")
                        return Accessor.ExpressionWithout<T, long>(Min, Max);
                    else if (Operation.OperatorStr == "><")
                        return Accessor.ExpressionWithin<T, long>(Min, Max);
                    }
                }
            else
                {
                long SearchLong = Convert.ToInt64(Operation.Search);

                return Accessor.GetOperatorExpression<T>(Operation.Operator, SearchLong);
                }
            return null;
            }
        protected override Expression<Func<T, Boolean>> PerformAction_ULong()
            {
            if (Operation.OperatorStr == "<>" ||
                Operation.OperatorStr == "><")
                {
                Boolean Nullable = Meta.ModelType == typeof(ulong?);

                if (Nullable)
                    {
                    String[] Split = Operation.Search.Split(" ");

                    ulong? Min = Convert.ToUInt64(Split[0]);
                    ulong? Max = Convert.ToUInt64(Split[1]);

                    if (Min > Max)
                        ObjectExt.Swap(ref Min, ref Max);

                    if (Operation.OperatorStr == "<>")
                        return Accessor.ExpressionWithout<T, ulong?>(Min, Max);
                    else if (Operation.OperatorStr == "><")
                        return Accessor.ExpressionWithin<T, ulong?>(Min, Max);
                    }
                else
                    {
                    String[] Split = Operation.Search.Split(" ");

                    ulong Min = Convert.ToUInt64(Split[0]);
                    ulong Max = Convert.ToUInt64(Split[1]);

                    if (Min > Max)
                        ObjectExt.Swap(ref Min, ref Max);

                    if (Operation.OperatorStr == "<>")
                        return Accessor.ExpressionWithout<T, ulong>(Min, Max);
                    else if (Operation.OperatorStr == "><")
                        return Accessor.ExpressionWithin<T, ulong>(Min, Max);
                    }

                }
            else
                {
                ulong SearchULong = Convert.ToUInt64(Operation.Search);

                return Accessor.GetOperatorExpression<T>(Operation.Operator, SearchULong);
                }
            return null;
            }
        protected override Expression<Func<T, Boolean>> PerformAction_Short()
            {
            if (Operation.OperatorStr == "<>" ||
                Operation.OperatorStr == "><")
                {
                Boolean Nullable = Meta.ModelType == typeof(short?);

                if (Nullable)
                    {
                    String[] Split = Operation.Search.Split(" ");

                    short? Min = Convert.ToInt16(Split[0]);
                    short? Max = Convert.ToInt16(Split[1]);

                    if (Min > Max)
                        ObjectExt.Swap(ref Min, ref Max);

                    if (Operation.OperatorStr == "<>")
                        return Accessor.ExpressionWithout<T, short?>(Min, Max);
                    else if (Operation.OperatorStr == "><")
                        return Accessor.ExpressionWithin<T, short?>(Min, Max);
                    }
                else
                    {
                    String[] Split = Operation.Search.Split(" ");

                    short Min = Convert.ToInt16(Split[0]);
                    short Max = Convert.ToInt16(Split[1]);

                    if (Min > Max)
                        ObjectExt.Swap(ref Min, ref Max);

                    if (Operation.OperatorStr == "<>")
                        return Accessor.ExpressionWithout<T, short>(Min, Max);
                    else if (Operation.OperatorStr == "><")
                        return Accessor.ExpressionWithin<T, short>(Min, Max);

                    }
                }
            else
                {
                short SearchShort = Convert.ToInt16(Operation.Search);

                Accessor.GetOperatorExpression<T>(Operation.Operator, SearchShort);
                }
            return null;
            }
        protected override Expression<Func<T, Boolean>> PerformAction_UShort()
            {
            if (Operation.OperatorStr == "<>" ||
                Operation.OperatorStr == "><")
                {
                Boolean Nullable = Meta.ModelType == typeof(ushort?);

                if (Nullable)
                    {
                    String[] Split = Operation.Search.Split(" ");

                    ushort? Min = Convert.ToUInt16(Split[0]);
                    ushort? Max = Convert.ToUInt16(Split[1]);

                    if (Min > Max)
                        ObjectExt.Swap(ref Min, ref Max);

                    if (Operation.OperatorStr == "<>")
                        return Accessor.ExpressionWithout<T, ushort?>(Min, Max);
                    else if (Operation.OperatorStr == "><")
                        return Accessor.ExpressionWithin<T, ushort?>(Min, Max);
                    }
                else
                    {
                    String[] Split = Operation.Search.Split(" ");

                    ushort Min = Convert.ToUInt16(Split[0]);
                    ushort Max = Convert.ToUInt16(Split[1]);

                    if (Min > Max)
                        ObjectExt.Swap(ref Min, ref Max);

                    if (Operation.OperatorStr == "<>")
                        return Accessor.ExpressionWithout<T, ushort>(Min, Max);
                    else if (Operation.OperatorStr == "><")
                        return Accessor.ExpressionWithin<T, ushort>(Min, Max);
                    }
                }
            else
                {
                ushort SearchUShort = Convert.ToUInt16(Operation.Search);

                return Accessor.GetOperatorExpression<T>(Operation.Operator, SearchUShort);
                }
            return null;
            }
        protected override Expression<Func<T, Boolean>> PerformAction_Decimal()
            {
            if (Operation.OperatorStr == "<>" ||
                Operation.OperatorStr == "><")
                {
                Boolean Nullable = Meta.ModelType == typeof(decimal?);

                if (Nullable)
                    {
                    String[] Split = Operation.Search.Split(" ");

                    decimal? Min = Convert.ToDecimal(Split[0]);
                    decimal? Max = Convert.ToDecimal(Split[1]);

                    if (Min > Max)
                        ObjectExt.Swap(ref Min, ref Max);

                    if (Operation.OperatorStr == "<>")
                        return Accessor.ExpressionWithout<T, decimal?>(Min, Max);
                    else if (Operation.OperatorStr == "><")
                        return Accessor.ExpressionWithin<T, decimal?>(Min, Max);
                    }
                else
                    {
                    String[] Split = Operation.Search.Split(" ");

                    decimal Min = Convert.ToDecimal(Split[0]);
                    decimal Max = Convert.ToDecimal(Split[1]);

                    if (Min > Max)
                        ObjectExt.Swap(ref Min, ref Max);

                    if (Operation.OperatorStr == "<>")
                        return Accessor.ExpressionWithout<T, decimal>(Min, Max);
                    else if (Operation.OperatorStr == "><")
                        return Accessor.ExpressionWithin<T, decimal>(Min, Max);
                    }
                }
            else
                {
                decimal SearchDecimal = Convert.ToDecimal(Operation.Search);

                return Accessor.GetOperatorExpression<T>(Operation.Operator, SearchDecimal);
                }
            return null;
            }
        protected override Expression<Func<T, Boolean>> PerformAction_Double()
            {
            if (Operation.OperatorStr == "<>" ||
                Operation.OperatorStr == "><")
                {
                Boolean Nullable = Meta.ModelType == typeof(double?);

                if (Nullable)
                    {
                    String[] Split = Operation.Search.Split(" ");

                    double? Min = Convert.ToDouble(Split[0]);
                    double? Max = Convert.ToDouble(Split[1]);

                    if (Min > Max)
                        ObjectExt.Swap(ref Min, ref Max);

                    if (Operation.OperatorStr == "<>")
                        return Accessor.ExpressionWithout<T, double?>(Min, Max);
                    else if (Operation.OperatorStr == "><")
                        return Accessor.ExpressionWithin<T, double?>(Min, Max);
                    }
                else
                    {
                    String[] Split = Operation.Search.Split(" ");

                    double Min = Convert.ToDouble(Split[0]);
                    double Max = Convert.ToDouble(Split[1]);

                    if (Min > Max)
                        ObjectExt.Swap(ref Min, ref Max);

                    if (Operation.OperatorStr == "<>")
                        return Accessor.ExpressionWithout<T, double>(Min, Max);
                    else if (Operation.OperatorStr == "><")
                        return Accessor.ExpressionWithin<T, double>(Min, Max);
                    }
                }
            else
                {
                double SearchDouble = Convert.ToDouble(Operation.Search);

                return Accessor.GetOperatorExpression<T>(Operation.Operator, SearchDouble);
                }
            return null;
            }
        protected override Expression<Func<T, Boolean>> PerformAction_Float()
            {
            if (Operation.OperatorStr == "<>" ||
                Operation.OperatorStr == "><")
                {
                Boolean Nullable = Meta.ModelType == typeof(float?);

                if (Nullable)
                    {
                    String[] Split = Operation.Search.Split(" ");

                    float? Min = Convert.ToSingle(Split[0]);
                    float? Max = Convert.ToSingle(Split[1]);

                    if (Min > Max)
                        ObjectExt.Swap(ref Min, ref Max);

                    if (Operation.OperatorStr == "<>")
                        return Accessor.ExpressionWithout<T, float?>(Min, Max);
                    else if (Operation.OperatorStr == "><")
                        return Accessor.ExpressionWithin<T, float?>(Min, Max);
                    }
                else
                    {
                    String[] Split = Operation.Search.Split(" ");

                    float Min = Convert.ToSingle(Split[0]);
                    float Max = Convert.ToSingle(Split[1]);

                    if (Min > Max)
                        ObjectExt.Swap(ref Min, ref Max);

                    if (Operation.OperatorStr == "<>")
                        return Accessor.ExpressionWithout<T, float>(Min, Max);
                    else if (Operation.OperatorStr == "><")
                        return Accessor.ExpressionWithin<T, float>(Min, Max);
                    }
                }
            else
                {
                float SearchFloat = Convert.ToSingle(Operation.Search);

                return Accessor.GetOperatorExpression<T>(Operation.Operator, SearchFloat);
                }
            return null;
            }

        protected override Expression<Func<T, Boolean>> PerformAction_String()
            {
            if (Operation.OperatorStr == "~")
                {
                return
                    QueryExt.WhereFilter<T>(
                    (Expression<Func<T, String>>)Accessor,
                    "*" + Operation.Search.RemoveAll("*") + "*",
                    Operation.Property);
                }
            else
                {
                return Accessor.GetOperatorExpression<T>(Operation.Operator, Operation.Search);
                }
            }
        protected override Expression<Func<T, Boolean>> PerformAction_Enum(Type EmumType)
            {
            if (Operation.OperatorStr == "~")
                {
                Type t = Meta.ModelType;
                if (Meta.ModelType.IsGenericType && Meta.ModelType.GetGenericArguments()[0].IsEnum)
                    {
                    t = Meta.ModelType.GetGenericArguments()[0];
                    }

                String[] Names = t.GetEnumNames();
                Object[] Values = t.GetEnumValues().Array<Object>();

                int?[] ValueInts = Values.Convert<Object, int?>((o) =>
                {
                    return (int?)Convert.ChangeType(o, ((Enum)o).GetTypeCode());
                });


                List<Object> SelectedValues = new List<Object>();

                for (int i = 0; i < Names.Length; i++)
                    {
                    if (Names[i].ToLower().Contains(Operation.Search.ToLower()))
                        SelectedValues.Add(ValueInts[i]);
                    }

                List<Expression<Func<T, Boolean>>> Ors = SelectedValues.Convert((o) =>
                {
                    return (Expression<Func<T, Boolean>>)
                        Expression.Lambda(
                            Expression.Equal(
                                Expression.Convert(Accessor.Body, typeof(int?)),
                                Expression.Convert(Expression.Constant(o), typeof(int?))),
                            Accessor.Parameters[0]);
                });

                Expression CombinedOrs = Ors.Or();

                return
                    (Expression<Func<T, Boolean>>)Expression.Lambda(
                    Expression.Equal(
                        Expression.Convert(Accessor.Body, typeof(int?)),
                        CombinedOrs),
                    Accessor.Parameters[0]);

                /*
                Expression.Enum
                return 
                    QueryExt.WhereFilter<T>(
                    (Expression<Func<T, String>>)Accessor,
                    "*" + Operation.Search.RemoveAll("*") + "*",
                    Operation.Property));
                 */
                }
            else
                {
                return Accessor.GetOperatorExpression<T>(Operation.Operator, Operation.Search);
                }
            }
        protected override Expression<Func<T, Boolean>> PerformAction_TimeSpan()
            {
            TimeSpan SearchTime = TimeSpan.Parse(Operation.Search);

            return Accessor.GetOperatorExpression<T>(Operation.Operator, SearchTime);
            }
        protected override Expression<Func<T, Boolean>> PerformAction_DateTime()
            {
            if (Operation.OperatorStr == "<>" ||
                Operation.OperatorStr == "><")
                {
                Boolean Nullable = Meta.ModelType == typeof(DateTime?);

                if (Nullable)
                    {
                    String[] Split = Operation.Search.Split(" ");

                    DateTime? Min = Convert.ToDateTime(Split[0]);
                    DateTime? Max = Convert.ToDateTime(Split[1]);

                    if (((DateTime)Min).Ticks > ((DateTime)Max).Ticks)
                        ObjectExt.Swap(ref Min, ref Max);

                    if (Operation.OperatorStr == "<>")
                        return Accessor.ExpressionWithout<T, DateTime?>(Min, Max);
                    else if (Operation.OperatorStr == "><")
                        return Accessor.ExpressionWithin<T, DateTime?>(Min, Max);
                    }
                else
                    {
                    String[] Split = Operation.Search.Split(" ");

                    DateTime Min = Convert.ToDateTime(Split[0]);
                    DateTime Max = Convert.ToDateTime(Split[1]);

                    if (Min.Ticks > Max.Ticks)
                        ObjectExt.Swap(ref Min, ref Max);

                    if (Operation.OperatorStr == "<>")
                        return Accessor.ExpressionWithout<T, DateTime>(Min, Max);
                    else if (Operation.OperatorStr == "><")
                        return Accessor.ExpressionWithin<T, DateTime>(Min, Max);
                    }
                }
            else
                {
                DateTime SearchDate = Convert.ToDateTime(Operation.Search);

                return Accessor.GetOperatorExpression<T>(Operation.Operator, SearchDate);
                }
            return null;
            }

        protected override Expression<Func<T, Boolean>> PerformAction_IModel(Type t)
            {
            /*
            if (Operation.OperatorStr == "~")
                {
             */
            return QueryExt.GlobalSearchRecursive<T>(Operation.Search);
            /*
                }
            else
                {
                return Accessor.GetOperatorExpression<T>(Operation.Operator, Operation.Search);
                }
             */
            }

        protected override Expression<Func<T, Boolean>> PerformAction_Object(Type t)
            {
            if (t.PreferGeneric().HasInterface<IModel>())
                {
                // Covers one-to-many fields
                return null;
                }

            throw new Exception("Type not supported: " + t.Name);
            }
        }
    }
