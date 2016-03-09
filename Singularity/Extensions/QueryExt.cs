using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LCore;
using System.Collections;
using System.Data.Entity;
using Singularity.Controllers;
using System.Web.Mvc;
using Singularity.Models;
using Singularity.Utilities;
using Singularity.Annotations;

namespace Singularity.Extensions
    {
    public class SwapVisitor : ExpressionVisitor
        {
        private readonly Expression from, to;
        public SwapVisitor(Expression from, Expression to)
            {
            this.from = from;
            this.to = to;
            }
        public override Expression Visit(Expression node)
            {
            return node == from ? to : base.Visit(node);
            }
        }
    public class ExpressionParameterReplacer : ExpressionVisitor
        {
        public ExpressionParameterReplacer(IList<ParameterExpression> fromParameters, IList<ParameterExpression> toParameters)
            {
            ParameterReplacements = new Dictionary<ParameterExpression, ParameterExpression>();
            for (int i = 0; i != fromParameters.Count && i != toParameters.Count; i++)
                ParameterReplacements.Add(fromParameters[i], toParameters[i]);
            }
        private IDictionary<ParameterExpression, ParameterExpression> ParameterReplacements
            {
            get;
            set;
            }
        protected override Expression VisitParameter(ParameterExpression node)
            {
            ParameterExpression replacement;
            if (ParameterReplacements.TryGetValue(node, out replacement))
                node = replacement;
            return base.VisitParameter(node);
            }
        }

    public static class QueryExt
        {
        public static Dictionary<String, Func<Expression, Expression, Expression>> BinaryOps = new Dictionary<String, Func<Expression, Expression, Expression>>()
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
                {":", Expression.Equal},
            };

        public static IQueryable<T> IsNull<T>(this IQueryable<T> source, string Column)
            {
            // Use source type instead of T which can be [Object]
            Type t = source.ElementType;

            ParameterExpression param = Expression.Parameter(t, string.Empty);
            MemberExpression member = Expression.PropertyOrField(param, Column);

            // Non-nullable value types can't contain nulls. No results will be returned.
            if (member.Type.IsValueType && !member.Type.IsNullable())
                return source.Where((Expression<Func<T, Boolean>>)Expression.Lambda(Expression.Constant(false), param));

            BinaryExpression property = Expression.Equal(member, Expression.Constant(null));
            LambdaExpression condition = Expression.Lambda(property, param);

            return source.Where((Expression<Func<T, Boolean>>)condition);
            }

        public static IQueryable<T> IsNotNull<T>(this IQueryable<T> source, string Column)
            {
            // Use source type instead of T which can be [Object]
            Type t = source.ElementType;

            ParameterExpression param = Expression.Parameter(t, string.Empty);
            MemberExpression member = Expression.PropertyOrField(param, Column);

            // Non-nullable value types can't contain nulls. Nothing can be filtered.
            if (member.Type.IsValueType && !member.Type.IsNullable())
                return source;

            BinaryExpression property = Expression.NotEqual(member, Expression.Constant(null));
            LambdaExpression condition = Expression.Lambda(property, param);

            return source.Where((Expression<Func<T, Boolean>>)condition);
            }

        public static Expression<Func<T, Boolean>> Or<T>(this IEnumerable<Expression<Func<T, Boolean>>> Expressions)
            {
            Expression<Func<T, Boolean>> Out = null;

            foreach (Expression<Func<T, Boolean>> Exp in Expressions)
                {
                if (Out == null)
                    {
                    Out = Exp;
                    }
                else
                    {
                    Out = Expression.Lambda<Func<T, Boolean>>(
                        Expression.OrElse(
                            Out.Body,
                            new ExpressionParameterReplacer(Exp.Parameters, Out.Parameters).Visit(Exp.Body)),
                        Out.Parameters);
                    }
                }

            /*
            Expression<T> Out = null;

            foreach (Expression<T> Exp in Expressions)
                {
                if (Out == null)
                    {
                    Out = Exp;
                    }
                else
                    {
                    Out = (Expression<T>)(Object)Expression.OrElse(Out, Exp);
                    }
                }
             */

            if (Out != null)
                {
                if (Out.CanReduce)
                    Out.Reduce();
                }

            return Out;
            }

        public static Expression<Func<T, Boolean>> And<T>(this IEnumerable<Expression<Func<T, Boolean>>> Expressions)
            {
            Expression<Func<T, Boolean>> Out = null;

            foreach (Expression<Func<T, Boolean>> Exp in Expressions)
                {
                if (Out == null)
                    {
                    Out = Exp;
                    }
                else
                    {
                    Out = Expression.Lambda<Func<T, Boolean>>(
                        Expression.AndAlso(
                            Out.Body,
                            new ExpressionParameterReplacer(Exp.Parameters, Out.Parameters).Visit(Exp.Body)),
                        Out.Parameters);
                    }
                }
            /*
            foreach (Expression<T> Exp in Expressions)
                {
                if (Out == null)
                    {
                    Out = Exp;
                    }
                else
                    {
                    Out = (Expression<T>)(Object)Expression.AndAlso(Out, Exp);
                    }
                }
            */

            if (Out != null && Out.CanReduce)
                Out.Reduce();

            return Out;
            }

        public static Expression<Func<T, Boolean>> GlobalSearchRecursive<T>(String GlobalSearch,
            String[] ParentProperties = null, Type[] ParentTypes = null)
            {
            ParentProperties = ParentProperties ?? new String[] { };
            ParentTypes = ParentTypes ?? new Type[] { typeof(T) };

            List<Expression<Func<T, Boolean>>> SearchPartConditions = new List<Expression<Func<T, bool>>>();

            ModelMetadata Meta = ParentTypes.Last().Meta();

            // TODO: Split by quotes
            String[] GlobalSearchParts = GlobalSearch.SplitWithQuotes(' ').Array();

            foreach (String GlobalSearchPart in GlobalSearchParts)
                {
                String GlobalSearchPartClean = GlobalSearchPart.RemoveAll("\"");

                List<Expression<Func<T, Boolean>>> FieldConditions = new List<Expression<Func<T, bool>>>();

                foreach (ModelMetadata Prop in Meta.Properties)
                    {
                    if (Prop.HasAttribute<KeyAttribute>())
                        continue;

                    if (Prop.HasAttribute<NotMappedAttribute>())
                        continue;

                    if (!Prop.HasAttribute<FieldGlobalSearchAttribute>()
                        || Prop.HasAttribute<HideManageViewColumnAttribute>())
                        continue;

                    if (!Prop.ModelType.HasInterface<IConvertible>() &&
                        // Don't skip IModel types for not being IConvertible
                        !(Prop.ModelType.HasInterface<IModel>(false)))
                        continue;

                    if (Prop.AdditionalValues.ContainsKey(GlobalSearchDisabledAttribute.Key)
                        && Prop.AdditionalValues[GlobalSearchDisabledAttribute.Key] as Boolean? == true)
                        continue;

                    String[] Properties = ParentProperties.Add(Prop.PropertyName);

                    if (Prop.ModelType.HasInterface<IModel>(false))
                        {
                        Type[] Types = ParentTypes.Add(Prop.ModelType);

                        Expression<Func<T, Boolean>> SubFieldConditions = GlobalSearchRecursive<T>("\"" + GlobalSearchPartClean + "\"", Properties, Types);

                        if (SubFieldConditions != null)
                            FieldConditions.Add(SubFieldConditions);
                        }
                    else
                        {
                        ModelMetadata Meta2;
                        String[] FullProperties = null;

                        LambdaExpression Accessor = ParentTypes[0].FindSubProperty(out Meta2, out FullProperties, Properties);

                        SearchOperation Operation = new SearchOperation()
                        {
                            Property = Prop.PropertyName,
                            OperatorStr = "~",
                            Operator = QueryExt.BinaryOps["~"],
                            Search = GlobalSearchPartClean
                        };

                        FilterExpression<T> Filter = new FilterExpression<T>(Operation, Accessor, Meta2);

                        Expression<Func<T, Boolean>> Expr = Filter.PerformAction(Meta2.ModelType);

                        if (Expr != null)
                            FieldConditions.Add(Expr);
                        }
                    }

                Expression<Func<T, Boolean>> FieldCondition = null;

                FieldCondition = FieldConditions.Or();

                if (FieldCondition != null)
                    {
                    if (FieldCondition != null && FieldCondition.CanReduce)
                        FieldCondition = (Expression<Func<T, Boolean>>)FieldCondition.Reduce();
                    }

                SearchPartConditions.Add(FieldCondition);
                }

            if (SearchPartConditions != null)
                {
                var Out = SearchPartConditions.And();

                if (Out != null && Out.CanReduce)
                    Out.Reduce();

                return Out;
                }

            return null;
            }

        private static IOrderedQueryable<T> OrderingHelper<T>(IQueryable<T> source, string PropertyName, bool descending, bool anotherLevel)
            {
            String PropertyName2 = "";
            if (PropertyName.Contains("."))
                {
                String[] Split = PropertyName.Split(".");

                PropertyName = Split[0];
                PropertyName2 = Split[1];
                }

            // Use source type instead of T which can be [Object]
            Type t = source.ElementType;

            Type PropertyType = t.Meta(PropertyName).ModelType;

            if (PropertyType.HasInterface<IEnumerable>() &&
                PropertyType.IsGenericType &&
                PropertyType.GetGenericArguments()[0].HasInterface<IModel>())
                {
                // Sort ICollection<IModel> properties by Count

                ParameterExpression param = Expression.Parameter(t, string.Empty);
                MemberExpression property = Expression.PropertyOrField(param, PropertyName);

                if (!String.IsNullOrEmpty(PropertyName2))
                    {
                    property = Expression.PropertyOrField(property, PropertyName2);
                    }

                MemberExpression property2 = Expression.PropertyOrField(property, "Count");

                // Expression property2 = Expression.Call(property, property.Type.GetMethod("get_Count"));

                LambdaExpression sort = Expression.Lambda(property2, param);

                Expression<Func<T, bool>> ConditionGreaterThanZero =
                    (Expression<Func<T, bool>>)Expression.Lambda(
                        Expression.GreaterThan(property2, Expression.Constant((int)0)),
                        param);

                source = source.Where(ConditionGreaterThanZero);

                MethodCallExpression call = Expression.Call(
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

                ParameterExpression param = Expression.Parameter(t, string.Empty);
                MemberExpression property = Expression.PropertyOrField(param, PropertyName);

                if (!String.IsNullOrEmpty(PropertyName2))
                    {
                    property = Expression.PropertyOrField(property, PropertyName2);
                    }

                LambdaExpression sort = Expression.Lambda(property, param);

                MethodCallExpression call = Expression.Call(
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
        
        public static Expression<Func<T, Boolean>> WhereFilter<T>(this Expression<Func<T, string>> selector, string filter, string fieldName)
            {
            if (filter == null)
                return null;

            if (selector == null)
                return null;

            int astrixCount = System.Linq.Enumerable.Count(filter, c => c.Equals('*'));
            if (astrixCount > 2)
                throw new ApplicationException(string.Format("Invalid filter used{0}. '*' can maximum occur 2 times.", fieldName == null ? "" : " for '" + fieldName + "'"));

            if (filter.Contains("?"))
                throw new ApplicationException(string.Format("Invalid filter used{0}. '?' is not supported, only '*' is supported.", fieldName == null ? "" : " for '" + fieldName + "'"));

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
                throw new ApplicationException(string.Format("Invalid filter used{0}.", fieldName == null ? "" : " for '" + fieldName + "'"));

            // Empty string: all results
            return null;

            }

        public static IQueryable<T> FilterBy<T>(this IQueryable<T> Query, SearchOperation Operation)
            {
            if (String.IsNullOrEmpty(Operation.Property))
                {
                throw new Exception("Property not found");
                }

            String Property = Operation.Property;
            Type MemberType = typeof(T);
            ModelMetadata Meta = null;

            LambdaExpression Accessor = null;


            if (Operation.Property.Contains("."))
                {
                String[] Split = Operation.Property.Split('.');

                String[] FullProperties = null;

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

                    SearchColumnsAttribute Attr = Meta.ModelType.GetAttribute<SearchColumnsAttribute>();

                    String SearchColumn = null;

                    if (Attr != null)
                        {
#warning only searching with first column - bandaid
                        SearchColumn = Attr.SearchColumns[0];
                        }
                    else
                        {
                        // Otherwise just use the first field
                        SearchColumn = Meta.Properties.FirstOrDefault().PropertyName;
                        }

                    String[] FullProperties = null;

                    Accessor = typeof(T).FindSubProperty(out Meta, out FullProperties, new[] { Property, SearchColumn });

                    MemberType = Meta.ModelType;
                    }
                }

            FilterExpression<T> Filter = new FilterExpression<T>(Operation, Accessor, Meta);

            Expression<Func<T, Boolean>> Expr = Filter.PerformAction(Meta.ModelType);

            if (Expr != null)
                {
                Query = Query.Where(Expr);
                }

            return Query;
            }

        public static String SearchForProperty(this Type type, string Property)
            {
            Property = Property.ToLower().Trim();

            List<MemberInfo> Fields =
                type.GetMembers().Where(m => m.Name.ToLower().StartsWith(Property)).ToList();

            if (Fields.Count == 1)
                return Fields[0].Name;
            else if (Fields.Count > 1)
                {
                List<MemberInfo> FieldsEqual = Fields.Where(m => m.Name.ToLower() == Property).ToList();

                if (FieldsEqual.Count == 1)
                    return FieldsEqual[0].Name;
                }

            return null;
            }

        public static Expression<Func<T, V>> CastInput<T, U, V>(this Expression<Func<U, V>> Expr)
            {
            ParameterExpression Param = Expression.Parameter(typeof(T), String.Empty);
            UnaryExpression Cast = Expression.TypeAs(Param, typeof(U));

            LambdaExpression Lambda = Expression.Lambda(new SwapVisitor(Expr.Parameters[0], Cast).Visit(Expr.Body), Param);

            return (Expression<Func<T, V>>)Lambda;
            }

        public static Object FindByID(this DbSet Set, Object ID)
            {
            if (ID is String)
                {
                String StrID = (String)ID;

                long IdLong = 0;
                if (Int64.TryParse(StrID, out IdLong))
                    return Set.Find(IdLong);

                int IdInt = 0;
                if (Int32.TryParse(StrID, out IdInt))
                    return Set.Find(IdInt);

                Guid g;
                if (Guid.TryParse(StrID, out g))
                    return Set.Find(g);
                }

            return Set.Find(ID);
            }

        public static T FindByID<T>(this DbSet<T> Set, Object ID)
            where T : class
            {
            if (ID is String)
                {
                String StrID = (String)ID;

                long IdLong = 0;
                if (Int64.TryParse(StrID, out IdLong))
                    return Set.Find(IdLong);

                int IdInt = 0;
                if (Int32.TryParse(StrID, out IdInt))
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
                if (typeof(T).Meta(ControllerHelper.AutomaticFields.Active).ModelType == typeof(Boolean))
                    {
                    Expression<Func<T, Boolean>> Exp = typeof(T).GetExpression<T, Boolean>(ControllerHelper.AutomaticFields.Active);
                    Expression Equal = Expression.Equal(Exp.Body, Expression.Constant(true));
                    Expression Lambda = Expression.Lambda(Equal, Exp.Parameters[0]);

                    Set = Set.Where((Expression<Func<T, Boolean>>)Lambda);
                    }
                else if (typeof(T).Meta(ControllerHelper.AutomaticFields.Active).ModelType == typeof(Boolean?))
                    {
                    Expression<Func<T, Boolean?>> Exp = typeof(T).GetExpression<T, Boolean?>(ControllerHelper.AutomaticFields.Active);
                    Expression Equal = Expression.Equal(Exp.Body, Expression.Constant(true));
                    Expression Lambda = Expression.Lambda(Equal, Exp.Parameters[0]);

                    Set = Set.Where((Expression<Func<T, Boolean>>)Lambda);
                    }
                }

            return Set;
            }
        }
    }