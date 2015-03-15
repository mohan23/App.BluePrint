using Abp.Authorization;
using Abp.Authorization.Roles;
using App.BluePrint.MultiTenency;
using App.BluePrint.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BluePrint.Authorization
{
    public class RoleManager : AbpRoleManager<TenantManagement, RoleManagement, UserManagement>
    {
        public RoleManager(RoleManagementStore store, IPermissionManager permissionManager)
            : base(store, permissionManager)
        {
        }
    }
}
