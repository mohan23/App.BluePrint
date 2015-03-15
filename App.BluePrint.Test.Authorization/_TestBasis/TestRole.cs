
using App.BluePrint.UserFramework.Authorization;

namespace App.BluePrint.Test.Authorization._TestBasis
{
    public class TestRole : RoleDefinition<TestTenant, TestUser>
    {
        protected TestRole()
        {

        }

        public TestRole(int? tenantId, string name, string displayName)
            : base(tenantId, name, displayName)
        {

        }
    }
}