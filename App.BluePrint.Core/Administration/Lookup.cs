using Abp.Domain.Entities.Auditing;
using App.BluePrint.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BluePrint.Administration
{
    [Table("Lookup", Schema = "Administration")]
    public class Lookup : FullAuditedEntity<int, UserManagement>
    {
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual string Value { get; set; }
        public virtual string Description { get; set; }
        public virtual string IconCss { get; set; }
    }
}
