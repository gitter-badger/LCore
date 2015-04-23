using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using LCore;
using System.ComponentModel.DataAnnotations;

namespace Singularity
    {
    public static class ModelExt
        {
        public static Boolean HasAttribute<TAttribute>(this Type t)
            {
            return t.MemberHasAttribute<TAttribute>(false);
            }

        public static TAttribute GetAttribute<TAttribute>(this Type t)
            {
            return t.MemberGetAttribute<TAttribute>(false);
            }

        public static Boolean HasAttribute<TAttribute>(this IModel Model)
            {
            return Model.TrueModelType().MemberHasAttribute<TAttribute>(false);
            }

        public static TAttribute GetAttribute<TAttribute>(this IModel Model)
            {
            return Model.TrueModelType().MemberGetAttribute<TAttribute>(false);
            }

        public static String GetID(this IModel Model)
            {
            System.Web.ModelBinding.ModelMetadata KeyProperty = Model.Properties().Where(m => m.HasAttribute<KeyAttribute>()).FirstOrDefault();

            if (KeyProperty != null)
                {
                String KeyField = KeyProperty.PropertyName;

                return Model.GetProperty(KeyField).ToString();
                }

            if (Model.HasProperty(Model.TrueModelType().Name + "ID"))
                {
                return Model.GetProperty(Model.TrueModelType().Name + "ID").ToString();
                }

            return null;
            }

        public static Boolean HasID(this IModel Model)
            {
            String KeyField = Model.Properties().Where(m => m.HasAttribute<KeyAttribute>()).FirstOrDefault().PropertyName;

            Object ID = Model.GetProperty(KeyField);

            return ID != null &&
                (!(ID is int) || ((int)ID != 0));
            }

        public static String GetFriendlyTypeName(this IModel Model)
            {
            String TypeName = Model.TrueModelType().Name;

            return TypeName.Humanize();
            }

        public static Type WithoutDynamicType(this Type t)
            {
            if (t.Namespace == "System.Data.Entity.DynamicProxies")
                return t.BaseType;

            return t;
            }

        public static Type TrueModelType<T>(this T Model)
            where T : IModel
            {
            if (Model == null)
                return typeof(T);

            if (Model.GetType().Namespace == "System.Data.Entity.DynamicProxies")
                return Model.GetType().BaseType;

            return Model.GetType();
            }
        }
    }