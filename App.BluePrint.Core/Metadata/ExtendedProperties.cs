using Abp.Domain.Entities.Auditing;
using App.BluePrint.Users;
using Abp.Authorization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Abp.Domain.Entities;
using App.BluePrint.Common;
using App.BluePrint.Config;
using System.ComponentModel.DataAnnotations;

namespace App.BluePrint.Metadata
{
    [Table("MetadataExProperties", Schema = "Metadata")]
    public class ExtendedProperties : AuditedEntity<long>
    {
        public virtual long? MetadataVersionId { get; set; }
        public virtual long? MetadataGroupId { get; set; }
        public virtual long? MetadataSectionId { get; set; }
        public virtual string PropertyValue { get; set; }
        public virtual ExProperties Properties { get; set; }

        public virtual MetadataVersion MetadataVersionInfo { get; set; }
        public virtual MetadataGroup MetadataGroupInfo { get; set; }
        public virtual MetadataSection MetadataSectionInfo { get; set; }
    }
}
