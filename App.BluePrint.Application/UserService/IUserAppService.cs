using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using App.BluePrint.Users;
using App.BluePrint.UserService.Dto;

namespace App.BluePrint.UserService
{
    public interface IUserAppService : IApplicationService
    {
        ListResultOutput<UserEntity> GetAllUsers();
        ListResultOutput<UserEntity> SearchUser(Expression<Func<UserManagement, bool>> expr);
        EntityResultOutput<UserEntity> GetUserById(EntityRequestInput input);
    }
}
