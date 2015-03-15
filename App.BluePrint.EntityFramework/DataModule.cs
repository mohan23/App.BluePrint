using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.UserManagement.EntityFramework;

namespace App.BluePrint
{
    [DependsOn(typeof(AbpUserManagementEFModule), typeof(CoreModule))]
    public class DataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
