using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.BluePrint.MultiTenency;
using Abp.Authorization.Users;

namespace App.BluePrint.Users
{
	public class UserManagement : AbpUser<TenantManagement, UserManagement>
	{
		public override string ToString()
		{
			return string.Format("{0} [{1}]", UserName, Id);
		}
	}
}
