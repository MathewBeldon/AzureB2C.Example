using AzureB2C.Example.App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;

namespace AzureB2C.Example.App.Controllers
{
    public class ResourceServerController : Controller
    {
        private IResourceServerService _resourceServerService;

        public ResourceServerController(IResourceServerService resourceServerService)
        {
            _resourceServerService = resourceServerService;
        }

        [AuthorizeForScopes(ScopeKeySection = "ResourceServer:Scope")]
        public async Task<ActionResult> Index()
        {
            return View(await _resourceServerService.GetAsync());
        }
    }
}