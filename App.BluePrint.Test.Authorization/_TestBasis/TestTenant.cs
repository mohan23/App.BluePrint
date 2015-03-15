
using App.BluePrint.UserFramework.MultiTenency;

namespace App.BluePrint.Test.Authorization._TestBasis
{
    public class TestTenant : TenentDefinition<TestTenant, TestUser>
    {
        protected TestTenant()
        {

        }

        public TestTenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}