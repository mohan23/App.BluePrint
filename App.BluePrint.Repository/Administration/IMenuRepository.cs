using Abp.Domain.Repositories;
using App.BluePrint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BluePrint.Repository.Administration
{
    public interface IMenuRepository : IRepository<AdminMenu, int>
    {
        List<Lookup> GetAdminMenuCategory();
        List<AdminMenu> GetAdminMenus(int roleId);
        List<AdminMenu> GetAdminMenus(List<int> roleId);
        List<AdminMenu> GetSubmMenus(int roleId, int parentMenuId);
        bool CheckPermission(int menuId);
    }
}
