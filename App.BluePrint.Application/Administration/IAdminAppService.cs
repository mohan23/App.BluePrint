using Abp.Application.Services;
using Abp.Application.Services.Dto;
using App.BluePrint.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BluePrint.Administration
{
    public interface IAdminAppService : IApplicationService
    {
        ListResultOutput<AdminCategoryDto> GetAdminMenus(MenuRequestInput input);
        bool HasPermission(MenuRequestInput input);
    }
}
