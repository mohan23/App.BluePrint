using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using App.BluePrint.Users;
using Abp.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.BluePrint.Authorization;

namespace App.BluePrint.Administration
{
    [Table("Navigation", Schema = "Administration")]
    public class AdminMenu : FullAuditedEntity<int, UserManagement>
    {
        public virtual string MenuName { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual string Description { get; set; }
        public virtual string LinkUrl { get; set; }
        public virtual int SortOrder { get; set; }
        public virtual string ImageIconUrl { get; set; }
        public virtual string ImageIconClass { get; set; }
        public virtual bool IsAction { get; set; }
        public virtual string RelativeUrl { get; set; }
        /// <summary>
        /// Role definitions for this user.
        /// </summary>
        [ForeignKey("MenuId")]
        public virtual ICollection<AdminMenuRoleMapper> Roles { get; set; }

        [ForeignKey("LookupId")]
        public Lookup Category { get; set; }

        public virtual int? LookupId { get; set; }

        public AdminMenu()
        {
            Category = null;
            Roles = new List<AdminMenuRoleMapper>();
        }

    }
}
