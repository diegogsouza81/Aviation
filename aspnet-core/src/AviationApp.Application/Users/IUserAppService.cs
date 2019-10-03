using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AviationApp.Roles.Dto;
using AviationApp.Users.Dto;

namespace AviationApp.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
