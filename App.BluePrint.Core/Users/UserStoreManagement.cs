using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using App.BluePrint.Authorization;
using App.BluePrint.MultiTenency;
using Abp.Authorization.Users;

namespace App.BluePrint.Users
{
    public class UserStoreManagement : AbpUserStore<TenantManagement, RoleManagement, UserManagement>
    {
        public UserStoreManagement(
            IRepository<UserManagement, long> userRepository,
            IRepository<UserLogin, long> userLoginRepository,
            IRepository<UserRole, long> userRoleRepository,
            IRepository<RoleManagement> roleRepository,
            IAbpSession session)
            : base(
                userRepository,
                userLoginRepository,
                userRoleRepository,
                roleRepository,
                session)
        {

        }
    }
}
