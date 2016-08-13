﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.Design;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Mvc.Routing;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 3 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
    using LCore.Extensions;
    
    #line default
    #line hidden
    using LMVC;
    using LMVC.Account;
    using LMVC.Annotations;
    using LMVC.Context;
    using LMVC.Controllers;
    using LMVC.Extensions;
    using LMVC.Models;
    using LMVC.Routes;
    using Singularity;
    
    #line 4 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
    using Singularity.Extensions;
    
    #line default
    #line hidden
    using Singularity.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Manage/Fields/FileUpload.cshtml")]
    public partial class _Views_Shared_Manage_Fields_FileUpload_cshtml : System.Web.Mvc.WebViewPage<IViewField>
    {
        public _Views_Shared_Manage_Fields_FileUpload_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n\r\n");

WriteLiteral("\r\n");

            
            #line 6 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
  
    var Context = ContextProviderFactory.GetCurrent().GetContext(Session);

    // ReSharper disable RedundantNameQualifier
    var CurrentFiles = new List<FileUpload>();

    var Attr = Model.Meta.GetAttribute<IFileUpload>();

    if (Context.ContextTypes.Has(typeof(FileUpload)))
        {
        CurrentFiles = FileUpload.GetFileUploads(Context, Model.ModelData, Model.PropertyName).List();
        }
    // ReSharper restore RedundantNameQualifier

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 23 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
 if (Attr != null && Model.ViewTypes.Has(ControllerHelper.ViewType.Edit))
    {
    if (CurrentFiles.Count > 0 &&
        Attr.AllowMultipleUploads == false)
        {
        }
    else
        {

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteAttribute("id", Tuple.Create(" id=\"", 800), Tuple.Create("\"", 836)
, Tuple.Create(Tuple.Create("", 805), Tuple.Create("upload-file-", 805), true)
            
            #line 31 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
, Tuple.Create(Tuple.Create("", 817), Tuple.Create<System.Object, System.Int32>(Model.PropertyName
            
            #line default
            #line hidden
, 817), false)
);

WriteLiteral(">\r\n\r\n            <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n                $(document).ready(function () {\r\n                    $(\'#file-" +
"upload-button-");

            
            #line 35 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                      Write(Model.PropertyName);

            
            #line default
            #line hidden
WriteLiteral("\').click(function () {\r\n\r\n                        $(\'.file-upload-error-no-file-");

            
            #line 37 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                                 Write(Model.PropertyName);

            
            #line default
            #line hidden
WriteLiteral("\').hide();\r\n\r\n                        const fileName = $(\'#file-upload-");

            
            #line 39 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                                    Write(Model.PropertyName);

            
            #line default
            #line hidden
WriteLiteral("\').val();\r\n                        if (!fileName) {\r\n                            " +
"$(\'.file-upload-error-no-file-");

            
            #line 41 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                                     Write(Model.PropertyName);

            
            #line default
            #line hidden
WriteLiteral("\').show();\r\n                            return;\r\n                        }\r\n\r\n   " +
"                     $(\'#file-upload-button-");

            
            #line 45 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                          Write(Model.PropertyName);

            
            #line default
            #line hidden
WriteLiteral("\').attr(\'disabled\', \'true\');\r\n                        $(\'#file-upload-button-");

            
            #line 46 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                          Write(Model.PropertyName);

            
            #line default
            #line hidden
WriteLiteral(" span\').html(\'Uploading\');\r\n\r\n                        var size = null;\r\n\r\n       " +
"                 const restrictFileType = ");

            
            #line 50 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                             Write(Attr.AllowFileTypes == null || Attr.AllowFileTypes.Length == 0 ? "false" : "true");

            
            #line default
            #line hidden
WriteLiteral(";\r\n\r\n                        $(\'.file-upload-error-incorrect-type-");

            
            #line 52 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                                         Write(Model.PropertyName);

            
            #line default
            #line hidden
WriteLiteral("\').hide();\r\n                        if (restrictFileType) {\r\n                    " +
"        const fileTypes = ");

            
            #line 54 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                         Write(Html.Raw($"[\'{Attr.AllowFileTypes.JoinLines("','").ToLower().ReplaceAll(".", "")}\']"));

            
            #line default
            #line hidden
WriteLiteral(@";

                            let typeFound = false;
                            for (let i = 0 ; i < fileTypes.length; i++)
                            {
                                if (fileName.toLowerCase().indexOf(fileTypes[i]) == fileName.length - fileTypes[i].length)
                                {
                                    typeFound = true;
                                    break;
                                }
                            }
                            if (!typeFound)
                            {
                                $('.file-upload-error-incorrect-type-");

            
            #line 67 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                                                 Write(Model.PropertyName);

            
            #line default
            #line hidden
WriteLiteral("\').show();\r\n                                return;\r\n                            " +
"}\r\n                        }\r\n\r\n                        if ($(\'#file-upload-");

            
            #line 72 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                        Write(Model.PropertyName);

            
            #line default
            #line hidden
WriteLiteral("\')[0].files && $(\'#file-upload-");

            
            #line 72 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                                                                            Write(Model.PropertyName);

            
            #line default
            #line hidden
WriteLiteral("\')[0].files[0])\r\n                            size = $(\'#file-upload-");

            
            #line 73 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                               Write(Model.PropertyName);

            
            #line default
            #line hidden
WriteLiteral("\')[0].files[0].size;\r\n\r\n                        $(\'.file-upload-error-too-small-");

            
            #line 75 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                                    Write(Model.PropertyName);

            
            #line default
            #line hidden
WriteLiteral("\').hide();\r\n                        $(\'.file-upload-error-too-large-");

            
            #line 76 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                                    Write(Model.PropertyName);

            
            #line default
            #line hidden
WriteLiteral("\').hide();\r\n\r\n                        if (size != null) {\r\n\r\n                    " +
"        if (size < ");

            
            #line 80 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                   Write(Attr.SizeMinimum);

            
            #line default
            #line hidden
WriteLiteral(" )\r\n                            {\r\n                            $(\'.file-upload-er" +
"ror-too-small-");

            
            #line 82 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                                        Write(Model.PropertyName);

            
            #line default
            #line hidden
WriteLiteral("\').show();\r\n                            return;\r\n                        }\r\n\r\n   " +
"                     if (size > ");

            
            #line 86 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                               Write(Attr.SizeMaximum);

            
            #line default
            #line hidden
WriteLiteral(" )\r\n                        {\r\n                        $(\'.file-upload-error-too-" +
"large-");

            
            #line 88 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                                    Write(Model.PropertyName);

            
            #line default
            #line hidden
WriteLiteral("\').show();\r\n                        return;\r\n                    }\r\n             " +
"       }\r\n\r\n                    const parentForm = $(\'#file-upload-button-");

            
            #line 93 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                                         Write(Model.PropertyName);

            
            #line default
            #line hidden
WriteLiteral("\').parents(\'form\')[0];\r\n\r\n                $.ajax({\r\n                    url: \'/");

            
            #line 96 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                       Write(Html.ControllerName());

            
            #line default
            #line hidden
WriteLiteral("/UploadFile?ReturnURL=");

            
            #line 96 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                                                    Write(Request.Url);

            
            #line default
            #line hidden
WriteLiteral("?.AbsoluteUri&RelationType=");

            
            #line 96 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                                                                                           Write(Model.ModelData.TrueModelType().FullName);

            
            #line default
            #line hidden
WriteLiteral("&RelationProperty=");

            
            #line 96 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                                                                                                                                                      Write(Model.PropertyName);

            
            #line default
            #line hidden
WriteLiteral("&RelationID=");

            
            #line 96 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                                                                                                                                                                                     Write(Model.ModelData.GetID());

            
            #line default
            #line hidden
WriteLiteral(@"',
                    type: 'POST',
                    data: new FormData(parentForm),
                    processData: false,
                    contentType: false,

                    success: function () {
                        location.reload();
                    },
                    error: function (e) {
                        console.log(e);
                        $('.file-upload-error-");

            
            #line 107 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                         Write(Model.PropertyName);

            
            #line default
            #line hidden
WriteLiteral("\').show();\r\n                    }\r\n                });\r\n                });\r\n    " +
"            });\r\n            </script>\r\n\r\n            <input");

WriteLiteral(" type=\"file\"");

WriteLiteral(" class=\"file-upload\"");

WriteAttribute("id", Tuple.Create(" id=\"", 4743), Tuple.Create("\"", 4779)
, Tuple.Create(Tuple.Create("", 4748), Tuple.Create("file-upload-", 4748), true)
            
            #line 114 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
, Tuple.Create(Tuple.Create("", 4760), Tuple.Create<System.Object, System.Int32>(Model.PropertyName
            
            #line default
            #line hidden
, 4760), false)
);

WriteAttribute("name", Tuple.Create(" name=\"", 4780), Tuple.Create("\"", 4818)
, Tuple.Create(Tuple.Create("", 4787), Tuple.Create("UploadFile", 4787), true)
            
            #line 114 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                         , Tuple.Create(Tuple.Create("", 4797), Tuple.Create<System.Object, System.Int32>(Model.PropertyName
            
            #line default
            #line hidden
, 4797), false)
);

WriteLiteral(" />\r\n\r\n            <div");

WriteAttribute("class", Tuple.Create(" class=\"", 4842), Tuple.Create("\"", 4908)
, Tuple.Create(Tuple.Create("", 4850), Tuple.Create("file-upload-error-incorrect-type-", 4850), true)
            
            #line 116 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
, Tuple.Create(Tuple.Create("", 4883), Tuple.Create<System.Object, System.Int32>(Model.PropertyName
            
            #line default
            #line hidden
, 4883), false)
, Tuple.Create(Tuple.Create(" ", 4902), Tuple.Create("error", 4903), true)
);

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">\r\n                File types allowed: ");

            
            #line 117 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                Write(Attr.AllowFileTypes.JoinLines(", ").ToUpper().ReplaceAll(".", ""));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n\r\n            <div");

WriteAttribute("class", Tuple.Create(" class=\"", 5078), Tuple.Create("\"", 5139)
, Tuple.Create(Tuple.Create("", 5086), Tuple.Create("file-upload-error-too-large-", 5086), true)
            
            #line 120 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
, Tuple.Create(Tuple.Create("", 5114), Tuple.Create<System.Object, System.Int32>(Model.PropertyName
            
            #line default
            #line hidden
, 5114), false)
, Tuple.Create(Tuple.Create(" ", 5133), Tuple.Create("error", 5134), true)
);

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">\r\n                Upload can not be larger than <b>");

            
            #line 121 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                            Write(Attr.SizeMaximum.FormatFileSize(Decimals: 2));

            
            #line default
            #line hidden
WriteLiteral("</b>\r\n            </div>\r\n\r\n            <div");

WriteAttribute("class", Tuple.Create(" class=\"", 5303), Tuple.Create("\"", 5364)
, Tuple.Create(Tuple.Create("", 5311), Tuple.Create("file-upload-error-too-small-", 5311), true)
            
            #line 124 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
, Tuple.Create(Tuple.Create("", 5339), Tuple.Create<System.Object, System.Int32>(Model.PropertyName
            
            #line default
            #line hidden
, 5339), false)
, Tuple.Create(Tuple.Create(" ", 5358), Tuple.Create("error", 5359), true)
);

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">\r\n                Upload must be at least <b>");

            
            #line 125 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                                      Write(Attr.SizeMinimum.FormatFileSize(Decimals: 2));

            
            #line default
            #line hidden
WriteLiteral("</b>\r\n            </div>\r\n\r\n            <div");

WriteAttribute("class", Tuple.Create(" class=\"", 5522), Tuple.Create("\"", 5581)
, Tuple.Create(Tuple.Create("", 5530), Tuple.Create("file-upload-error-no-file-", 5530), true)
            
            #line 128 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
, Tuple.Create(Tuple.Create("", 5556), Tuple.Create<System.Object, System.Int32>(Model.PropertyName
            
            #line default
            #line hidden
, 5556), false)
, Tuple.Create(Tuple.Create(" ", 5575), Tuple.Create("error", 5576), true)
);

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">\r\n                Please select a file to upload.\r\n            </div>\r\n\r\n       " +
"     <div");

WriteAttribute("class", Tuple.Create(" class=\"", 5694), Tuple.Create("\"", 5745)
, Tuple.Create(Tuple.Create("", 5702), Tuple.Create("file-upload-error-", 5702), true)
            
            #line 132 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
, Tuple.Create(Tuple.Create("", 5720), Tuple.Create<System.Object, System.Int32>(Model.PropertyName
            
            #line default
            #line hidden
, 5720), false)
, Tuple.Create(Tuple.Create(" ", 5739), Tuple.Create("error", 5740), true)
);

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">\r\n                An error occured while uploading this file.\r\n            </div" +
">\r\n\r\n            <div");

WriteLiteral(" class=\"btn btn-default\"");

WriteAttribute("id", Tuple.Create(" id=\"", 5894), Tuple.Create("\"", 5937)
, Tuple.Create(Tuple.Create("", 5899), Tuple.Create("file-upload-button-", 5899), true)
            
            #line 136 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
, Tuple.Create(Tuple.Create("", 5918), Tuple.Create<System.Object, System.Int32>(Model.PropertyName
            
            #line default
            #line hidden
, 5918), false)
);

WriteLiteral(">\r\n                <glyph>&#xE027;</glyph>\r\n                <span>Upload</span>\r\n" +
"            </div>\r\n        </div>\r\n");

            
            #line 141 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
        }
    }
else if (Model.ViewTypes.Has(ControllerHelper.ViewType.TableCell))
    {
    }
else if (Model.ViewTypes.Has(ControllerHelper.ViewType.Display))
    {
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 150 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
 if (Model.ViewTypes.Has(ControllerHelper.ViewType.Edit) ||
                                                Model.ViewTypes.Has(ControllerHelper.ViewType.Display))
    {
    foreach (var File in CurrentFiles)
        {
        string Ext = Path.GetExtension(File.FilePath);

        if (Ext != null && Ext.StartsWith("."))
            {
            Ext = Ext.Substring(startIndex: 1);
            }


            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"display-file border-round\"");

WriteLiteral(">\r\n\r\n            <div");

WriteLiteral(" class=\"file-icon\"");

WriteLiteral(">\r\n                <a");

WriteAttribute("href", Tuple.Create(" href=\"", 6755), Tuple.Create("\"", 6864)
            
            #line 165 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
, Tuple.Create(Tuple.Create("", 6762), Tuple.Create<System.Object, System.Int32>(Url.Controller<ManageController>().Action(Controller => Controller.DownloadFile, File.FileUploadID)
            
            #line default
            #line hidden
, 6762), false)
);

WriteLiteral(">\r\n                    <img");

WriteAttribute("src", Tuple.Create(" src=\"", 6892), Tuple.Create("\"", 6928)
, Tuple.Create(Tuple.Create("", 6898), Tuple.Create("/Content/icons/32px/", 6898), true)
            
            #line 166 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
, Tuple.Create(Tuple.Create("", 6918), Tuple.Create<System.Object, System.Int32>(Ext
            
            #line default
            #line hidden
, 6918), false)
, Tuple.Create(Tuple.Create("", 6924), Tuple.Create(".png", 6924), true)
);

WriteLiteral(" alt=\"Image not found\"");

WriteLiteral(" error-src=\"/Content/icons/32px/_blank.png\"");

WriteLiteral(" />\r\n                </a>\r\n            </div>\r\n            <div>\r\n               " +
" <a");

WriteAttribute("href", Tuple.Create(" href=\"", 7078), Tuple.Create("\"", 7187)
            
            #line 170 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
, Tuple.Create(Tuple.Create("", 7085), Tuple.Create<System.Object, System.Int32>(Url.Controller<ManageController>().Action(Controller => Controller.DownloadFile, File.FileUploadID)
            
            #line default
            #line hidden
, 7085), false)
);

WriteLiteral(">\r\n                    Name:\r\n");

WriteLiteral("                    ");

            
            #line 172 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
               Write(Path.GetFileName(File.FilePath));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </a>\r\n            </div>\r\n\r\n            <div>\r\n                " +
"Size:\r\n");

WriteLiteral("                ");

            
            #line 178 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
           Write(File.FileSize.FormatFileSize(Decimals: 1));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n\r\n");

            
            #line 181 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
            
            
            #line default
            #line hidden
            
            #line 181 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
             if (Attr?.AllowDeactivate == true)
                {

            
            #line default
            #line hidden
WriteLiteral("                <a");

WriteLiteral(" class=\"btn btn-default\"");

WriteAttribute("id", Tuple.Create(" id=\"", 7550), Tuple.Create("\"", 7593)
, Tuple.Create(Tuple.Create("", 7555), Tuple.Create("file-upload-button-", 7555), true)
            
            #line 183 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
, Tuple.Create(Tuple.Create("", 7574), Tuple.Create<System.Object, System.Int32>(Model.PropertyName
            
            #line default
            #line hidden
, 7574), false)
);

WriteAttribute("href", Tuple.Create("\r\n                   href=\"", 7594), Tuple.Create("\"", 7747)
            
            #line 184 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
, Tuple.Create(Tuple.Create("", 7621), Tuple.Create<System.Object, System.Int32>(Url.Controller<ManageController>().Action(Controller => Controller.DeleteFile, File.FileUploadID, Request.Url?.AbsoluteUri)
            
            #line default
            #line hidden
, 7621), false)
);

WriteLiteral(">\r\n                    <glyph>&#xe014;</glyph>\r\n                    Remove\r\n     " +
"           </a>\r\n");

            
            #line 188 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n");

            
            #line 190 "..\..\Views\Shared\Manage\Fields\FileUpload.cshtml"
        }
    }

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
