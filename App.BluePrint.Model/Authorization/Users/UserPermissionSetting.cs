using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BluePrint.UserFramework.Authorization
{
    public class UserPermissionSetting : PermissionSetting
    {
        public virtual long UserId { get; set; }
    }

}
