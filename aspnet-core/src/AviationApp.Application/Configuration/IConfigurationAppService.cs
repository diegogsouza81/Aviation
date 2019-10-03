using System.Threading.Tasks;
using AviationApp.Configuration.Dto;

namespace AviationApp.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
