using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BluePrint.UserFramework.Configuration
{
    public class FrameworkConfiguration
    {
        public MultiTenancyConfig MultiTenancy { get; private set; }

        public FrameworkConfiguration(MultiTenancyConfig multiTenancy)
        {
            MultiTenancy = multiTenancy;
        }
    }
}
