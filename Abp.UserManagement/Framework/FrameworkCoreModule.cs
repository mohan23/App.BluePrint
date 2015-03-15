using System.Reflection;
using Abp.Modules;
using Abp.UserManagement.Framework.Configuration;

namespace Abp.UserManagement.Framework
{
    public class FrameworkCoreModule : AbpModule
    {
        /// <summary>
        /// Current version of the  UserManagement Framework module.
        /// </summary>
        public const string CurrentVersion = "0.1.0.1";

        public override void PreInitialize()
        {
            IocManager.Register<MultiTenancyConfig>();
            IocManager.Register<FrameworkConfig>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

    }
}
