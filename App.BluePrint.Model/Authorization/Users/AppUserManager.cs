using Abp.Dependency;
using App.BluePrint.UserFramework.MultiTenency;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BluePrint.UserFramework.Authorization
{
    /// <summary>
    /// Extends <see cref="UserManager{TRole,TKey}"/> of ASP.NET Identity Framework.
    /// </summary>
    public abstract class AppUserManager<TTenant, TRole, TUser> : UserManager<TUser, long>, ITransientDependency
        where TTenant : TenentDefinition<TTenant, TUser>
        where TRole : RoleDefinition<TTenant, TUser>
        where TUser : UserDefinition<TTenant, TUser>
    {
        protected AppUserManager(AppUserStore<TTenant, TRole, TUser> store)
            : base(store)
        {

        }
    }

}
