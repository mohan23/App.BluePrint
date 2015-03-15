using System.Reflection;
using Abp.Modules;
using Abp.UserManagement.Framework;

namespace App.BluePrint
{
    [DependsOn(typeof(FrameworkCoreModule))]
    public class CoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
