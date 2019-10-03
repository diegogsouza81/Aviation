using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AviationApp.Controllers
{
    public abstract class AviationAppControllerBase: AbpController
    {
        protected AviationAppControllerBase()
        {
            LocalizationSourceName = AviationAppConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
