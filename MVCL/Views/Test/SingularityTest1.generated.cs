﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    
    #line 11 "..\..\Views\Test\SingularityTest.cshtml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 12 "..\..\Views\Test\SingularityTest.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 13 "..\..\Views\Test\SingularityTest.cshtml"
    using System.ComponentModel;
    
    #line default
    #line hidden
    
    #line 14 "..\..\Views\Test\SingularityTest.cshtml"
    using System.ComponentModel.DataAnnotations;
    
    #line default
    #line hidden
    
    #line 15 "..\..\Views\Test\SingularityTest.cshtml"
    using System.ComponentModel.Design;
    
    #line default
    #line hidden
    using System.IO;
    
    #line 9 "..\..\Views\Test\SingularityTest.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 10 "..\..\Views\Test\SingularityTest.cshtml"
    using System.Linq.Expressions;
    
    #line default
    #line hidden
    using System.Net;
    using System.Text;
    
    #line 16 "..\..\Views\Test\SingularityTest.cshtml"
    using System.Web;
    
    #line default
    #line hidden
    using System.Web.Helpers;
    
    #line 17 "..\..\Views\Test\SingularityTest.cshtml"
    using System.Web.Mvc;
    
    #line default
    #line hidden
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 3 "..\..\Views\Test\SingularityTest.cshtml"
    using LCore;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\Test\SingularityTest.cshtml"
    using MVCL;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Views\Test\SingularityTest.cshtml"
    using MVCL.Context;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Views\Test\SingularityTest.cshtml"
    using MVCL.Controllers;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Views\Test\SingularityTest.cshtml"
    using MVCL.Models;
    
    #line default
    #line hidden
    
    #line 8 "..\..\Views\Test\SingularityTest.cshtml"
    using MVCL.Routes;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Test/SingularityTest.cshtml")]
    public partial class _Views_Test_SingularityTest_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Test_SingularityTest_cshtml()
        {
        }
        public override void Execute()
        {


WriteLiteral("\r\n\r\n");
















WriteLiteral("\r\n");


            
            #line 19 "..\..\Views\Test\SingularityTest.cshtml"
  
    /// <reference path="singularity-core.ts" />
    Layout = Layouts.MainLayout;


            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div class=\"mvcl-test singularity-test\" sing-fill=\"{{ Singularity with sing }" +
"}\"></div>\r\n\r\n\r\n<div class=\"mvcl-test singularity-test\">\r\n\r\n    <div>\r\n        <s" +
"cript type=\"text/javascript\">\r\n            $().init(function () {\r\n             " +
"   sing.loadTemplate(\'/Templates/Templates.html\', function () {\r\n               " +
"     sing.initTemplates();\r\n                });\r\n            });\r\n\r\n            " +
"$().ready(function () {\r\n\r\n                $(\'#singularity-output\').html(sing.ge" +
"tSummary(\'\', false, false).textToHTML().replaceAll(\'(100%)\', \'<b>(&nbsp;100%&nbs" +
"p;)</b>\'));\r\n\r\n                $(\'#singularity-tests-module\').html(sing.getSumma" +
"ry(\'Singularity.Tests.\', false, false).textToHTML().replaceAll(\'(100%)\', \'<b>(&n" +
"bsp;100%&nbsp;)</b>\'));\r\n                $(\'#singularity-docs-module\').html(sing" +
".getSummary(\'Singularity.Documentation.\', false, false).textToHTML().replaceAll(" +
"\'(100%)\', \'<b>(&nbsp;100%&nbsp;)</b>\'));\r\n                $(\'#singularity-enumer" +
"able-module\').html(sing.getSummary(\'Singularity.Enumerable.\', false, false).text" +
"ToHTML().replaceAll(\'(100%)\', \'<b>(&nbsp;100%&nbsp;)</b>\'));\r\n                $(" +
"\'#singularity-bbcode-module\').html(sing.getSummary(\'Singularity.BBCode.\', false," +
" false).textToHTML().replaceAll(\'(100%)\', \'<b>(&nbsp;100%&nbsp;)</b>\'));\r\n      " +
"          $(\'#singularity-regexp-module\').html(sing.getSummary(\'Singularity.RegE" +
"xp.\', false, false).textToHTML().replaceAll(\'(100%)\', \'<b>(&nbsp;100%&nbsp;)</b>" +
"\'));\r\n                $(\'#singularity-templates-module\').html(sing.getSummary(\'S" +
"ingularity.Templates.\', false, false).textToHTML().replaceAll(\'(100%)\', \'<b>(&nb" +
"sp;100%&nbsp;)</b>\'));\r\n                $(\'#singularity-logging-module\').html(si" +
"ng.getSummary(\'Singularity.Logging.\', false, false).textToHTML().replaceAll(\'(10" +
"0%)\', \'<b>(&nbsp;100%&nbsp;)</b>\'));\r\n                $(\'#singularity-html-modul" +
"e\').html(sing.getSummary(\'Singularity.html.\', false, false).textToHTML().replace" +
"All(\'(100%)\', \'<b>(&nbsp;100%&nbsp;)</b>\'));\r\n\r\n\r\n                $(\'#singularit" +
"y-output-object\').html(sing.getSummary(\'Singularity.object.\', false, false).text" +
"ToHTML().replaceAll(\'(100%)\', \'<b>(&nbsp;100%&nbsp;)</b>\'));\r\n                $(" +
"\'#singularity-output-boolean\').html(sing.getSummary(\'Singularity.Boolean.\', fals" +
"e, false).textToHTML().replaceAll(\'(100%)\', \'<b>(&nbsp;100%&nbsp;)</b>\'));\r\n    " +
"            $(\'#singularity-output-number\').html(sing.getSummary(\'Singularity.Nu" +
"mber.\', false, false).textToHTML().replaceAll(\'(100%)\', \'<b>(&nbsp;100%&nbsp;)</" +
"b>\'));\r\n                $(\'#singularity-output-string\').html(sing.getSummary(\'Si" +
"ngularity.String.\', false, false).textToHTML().replaceAll(\'(100%)\', \'<b>(&nbsp;1" +
"00%&nbsp;)</b>\'));\r\n                $(\'#singularity-output-date\').html(sing.getS" +
"ummary(\'Singularity.Date.\', false, false).textToHTML().replaceAll(\'(100%)\', \'<b>" +
"(&nbsp;100%&nbsp;)</b>\'));\r\n                $(\'#singularity-output-array\').html(" +
"sing.getSummary(\'Singularity.Array.\', false, false).textToHTML().replaceAll(\'(10" +
"0%)\', \'<b>(&nbsp;100%&nbsp;)</b>\'));\r\n                $(\'#singularity-output-jqu" +
"ery\').html(sing.getSummary(\'Singularity.jQuery.\', false, false).textToHTML().rep" +
"laceAll(\'(100%)\', \'<b>(&nbsp;100%&nbsp;)</b>\'));\r\n                $(\'#singularit" +
"y-output-function\').html(sing.getSummary(\'Singularity.Function.\', false, false)." +
"textToHTML().replaceAll(\'(100%)\', \'<b>(&nbsp;100%&nbsp;)</b>\'));\r\n\r\n            " +
"    $(\'#singularity-output-test-results\').html(sing.runTests().textToHTML().repl" +
"aceAll(\'(100%)\', \'<b>(&nbsp;100%&nbsp;)</b>\'));\r\n\r\n                $(\'#singulari" +
"ty-output-bbcode-source\').html(sing.BBCodes.arrayValues(\'test\').joinLines().text" +
"ToHTML().replaceAll(\'(100%)\', \'<b>(&nbsp;100%&nbsp;)</b>\'));\r\n                $(" +
"\'#singularity-output-bbcode-results\').html(sing.BBCodes.arrayValues(\'test\').join" +
"Lines().bbCodesToHTML().replaceAll(\'(100%)\', \'<b>(&nbsp;100%&nbsp;)</b>\'));\r\n   " +
"         });\r\n        </script>\r\n        <h1>Singularity</h1>\r\n        <div id=\"" +
"singularity-output\"></div>\r\n        <h2>Modules</h2>\r\n        <h3>- Logging</h3>" +
"\r\n        <div id=\"singularity-logging-module\"></div>\r\n        <h3>- Tests</h3>\r" +
"\n        <div id=\"singularity-tests-module\"></div>\r\n        <h3>- Documentation<" +
"/h3>\r\n        <div id=\"singularity-docs-module\"></div>\r\n    </div>\r\n</div>\r\n\r\n<d" +
"iv class=\"mvcl-test singularity-test\">\r\n\r\n    <div>\r\n        <h3>Enumerable</h3>" +
"\r\n        <div id=\"singularity-enumerable-module\"></div>\r\n    </div>\r\n</div>\r\n\r\n" +
"<div class=\"mvcl-test singularity-test\">\r\n\r\n    <div>\r\n        <h3>Boolean</h3>\r" +
"\n        <div id=\"singularity-output-boolean\"></div>\r\n    </div>\r\n</div>\r\n\r\n<div" +
" class=\"mvcl-test singularity-test\">\r\n\r\n    <div>\r\n        <h3>Number</h3>\r\n    " +
"    <div id=\"singularity-output-number\"></div>\r\n    </div>\r\n</div>\r\n\r\n<div class" +
"=\"mvcl-test singularity-test\">\r\n\r\n    <div>\r\n        <h3>Date</h3>\r\n        <div" +
" id=\"singularity-output-date\"></div>\r\n    </div>\r\n</div>\r\n\r\n\r\n<div class=\"mvcl-t" +
"est singularity-test\">\r\n\r\n    <div>\r\n        <h3>Object</h3>\r\n        <div id=\"s" +
"ingularity-output-object\"></div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"mvcl-test si" +
"ngularity-test\">\r\n\r\n    <div>\r\n        <h3>String</h3>\r\n        <div id=\"singula" +
"rity-output-string\"></div>\r\n        <h3>- RegExp</h3>\r\n        <div id=\"singular" +
"ity-regexp-module\"></div>\r\n        <h3>- Templates</h3>\r\n        <div id=\"singul" +
"arity-templates-module\"></div>\r\n        <h3>- HTML</h3>\r\n        <div id=\"singul" +
"arity-html-module\"></div>\r\n        <h3>- BBCode</h3>\r\n        <div id=\"singulari" +
"ty-bbcode-module\"></div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"mvcl-test singularit" +
"y-test\">\r\n\r\n    <div>\r\n        <h3>Array</h3>\r\n        <div id=\"singularity-outp" +
"ut-array\"></div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"mvcl-test singularity-test\">" +
"\r\n\r\n    <div>\r\n        <h3>jQuery</h3>\r\n        <div id=\"singularity-output-jque" +
"ry\"></div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"mvcl-test singularity-test\">\r\n\r\n  " +
"  <div>\r\n        <h3>Function</h3>\r\n        <div id=\"singularity-output-function" +
"\"></div>\r\n    </div>\r\n</div>\r\n\r\n\r\n<div class=\"mvcl-test singularity-test\">\r\n\r\n  " +
"  <div>\r\n        <h3>BBCode Support</h3>\r\n        <div id=\"singularity-output-bb" +
"code-source\"></div>\r\n        <hr />\r\n        <div id=\"singularity-output-bbcode-" +
"results\"></div>\r\n    </div>\r\n</div>\r\n\r\n\r\n<div class=\"mvcl-test singularity-test\"" +
">\r\n\r\n    <div>\r\n        <h3>Test Results</h3>\r\n        <div id=\"singularity-outp" +
"ut-test-results\"></div>\r\n    </div>\r\n</div>\r\n");


        }
    }
}
#pragma warning restore 1591
