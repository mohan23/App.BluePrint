using Abp.EntityFramework;
using Abp.UserManagement.EntityFramework;
using App.BluePrint.Administration;
using App.BluePrint.Authorization;
using App.BluePrint.MultiTenency;
using App.BluePrint.Users;
using System.Data.Entity;

namespace App.BluePrint.EntityFramework
{
    public class AppDbContext : AbpUserManagementDBContext<TenantManagement, RoleManagement, UserManagement>
    {
        //TODO: Define an IDbSet for each Entity...

        //Example:
        //public virtual IDbSet<User> Users { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */

        public virtual IDbSet<AdminMenu> AdministrationMenus { get; set; }
        public virtual IDbSet<AdminMenuRoleMapper> AdminMenuRoles { get; set; }
        public virtual IDbSet<Lookup> LookupData { get; set; }
        public AppDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in App.BluePrintDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of App.BluePrintDbContext since ABP automatically handles it.
         */
        public AppDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
    }
}
