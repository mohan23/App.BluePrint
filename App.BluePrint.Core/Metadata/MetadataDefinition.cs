using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using App.BluePrint.Users;
using Abp.Authorization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace App.BluePrint.Metadata
{
    [Table("MetadataDefinition", Schema = "Metadata")]
    public class MetadataDefinition : FullAuditedEntity<int, UserManagement>
    {
        [Index(IsClustered = false, IsUnique = false)]
        [StringLength(20)]
        public virtual string InternalName { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime EffectiveDate { get; set; }

        public virtual ICollection<MetadataVersion> Versions { get; set; }

    }
}
