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
    using LMVC;
    using LMVC.Account;
    using LMVC.Annotations;
    using LMVC.Context;
    using LMVC.Controllers;
    using LMVC.Extensions;
    using LMVC.Models;
    using LMVC.Routes;
    using Singularity;
    using Singularity.Extensions;
    using Singularity.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Admin/Header.cshtml")]
    public partial class _Views_Shared_Admin_Header_cshtml : SingularityRazor<dynamic>
    {
        public _Views_Shared_Admin_Header_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Shared\Admin\Header.cshtml"
  

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<header");

WriteLiteral(" class=\"main-header\"");

WriteLiteral(">\r\n    <!-- Logo -->\r\n    <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"logo\"");

WriteLiteral(">\r\n        <!-- mini logo for sidebar mini 50x50 pixels -->\r\n        <span");

WriteLiteral(" class=\"logo-mini\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 11 "..\..\Views\Shared\Admin\Header.cshtml"
       Write(Singularity.AppName_Short);

            
            #line default
            #line hidden
WriteLiteral("\r\n        </span>\r\n        <!-- logo for regular state and mobile devices -->\r\n  " +
"      <span");

WriteLiteral(" class=\"logo-lg\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 15 "..\..\Views\Shared\Admin\Header.cshtml"
       Write(Singularity.AppName);

            
            #line default
            #line hidden
WriteLiteral("\r\n        </span>\r\n    </a>\r\n    <!-- Header Navbar: style can be found in header" +
".less -->\r\n    <nav");

WriteLiteral(" class=\"navbar navbar-static-top\"");

WriteLiteral(">\r\n        <!-- Sidebar toggle button-->\r\n        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"sidebar-toggle\"");

WriteLiteral(" data-toggle=\"offcanvas\"");

WriteLiteral(" role=\"button\"");

WriteLiteral(">\r\n            <span");

WriteLiteral(" class=\"sr-only\"");

WriteLiteral(">Toggle navigation</span>\r\n        </a>\r\n        <div");

WriteLiteral(" class=\"navbar-custom-menu\"");

WriteLiteral(">\r\n            <ul");

WriteLiteral(" class=\"nav navbar-nav\"");

WriteLiteral(">\r\n");

            
            #line 26 "..\..\Views\Shared\Admin\Header.cshtml"
                
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\Shared\Admin\Header.cshtml"
                 if (Auth.IsLoggedIn)
                    {

            
            #line default
            #line hidden
WriteLiteral("                <!-- Messages: style can be found in dropdown.less-->\r\n");

WriteLiteral("                    <li");

WriteLiteral(" class=\"dropdown messages-menu\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(">\r\n                            <i");

WriteLiteral(" class=\"fa fa-envelope-o\"");

WriteLiteral("></i>\r\n                            <span");

WriteLiteral(" class=\"label label-success\"");

WriteLiteral(">4</span>\r\n                        </a>\r\n                        <ul");

WriteLiteral(" class=\"dropdown-menu\"");

WriteLiteral(">\r\n                            <li");

WriteLiteral(" class=\"header\"");

WriteLiteral(">You have 4 messages</li>\r\n                            <li>\r\n                    " +
"            <!-- inner menu: contains the actual data -->\r\n                     " +
"           <ul");

WriteLiteral(" class=\"menu\"");

WriteLiteral(">\r\n                                    <li>\r\n                                    " +
"    <!-- start message -->\r\n                                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n                                            <div");

WriteLiteral(" class=\"pull-left\"");

WriteLiteral(">\r\n                                                <img");

WriteLiteral(" src=\"\"");

WriteLiteral(" class=\"img-circle\"");

WriteLiteral(" alt=\"User Image\"");

WriteLiteral(">\r\n                                            </div>\r\n                          " +
"                  <h4>\r\n                                                Support " +
"Team\r\n                                                <small><i");

WriteLiteral(" class=\"fa fa-clock-o\"");

WriteLiteral(@"></i> 5 mins</small>
                                            </h4>
                                            <p>Why not buy a new awesome theme?</p>
                                        </a>
                                    </li>
                                    <!-- end message -->
                                    <li>
                                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n                                            <div");

WriteLiteral(" class=\"pull-left\"");

WriteLiteral(">\r\n                                                <img");

WriteLiteral(" src=\"\"");

WriteLiteral(" class=\"img-circle\"");

WriteLiteral(" alt=\"User Image\"");

WriteLiteral(">\r\n                                            </div>\r\n                          " +
"                  <h4>\r\n                                                AdminLTE" +
" Design Team\r\n                                                <small><i");

WriteLiteral(" class=\"fa fa-clock-o\"");

WriteLiteral(@"></i> 2 hours</small>
                                            </h4>
                                            <p>Why not buy a new awesome theme?</p>
                                        </a>
                                    </li>
                                    <li>
                                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n                                            <div");

WriteLiteral(" class=\"pull-left\"");

WriteLiteral(">\r\n                                                <img");

WriteLiteral(" src=\"\"");

WriteLiteral(" class=\"img-circle\"");

WriteLiteral(" alt=\"User Image\"");

WriteLiteral(">\r\n                                            </div>\r\n                          " +
"                  <h4>\r\n                                                Develope" +
"rs\r\n                                                <small><i");

WriteLiteral(" class=\"fa fa-clock-o\"");

WriteLiteral(@"></i> Today</small>
                                            </h4>
                                            <p>Why not buy a new awesome theme?</p>
                                        </a>
                                    </li>
                                    <li>
                                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n                                            <div");

WriteLiteral(" class=\"pull-left\"");

WriteLiteral(">\r\n                                                <img");

WriteLiteral(" src=\"\"");

WriteLiteral(" class=\"img-circle\"");

WriteLiteral(" alt=\"User Image\"");

WriteLiteral(">\r\n                                            </div>\r\n                          " +
"                  <h4>\r\n                                                Sales De" +
"partment\r\n                                                <small><i");

WriteLiteral(" class=\"fa fa-clock-o\"");

WriteLiteral(@"></i> Yesterday</small>
                                            </h4>
                                            <p>Why not buy a new awesome theme?</p>
                                        </a>
                                    </li>
                                    <li>
                                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n                                            <div");

WriteLiteral(" class=\"pull-left\"");

WriteLiteral(">\r\n                                                <img");

WriteLiteral(" src=\"\"");

WriteLiteral(" class=\"img-circle\"");

WriteLiteral(" alt=\"User Image\"");

WriteLiteral(">\r\n                                            </div>\r\n                          " +
"                  <h4>\r\n                                                Reviewer" +
"s\r\n                                                <small><i");

WriteLiteral(" class=\"fa fa-clock-o\"");

WriteLiteral(@"></i> 2 days</small>
                                            </h4>
                                            <p>Why not buy a new awesome theme?</p>
                                        </a>
                                    </li>
                                </ul>
                            </li>
                            <li");

WriteLiteral(" class=\"footer\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">See All Messages</a></li>\r\n                        </ul>\r\n                    </" +
"li>\r\n");

WriteLiteral("                <!-- Notifications: style can be found in dropdown.less -->\r\n");

WriteLiteral("                    <li");

WriteLiteral(" class=\"dropdown notifications-menu\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(">\r\n                            <i");

WriteLiteral(" class=\"fa fa-bell-o\"");

WriteLiteral("></i>\r\n                            <span");

WriteLiteral(" class=\"label label-warning\"");

WriteLiteral(">10</span>\r\n                        </a>\r\n                        <ul");

WriteLiteral(" class=\"dropdown-menu\"");

WriteLiteral(">\r\n                            <li");

WriteLiteral(" class=\"header\"");

WriteLiteral(">You have 10 notifications</li>\r\n                            <li>\r\n              " +
"                  <!-- inner menu: contains the actual data -->\r\n               " +
"                 <ul");

WriteLiteral(" class=\"menu\"");

WriteLiteral(">\r\n                                    <li>\r\n                                    " +
"    <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n                                            <i");

WriteLiteral(" class=\"fa fa-users text-aqua\"");

WriteLiteral("></i> 5 new members joined today\r\n                                        </a>\r\n " +
"                                   </li>\r\n                                    <l" +
"i>\r\n                                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n                                            <i");

WriteLiteral(" class=\"fa fa-warning text-yellow\"");

WriteLiteral(@"></i> Very long description here that may not fit into the
                                            page and may cause design problems
                                        </a>
                                    </li>
                                    <li>
                                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n                                            <i");

WriteLiteral(" class=\"fa fa-users text-red\"");

WriteLiteral("></i> 5 new members joined\r\n                                        </a>\r\n       " +
"                             </li>\r\n                                    <li>\r\n  " +
"                                      <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n                                            <i");

WriteLiteral(" class=\"fa fa-shopping-cart text-green\"");

WriteLiteral("></i> 25 sales made\r\n                                        </a>\r\n              " +
"                      </li>\r\n                                    <li>\r\n         " +
"                               <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n                                            <i");

WriteLiteral(" class=\"fa fa-user text-red\"");

WriteLiteral("></i> You changed your username\r\n                                        </a>\r\n  " +
"                                  </li>\r\n                                </ul>\r\n" +
"                            </li>\r\n                            <li");

WriteLiteral(" class=\"footer\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">View all</a></li>\r\n                        </ul>\r\n                    </li>\r\n");

WriteLiteral("                <!-- Tasks: style can be found in dropdown.less -->\r\n");

WriteLiteral("                    <li");

WriteLiteral(" class=\"dropdown tasks-menu\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(">\r\n                            <i");

WriteLiteral(" class=\"fa fa-flag-o\"");

WriteLiteral("></i>\r\n                            <span");

WriteLiteral(" class=\"label label-danger\"");

WriteLiteral(">9</span>\r\n                        </a>\r\n                        <ul");

WriteLiteral(" class=\"dropdown-menu\"");

WriteLiteral(">\r\n                            <li");

WriteLiteral(" class=\"header\"");

WriteLiteral(">You have 9 tasks</li>\r\n                            <li>\r\n                       " +
"         <!-- inner menu: contains the actual data -->\r\n                        " +
"        <ul");

WriteLiteral(" class=\"menu\"");

WriteLiteral(">\r\n                                    <li>\r\n                                    " +
"    <!-- Task item -->\r\n                                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n                                            <h3>\r\n                            " +
"                    Design some buttons\r\n                                       " +
"         <small");

WriteLiteral(" class=\"pull-right\"");

WriteLiteral(">20%</small>\r\n                                            </h3>\r\n                " +
"                            <div");

WriteLiteral(" class=\"progress xs\"");

WriteLiteral(">\r\n                                                <div");

WriteLiteral(" class=\"progress-bar progress-bar-aqua\"");

WriteLiteral(" style=\"width: 20%\"");

WriteLiteral(" role=\"progressbar\"");

WriteLiteral(" aria-valuenow=\"20\"");

WriteLiteral(" aria-valuemin=\"0\"");

WriteLiteral(" aria-valuemax=\"100\"");

WriteLiteral(">\r\n                                                    <span");

WriteLiteral(" class=\"sr-only\"");

WriteLiteral(@">20% Complete</span>
                                                </div>
                                            </div>
                                        </a>
                                    </li>
                                    <!-- end task item -->
                                    <li>
                                        <!-- Task item -->
                                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n                                            <h3>\r\n                            " +
"                    Create a nice theme\r\n                                       " +
"         <small");

WriteLiteral(" class=\"pull-right\"");

WriteLiteral(">40%</small>\r\n                                            </h3>\r\n                " +
"                            <div");

WriteLiteral(" class=\"progress xs\"");

WriteLiteral(">\r\n                                                <div");

WriteLiteral(" class=\"progress-bar progress-bar-green\"");

WriteLiteral(" style=\"width: 40%\"");

WriteLiteral(" role=\"progressbar\"");

WriteLiteral(" aria-valuenow=\"20\"");

WriteLiteral(" aria-valuemin=\"0\"");

WriteLiteral(" aria-valuemax=\"100\"");

WriteLiteral(">\r\n                                                    <span");

WriteLiteral(" class=\"sr-only\"");

WriteLiteral(@">40% Complete</span>
                                                </div>
                                            </div>
                                        </a>
                                    </li>
                                    <!-- end task item -->
                                    <li>
                                        <!-- Task item -->
                                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n                                            <h3>\r\n                            " +
"                    Some task I need to do\r\n                                    " +
"            <small");

WriteLiteral(" class=\"pull-right\"");

WriteLiteral(">60%</small>\r\n                                            </h3>\r\n                " +
"                            <div");

WriteLiteral(" class=\"progress xs\"");

WriteLiteral(">\r\n                                                <div");

WriteLiteral(" class=\"progress-bar progress-bar-red\"");

WriteLiteral(" style=\"width: 60%\"");

WriteLiteral(" role=\"progressbar\"");

WriteLiteral(" aria-valuenow=\"20\"");

WriteLiteral(" aria-valuemin=\"0\"");

WriteLiteral(" aria-valuemax=\"100\"");

WriteLiteral(">\r\n                                                    <span");

WriteLiteral(" class=\"sr-only\"");

WriteLiteral(@">60% Complete</span>
                                                </div>
                                            </div>
                                        </a>
                                    </li>
                                    <!-- end task item -->
                                    <li>
                                        <!-- Task item -->
                                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n                                            <h3>\r\n                            " +
"                    Make beautiful transitions\r\n                                " +
"                <small");

WriteLiteral(" class=\"pull-right\"");

WriteLiteral(">80%</small>\r\n                                            </h3>\r\n                " +
"                            <div");

WriteLiteral(" class=\"progress xs\"");

WriteLiteral(">\r\n                                                <div");

WriteLiteral(" class=\"progress-bar progress-bar-yellow\"");

WriteLiteral(" style=\"width: 80%\"");

WriteLiteral(" role=\"progressbar\"");

WriteLiteral(" aria-valuenow=\"20\"");

WriteLiteral(" aria-valuemin=\"0\"");

WriteLiteral(" aria-valuemax=\"100\"");

WriteLiteral(">\r\n                                                    <span");

WriteLiteral(" class=\"sr-only\"");

WriteLiteral(@">80% Complete</span>
                                                </div>
                                            </div>
                                        </a>
                                    </li>
                                    <!-- end task item -->
                                </ul>
                            </li>
                            <li");

WriteLiteral(" class=\"footer\"");

WriteLiteral(">\r\n                                <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">View all tasks</a>\r\n                            </li>\r\n                        <" +
"/ul>\r\n                    </li>\r\n");

WriteLiteral("                <!-- User Account: style can be found in dropdown.less -->\r\n");

WriteLiteral("                    <li");

WriteLiteral(" class=\"dropdown user user-menu\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(">\r\n                            <img");

WriteLiteral(" src=\"\"");

WriteLiteral(" class=\"user-image\"");

WriteLiteral(" alt=\"User Image\"");

WriteLiteral(">\r\n                            <span");

WriteLiteral(" class=\"hidden-xs\"");

WriteLiteral(">Alexander Pierce</span>\r\n                        </a>\r\n                        <" +
"ul");

WriteLiteral(" class=\"dropdown-menu\"");

WriteLiteral(">\r\n                            <!-- User image -->\r\n                            <" +
"li");

WriteLiteral(" class=\"user-header\"");

WriteLiteral(">\r\n                                <img");

WriteLiteral(" src=\"\"");

WriteLiteral(" class=\"img-circle\"");

WriteLiteral(" alt=\"User Image\"");

WriteLiteral(@">
                                <p>
                                    Alexander Pierce - Web Developer
                                    <small>Member since Nov. 2012</small>
                                </p>
                            </li>
                            <!-- Menu Body -->
                            <li");

WriteLiteral(" class=\"user-body\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"col-xs-4 text-center\"");

WriteLiteral(">\r\n                                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">Followers</a>\r\n                                    </div>\r\n                     " +
"               <div");

WriteLiteral(" class=\"col-xs-4 text-center\"");

WriteLiteral(">\r\n                                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">Sales</a>\r\n                                    </div>\r\n                         " +
"           <div");

WriteLiteral(" class=\"col-xs-4 text-center\"");

WriteLiteral(">\r\n                                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(@">Friends</a>
                                    </div>
                                </div>
                                <!-- /.row -->
                            </li>
                            <!-- Menu Footer-->
                            <li");

WriteLiteral(" class=\"user-footer\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"pull-left\"");

WriteLiteral(">\r\n                                    <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"btn btn-default btn-flat\"");

WriteLiteral(">Profile</a>\r\n                                </div>\r\n                           " +
"     <div");

WriteLiteral(" class=\"pull-right\"");

WriteLiteral(">\r\n                                    <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"btn btn-default btn-flat\"");

WriteLiteral(">Sign out</a>\r\n                                </div>\r\n                          " +
"  </li>\r\n                        </ul>\r\n                    </li>\r\n");

WriteLiteral("                <!-- Control Sidebar Toggle Button -->\r\n");

WriteLiteral("                    <li>\r\n                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" data-toggle=\"control-sidebar\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-gears\"");

WriteLiteral("></i></a>\r\n                    </li>\r\n");

            
            #line 271 "..\..\Views\Shared\Admin\Header.cshtml"

                    }

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n            </ul>\r\n        </div>\r\n    </nav>\r\n</header>");

        }
    }
}
#pragma warning restore 1591
