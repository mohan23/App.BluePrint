using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Configuration;
using App.BluePrint.Authorization;
using App.BluePrint.EntityFramework;
using App.BluePrint.MultiTenency;
using App.BluePrint.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BluePrint.Migrations.Data
{
    public class InitialDataBuilder
    {
        public void Build(AppDbContext context)
        {
            var tenant = CreateBaseTenent(context);
            CreateTenantUsersRoles(context, tenant);
        }

        private TenantManagement CreateBaseTenent(AppDbContext context)
        {
            var defaultTenant = context.Tenants.FirstOrDefault(t => t.TenancyName == "BASE");
            if (defaultTenant == null)
            {
                defaultTenant = context.Tenants.Add(new TenantManagement("BASE", "BluePrint for Emerio"));
                if (defaultTenant.Settings == null)
                    defaultTenant.Settings = new List<Setting>();

                defaultTenant.Settings.Add(new Setting() { Name = "ApplicationTitle", Value = "BluePrint for Emerio" });
                defaultTenant.Settings.Add(new Setting() { Name = "OwnerName", Value = "Mohan D. Kumar" });
                defaultTenant.Settings.Add(new Setting() { Name = "ContactNo", Value = "+61 468 419 155" });
                defaultTenant.Settings.Add(new Setting() { Name = "Email", Value = "mohan.kumar@emeriocorp.com" });
                defaultTenant.Settings.Add(new Setting() { Name = "License", Value = "ENT" });
                defaultTenant.Settings.Add(new Setting() { Name = "LicenseKey", Value = "ENT" });
                defaultTenant.Settings.Add(new Setting() { Name = "ExpiryDate", Value = "31/12/2020" });
                defaultTenant.Settings.Add(new Setting() { Name = "AuthMode", Value = "1" });
                context.SaveChanges();
            }

            return defaultTenant;
        }

        private void CreateTenantUsersRoles(AppDbContext context, TenantManagement tenent)
        {
            //Admin role for tenancy owner

            var adminRoleForTenancyOwner = context.Roles.FirstOrDefault(r => r.TenantId == tenent.Id && r.Name == "Admin");
            if (adminRoleForTenancyOwner == null)
            {
                adminRoleForTenancyOwner = context.Roles.Add(new RoleManagement(tenent.Id, "Admin", "Administrator"));
                //Permission definitions for Admin of 'Default' tenant
                context.Permissions.Add(new RolePermissionSetting { RoleId = adminRoleForTenancyOwner.Id, Name = "CanDeleteUsers", IsGranted = true });
                context.Permissions.Add(new RolePermissionSetting { RoleId = adminRoleForTenancyOwner.Id, Name = "CanDeleteRoles", IsGranted = true });
                context.SaveChanges();
            }

            //Admin user for tenancy owner

            var adminUserForTenancyOwner = context.Users.FirstOrDefault(u => u.TenantId == tenent.Id && u.UserName == "admin");
            if (adminUserForTenancyOwner == null)
            {
                adminUserForTenancyOwner = context.Users.Add(
                    new UserManagement
                    {
                        TenantId = tenent.Id,
                        UserName = "admin",
                        Name = "System",
                        Surname = "Administrator",
                        EmailAddress = "bpadmin@emeriocorp.com",
                        IsEmailConfirmed = true,
                        Password = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==" //123qwe
                    });

                if (adminUserForTenancyOwner.Settings == null)
                    adminUserForTenancyOwner.Settings = new List<Setting>();

                adminUserForTenancyOwner.Settings.Add(new Setting() { Name = "AuthType", Value = "1" });

                context.SaveChanges();

                context.UserRoles.Add(new UserRole(adminUserForTenancyOwner.Id, adminRoleForTenancyOwner.Id));

                context.SaveChanges();
            }
            
        }
        
    }
}
