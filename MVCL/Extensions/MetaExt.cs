using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.ModelBinding;
using LCore;

namespace MVCL
    {
    public static class MetaExt
        {
        public static Type PreferGeneric(this Type t)
            {
            if (t.IsGenericType)
                return t.GetGenericArguments()[0];
            else
                return t;
            }

        public static Boolean IsNullable(this Type t)
            {
            return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>);

            //    return t.Name == "Nullable" || t.Name == "Nullable`1";
            }

        public static System.Web.ModelBinding.ModelMetadata Meta(this Type t, String PropertyName = null)
            {
            t = t.WithoutDynamicType();

            if (!String.IsNullOrEmpty(PropertyName))
                {
                if (PropertyName.Contains("."))
                    {
                    return System.Web.ModelBinding.ModelMetadataProviders.Current.GetMetadataForProperty(null, t, PropertyName.Split(".")[1]);
                    }
                else
                    {
                    return System.Web.ModelBinding.ModelMetadataProviders.Current.GetMetadataForProperty(null, t, PropertyName);

                    }
                }
            else
                return System.Web.ModelBinding.ModelMetadataProviders.Current.GetMetadataForType(null, t);
            }

        public static System.Web.ModelBinding.ModelMetadata Meta(this TypeInfo t, String PropertyName = null)
            {
            if (!String.IsNullOrEmpty(PropertyName))
                {
                if (PropertyName.Contains("."))
                    {
                    return System.Web.ModelBinding.ModelMetadataProviders.Current.GetMetadataForProperty(null, t, PropertyName.Split(".")[1]);
                    }
                else
                    {
                    return System.Web.ModelBinding.ModelMetadataProviders.Current.GetMetadataForProperty(null, t, PropertyName);

                    }
                }
            else
                return System.Web.ModelBinding.ModelMetadataProviders.Current.GetMetadataForType(null, t);
            }

        public static System.Web.ModelBinding.ModelMetadata Meta<T>(this T Model, Expression<Func<T, Object>> Expression)
            where T : IModel
            {
            return Model.Meta((Expression.Body as MemberExpression).Member.Name);
            }
        public static System.Web.ModelBinding.ModelMetadata Meta<T>(this T Model, String PropertyName = null)
            where T : IModel
            {
            if (String.IsNullOrEmpty(PropertyName))
                return System.Web.ModelBinding.ModelMetadataProviders.Current.GetMetadataForType(null, Model.TrueModelType());
            else
                return Model.Property(PropertyName);
            }

        public static IEnumerable<System.Web.ModelBinding.ModelMetadata> Properties<T>(this T Model)
            where T : IModel
            {
            return Model.Meta().Properties;
            }

        public static System.Web.ModelBinding.ModelMetadata Property<T>(this T Model, Expression<Func<T, Object>> Expression)
            where T : IModel
            {
            return Model.Meta((Expression.Body as MemberExpression).Member.Name);
            }
        public static System.Web.ModelBinding.ModelMetadata Property<T>(this T Model, String PropertyName)
            where T : IModel
            {
            return System.Web.ModelBinding.ModelMetadataProviders.Current.GetMetadataForProperty(null, Model.TrueModelType(), PropertyName);
            }

        public static Expression GetPropertyExpression(this ModelMetadata Meta)
            {
            if (String.IsNullOrEmpty(Meta.PropertyName))
                throw new ArgumentNullException("Meta");

            ParameterExpression param = Expression.Parameter(Meta.ModelType, string.Empty);
            MemberExpression property = Expression.PropertyOrField(param, Meta.PropertyName);
            LambdaExpression Out = Expression.Lambda(property, param);

            return Out;
            }

        public static LambdaExpression GetExpression(this ModelMetadata Meta)
            {
            if (String.IsNullOrEmpty(Meta.PropertyName))
                throw new ArgumentNullException("Meta");

            ParameterExpression param = Expression.Parameter(Meta.ContainerType, string.Empty);
            MemberExpression property = Expression.PropertyOrField(param, Meta.PropertyName);
            LambdaExpression Expr = Expression.Lambda(property, param);

            return Expr;
            }

        public static LambdaExpression FindSubProperty(this Type t, out ModelMetadata Meta, out String[] FullProperties, params String[] Properties)
            {
            ParameterExpression Param = Expression.Parameter(t, string.Empty);
            MemberExpression Member = null;
            Type CurrentType = t;

            FullProperties = new String[Properties.Length];

            for (int i = 0; i < Properties.Length; i++)
                {
                FullProperties[i] = CurrentType.SearchForProperty(Properties[i]);

                if (Member == null)
                    {
                    Member = Expression.PropertyOrField(Param, FullProperties[i]);
                    }
                else
                    {
                    Member = Expression.PropertyOrField(Member, FullProperties[i]);
                    }


                if (i < Properties.Length - 1)
                    CurrentType = Member.Type;

                }

            Meta = CurrentType.Meta(FullProperties[FullProperties.Length - 1]);

            LambdaExpression Out = Expression.Lambda(Member, Param);

            return Out;
            }

        public static Expression<Func<T, Boolean>> GetOperatorExpression<T>(this ModelMetadata Meta, Func<Expression, Expression, Expression> Operator, Object Value)
            {
            ParameterExpression param = Expression.Parameter(typeof(T), string.Empty);
            MemberExpression property = Expression.PropertyOrField(param, Meta.PropertyName);

            LambdaExpression Lambda = Expression.Lambda(property, param);

            return Lambda.GetOperatorExpression<T>(Operator, Value);
            }
        public static Expression<Func<T, Boolean>> GetOperatorExpression<T>(this LambdaExpression Lambda, Func<Expression, Expression, Expression> Operator, Object Value)
            {
            Expression compare = null;

            if (Lambda.Body.Type.IsNullable())
                {
                compare = Expression.Convert(Expression.Constant(Value), Lambda.Body.Type);
                }
            else
                {
                compare = Expression.Constant(Value);
                }

            Expression<Func<T, Boolean>> Expr = Expression.Lambda<Func<T, Boolean>>(Operator(Lambda.Body, compare), Lambda.Parameters[0]);

            return Expr;
            }

        public static Boolean HasProperty(this Type t, String PropertyName)
            {
            return t.GetProperty(PropertyName) != null;
            }

        public static Expression<Func<T, U>> GetExpression<T, U>(this Type t, String PropertyName)
            {
            ParameterExpression param = Expression.Parameter(t, string.Empty);
            MemberExpression property = Expression.PropertyOrField(param, PropertyName);
            Expression<Func<T, U>> Expr = Expression.Lambda<Func<T, U>>(property, param);

            return Expr;
            }


        public static Expression<Func<T, U>> GetExpression<T, U>(this ModelMetadata Meta)
            {
            ParameterExpression param = Expression.Parameter(typeof(T), string.Empty);
            MemberExpression property = Expression.PropertyOrField(param, Meta.PropertyName);
            Expression<Func<T, U>> Expr = Expression.Lambda<Func<T, U>>(property, param);

            return Expr;
            }

        public static Func<T, U> GetFunc<T, U>(this ModelMetadata Meta)
            {
            return Meta.GetExpression<T, U>().Compile();
            }

        public static Func<Object, Object> GetFunc(this ModelMetadata Meta)
            {
            ParameterExpression param = Expression.Parameter(typeof(Object), string.Empty);
            UnaryExpression property = Expression.TypeAs(Expression.PropertyOrField(Expression.TypeAs(param, Meta.ContainerType), Meta.PropertyName), typeof(Object));
            Expression<Func<Object, Object>> Expr = Expression.Lambda<Func<Object, Object>>(property, param);

            return Expr.Compile();
            }

        public static Delegate GetDelegate(this ModelMetadata Meta)
            {
            return Meta.GetExpression().Compile();
            }

        public static MemberInfo GetMember(this ModelMetadata Meta)
            {
            if (String.IsNullOrEmpty(Meta.PropertyName))
                {
                return Meta.ModelType;
                }
            else
                {
                ParameterExpression param = Expression.Parameter(Meta.ContainerType, string.Empty);
                MemberExpression property = Expression.PropertyOrField(param, Meta.PropertyName);
                return property.Member;
                }
            }

        public static Boolean HasAttribute<T>(this ModelMetadata Meta)
            {
            return Meta.GetMember().MemberHasAttribute<T>(false);
            }

        public static T GetAttribute<T>(this ModelMetadata Meta)
            {
            return Meta.GetMember().MemberGetAttribute<T>(false);
            }

        public static List<T> GetAttributes<T>(this ModelMetadata Meta)
            where T : class
            {
            return Meta.GetMember().MemberGetAttributes<T>(false);
            }


        public static Expression<Func<T, Boolean>> ExpressionWithin<T, U>(this ModelMetadata Meta, U Min, U Max)
            {
            ParameterExpression param = Expression.Parameter(typeof(T), string.Empty);
            MemberExpression member = Expression.PropertyOrField(param, Meta.PropertyName);


            LambdaExpression Lambda = Expression.Lambda<Func<T, Boolean>>(member, param);
            Expression<Func<T, Boolean>> Out = Lambda.ExpressionWithin<T, U>(Min, Max);

            return Out;
            }

        public static Expression<Func<T, Boolean>> ExpressionWithin<T, U>(this LambdaExpression Member, U Min, U Max)
            {
            Expression const1 = Expression.Constant((U)Min);
            Expression const2 = Expression.Constant((U)Max);


            if (Member.Body.Type.IsNullable())
                {
                UnaryExpression Member2 = Expression.Convert(Member.Body, Member.Body.Type.PreferGeneric());

                //  const1 = Expression.Convert(const1, Member.Type);
                //  const2 = Expression.Convert(const2, Member.Type);

                BinaryExpression expr = Expression.And(
                    Expression.GreaterThanOrEqual(Member2, const1),
                    Expression.LessThanOrEqual(Member2, const2));

                Expression<Func<T, Boolean>> condition = Expression.Lambda<Func<T, Boolean>>(expr, Member.Parameters[0]);

                return condition;
                }
            else
                {
                BinaryExpression expr = Expression.And(
                    Expression.GreaterThanOrEqual(Member.Body, const1),
                    Expression.LessThanOrEqual(Member.Body, const2));

                Expression<Func<T, Boolean>> condition = Expression.Lambda<Func<T, Boolean>>(expr, Member.Parameters[0]);

                return condition;
                }
            }

        public static Expression<Func<T, Boolean>> ExpressionWithout<T, U>(this ModelMetadata Meta, U Min, U Max)
            {
            ParameterExpression param = Expression.Parameter(typeof(T), string.Empty);
            MemberExpression member = Expression.PropertyOrField(param, Meta.PropertyName);

            LambdaExpression Lambda = Expression.Lambda<Func<T, Boolean>>(member, param);
            Expression<Func<T, Boolean>> Out = Lambda.ExpressionWithout<T, U>(Min, Max);

            return Out;
            }

        public static Expression<Func<T, Boolean>> ExpressionWithout<T, U>(this LambdaExpression Member, U Min, U Max)
            {
            Expression const1 = Expression.Constant(Min);
            Expression const2 = Expression.Constant(Max);

            if (Member.Type.IsNullable())
                {
                const1 = Expression.Convert(const1, Member.Body.Type);
                const2 = Expression.Convert(const2, Member.Body.Type);
                }

            BinaryExpression expr = Expression.Or(
                Expression.LessThanOrEqual(Member, const1),
                Expression.GreaterThanOrEqual(Member, const2));

            Expression<Func<T, Boolean>> condition = Expression.Lambda<Func<T, Boolean>>(expr, Member.Parameters[0]);

            return condition;
            }

        public static String Name<TIn, TOut>(this Expression<Func<TIn, TOut>> Expression)
            {
            if (Expression.Body == null || !(Expression.Body is MemberExpression))
                return null;

            return (Expression.Body as MemberExpression).Member.Name;
            }
        }
    public static class ExprExt
        {
        public static Expression<Func<TIn, TOut>> Expr<TIn, TOut>(this Expression<Func<TIn, TOut>> Exp)
            {
            return Exp;
            }
        }
    }