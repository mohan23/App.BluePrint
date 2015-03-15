using Abp.Domain.Repositories;
using Abp.EntityFramework;
using App.BluePrint.Administration;
using App.BluePrint.Authorization;
using App.BluePrint.EntityFramework;
using App.BluePrint.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BluePrint.Repository.Administration
{
    public class MenuRepository : AppBaseRepository<AdminMenu, int>, IMenuRepository
    {
        private readonly IRepository<RoleManagement> _roleRepository;
        private readonly IRepository<AdminMenuRoleMapper, int> _menuRoleMapper;
        private readonly IRepository<Lookup, int> _lookupRepository; 
        private const string ADMCAT = "ADM";

        public MenuRepository(IDbContextProvider<AppDbContext> dbContextProvider)
        : base(dbContextProvider)
        {
        }

        public MenuRepository(IDbContextProvider<AppDbContext> dbContextProvider, IRepository<RoleManagement> role, IRepository<AdminMenuRoleMapper, int> menuRole, IRepository<Lookup, int> lookupRepository)
        : base(dbContextProvider)
        {
            _roleRepository = role;
            _menuRoleMapper = menuRole;
            _lookupRepository = lookupRepository;
        }

        
        public bool CheckPermission(int menuId)
        {
            throw new NotImplementedException();
        }

        public List<AdminMenu> GetAdminMenus(int roleId)
        {
            throw new NotImplementedException();
        }

        public List<AdminMenu> GetSubmMenus(int roleId, int parentMenuId)
        {
            throw new NotImplementedException();
        }

        public List<AdminMenu> GetAdminMenus(List<int> roleId)
        {
            var aMenuIds = _menuRoleMapper.GetAllList().Join(roleId, m => m.RoleId, r => r, (m, r) => new { MenuId = m.MenuId });
            if (aMenuIds != null)
            {
                var menus = this.GetAllList().Join(aMenuIds, m => m.Id, a => a.MenuId, (m, r) => m);
                return (menus != null ? menus.ToList() : null);
            }

            return null;
        }

        public List<Lookup> GetAdminMenuCategory()
        {
            var aCats = _lookupRepository.GetAllList(l => l.Code == ADMCAT);
            if (aCats != null && aCats.Any())
                return aCats.ToList();

            return null;
        }
    }
}
