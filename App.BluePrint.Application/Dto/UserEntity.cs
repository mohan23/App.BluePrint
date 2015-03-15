using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using App.BluePrint.Users;

namespace App.BluePrint.UserService.Dto
{
    [AutoMapFrom(typeof(UserManagement))]
    public class UserEntity : EntityDto<long>
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string FullName { get { return Name + ' ' + Surname; } }

    }
}
