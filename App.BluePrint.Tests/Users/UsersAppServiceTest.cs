using Abp.Application.Services.Dto;
using App.BluePrint.UserService;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace App.BluePrint.Tests.Users
{
    public class UsersAppServiceTest : BluePrintTestBase
    {
        private readonly IUserAppService _userAppService;

        public UsersAppServiceTest()
        {
            _userAppService = LocalIocManager.Resolve<IUserAppService>();
        }

        [Fact]
        public void Should_Get_Users()
        {
            var output = _userAppService.GetAllUsers();
            output.Items.FirstOrDefault(i => i.UserName == "admin").ShouldNotBe(null); //Since initial data has admin user
        }

        [Fact]
        public void Should_Get_UserById()
        {
            var userId = 1;
            var userInfo = _userAppService.GetUserById(new EntityRequestInput { Id = userId });
            userInfo.ShouldNotBe(null);
        }
    }
}
