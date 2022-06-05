namespace AzureB2C.Example.App.Services
{
    public interface IResourceServerService
    {
        Task<string> GetAsync();
    }
}
