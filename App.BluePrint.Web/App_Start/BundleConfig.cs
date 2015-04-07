using System.Web.Optimization;

namespace App.BluePrint.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            //IE 7 Css and Scripts
            bundles.Add(new StyleBundle("~/Bundles/App/Vendor/IE7Css").Include("~/Content/iconset/IE7/IE7.css"));
            bundles.Add(new ScriptBundle("~/Bundles/App/Vendor/IE7js").Include("~/Content/iconset/IE7/IE7.js"));


            //BluePrintIconSet
            bundles.Add(new StyleBundle("~/Bundles/App/Iconset/css").Include("~/Content/Iconset/Icons.css"));

            //Bootstrap UI Materializ CSS & JS
            //Author: http://fezvrasta.github.io/bootstrap-material-design/
            bundles.Add(new StyleBundle("~/Bundles/App/BootStrapMaterial/css").Include("~/Scripts/lib/bootstrap-material-design/dist/css/ripples.min.css",
                        "~/Scripts/lib/bootstrap-material-design/dist/css/material-wfont.min.css",
                        "~/Scripts/lib/bootstrap-material-design/dist/css/material.min.css"));

            bundles.Add(new ScriptBundle("~/Bundles/App/BootStrapMaterial/js").Include("~/scripts/lib/bootstrap-material-design/dist/js/ripples.min.js",
                        "~/scripts/lib/bootstrap-material-design/dist/js/material.min.js"));

            //Materialize CSS & JS
            //Author: http://materializecss.com/
            bundles.Add(new StyleBundle("~/Bundles/App/Materialize/css").Include("~/Scripts/lib/materialize/dist/css/materialize.min.css"));
            bundles.Add(new ScriptBundle("~/Bundles/App/Materialize/js").Include("~/Scripts/lib/materialize/dist/js/materialize.min.js"));

            //~/Bundles/App/vendor/css
            bundles.Add(
                new StyleBundle("~/Bundles/App/vendor/css")
                    .Include(
                        "~/Content/themes/base/all.css",
                        "~/Content/bootstrap-cosmo.min.css",

                        "~/Scripts/lib/angular-material/angular-material.min.css",
                        "~/Scripts/lib/angular-material/themes/blue-grey-theme.css",

                        "~/Scripts/lib/angular-ui-router-anim-in-out/css/anim-in-out.css",

                        "~/Content/toastr.min.css",
                        "~/Content/flags/famfamfam-flags.css",
                        "~/Content/font-awesome.min.css"
                    )
                );

            //~/Bundles/App/Main/css
            bundles.Add(
                new StyleBundle("~/Bundles/App/Main/css")
                    .IncludeDirectory("~/App/Main", "*.css", true)
                );

            
            //~/Bundles/App/vendor/js
            bundles.Add(
                new ScriptBundle("~/Bundles/App/vendor/js")
                    .Include(
                        "~/Abp/Framework/scripts/utils/ie10fix.js",
                        "~/Scripts/json2.min.js",

                        "~/Scripts/modernizr-2.8.3.js",

                        "~/Scripts/jquery-2.1.3.min.js",
                        "~/Scripts/jquery-ui-1.11.2.min.js",

                        "~/Scripts/bootstrap.min.js",

                        "~/Scripts/moment-with-locales.min.js",
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/toastr.min.js",
                        "~/Scripts/others/spinjs/spin.js",
                        "~/Scripts/others/spinjs/jquery.spin.js",

                        "~/Scripts/angular.min.js",
                        //"~/Scripts/angular-route.min.js",
                        "~/Scripts/angular-animate.min.js",
                        "~/Scripts/angular-sanitize.min.js",
                        "~/Scripts/angular-ui-router.min.js",
                        "~/Scripts/angular-ui/ui-bootstrap.min.js",
                        "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js",
                        "~/Scripts/angular-ui/ui-utils.min.js",

                        "~/Scripts/lib/angular-aria/angular-aria.min.js",

                        "~/Scripts/lib/hammerjs/hammer.min.js",

                        "~/Scripts/lib/angular-material/angular-material.min.js",

                        "~/Scripts/lib/angular-ui-router-anim-in-out/anim-in-out.js",
                        "~/scripts/lib/arrive/minified/arrive.min.js",
                       
                        "~/Abp/Framework/scripts/abp.js",
                        "~/Abp/Framework/scripts/libs/abp.jquery.js",
                        "~/Abp/Framework/scripts/libs/abp.toastr.js",
                        "~/Abp/Framework/scripts/libs/abp.blockUI.js",
                        "~/Abp/Framework/scripts/libs/abp.spin.js",
                        "~/Abp/Framework/scripts/libs/angularjs/abp.ng.js"
                    )
                );

            //APPLICATION RESOURCES

           

            ////~/Bundles/App/Main/js
            //bundles.Add(new ScriptBundle("~/Bundles/App/Main/js").IncludeDirectory("~/App/Main", "*.js", true));
            //#endregion

            ////~/Bundles/js
            //bundles.Add(new ScriptBundle("~/Bundles/Main/js").Include("~/app/common/main-{version}.js"));

            #region -- Application Js Files JS --

            //Include AppJs
            bundles.Add(new ScriptBundle("~/Bundles/App/Main/js").Include("~/App/Main/App-{version}.js"));

            //Include App
            bundles.Add(new ScriptBundle("~/Bundles/App/Common/js").IncludeDirectory("~/App/Common/js", "*.js", true));

            //include view js file
            bundles.Add(new ScriptBundle("~/Bundles/App/Views/js").IncludeDirectory("~/App/Main/Views", "*.js", true));

            #endregion
        }
    }
}