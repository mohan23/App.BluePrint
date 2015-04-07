using Abp.Domain.Entities.Auditing;
using App.BluePrint.Users;
using Abp.Authorization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using App.BluePrint.Config;

namespace App.BluePrint.Metadata
{
    [Table("MetadataGroup", Schema = "Metadata")]
    public class MetadataGroup : FullAuditedEntity<long, UserManagement>
    {
        [Index(IsClustered = false, IsUnique = false)]
        [StringLength(20)]
        public virtual string InternalName { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int Sequence { get; set; }

        public virtual long MetadataVersionId { get; set; }
        public virtual MetadataVersion MetadataVersionInfo { get; set; }

        public virtual ICollection<ExtendedProperties> ExtendedProperties { get; set; }
        public virtual ICollection<MetadataSection> Sections { get; set; }
    }
}
