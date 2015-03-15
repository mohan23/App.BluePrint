using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Configuration.Startup;

namespace App.BluePrint.UserFramework.Configuration
{
    public static class ConfigurationExtensions
    {
        public static FrameworkConfiguration Zero(this IModuleConfigurations moduleConfigurations)
        {
            return moduleConfigurations.AbpConfiguration
                .GetOrCreate("FrameworkConfiguration",
                    () => moduleConfigurations.AbpConfiguration.IocManager.Resolve<FrameworkConfiguration>()
                );
        }
    }
}
