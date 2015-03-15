using Abp.Domain.Repositories;
using App.BluePrint.Test.Authorization._TestBasis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Abp.Configuration;

namespace App.BluePrint.Test.Authorization
{
    public class TestAuthorization : TestBase
    {
        [Fact]
        public void CreateTenent()
        {
            var tenentRepo = LocalIocManager.Resolve<IRepository<TestTenant, int>>();
			var tenent1 = new TestTenant("BluePrintForEmerio", "BluePrint for Emerio 2.0");
			tenent1.Settings.Add(new UserFramework.Configuration.Setting { Name = "CompanyName", Value = "Emerio Austraila Pty Ltd" });
			tenent1.Settings.Add(new UserFramework.Configuration.Setting { Name = "CompanyUser", Value = "Mohan D. Kumar" });
			tenent1.Settings.Add(new UserFramework.Configuration.Setting { Name = "EmailAddress", Value = "mohan.kumar@emeriocorp.com" });
			tenent1.Settings.Add(new UserFramework.Configuration.Setting { Name = "CompanyAddress", Value = "19, 321 Kent Street, Sydney, NSW 2000" });
			tenent1.Settings.Add(new UserFramework.Configuration.Setting { Name = "ContantNo", Value = "+61 2 8903 4900" });
			tenent1.Settings.Add(new UserFramework.Configuration.Setting { Name = "MobileNo", Value = "+61 468 419 155" });
			tenent1.Settings.Add(new UserFramework.Configuration.Setting { Name = "SiteUrl", Value = "http://blueprint.emerioapps.com" });
			tenent1.Settings.Add(new UserFramework.Configuration.Setting { Name = "LicenseType", Value = "Enterprise" });
			tenent1.Settings.Add(new UserFramework.Configuration.Setting { Name = "ExpiryDate", Value = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==" });

			tenentRepo.FirstOrDefault(t => t.TenancyName == "BluePrintForEmerio").ShouldBe(null);
			var tenentId = tenentRepo.InsertOrUpdateAndGetId(tenent1);
			tenentRepo.FirstOrDefault(t => t.TenancyName == "BluePrintForEmerio").ShouldNotBe(null);
			System.Diagnostics.Trace.WriteLine("Successfully Added New Tenent, TenentId: " + tenentId.ToString());
		}

        [Fact]
        public void Should_Insert_And_Retrieve_User()
        {
            var useRepository = LocalIocManager.Resolve<IRepository<TestUser, long>>();

            useRepository.FirstOrDefault(u => u.EmailAddress == "admin@aspnetboilerplate.com").ShouldBe(null);

            useRepository.Insert(new TestUser
            {
                TenantId = null,
                UserName = "admin",
                Name = "System",
                Surname = "Administrator",
                EmailAddress = "admin@aspnetboilerplate.com",
                IsEmailConfirmed = true,
                Password = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==" //123qwe
            });

            DbContext.SaveChanges();

            useRepository.FirstOrDefault(u => u.EmailAddress == "admin@aspnetboilerplate.com").ShouldNotBe(null);
        }

    }
}
