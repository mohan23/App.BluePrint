using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.MultiTenancy;
using Abp.Runtime.Session;

namespace App.BluePrint.Session
{
    public class UserSession : IAbpSession
    {
        public MultiTenancySides MultiTenancySide
        {
            get
            {
                return !TenantId.HasValue ? MultiTenancySides.Host : MultiTenancySides.Tenant;
            }
        }

        public int? TenantId { get; set; }
        public long? UserId { get; set; }
    }
}
