using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Abp.Modules;
using App.BluePrint.UserFramework.Configuration;

namespace App.BluePrint.UserFramework
{
    public class AppCoreUserFramework : AbpModule
    {
        /// <summary>
        /// Current version of the zero module.
        /// </summary>
        public const string CurrentVersion = "0.5.0.1";

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
