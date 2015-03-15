using Abp.Web.Mvc.Controllers;

namespace App.BluePrint.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class ApplicationControllerBase : AbpController
    {
        protected ApplicationControllerBase()
        {
            LocalizationSourceName = Consts.LocalizationSourceName;
        }
    }
}