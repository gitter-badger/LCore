using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using LCore.Extensions;
using System.Collections;
using System.Data.Entity;
using System.Reflection;
using Singularity.Controllers;
using System.Web.Mvc;
using LCore.Interfaces;
using Singularity.Models;
using Singularity.Utilities;
using Singularity.Annotations;

namespace Singularity.Extensions
    {
    [ExtensionProvider]
    public static class QueryExt
        {
        public static readonly Dictionary<string, Func<Expression, Expression, Expression>> BinaryOps = new Dictionary<string, Func<Expression, Expression, Expression>>
            {
                {"~", null}, // LIKE, custom Expression
                {"><", null}, // WITHIN, custom expression
                {"<>", null}, // WITHOUT, custom expression
                {">=", Expression.GreaterThanOrEqual},
                {"<=", Expression.LessThanOrEqual},
                {">",  Expression.GreaterThan},
                {"<", Expression.LessThan},
                {"!=", Expression.NotEqual},
                {"!", Expression.NotEqual},
                {"==", Expression.Equal},
                {"=", Expression.Equal},
                {":", Expression.Equal}
            };

        public static IQueryable<T> IsNull<T>(this IQueryable<T> Source, string Column)
            {
            // Use source type instead of T which can be [Object]
            var Type = Source.ElementType;

            var Param = Expression.Parameter(Type, string.Empty);
            var Member = Expression.PropertyOrField(Param, Column);

            // Non-nullable value types can't contain nulls. No results will be returned.
            if (Member.Type.IsValueType && !Member.Type.IsNullable())
                return Source.Where((Expression<Func<T, bool>>)Expression.Lambda(Expression.Constant(false), Param));

            var Property = Expression.Equal(Member, Expression.Constant(null));
            var Condition = Expression.Lambda(Property, Param);

            return Source.Where((Expression<Func<T, bool>>)Condition);
            }

        public static IQueryable<T> IsNotNull<T>(this IQueryable<T> Source, string Column)
            {
            // Use source type instead of T which can be [Object]
            var Type = Source.ElementType;

            var Param = Expression.Parameter(Type, string.Empty);
            var Member = Expression.PropertyOrField(Param, Column);

            // Non-nullable value types can't contain nulls. Nothing can be filtered.
            if (Member.Type.IsValueType && !Member.Type.IsNullable())
                return Source;

            var Property = Expression.NotEqual(Member, Expression.Constant(null));
            var Condition = Expression.Lambda(Property, Param);

            return Source.Where((Expression<Func<T, bool>>)Condition);
            }

        public static Expression<Func<T, bool>> Or<T>(this IEnumerable<Expression<Func<T, bool>>> Expressions)
            {
            Expression<Func<T, bool>> Out = null;

            foreach (Expression<Func<T, bool>> Exp in Expressions)
                {
                if (Out == null)
                    {
                    Out = Exp;
                    }
                else if (Exp != null)
                    {
                    Out = Expression.Lambda<Func<T, bool>>(
                        Expression.OrElse(
                            Out.Body,
                            new ExpressionParameterReplacer(Exp.Parameters, Out.Parameters).Visit(Exp.Body)),
                        Out.Parameters);
                    }
                }

            if (Out != null)
                {
                if (Out.CanReduce)
                    Out.Reduce();
                }

            return Out;
            }

        public static Expression<Func<T, bool>> And<T>(this IEnumerable<Expression<Func<T, bool>>> Expressions)
            {
            Expression<Func<T, bool>> Out = null;

            foreach (Expression<Func<T, bool>> Exp in Expressions)
                {
                if (Out == null)
                    {
                    Out = Exp;
                    }
                else
                    {
                    Out = Expression.Lambda<Func<T, bool>>(
                        Expression.AndAlso(
                            Out.Body,
                            new ExpressionParameterReplacer(Exp.Parameters, Out.Parameters).Visit(Exp.Body)),
                        Out.Parameters);
                    }
                }

            if (Out?.CanReduce == true)
                Out.Reduce();

            return Out;
            }

        public static Expression<Func<T, bool>> GlobalSearchRecursive<T>(string GlobalSearch,
            string[] ParentProperties = null, Type[] ParentTypes = null)
            {
            ParentProperties = ParentProperties ?? new string[] { };
            ParentTypes = ParentTypes ?? new[] { typeof(T) };

            var SearchPartConditions = new List<Expression<Func<T, bool>>>();

            var Meta = ParentTypes.Last().Meta();

            string[] GlobalSearchParts = GlobalSearch.SplitWithQuotes(' ').Array();

            foreach (string GlobalSearchPart in GlobalSearchParts)
                {
                string GlobalSearchPartClean = GlobalSearchPart.RemoveAll("\"");

                var FieldConditions = new List<Expression<Func<T, bool>>>();

                foreach (var Prop in Meta.Properties)
                    {
                    if (Prop.HasAttribute<KeyAttribute>(true))
                        continue;

                    if (Prop.HasAttribute<NotMappedAttribute>(true))
                        continue;

                    if (!Prop.HasAttribute<FieldGlobalSearchAttribute>()
                        || Prop.HasAttribute<HideManageViewColumnAttribute>())
                        continue;

                    if (!Prop.ModelType.HasInterface<IConvertible>() &&
                        // Don't skip IModel types for not being IConvertible
                        !Prop.ModelType.HasInterface<IModel>())
                        continue;

                    if (Prop.AdditionalValues.ContainsKey(GlobalSearchDisabledAttribute.Key)
                        && Prop.AdditionalValues[GlobalSearchDisabledAttribute.Key] as bool? == true)
                        continue;

                    string[] Properties = ParentProperties.Add(Prop.PropertyName);

                    if (Prop.ModelType.HasInterface<IModel>())
                        {
                        Type[] Types = ParentTypes.Add(Prop.ModelType);

                        Expression<Func<T, bool>> SubFieldConditions = GlobalSearchRecursive<T>(
                            $"\"{GlobalSearchPartClean}\"", Properties, Types);

                        if (SubFieldConditions != null)
                            FieldConditions.Add(SubFieldConditions);
                        }
                    else
                        {
                        ModelMetadata Meta2;
                        string[] FullProperties;

                        var Accessor = ParentTypes[0].FindSubProperty(out Meta2, out FullProperties, Properties);

                        var Operation = new SearchOperation
                            {
                            Property = Prop.PropertyName,
                            OperatorStr = "~",
                            Operator = BinaryOps["~"],
                            Search = GlobalSearchPartClean
                            };

                        var Filter = new FilterExpression<T>(Operation, Accessor, Meta2);

                        Expression<Func<T, bool>> Expr = Filter.PerformAction(Meta2.ModelType);

                        if (Expr != null)
                            FieldConditions.Add(Expr);
                        }
                    }

                Expression<Func<T, bool>> FieldCondition = FieldConditions.Or();

                if (FieldCondition?.CanReduce == true)
                    FieldCondition = (Expression<Func<T, bool>>)FieldCondition.Reduce();

                SearchPartConditions.Add(FieldCondition);
                }

            if (SearchPartConditions.Count > 0)
                {
                Expression<Func<T, bool>> Out = SearchPartConditions.And();

                if (Out?.CanReduce == true)
                    Out.Reduce();

                return Out;
                }

            return null;
            }

        private static IOrderedQueryable<T> OrderingHelper<T>(IQueryable<T> Source, string PropertyName, bool Desc, bool AnotherLevel)
            {
            string PropertyName2 = "";
            if (PropertyName.Contains("."))
                {
                string[] Split = PropertyName.Split(".");

                PropertyName = Split[0];
                PropertyName2 = Split[1];
                }

            // Use source type instead of T which can be [Object]
            var Type = Source.ElementType;

            var PropertyType = Type.Meta(PropertyName).ModelType;

            if (PropertyType.HasInterface<IEnumerable>() &&
                PropertyType.IsGenericType &&
                PropertyType.GetGenericArguments()[0].HasInterface<IModel>())
                {
                // Sort ICollection<IModel> properties by Count

                var Param = Expression.Parameter(Type, string.Empty);
                var Property = Expression.PropertyOrField(Param, PropertyName);

                if (!string.IsNullOrEmpty(PropertyName2))
                    {
                    Property = Expression.PropertyOrField(Property, PropertyName2);
                    }

                var Property2 = Expression.PropertyOrField(Property, "Count");

                // Expression property2 = Expression.Call(property, property.Type.GetMethod("get_Count"));

                var Sort = Expression.Lambda(Property2, Param);

                var ConditionGreaterThanZero =
                    (Expression<Func<T, bool>>)Expression.Lambda(
                        Expression.GreaterThan(Property2, Expression.Constant(0)),
                        Param);

                Source = Source.Where(ConditionGreaterThanZero);

                var Call = Expression.Call(
                    typeof(Queryable),
                    (!AnotherLevel ? "OrderBy" : "ThenBy") + (Desc ? "Descending" : string.Empty),
                    new[] { Type, Property2.Type },
                    Source.Expression,
                    Expression.Quote(Sort));

                return (IOrderedQueryable<T>)Source.Provider.CreateQuery<T>(Call);
                }

            Source = Source.IsNotNull(PropertyName);

            var Parameter = Expression.Parameter(Type, string.Empty);
            var Property3 = Expression.PropertyOrField(Parameter, PropertyName);

            if (!string.IsNullOrEmpty(PropertyName2))
                {
                Property3 = Expression.PropertyOrField(Property3, PropertyName2);
                }

            var Sort2 = Expression.Lambda(Property3, Parameter);

            var Call2 = Expression.Call(
                typeof(Queryable),
                (!AnotherLevel ? "OrderBy" : "ThenBy") + (Desc ? "Descending" : string.Empty),
                new[] { Type, Property3.Type },
                Source.Expression,
                Expression.Quote(Sort2));
            return (IOrderedQueryable<T>)Source.Provider.CreateQuery<T>(Call2);
            }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> Source, string PropertyName)
            {
            return OrderingHelper(Source, PropertyName, false, false);
            }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> Source, string PropertyName)
            {
            return OrderingHelper(Source, PropertyName, true, false);
            }

        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> Source, string PropertyName)
            {
            return OrderingHelper(Source, PropertyName, false, true);
            }

        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> Source, string PropertyName)
            {
            return OrderingHelper(Source, PropertyName, true, true);
            }

        /// <exception cref="ApplicationException">Used * characters more than 2 times</exception>
        /// <exception cref="ApplicationException">Used ? character, it's not supported</exception>
        public static Expression<Func<T, bool>> WhereFilter<T>(this Expression<Func<T, string>> Selector, string Filter, string FieldName)
            {
            if (Filter == null)
                return null;

            if (Selector == null)
                return null;

            int AsterixCount = Filter.Count(Char => Char.Equals('*'));
            if (AsterixCount > 2)
                throw new ApplicationException(
                    $"Invalid filter used{(FieldName == null ? "" : $" for \'{FieldName}\'")}. '*' can maximum occur 2 times.");

            if (Filter.Contains("?"))
                throw new ApplicationException(
                    $"Invalid filter used{(FieldName == null ? "" : $" for \'{FieldName}\'")}. '?' is not supported, only '*' is supported.");

            // *XX*
            if (AsterixCount == 2 && Filter.Length > 2 && Filter.StartsWith("*") && Filter.EndsWith("*"))
                {
                Filter = Filter.Replace("*", "");
                return Expression.Lambda<Func<T, bool>>(
                        Expression.Call(Selector.Body, "Contains", null, Expression.Constant(Filter)),
                        Selector.Parameters[0]);
                }

            // *XX
            if (AsterixCount == 1 && Filter.Length > 1 && Filter.StartsWith("*"))
                {
                Filter = Filter.Replace("*", "");
                return Expression.Lambda<Func<T, bool>>(
                        Expression.Call(Selector.Body, "EndsWith", null, Expression.Constant(Filter)),
                        Selector.Parameters[0]
                    );
                }

            // XX*
            if (AsterixCount == 1 && Filter.Length > 1 && Filter.EndsWith("*"))
                {
                Filter = Filter.Replace("*", "");
                return Expression.Lambda<Func<T, bool>>(
                        Expression.Call(Selector.Body, "StartsWith", null, Expression.Constant(Filter)),
                        Selector.Parameters[0]
                    );
                }

            // X*X
            if (AsterixCount == 1 && Filter.Length > 2 && !Filter.StartsWith("*") && !Filter.EndsWith("*"))
                {
                string StartsWith = Filter.Substring(0, Filter.IndexOf('*'));
                string EndsWith = Filter.Substring(Filter.IndexOf('*') + 1);

                return
                    Expression.Lambda<Func<T, bool>>(
                    Expression.And(
                        Expression.Call(Selector.Body, "StartsWith", null, Expression.Constant(StartsWith)),
                        Expression.Call(Selector.Body, "EndsWith", null, Expression.Constant(EndsWith))),
                        Selector.Parameters[0]);
                }

            // XX
            if (AsterixCount == 0 && Filter.Length > 0)
                {
                return
                    Expression.Lambda<Func<T, bool>>(
                        Expression.Equal(Selector.Body, Expression.Constant(Filter)),
                        Selector.Parameters[0]
                    );
                }

            // *
            if (AsterixCount == 1 && Filter.Length == 1)
                return null;

            // Invalid Filter
            if (AsterixCount > 0)
                throw new ApplicationException(
                    $"Invalid filter used{(FieldName == null ? "" : $" for \'{FieldName}\'")}.");

            // Empty string: all results
            return null;

            }

        /// <exception cref="ArgumentException">Property not found</exception>
        public static IQueryable<T> FilterBy<T>(this IQueryable<T> Query, SearchOperation Operation)
            {
            if (string.IsNullOrEmpty(Operation.Property))
                {
                throw new ArgumentException("Property not found");
                }

            string Property = Operation.Property;
            var MemberType = typeof(T);
            ModelMetadata Meta;

            LambdaExpression Accessor;


            if (Operation.Property.Contains("."))
                {
                string[] Split = Operation.Property.Split('.');

                string[] FullProperties;

                Accessor = typeof(T).FindSubProperty(out Meta, out FullProperties, Split);
                }
            else
                {
                Property = MemberType.SearchForProperty(Property);
                Meta = MemberType.Meta(Property);
                Accessor = Meta.GetExpression();

                if (Meta.ModelType.HasInterface<IModel>() && Meta.ModelType.HasAttribute<SearchColumnsAttribute>())
                    {
                    // Relation fields drill into the sub-model to filter
                    // Use the default field since no field was given

                    var Attr = Meta.ModelType.GetAttribute<SearchColumnsAttribute>();

                    string SearchColumn = Attr != null ?
                        Attr.SearchColumns[0] :
                        Meta.Properties.FirstOrDefault()?.PropertyName;

                    string[] FullProperties;

                    Accessor = typeof(T).FindSubProperty(out Meta, out FullProperties, Property, SearchColumn);

                    MemberType = Meta.ModelType;
                    }
                }

            var Filter = new FilterExpression<T>(Operation, Accessor, Meta);

            Expression<Func<T, bool>> Expr = Filter.PerformAction(MemberType);

            if (Expr != null)
                {
                Query = Query.Where(Expr);
                }

            return Query;
            }

        public static string SearchForProperty(this Type Type, string Property)
            {
            Property = Property.ToLower().Trim();

            List<MemberInfo> Fields =
                Type.GetMembers().Where(Member => Member.Name.ToLower().StartsWith(Property)).ToList();

            if (Fields.Count == 1)
                return Fields[0].Name;
            if (Fields.Count > 1)
                {
                List<MemberInfo> FieldsEqual = Fields.Where(Field => Field.Name.ToLower() == Property).ToList();

                if (FieldsEqual.Count == 1)
                    return FieldsEqual[0].Name;
                }

            return null;
            }

        public static Expression<Func<T, V>> CastInput<T, U, V>(this Expression<Func<U, V>> Expr)
            {
            var Param = Expression.Parameter(typeof(T), string.Empty);
            var Cast = Expression.TypeAs(Param, typeof(U));

            var Lambda = Expression.Lambda(new SwapVisitor(Expr.Parameters[0], Cast).Visit(Expr.Body), Param);

            return (Expression<Func<T, V>>)Lambda;
            }

        public static object FindByID(this DbSet Set, object ID)
            {
            string Str = ID as string;
            if (Str != null)
                {
                string StrID = Str;

                long IdLong;
                if (long.TryParse(StrID, out IdLong))
                    return Set.Find(IdLong);

                int IdInt;
                if (int.TryParse(StrID, out IdInt))
                    return Set.Find(IdInt);

                Guid Guid;
                if (Guid.TryParse(StrID, out Guid))
                    return Set.Find(Guid);
                }

            return Set.Find(ID);
            }

        public static T FindByID<T>(this DbSet<T> Set, object ID)
            where T : class
            {
            string Str = ID as string;
            if (Str != null)
                {
                string StrID = Str;

                long IdLong;
                if (long.TryParse(StrID, out IdLong))
                    return Set.Find(IdLong);

                int IdInt;
                if (int.TryParse(StrID, out IdInt))
                    return Set.Find(IdInt);

                Guid Guid;
                if (Guid.TryParse(StrID, out Guid))
                    return Set.Find(Guid);
                }

            return Set.Find(ID);
            }

        internal static IQueryable<T> FilterSet_Active<T>(IQueryable<T> Set)
            {
            // Filter out inactive if there is an Active field
            if (typeof(T).HasProperty(ControllerHelper.AutomaticFields.Active))
                {
                if (typeof(T).Meta(ControllerHelper.AutomaticFields.Active).ModelType == typeof(bool))
                    {
                    Expression<Func<T, bool>> Exp = typeof(T).GetExpression<T, bool>(ControllerHelper.AutomaticFields.Active);
                    Expression Equal = Expression.Equal(Exp.Body, Expression.Constant(true));
                    Expression Lambda = Expression.Lambda(Equal, Exp.Parameters[0]);

                    Set = Set.Where((Expression<Func<T, bool>>)Lambda);
                    }
                else if (typeof(T).Meta(ControllerHelper.AutomaticFields.Active).ModelType == typeof(bool?))
                    {
                    Expression<Func<T, bool?>> Exp = typeof(T).GetExpression<T, bool?>(ControllerHelper.AutomaticFields.Active);
                    Expression Equal = Expression.Equal(Exp.Body, Expression.Constant(true));
                    Expression Lambda = Expression.Lambda(Equal, Exp.Parameters[0]);

                    Set = Set.Where((Expression<Func<T, bool>>)Lambda);
                    }
                }

            return Set;
            }
        }
    }