using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.EntityFramework;
using Abp.Modules;
using System.Reflection;

namespace App.BluePrint.UserFramework
{
    [DependsOn(typeof(AppUserFramworkModule), typeof(AbpEntityFrameworkModule))]
    public class AppUserEntityFrameworkModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
