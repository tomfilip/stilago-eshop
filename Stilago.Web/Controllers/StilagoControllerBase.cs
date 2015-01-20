using Abp.Web.Mvc.Controllers;

namespace Stilago.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class StilagoControllerBase : AbpController
    {
        protected StilagoControllerBase()
        {
            LocalizationSourceName = StilagoConsts.LocalizationSourceName;
        }
    }
}