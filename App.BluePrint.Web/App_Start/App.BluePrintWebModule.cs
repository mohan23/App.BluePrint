﻿using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Localization;
using Abp.Localization.Sources.Xml;
using Abp.Modules;

namespace App.BluePrint.Web
{
    [DependsOn(typeof(DataModule), typeof(ApplicationModule), typeof(WebApiModule))]
    public class WebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Add/remove languages for your application
            Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flag-au", true));
            Configuration.Localization.Languages.Add(new LanguageInfo("tr", "Türkçe", "famfamfam-flag-tr"));

            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new XmlLocalizationSource(
                    Consts.LocalizationSourceName,
                    HttpContext.Current.Server.MapPath("~/Localization/App.BluePrint")
                    )
                );

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<AppNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
