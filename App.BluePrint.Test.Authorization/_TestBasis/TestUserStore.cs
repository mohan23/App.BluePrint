
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using App.BluePrint.UserFramework.Authorization;

namespace App.BluePrint.Test.Authorization._TestBasis
{
    public class TestUserStore : AppUserStore<TestTenant, TestRole, TestUser>
    {
        public TestUserStore(
            IRepository<TestUser, long> userRepository,
            IRepository<UserLogin, long> userLoginRepository,
            IRepository<UserRole, long> userRoleRepository,
            IRepository<TestRole> roleRepository,
            IAbpSession session,
            IUnitOfWorkManager unitOfWorkManager)
            : base(
                userRepository,
                userLoginRepository,
                userRoleRepository,
                roleRepository,
                session,
                unitOfWorkManager)
        {

        }
    }
}