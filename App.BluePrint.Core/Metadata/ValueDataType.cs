using Abp.Domain.Entities.Auditing;
using App.BluePrint.Users;
using Abp.Authorization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace App.BluePrint.Metadata
{
    [Table("ValueDataType", Schema = "Metadata")]
    public class ValueDataType : FullAuditedEntity<int, UserManagement>
    {
        public virtual string ClrTypeName { get; set; }
        public virtual string TypeName { get; set; }
        public virtual string SqlTypeName { get; set; }
    }
}
