using Abp.Authorization;
using AviationApp.Authorization.Roles;
using AviationApp.Authorization.Users;

namespace AviationApp.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
