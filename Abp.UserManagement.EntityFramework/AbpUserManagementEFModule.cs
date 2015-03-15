using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using Abp.UserManagement.Framework;

namespace Abp.UserManagement.EntityFramework
{
    [DependsOn(typeof(FrameworkCoreModule), typeof(AbpEntityFrameworkModule))]
    public class AbpUserManagementEFModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }

}
