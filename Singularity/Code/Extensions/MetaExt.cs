using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using LCore.Extensions;

using System.Web.Mvc;
using Singularity.Models;

namespace Singularity.Extensions
    {
    public static class MetaExt
        {
        public static Type PreferGeneric(this Type t)
            {
            return t.IsGenericType ? t.GetGenericArguments()[0] : t;
            }

        public static bool IsNullable(this Type t)
            {
            return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>);

            //    return t.Name == "Nullable" || t.Name == "Nullable`1";
            }

        public static ModelMetadata Meta(this Type t, string PropertyName = null)
            {
            t = t.WithoutDynamicType();

            return !string.IsNullOrEmpty(PropertyName) ? ModelMetadataProviders.Current.GetMetadataForProperty(null, t, PropertyName.Contains(".") ? PropertyName.Split(".")[1] : PropertyName) : ModelMetadataProviders.Current.GetMetadataForType(null, t);
            }

        public static ModelMetadata Meta(this TypeInfo t, string PropertyName = null)
            {
            return !string.IsNullOrEmpty(PropertyName) ? ModelMetadataProviders.Current.GetMetadataForProperty(null, t, PropertyName.Contains(".") ? PropertyName.Split(".")[1] : PropertyName) : ModelMetadataProviders.Current.GetMetadataForType(null, t);
            }

        public static ModelMetadata Meta<T>(this T Model, Expression<Func<T, object>> Expression)
            where T : IModel
            {
            return Model.Meta((Expression.Body as MemberExpression)?.Member.Name);
            }
        public static ModelMetadata Meta<T>(this T Model, string PropertyName = null)
            where T : IModel
            {
            return string.IsNullOrEmpty(PropertyName) ? ModelMetadataProviders.Current.GetMetadataForType(null, Model.TrueModelType()) : Model.Property(PropertyName);
            }

        public static IEnumerable<ModelMetadata> Properties<T>(this T Model)
            where T : IModel
            {
            return Model.Meta().Properties;
            }

        public static ModelMetadata Property<T>(this T Model, Expression<Func<T, object>> Expression)
            where T : IModel
            {
            return Model.Meta((Expression.Body as MemberExpression)?.Member.Name);
            }
        public static ModelMetadata Property<T>(this T Model, string PropertyName)
            where T : IModel
            {
            return ModelMetadataProviders.Current.GetMetadataForProperty(null, Model.TrueModelType(), PropertyName);
            }

        public static Expression GetPropertyExpression(this ModelMetadata Meta)
            {
            if (string.IsNullOrEmpty(Meta.PropertyName))
                throw new ArgumentNullException(nameof(Meta));

            ParameterExpression param = Expression.Parameter(Meta.ModelType, string.Empty);
            MemberExpression property = Expression.PropertyOrField(param, Meta.PropertyName);
            LambdaExpression Out = Expression.Lambda(property, param);

            return Out;
            }

        public static LambdaExpression GetExpression(this ModelMetadata Meta)
            {
            if (string.IsNullOrEmpty(Meta.PropertyName))
                throw new ArgumentNullException(nameof(Meta));

            ParameterExpression param = Expression.Parameter(Meta.ContainerType, string.Empty);
            MemberExpression property = Expression.PropertyOrField(param, Meta.PropertyName);
            LambdaExpression Expr = Expression.Lambda(property, param);

            return Expr;
            }

        public static LambdaExpression FindSubProperty(this Type t, out ModelMetadata Meta, out string[] FullProperties, params string[] Properties)
            {
            ParameterExpression Param = Expression.Parameter(t, string.Empty);
            MemberExpression Member = null;
            Type CurrentType = t;

            FullProperties = new string[Properties.Length];

            for (int i = 0; i < Properties.Length; i++)
                {
                FullProperties[i] = CurrentType.SearchForProperty(Properties[i]);

                Member = Member == null ?
                    Expression.PropertyOrField(Param, FullProperties[i]) :
                    Expression.PropertyOrField(Member, FullProperties[i]);


                if (i < Properties.Length - 1)
                    CurrentType = Member.Type;

                }

            Meta = CurrentType.Meta(FullProperties[FullProperties.Length - 1]);

            if (Member != null)
                {
                LambdaExpression Out = Expression.Lambda(Member, Param);

                return Out;
                }
            return null;
            }

        public static Expression<Func<T, bool>> GetOperatorExpression<T>(this ModelMetadata Meta, Func<Expression, Expression, Expression> Operator, object Value)
            {
            ParameterExpression param = Expression.Parameter(typeof(T), string.Empty);
            MemberExpression property = Expression.PropertyOrField(param, Meta.PropertyName);

            LambdaExpression Lambda = Expression.Lambda(property, param);

            return Lambda.GetOperatorExpression<T>(Operator, Value);
            }
        public static Expression<Func<T, bool>> GetOperatorExpression<T>(this LambdaExpression Lambda, Func<Expression, Expression, Expression> Operator, object Value)
            {
            Expression compare;

            if (Lambda.Body.Type.IsNullable())
                {
                compare = Expression.Convert(Expression.Constant(Value), Lambda.Body.Type);
                }
            else
                {
                compare = Expression.Constant(Value);
                }

            Expression<Func<T, bool>> Expr = Expression.Lambda<Func<T, bool>>(Operator(Lambda.Body, compare), Lambda.Parameters[0]);

            return Expr;
            }

        public static bool HasProperty(this Type t, string PropertyName)
            {
            return t.GetProperty(PropertyName) != null;
            }

        public static LambdaExpression GetExpression(this Type t, string PropertyName)
            {
            ParameterExpression param = Expression.Parameter(t, string.Empty);
            MemberExpression property = Expression.PropertyOrField(param, PropertyName);
            LambdaExpression Expr = Expression.Lambda(property, param);

            return Expr;
            }

        public static Expression<Func<T, U>> GetExpression<T, U>(this Type t, string PropertyName)
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

        public static Func<object, object> GetFunc(this ModelMetadata Meta)
            {
            ParameterExpression param = Expression.Parameter(typeof(object), string.Empty);
            UnaryExpression property = Expression.TypeAs(Expression.PropertyOrField(Expression.TypeAs(param, Meta.ContainerType), Meta.PropertyName), typeof(object));
            Expression<Func<object, object>> Expr = Expression.Lambda<Func<object, object>>(property, param);

            return Expr.Compile();
            }

        public static Delegate GetDelegate(this ModelMetadata Meta)
            {
            return Meta.GetExpression().Compile();
            }

        public static MemberInfo GetMember(this ModelMetadata Meta)
            {
            if (string.IsNullOrEmpty(Meta.PropertyName))
                {
                return Meta.ModelType;
                }
            ParameterExpression param = Expression.Parameter(Meta.ContainerType, string.Empty);
            MemberExpression property = Expression.PropertyOrField(param, Meta.PropertyName);
            return property.Member;
            }

        public static bool HasAttribute<T>(this ModelMetadata Meta)
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


        public static Dictionary<string, ModelMetadata> GetMeta(this Type t,
            Func<ModelMetadata, bool> Selector = null,
            int Levels = 0)
            {
            Dictionary<string, ModelMetadata> Out = new Dictionary<string, ModelMetadata>();

            Out = GetMeta(t, Out, Selector, Levels);

            return Out;
            }
        private static Dictionary<string, ModelMetadata> GetMeta(this Type t,
            Dictionary<string, ModelMetadata> In,
            Func<ModelMetadata, bool> Selector = null,
            int Levels = 0,
            int CurrentLevel = 0,
            string PathString = "")
            {
            if (In == null)
                In = new Dictionary<string, ModelMetadata>();

            if (Levels != 0 && Levels < CurrentLevel)
                return In;

            if (Selector == null)
                Selector = m => true;

            ModelMetadata[] TypeMeta = t.Meta().Properties.Array();

            TypeMeta.Each(meta =>
            {
                string KeyString = string.IsNullOrEmpty(PathString) ? meta.PropertyName :
                    $"{PathString}.{meta.PropertyName}";

                if (!In.ContainsKey(KeyString))
                    In[KeyString] = meta;

                if (!Selector(meta))
                    return;

                if (KeyString.Contains($".{meta.PropertyName}."))
                    {
                    // Avoids recursive lookups
                    }
                else if (meta.ModelType.HasInterface<IModel>())
                    {
                    In = meta.ModelType.GetMeta(In, Selector, Levels, CurrentLevel + 1, KeyString);
                    }
            });

            return In;
            }

        public static Expression<Func<T, bool>> ExpressionWithin<T, U>(this ModelMetadata Meta, U Min, U Max)
            {
            ParameterExpression param = Expression.Parameter(typeof(T), string.Empty);
            MemberExpression member = Expression.PropertyOrField(param, Meta.PropertyName);


            LambdaExpression Lambda = Expression.Lambda<Func<T, bool>>(member, param);
            Expression<Func<T, bool>> Out = Lambda.ExpressionWithin<T, U>(Min, Max);

            return Out;
            }

        public static Expression<Func<T, bool>> ExpressionWithin<T, U>(this LambdaExpression Member, U Min, U Max)
            {
            Expression const1 = Expression.Constant(Min);
            Expression const2 = Expression.Constant(Max);


            if (Member.Body.Type.IsNullable())
                {
                UnaryExpression Member2 = Expression.Convert(Member.Body, Member.Body.Type.PreferGeneric());

                //  const1 = Expression.Convert(const1, Member.Type);
                //  const2 = Expression.Convert(const2, Member.Type);

                BinaryExpression expr = Expression.And(
                    Expression.GreaterThanOrEqual(Member2, const1),
                    Expression.LessThanOrEqual(Member2, const2));

                Expression<Func<T, bool>> condition = Expression.Lambda<Func<T, bool>>(expr, Member.Parameters[0]);

                return condition;
                }
            else
                {
                BinaryExpression expr = Expression.And(
                    Expression.GreaterThanOrEqual(Member.Body, const1),
                    Expression.LessThanOrEqual(Member.Body, const2));

                Expression<Func<T, bool>> condition = Expression.Lambda<Func<T, bool>>(expr, Member.Parameters[0]);

                return condition;
                }
            }

        public static Expression<Func<T, bool>> ExpressionWithout<T, U>(this ModelMetadata Meta, U Min, U Max)
            {
            ParameterExpression param = Expression.Parameter(typeof(T), string.Empty);
            MemberExpression member = Expression.PropertyOrField(param, Meta.PropertyName);

            LambdaExpression Lambda = Expression.Lambda<Func<T, bool>>(member, param);
            Expression<Func<T, bool>> Out = Lambda.ExpressionWithout<T, U>(Min, Max);

            return Out;
            }

        public static Expression<Func<T, bool>> ExpressionWithout<T, U>(this LambdaExpression Member, U Min, U Max)
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

            Expression<Func<T, bool>> condition = Expression.Lambda<Func<T, bool>>(expr, Member.Parameters[0]);

            return condition;
            }

        public static LambdaExpression GetTokenExpression(this Type ModelType, string Token, out ModelMetadata Meta)
            {
            Token = Token ?? "";

            if (Token.StartsWith("["))
                Token = Token.Substring(1);

            if (Token.EndsWith("]"))
                Token = Token.Substring(0, Token.Length - 1);

            string[] FullProperty;

            LambdaExpression Lambda = ModelType.FindSubProperty(out Meta, out FullProperty, Token.Split('.'));

            ParameterExpression Param = Lambda.Parameters[0];
            Expression AsObject = Expression.TypeAs(Lambda.Body, typeof(object));
            LambdaExpression Lambda2 = Expression.Lambda(AsObject, Param);

            ParameterExpression Param2 = Expression.Parameter(typeof(object), "b");
            Expression AsT = Expression.TypeAs(Param2, ModelType);

            InvocationExpression Invoke = Expression.Invoke(Lambda2, AsT);
            LambdaExpression Lambda3 = Expression.Lambda(Invoke, Param2);

            return Lambda3;
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