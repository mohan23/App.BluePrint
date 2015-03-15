using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.BluePrint.Users;
using Abp.MultiTenancy;

namespace App.BluePrint.MultiTenency
{
    public class TenantManagement : AbpTenant<TenantManagement, UserManagement>
	{
		protected TenantManagement()
		{

		}

		public TenantManagement(string tenancyName, string name)
            : base(tenancyName, name)
        {
		}
	}
}
