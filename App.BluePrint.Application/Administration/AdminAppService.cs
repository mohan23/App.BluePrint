using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using App.BluePrint.Dto;
using Abp.Domain.Repositories;
using App.BluePrint.Users;
using App.BluePrint.Authorization;
using App.BluePrint.Repository.Administration;
using Abp.AutoMapper;
using Abp.Application.Services;

namespace App.BluePrint.Administration
{
    public class AdminAppService : ApplicationService, IAdminAppService
    {
        private readonly IRepository<RoleManagement, int> _roleRepository;
        private readonly IMenuRepository _adminRepo;

        public AdminAppService(IRepository<RoleManagement, int> roleRepository, IMenuRepository adminRepo)
        {
            _roleRepository = roleRepository;
            _adminRepo = adminRepo;
        }

        public ListResultOutput<AdminCategoryDto> GetAdminMenus(MenuRequestInput input)
        {
            Logger.InfoFormat("---> GetAdminMenuData --> {0} ", string.Join(",",input.RoleIds.ToArray()));
            var adminMenus = _adminRepo.GetAdminMenus(input.RoleIds).MapTo<List<AdminMenuDto>>();
            var CategoryList = _adminRepo.GetAdminMenuCategory().MapTo<List<LookupDto>>();
            Logger.InfoFormat("---> Menu Count --> {0} ", adminMenus.Count.ToString());
            Logger.InfoFormat("---> CatagoryListCount --> {0} ", CategoryList.Count.ToString());

            var adminMenusList = new List<AdminCategoryDto>();
            CategoryList.ForEach(c =>
            {
                var menus = adminMenus.Where(l => l.LookupId == c.Id);
                var aMenu = new AdminCategoryDto()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Value = c.Value,
                    IconCss = c.IconCss,
                    Menus = (menus != null ? menus.ToList() : null)
                };
                adminMenusList.Add(aMenu);
            });

            Logger.InfoFormat("---> ReturntAdminMenuData --> {0} ", "SUCCESS");
            return new ListResultOutput<AdminCategoryDto>() { Items = adminMenusList };
        }

        public bool HasPermission(MenuRequestInput input)
        {
            return false;
        }
    }
}
