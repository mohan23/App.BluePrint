using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abp.UserManagement.Framework.Configuration
{
    public class FrameworkConfig
    {
         /// <summary>
        /// Multi tenancy configuration.
        /// </summary>
        public MultiTenancyConfig MultiTenancy { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="multiTenancy">Multi tenancy configuration</param>
        public FrameworkConfig(MultiTenancyConfig multiTenancy)
        {
            MultiTenancy = multiTenancy;
        }

    }
}
