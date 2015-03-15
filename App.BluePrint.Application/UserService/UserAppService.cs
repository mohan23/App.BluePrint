using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using App.BluePrint.Users;
using App.BluePrint.UserService.Dto;

namespace App.BluePrint.UserService
{
    public class UserAppService : ApplicationService, IUserAppService
    {
        private readonly IRepository<UserManagement, long> _userRepository;

        public UserAppService(IRepository<UserManagement, long> userRepository)
        {
            _userRepository = userRepository;
        }
        public ListResultOutput<UserEntity> GetAllUsers()
        {
            return new ListResultOutput<UserEntity>
            {
                Items = _userRepository
                           .GetAllList(u => u.TenantId == CurrentSession.TenantId)
                           .MapTo<List<UserEntity>>()
            };
        }

        public EntityResultOutput<UserEntity> GetUserById(EntityRequestInput input)
        {
            Logger.InfoFormat("---> GetUserById --> {0} ", input.Id.ToString());
            var userData = _userRepository.Get(input.Id).MapTo<UserEntity>();
            Logger.InfoFormat("---> GetUserById --> {0} --> Return Data --> {1}", userData.Id.ToString(), userData.Name);
            return new EntityResultOutput<UserEntity> { Id = userData };
        }

        public ListResultOutput<UserEntity> SearchUser(Expression<Func<UserManagement, bool>> expr)
        {
            return new ListResultOutput<UserEntity>
            {
                Items = _userRepository
                          .GetAllList(expr)
                          .MapTo<List<UserEntity>>()
            };
        }
    }
}
