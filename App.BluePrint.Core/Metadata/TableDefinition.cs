using Abp.Domain.Entities.Auditing;
using App.BluePrint.Users;
using Abp.Authorization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Data;
using System.ComponentModel.DataAnnotations;
using App.BluePrint.Config;

namespace App.BluePrint.Metadata
{
    [Table("MetadataTable", Schema = "Metadata")]
    public class TableDefinition : FullAuditedEntity<long, UserManagement>
    {
        public virtual long SectionId { get; set; }
        public virtual long MetadataVersionId { get; set; }
        [Index(IsClustered = false, IsUnique = false)]
        [StringLength(20)]
        public virtual string InternalName { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int Sequence { get; set; }
        public virtual bool IsMandatory { get; set; }
        [NotMapped]
        public DataTable TableValue { get; set; }

        [ForeignKey("MetadataVersionId")]
        public virtual ICollection<ExtendedProperties> ExtendedProperties { get; set; }

        [ForeignKey("TableId")]
        public virtual ICollection<MetadataField> Fields { get; set; }
    }
}
