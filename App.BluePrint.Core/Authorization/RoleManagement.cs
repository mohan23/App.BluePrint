using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.BluePrint.MultiTenency;
using App.BluePrint.Users;
using Abp.Authorization.Roles;

namespace App.BluePrint.Authorization
{
	public class RoleManagement : AbpRole<TenantManagement, UserManagement>
	{
        protected RoleManagement()
        {

        }

        public RoleManagement(int? tenantId, string name, string displayName)
            : base(tenantId, name, displayName)
        {

        }
    }
}
