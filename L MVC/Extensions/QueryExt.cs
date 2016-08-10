using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LCore.Extensions;
using System.Collections;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using LMVC.Controllers;
using System.Web.Mvc;
using JetBrains.Annotations;
using LCore.Interfaces;
using LMVC.Models;
using LMVC.Utilities;
using LMVC.Annotations;

// ReSharper disable once RedundantUsingDirective
using IQueryable = System.Linq.IQueryable;

namespace LMVC.Extensions
    {
    [ExtensionProvider]
    public static class QueryExt
        {
        public static readonly Dictionary<string, Func<Expression, Expression, Expression>> BinaryOps = new Dictionary
            <string, Func<Expression, Expression, Expression>>
            {
            // ReSharper disable ArgumentsStyleLiteral
            {"~", null}, // LIKE, custom Expression
            {"><", null}, // WITHIN, custom expression
            {"<>", null}, // WITHOUT, custom expression
            // ReSharper restore ArgumentsStyleLiteral
            {">=", Expression.GreaterThanOrEqual},
            {"<=", Expression.LessThanOrEqual},
            {">", Expression.GreaterThan},
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
                return Source.Where((Expression<Func<T, bool>>) Expression.Lambda(Expression.Constant(value: false), Param));

            var Property = Expression.Equal(Member, Expression.Constant(value: null));
            var Condition = Expression.Lambda(Property, Param);

            return Source.Where((Expression<Func<T, bool>>) Condition);
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

            var Property = Expression.NotEqual(Member, Expression.Constant(value: null));
            var Condition = Expression.Lambda(Property, Param);

            return Source.Where((Expression<Func<T, bool>>) Condition);
            }

        public static Expression<Func<T, bool>> Or<T>([CanBeNull] this IEnumerable<Expression<Func<T, bool>>> Expressions)
            {
            Expression<Func<T, bool>> Out = Obj => false;

            Out = Expressions.Where(Exp => Exp != null).Aggregate(Out, (Current, Exp) =>
                Expression.Lambda<Func<T, bool>>(Expression.OrElse(Current.Body,
                    new ExpressionParameterReplacer(Exp.Parameters, Current.Parameters).Visit(Exp.Body)), Current.Parameters));

            if (Out.CanReduce)
                Out.Reduce();

            return Out;
            }

        public static Expression<Func<T, bool>> And<T>([CanBeNull] this IEnumerable<Expression<Func<T, bool>>> Expressions)
            {
            Expression<Func<T, bool>> Out = Obj => false;

            if (Expressions != null)
                Out = Expressions.Aggregate(Out, (Current, Exp) =>
                    Expression.Lambda<Func<T, bool>>(Expression.AndAlso(Current.Body,
                        new ExpressionParameterReplacer(Exp.Parameters, Current.Parameters).Visit(Exp.Body)),
                        Current.Parameters));

            if (Out.CanReduce)
                Out.Reduce();

            return Out;
            }

        [CanBeNull]
        public static Expression<Func<T, bool>> GlobalSearchRecursive<T>(string GlobalSearch,
            string[] ParentProperties = null, Type[] ParentTypes = null)
            {
            ParentProperties = ParentProperties ?? new string[] {};
            ParentTypes = ParentTypes ?? new[] {typeof(T)};

            var SearchPartConditions = new List<Expression<Func<T, bool>>>();

            var Meta = ParentTypes.Last().Meta();

            string[] GlobalSearchParts = GlobalSearch.SplitWithQuotes(SplitBy: ' ').Array();

            foreach (string GlobalSearchPart in GlobalSearchParts)
                {
                string GlobalSearchPartClean = GlobalSearchPart.RemoveAll("\"");

                var FieldConditions = new List<Expression<Func<T, bool>>>();

                if (Meta != null)
                    foreach (var Prop in Meta.Properties)
                        {
                        if (Prop.HasAttribute<KeyAttribute>(IncludeSubClasses: true))
                            continue;

                        if (Prop.HasAttribute<NotMappedAttribute>(IncludeSubClasses: true))
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

                if (FieldCondition.CanReduce)
                    FieldCondition = (Expression<Func<T, bool>>) FieldCondition.Reduce();

                SearchPartConditions.Add(FieldCondition);
                }

            if (SearchPartConditions.Count > 0)
                {
                Expression<Func<T, bool>> Out = SearchPartConditions.And();

                if (Out.CanReduce)
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

            var PropertyType = Type.Meta(PropertyName)?.ModelType;

            if (PropertyType.HasInterface<IEnumerable>() &&
                PropertyType?.IsGenericType == true &&
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
                    (Expression<Func<T, bool>>) Expression.Lambda(
                        Expression.GreaterThan(Property2, Expression.Constant(value: 0)),
                        Param);

                Source = Source.Where(ConditionGreaterThanZero);

                var Call = Expression.Call(
                    typeof(Queryable),
                    (!AnotherLevel
                        ? "OrderBy"
                        : "ThenBy") + (Desc
                            ? "Descending"
                            : string.Empty),
                    new[] {Type, Property2.Type},
                    Source.Expression,
                    Expression.Quote(Sort));

                return (IOrderedQueryable<T>) Source.Provider.CreateQuery<T>(Call);
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
                (!AnotherLevel
                    ? "OrderBy"
                    : "ThenBy") + (Desc
                        ? "Descending"
                        : string.Empty),
                new[] {Type, Property3.Type},
                Source.Expression,
                Expression.Quote(Sort2));
            return (IOrderedQueryable<T>) Source.Provider.CreateQuery<T>(Call2);
            }

        public static IOrderedQueryable<T> OrderBy<T>([CanBeNull] this IQueryable<T> Source, [CanBeNull] string PropertyName)
            {
            return OrderingHelper(Source, PropertyName, Desc: false, AnotherLevel: false);
            }

        public static IOrderedQueryable<T> OrderByDescending<T>([CanBeNull] this IQueryable<T> Source, [CanBeNull] string PropertyName)
            {
            return OrderingHelper(Source, PropertyName, Desc: true, AnotherLevel: false);
            }

        public static IOrderedQueryable<T> ThenBy<T>([CanBeNull] this IOrderedQueryable<T> Source, [CanBeNull] string PropertyName)
            {
            return OrderingHelper(Source, PropertyName, Desc: false, AnotherLevel: true);
            }

        public static IOrderedQueryable<T> ThenByDescending<T>([CanBeNull] this IOrderedQueryable<T> Source, [CanBeNull] string PropertyName)
            {
            return OrderingHelper(Source, PropertyName, Desc: true, AnotherLevel: true);
            }

        /// <exception cref="ApplicationException">Used * characters more than 2 times</exception>
        /// <exception cref="ApplicationException">Used ? character, it's not supported</exception>
        public static Expression<Func<T, bool>> WhereFilter<T>([CanBeNull] this Expression<Func<T, string>> Selector,
            [CanBeNull] string Filter, [CanBeNull] string FieldName)
            {
            if (Filter == null)
                return null;

            if (Selector == null)
                return null;

            uint AsterixCount = EnumerableExt.Count(Filter, Char => Char.Equals(obj: '*'));
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
                    Selector.Parameters[index: 0]);
                }

            // *XX
            if (AsterixCount == 1 && Filter.Length > 1 && Filter.StartsWith("*"))
                {
                Filter = Filter.Replace("*", "");
                return Expression.Lambda<Func<T, bool>>(
                    Expression.Call(Selector.Body, "EndsWith", null, Expression.Constant(Filter)),
                    Selector.Parameters[index: 0]
                    );
                }

            // XX*
            if (AsterixCount == 1 && Filter.Length > 1 && Filter.EndsWith("*"))
                {
                Filter = Filter.Replace("*", "");
                return Expression.Lambda<Func<T, bool>>(
                    Expression.Call(Selector.Body, "StartsWith", null, Expression.Constant(Filter)),
                    Selector.Parameters[index: 0]
                    );
                }

            // X*X
            if (AsterixCount == 1 && Filter.Length > 2 && !Filter.StartsWith("*") && !Filter.EndsWith("*"))
                {
                string StartsWith = Filter.Sub(Start: 0, Length: Filter.IndexOf(value: '*'));
                string EndsWith = Filter.Sub(Filter.IndexOf(value: '*') + 1);

                return
                    Expression.Lambda<Func<T, bool>>(
                        Expression.And(
                            Expression.Call(Selector.Body, "StartsWith", null, Expression.Constant(StartsWith)),
                            Expression.Call(Selector.Body, "EndsWith", null, Expression.Constant(EndsWith))),
                        Selector.Parameters[index: 0]);
                }

            // XX
            if (AsterixCount == 0 && Filter.Length > 0)
                {
                return
                    Expression.Lambda<Func<T, bool>>(
                        Expression.Equal(Selector.Body, Expression.Constant(Filter)),
                        Selector.Parameters[index: 0]
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
        public static IQueryable<T> FilterBy<T>([CanBeNull] this IQueryable<T> Query, SearchOperation Operation)
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

                if (Meta?.ModelType.HasInterface<IModel>() == true &&
                    Meta.ModelType.HasAttribute<SearchColumnsAttribute>())
                    {
                    // Relation fields drill into the sub-model to filter
                    // Use the default field since no field was given

                    var Attr = Meta.ModelType.GetAttribute<SearchColumnsAttribute>();

                    string SearchColumn = Attr != null
                        ? Attr.SearchColumns[0]
                        : Meta.Properties.FirstOrDefault()?.PropertyName;

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
                return Fields[index: 0].Name;
            if (Fields.Count > 1)
                {
                List<MemberInfo> FieldsEqual = Fields.Where(Field => Field.Name.ToLower() == Property).ToList();

                if (FieldsEqual.Count == 1)
                    return FieldsEqual[index: 0].Name;
                }

            return null;
            }

        public static Expression<Func<T, V>> CastInput<T, U, V>(this Expression<Func<U, V>> Expr)
            {
            var Param = Expression.Parameter(typeof(T), string.Empty);
            var Cast = Expression.TypeAs(Param, typeof(U));

            var Lambda = Expression.Lambda(new SwapVisitor(Expr.Parameters[index: 0], Cast).Visit(Expr.Body), Param);

            return (Expression<Func<T, V>>) Lambda;
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
                if (typeof(T).Meta(ControllerHelper.AutomaticFields.Active)?.ModelType == typeof(bool))
                    {
                    Expression<Func<T, bool>> Exp = typeof(T).GetExpression<T, bool>(ControllerHelper.AutomaticFields.Active);
                    Expression Equal = Expression.Equal(Exp.Body, Expression.Constant(value: true));
                    Expression Lambda = Expression.Lambda(Equal, Exp.Parameters[index: 0]);

                    Set = Set.Where((Expression<Func<T, bool>>) Lambda);
                    }
                else if (typeof(T).Meta(ControllerHelper.AutomaticFields.Active)?.ModelType == typeof(bool?))
                    {
                    Expression<Func<T, bool?>> Exp = typeof(T).GetExpression<T, bool?>(ControllerHelper.AutomaticFields.Active);
                    Expression Equal = Expression.Equal(Exp.Body, Expression.Constant(value: true));
                    Expression Lambda = Expression.Lambda(Equal, Exp.Parameters[index: 0]);

                    Set = Set.Where((Expression<Func<T, bool>>) Lambda);
                    }
                }

            return Set;
            }
        }
    }