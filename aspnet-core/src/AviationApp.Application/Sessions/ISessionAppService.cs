using System.Threading.Tasks;
using Abp.Application.Services;
using AviationApp.Sessions.Dto;

namespace AviationApp.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
