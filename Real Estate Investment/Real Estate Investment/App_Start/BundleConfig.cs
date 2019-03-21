using System.Web;
using System.Web.Optimization;

namespace RealEstateInvestment
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/assets/lib/bootstrap/css/bootstrap.css",
                      "~/Content/font-awesome.css",
                      "~/assets/css/main.rtl.css",
                      "~/assets/lib/metismenu/metisMenu.css",
                      "~/assets/lib/onoffcanvas/onoffcanvas.css",
                      "~/assets/lib/animate.css/animate.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/plugins").Include(
                      "~/Plugins/jquery-ui-themes-1.12.1/jquery-ui.css",
                      "~/Plugins/DataTables/datatables.css"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/assets/lib/metismenu/metisMenu.js",
                      "~/assets/lib/onoffcanvas/onoffcanvas.js",
                      "~/assets/lib/screenfull/screenfull.js",
                      "~/assets/js/core.js",
                      "~/assets/js/style-switcher.js",
                      "~/Scripts/moment.js"));

            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                      "~/Plugins/jquery-ui-themes-1.12.1/jquery-ui.js",
                      "~/Plugins/DataTables/datatables.js",
                      "~/Plugins/notify/notify.js"));
        }
    }
}