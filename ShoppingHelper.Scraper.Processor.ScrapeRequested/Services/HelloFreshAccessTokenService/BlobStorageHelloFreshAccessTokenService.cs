using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;
using ShoppingHelper.Scraper.Processor.ScrapeRequested.Common.Options;

namespace ShoppingHelper.Scraper.Processor.ScrapeRequested.Services.HelloFreshAccessTokenService;

public class BlobStorageHelloFreshAccessTokenService(
    BlobServiceClient blobServiceClient,
    IOptions<HelloFreshBlobStorageOptions> helloFreshBlobStorageOptions) : IHelloFreshAccessTokenService
{
    private readonly BlobServiceClient _blobServiceClient = blobServiceClient;
    private readonly IOptions<HelloFreshBlobStorageOptions> _helloFreshBlobStorageOptions = helloFreshBlobStorageOptions;

    public async Task<string> GetAccessToken(CancellationToken cancellationToken)
    {
        var blobContainerClient = _blobServiceClient.GetBlobContainerClient(_helloFreshBlobStorageOptions.Value.HelloFreshAccessTokenContainer);
        var blobClient = blobContainerClient.GetBlobClient(_helloFreshBlobStorageOptions.Value.HelloFreshAccessTokenBlob);

        var content = await blobClient.DownloadContentAsync(cancellationToken);
        var accessToken = content.Value.Content.ToString();

        return accessToken;
    }
}
