using Abp.Domain.Entities.Auditing;
using App.BluePrint.Users;
using Abp.Authorization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Abp.Domain.Entities;
using App.BluePrint.Common;
using App.BluePrint.Metadata;


namespace App.BluePrint.Config
{
    [Table("ExProperties", Schema = "Config")]
    public class ExProperties : CreationAuditedEntity<int, UserManagement>
    {
        public virtual string Name { get; set; }
        public virtual string DataType { get; set; }
        public virtual object Default { get; set; }
        public virtual ExPropType PropertyType { get; set; }

        public virtual ExtendedProperties PropertyInfo { get; set; }
    }
}
