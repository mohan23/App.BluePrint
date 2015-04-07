using Abp.Domain.Entities.Auditing;
using App.BluePrint.Users;
using Abp.Authorization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using App.BluePrint.Interfaces;
using App.BluePrint.Metadata;

namespace App.BluePrint.Config
{
    [Table("VersionGenerator", Schema = "Config")]
    public class VersionGenerator : CreationAuditedEntity<long, UserManagement>
    {
        [Column(Order=4)]
        public virtual int Build { get; set; }
        [Column(Order = 1)]
        public virtual int Major { get; set; }
        [Column(Order = 2)]
        public virtual int Minor { get; set; }
        [Column(Order = 3)]
        public virtual int Revision { get; set; }

        public virtual MetadataVersion MetadataVersionInfo { get; set; }
    }
}
