using Abp.Application.Services;

namespace Stilago
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class StilagoAppServiceBase : ApplicationService
    {
        protected StilagoAppServiceBase()
        {
            LocalizationSourceName = StilagoConsts.LocalizationSourceName;
        }
    }
}