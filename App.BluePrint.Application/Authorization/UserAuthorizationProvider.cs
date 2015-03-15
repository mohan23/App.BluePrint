using Abp.Authorization;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BluePrint.Authorization
{
    public class UserAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //User permissions
            context.CreatePermission("CanCreateUsers", new FixedLocalizableString("Can create users"));
            context.CreatePermission("CanDeleteUsers", new FixedLocalizableString("Can delete users"));
            context.CreatePermission("CanModifyUsers", new FixedLocalizableString("Can modify users"));
            context.CreatePermission("CanViewUsers", new FixedLocalizableString("Can view users"), isGrantedByDefault: true);

            //RolePermissions
            context.CreatePermission("CanCreateRoles", new FixedLocalizableString("Can create Roles"));
            context.CreatePermission("CanDeleteRoles", new FixedLocalizableString("Can delete Roles"));
            context.CreatePermission("CanModifyRoles", new FixedLocalizableString("Can modify Roles"));
            context.CreatePermission("CanViewRoles", new FixedLocalizableString("Can view Roles"), isGrantedByDefault: true);

            //RoleUserPermissions
            context.CreatePermission("CanAssignRoleToUser", new FixedLocalizableString("Can Assign role to user"));
            context.CreatePermission("CanRemokeRoleFromUser", new FixedLocalizableString("Can Remove User role"));
            context.CreatePermission("CanViewUserRoles", new FixedLocalizableString("Can view users role"), isGrantedByDefault: true);
        }
    }
}
