using System.Reflection;
using Abp.Application.Services;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;

namespace App.BluePrint
{
    [DependsOn(typeof(AbpWebApiModule), typeof(ApplicationModule))]
    public class WebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(ApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
