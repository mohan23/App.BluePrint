using Abp.Application.Services;
using Abp.Domain.Repositories;
using App.BluePrint.Dto;
using App.BluePrint.MultiTenency;
using App.BluePrint.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BluePrint.Session
{
    public class SessionAppService : ApplicationService, ISessionAppService
    {
        private readonly IRepository<TenantManagement, int> _tenantRepository;
        private readonly IRepository<UserManagement, long> _userRepository;

        public SessionAppService(IRepository<TenantManagement, int> tenantRepository, IRepository<UserManagement, long> userRepository)
        {
            _tenantRepository = tenantRepository;
            _userRepository = userRepository;
        }

        public SessionDto GetSessionData(SessionRequestInput input)
        {
            Logger.InfoFormat("---> GetSessionData --> {0} ", input.TenencyId.ToString());
            var tenant = _tenantRepository.Get(input.TenencyId);
            var userData = _userRepository.Get(input.UserId);
            Logger.InfoFormat("---> GetSessionData --> Tenency Name {0} ", tenant.TenancyName.ToString());
            Logger.InfoFormat("---> GetSessionData --> User Name {0} ", userData.UserName.ToString());
            return new SessionDto{
                TenentId = tenant.Id,
                TenencyKey = tenant.TenancyName,
                TenencyName = tenant.Name,
                ApplicationTitle = ((tenant.Settings.Any(a => a.Name == "ApplicationTitle") ? tenant.Settings.Where(a => a.Name == "ApplicationTitle").First().Value : "")),
                UserId = userData.Id,
                UserName = userData.UserName,
                FullName = (userData.Name + " " + userData.Surname),
                RoleIds = userData.Roles.Select(r => r.RoleId).ToList()
            };
        }
    }
}
