using App.BluePrint.UserFramework.MultiTenency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BluePrint.UserFramework.Authorization
{
    /// <summary>
    /// Used to perform database operations for roles.
    /// </summary>
    public interface IRolePermissionStore<TRole, TTenant, TUser>
        where TRole : RoleDefinition<TTenant, TUser>
        where TUser : UserDefinition<TTenant, TUser>
        where TTenant : TenentDefinition<TTenant, TUser>
    {
        /// <summary>
        /// Adds a permission grant setting to a role.
        /// </summary>
        /// <param name="role">Role</param>
        /// <param name="permissionGrant">Permission grant setting info</param>
        Task AddPermissionAsync(TRole role, PermissionGrantInfo permissionGrant);

        /// <summary>
        /// Removes a permission grant setting from a role.
        /// </summary>
        /// <param name="role">Role </param>
        /// <param name="permissionGrant">Permission grant setting info</param>
        Task RemovePermissionAsync(TRole role, PermissionGrantInfo permissionGrant);

        /// <summary>
        /// Gets permission grant setting informations for a role.
        /// </summary>
        /// <param name="role">Role</param>
        /// <returns>List of permission setting informations</returns>
        Task<IList<PermissionGrantInfo>> GetPermissionsAsync(TRole role);

        /// <summary>
        /// Checks whether a role has a permission grant setting info.
        /// </summary>
        /// <param name="role">Role</param>
        /// <param name="permissionGrant">Permission grant setting info</param>
        /// <returns></returns>
        Task<bool> HasPermissionAsync(TRole role, PermissionGrantInfo permissionGrant);
    }

}
