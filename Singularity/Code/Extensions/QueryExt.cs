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
        public static Dictionary<string, Func<Expression, Expression, Expression>> BinaryOps = new Dictionary<string, Func<Expression, Expression, Expression>>
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

        public static IQueryable<T> IsNull<T>(this IQueryable<T> source, string Column)
            {
            // Use source type instead of T which can be [Object]
            var t = source.ElementType;

            var param = Expression.Parameter(t, string.Empty);
            var member = Expression.PropertyOrField(param, Column);

            // Non-nullable value types can't contain nulls. No results will be returned.
            if (member.Type.IsValueType && !member.Type.IsNullable())
                return source.Where((Expression<Func<T, bool>>)Expression.Lambda(Expression.Constant(false), param));

            var property = Expression.Equal(member, Expression.Constant(null));
            var condition = Expression.Lambda(property, param);

            return source.Where((Expression<Func<T, bool>>)condition);
            }

        public static IQueryable<T> IsNotNull<T>(this IQueryable<T> source, string Column)
            {
            // Use source type instead of T which can be [Object]
            var t = source.ElementType;

            var param = Expression.Parameter(t, string.Empty);
            var member = Expression.PropertyOrField(param, Column);

            // Non-nullable value types can't contain nulls. Nothing can be filtered.
            if (member.Type.IsValueType && !member.Type.IsNullable())
                return source;

            var property = Expression.NotEqual(member, Expression.Constant(null));
            var condition = Expression.Lambda(property, param);

            return source.Where((Expression<Func<T, bool>>)condition);
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
                        !Prop.ModelType.HasInterface<IModel>(false))
                        continue;

                    if (Prop.AdditionalValues.ContainsKey(GlobalSearchDisabledAttribute.Key)
                        && Prop.AdditionalValues[GlobalSearchDisabledAttribute.Key] as bool? == true)
                        continue;

                    string[] Properties = ParentProperties.Add(Prop.PropertyName);

                    if (Prop.ModelType.HasInterface<IModel>(false))
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

        private static IOrderedQueryable<T> OrderingHelper<T>(IQueryable<T> source, string PropertyName, bool descending, bool anotherLevel)
            {
            string PropertyName2 = "";
            if (PropertyName.Contains("."))
                {
                string[] Split = PropertyName.Split(".");

                PropertyName = Split[0];
                PropertyName2 = Split[1];
                }

            // Use source type instead of T which can be [Object]
            var t = source.ElementType;

            var PropertyType = t.Meta(PropertyName).ModelType;

            if (PropertyType.HasInterface<IEnumerable>() &&
                PropertyType.IsGenericType &&
                PropertyType.GetGenericArguments()[0].HasInterface<IModel>())
                {
                // Sort ICollection<IModel> properties by Count

                var param = Expression.Parameter(t, string.Empty);
                var property = Expression.PropertyOrField(param, PropertyName);

                if (!string.IsNullOrEmpty(PropertyName2))
                    {
                    property = Expression.PropertyOrField(property, PropertyName2);
                    }

                var property2 = Expression.PropertyOrField(property, "Count");

                // Expression property2 = Expression.Call(property, property.Type.GetMethod("get_Count"));

                var sort = Expression.Lambda(property2, param);

                var ConditionGreaterThanZero =
                    (Expression<Func<T, bool>>)Expression.Lambda(
                        Expression.GreaterThan(property2, Expression.Constant(0)),
                        param);

                source = source.Where(ConditionGreaterThanZero);

                var call = Expression.Call(
                    typeof(Queryable),
                    (!anotherLevel ? "OrderBy" : "ThenBy") + (descending ? "Descending" : string.Empty),
                    new[] { t, property2.Type },
                    source.Expression,
                    Expression.Quote(sort));

                return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(call);
                }
            else
                {
                source = source.IsNotNull(PropertyName);

                var param = Expression.Parameter(t, string.Empty);
                var property = Expression.PropertyOrField(param, PropertyName);

                if (!string.IsNullOrEmpty(PropertyName2))
                    {
                    property = Expression.PropertyOrField(property, PropertyName2);
                    }

                var sort = Expression.Lambda(property, param);

                var call = Expression.Call(
                    typeof(Queryable),
                    (!anotherLevel ? "OrderBy" : "ThenBy") + (descending ? "Descending" : string.Empty),
                    new[] { t, property.Type },
                    source.Expression,
                    Expression.Quote(sort));
                return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(call);
                }
            }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string PropertyName)
            {
            return OrderingHelper(source, PropertyName, false, false);
            }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string PropertyName)
            {
            return OrderingHelper(source, PropertyName, true, false);
            }

        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string PropertyName)
            {
            return OrderingHelper(source, PropertyName, false, true);
            }

        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string PropertyName)
            {
            return OrderingHelper(source, PropertyName, true, true);
            }

        public static Expression<Func<T, bool>> WhereFilter<T>(this Expression<Func<T, string>> selector, string filter, string fieldName)
            {
            if (filter == null)
                return null;

            if (selector == null)
                return null;

            int astrixCount = filter.Count(c => c.Equals('*'));
            if (astrixCount > 2)
                throw new ApplicationException(
                    $"Invalid filter used{(fieldName == null ? "" : $" for \'{fieldName}\'")}. '*' can maximum occur 2 times.");

            if (filter.Contains("?"))
                throw new ApplicationException(
                    $"Invalid filter used{(fieldName == null ? "" : $" for \'{fieldName}\'")}. '?' is not supported, only '*' is supported.");

            // *XX*
            if (astrixCount == 2 && filter.Length > 2 && filter.StartsWith("*") && filter.EndsWith("*"))
                {
                filter = filter.Replace("*", "");
                return Expression.Lambda<Func<T, bool>>(
                        Expression.Call(selector.Body, "Contains", null, Expression.Constant(filter)),
                        selector.Parameters[0]);
                }

            // *XX
            if (astrixCount == 1 && filter.Length > 1 && filter.StartsWith("*"))
                {
                filter = filter.Replace("*", "");
                return Expression.Lambda<Func<T, bool>>(
                        Expression.Call(selector.Body, "EndsWith", null, Expression.Constant(filter)),
                        selector.Parameters[0]
                    );
                }

            // XX*
            if (astrixCount == 1 && filter.Length > 1 && filter.EndsWith("*"))
                {
                filter = filter.Replace("*", "");
                return Expression.Lambda<Func<T, bool>>(
                        Expression.Call(selector.Body, "StartsWith", null, Expression.Constant(filter)),
                        selector.Parameters[0]
                    );
                }

            // X*X
            if (astrixCount == 1 && filter.Length > 2 && !filter.StartsWith("*") && !filter.EndsWith("*"))
                {
                string startsWith = filter.Substring(0, filter.IndexOf('*'));
                string endsWith = filter.Substring(filter.IndexOf('*') + 1);

                return
                    Expression.Lambda<Func<T, bool>>(
                    Expression.And(
                        Expression.Call(selector.Body, "StartsWith", null, Expression.Constant(startsWith)),
                        Expression.Call(selector.Body, "EndsWith", null, Expression.Constant(endsWith))),
                        selector.Parameters[0]);
                }

            // XX
            if (astrixCount == 0 && filter.Length > 0)
                {
                return
                    Expression.Lambda<Func<T, bool>>(
                        Expression.Equal(selector.Body, Expression.Constant(filter)),
                        selector.Parameters[0]
                    );
                }

            // *
            if (astrixCount == 1 && filter.Length == 1)
                return null;

            // Invalid Filter
            if (astrixCount > 0)
                throw new ApplicationException(
                    $"Invalid filter used{(fieldName == null ? "" : $" for \'{fieldName}\'")}.");

            // Empty string: all results
            return null;

            }

        public static IQueryable<T> FilterBy<T>(this IQueryable<T> Query, SearchOperation Operation)
            {
            if (string.IsNullOrEmpty(Operation.Property))
                {
                throw new Exception("Property not found");
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

                if (Meta.ModelType.HasInterface<IModel>(false) && Meta.ModelType.HasAttribute<SearchColumnsAttribute>())
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

        public static string SearchForProperty(this Type type, string Property)
            {
            Property = Property.ToLower().Trim();

            List<MemberInfo> Fields =
                type.GetMembers().Where(m => m.Name.ToLower().StartsWith(Property)).ToList();

            if (Fields.Count == 1)
                return Fields[0].Name;
            if (Fields.Count > 1)
                {
                List<MemberInfo> FieldsEqual = Fields.Where(m => m.Name.ToLower() == Property).ToList();

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
            string s = ID as string;
            if (s != null)
                {
                string StrID = s;

                long IdLong;
                if (long.TryParse(StrID, out IdLong))
                    return Set.Find(IdLong);

                int IdInt;
                if (int.TryParse(StrID, out IdInt))
                    return Set.Find(IdInt);

                Guid g;
                if (Guid.TryParse(StrID, out g))
                    return Set.Find(g);
                }

            return Set.Find(ID);
            }

        public static T FindByID<T>(this DbSet<T> Set, object ID)
            where T : class
            {
            string s = ID as string;
            if (s != null)
                {
                string StrID = s;

                long IdLong;
                if (long.TryParse(StrID, out IdLong))
                    return Set.Find(IdLong);

                int IdInt;
                if (int.TryParse(StrID, out IdInt))
                    return Set.Find(IdInt);

                Guid g;
                if (Guid.TryParse(StrID, out g))
                    return Set.Find(g);
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