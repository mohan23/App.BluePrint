using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BluePrint.Dto
{
    public abstract class BaseEntity : Entity<int>
    {
        public bool HasError { get; set; }
        public string Error { get; set; }
    }
}
