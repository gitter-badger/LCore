using System;
using Singularity.Controllers;
using System.Collections.Generic;

namespace Singularity.Routes
    {
    public static class PartialViews
        {
        public const string Nav = nameof(Nav);
        public const string Footer = nameof(Footer);

        public const string LoginPartial = nameof(LoginPartial);
        public const string PasswordRequirements = nameof(PasswordRequirements);

        
        public const string StatusMessages = nameof(StatusMessages);

        public const string TextContent = nameof(TextContent);
        public const string Singularity_JS_Test = "Test/JavascriptTest";

        public static class Examples
            {
            public static readonly string Bootstrap = $"{nameof(Examples)}_{nameof(Bootstrap)}";
            public static readonly string JQueryUI = $"{nameof(Examples)}_{nameof(JQueryUI)}";
            public static readonly string Singularity = $"{nameof(Examples)}_{nameof(Singularity)}";

            public static readonly string Member = $"{nameof(Examples)}_{nameof(Member)}";
            }

        public static class Admin
            {
            public static readonly string Footer = $"{nameof(Admin)}/{nameof(Footer)}";
            public static readonly string Header = $"{nameof(Admin)}/{nameof(Header)}";
            public static readonly string Sidebar = $"{nameof(Admin)}/{nameof(Sidebar)}";
            public static readonly string ContentHeader = $"{nameof(Admin)}/{nameof(ContentHeader)}";


            }

        public static class Manage
            {
            public static readonly string Before = $"{nameof(Manage)}/{nameof(Before)}";
            public static readonly string After = $"{nameof(Manage)}/{nameof(After)}";

            public static readonly string CustomExport = $"{nameof(Manage)}/Exports";

            public static readonly string HeaderRow = $"{nameof(Manage)}/{nameof(HeaderRow)}";
            public static readonly string Pagination = $"{nameof(Manage)}/{nameof(Pagination)}";
            public static readonly string Row = $"{nameof(Manage)}/{nameof(Row)}";
            public static readonly string Search = $"{nameof(Manage)}/{nameof(Search)}";

            public static readonly string Edit = $"{nameof(Manage)}/{nameof(Edit)}";

            public static class Fields
                {
                public static readonly string Field = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(Field)}";

                public static readonly string Error = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(Error)}";
                public static readonly string FileUpload = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(FileUpload)}";
                public static readonly string Information = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(Information)}";

                public static readonly string FieldHeader = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(FieldHeader)}";

                public static string PropertyName(string PropertyName)
                    {
                    return $"{nameof(Manage)}/{nameof(Fields)}/{PropertyName}";
                    }
                public static string PropertyName_Before(string PropertyName)
                    {
                    return $"{nameof(Manage)}/{nameof(Fields)}/{PropertyName}_Before";
                    }
                public static string PropertyName_After(string PropertyName)
                    {
                    return $"{nameof(Manage)}/{nameof(Fields)}/{PropertyName}_After";
                    }

                public static string PropertyType_Before(Type PropertyType)
                    {
                    return PropertyType != null ? $"{nameof(Manage)}/{nameof(Fields)}/{PropertyType.Name}_Before" : null;
                    }
                public static string PropertyType_After(Type PropertyType)
                    {
                    return $"{nameof(Manage)}/{nameof(Fields)}/{PropertyType.Name}_After";
                    }

                public static string ViewType_Before(ControllerHelper.ViewType ViewType)
                    {
                    return $"{nameof(Manage)}/{nameof(Fields)}/{ViewType}_Before";
                    }
                public static string ViewType_After(ControllerHelper.ViewType ViewType)
                    {
                    return $"{nameof(Manage)}/{nameof(Fields)}/{ViewType}_After";
                    }


                public static class Edit
                    {
                    public static readonly string FieldEdit = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(FieldEdit)}";

                    public static string PropertyName(string PropertyName)
                        {
                        return $"{nameof(Manage)}/{nameof(Fields)}/Edit/{PropertyName}";
                        }
                    public static string PropertyType(Type PropertyType)
                        {
                        return $"{nameof(Manage)}/{nameof(Fields)}/Edit/{PropertyType.Name}";
                        }
                    public static string DataTypeName(string DataType)
                        {
                        return $"{nameof(Manage)}/{nameof(Fields)}/Edit/{DataType}";
                        }

                    public static readonly string Boolean = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(Edit)}/{nameof(Boolean)}";
                    public static readonly string ComplexType = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(Edit)}/{nameof(ComplexType)}";
                    public static readonly string Currency = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(Edit)}/{nameof(Currency)}";
                    public static readonly string DateTime = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(Edit)}/{nameof(DateTime)}";
                    public static readonly string Decimal = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(Edit)}/{nameof(Decimal)}";
                    public static readonly string Enum = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(Edit)}/{nameof(Enum)}";
                    public static readonly string Key = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(Edit)}/{nameof(Key)}";
                    public static readonly string DisplayColumn = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(Edit)}/{nameof(DisplayColumn)}";
                    public static readonly string Empty = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(Edit)}/{nameof(Empty)}";
                    public static readonly string FormatString = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(Edit)}/{nameof(FormatString)}";
                    public static readonly string Hidden = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(Edit)}/{nameof(Hidden)}";
                    public static readonly string IModel = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(Edit)}/{nameof(IModel)}";
                    // public const String IModelCollection = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(Edit)}/IModelCollection";
                    public static readonly string Int = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(Edit)}/{nameof(Int)}";
                    public static readonly string Long = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(Edit)}/{nameof(Long)}";
                    public static readonly string IntRange = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(Edit)}/{nameof(IntRange)}";
                    public static readonly string String = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(Edit)}/{nameof(String)}";
                    public static readonly string StringMultiLine = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(Edit)}/{nameof(StringMultiLine)}";
                    public static readonly string HTMLContent = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(Edit)}/{nameof(HTMLContent)}";
                    public static readonly string Unknown = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(Edit)}/{nameof(Unknown)}";
                    public static readonly string Dropdown = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(Edit)}/{nameof(Dropdown)}";
                    }

                public static class View
                    {
                    public static readonly string FieldView = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(FieldView)}";

                    public static string PropertyName(string PropertyName)
                        {
                        return $"{nameof(Manage)}/{nameof(Fields)}/{nameof(View)}/{PropertyName}";
                        }
                    public static string PropertyType(Type PropertyType)
                        {
                        return $"{nameof(Manage)}/{nameof(Fields)}/{nameof(View)}/{PropertyType.Name}";
                        }
                    public static string DataTypeName(string DataType)
                        {
                        return $"{nameof(Manage)}/{nameof(Fields)}/{nameof(View)}/{DataType}";
                        }

                    public static readonly string Boolean = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(View)}/{nameof(Boolean)}";
                    // public const String ComplexType = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(View)}/{nameof(ComplexType)}";
                    public static readonly string Currency = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(View)}/{nameof(Currency)}";
                    public static readonly string DateTime = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(View)}/{nameof(DateTime)}";
                    public static readonly string DisplayColumn = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(View)}/{nameof(DisplayColumn)}";
                    public static readonly string Enum = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(View)}/{nameof(Enum)}";
                    public static readonly string Empty = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(View)}/{nameof(Empty)}";
                    public static readonly string FormatString = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(View)}/{nameof(FormatString)}";
                    public static readonly string IModel = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(View)}/{nameof(IModel)}";
                    public static readonly string IModelCollection = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(View)}/{nameof(IModelCollection)}";
                    public static readonly string Int = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(View)}/{nameof(Int)}";
                    public static readonly string String = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(View)}/{nameof(String)}";
                    public static readonly string StringMatrix = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(View)}/{nameof(StringMatrix)}";
                    public static readonly string StringMultiArray = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(View)}/{nameof(StringMultiArray)}";


                    public static readonly string Unknown = $"{nameof(Manage)}/{nameof(Fields)}/{nameof(View)}/{nameof(Unknown)}";
                    }
                }
            }
        }
    }