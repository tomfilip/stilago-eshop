using System.Reflection;
using Abp.Modules;

namespace Stilago
{
    [DependsOn(typeof(StilagoCoreModule))]
    public class StilagoApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            AutomapperMappings.Init();
        }
    }
}
