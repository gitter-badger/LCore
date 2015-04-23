using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LCore;
using System.Collections;

namespace Singularity
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

        public static Expression<T> Or<T>(this IEnumerable<Expression<T>> Expressions)
            {
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

            if (Out.CanReduce)
                Out.Reduce();

            return Out;
            }

        public static IQueryable<T> GlobalSearch<T>(this IQueryable<T> data, String GlobalSearch)
            {
            List<Expression<Func<T, Boolean>>> FieldConditions = new List<Expression<Func<T, bool>>>();

            ModelMetadata Meta = typeof(T).Meta();

            foreach (ModelMetadata Prop in Meta.Properties)
                {
                if (Prop.HasAttribute<KeyAttribute>())
                    continue;

                if (!Prop.ModelType.HasInterface(typeof(IConvertible), true))
                    continue;

                if (Prop.AdditionalValues.ContainsKey(GlobalSearchDisabledAttribute.Key)
                    && Prop.AdditionalValues[GlobalSearchDisabledAttribute.Key] as Boolean? == true)
                    continue;

                ParameterExpression param = Expression.Parameter(data.ElementType, string.Empty);
                MemberExpression property = Expression.PropertyOrField(param, Prop.PropertyName);

                Type t = null;
                if (property.Member is PropertyInfo)
                    {
                    t = (property.Member as PropertyInfo).PropertyType;
                    }
                else if (property.Member is FieldInfo)
                    {
                    t = (property.Member as FieldInfo).FieldType;
                    }

                MethodCallExpression convertedExpression =
                    Expression.Call(Expression.Convert(property, typeof(Object)),
                     typeof(Object).GetMethod("ToString"));

                LambdaExpression sort = Expression.Lambda(convertedExpression, param);

                Expression<Func<T, Boolean>> Exp = WhereFilter((Expression<Func<T, String>>)sort, "*" + GlobalSearch + "*", Prop.PropertyName);

                if (Exp != null)
                    FieldConditions.Add(Exp);
                }

            Expression<Func<T, Boolean>> Out = null;

            foreach (Expression<Func<T, Boolean>> Exp in FieldConditions)
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

            if (Out.CanReduce)
                Out = (Expression<Func<T, Boolean>>)Out.Reduce();

            return data.Where(Out);
            }

        /*
        public static Expression<Func<T, Boolean>> LikeExpression<T>(IQueryable<T> data, string propertyOrFieldName, string value)
            {
            var param = Expression.Parameter(typeof(T), "x");
            var body = Expression.Call(
                typeof(HttpApplication).GetMethod("Like",
                    BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public),
                    Expression.PropertyOrField(param, propertyOrFieldName),
                    Expression.Constant(value, typeof(string)));

            var lambda = Expression.Lambda<Func<T, bool>>(body, param);

            return lambda;
            }

        public static IQueryable<T> WhereLike<T>(this IQueryable<T> data, string PropertyName, string value)
            {
            return data.Where(LikeExpression(data, PropertyName, value));
            }
         */

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

            if (PropertyType.HasInterface(typeof(IEnumerable), true) &&
                PropertyType.IsGenericType &&
                PropertyType.GetGenericArguments()[0].HasInterface(typeof(IModel), true))
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


        /// <summary>
        /// Filters a sequence of values based on a filter with asterix characters: A*, *A, *A*, A*B
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector">Field to use for filtering. (E.g: item => item.Name)</param>
        /// <param name="filter">Filter: A*, *A, *A*, A*B</param>
        /// <param name="fieldName">Optional description of filter field used in error messages</param>
        /// <returns>Filtered source</returns>
        /*
        public static IEnumerable<T> WhereFilter<T>(this IEnumerable<T> source, Func<T, string> selector, string filter, string fieldName)
            {

            if (filter == null)
                return source;

            if (selector == null)
                return source;

            int astrixCount = System.Linq.Enumerable.Count(filter, c => c.Equals('*'));
            if (astrixCount > 2)
                throw new ApplicationException(string.Format("Invalid filter used{0}. '*' can maximum occur 2 times.", fieldName == null ? "" : " for '" + fieldName + "'"));

            if (filter.Contains("?"))
                throw new ApplicationException(string.Format("Invalid filter used{0}. '?' is not supported, only '*' is supported.", fieldName == null ? "" : " for '" + fieldName + "'"));


            // *XX*
            if (astrixCount == 2 && filter.Length > 2 && filter.StartsWith("*") && filter.EndsWith("*"))
                {
                filter = filter.Replace("*", "");
                return source.Where(item => selector.Invoke(item).Contains(filter));
                }

            // *XX
            if (astrixCount == 1 && filter.Length > 1 && filter.StartsWith("*"))
                {
                filter = filter.Replace("*", "");
                return source.Where(item => selector.Invoke(item).EndsWith(filter));
                }

            // XX*
            if (astrixCount == 1 && filter.Length > 1 && filter.EndsWith("*"))
                {
                filter = filter.Replace("*", "");
                return source.Where(item => selector.Invoke(item).StartsWith(filter));
                }

            // X*X
            if (astrixCount == 1 && filter.Length > 2 && !filter.StartsWith("*") && !filter.EndsWith("*"))
                {
                string startsWith = filter.Substring(0, filter.IndexOf('*'));
                string endsWith = filter.Substring(filter.IndexOf('*') + 1);

                return source.Where(item => selector.Invoke(item).StartsWith(startsWith) && selector.Invoke(item).EndsWith(endsWith));
                }

            // XX
            if (astrixCount == 0 && filter.Length > 0)
                {
                return source.Where(item => selector.Invoke(item).Equals(filter));
                }

            // *
            if (astrixCount == 1 && filter.Length == 1)
                return source;

            // Invalid Filter
            if (astrixCount > 0)
                throw new ApplicationException(string.Format("Invalid filter used{0}.", fieldName == null ? "" : " for '" + fieldName + "'"));

            // Empty string: all results
            return source;


            }
        */
        /// <summary>
        /// Filters a sequence of values based on a filter with asterix characters: A*, *A, *A*, A*B
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector">Field to use for filtering. (E.g: item => item.Name)        </param>
        /// <param name="filter">Filter: A*, *A, *A*, A*B</param>
        /// <param name="fieldName">Optional description of filter field used in error messages</param>
        /// <returns>Filtered source</returns>
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
            System.Web.ModelBinding.ModelMetadata Meta = null;

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

                if (Meta.ModelType.HasInterface(typeof(IModel), false))
                    {
                    // Relation fields drill into the sub-model to filter
                    // Use the default field since no field was given

                    DisplayColumnAttribute Attr = Meta.ModelType.GetAttribute<DisplayColumnAttribute>();

                    String SearchColumn = null;
                    if (Attr != null)
                        {
                        // Use the DisplayColumn
                        SearchColumn = Attr.DisplayColumn;
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

            FilterAction<T> Filter = new FilterAction<T>(Query, Operation, Accessor, Meta);

            Query = Filter.PerformAction(Meta.ModelType);

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
        }
    }