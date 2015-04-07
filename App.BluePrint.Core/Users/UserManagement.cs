using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.BluePrint.MultiTenency;
using Abp.Authorization.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.BluePrint.Users
{
	public class UserManagement : AbpUser<TenantManagement, UserManagement>
	{
        /// <summary>
        /// Settings for this user manager.
        /// </summary>
        public virtual ICollection<ManagerDefinition> Managers { get; set; }
      
        public override string ToString()
		{
			return string.Format("{0} [{1}]", UserName, Id);
		}
	}
}
