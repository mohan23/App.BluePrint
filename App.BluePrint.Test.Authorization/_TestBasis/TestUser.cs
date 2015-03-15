
using App.BluePrint.UserFramework.Authorization;

namespace App.BluePrint.Test.Authorization._TestBasis
{
    public class TestUser : UserDefinition<TestTenant, TestUser>
    {
        public override string ToString()
        {
            return string.Format("[TestUser {0}] {1}", Id, UserName);
        }
    }
}