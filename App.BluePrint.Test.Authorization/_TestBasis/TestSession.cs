using Abp.Runtime.Session;

namespace App.BluePrint.Test.Authorization._TestBasis
{
    public class TestSession : IAbpSession
    {
        public long? UserId { get; set; }

        public int? TenantId { get; set; }
    }
}