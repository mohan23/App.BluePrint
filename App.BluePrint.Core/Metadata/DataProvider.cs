using Abp.Domain.Entities.Auditing;
using App.BluePrint.Users;
using Abp.Authorization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;


namespace App.BluePrint.Metadata
{
    [Table("DataProvider", Schema = "Metadata")]
    public class DataProvider : FullAuditedEntity<int, UserManagement>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsScriptMode { get; set; }
        public virtual string BehaviourOnAssemblyName { get; set; }
        public virtual string BehaviourClassName { get; set; }
        public virtual string ScriptExpression { get; set; }
        public virtual string ValueColumn { get; set; }
        public virtual string TextColumn { get; set; }
        public virtual string Namespace { get; set; }
        public virtual string MethodName { get; set; }
        public virtual string ClassName { get; set; }
        public virtual string MethodReturnType { get; set; }
    }
}
