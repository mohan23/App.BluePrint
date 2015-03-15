using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Abp.Modules;
using App.BluePrint.UserFramework.Configuration;

namespace App.BluePrint.UserFramework
{
    public class AppUserFramworkModule : AbpModule
    {
        /// <summary>
        /// Current version of the User Framework module.
        /// </summary>
        public const string CurrentVersion = "0.1.0.1";

        public override void PreInitialize()
        {
            IocManager.Register<MultiTenancyConfig>();
            IocManager.Register<FrameworkConfiguration>();
        }

        public override void Initialize()
        {
            base.Initialize();
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
