﻿using System.Reflection;
using Abp.Modules;

namespace Stilago
{
    public class StilagoCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
