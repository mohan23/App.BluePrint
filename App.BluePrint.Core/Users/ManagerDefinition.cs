using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace App.BluePrint.Users
{
    [Table("UserManager", Schema = "Authentication")]
    public class ManagerDefinition : AuditedEntity<long, UserManagement>
    {
        public virtual long? UserId { get; set; }
        public virtual long? ManagerId { get; set; }

        public virtual UserManagement UserInfo { get; set; }
        public virtual UserManagement ManagerInfo { get; set; }

        public ManagerDefinition()
        {

        }

        public ManagerDefinition(long userId, long managerId)
        {
            UserId = userId;
            ManagerId = managerId;
        }
    }
}
