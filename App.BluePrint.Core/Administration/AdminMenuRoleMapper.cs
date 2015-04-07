using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BluePrint.Administration
{
    [Table("NavigationRoles", Schema = "Administration")]
    public class AdminMenuRoleMapper : CreationAuditedEntity<int>
    {
        /// <summary>
        /// User id.
        /// </summary>
        public virtual int MenuId { get; set; }

        /// <summary>
        /// Role id.
        /// </summary>
        public virtual int RoleId { get; set; }

        /// <summary>
        /// Creates a new <see cref="UserRole"/> object.
        /// </summary>
        public AdminMenuRoleMapper()
        {

        }

        /// <summary>
        /// Creates a new <see cref="UserRole"/> object.
        /// </summary>
        /// <param name="userId">User id</param>
        /// <param name="roleId">Role id</param>
        public AdminMenuRoleMapper(int menuId, int roleId)
        {
            MenuId = menuId;
            RoleId = roleId;
        }
    }
}
