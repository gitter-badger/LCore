﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
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
  
    /// <reference path="singularity-core.margin:-10px 8px 17px;font-size:13px;ts" />
    Layout = Layouts.MainLayout;



            
            #line default
            #line hidden
WriteLiteral("\r\n<script type=\"text/javascript\">\r\n\r\n    sing.templateShown(function (element) {\r" +
"\n\r\n    })\r\n\r\n    $(document).init(function () {\r\n\r\n    });\r\n\r\n    $(document).re" +
"ady(function () {\r\n        (function () {\r\n            sing.tests.runTests();\r\n\r" +
"\n            sing.loadTemplate(\'/Templates/Common.html\', function () { });\r\n\r\n  " +
"          sing.initTemplates();\r\n\r\n            sing.ready();\r\n\r\n            $(\"." +
"tabs\").tabs({\r\n                collapsible: true\r\n            });\r\n        }).fn" +
"_defer()();\r\n    });\r\n</script>\r\n\r\n\r\n<div class=\"mvcl-test singularity-test sing" +
"\" sing-fill=\"{{ Singularity with sing }}\">\r\n\r\n\r\n    <br />\r\n    <br />\r\n    <br " +
"/>\r\n    <br />\r\n    <br />\r\n    <div style=\"text-align:center\">\r\n        <span c" +
"lass=\"glyphicon spin\" style=\"font-size: 36px;\">&#xe201;</span>\r\n    </div>\r\n    " +
"<br />\r\n    <br />\r\n    <br />\r\n    <br />\r\n    <br />\r\n    <br />\r\n    <br />\r\n" +
"    <br />\r\n</div>\r\n\r\n\r\n\r\n<div sing-template=\"Singularity\">\r\n    <h1>&#8226; Sin" +
"gularity</h1>\r\n\r\n    <p>{{sing.summary}}</p>\r\n\r\n    <div sing-if=\"{{sing.tests.t" +
"estErrors}}\" class=\"test-errors\">\r\n        <h2><error>Errors</error></h2>\r\n     " +
"   <ol>\r\n            <li sing-loop=\"{{ error in sing.tests.testErrors}}\">\r\n     " +
"           <error>{{error.textToHTML()}}</error>\r\n                <hr />\r\n      " +
"      </li>\r\n        </ol>\r\n    </div>\r\n\r\n    <div sing-fill=\"{{ Module with sin" +
"g.modules.Singularity as module }}\"></div>\r\n    <hr />\r\n</div>\r\n\r\n<div sing-temp" +
"late=\"Module\">\r\n    <div class=\"sing-module-totals\">\r\n        <div class=\"sing-m" +
"odule-total\">\r\n            <div class=\"right\" sing-fill=\"{{PercentSlider with [m" +
"odule.implementedMethodCount(), module.totalMethods()]}}\"></div>\r\n            <p" +
" style=\"float:right;\">Methods Implemented:</p>\r\n        </div>\r\n\r\n        <div s" +
"ing-if=\"{{module.requiredUnitTests}}\" class=\"sing-module-total\">\r\n            <d" +
"iv>\r\n                <div class=\"right\" sing-fill=\"{{PercentSlider with [module." +
"implementedMethodTests(), module.totalMethods()]}}\"></div>\r\n                <p s" +
"tyle=\"float:right;\">Unit Tests Implemented:</p>\r\n            </div>\r\n           " +
" <div>\r\n                <div class=\"right\" sing-fill=\"{{PercentSlider with [modu" +
"le.passedMethodTests(), module.implementedMethodTestsTotal()]}}\"></div>\r\n       " +
"         <p style=\"float:right;\">Unit Tests Passed:</p>\r\n            </div>\r\n\r\n " +
"       </div>\r\n\r\n        <div sing-if=\"{{module.srcLink}}\">\r\n            <a href" +
"=\"{{module.srcLink}}\" target=\"_blank\">View Source...</a>\r\n        </div>\r\n\r\n    " +
"    <div sing-if=\"{{module.totalProperties() > 0}}\" class=\"sing-module-total\">\r\n" +
"            <div>\r\n                <div class=\"right\" sing-fill=\"{{PercentSlider" +
" with [module.implementedProperties(), module.totalProperties()]}}\"></div>\r\n    " +
"            <p style=\"float:right;\">Properties:</p>\r\n            </div>\r\n       " +
" </div>\r\n\r\n        <div sing-if=\"{{module.requiredDocumentation}}\" class=\"sing-m" +
"odule-total\">\r\n            <div>\r\n                <div class=\"right\" sing-fill=\"" +
"{{PercentSlider with [module.implementedDocumentation(), module.totalDocumentati" +
"on()]}}\"></div>\r\n                <p style=\"float:right;\">Documentation:</p>\r\n   " +
"         </div>\r\n        </div>\r\n\r\n        <div sing-if=\"{{module.totalJSFiddle(" +
") > 0}}\" class=\"sing-module-total\">\r\n            <div style=\"display: block;heig" +
"ht: 15px;\">\r\n                <div class=\"right\" sing-fill=\"{{PercentSlider with " +
"[module.implementedJSFiddle(), module.totalJSFiddle()]}}\"></div>\r\n              " +
"  <p style=\"float:right;\">JSFiddle:</p>\r\n            </div>\r\n        </div>\r\n\r\n " +
"       <div class=\"sing-module-total\">\r\n            <strong>\r\n                <b" +
"r />\r\n                <div class=\"right wide\" sing-fill=\"{{PercentSlider with [m" +
"odule.implementedItems(), module.totalItems()]}}\"></div>\r\n                <p sty" +
"le=\"float:right;\">Total:</p>\r\n                <br /><br />\r\n            </strong" +
">\r\n        </div>\r\n    </div>\r\n\r\n    <h2 sing-if=\"{{module.parentModule}}\">{{mod" +
"ule.name}}</h2>\r\n\r\n    <p sing-if=\"{{module.summaryShort}}\" class=\"sing-module-s" +
"ummary\">\r\n        <strong>{{module.summaryShort.textToHTML()}}</strong>\r\n    </p" +
">\r\n    <p sing-else>\r\n        <strong>[Summary]</strong>\r\n    </p>\r\n\r\n    <p sin" +
"g-if=\"{{module.summaryLong}}\" class=\"sing-module-summary\">\r\n        <strong>{{mo" +
"dule.summaryLong.textToHTML()}}</strong>\r\n    </p>\r\n    <p sing-else>\r\n        <" +
"strong>[Long Summary]</strong>\r\n    </p>\r\n\r\n\r\n    <div sing-if=\"{{module.feature" +
"s}}\" class=\"sing-module-features\">\r\n        Features:\r\n        <ul>\r\n           " +
" <li sing-loop=\"{{feature in module.features}}\">\r\n                {{feature}}\r\n " +
"           </li>\r\n        </ul>\r\n    </div>\r\n\r\n    <div sing-if=\"{{module.resour" +
"ces}}\" class=\"sing-module-resources\">\r\n        Resources:\r\n        <ul>\r\n       " +
"     <li sing-loop=\"{{resource in module.resources}}\">\r\n                <a href=" +
"\"{{resource$key}}\">{{resource}}</a>\r\n            </li>\r\n        </ul>\r\n    </div" +
">\r\n\r\n    <div sing-if=\"{{module.features}}\">\r\n        <b>Features:</b>\r\n\r\n      " +
"  <div sing-fill=\"{{ Feature with feature in module.features}}\"></div>\r\n    </di" +
"v>\r\n\r\n    <div class=\"sing-module-methods\">\r\n        <div class=\"btn-info btn le" +
"ft method-show-hide\" click-fade-toggle=\".methods-{{module.name.toSlug()}}\">\r\n   " +
"         <glyph class=\"methods-{{module.name.toSlug()}}\">&#x2b;</glyph>\r\n       " +
"     <glyph class=\"methods-{{module.name.toSlug()}}\" style=\" display: none;\">&#x" +
"2212;</glyph>\r\n        </div>\r\n        <h4>Methods</h4>\r\n        <div class=\"met" +
"hods-{{module.name.toSlug()}}\" style=\"display:none;\">\r\n            <div sing-loo" +
"p=\"{{ method in module.methods }}\" class=\"sing-method-list\">\r\n                <d" +
"iv sing-fill=\"{{ Method with method }}\"></div>\r\n            </div>\r\n\r\n          " +
"  <div sing-if=\"{{module.getUnknownMethods()}}\">\r\n                <b>Unknown Met" +
"hods:</b>\r\n                <error sing-loop=\"{{ methodName in module.getUnknownM" +
"ethods()}}\">{{methodName}}</error>\r\n            </div>\r\n        </div>\r\n    </di" +
"v>\r\n\r\n    <div class=\"sing-module-properties\">\r\n        <div class=\"btn-info btn" +
" left method-show-hide\" click-fade-toggle=\".properties-{{module.name.toSlug()}}\"" +
">\r\n            <glyph class=\"properties-{{module.name.toSlug()}}\">&#x2b;</glyph>" +
"\r\n            <glyph class=\"properties-{{module.name.toSlug()}}\" style=\" display" +
": none;\">&#x2212;</glyph>\r\n        </div>\r\n        <h4>Properites</h4>\r\n        " +
"<div class=\"sing-method-list properties-{{module.name.toSlug()}}\" style=\" displa" +
"y: none;\">\r\n            <div sing-loop=\"{{ prop in module.properties }}\">\r\n     " +
"           <div sing-fill=\"{{ Parameter with prop as param }}\"></div>\r\n         " +
"   </div>\r\n\r\n            <div sing-if=\"{{module.getUnknownProperties()}}\">\r\n    " +
"            <b>Unknown Properties:</b>\r\n                <error sing-loop=\"{{ pro" +
"p in module.getUnknownProperties()}}\">{{prop}}</error>\r\n            </div>\r\n    " +
"    </div>\r\n    </div>\r\n\r\n\r\n    <div class=\"tabs\" sing-if=\"{{module.subModules}}" +
"\">\r\n        <h3 sing-if=\"{{module.parentModule}}\">Sub-Modules:</h3>\r\n        <h3" +
" sing-else>Modules:</h3>\r\n\r\n        <ul>\r\n            <li sing-loop=\"{{ sub in m" +
"odule.subModules }}\">\r\n                <a href=\"#tabs-{{sub.name}}-{{sub$index}}" +
"\">\r\n                    {{sub.name}} ({{sub.totalMethods()}})\r\n                 " +
"   <div class=\"no-text\" sing-fill=\"{{PercentSlider with [sub.implementedItems()," +
" sub.totalItems()]}}\"></div>\r\n                </a>\r\n            </li>\r\n        <" +
"/ul>\r\n        <div sing-loop=\"{{ sub in module.subModules }}\" sing-loop-inner=\"t" +
"rue\">\r\n            <div id=\"tabs-{{sub.name}}-{{sub$index}}\" style=\"display:none" +
";\">\r\n                <!--\r\n                <div sing-fill=\"{{ Module with sub as" +
" module }}\"></div>\r\n                -->\r\n            </div>\r\n        </div>\r\n   " +
" </div>\r\n</div>\r\n\r\n<div sing-template=\"Method\">\r\n    <div sing-if=\"{{ !method.is" +
"Alias }}\">\r\n        <hr />\r\n        <div class=\"btn-info btn left method-show-hi" +
"de\" click-fade-toggle=\".show-{{method.name.toSlug()}}\">\r\n            <glyph clas" +
"s=\"show-{{method.name.toSlug()}}\">&#x2b;</glyph>\r\n            <glyph class=\"show" +
"-{{method.name.toSlug()}}\" style=\" display: none;\">&#x2212;</glyph>\r\n        </d" +
"iv>\r\n\r\n        <h3 class=\"sing-method-header\">\r\n            <span class=\"sing-bu" +
"bble success\" sing-if=\"{{method.details.manuallyTested}}\">Manually Tested</span>" +
"\r\n            <span class=\"sing-bubble success\" sing-else-if=\"{{method.passesAll" +
"Tests()}}\">Tests: {{ method.details.unitTests.length}}</span>\r\n            <span" +
" class=\"sing-bubble error\" sing-else-if=\"{{method.isTested()}}\">Tests: {{method." +
"passedTests()}} / {{ method.details.unitTests.length}}</span>\r\n            <span" +
" sing-else class=\"sing-bubble error\">Untested</span>\r\n\r\n            <span class=" +
"\"sing-bubble info wide\">Extends: <b>{{method.target}}</b></span>\r\n\r\n            " +
"<span sing-if=\"{{$.isDefined(method.methodOriginal)}}\">\r\n                {{metho" +
"d.shortName}}\r\n            </span>\r\n            <span sing-else>\r\n              " +
"  <error>{{method.shortName}}</error>\r\n            </span>\r\n        </h3>\r\n\r\n   " +
"     <div style=\"display:none;\" class=\"show-{{method.name.toSlug()}}\">\r\n        " +
"    <h4>{{method.methodCall}}</h4>\r\n\r\n            <p sing-if=\"{{method.details.s" +
"ummary}}\">\r\n                <b>Summary: </b>{{method.details.summary}}\r\n        " +
"    </p>\r\n\r\n            <div sing-if=\"{{method.details.parameters}}\">\r\n         " +
"       <b>Parameters:</b>\r\n\r\n                <ol>\r\n                    <li sing-" +
"fill=\"{{ Parameter with param in method.details.parameters }}\"></li>\r\n          " +
"      </ol>\r\n            </div>\r\n\r\n            <p sing-if=\"{{method.details.retu" +
"rns}}\">\r\n                <b>Returns:</b>\r\n                {{method.details.retur" +
"ns}}\r\n            </p>\r\n            <p sing-if=\"{{method.details.returnType}}\">\r" +
"\n                <b>Return Type:</b>\r\n                {{sing.getTypeName(method." +
"details.returnType)}}\r\n            </p>\r\n            <p sing-else><b>Returns:</b" +
"> Nothing.</p>\r\n\r\n            <div sing-if=\"{{$.isDefined(method.methodOriginal)" +
"}}\" class=\"method-view-code\">\r\n                <div class=\"btn-default btn metho" +
"d-code-show-hide\" click-fade-toggle=\".code-{{method.name.toSlug()}}\">\r\n         " +
"           <span class=\"code-{{method.name.toSlug()}}\" style=\"position:absolute;" +
"\">View Code...</span>\r\n                    <span style=\"display: none;position:a" +
"bsolute;\" class=\"code-{{method.name.toSlug()}}\">Hide Code...</span>\r\n           " +
"     </div>\r\n                <div style=\"display: none;\" class=\"method-code code" +
"-{{method.name.toSlug()}}\">\r\n                    <b style=\"margin-top: 40px;\">So" +
"urce Code:</b>\r\n                    <pre>{{method.methodOriginal.toString().text" +
"ToHTML()}}</pre>\r\n                </div>\r\n            </div>\r\n            <div s" +
"ing-else>\r\n                <error>Method is not implemented.</error>\r\n          " +
"  </div>\r\n\r\n            <div sing-if=\"{{method.details.features}}\">\r\n           " +
"     <b>Features:</b>\r\n\r\n                <div sing-fill=\"{{ Feature with feature" +
" in method.details.features}}\"></div>\r\n            </div>\r\n\r\n            <div si" +
"ng-if=\"{{ method.details.examples}}\">\r\n                <b>Examples:</b>\r\n       " +
"         <pre sing-loop=\"{{ example in method.details.examples}}\">{{example}}</p" +
"re>\r\n            </div>\r\n\r\n            <div sing-if=\"{{ method.details.examples}" +
"}\">\r\n                <b>Unit Tests:</b>\r\n                <pre sing-loop=\"{{ test" +
" in method.details.unitTests}}\">\r\n                    {{test.requirement}}\r\n    " +
"                \r\n                <span sing-if=\"{{test.testResult == true}}\">\r\n" +
"                        PASSED\r\n                </span>\r\n                <span s" +
"ing-else>\r\n                <error>\r\n                        {{test.testResult}}\r" +
"\n                    </error>\r\n                </span>\r\n                </pre>\r\n" +
"            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div sing-template=\"Pa" +
"rameter\">\r\n    <table>\r\n        <tr>\r\n            <td>\r\n                <b>Name:" +
"</b>\r\n            </td>\r\n            <td>\r\n                {{param.name}}\r\n     " +
"       </td>\r\n        </tr>\r\n        <tr sing-if=\"{{param.types}}\">\r\n           " +
" <td><b>Type:</b></td>\r\n            <td>{{sing.getTypeName(param.types)}}</td>\r\n" +
"\r\n        </tr>\r\n        <tr sing-if=\"{{param.description}}\">\r\n            <td><" +
"b>Description:</b></td>\r\n            <td>{{param.description}}</td>\r\n        </t" +
"r>\r\n        <tr>\r\n            <td><b>Required:</b></td>\r\n            <td sing-if" +
"=\"{{param.required}}\">Yes</td>\r\n            <td sing-else>No</td>\r\n        </tr>" +
"\r\n    </table>\r\n</div>\r\n\r\n<div sing-template=\"Feature\">\r\n    {{feature$context}}" +
"\r\n</div>\r\n\r\n<span sing-template=\"PercentSlider\">\r\n    <span class=\"sing-progress" +
"-slider\">\r\n        <span class=\"sing-progress-complete\" style=\"width: {{$data[0]" +
".percentOf($data[1])}}%;\">\r\n\r\n        </span>\r\n        <b>\r\n            ({{ $dat" +
"a[0] }} / {{$data[1]}}) ({{ $data[0].percentOf($data[1]) }}%)\r\n        </b>\r\n   " +
" </span>\r\n</span>\r\n");


        }
    }
}
#pragma warning restore 1591
