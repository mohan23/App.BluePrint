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
    [Table("MetadataField", Schema = "Metadata")]
    public class MetadataField : FullAuditedEntity<long, UserManagement>
    {
        public virtual long? SectionId { get; set; }
        public virtual long? TableId { get; set; }
        public virtual long MetadataVersionId { get; set; }
        [Index(IsClustered = false, IsUnique = false)]
        [StringLength(20)]
        public virtual string InternalName { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual int ValueDataTypeId { get; set; }
        public virtual int? ProviderId { get; set; }
        public virtual int Sequence { get; set; }

        public virtual int? FieldLength { get; set; }
        public virtual int? Precision { get; set; }
        public virtual int? Scale { get; set; }
        public virtual string HelpText { get; set; }
        public virtual string PlaceHolderText { get; set; }
        public virtual string FormulaExpression { get; set; }
        public virtual string GroupText { get; set; }
        public virtual bool IsHyperLink { get; set; }
        public virtual bool IsUrl { get; set; }
        public virtual string UrlText { get; set; }
        public virtual bool IsMandatory { get; set; }
        public virtual bool IsMultiValue { get; set; }

        [ForeignKey("MetadataVersionId")]
        public virtual ICollection<ExtendedProperties> ExtendedProperties { get; set; }

        [ForeignKey("ValueDataTypeId")]
        public virtual ValueDataType ValueDataTypes { get; set; }

        [ForeignKey("ProviderId")]
        public virtual DataProvider DataProviderInfo { get; set; }

        [ForeignKey("FieldId")]
        public virtual ICollection<FieldValidation> Validations { get;set;}
    }

    [Table("FieldValidation", Schema = "Metadata")]
    public class FieldValidation : AuditedEntity<long, UserManagement>
    {
        public virtual long FieldId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string Expression { get; set; }
        public virtual string AssertionMessage { get; set; }
        public virtual bool UseAssembly { get; set; }
        public virtual string Assembly { get; set; }
        public virtual string MethodName { get; set; }
    }
}
