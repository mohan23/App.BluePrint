using Abp.Authorization.Roles;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using App.BluePrint.MultiTenency;
using App.BluePrint.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BluePrint.Authorization
{
    public class RoleManagementStore : AbpRoleStore<TenantManagement, RoleManagement, UserManagement>
    {
        public RoleManagementStore(
            IRepository<RoleManagement> roleRepository,
            IRepository<RolePermissionSetting, long> rolePermissionSettingRepository,
            IAbpSession session)
            : base(
                roleRepository,
                rolePermissionSettingRepository,
                session)
        {
        }
    }
}
