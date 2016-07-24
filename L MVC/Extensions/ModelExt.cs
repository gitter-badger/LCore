using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LCore.Extensions;
using System.ComponentModel.DataAnnotations;
using LMVC.Controllers;
using System.Web.Mvc;
using JetBrains.Annotations;
using LCore.Interfaces;
using LMVC.Models;
using LMVC.Annotations;
using LMVC.Utilities;

namespace LMVC.Extensions
    {
    [ExtensionProvider]
    public static class ModelExt
        {
        //////////////////////////////////////////////////////////////////////////////////////////////////
        // Attributes
        //
        
        public static bool HasAttribute<TAttribute>(this IModel Model)
            where TAttribute : IPersistAttribute
            {
            return Model.TrueModelType().HasAttribute<TAttribute>();
            }

        public static TAttribute GetAttribute<TAttribute>(this IModel Model)
            where TAttribute : IPersistAttribute
            {
            return Model.TrueModelType().GetAttribute<TAttribute>();
            }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        // IDs
        //

        public static TOut GetID<TOut>(this IModel Model)
            {
            string Out = GetID(Model);

            try
                {
                return (TOut)new StringConverter().PerformAction(Out, typeof(TOut));
                }
            catch
                {

                }

            return default(TOut);
            }

        public static string GetID(this IModel Model)
            {
            var KeyProperty = Model.Properties().First(Prop => Prop.HasAttribute<KeyAttribute>(true));

            if (KeyProperty != null)
                {
                string KeyField = KeyProperty.PropertyName;

                return Model.GetProperty(KeyField).ToString();
                }

            return Model.HasProperty($"{Model.TrueModelType().Name}ID") ? Model.GetProperty(
                $"{Model.TrueModelType().Name}ID").ToString() : null;
            }

        public static bool HasID(this IModel Model)
            {
            string KeyField = Model.Properties().First(Prop => Prop.HasAttribute<KeyAttribute>(true))?.PropertyName;

            var ID = Model.GetProperty(KeyField);

            return ID != null &&
                (!(ID is int) || ((int)ID != 0));
            }

        // Model Types ////////////////////////////////////////////////////////////////////////////////////////////////

        public static string GetFriendlyTypeName(this IModel Model)
            {
            string TypeName = Model.TrueModelType().Name;

            return TypeName.Humanize();
            }

        public static Type WithoutDynamicType(this Type Type)
            {
            return Type.Namespace == "System.Data.Entity.DynamicProxies" ? Type.BaseType : Type;
            }

        public static Type TrueModelType<T>([CanBeNull]this T Model)
            where T : IModel
            {
            if (Model == null)
                return typeof(T);

            return Model.GetType().Namespace == "System.Data.Entity.DynamicProxies" ? Model.GetType().BaseType : Model.GetType();
            }

        // CSV to Model ////////////////////////////////////////////////////////////////////////////////////////////////

        /// <exception cref="ArgumentException">Header and line length don't match, Could not find property</exception>
        /// <exception cref="Exception">If a property could not be set.</exception>
        public static List<T> CSVToModels<T>(this string CSVData)
            where T : IModel
            {
            string[] Lines = CSVData.Lines();

            List<string[]> CSV = Lines.Convert(Line => Line.SplitWithQuotes(',').Array()).List();

            string[][] CSVArray = CSV.Array();

            return CSVArray.CSVToModels<T>();
            }

        /// <exception cref="ArgumentException">Header and line length don't match, Could not find property</exception>
        /// <exception cref="Exception">If a property could not be set.</exception>
        public static List<T> CSVToModels<T>(this string[][] CSVData)
            where T : IModel
            {
            var Out = new List<T>();

            string[] CSVHeader = null;


            for (int Index = 0; Index < CSVData.Length; Index++)
                {
                string[] Line = CSVData[Index];

                // Assume the first line is the header
                if (Index == 0)
                    {
                    CSVHeader = Line;

                    continue;
                    }

                Out.Add(Line.CSVToModel<T>(CSVHeader));
                }

            return Out;
            }

        /// <exception cref="ArgumentException">Header and line length don't match, Could not find property</exception>
        /// <exception cref="Exception">If a property could not be set.</exception>
        public static T CSVToModel<T>(this string CSVLine)
            where T : IModel
            {
            string[] LineSplit = CSVLine.SplitWithQuotes(',').Array();

            return LineSplit.CSVToModel<T>();
            }

        /// <exception cref="ArgumentException">Header and line length don't match, Could not find property</exception>
        /// <exception cref="Exception">If a property could not be set.</exception>
        public static T CSVToModel<T>(this string[] CSVLine, string[] CSVHeader = null)
            where T : IModel
            {
            var Out = typeof(T).New<T>();

            if (CSVHeader == null)
                CSVHeader = Out.CSVHeader();

            if (CSVLine.Length != CSVHeader.Length)
                throw new ArgumentException("Header and line length don't match");

            Out.Initialize();

            ModelMetadata[] ModelMeta = null;

            for (int Index = 0; Index < CSVLine.Length; Index++)
                {
                string HeaderTitle = CSVHeader[Index];
                string LineValue = CSVLine[Index];

                var Meta = Out.Meta(HeaderTitle);

                if (Meta == null)
                    {
                    // Only compute once per model if needed
                    ModelMeta = ModelMeta ?? typeof(T).Meta().Properties.Array();

                    foreach (var FieldMeta in ModelMeta)
                        {
                        if (FieldMeta.HasAttribute<FieldExportHeaderAttribute>() &&
                            FieldMeta.GetAttribute<FieldExportHeaderAttribute>().HeaderText == HeaderTitle)
                            {
                            Meta = FieldMeta;
                            break;
                            }
                        }

                    if (Meta == null)
                        throw new ArgumentException($"Could not find property {HeaderTitle}");
                    }

                if (Meta.IsReadOnly)
                    continue;

                if (Meta.HasAttribute<FieldDisableImportAttribute>() ||
                    Meta.HasAttribute<KeyAttribute>(true))
                    continue;

                var Convert = new StringConverter();

                try
                    {
                    var Value = Convert.PerformAction(LineValue, Meta.ModelType);

                    Out.SetProperty(HeaderTitle, Value);
                    }
                catch (Exception)
                    {
                    if (LineValue == null || LineValue.IsEmpty())
                        {
                        }
                    else
                        {
                        throw;
                        }
                    }
                }

            return Out;
            }

        public static string[] CSVHeader<T>(this T Model)
            where T : IModel
            {
            return typeof(T).CSVHeader();
            }

        public static string[] CSVHeader(this Type Type)
            {
            ModelMetadata[] ModelMeta = Type.Meta().Properties.Array();

            List<string> Out = ModelMeta
                .Select(Meta => !Meta.HasAttribute<FieldDisableExportAttribute>())
                .Convert(Meta => Meta.HasAttribute<FieldExportHeaderAttribute>()
                    ? Meta.GetAttribute<FieldExportHeaderAttribute>().HeaderText
                    : Meta.PropertyName).List();

            return Out.Array();
            }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        public static void Initialize<T>(this T Model)
            where T : IModel
            {
            // Active field /////////////////////////////////////////////////////////
            if (Model.HasProperty(ControllerHelper.AutomaticFields.Active) &&
                Model.Meta(ControllerHelper.AutomaticFields.Active).ModelType == typeof(bool))
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

            foreach (var Meta in Properties)
                {
                var Attr = Meta.GetAttribute<FieldDefaultValueAttribute>();

                if (Attr != null)
                    {
                    var Value = Attr.GetValue(Model);

                    Model.SetProperty(Meta.PropertyName, Value);
                    }
                }
            }

        /// <exception cref="InvalidOperationException">Data field was not convertible to string.</exception>
        public static string TemplateTokenFill<T>(this T Model, [CanBeNull]string Template) where T : IModel
            {
            var ModelType = Model.TrueModelType();
            Dictionary<string, ModelMetadata> AllMeta = ModelType.GetMeta(Meta => !Meta.HasAttribute<FieldNoTokenAttribute>());

            string Out = Template ?? "";

            foreach (string Key in AllMeta.Keys)
                {
                string KeyBraced = $"[{Key}]";

                var Meta = AllMeta[Key];

                if (Meta.HasAttribute<FieldNoTokenAttribute>())
                    {
                    continue;
                    }

                if (Out.Contains(KeyBraced))
                    {
                    var Lambda = ModelType.GetTokenExpression(Key, out Meta);

                    Func<object, object> Func = ((Expression<Func<object, object>>)Lambda).Compile();

                    var Data = Func(Model) ?? "";

                    if (StringConverter.IsTypeSupported(Meta))
                        {
                        string Str = (string)((IConvertible)Data).ConvertTo(typeof(string));

                        Out = Out.ReplaceAll(KeyBraced, Str);
                        }
                    else
                        {
                        throw new InvalidOperationException($"Data for {Key} was not convertible to String: {Data}");
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
            var Out = typeof(U).New<U>();

            return CloneInto(Model, Out);
            }

        public static U CloneInto<T, U>(this T Model, U Out)
            where T : IModel
            where U : IModel
            {
            List<ModelMetadata> ModelMetaT = typeof(T).Meta().Properties.List();
            List<ModelMetadata> ModelMetaU = Out.Properties().List();

            foreach (var Meta in ModelMetaU)
                {
                if (Meta.IsReadOnly ||
                    Meta.HasAttribute<IDontClone>() ||
                    Meta.HasAttribute<KeyAttribute>(true) ||
                    Meta.ModelType.HasInterface<IModel>())
                    continue;

                var MetaT = ModelMetaT.First(Metadata => Metadata.PropertyName == Meta.PropertyName);

                if (MetaT == null ||
                    MetaT.IsReadOnly ||
                    MetaT.HasAttribute<IDontClone>() ||
                    MetaT.HasAttribute<KeyAttribute>(true))
                    continue;

                var Value = Model.GetProperty(Meta.PropertyName);

                Out.SetProperty(Meta.PropertyName, Value);
                }

            return Out;
            }
        }
    }