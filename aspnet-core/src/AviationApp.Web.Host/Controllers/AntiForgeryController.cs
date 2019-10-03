using Microsoft.AspNetCore.Antiforgery;
using AviationApp.Controllers;

namespace AviationApp.Web.Host.Controllers
{
    public class AntiForgeryController : AviationAppControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
