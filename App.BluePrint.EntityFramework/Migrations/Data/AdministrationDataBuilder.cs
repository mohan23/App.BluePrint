using Abp.Authorization.Roles;
using App.BluePrint.Administration;
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
    public class AdministrationDataBuilder
    {
        public void Build(AppDbContext context)
        {
            var defaultTenant = context.Tenants.FirstOrDefault(t => t.TenancyName == "BASE");
            var adminUser = context.Users.FirstOrDefault(u => u.TenantId == defaultTenant.Id && u.UserName == "admin");

            //ClearAdminData(context, adminUser);
            CreateLookupData(context, adminUser);
            CreateUserMenus(context, adminUser, defaultTenant);
            CreateProcessMenus(context, adminUser, defaultTenant);
            CreateSearchMenus(context, adminUser, defaultTenant);
            CreateDesignerMenus(context, adminUser, defaultTenant);
            CreateReportsMenus(context, adminUser, defaultTenant);
            CreateAdminActions(context, adminUser, defaultTenant);
            UpdateNavigationPath(context, adminUser, defaultTenant);
        }

        private void ClearAdminData(AppDbContext context, UserManagement user)
        {
            if (context.AdminMenuRoles.Any())
                context.AdminMenuRoles.ToList().RemoveAll(a => a.Id > 0);

            if (context.AdministrationMenus.Any())
                context.AdministrationMenus.ToList().RemoveAll(a => a.Id > 0);

            if (context.LookupData.Any())
                context.LookupData.ToList().RemoveAll(a => a.Code == "ADM" );

            if (context.Permissions.Any())
            {
                context.Permissions.ToList().RemoveAll(a => a.Name == "AllowManageUsersRoles" ||
                                                            a.Name == "AllowManageWorkflowRoles" ||
                                                            a.Name == "AllowManageProcesses"  || 
                                                            a.Name == "AllowManageInstances" ||
                                                            a.Name == "AllowAdminSearch" || 
                                                            a.Name == "AllowAdvanceSearch"  ||
                                                            a.Name == "AllowProcessDesign"  || 
                                                            a.Name == "AllowManageProcesses"  ||
                                                            a.Name == "AllowWorkflowDesign" ||
                                                            a.Name == "AllowGenerateReports" ||
                                                            a.Name == "AllowReportDesign" ||
                                                            a.Name == "AllowViewAuditLog" || 
                                                            a.Name == "AllowManageSettings" );
            }
            context.SaveChanges();
        }

        public void CreateLookupData(AppDbContext context, UserManagement user)
        {
            var MCats = context.LookupData.FirstOrDefault(l => l.Code == "ADM");
            if (MCats == null)
            {
                context.LookupData.Add(new Administration.Lookup()
                {
                    Code = "ADM",
                    Name = "UserRoleManagement",
                    Value = "User & Role Management",
                    Description = "Manage Users and Roles",
                    CreatorUserId = user.Id,
                    IconCss = "icon-account-child-bp"
                });
                context.LookupData.Add(new Administration.Lookup()
                {
                    Code = "ADM",
                    Name = "ProcessManagement",
                    Value = "Process Management",
                    Description = "Manage Processes and Process Instances",
                    CreatorUserId = user.Id,
                    IconCss = "icon-pages-bp"
                });
                context.LookupData.Add(new Administration.Lookup()
                {
                    Code = "ADM",
                    Name = "AppSearch",
                    Value = "Search",
                    Description = "Manage Processes and Process Instances using Search",
                    CreatorUserId = user.Id,
                    IconCss = "icon-search-bp"
                });
                context.LookupData.Add(new Administration.Lookup()
                {
                    Code = "ADM",
                    Name = "AppDesigners",
                    Value = "Designers",
                    Description = "Desiging Process and Workflows",
                    CreatorUserId = user.Id,
                    IconCss= "icon-retweet-bp"
                });
                context.LookupData.Add(new Administration.Lookup()
                {
                    Code = "ADM",
                    Name = "AppReports",
                    Value = "Report Configuration",
                    Description = "Configuration and Settings for Reports",
                    CreatorUserId = user.Id,
                    IconCss = "icon-report-bp"
                });
                context.SaveChanges();
            }
        }

        public void CreateUserMenus(AppDbContext context, UserManagement user, TenantManagement tenent)
        {
            var UserCat = context.LookupData.FirstOrDefault(l => l.Name == "UserRoleManagement");
            if (UserCat != null)
            {
                var adminRole = context.Roles.FirstOrDefault(r => r.TenantId == tenent.Id && r.Name == "Admin");
                if (adminRole != null)
                {
                    context.Permissions.Add(new RolePermissionSetting { RoleId = adminRole.Id, Name = "AllowManageUsers", IsGranted = true });
                    context.Permissions.Add(new RolePermissionSetting { RoleId = adminRole.Id, Name = "AllowManageUsersRoles", IsGranted = true });
                    context.Permissions.Add(new RolePermissionSetting { RoleId = adminRole.Id, Name = "AllowManageWorkflowRoles", IsGranted = true });
                    context.SaveChanges();
                }

                var userMenu = context.AdministrationMenus.FirstOrDefault(m => m.LookupId == UserCat.Id);
                if (userMenu == null)
                {
                    context.AdministrationMenus.Add(new AdminMenu()
                    {
                        Category = UserCat,
                        CreatorUserId = user.Id,
                        MenuName = "ManageUsers",
                        DisplayName = "Manage Application Users",
                        Description = "Use this links to manage the application users",
                        LookupId = UserCat.Id,
                        SortOrder = 1,
                        ImageIconClass = "icon-account-box-bp",
                        LinkUrl = "/Admin/ManageUsers",
                        RelativeUrl = "/App/Main/Views/Admin/ManageUsers/ManageUsers.cshtml"
                    });

                    context.AdministrationMenus.Add(new AdminMenu()
                    {
                        Category = UserCat,
                        CreatorUser = user,
                        MenuName = "ManageRoles",
                        DisplayName = "Manage Application User Roles",
                        Description = "Use this links to manage the application user roles",
                        LookupId = UserCat.Id,
                        SortOrder = 1,
                        ImageIconClass = "icon-perm-identity-bp",
                        LinkUrl = "/Admin/ManageRoles",
                        RelativeUrl = "/App/Main/Views/Admin/ManageUsers/ManageRoles.cshtml"
                    });

                    context.AdministrationMenus.Add(new AdminMenu()
                    {
                        Category = UserCat,
                        CreatorUser = user,
                        MenuName = "ManageWFRoles",
                        DisplayName = "Manage Workflpw Roles",
                        Description = "Use this links to manage the workflow roles",
                        LookupId = UserCat.Id,
                        SortOrder = 1,
                        ImageIconClass = "icon-perm-data-setting-bp",
                        LinkUrl = "/Admin/ManageWFRoles",
                        RelativeUrl = "/App/Main/Views/Admin/ManageUsers/ManageWFRoles.cshtml"
                    });

                    context.SaveChanges();

                    var menus = context.AdministrationMenus.Where(m => m.LookupId == UserCat.Id);
                    if (menus != null)
                    {
                        menus.ToList().ForEach(m =>
                        {
                            context.AdminMenuRoles.Add(new AdminMenuRoleMapper(m.Id, adminRole.Id));
                        });
                        context.SaveChanges();
                    }
                }
            }
        }

        public void CreateProcessMenus(AppDbContext context, UserManagement user, TenantManagement tenent)
        {
            var UserCat = context.LookupData.FirstOrDefault(l => l.Name == "ProcessManagement");
            if (UserCat != null)
            {
                var adminRole = context.Roles.FirstOrDefault(r => r.TenantId == tenent.Id && r.Name == "Admin");
                if (adminRole != null)
                {
                    context.Permissions.Add(new RolePermissionSetting { RoleId = adminRole.Id, Name = "AllowManageProcesses", IsGranted = true });
                    context.Permissions.Add(new RolePermissionSetting { RoleId = adminRole.Id, Name = "AllowManageInstances", IsGranted = true });
                    context.SaveChanges();
                }

                var userMenu = context.AdministrationMenus.FirstOrDefault(m => m.LookupId == UserCat.Id);
                if (userMenu == null)
                {

                    context.AdministrationMenus.Add(new AdminMenu()
                    {
                        Category = UserCat,
                        CreatorUserId = user.Id,
                        MenuName = "ManageProcess",
                        DisplayName = "Manage Process",
                        Description = "Use this links to manage the Saved/Submitted Process",
                        LookupId = UserCat.Id,
                        SortOrder = 1,
                        ImageIconClass = "icon-group-work-bp",
                        LinkUrl = "/Admin/ManageProcess",
                        RelativeUrl = "/App/Main/Views/Admin/ManageProcess/ManageProcess.cshtml"
                    });

                    context.AdministrationMenus.Add(new AdminMenu()
                    {
                        Category = UserCat,
                        CreatorUser = user,
                        MenuName = "ManageInstances",
                        DisplayName = "Manage Process Instances",
                        Description = "Use this links to manage the Saved/Submitted Process Instances",
                        LookupId = UserCat.Id,
                        SortOrder = 1,
                        ImageIconClass = "icon-aspect-ratio-bp",
                        LinkUrl = "/Admin/ManageInstances",
                        RelativeUrl = "/App/Main/Views/Admin/ManageInstances/ManageInstances.cshtml"
                    });

                    context.SaveChanges();

                    var menus = context.AdministrationMenus.Where(m => m.LookupId == UserCat.Id);
                    if (menus != null)
                    {
                        menus.ToList().ForEach(m =>
                        {
                            context.AdminMenuRoles.Add(new AdminMenuRoleMapper(m.Id, adminRole.Id));
                        });
                        context.SaveChanges();
                    }
                }
            }
        }

        public void CreateSearchMenus(AppDbContext context, UserManagement user, TenantManagement tenent)
        {
            var UserCat = context.LookupData.FirstOrDefault(l => l.Name == "AppSearch");
            if (UserCat != null)
            {
                var adminRole = context.Roles.FirstOrDefault(r => r.TenantId == tenent.Id && r.Name == "Admin");
                if (adminRole != null)
                {
                    context.Permissions.Add(new RolePermissionSetting { RoleId = adminRole.Id, Name = "AllowAdminSearch", IsGranted = true });
                    context.Permissions.Add(new RolePermissionSetting { RoleId = adminRole.Id, Name = "AllowAdvanceSearch", IsGranted = true });
                    context.SaveChanges();
                }

                var userMenu = context.AdministrationMenus.FirstOrDefault(m => m.LookupId == UserCat.Id);
                if (userMenu == null)
                {
                    context.AdministrationMenus.Add(new AdminMenu()
                    {
                        Category = UserCat,
                        CreatorUserId = user.Id,
                        MenuName = "AdmSearch",
                        DisplayName = "Search Process",
                        Description = "Use this links to sarch the Saved/Submitted Process Instances",
                        LookupId = UserCat.Id,
                        SortOrder = 1,
                        ImageIconClass = " icon-search2-bp",
                        LinkUrl = "/Admin/SearchProcess",
                        RelativeUrl = "/App/Main/Views/Admin/SearchProcess/SearchProcess.cshtml"
                    });

                    context.AdministrationMenus.Add(new AdminMenu()
                    {
                        Category = UserCat,
                        CreatorUser = user,
                        MenuName = "ManageInstances",
                        DisplayName = "Manage Process Instances",
                        Description = "Use this links to use the advance search for the Saved/Submitted Process Instances",
                        LookupId = UserCat.Id,
                        SortOrder = 1,
                        ImageIconClass = "icon-search-plus-bp",
                        LinkUrl = "/Admin/AdvSearch",
                        RelativeUrl = "/App/Main/Views/Admin/AdvSearch/AdvSearch.cshtml"
                    });

                    context.SaveChanges();

                    var menus = context.AdministrationMenus.Where(m => m.LookupId == UserCat.Id);
                    if (menus != null)
                    {
                        menus.ToList().ForEach(m =>
                        {
                            context.AdminMenuRoles.Add(new AdminMenuRoleMapper(m.Id, adminRole.Id));
                        });
                        context.SaveChanges();
                    }
                }
            }
        }

        public void CreateDesignerMenus(AppDbContext context, UserManagement user, TenantManagement tenent)
        {
            var UserCat = context.LookupData.FirstOrDefault(l => l.Name == "AppDesigners");
            if (UserCat != null)
            {
                var adminRole = context.Roles.FirstOrDefault(r => r.TenantId == tenent.Id && r.Name == "Admin");
                if (adminRole != null)
                {
                    context.Permissions.Add(new RolePermissionSetting { RoleId = adminRole.Id, Name = "AllowProcessDesign", IsGranted = true });
                    context.Permissions.Add(new RolePermissionSetting { RoleId = adminRole.Id, Name = "AllowWorkflowDesign", IsGranted = true });
                    context.SaveChanges();
                }

                var userMenu = context.AdministrationMenus.FirstOrDefault(m => m.LookupId == UserCat.Id);
                if (userMenu == null)
                {
                    context.AdministrationMenus.Add(new AdminMenu()
                    {
                        Category = UserCat,
                        CreatorUserId = user.Id,
                        MenuName = "ProcessDesigners",
                        DisplayName = "Design a New Process",
                        Description = "Use this links to design a new Process/Form",
                        LookupId = UserCat.Id,
                        SortOrder = 1,
                        ImageIconClass = " icon-dashboard-bp",
                        LinkUrl = "/Admin/ProcessDesign",
                        RelativeUrl = "/App/Main/Views/Admin/ProcessDesign/ProcessDesign.cshtml"
                    });

                    context.AdministrationMenus.Add(new AdminMenu()
                    {
                        Category = UserCat,
                        CreatorUser = user,
                        MenuName = "WFDesigners",
                        DisplayName = "Design a new Workflow",
                        Description = "Use this links to design a new Workflow",
                        LookupId = UserCat.Id,
                        SortOrder = 1,
                        ImageIconClass = "icon-call-split-bp",
                        LinkUrl = "/Admin/WFDesign",
                        RelativeUrl = "/App/Main/Views/Admin/WFDesign/WFDesign.cshtml"
                    });

                    context.SaveChanges();

                    var menus = context.AdministrationMenus.Where(m => m.LookupId == UserCat.Id);
                    if (menus != null)
                    {
                        menus.ToList().ForEach(m =>
                        {
                            context.AdminMenuRoles.Add(new AdminMenuRoleMapper(m.Id, adminRole.Id));
                        });
                        context.SaveChanges();
                    }
                }
            }
        }

        public void CreateReportsMenus(AppDbContext context, UserManagement user, TenantManagement tenent)
        {
            var UserCat = context.LookupData.FirstOrDefault(l => l.Name == "AppReports");
            if (UserCat != null)
            {
                var adminRole = context.Roles.FirstOrDefault(r => r.TenantId == tenent.Id && r.Name == "Admin");
                if (adminRole != null)
                {
                    context.Permissions.Add(new RolePermissionSetting { RoleId = adminRole.Id, Name = "AllowGenerateReports", IsGranted = true });
                    context.Permissions.Add(new RolePermissionSetting { RoleId = adminRole.Id, Name = "AllowReportDesign", IsGranted = true });
                    context.Permissions.Add(new RolePermissionSetting { RoleId = adminRole.Id, Name = "AllowViewAuditLog", IsGranted = true });
                    context.SaveChanges();
                }

                var userMenu = context.AdministrationMenus.FirstOrDefault(m => m.LookupId == UserCat.Id);
                if (userMenu == null)
                {
                    context.AdministrationMenus.Add(new AdminMenu()
                    {
                        Category = UserCat,
                        CreatorUserId = user.Id,
                        MenuName = "GenReport",
                        DisplayName = "Generate Process Reports",
                        Description = "Use this links to design a new Process/Form",
                        LookupId = UserCat.Id,
                        SortOrder = 1,
                        ImageIconClass = " icon-assignment-bp",
                        LinkUrl = "/Admin/Reports/ProcessRep"
                    });

                    context.AdministrationMenus.Add(new AdminMenu()
                    {
                        Category = UserCat,
                        CreatorUser = user,
                        MenuName = "ReportDesign",
                        DisplayName = "Design a new Report",
                        Description = "Use this links to design a new Workflow",
                        LookupId = UserCat.Id,
                        SortOrder = 1,
                        ImageIconClass = "icon-input-bp",
                        LinkUrl = "/Admin/Reports/Design"
                    });

                    context.AdministrationMenus.Add(new AdminMenu()
                    {
                        Category = UserCat,
                        CreatorUser = user,
                        MenuName = "RepAuditLog",
                        DisplayName = "Generate Audit Log Report",
                        Description = "Use this links to design a new Workflow",
                        LookupId = UserCat.Id,
                        SortOrder = 1,
                        ImageIconClass = "icon-supervisor-account-bp",
                        LinkUrl = "/Admin/Reports/AuditLog"
                    });

                    context.SaveChanges();

                    var menus = context.AdministrationMenus.Where(m => m.LookupId == UserCat.Id);
                    if (menus != null)
                    {
                        menus.ToList().ForEach(m =>
                        {
                            context.AdminMenuRoles.Add(new AdminMenuRoleMapper(m.Id, adminRole.Id));
                        });
                        context.SaveChanges();
                    }
                }
            }
        }

        public void CreateAdminActions(AppDbContext context, UserManagement user, TenantManagement tenent)
        {
            var adminRole = context.Roles.FirstOrDefault(r => r.TenantId == tenent.Id && r.Name == "Admin");
            if (adminRole != null)
            {
                context.Permissions.Add(new RolePermissionSetting { RoleId = adminRole.Id, Name = "AllowManageSettings", IsGranted = true });
                context.SaveChanges();
            }

            var userMenu = context.AdministrationMenus.FirstOrDefault(m => m.MenuName == "ActSettings");
            if (userMenu == null)
            {
                context.AdministrationMenus.Add(new AdminMenu()
                {
                    CreatorUserId = user.Id,
                    MenuName = "ActSettings",
                    DisplayName = "Settings",
                    Description = "To Manage BluePrint Settigns",
                    SortOrder = 1,
                    ImageIconClass = "icon-settings-applications-bp ",
                    LinkUrl = "/Admin/Settings",
                    IsAction = true
                });
                context.SaveChanges();

                var menus = context.AdministrationMenus.Where(m => m.MenuName == "ActSettings");
                if (menus != null)
                {
                    menus.ToList().ForEach(m =>
                    {
                        context.AdminMenuRoles.Add(new AdminMenuRoleMapper(m.Id, adminRole.Id));
                    });
                    context.SaveChanges();
                }
            }
        }

        public void UpdateNavigationPath(AppDbContext context, UserManagement user, TenantManagement tenent)
        {
            var rootPath = "/App/Main/Views";
            context.AdministrationMenus.ToList().ForEach(m =>
            {
                if (!m.IsAction)
                {
                    var linkName = m.LinkUrl.Replace("Admin", "").Replace("/", "") + ".cshtml";
                    var relPath = rootPath + m.LinkUrl + "/" + linkName;
                    m.LinkUrl = m.LinkUrl.Replace("/Admin", "");
                    m.RelativeUrl = relPath;
                }
            });

            context.SaveChanges();
        }
    }
}
