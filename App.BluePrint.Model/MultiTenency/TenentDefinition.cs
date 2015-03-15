using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Configuration;
using Abp.Domain.Entities.Auditing;
using App.BluePrint.UserFramework.Authorization;
using App.BluePrint.UserFramework.Configuration;

namespace App.BluePrint.UserFramework.MultiTenency
{
    [Table("Tenent.TenentDefinition")]
    public class TenentDefinition<TTenent, TUser> : AuditedEntity<int, TUser>
        where TUser:UserDefinition<TTenent, TUser>
        where TTenent:TenentDefinition<TTenent, TUser>
    {
         /// <summary>
        /// Tenancy name. This property is the UNIQUE name of this Tenant.
        /// It can be used as subdomain name in a web application.
        /// </summary>
        public virtual string TenancyName { get; set; }

        /// <summary>
        /// Display name of the Tenant.
        /// </summary>
        public virtual string Name { get; set; }

        [ForeignKey("TenantId")]
        public virtual ICollection<Setting> Settings { get; set; }

        public TenentDefinition()
        {
            
        }

        public TenentDefinition(string tenancyName, string name)
        {
            TenancyName = tenancyName;
            Name = name;
			Settings = new List<Setting>();
        }

    }
}
