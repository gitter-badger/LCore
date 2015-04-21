using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Security;
using LCore;
using MVCL;
using MVCL.Context;
using MVCL.Models;
using WebMatrix.WebData;


namespace MVCL.Controllers
{
    public static class ControllerHelper
    {
        [Flags]
        public enum ViewType
        {
            Create = 1,
            Edit = 2,
            Display = 4,
            TableCell = 8,
            FieldHeader = 16,
            Export = 32,

            All = ViewType.Create | ViewType.Display | ViewType.Edit | ViewType.Export | ViewType.FieldHeader | ViewType.TableCell
        }

        public const string Menu_Admin = "Admin";
        public const string Menu_Directory = "Directory";
        public const string Menu_Time = "Time";
        public const string Menu_Forms = "Forms";
        public const string Menu_Invoicing = "Invoicing";

        public static class PartialViews
        {
            public const String Manage_Pagination = "_Manage_Pagination";
            public const String Manage_Search = "_Manage_Search";
            public const String Manage_HeaderRow = "_Manage_HeaderRow";
            public const String Manage_Row = "_Manage_Row";

            public const String MVCL_JS_Test = "Test/JavascriptTest";

            public const String Edit = "Edit";
            public const String Login = "_LoginPartial";

            public const String Field = "Fields/Field";

            public static String Field_PropertyName(String PropertyName)
            {
                return "Fields/" + PropertyName;
            }

            public static String Field_PropertyName_Before(String PropertyName)
            {
                return "Fields/" + PropertyName + "_Before";
            }
            public static String Field_PropertyName_After(String PropertyName)
            {
                return "Fields/" + PropertyName + "_After";
            }

            public static String Field_PropertyType_Before(Type PropertyType)
            {
                return "Fields/" + PropertyType.Name + "_Before";
            }
            public static String Field_PropertyType_After(Type PropertyType)
            {
                return "Fields/" + PropertyType.Name + "_After";
            }

            public static String Field_ViewType_Before(ControllerHelper.ViewType ViewType)
            {
                return "Fields/" + ViewType.ToString() + "_Before";
            }
            public static String Field_ViewType_After(ControllerHelper.ViewType ViewType)
            {
                return "Fields/" + ViewType.ToString() + "_After";
            }

            public const String Field_Error = "Fields/Error";

            public const String Field_View = "Fields/View";

            public static String Field_View_PropertyName(String PropertyName)
            {
                return "Fields/View/" + PropertyName;
            }
            public static String Field_View_PropertyType(Type PropertyType)
            {
                return "Fields/View/" + PropertyType.Name;
            }
            public static String Field_View_DataTypeName(String DataType)
            {
                return "Fields/View/" + DataType;
            }

            public const String Field_View_Boolean = "Fields/View/Boolean";
            // public const String Field_View_ComplexType = "Fields/View/ComplexType";
            public const String Field_View_Currency = "Fields/View/Currency";
            public const String Field_View_DateTime = "Fields/View/DateTime";
            public const String Field_View_DisplayColumn = "Fields/View/DisplayColumn";
            public const String Field_View_Enum = "Fields/View/Enum";
            public const String Field_View_Empty = "Fields/View/Empty";
            public const String Field_View_FormatString = "Fields/View/FormatString";
            public const String Field_View_IModel = "Fields/View/IModel";
            public const String Field_View_IModelCollection = "Fields/View/IModelCollection";
            public const String Field_View_Int = "Fields/View/Int";
            public const String Field_View_String = "Fields/View/String";
            public const String Field_View_StringMatrix = "Fields/View/StringMatrix";
            public const String Field_View_StringMultiArray = "Fields/View/StringMultiArray";


            public const String Field_View_Unknown = "Fields/View/Unknown";

            public const String Field_Edit = "Fields/Edit";

            public static String Field_Edit_PropertyName(String PropertyName)
            {
                return "Fields/Edit/" + PropertyName;
            }
            public static String Field_Edit_PropertyType(Type PropertyType)
            {
                return "Fields/Edit/" + PropertyType.Name;
            }
            public static String Field_Edit_DataTypeName(String DataType)
            {
                return "Fields/Edit/" + DataType;
            }

            public const String Field_Edit_Boolean = "Fields/Edit/Boolean";
            public const String Field_Edit_ComplexType = "Fields/Edit/ComplexType";
            public const String Field_Edit_Currency = "Fields/Edit/Currency";
            public const String Field_Edit_DateTime = "Fields/Edit/DateTime";
            public const String Field_Edit_Decimal = "Fields/Edit/Decimal";
            public const String Field_Edit_Enum = "Fields/Edit/Enum";
            public const String Field_Edit_Key = "Fields/Edit/Key";
            public const String Field_Edit_DisplayColumn = "Fields/Edit/DisplayColumn";
            public const String Field_Edit_Empty = "Fields/Edit/Empty";
            public const String Field_Edit_FormatString = "Fields/Edit/FormatString";
            public const String Field_Edit_Hidden = "Fields/Edit/Hidden";
            public const String Field_Edit_IModel = "Fields/Edit/IModel";
            // public const String Field_Edit_IModelCollection = "Fields/Edit/IModelCollection";
            public const String Field_Edit_Int = "Fields/Edit/Int";
            public const String Field_Edit_Long = "Fields/Edit/Long";
            public const String Field_Edit_IntRange = "Fields/Edit/IntRange";
            public const String Field_Edit_String = "Fields/Edit/String";
            public const String Field_Edit_StringMultiLine = "Fields/Edit/StringMultiLine";
            public const String Field_Edit_Unknown = "Fields/Edit/Unknown";

            public const String Field_FileUpload = "Fields/FileUpload";

            public const String Field_Information = "Fields/Information";
        }

        public static class AutomaticFields
        {
            public const String Active = "Active";
            public const String Created = "Created";
            public const String Updated = "Updated";
        }

        public const Boolean AllowRegister = false;
        public const Boolean AllowExternalLogin = false;
        public const Boolean AllowLoginCookie = true;

        public const String StatusMessage = "TempStatusMessage";
        public const String StatusMessageIcon = "TempStatusMessageIcon";

        public const String UserSessionID = "ProfileUserSession";
        public const String RoleSessionID = "ProfileRoleSession";


        public static Boolean IsLoggedIn(HttpSessionStateBase Session)
        {
            return WebSecurity.HasUserId &&
                ContextProviderFactory.GetCurrent().CurrentUser(Session) != null &&
                ContextProviderFactory.GetCurrent().CurrentRole(Session) != null;
        }

        public static Boolean AllowEdit(HttpSessionStateBase Session, Type t)
        {
            return Session != null &&
                ContextProviderFactory.GetCurrent().CurrentRole(Session) != null &&
                ContextProviderFactory.GetCurrent().GetModelPermissions(Session, t).Edit == true;
        }

        public static Boolean AllowDeactivate(HttpSessionStateBase Session, Type t)
        {
            return Session != null &&
                ContextProviderFactory.GetCurrent().CurrentRole(Session) != null &&
                ContextProviderFactory.GetCurrent().GetModelPermissions(Session, t).Deactivate == true;
        }

        public static Boolean AllowCreate(HttpSessionStateBase Session, Type t)
        {
            return Session != null &&
                ContextProviderFactory.GetCurrent().CurrentRole(Session) != null &&
                ContextProviderFactory.GetCurrent().GetModelPermissions(Session, t).Create == true;
        }

        public static Boolean AllowView(HttpSessionStateBase Session, Type t)
        {
            return Session != null &&
                ContextProviderFactory.GetCurrent().CurrentRole(Session) != null &&
                ContextProviderFactory.GetCurrent().GetModelPermissions(Session, t).View == true;
        }

        public static Boolean AllowViewInactive(HttpSessionStateBase Session, Type t)
        {
            return Session != null &&
                ContextProviderFactory.GetCurrent().CurrentRole(Session) != null &&
                ContextProviderFactory.GetCurrent().GetModelPermissions(Session, t).ViewInactive == true;
        }

        public static Boolean AllowExport(HttpSessionStateBase Session, Type t)
        {
            return Session != null &&
                ContextProviderFactory.GetCurrent().CurrentRole(Session) != null &&
                ContextProviderFactory.GetCurrent().GetModelPermissions(Session, t).Export == true;
        }


        public static void HandleError(HttpContextBase HttpContext, Exception Ex)
        {
            ModelContext Context = ContextProviderFactory.GetCurrent().GetContext(HttpContext.Session);

            if (Context.ContextTypes.Has(typeof(MVCL.Models.Error)))
            {
                DbSet<MVCL.Models.Error> ErrorsTable = Context.GetDBSet<MVCL.Models.Error>();

                try
                {
                    MVCL.Models.Error Error = new Error();
                    Error.Message = Ex.Message;
                    Error.FullDetails = Ex.ToString();
                    Error.Created = DateTime.Now;
                    Error.Active = true;
                    Error.URL = HttpContext.Request.Url.AbsoluteUri;

                    if (ErrorsTable.Where(
                            e => e.FullDetails == Error.FullDetails &&
                            e.URL == Error.URL &&
                                //                            e.Created.Date == Error.Created.Date &&
                            e.Active == true).Count() > 0)
                    {
                        // Don't duplicate errors more than once per day.
                        return;
                    }

                    ErrorsTable.Add(Error);
                    Context.SaveChanges();
                }
                catch
                {

                }
            }
        }

        public static void WriteCSV(this HttpResponseBase Response, String[] CSVData, String FileName)
        {
            Response.WriteCSV(CSVData.JoinLines(), FileName);
        }

        public static void WriteCSV(this HttpResponseBase Response, String CSVData, String FileName)
        {
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ".csv");
            Response.ContentType = "text/csv";
            Response.Write(CSVData);
            Response.End();
        }

        public static void WriteCSV(this HttpResponseBase Response, StringWriter sw, String FileName)
        {
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ".csv");
            Response.ContentType = "text/csv";
            Response.Write(sw);
            Response.End();
        }

        public static void WriteFile(this HttpResponseBase Response, String FilePath)
        {
            String FileName = Path.GetFileName(FilePath);

            if (!File.Exists(FilePath))
                return;

            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + "");
            Response.AddHeader("Content-Length", new FileInfo(FilePath).Length.ToString());
            Response.WriteFile(FilePath);
            Response.End();
        }

        public static void WritePDF(this HttpResponseBase Response, Byte[] PDF_Bytes, String FileName)
        {
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + "");
            Response.AddHeader("Content-Length", PDF_Bytes.Length.ToString());

            Response.ContentType = "application/pdf";
            Response.BinaryWrite(PDF_Bytes);
            Response.End();
        }


        public const String Script_Singularity = "~/Scripts/singularity";
        public const String Style_Singularity = "~/Content/singularity";

        public const String Script_MVCL = "~/Scripts/mvcl";
        public const String Style_MVCL = "~/Content/mvcl";

        public const String Style_JQuery_Mobile = "~/Content/jquery-mobile";
        public const String Script_JQuery_Mobile = "~/Scripts/jquery-mobile";

        public const String Script_MVCL_Chance = "~/Scripts/mvcl/chance";
        public const String Script_MVCL_qTip = "~/Scripts/mvcl/qTip";
        public const String Script_MVCL_jQueryCookie = "~/Scripts/mvcl/jquery.cookie";
        public const String Script_MVCL_jQueryMousewheel = "~/Scripts/mvcl/jquery.mousewheel";
        public const String Script_MVCL_jQueryTimepicker = "~/bundles/mvcl/jquery.timepicker";

        public static void RegisterBundles(System.Web.Optimization.BundleCollection bundles, Boolean IncludedLib)
        {

            String Root = IncludedLib ? "~/bin/" : "~/";


            bundles.Add(new StyleBundle(Style_MVCL).Include(
                Root + "Content/mvcl.css"));

            bundles.Add(new ScriptBundle(Script_MVCL).Include(
                        Root + "Scripts/mvcl.js"));

            #region Singularity
            bundles.Add(new ScriptBundle(Script_Singularity).Include(
                        Root + "Scripts/singularity/singularity-core.js",
                        Root + "Scripts/singularity/singularity-tests.js",
                        Root + "Scripts/singularity/singularity-enumerable.js",
                        Root + "Scripts/singularity/singularity-js-function.js",
                        Root + "Scripts/singularity/singularity-js-object.js",
                        Root + "Scripts/singularity/singularity-js-array.js",
                        Root + "Scripts/singularity/singularity-js-boolean.js",
                        Root + "Scripts/singularity/singularity-js-number.js",
                        Root + "Scripts/singularity/singularity-js-date.js",
                        Root + "Scripts/singularity/singularity-js-string.js",
                        Root + "Scripts/singularity/singularity-text-bbcode.js",
                        Root + "Scripts/singularity/singularity-regexp.js",
                        Root + "Scripts/singularity/singularity-templates.js",
                        Root + "Scripts/singularity/singularity-object.js",
                        Root + "Scripts/singularity/singularity-jquery.js",
                        Root + "Scripts/singularity/singularity-html.js",
                        Root + "Scripts/singularity/singularity-doc.js",
                        Root + "Scripts/singularity/singularity-log.js"));

            bundles.Add(new StyleBundle(Style_Singularity).Include(
                Root + "Content/singularity.css"));
            #endregion

            bundles.Add(new ScriptBundle(Script_JQuery_Mobile).Include(
                        Root + "Scripts/jquery-mobile/jquery.mobile.custom.js"));

            bundles.Add(new ScriptBundle(Style_JQuery_Mobile).Include(
                        Root + "Scripts/jquery-mobile/jquery.mobile.custom.theme.css"));

            bundles.Add(new ScriptBundle(Script_MVCL_Chance).Include(
                        Root + "Scripts/chance.js"));

            bundles.Add(new ScriptBundle(Script_MVCL_qTip).Include(
                        Root + "Scripts/qTip.js"));

            bundles.Add(new ScriptBundle(Script_MVCL_jQueryCookie).Include(
                        Root + "Scripts/jquery.cookie.js"));

            bundles.Add(new ScriptBundle(Script_MVCL_jQueryMousewheel).Include(
                        Root + "Scripts/jquery.mousewheel.js"));

            bundles.Add(new ScriptBundle(Script_MVCL_jQueryTimepicker).Include(
                      "~/Scripts/jquery.timepicker.js"));
        }

    }
}
