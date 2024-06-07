using Azure.Identity;
using Azure.Storage.Blobs;
using ShoppingHelper.Scraper.Api.Common.Options;

namespace ShoppingHelper.Scraper.Api.Common.Extensions.IServiceCollectionExtensions;

public static class RegisterBlobServiceClientExtension
{
    public static IServiceCollection RegisterBlobServiceClient(this IServiceCollection services, IConfiguration configuration)
    {
        var serviceUri = configuration.GetRequiredSection(BlobStorageOptions.Section)[nameof(BlobStorageOptions.ServiceUri)];
        var bloblServiceClient = new BlobServiceClient(new Uri(serviceUri!), new DefaultAzureCredential());

        services.AddSingleton(bloblServiceClient);
        return services;
    }
}
