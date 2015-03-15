using Abp.Domain.Entities.Auditing;
using App.BluePrint.UserFramework.MultiTenency;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BluePrint.UserFramework.Authorization
{
    [Table("Users.Roles")]
    public class RoleDefinition<TTenant, TUser> : AuditedEntity<int, TUser>, IRole<int>, IMayHaveTenant<TTenant, TUser>
        where TUser : UserDefinition<TTenant, TUser>
        where TTenant : TenentDefinition<TTenant, TUser>
    {
        /// <summary>
        /// Maximum length of the <see cref="Name"/> property.
        /// </summary>
        public const int MaxNameLength = 32;

        /// <summary>
        /// Maximum length of the <see cref="Name"/> property.
        /// </summary>
        public const int MaxDisplayNameLength = 64;

        /// <summary>
        /// The Tenant if this role is a tenant-level role.
        /// </summary>
        [ForeignKey("TenantId")]
        public virtual TTenant Tenant { get; set; }

        /// <summary>
        /// Tenant's Id if this role is a tenant-level role. Null, if not.
        /// </summary>
        public virtual int? TenantId { get; set; }

        /// <summary>
        /// Unique name of this role.
        /// </summary>
        [Required]
        [StringLength(MaxNameLength)]
        public virtual string Name { get; set; }

        /// <summary>
        /// Display name of this role.
        /// </summary>
        [Required]
        [StringLength(MaxDisplayNameLength)]
        public virtual string DisplayName { get; set; }

        /// <summary>
        /// Is this a static role?
        /// Static roles can not be deleted, can not change their name and can be used programmatically.
        /// </summary>
        public virtual bool IsStatic { get; set; }

        /// <summary>
        /// List of permissions of the role.
        /// </summary>
        [ForeignKey("RoleId")]
        public virtual ICollection<RolePermissionSetting> Permissions { get; set; }

        /// <summary>
        /// Creates a new <see cref="AbpRole{TTenant,TUser}"/> object.
        /// </summary>
        public RoleDefinition()
        {
            
        }
        
        /// <summary>
        /// Creates a new <see cref="AbpRole{TTenant,TUser}"/> object.
        /// </summary>
        /// <param name="tenantId">TenantId or null (if this is not a tenant-level role)</param>
        /// <param name="name">Unique role name</param>
        /// <param name="displayName">Display name of the role</param>
        public RoleDefinition(int? tenantId, string name, string displayName)
        {
            TenantId = tenantId;
            Name = name;
            DisplayName = displayName;
        }

        public override string ToString()
        {
            return string.Format("[Role {0}, Name={1}]", Id, Name);
        }
    }
}
