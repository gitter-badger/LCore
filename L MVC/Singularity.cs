using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;
using LMVC.Extensions;

namespace LMVC
    {
    public static class Singularity
        {
        public static readonly string AppName = $"{nameof(Singularity)}";
        public const string AppName_Short = "•";

        public static class Reference
            {
            public const string CSharp = "https://msdn.microsoft.com/en-us/library/618ayhy6.aspx";
            public const string SQL = "https://msdn.microsoft.com/en-us/library/bb510741.aspx";

            public const string JavaScript = "http://www.w3schools.com/js/";
            public const string TypeScript = "https://www.typescriptlang.org/docs/tutorial.html";

            public const string Html = "http://www.w3schools.com/html/default.asp";

            ///////////////////

            public const string Bootstrap = "http://www.w3schools.com/bootstrap/";

            // ReSharper disable InconsistentNaming
            public const string jQuery = "https://api.jquery.com/";
            public const string jQueryUI = "http://jqueryui.com/";
            // ReSharper restore InconsistentNaming
            }

        public static class Source
            {
            public const string Singularity = "";
            public const string L = "";
            }

        public static class Icons
            {
            public static readonly Dictionary<Type, FontAwesomeExt.Icon> TypeIcons_L = new Dictionary<Type, FontAwesomeExt.Icon>
                {
                [typeof(BooleanExt)] = FontAwesomeExt.Icon.adjust,
                [typeof(ReflectionExt)] = FontAwesomeExt.Icon.shield,
                [typeof(EnumerableExt)] = FontAwesomeExt.Icon.list,
                [typeof(LoopExt)] = FontAwesomeExt.Icon.repeat,
                [typeof(DateExt)] = FontAwesomeExt.Icon.calendar,
                [typeof(DictionaryExt)] = FontAwesomeExt.Icon.book,
                [typeof(FileExt)] = FontAwesomeExt.Icon.archive,
                [typeof(StringExt)] = FontAwesomeExt.Icon.quote_left,
                [typeof(ObjectExt)] = FontAwesomeExt.Icon.square_o,
                [typeof(ConvertibleExt)] = FontAwesomeExt.Icon.info_circle,
                [typeof(ExceptionExt)] = FontAwesomeExt.Icon.warning,
                [typeof(EnumExt)] = FontAwesomeExt.Icon.navicon,
                [typeof(ThreadExt)] = FontAwesomeExt.Icon.random,
                [typeof(NumberExt)] = FontAwesomeExt.Icon.sort_numeric_asc,
                [typeof(CommentExt)] = FontAwesomeExt.Icon.adjust,
                [typeof(ComparableExt)] = FontAwesomeExt.Icon.question,
                [typeof(L)] = FontAwesomeExt.Icon.gbp
                };

            public static readonly Dictionary<Type, FontAwesomeExt.Icon> TypeIcons_LMVC = new Dictionary<Type, FontAwesomeExt.Icon>
                {
                [typeof(MetaExt)] = FontAwesomeExt.Icon.question,
                [typeof(ContextExt)] = FontAwesomeExt.Icon.question,
                [typeof(ControllerExt)] = FontAwesomeExt.Icon.question,
                [typeof(GlyphIconExt)] = FontAwesomeExt.Icon.question,
                [typeof(HtmlExt)] = FontAwesomeExt.Icon.question,
                [typeof(ModelExt)] = FontAwesomeExt.Icon.question,
                [typeof(DataExt)] = FontAwesomeExt.Icon.question,
                [typeof(UrlExt)] = FontAwesomeExt.Icon.internet_explorer,
                [typeof(SessionExt)] = FontAwesomeExt.Icon.question,
                [typeof(SingularityControllerExt)] = FontAwesomeExt.Icon.question,
                [typeof(MVCExt)] = FontAwesomeExt.Icon.question,
                [typeof(ResponseExt)] = FontAwesomeExt.Icon.question,
                [typeof(FontAwesomeExt)] = FontAwesomeExt.Icon.question,
                [typeof(QueryExt)] = FontAwesomeExt.Icon.question
                };

            public static readonly Dictionary<Type, FontAwesomeExt.Icon> TypeIcons = new Dictionary<Type, FontAwesomeExt.Icon>
                {
                [typeof(bool)] = FontAwesomeExt.Icon.adjust,
                [typeof(IEnumerable)] = FontAwesomeExt.Icon.list,
                [typeof(Array)] = FontAwesomeExt.Icon.list,
                [typeof(DateTime)] = FontAwesomeExt.Icon.calendar,
                [typeof(TimeSpan)] = FontAwesomeExt.Icon.calendar,
                [typeof(IDictionary)] = FontAwesomeExt.Icon.book,
                [typeof(System.IO.File)] = FontAwesomeExt.Icon.archive,
                [typeof(System.IO.FileInfo)] = FontAwesomeExt.Icon.archive,
                [typeof(string)] = FontAwesomeExt.Icon.quote_left,
                [typeof(object)] = FontAwesomeExt.Icon.square_o,
                [typeof(Exception)] = FontAwesomeExt.Icon.warning,
                [typeof(Enum)] = FontAwesomeExt.Icon.navicon,
                [typeof(System.Threading.Thread)] = FontAwesomeExt.Icon.random,
                [typeof(int)] = FontAwesomeExt.Icon.sort_numeric_asc,
                [typeof(double)] = FontAwesomeExt.Icon.sort_numeric_asc,
                [typeof(float)] = FontAwesomeExt.Icon.sort_numeric_asc,
                [typeof(short)] = FontAwesomeExt.Icon.sort_numeric_asc,
                [typeof(long)] = FontAwesomeExt.Icon.sort_numeric_asc,
                [typeof(uint)] = FontAwesomeExt.Icon.sort_numeric_asc,
                [typeof(ushort)] = FontAwesomeExt.Icon.sort_numeric_asc,
                [typeof(ulong)] = FontAwesomeExt.Icon.sort_numeric_asc
                };

            public static FontAwesomeExt.Icon? GetTypeIcon([CanBeNull]Type Type)
                {
                if (Type == null)
                    return null;

                if (TypeIcons.ContainsKey(Type))
                    return TypeIcons[Type];

                if (TypeIcons_L.ContainsKey(Type))
                    return TypeIcons_L[Type];

                // ReSharper disable once ConvertIfStatementToReturnStatement
                if (TypeIcons_LMVC.ContainsKey(Type))
                    return TypeIcons_LMVC[Type];

                return FontAwesomeExt.Icon.question;
                }
            }

        public static class Url
            {
            public const string MainSite = "http://codesingularity.info";
            }

        public static class Namespaces
            {
            public static class LCore
                {
                public static readonly string Extensions = $"{nameof(LCore)}.{nameof(Extensions)}";
                }

            public static class Singularity
                {
                public static readonly string Extensions = $"{nameof(Singularity)}.{nameof(Extensions)}";
                }
            }
        }
    }