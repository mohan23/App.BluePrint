using Abp.Domain.Repositories;
using App.BluePrint.MultiTenency;
using App.BluePrint.Users;
using Abp.Runtime.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Abp.Domain.Uow;
using Abp.UI;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using Abp.Runtime.Security;
using Abp.Web.Mvc.Models;
using Abp.UserManagement.Framework.Configuration;

namespace App.BluePrint.Web.Controllers
{
    public class AccountController : ApplicationControllerBase
    {
        #region -- Declarations --

        private readonly UserManager _userManager;

        private readonly IRepository<UserManagement, long> _userDefinition;
        private readonly IRepository<TenantManagement, int> _tenentDefinition;
        private readonly MultiTenancyConfig _mTenencySetting;

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        #endregion

        #region -- Constructors --

        public AccountController(UserManager userManager, IRepository<UserManagement, long> userRepository, IRepository<TenantManagement, int> tenantRepository, MultiTenancyConfig multiTenancy)
        {
            _userManager = userManager;
            _userDefinition = userRepository;
            _tenentDefinition = tenantRepository;
            _mTenencySetting = multiTenancy;
        }

        #endregion

        #region -- View Methods --

        public ActionResult Login(string returnUrl = "")
        {
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = Request.ApplicationPath;
            }

            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [UnitOfWork]
        [HttpPost]
        public virtual JsonResult Login(LoginViewModel loginModel, string returnUrl = "")
        {
            if (!ModelState.IsValid)
            {
                throw new UserFriendlyException("Your form is invalid!");
            }

            UserManagement user;
            var tenencyName = "BASE";

            if (!_mTenencySetting.IsEnabled)
            {
                user = _userManager.Find(loginModel.UsernameOrEmailAddress, loginModel.Password);
                if (user == null)
                {
                    throw new UserFriendlyException("Invalid user name or password!");
                }
            }
            else 
            {
                tenencyName = (string.IsNullOrWhiteSpace(loginModel.TenancyName) ? "BASE" : loginModel.TenancyName);
                var tenant = _tenentDefinition.FirstOrDefault(t => t.TenancyName == tenencyName);
                if (tenant == null)
                {
                    throw new UserFriendlyException("No tenant with name: " + tenencyName);
                }

                user = _userDefinition.FirstOrDefault(
                    u =>
                        (u.UserName == loginModel.UsernameOrEmailAddress ||
                         u.EmailAddress == loginModel.UsernameOrEmailAddress)
                        && u.TenantId == tenant.Id
                    );

                if (user == null)
                {
                    throw new UserFriendlyException("Invalid user name or password!");
                }

                var verificationResult = new PasswordHasher().VerifyHashedPassword(user.Password, loginModel.Password);
                if (verificationResult != PasswordVerificationResult.Success)
                {
                    throw new UserFriendlyException("Invalid user name or password!");
                }
            }


            //else
            //{
            //    throw new Exception("Tenant is not set!");
            //}

            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            identity.AddClaim(new Claim(AbpClaimTypes.TenantId, user.TenantId.HasValue ? user.TenantId.Value.ToString() : null));

            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = loginModel.RememberMe }, identity);

            user.LastLoginTime = DateTime.Now;

            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = Request.ApplicationPath;
            }

            return Json(new MvcAjaxResponse { TargetUrl = returnUrl });
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }

        #endregion
    }
}