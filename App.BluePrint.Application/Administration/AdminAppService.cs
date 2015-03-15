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

namespace App.BluePrint.Administration
{
    public class AdminAppService : IAdminAppService
    {
        private readonly IRepository<RoleManagement, int> _roleRepository;
        private readonly IMenuRepository _adminRepo;

        public AdminAppService(IRepository<RoleManagement, int> roleRepository, IMenuRepository adminRepo)
        {
            _roleRepository = roleRepository;
            _adminRepo = adminRepo;
        }

        public MenuEntity GetAdminMenus(MenuRequestInput input)
        {
            var menuItems = _adminRepo;
            var menuData = new MenuEntity();
            menuData.Menus = _adminRepo.GetAdminMenus(input.RoleIds);
            menuData.CategoryList = _adminRepo.GetAdminMenuCategory();
            return menuData;
        }

        public bool HasPermission(MenuRequestInput input)
        {
            return false;
        }
    }
}
