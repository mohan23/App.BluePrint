using App.BluePrint.UserFramework.Authorization;

namespace App.BluePrint.Test.Authorization._TestBasis
{
    public class TestUserManager : AppUserManager<TestTenant, TestRole, TestUser>
    {
        public TestUserManager(TestUserStore store)
            : base(store)
        {
        }
    }
}