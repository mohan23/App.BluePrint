using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using App.BluePrint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BluePrint.Dto
{
    public class MenuEntity : IOutputDto
    {
       public List<Lookup> CategoryList { get; set; }
       public List<AdminMenu> Menus { get; set; }
    }

    public class MenuRequestInput : IInputDto
    {
        public int? MenuId { get; set; }
        public int? UserId { get; set; }
        public List<int> RoleIds { get; set; }
    }
}
