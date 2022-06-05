using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace AzureB2C.Example.Api.Controllers
{
    [Authorize]
    [Route("api")]
    [RequiredScope(scopeRequiredByAPI)]
    public sealed class ResourceController : Controller
    {
        const string scopeRequiredByAPI = "read";

        [HttpGet("message")]
        public async Task<IActionResult> GetMessage()
        {
            return Content($"{User.Identity.Name} has been successfully authenticated.");
        }
    }
}
