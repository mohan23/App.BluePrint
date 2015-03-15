using Abp.Authorization;
using Abp.Dependency;
using Abp.Runtime.Session;
using App.BluePrint.UserFramework.MultiTenency;
using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BluePrint.UserFramework.Authorization
{
    public abstract class PermissionGrantStore<TRole, TTenant, TUser> : IPermissionGrantStore, ITransientDependency
        where TRole : RoleDefinition<TTenant, TUser>
        where TUser : UserDefinition<TTenant, TUser>
        where TTenant : TenentDefinition<TTenant, TUser>
    {
        private readonly AppRoleManager<TTenant, TRole, TUser> _roleManager;
        private readonly AppUserManager<TTenant, TRole, TUser> _userManager;

        public ILogger Logger { get; set; }

        public IAbpSession AppSession { get; set; }

        public PermissionGrantStore(AppRoleManager<TTenant, TRole, TUser> roleManager, AppUserManager<TTenant, TRole, TUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;

            Logger = NullLogger.Instance;
            AppSession = NullAbpSession.Instance;
        }

        public bool IsGranted(long userId, string permissionName)
        {
            return _userManager
                .GetRolesAsync(userId).Result.Any(roleName => _roleManager.HasPermissionAsync(roleName, permissionName).Result);
        }
    }

}
