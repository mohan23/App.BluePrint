using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.BluePrint.Users;
using Abp.MultiTenancy;

namespace App.BluePrint.MultiTenency
{
    public class TenentManagement : AbpTenant<TenentManagement, UserManagement>
	{
		protected TenentManagement()
		{

		}

		public TenentManagement(string tenancyName, string name)
            : base(tenancyName, name)
        {
		}
	}
}
