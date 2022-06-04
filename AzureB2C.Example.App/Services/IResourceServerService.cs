using AzureB2C.Example.App.Models;

namespace AzureB2C.Example.App.Services
{
    public interface IResourceServerService
    {
        Task<ResourceServerResponse> GetAsync();
    }
}
