using Singularity.Controllers;
using System;
using System.Web;
using System.Web.Optimization;

namespace Singularity.Config
{
    public class BundleConfig
    {
        public const String Script_jQuery = "~/bundles/jquery";
        public const String Script_jQueryUI = "~/bundles/jquery-ui";
        public const String Style_jQueryUI = "~/Content/jquery-ui/base/css";

        public const String Script_jQueryVal = "~/bundles/jqueryval";

        public const String Script_Bootstrap = "~/bundles/bootstrap";
        public const String Style_Bootstrap = "~/Content/bootstrap";

        public const String Script_Modernizr = "~/bundles/modernizr";




        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {


            #region jQuery
            bundles.Add(new ScriptBundle(Script_jQuery).Include(
                        "~/Scripts/jquery-2.1.3.js"));

            #endregion

            #region jQuery UI
            bundles.Add(new ScriptBundle(Script_jQueryUI).Include(
                        "~/Scripts/jquery-ui-1.11.4.js"));

            bundles.Add(new StyleBundle(Style_jQueryUI).Include(
                        "~/Content/jquery-ui/base/accordion.css",
                        "~/Content/jquery-ui/base/all.css",
                        "~/Content/jquery-ui/base/autocomplete.css",
                        "~/Content/jquery-ui/base/base.css",
                        "~/Content/jquery-ui/base/button.css",
                        "~/Content/jquery-ui/base/core.css",
                        "~/Content/jquery-ui/base/datepicker.css",
                        "~/Content/jquery-ui/base/dialog.css",
                        "~/Content/jquery-ui/base/draggable.css",
                        "~/Content/jquery-ui/base/menu.css",
                        "~/Content/jquery-ui/base/progressbar.css",
                        "~/Content/jquery-ui/base/resizable.css",
                        "~/Content/jquery-ui/base/selectable.css",
                        "~/Content/jquery-ui/base/selectmenu.css",
                        "~/Content/jquery-ui/base/slider.css",
                        "~/Content/jquery-ui/base/sortable.css",
                        "~/Content/jquery-ui/base/spinner.css",
                        "~/Content/jquery-ui/base/tabs.css",
                        "~/Content/jquery-ui/base/theme.css",
                        "~/Content/jquery-ui/base/tooltip.css"));
            #endregion

            #region jQuery Validate
            bundles.Add(new ScriptBundle(Script_jQueryVal).Include(
                        "~/Scripts/jquery.validate*"));
            #endregion

            #region Bootstrap
            bundles.Add(new ScriptBundle(Script_Bootstrap).Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle(Style_Bootstrap).Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap.icon.css"));
            #endregion

            #region Modernizr

            bundles.Add(new ScriptBundle(Script_Modernizr).Include(
                        "~/Scripts/modernizr-*"));
            #endregion

            #region Singularity
            ControllerHelper.RegisterBundles(bundles, false);
            #endregion


        }
    }
}
