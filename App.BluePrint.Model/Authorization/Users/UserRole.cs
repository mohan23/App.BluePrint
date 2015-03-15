using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BluePrint.UserFramework.Authorization
{
    /// <summary>
    /// Represents role record of a user. 
    /// </summary>
    [Table("Users.UserRoles")]
    public class UserRole : CreationAuditedEntity<long>
    {
        public virtual long UserId { get; set; }

        public virtual int RoleId { get; set; }

        public UserRole()
        {

        }

        public UserRole(long userId, int roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
    }

}
