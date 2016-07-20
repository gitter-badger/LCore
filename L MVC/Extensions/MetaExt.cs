using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using LCore.Extensions;

using System.Web.Mvc;
using LCore.Interfaces;
using LMVC.Models;

namespace LMVC.Extensions
    {
    [ExtensionProvider]
    public static class MetaExt
        {
        #region Extensions +

        #region ModelMetadata +

        #region ExpressionWithin

        public static Expression<Func<T, bool>> ExpressionWithin<T, U>(this ModelMetadata Meta, U Min, U Max)
            {
            var Param = Expression.Parameter(typeof(T), string.Empty);
            var Member = Expression.PropertyOrField(Param, Meta.PropertyName);


            LambdaExpression Lambda = Expression.Lambda<Func<T, bool>>(Member, Param);
            Expression<Func<T, bool>> Out = Lambda.ExpressionWithin<T, U>(Min, Max);

            return Out;
            }

        public static Expression<Func<T, bool>> ExpressionWithin<T, U>(this LambdaExpression Member, U Min, U Max)
            {
            Expression Const1 = Expression.Constant(Min);
            Expression Const2 = Expression.Constant(Max);


            if (Member.Body.Type.IsNullable())
                {
                var Member2 = Expression.Convert(Member.Body, Member.Body.Type.PreferGeneric());

                //  const1 = Expression.Convert(const1, Member.Type);
                //  const2 = Expression.Convert(const2, Member.Type);

                var Expr = Expression.And(
                    Expression.GreaterThanOrEqual(Member2, Const1),
                    Expression.LessThanOrEqual(Member2, Const2));

                Expression<Func<T, bool>> Condition = Expression.Lambda<Func<T, bool>>(Expr, Member.Parameters[0]);

                return Condition;
                }
            var Expr2 = Expression.And(
                Expression.GreaterThanOrEqual(Member.Body, Const1),
                Expression.LessThanOrEqual(Member.Body, Const2));

            Expression<Func<T, bool>> Condition2 = Expression.Lambda<Func<T, bool>>(Expr2, Member.Parameters[0]);

            return Condition2;
            }

        #endregion

        #region ExpressionWithout

        public static Expression<Func<T, bool>> ExpressionWithout<T, U>(this ModelMetadata Meta, U Min, U Max)
            {
            var Param = Expression.Parameter(typeof(T), string.Empty);
            var Member = Expression.PropertyOrField(Param, Meta.PropertyName);

            LambdaExpression Lambda = Expression.Lambda<Func<T, bool>>(Member, Param);
            Expression<Func<T, bool>> Out = Lambda.ExpressionWithout<T, U>(Min, Max);

            return Out;
            }

        public static Expression<Func<T, bool>> ExpressionWithout<T, U>(this LambdaExpression Member, U Min, U Max)
            {
            Expression Const1 = Expression.Constant(Min);
            Expression Const2 = Expression.Constant(Max);

            if (Member.Type.IsNullable())
                {
                Const1 = Expression.Convert(Const1, Member.Body.Type);
                Const2 = Expression.Convert(Const2, Member.Body.Type);
                }

            var Expr = Expression.Or(
                Expression.LessThanOrEqual(Member, Const1),
                Expression.GreaterThanOrEqual(Member, Const2));

            Expression<Func<T, bool>> Condition = Expression.Lambda<Func<T, bool>>(Expr, Member.Parameters[0]);

            return Condition;
            }

        #endregion

        #region GetAttribute

        public static T GetAttribute<T>(this ModelMetadata Meta)
            where T : IPersistAttribute
            {
            return Meta.GetMember().GetAttribute<T>();
            }

        public static T GetAttribute<T>(this ModelMetadata Meta, bool IncludeBaseTypes)
            {
            return Meta.GetMember().GetAttribute<T>(IncludeBaseTypes);
            }

        public static List<T> GetAttributes<T>(this ModelMetadata Meta)
            where T : class
            {
            return Meta.GetMember().GetAttributes<T>(false);
            }

        #endregion

        #region GetDelegate

        public static Delegate GetDelegate(this ModelMetadata Meta)
            {
            return Meta.GetExpression().Compile();
            }

        #endregion

        #region GetExpression

        public static LambdaExpression GetExpression(this ModelMetadata Meta)
            {
            if (string.IsNullOrEmpty(Meta.PropertyName))
                throw new ArgumentNullException(nameof(Meta));

            var Param = Expression.Parameter(Meta.ContainerType, string.Empty);
            var Property = Expression.PropertyOrField(Param, Meta.PropertyName);
            var Expr = Expression.Lambda(Property, Param);

            return Expr;
            }

        public static Expression<Func<T, U>> GetExpression<T, U>(this ModelMetadata Meta)
            {
            var Param = Expression.Parameter(typeof(T), string.Empty);
            var Property = Expression.PropertyOrField(Param, Meta.PropertyName);
            Expression<Func<T, U>> Expr = Expression.Lambda<Func<T, U>>(Property, Param);

            return Expr;
            }

        #endregion

        #region GetFunc

        public static Func<T, U> GetFunc<T, U>(this ModelMetadata Meta)
            {
            return Meta.GetExpression<T, U>().Compile();
            }

        public static Func<object, object> GetFunc(this ModelMetadata Meta)
            {
            var Param = Expression.Parameter(typeof(object), string.Empty);
            var Property =
                Expression.TypeAs(
                    Expression.PropertyOrField(Expression.TypeAs(Param, Meta.ContainerType), Meta.PropertyName),
                    typeof(object));
            Expression<Func<object, object>> Expr = Expression.Lambda<Func<object, object>>(Property, Param);

            return Expr.Compile();
            }

        #endregion

        #region GetMember

        public static MemberInfo GetMember(this ModelMetadata Meta)
            {
            if (string.IsNullOrEmpty(Meta.PropertyName))
                {
                return Meta.ModelType;
                }
            var Param = Expression.Parameter(Meta.ContainerType, string.Empty);
            var Property = Expression.PropertyOrField(Param, Meta.PropertyName);
            return Property.Member;
            }

        #endregion

        #region GetMeta

        public static Dictionary<string, ModelMetadata> GetMeta(this Type Type,
            Func<ModelMetadata, bool> Selector = null,
            int Levels = 0)
            {
            var Out = new Dictionary<string, ModelMetadata>();

            Out = GetMeta(Type, Out, Selector, Levels);

            return Out;
            }

        private static Dictionary<string, ModelMetadata> GetMeta(this Type Type,
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
                Selector = Member => true;

            ModelMetadata[] TypeMeta = Type.Meta().Properties.Array();

            TypeMeta.Each(Meta =>
                {
                    string KeyString = string.IsNullOrEmpty(PathString)
                        ? Meta.PropertyName
                        : $"{PathString}.{Meta.PropertyName}";

                    if (!In.ContainsKey(KeyString))
                        In[KeyString] = Meta;

                    if (!Selector(Meta))
                        return;

                    if (KeyString.Contains($".{Meta.PropertyName}."))
                        {
                        // Avoids recursive lookups
                        }
                    else if (Meta.ModelType.HasInterface<IModel>())
                        {
                        In = Meta.ModelType.GetMeta(In, Selector, Levels, CurrentLevel + 1, KeyString);
                        }
                });

            return In;
            }

        #endregion

        #region GetOperatorExpression

        public static Expression<Func<T, bool>> GetOperatorExpression<T>(this ModelMetadata Meta,
            Func<Expression, Expression, Expression> Operator, object Value)
            {
            var Param = Expression.Parameter(typeof(T), string.Empty);
            var Property = Expression.PropertyOrField(Param, Meta.PropertyName);

            var Lambda = Expression.Lambda(Property, Param);

            return Lambda.GetOperatorExpression<T>(Operator, Value);
            }

        public static Expression<Func<T, bool>> GetOperatorExpression<T>(this LambdaExpression Lambda,
            Func<Expression, Expression, Expression> Operator, object Value)
            {
            Expression Compare;

            if (Lambda.Body.Type.IsNullable())
                {
                Compare = Expression.Convert(Expression.Constant(Value), Lambda.Body.Type);
                }
            else
                {
                Compare = Expression.Constant(Value);
                }

            Expression<Func<T, bool>> Expr = Expression.Lambda<Func<T, bool>>(Operator(Lambda.Body, Compare),
                Lambda.Parameters[0]);

            return Expr;
            }

        #endregion

        #region GetPropertyExpression

        public static Expression GetPropertyExpression(this ModelMetadata Meta)
            {
            if (string.IsNullOrEmpty(Meta.PropertyName))
                throw new ArgumentNullException(nameof(Meta));

            var Param = Expression.Parameter(Meta.ModelType, string.Empty);
            var Property = Expression.PropertyOrField(Param, Meta.PropertyName);
            var Out = Expression.Lambda(Property, Param);

            return Out;
            }

        #endregion

        #region GetTokenExpression

        public static LambdaExpression GetTokenExpression(this Type ModelType, string Token, out ModelMetadata Meta)
            {
            Token = Token ?? "";

            if (Token.StartsWith("["))
                Token = Token.Substring(1);

            if (Token.EndsWith("]"))
                Token = Token.Substring(0, Token.Length - 1);

            string[] FullProperty;

            var Lambda = ModelType.FindSubProperty(out Meta, out FullProperty, Token.Split('.'));

            var Param = Lambda.Parameters[0];
            Expression AsObject = Expression.TypeAs(Lambda.Body, typeof(object));
            var Lambda2 = Expression.Lambda(AsObject, Param);

            var Param2 = Expression.Parameter(typeof(object), "b");
            Expression AsT = Expression.TypeAs(Param2, ModelType);

            var Invoke = Expression.Invoke(Lambda2, AsT);
            var Lambda3 = Expression.Lambda(Invoke, Param2);

            return Lambda3;
            }

        #endregion

        #region HasAttribute

        public static bool HasAttribute<T>(this ModelMetadata Meta)
            where T : IPersistAttribute
            {
            return Meta.GetMember().HasAttribute<T>(false);
            }
        public static bool HasAttribute<T>(this ModelMetadata Meta, bool IncludeSubClasses)
            {
            return Meta.GetMember().HasAttribute<T>(IncludeSubClasses);
            }

        #endregion

        #region HasProperty

        public static bool HasProperty(this Type Type, string PropertyName)
            {
            return Type.GetProperty(PropertyName) != null;
            }

        #endregion

        #region IsNullable

        public static bool IsNullable(this Type Type)
            {
            return Type.IsGenericType && Type.GetGenericTypeDefinition() == typeof(Nullable<>);

            //    return t.Name == "Nullable" || t.Name == "Nullable`1";
            }

        #endregion

        #region Meta

        public static ModelMetadata Meta(this Type Type, string PropertyName = null)
            {
            Type = Type.WithoutDynamicType();

            return !string.IsNullOrEmpty(PropertyName)
                ? ModelMetadataProviders.Current.GetMetadataForProperty(null, Type,
                    PropertyName.Contains(".") ? PropertyName.Split(".")[1] : PropertyName)
                : ModelMetadataProviders.Current.GetMetadataForType(null, Type);
            }

        public static ModelMetadata Meta(this TypeInfo Type, string PropertyName = null)
            {
            return !string.IsNullOrEmpty(PropertyName)
                ? ModelMetadataProviders.Current.GetMetadataForProperty(null, Type,
                    PropertyName.Contains(".") ? PropertyName.Split(".")[1] : PropertyName)
                : ModelMetadataProviders.Current.GetMetadataForType(null, Type);
            }

        public static ModelMetadata Meta<T>(this T Model, Expression<Func<T, object>> Expression)
            where T : IModel
            {
            return Model.Meta((Expression.Body as MemberExpression)?.Member.Name);
            }

        public static ModelMetadata Meta<T>(this T Model, string PropertyName = null)
            where T : IModel
            {
            return string.IsNullOrEmpty(PropertyName)
                ? ModelMetadataProviders.Current.GetMetadataForType(null, Model.TrueModelType())
                : Model.Property(PropertyName);
            }

        #endregion

        #region PreferGeneric

        public static Type PreferGeneric(this Type Type)
            {
            return Type.IsGenericType ? Type.GetGenericArguments()[0] : Type;
            }

        #endregion

        #region Properties

        public static IEnumerable<ModelMetadata> Properties<T>(this T Model)
            where T : IModel
            {
            return Model.Meta().Properties;
            }

        #endregion

        #region Property

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

        #endregion

        #endregion

        #region Type +

        #region FindSubProperty

        public static LambdaExpression FindSubProperty(this Type Type, out ModelMetadata Meta, out string[] FullProperties,
            params string[] Properties)
            {
            var Param = Expression.Parameter(Type, string.Empty);
            MemberExpression Member = null;
            var CurrentType = Type;

            FullProperties = new string[Properties.Length];

            for (int Index = 0; Index < Properties.Length; Index++)
                {
                FullProperties[Index] = CurrentType.SearchForProperty(Properties[Index]);

                Member = Member == null
                    ? Expression.PropertyOrField(Param, FullProperties[Index])
                    : Expression.PropertyOrField(Member, FullProperties[Index]);


                if (Index < Properties.Length - 1)
                    CurrentType = Member.Type;

                }

            Meta = CurrentType.Meta(FullProperties[FullProperties.Length - 1]);

            if (Member != null)
                {
                var Out = Expression.Lambda(Member, Param);

                return Out;
                }
            return null;
            }

        #endregion

        #region GetExpression

        public static LambdaExpression GetExpression(this Type Type, string PropertyName)
            {
            var Param = Expression.Parameter(Type, string.Empty);
            var Property = Expression.PropertyOrField(Param, PropertyName);
            var Expr = Expression.Lambda(Property, Param);

            return Expr;
            }

        #endregion

        #region GetExpression

        public static Expression<Func<T, U>> GetExpression<T, U>(this Type Type, string PropertyName)
            {
            var Param = Expression.Parameter(Type, string.Empty);
            var Property = Expression.PropertyOrField(Param, PropertyName);
            Expression<Func<T, U>> Expr = Expression.Lambda<Func<T, U>>(Property, Param);

            return Expr;
            }

        #endregion

        #endregion

        #endregion
        }
    }