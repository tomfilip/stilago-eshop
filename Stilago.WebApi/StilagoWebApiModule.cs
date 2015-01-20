using System.Reflection;
using Abp.Application.Services;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;

namespace Stilago
{
    [DependsOn(typeof(AbpWebApiModule), typeof(StilagoApplicationModule))]
    public class StilagoWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(StilagoApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
