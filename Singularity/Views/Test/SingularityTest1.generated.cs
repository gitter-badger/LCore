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
    using LCore.Extensions;
    using Singularity;
    using LMVC.Context;
    using LMVC.Controllers;
    using Singularity.Models;
    
    #line 3 "..\..\Views\Test\SingularityTest.cshtml"
    using Singularity.Routes;
    
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
WriteLiteral("\r\n<!-- ReSharper disable All -->\r\n");

WriteLiteral("\r\n");

            
            #line 5 "..\..\Views\Test\SingularityTest.cshtml"
  

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">

    sing.templateShown(function (element) {

    })

    $(document).init(function () {

    });

    $(document).ready(function () {
        (function () {
            sing.tests.runTests();

            sing.loadTemplate(['/Templates/Common.html', '/Templates/Documentation.html'],
                function (ms) {

                    sing.initTemplates();

                    sing.ready();

                    $("".tabs"").tabs({
                        collapsible: true
                    });
                });

        }).fn_defer()();
    });
</script>

<div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"mvcl-test singularity-test sing col-xs-12\"");

WriteLiteral(" sing-fill=\"{{ Singularity with sing }}\"");

WriteLiteral(">\r\n            <br />\r\n            <br />\r\n            <br />\r\n            <br />" +
"\r\n            <br />\r\n            <div");

WriteLiteral(" style=\"text-align:center\"");

WriteLiteral(">\r\n                <span");

WriteLiteral(" class=\"glyphicon spin\"");

WriteLiteral(" style=\"font-size: 36px;\"");

WriteLiteral(">&#xe201;</span>\r\n            </div>\r\n            <br />\r\n            <br />\r\n   " +
"         <br />\r\n            <br />\r\n            <br />\r\n            <br />\r\n   " +
"         <br />\r\n            <br />\r\n        </div>\r\n\r\n    </div>\r\n\r\n</div>\r\n\r\n\r" +
"\n");

        }
    }
}
#pragma warning restore 1591
