using Abp.Web.Mvc.Views;

namespace App.BluePrint.Web.Views
{
    public abstract class ApplicationViewPageBase : ApplicationViewPageBase<dynamic>
    {

    }

    public abstract class ApplicationViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected ApplicationViewPageBase()
        {
            LocalizationSourceName = Consts.LocalizationSourceName;
        }
    }
}