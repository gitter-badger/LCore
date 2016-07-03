using System;

namespace Singularity
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

            public const string jQuery = "https://api.jquery.com/";
            public const string jQueryUI = "http://jqueryui.com/";
            }

        public static class Source
            {
            public const string Singularity = "";
            public const string L = "";

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