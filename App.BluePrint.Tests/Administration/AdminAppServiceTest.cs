using App.BluePrint.Administration;
using App.BluePrint.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace App.BluePrint.Tests.Administration
{
    public class AdminAppServiceTest : BluePrintTestBase
    {
        IAdminAppService _adminService;

        public AdminAppServiceTest()
        {
            _adminService = LocalIocManager.Resolve<IAdminAppService>();
        }

        [Fact]
        public void GetAllMenus()
        {
            var menuInput = new MenuRequestInput();
            menuInput.RoleIds = new List<int>() { 1 };
            var adminMenus = _adminService.GetAdminMenus(menuInput);
            //adminMenus.Id.Menus.ShouldNotBe(null);
            //adminMenus.Id.CategoryList.ShouldNotBeEmpty();
        }
    }
}
