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
    [Table("MetadataSection", Schema = "Metadata")]
    public class MetadataSection : FullAuditedEntity<long, UserManagement>
    {
        [Index(IsClustered = false, IsUnique = false)]
        [StringLength(20)]
        public virtual string InternalName { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int Sequence { get; set; }

        public virtual long MetadataGroupId { get; set; }
        public virtual ICollection<ExtendedProperties> ExtendedProperties { get; set; }

        //[ForeignKey("SectionId")]
        //public virtual ICollection<MetadataField> Fields { get; set; }

        //[ForeignKey("SectionId")]
        //public virtual ICollection<TableDefinition> Tables { get; set; }

        public virtual MetadataGroup MetadataGroupInfo { get; set; }
    }

}
