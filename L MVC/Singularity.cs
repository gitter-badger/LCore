using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore;
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
            public static readonly Dictionary<Type, FontAwesomeIcon> TypeIcons_L = new Dictionary<Type, FontAwesomeIcon>
                {
                [typeof(BooleanExt)] = FontAwesomeIcon.adjust,
                [typeof(ReflectionExt)] = FontAwesomeIcon.shield,
                [typeof(EnumerableExt)] = FontAwesomeIcon.list,
                [typeof(LoopExt)] = FontAwesomeIcon.repeat,
                [typeof(DateExt)] = FontAwesomeIcon.calendar,
                [typeof(DictionaryExt)] = FontAwesomeIcon.book,
                [typeof(FileExt)] = FontAwesomeIcon.archive,
                [typeof(StringExt)] = FontAwesomeIcon.quote_left,
                [typeof(ObjectExt)] = FontAwesomeIcon.square_o,
                [typeof(ConvertibleExt)] = FontAwesomeIcon.info_circle,
                [typeof(ExceptionExt)] = FontAwesomeIcon.warning,
                [typeof(EnumExt)] = FontAwesomeIcon.navicon,
                [typeof(ThreadExt)] = FontAwesomeIcon.random,
                [typeof(NumberExt)] = FontAwesomeIcon.sort_numeric_asc,
                [typeof(CommentExt)] = FontAwesomeIcon.adjust,
                [typeof(ComparableExt)] = FontAwesomeIcon.question,
                [typeof(L)] = FontAwesomeIcon.gbp
                };

            public static readonly Dictionary<Type, FontAwesomeIcon> TypeIcons_LMVC = new Dictionary<Type, FontAwesomeIcon>
                {
                [typeof(MetaExt)] = FontAwesomeIcon.question,
                [typeof(ContextExt)] = FontAwesomeIcon.question,
                [typeof(ControllerExt)] = FontAwesomeIcon.question,
                [typeof(GlyphIconExt)] = FontAwesomeIcon.question,
                [typeof(HtmlExt)] = FontAwesomeIcon.question,
                [typeof(ModelExt)] = FontAwesomeIcon.question,
                [typeof(DataExt)] = FontAwesomeIcon.question,
                [typeof(UrlExt)] = FontAwesomeIcon.internet_explorer,
                [typeof(SessionExt)] = FontAwesomeIcon.question,
                [typeof(SingularityControllerExt)] = FontAwesomeIcon.question,
                [typeof(MVCExt)] = FontAwesomeIcon.question,
                [typeof(ResponseExt)] = FontAwesomeIcon.question,
                [typeof(FontAwesomeExt)] = FontAwesomeIcon.question,
                [typeof(QueryExt)] = FontAwesomeIcon.question
                };

            public static readonly Dictionary<Type, FontAwesomeIcon> TypeIcons = new Dictionary<Type, FontAwesomeIcon>
                {
                [typeof(bool)] = FontAwesomeIcon.adjust,
                [typeof(IEnumerable)] = FontAwesomeIcon.list,
                [typeof(Array)] = FontAwesomeIcon.list,
                [typeof(DateTime)] = FontAwesomeIcon.calendar,
                [typeof(TimeSpan)] = FontAwesomeIcon.calendar,
                [typeof(IDictionary)] = FontAwesomeIcon.book,
                [typeof(System.IO.File)] = FontAwesomeIcon.archive,
                [typeof(System.IO.FileInfo)] = FontAwesomeIcon.archive,
                [typeof(string)] = FontAwesomeIcon.quote_left,
                [typeof(object)] = FontAwesomeIcon.square_o,
                [typeof(Exception)] = FontAwesomeIcon.warning,
                [typeof(Enum)] = FontAwesomeIcon.navicon,
                [typeof(System.Threading.Thread)] = FontAwesomeIcon.random,
                [typeof(int)] = FontAwesomeIcon.sort_numeric_asc,
                [typeof(double)] = FontAwesomeIcon.sort_numeric_asc,
                [typeof(float)] = FontAwesomeIcon.sort_numeric_asc,
                [typeof(short)] = FontAwesomeIcon.sort_numeric_asc,
                [typeof(long)] = FontAwesomeIcon.sort_numeric_asc,
                [typeof(uint)] = FontAwesomeIcon.sort_numeric_asc,
                [typeof(ushort)] = FontAwesomeIcon.sort_numeric_asc,
                [typeof(ulong)] = FontAwesomeIcon.sort_numeric_asc
                };

            public static FontAwesomeIcon? GetTypeIcon([CanBeNull]Type Type)
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

                return FontAwesomeIcon.question;
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