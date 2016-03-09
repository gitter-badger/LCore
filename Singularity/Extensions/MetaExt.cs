using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using LCore;
using System.Web.Mvc;
using Singularity.Models;

namespace Singularity.Extensions
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

        public static ModelMetadata Meta(this Type t, String PropertyName = null)
            {
            t = t.WithoutDynamicType();

            if (!String.IsNullOrEmpty(PropertyName))
                {
                if (PropertyName.Contains("."))
                    {
                    return ModelMetadataProviders.Current.GetMetadataForProperty(null, t, PropertyName.Split(".")[1]);
                    }
                else
                    {
                    return ModelMetadataProviders.Current.GetMetadataForProperty(null, t, PropertyName);

                    }
                }
            else
                return ModelMetadataProviders.Current.GetMetadataForType(null, t);
            }

        public static ModelMetadata Meta(this TypeInfo t, String PropertyName = null)
            {
            if (!String.IsNullOrEmpty(PropertyName))
                {
                if (PropertyName.Contains("."))
                    {
                    return ModelMetadataProviders.Current.GetMetadataForProperty(null, t, PropertyName.Split(".")[1]);
                    }
                else
                    {
                    return ModelMetadataProviders.Current.GetMetadataForProperty(null, t, PropertyName);

                    }
                }
            else
                return ModelMetadataProviders.Current.GetMetadataForType(null, t);
            }

        public static ModelMetadata Meta<T>(this T Model, Expression<Func<T, Object>> Expression)
            where T : IModel
            {
            return Model.Meta((Expression.Body as MemberExpression).Member.Name);
            }
        public static ModelMetadata Meta<T>(this T Model, String PropertyName = null)
            where T : IModel
            {
            if (String.IsNullOrEmpty(PropertyName))
                return ModelMetadataProviders.Current.GetMetadataForType(null, Model.TrueModelType());
            else
                return Model.Property(PropertyName);
            }

        public static IEnumerable<ModelMetadata> Properties<T>(this T Model)
            where T : IModel
            {
            return Model.Meta().Properties;
            }

        public static ModelMetadata Property<T>(this T Model, Expression<Func<T, Object>> Expression)
            where T : IModel
            {
            return Model.Meta((Expression.Body as MemberExpression).Member.Name);
            }
        public static ModelMetadata Property<T>(this T Model, String PropertyName)
            where T : IModel
            {
            return ModelMetadataProviders.Current.GetMetadataForProperty(null, Model.TrueModelType(), PropertyName);
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

        public static LambdaExpression GetExpression(this Type t, String PropertyName)
            {
            ParameterExpression param = Expression.Parameter(t, string.Empty);
            MemberExpression property = Expression.PropertyOrField(param, PropertyName);
            LambdaExpression Expr = Expression.Lambda(property, param);

            return Expr;
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


        public static Dictionary<String, ModelMetadata> GetMeta(this Type t,
            Func<ModelMetadata, Boolean> Selector = null,
            int Levels = 0)
            {
            Dictionary<String, ModelMetadata> Out = new Dictionary<string, ModelMetadata>();

            Out = GetMeta(t, Out, Selector, Levels, 0);

            return Out;
            }
        private static Dictionary<String, ModelMetadata> GetMeta(this Type t,
            Dictionary<String, ModelMetadata> In,
            Func<ModelMetadata, Boolean> Selector = null,
            int Levels = 0,
            int CurrentLevel = 0,
            String PathString = "")
            {
            if (In == null)
                In = new Dictionary<string, ModelMetadata>();

            if (Levels != 0 && Levels < CurrentLevel)
                return In;

            if (Selector == null)
                Selector = (m) => { return true; };

            ModelMetadata[] TypeMeta = t.Meta().Properties.Array();

            TypeMeta.Each((meta) =>
            {
                String KeyString = String.IsNullOrEmpty(PathString) ? meta.PropertyName : PathString + "." + meta.PropertyName;

                if (!In.ContainsKey(KeyString))
                    In[KeyString] = meta;

                if (!Selector(meta))
                    return;

                if (KeyString.Contains("." + meta.PropertyName + "."))
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

        public static MemberHelper<T> Type<T>()
            {
            return new MemberHelper<T>();
            }

        public static String Name<T>(Expression<Func<T, Object>> Expression)
            {
            return MetaExt.Type<T>().Name(Expression);
            }

        public class MemberHelper<T>
            {
            public MemberHelper()
                {
                }

            public String Name(Expression<Func<T, Action>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1>(Expression<Func<T, Action<A1>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2>(Expression<Func<T, Action<A1, A2>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3>(Expression<Func<T, Action<A1, A2, A3>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, A4>(Expression<Func<T, Action<A1, A2, A3, A4>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, A4, A5>(Expression<Func<T, Action<A1, A2, A3, A4, A5>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, A4, A5, A6>(Expression<Func<T, Action<A1, A2, A3, A4, A5, A6>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, A4, A5, A6, A7>(Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, A4, A5, A6, A7, A8>(Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, A4, A5, A6, A7, A8, A9>(Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10>(Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11>(Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12>(Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13>(Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14>(Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15>(Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16>(Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }

            public String Name<U>(Expression<Func<T, Func<U>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, U>(Expression<Func<T, Func<A1, U>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, U>(Expression<Func<T, Func<A1, A2, U>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, U>(Expression<Func<T, Func<A1, A2, A3, U>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, A4, U>(Expression<Func<T, Func<A1, A2, A3, A4, U>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, A4, A5, U>(Expression<Func<T, Func<A1, A2, A3, A4, A5, U>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, A4, A5, A6, U>(Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, U>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, A4, A5, A6, A7, U>(Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, U>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, A4, A5, A6, A7, A8, U>(Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, U>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, A4, A5, A6, A7, A8, A9, U>(Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, U>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, U>(Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, U>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, U>(Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, U>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, U>(Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, U>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, U>(Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, U>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, U>(Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, U>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, U>(Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, U>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }
            public String Name<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16, U>(Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16, U>>> Expression)
                {
                return Name((LambdaExpression)Expression);
                }

            public String Name(LambdaExpression Expression)
                {
                if (Expression.Body == null || !(Expression.Body is MemberExpression))
                    return null;

                if (Expression.Body is MemberExpression)
                    {
                    return (Expression.Body as MemberExpression).Member.Name;
                    }
                else if (Expression.Body is MethodCallExpression)
                    {
                    return (Expression.Body as MethodCallExpression).Method.Name;
                    }
                else
                    {
                    return "";
                    }
                }
            }


        public static LambdaExpression GetTokenExpression(this Type ModelType, String Token, out ModelMetadata Meta)
            {
            Token = Token ?? "";

            if (Token.StartsWith("["))
                Token = Token.Substring(1);

            if (Token.EndsWith("]"))
                Token = Token.Substring(0, Token.Length - 1);

            String[] FullProperty;

            LambdaExpression Lambda = ModelType.FindSubProperty(out Meta, out FullProperty, Token.Split('.'));

            ParameterExpression Param = Lambda.Parameters[0];
            Expression AsObject = Expression.TypeAs(Lambda.Body, typeof(Object));
            LambdaExpression Lambda2 = Expression.Lambda(AsObject, Param);

            ParameterExpression Param2 = Expression.Parameter(typeof(Object), "b");
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