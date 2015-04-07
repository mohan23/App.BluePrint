using Abp.Domain.Entities.Auditing;
using App.BluePrint.Users;
using Abp.Authorization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using App.BluePrint.Config;

namespace App.BluePrint.Metadata
{
    [Table("MetadataVersion", Schema = "Metadata")]
    public class MetadataVersion : CreationAuditedEntity<long, UserManagement>
    {
        public virtual int MetadataId { get; set; }

        public virtual VersionGenerator Version { get; set; } 
        public virtual string VersionDescription { get; set; }
        public virtual string BehaviourAssembly { get; set; }
        public virtual string BehaviourClass { get; set; }

        public virtual ICollection<MetadataGroup> MetadataGroups { get; set; }
        public virtual ICollection<ExtendedProperties> ExtendedProperties { get; set; }

        public virtual MetadataDefinition Definition { get; set; }
    }
}
