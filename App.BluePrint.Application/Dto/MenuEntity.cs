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
    [AutoMapFrom(typeof(AdminMenu))]
    public class AdminMenuDto : Entity<int>
    {
        public string MenuName { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string LinkUrl { get; set; }
        public int? LookupId { get; set; }
        public string ImageIconUrl { get; set; }
        public string ImageIconClass { get; set; }
        public bool IsAction { get; set; }
        public string RelativeUrl { get; set; }
    }


    public class AdminCategoryDto : Entity
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string IconCss { get; set; }
        public List<AdminMenuDto> Menus { get; set; }
    }

    [AutoMapFrom(typeof(Lookup))]
    public class LookupDto : Entity<int>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string IconCss { get; set; }
    }

    public class MenuEntity : IOutputDto
    {
       public List<LookupDto> CategoryList { get; set; }
       public List<AdminMenuDto> Menus { get; set; }
    }

    public class MenuRequestInput : IInputDto
    {
        public int? MenuId { get; set; }
        public int? UserId { get; set; }
        public List<int> RoleIds { get; set; }
    }
}
