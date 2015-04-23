
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using RazorGenerator.Mvc;

namespace Singularity.Routes
{
    public static class Controllers
    {
        public static class Error
        {
            public const String Name = "Error";

            public static class Actions
            {
                public const String Index = "Index";
            }
        }

        public static class Test
        {
            public const String Name = "Test";

            public static class Actions
            {
                public const String JavascriptTest = "JavascriptTest";
                public const String SingularityTest = "SingularityTest";

            }
        }
        public static class Manage
        {
            public const String Name = "Manage";

            public static class Actions
            {
                public const String Create = "Create";
                public const String Delete = "Delete";
                public const String Edit = "Edit";
                public const String Manage = "Manage";

            }
        }
    }

    public static class Layouts
    {
        public const String MainLayout = "~/Views/_MainLayout.cshtml";
    }

    public static class PartialViews
    {

        public const String Manage_HeaderRow = "_Manage_HeaderRow";
        public const String Manage_Pagination = "_Manage_Pagination";
        public const String Manage_Row = "_Manage_Row";
        public const String Manage_Search = "_Manage_Search";
    }
}