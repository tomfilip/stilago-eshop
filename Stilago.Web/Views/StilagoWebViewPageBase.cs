using Abp.Web.Mvc.Views;

namespace Stilago.Web.Views
{
    public abstract class StilagoWebViewPageBase : StilagoWebViewPageBase<dynamic>
    {

    }

    public abstract class StilagoWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected StilagoWebViewPageBase()
        {
            LocalizationSourceName = StilagoConsts.LocalizationSourceName;
        }
    }
}