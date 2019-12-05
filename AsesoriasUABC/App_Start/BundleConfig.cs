using System.Web;
using System.Web.Optimization;

namespace AsesoriasUABC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new StyleBundle("~/Contend/fonts")
                        .Include("~/https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css"));

            bundles.Add(new StyleBundle("~/Contend/fonts2")
                        .Include("~/https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Conetent/toastr/toastr.min.js",
                      "~/Content/sweetalert2/sweetalert2.js",
                      "~/Content/bootstrap/bootstrap.js",
                      "~/Content/bootstrap/bootstrap.bundle.js",
                      "~/Scripts/adminlte/adminlte.js",
                      "~/Scripts/fastclick/fastclick.js",
                      "~/Scripts/custom/lstAsesoria.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/tables").Include(

               "~/Content/dataTables/jquery.dataTables.js",
                "~/Content/dataTables/dataTables.bootstrap4.js"

                ));

            bundles.Add(new StyleBundle("~/Content/css/tables")
             .Include("~/Content/dataTables/dataTables.bootstrap4.css"));


            bundles.Add(new StyleBundle("~/Content/css")
                .Include(
                      "~/Content/fontawesome/css/all.css",
                      "~/Content/dist/css/adminlte.css",
                      "~/Content/sweetalert2/sweetalert2.css",
                     // "~/Content/animate.css",
                     // "~/Content/Site.css",
                      "~/Content/icheck-bootstrap/icheck-bootstrap.css",
                      "~/Content/all.css",
                      "~/Content/toastr/toastr.css"
                      ));
        }
    }
}
