
using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;
using ShoppingHelper.Scraper.Api.Common.Options;

namespace ShoppingHelper.Scraper.Api.Services.HelloFreshAccessTokenService;

public class BlobStorageHelloFreshAccessTokenService(
    BlobServiceClient blobServiceClient,
    IOptions<BlobStorageOptions> blobStorageOptions) : IHelloFreshAccessTokenService
{
    private readonly BlobServiceClient _blobServiceClient = blobServiceClient;
    private readonly IOptions<BlobStorageOptions> _blobStorageOptions = blobStorageOptions;

    public async Task<string> GetAccessToken(CancellationToken cancellationToken)
    {
        var blobContainerClient = _blobServiceClient.GetBlobContainerClient(_blobStorageOptions.Value.HelloFreshAccessTokenContainer);
        var blobClient = blobContainerClient.GetBlobClient(_blobStorageOptions.Value.HelloFreshAccessTokenBlob);

        var content = await blobClient.DownloadContentAsync(cancellationToken);
        var accessToken = content.Value.Content.ToString();

        return accessToken;
    }
}
