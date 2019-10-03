using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AviationApp.Configuration.Dto;

namespace AviationApp.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AviationAppAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
