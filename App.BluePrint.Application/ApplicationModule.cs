using System.Reflection;
using Abp.Modules;
using Abp.AutoMapper;
using App.BluePrint.Authorization;
using App.BluePrint.Repository;

namespace App.BluePrint
{
    [DependsOn(typeof(CoreModule), typeof(AbpAutoMapperModule), typeof(BluePrintRepositoryModule))]
    public class ApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Configuration.Authorization.Providers.Add<UserAuthorizationProvider>();
        }
    }
}
