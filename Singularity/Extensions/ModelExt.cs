using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using LCore;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using Singularity.Context;
using Singularity.Controllers;
using System.Web.Mvc;
using Singularity.Models;
using Singularity.Annotations;
using Singularity.Utilities;

namespace Singularity.Extensions
    {
    public static class ModelExt
        {
        //////////////////////////////////////////////////////////////////////////////////////////////////
        // Attributes
        //

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

        //////////////////////////////////////////////////////////////////////////////////////////////////
        // IDs
        //

        public static TOut GetID<TOut>(this IModel Model)
            {
            String Out = GetID(Model);

            try
                {
                return (TOut)new StringConverter().PerformAction(Out, typeof(TOut));
                }
            catch
                {

                }

            return default(TOut);
            }

        public static String GetID(this IModel Model)
            {
            ModelMetadata KeyProperty = Model.Properties().Where(m => m.HasAttribute<KeyAttribute>()).FirstOrDefault();

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

        // Model Types ////////////////////////////////////////////////////////////////////////////////////////////////

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

        // CSV to Model ////////////////////////////////////////////////////////////////////////////////////////////////

        public static List<T> CSVToModels<T>(this String CSVData)
            where T : IModel
            {
            String[] Lines = CSVData.Lines();

            List<String[]> CSV = new List<String[]>();

            foreach (String Line in Lines)
                {
                CSV.Add(Line.SplitWithQuotes(',').Array());
                }

            String[][] CSVArray = CSV.Array();

            return CSVArray.CSVToModels<T>();
            }

        public static List<T> CSVToModels<T>(this String[][] CSVData)
            where T : IModel
            {
            List<T> Out = new List<T>();

            String[] CSVHeader = null;


            for (int i = 0; i < CSVData.Length; i++)
                {
                String[] Line = CSVData[i];

                // Assume the first line is the header
                if (i == 0)
                    {
                    CSVHeader = Line;

                    continue;
                    }

                Out.Add(Line.CSVToModel<T>(CSVHeader));
                }

            return Out;
            }

        public static T CSVToModel<T>(this String CSVLine)
            where T : IModel
            {
            String[] LineSplit = CSVLine.SplitWithQuotes(',').Array();

            return LineSplit.CSVToModel<T>();
            }

        public static T CSVToModel<T>(this String[] CSVLine, String[] CSVHeader = null)
            where T : IModel
            {
            T Out = typeof(T).New<T>();

            if (CSVHeader == null)
                CSVHeader = Out.CSVHeader();

            if (CSVLine.Length != CSVHeader.Length)
                throw new Exception("Header and line length don't match");

            Out.Initialize();

            ModelMetadata[] ModelMeta = null;

            for (int j = 0; j < CSVLine.Length; j++)
                {
                String HeaderTitle = CSVHeader[j];
                String LineValue = CSVLine[j];

                ModelMetadata Meta = Out.Meta(HeaderTitle);

                if (Meta == null)
                    {
                    // Only compute once per model if needed
                    ModelMeta = ModelMeta ?? typeof(T).Meta().Properties.Array();

                    foreach (ModelMetadata FieldMeta in ModelMeta)
                        {
                        if (FieldMeta.HasAttribute<FieldExportHeaderAttribute>() &&
                            FieldMeta.GetAttribute<FieldExportHeaderAttribute>().HeaderText == HeaderTitle)
                            {
                            Meta = FieldMeta;
                            break;
                            }
                        }

                    if (Meta == null)
                        throw new Exception("Could not find property " + HeaderTitle);
                    }

                if (Meta.IsReadOnly)
                    continue;

                if (Meta.HasAttribute<FieldDisableImportAttribute>() ||
                    Meta.HasAttribute<KeyAttribute>())
                    continue;

                StringConverter Convert = new StringConverter();

                Object Value = null;

                try
                    {
                    Value = Convert.PerformAction(LineValue, Meta.ModelType);

                    Out.SetProperty(HeaderTitle, Value);
                    }
                catch(Exception e)
                    {
                    if (LineValue == null || LineValue.IsEmpty())
                        {
                        }
                    else
                        {
                        throw e;
                        }
                    }
                }

            return Out;
            }

        public static String[] CSVHeader<T>(this T Model)
            where T : IModel
            {
            return typeof(T).CSVHeader();
            }

        public static String[] CSVHeader(this Type t)
            {
            ModelMetadata[] ModelMeta = t.Meta().Properties.Array();

            List<String> Out = new List<String>();

            foreach (ModelMetadata Meta in ModelMeta)
                {
                if (Meta.HasAttribute<FieldDisableExportAttribute>())
                    {
                    continue;
                    }

                if (Meta.HasAttribute<FieldExportHeaderAttribute>())
                    {
                    Out.Add(Meta.GetAttribute<FieldExportHeaderAttribute>().HeaderText);
                    }
                else
                    {
                    Out.Add(Meta.PropertyName);
                    }
                }

            return Out.Array();
            }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        public static void Initialize<T>(this T Model)
            where T : IModel
            {
            // Active field /////////////////////////////////////////////////////////
            if (Model.HasProperty(ControllerHelper.AutomaticFields.Active) &&
                Model.Meta(ControllerHelper.AutomaticFields.Active).ModelType == typeof(Boolean))
                {
                Model.SetProperty(ControllerHelper.AutomaticFields.Active, true);
                }

            // Created field ////////////////////////////////////////////////////////
            if (Model.HasProperty(ControllerHelper.AutomaticFields.Created) &&
                Model.Meta(ControllerHelper.AutomaticFields.Created).ModelType == typeof(DateTime))
                {
                Model.SetProperty(ControllerHelper.AutomaticFields.Created, DateTime.Now);
                }

            // Default Value fields /////////////////////////////////////////////////
            ModelMetadata[] Properties = Model.Meta().Properties.Array();

            foreach (ModelMetadata Meta in Properties)
                {
                FieldDefaultValueAttribute Attr = Meta.GetAttribute<FieldDefaultValueAttribute>();

                if (Attr != null)
                    {
                    Object Value = Attr.GetValue(Model);

                    Model.SetProperty(Meta.PropertyName, Value);
                    }
                }
            }

        public static String TemplateTokenFill<T>(this T Model, String Template) where T : IModel
            {
            Type ModelType = Model.TrueModelType();
            Dictionary<String, ModelMetadata> AllMeta = ModelType.GetMeta(m => !m.HasAttribute<FieldNoTokenAttribute>());

            String Out = Template ?? "";

            foreach (String Key in AllMeta.Keys)
                {
                String KeyBraced = "[" + Key + "]";

                ModelMetadata Meta = AllMeta[Key];

                if (Meta.HasAttribute<FieldNoTokenAttribute>())
                    {
                    continue;
                    }

                if (Out.Contains(KeyBraced))
                    {
                    LambdaExpression Lambda = ModelType.GetTokenExpression(Key, out Meta);

                    Func<Object, Object> Func = ((Expression<Func<Object, Object>>)Lambda).Compile();

                    Object Data = Func(Model) ?? "";

                    StringConverter Convert = new StringConverter();

                    if (StringConverter.IsTypeSupported(Meta))
                        {
                        String Str = (String)((IConvertible)Data).ConvertTo(typeof(String));

                        Out = Out.ReplaceAll(KeyBraced, Str);
                        }
                    else
                        {
                        throw new Exception("Data for " + Key + " was not convertible to String: " + Data);
                        }
                    }
                }

            return Out;
            }

        public static T Clone<T>(this T Model)
            where T : IModel
            {
            return Model.CloneInto<T, T>();
            }

        public static U CloneInto<T, U>(this T Model)
            where T : IModel
            where U : IModel
            {
            U Out = typeof(U).New<U>();

            return CloneInto<T, U>(Model, Out);
            }

        public static U CloneInto<T, U>(this T Model, U Out)
            where T : IModel
            where U : IModel
            {
            List<ModelMetadata> ModelMetaT = typeof(T).Meta().Properties.List();
            List<ModelMetadata> ModelMetaU = Out.Properties().List();

            foreach (ModelMetadata Meta in ModelMetaU)
                {
                if (Meta.IsReadOnly ||
                    Meta.HasAttribute<IDontClone>() ||
                    Meta.HasAttribute<KeyAttribute>() ||
                    Meta.ModelType.HasInterface<IModel>())
                    continue;

                ModelMetadata MetaT = ModelMetaT.First(m => m.PropertyName == Meta.PropertyName);

                if (MetaT == null ||
                    MetaT.IsReadOnly ||
                    MetaT.HasAttribute<IDontClone>() ||
                    MetaT.HasAttribute<KeyAttribute>())
                    continue;

                Object Value = Model.GetProperty(Meta.PropertyName);

                Out.SetProperty(Meta.PropertyName, Value);
                }

            return Out;
            }
        }
    }