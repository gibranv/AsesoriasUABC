﻿using System.Web;
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
                      "~/Content/bootstrap/bootstrap.js",
                      "~/Scripts/adminlte/adminlte.js",
                      "~/Scripts/fastclick/fastclick.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/adminlte.css",
                       "~/Content/fontawesome/css/all.css",
                      "~/Content/all.css"
                      ));
        }
    }
}
