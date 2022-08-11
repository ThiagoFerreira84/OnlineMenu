using System.Web;
using System.Web.Optimization;

namespace OnlineMenu
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/extrajs").Include(
                      "~/Scripts/autosize.min.js",
                      "~/Scripts/moment.js",
                      "~/Scripts/bootstrap-datetimepicker.js",
                      "~/Scripts/jquery.dataTables.min.js",
                      "~/Scripts/bootstrap-hover-dropdown.min.js",
                      "~/Scripts/SiteSections/AdminSections.js",
                      "~/Scripts/SiteSections/AppSections.js",
                      "~/Scripts/App/app.js",
                      "~/Scripts/App/Charts.js",
                      "~/Scripts/monthly.js",
                      "~/Scripts/jquery.canvasjs.min.js",
                      "~/Scripts/uikit.min.js",
                      "~/Scripts/uikit-icons.min.js",
                      "~/Scripts/Site.js",
                      "~/Scripts/site-event.js",
                      "~/Scripts/views.js"));
        }
    }
}