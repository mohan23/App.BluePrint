using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BluePrint.Dto
{
    public class SessionDto : Entity<int>
    {
        public int TenentId { get; set; }
        public string TenencyName { get; set; }
        public string TenencyKey { get; set; }
        public string ApplicationTitle { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public List<int> RoleIds { get; set; }
    }
}
