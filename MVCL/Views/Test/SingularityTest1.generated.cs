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
WriteLiteral("\r\n<script type=\"text/javascript\">\r\n\r\n    sing.templateShown(function (element) {\r" +
"\n\r\n    })\r\n    /*\r\n    sing.init(function () {\r\n    });\r\n    */\r\n\r\n    $(documen" +
"t).init(function () {\r\n        sing.tests.runTests();\r\n\r\n        sing.loadTempla" +
"te(\'/Templates/Common.html\', function () {\r\n\r\n\r\n        });\r\n        sing.initTe" +
"mplates();\r\n\r\n        sing.ready();\r\n\r\n        $(\".tabs\").tabs({\r\n            co" +
"llapsible: true\r\n        });\r\n    });\r\n\r\n    $(document).ready(function () {\r\n\r\n" +
"\r\n    });\r\n</script>\r\n\r\n\r\n<div class=\"mvcl-test singularity-test sing\" sing-fill" +
"=\"{{ Singularity with sing }}\">\r\n\r\n\r\n    <br />\r\n    <br />\r\n    <br />\r\n    <br" +
" />\r\n    <br />\r\n    <div style=\"text-align:center\">\r\n        <span class=\"glyph" +
"icon spin\" style=\"font-size: 36px;\">&#xe201;</span>\r\n    </div>\r\n    <br />\r\n   " +
" <br />\r\n    <br />\r\n    <br />\r\n    <br />\r\n    <br />\r\n    <br />\r\n    <br />\r" +
"\n</div>\r\n\r\n\r\n\r\n<div sing-template=\"Singularity\">\r\n    <h1>&#8226; Singularity</h" +
"1>\r\n\r\n    <p>{{sing.summary}}</p>\r\n\r\n    <div sing-if=\"{{sing.tests.testErrors}}" +
"\" class=\"test-errors\">\r\n        <h2><error>Errors</error></h2>\r\n        <ol>\r\n  " +
"          <li sing-loop=\"{{ error in sing.tests.testErrors}}\">\r\n                " +
"<error>{{error.textToHTML()}}</error>\r\n                <hr />\r\n            </li>" +
"\r\n        </ol>\r\n    </div>\r\n\r\n    <div sing-fill=\"{{ Module with sing.modules.S" +
"ingularity as module }}\"></div>\r\n    <hr />\r\n</div>\r\n\r\n<div sing-template=\"Modul" +
"e\">\r\n    <h2>{{module.name}}</h2>\r\n\r\n    <div>\r\n        Methods Implemented:\r\n\r\n" +
"        <div class=\"right\" sing-fill=\"{{PercentSlider with [module.implementedMe" +
"thodCount(), module.totalMethods()]}}\"></div>\r\n    </div>\r\n\r\n    <div sing-if=\"{" +
"{module.requiredUnitTests}}\">\r\n        <div>\r\n            Unit Tests Implemented" +
":\r\n            <div class=\"right\" sing-fill=\"{{PercentSlider with [module.implem" +
"entedMethodTests(), module.totalMethods()]}}\"></div>\r\n        </div>\r\n        <d" +
"iv>\r\n            Unit Tests Passed:\r\n            <div class=\"right\" sing-fill=\"{" +
"{PercentSlider with [module.passedMethodTests(), module.implementedMethodTestsTo" +
"tal()]}}\"></div>\r\n        </div>\r\n\r\n    </div>\r\n\r\n\r\n    <div sing-if=\"{{module.t" +
"otalProperties() > 0}}\">\r\n        <div>\r\n            Properties:\r\n            <d" +
"iv class=\"right\" sing-fill=\"{{PercentSlider with [module.implementedProperties()" +
", module.totalProperties()]}}\"></div>\r\n        </div>\r\n    </div>\r\n\r\n    <div si" +
"ng-if=\"{{module.requiredDocumentation}}\">\r\n        <div>\r\n            Documentat" +
"ion:\r\n            <div class=\"right\" sing-fill=\"{{PercentSlider with [module.imp" +
"lementedDocumentation(), module.totalDocumentation()]}}\"></div>\r\n        </div>\r" +
"\n    </div>\r\n\r\n    <div sing-if=\"{{module.totalJSFiddle() > 0}}\">\r\n        <div>" +
"\r\n            JSFiddle:\r\n            <div class=\"right\" sing-fill=\"{{PercentSlid" +
"er with [module.implementedJSFiddle(), module.totalJSFiddle()]}}\"></div>\r\n      " +
"  </div>\r\n    </div>\r\n\r\n    <div>\r\n        <strong>\r\n            <br />\r\n       " +
"     Total:\r\n            <div class=\"right wide\" sing-fill=\"{{PercentSlider with" +
" [module.implementedItems(), module.totalItems()]}}\"></div>\r\n            <br /><" +
"br />\r\n        </strong>\r\n    </div>\r\n\r\n    <div class=\"tabs\" sing-if=\"{{module." +
"subModules}}\">\r\n        <h3 sing-if=\"{{module.parentModule}}\">Sub-Modules:</h3>\r" +
"\n        <h3 sing-else>Modules:</h3>\r\n\r\n        <ul>\r\n            <li sing-loop=" +
"\"{{ sub in module.subModules }}\">\r\n                <a href=\"#tabs-{{sub.name}}-{" +
"{sub$index}}\">\r\n                    {{sub.name}} ({{sub.totalMethods()}})\r\n     " +
"               <div class=\"no-text\" sing-fill=\"{{PercentSlider with [sub.impleme" +
"ntedItems(), sub.totalItems()]}}\"></div>\r\n                </a>\r\n            </li" +
">\r\n        </ul>\r\n        <div sing-loop=\"{{ sub in module.subModules }}\" sing-l" +
"oop-inner=\"true\">\r\n            <div id=\"tabs-{{sub.name}}-{{sub$index}}\" style=\"" +
"display:none;\">\r\n                <div sing-fill=\"{{ Module with sub as module }}" +
"\"></div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <div>\r\n        <" +
"h4>Methods:</h4>\r\n        <div sing-loop=\"{{ method in module.methods }}\" class=" +
"\"sing-method-list\">\r\n            <div sing-fill=\"{{ Method with method }}\"></div" +
">\r\n        </div>\r\n    </div>\r\n\r\n    <div>\r\n        <h4>Properites:</h4>\r\n      " +
"  <div sing-loop=\"{{ prop in module.properties }}\" class=\"sing-method-list\">\r\n  " +
"          <div sing-fill=\"{{ Parameter with prop as param }}\"></div>\r\n        </" +
"div>\r\n    </div>\r\n\r\n    <div sing-if=\"{{module.getUnknownMethods()}}\">\r\n        " +
"<b>Unknown Methods:</b>\r\n        <error sing-loop=\"{{ methodName in module.getUn" +
"knownMethods()}}\">{{methodName}}</error>\r\n    </div>\r\n\r\n    <div sing-if=\"{{modu" +
"le.getUnknownProperties()}}\">\r\n        <b>Unknown Properties:</b>\r\n        <erro" +
"r sing-loop=\"{{ prop in module.getUnknownProperties()}}\">{{prop}}</error>\r\n    <" +
"/div>\r\n</div>\r\n\r\n<div sing-template=\"Method\">\r\n    <div sing-if=\"{{method.detail" +
"s}}\">\r\n        <hr />\r\n        <div class=\"btn-info btn left method-show-hide\" c" +
"lick-fade-toggle=\".show-{{method.name.toSlug()}}\">\r\n            <glyph class=\"sh" +
"ow-{{method.name.toSlug()}}\">&#x2b;</glyph>\r\n            <glyph class=\"show-{{me" +
"thod.name.toSlug()}}\" style=\" display: none;\">&#x2212;</glyph>\r\n        </div>\r\n" +
"\r\n        <h3 sing-if=\"{{$.isDefined(method.methodOriginal)}}\">{{method.shortNam" +
"e}}</h3>\r\n        <h3 sing-else><error>{{method.shortName}}</error></h3>\r\n\r\n    " +
"    <div style=\"display:none;\" class=\"show-{{method.name.toSlug()}}\">\r\n         " +
"   <h4>{{method.methodCall}}</h4>\r\n\r\n            <p sing-if=\"{{method.details.su" +
"mmary}}\">\r\n                <b>Summary: </b>{{method.details.summary}}\r\n         " +
"   </p>\r\n\r\n            <div sing-if=\"{{method.details.parameters}}\">\r\n          " +
"      <b>Parameters:</b>\r\n\r\n                <ol>\r\n                    <li sing-l" +
"oop=\"{{ param in method.details.parameters }}\">\r\n                        <div si" +
"ng-fill=\"{{ Parameter with param }}\"></div>\r\n                    </li>\r\n        " +
"        </ol>\r\n            </div>\r\n\r\n            <p sing-if=\"{{method.details.re" +
"turnType}}\">\r\n                <b>Returns:</b>\r\n                {{sing.getTypeNam" +
"e(method.details.returnType)}}\r\n            </p>\r\n            <p sing-else><b>Re" +
"turns:</b> Nothing.</p>\r\n\r\n            <div sing-if=\"{{$.isDefined(method.method" +
"Original)}}\" class=\"method-view-code\">\r\n                <div class=\"btn-default " +
"btn method-code-show-hide\" click-fade-toggle=\".code-{{method.name.toSlug()}}\">\r\n" +
"                    <span class=\"code-{{method.name.toSlug()}}\" style=\"position:" +
"absolute;\">View Code...</span>\r\n                    <span style=\"display: none;p" +
"osition:absolute;\" class=\"code-{{method.name.toSlug()}}\">Hide Code...</span>\r\n  " +
"              </div>\r\n                <div style=\"display: none;\" class=\"method-" +
"code code-{{method.name.toSlug()}}\">\r\n                    <b style=\"margin-top: " +
"40px;\">Source Code:</b>\r\n                    <pre>{{method.methodOriginal.toStri" +
"ng().textToHTML()}}</pre>\r\n                </div>\r\n            </div>\r\n         " +
"   <div sing-else>\r\n                <error>Method is not implemented.</error>\r\n " +
"           </div>\r\n\r\n            <div sing-if=\"{{ method.details.examples}}\">\r\n " +
"               <b>Examples:</b>\r\n                <pre sing-loop=\"{{ example in m" +
"ethod.details.examples}}\">{{example}}</pre>\r\n            </div>\r\n        </div>\r" +
"\n    </div>\r\n</div>\r\n\r\n<div sing-template=\"Parameter\">\r\n    {{param$context}}\r\n " +
"   <div>Name: {{param.name}}</div>\r\n    <div sing-if=\"{{param.types}}\">\r\n       " +
" Type:{{sing.getTypeName(param.types)}}\r\n    </div>\r\n    <div sing-if=\"{{param.d" +
"escription}}\">\r\n        Description: {{param.description}}\r\n    </div>\r\n</div>\r\n" +
"\r\n<span sing-template=\"PercentSlider\">\r\n    <span class=\"sing-progress-slider\">\r" +
"\n        <span class=\"sing-progress-complete\" style=\"width: {{$data[0].percentOf" +
"($data[1])}}%;\">\r\n\r\n        </span>\r\n        <b>\r\n            ({{ $data[0] }} / " +
"{{$data[1]}}) ({{ $data[0].percentOf($data[1]) }}%)\r\n        </b>\r\n    </span>\r\n" +
"</span>");


        }
    }
}
#pragma warning restore 1591
