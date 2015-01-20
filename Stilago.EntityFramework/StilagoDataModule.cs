using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using Stilago.EntityFramework;

namespace Stilago
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(StilagoCoreModule))]
    public class StilagoDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<StilagoDbContext>(null);
        }
    }
}
