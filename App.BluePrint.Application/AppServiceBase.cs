using Abp.Application.Services;

namespace App.BluePrint
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class AppServiceBase : ApplicationService
    {
        protected AppServiceBase()
        {
            LocalizationSourceName = Consts.LocalizationSourceName;
        }
    }
}