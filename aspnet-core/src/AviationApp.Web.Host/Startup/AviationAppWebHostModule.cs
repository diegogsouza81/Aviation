using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AviationApp.Configuration;

namespace AviationApp.Web.Host.Startup
{
    [DependsOn(
       typeof(AviationAppWebCoreModule))]
    public class AviationAppWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AviationAppWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AviationAppWebHostModule).GetAssembly());
        }
    }
}
