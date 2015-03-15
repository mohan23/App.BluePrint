using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.BluePrint.MultiTenency;
using App.BluePrint.Authorization;
using Abp.Authorization.Users;

namespace App.BluePrint.Users
{
    public class UserManager : AbpUserManager<TenantManagement, RoleManagement, UserManagement>
	{
		public UserManager(UserStoreManagement store, RoleManager roleManager)
            : base(store, roleManager)
        {
		}
	}
}
