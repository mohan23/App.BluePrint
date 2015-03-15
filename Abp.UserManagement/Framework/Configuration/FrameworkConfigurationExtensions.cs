using Abp.Configuration.Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abp.UserManagement.Framework.Configuration
{
    public static class FrameworkConfigurationExtensions
    {
        /// <summary>
        /// Used to configure module User Management Framework.
        /// </summary>
        /// <param name="moduleConfigurations"></param>
        /// <returns></returns>
        public static FrameworkConfig Framework(this IModuleConfigurations moduleConfigurations)
        {
            return moduleConfigurations.AbpConfiguration
                .GetOrCreate("FrameworkConfig",
                    () => moduleConfigurations.AbpConfiguration.IocManager.Resolve<FrameworkConfig>()
                );
        }

    }
}
