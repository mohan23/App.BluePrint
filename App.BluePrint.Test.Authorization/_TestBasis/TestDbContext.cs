using System.Configuration;
using System.Data.Common;
using App.BluePrint.UserFramework;

namespace App.BluePrint.Test.Authorization._TestBasis
{
    public class TestDbContext : TenentDBContext<TestTenant, TestRole, TestUser>
    {
        public TestDbContext(DbConnection connection)
            : base(connection, true)
        {

        }

		public TestDbContext() : base(ConfigurationManager.ConnectionStrings["Default"].ConnectionString) {
		}
    }
}