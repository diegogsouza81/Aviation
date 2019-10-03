using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AviationApp.MultiTenancy.Dto;

namespace AviationApp.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

