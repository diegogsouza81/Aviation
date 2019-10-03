using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AviationApp.Authorization;

namespace AviationApp
{
    [DependsOn(
        typeof(AviationAppCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AviationAppApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AviationAppAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AviationAppApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
