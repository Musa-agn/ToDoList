using System.Web.Optimization;

namespace ToDoList.UI
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
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/vue").Include(
                    "~/Frontend/Plugins/vuejs/vue.js"));

            bundles.Add(new ScriptBundle("~/bundles/vueminjs").Include(
                    "~/Frontend/Plugins/vuejs/vue.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/axios").Include(
                    "~/Frontend/Plugins/axios/axios.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                   "~/Frontend/Plugins/moment/moment.js"));

            bundles.Add(new ScriptBundle("~/bundles/iviewminjs").Include(
                    "~/Frontend/Plugins/iview/iview.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/todovue").Include(
                    "~/Frontend/vue/controllers/todo/index.js"));


        }
    }
}
