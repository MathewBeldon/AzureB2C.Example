using AzureB2C.Example.App.Models;
using Microsoft.Identity.Web;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace AzureB2C.Example.App.Services
{
    public static class ResourceServerServiceRegistration
    {
        public static void AddAddResourseServerService(this IServiceCollection services)
        {
            services.AddHttpClient<IResourceServerService, ResourceServerService> ();
        }
    }

    public class ResourceServerService : IResourceServerService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient _httpClient;
        private readonly string _resourceServerScope = string.Empty;
        private readonly string _resourceServerBaseAddress = string.Empty;
        private readonly ITokenAcquisition _tokenAcquisition;

        public ResourceServerService(ITokenAcquisition tokenAcquisition, HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor contextAccessor)
        {
            _httpClient = httpClient;
            _tokenAcquisition = tokenAcquisition;
            _contextAccessor = contextAccessor;
            _resourceServerScope = configuration["ResourceServer:Scope"];
            _resourceServerBaseAddress = configuration["ResourceServer:BaseAddress"];
        }
        public async Task<ResourceServerResponse> GetAsync()
        {
            await PrepareAuthenticatedClient();

            throw new NotImplementedException();            
        }

        private async Task PrepareAuthenticatedClient()
        {
            var accessToken = await _tokenAcquisition.GetAccessTokenForUserAsync(new[] { _resourceServerScope });
            Debug.WriteLine($"access token-{accessToken}");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}