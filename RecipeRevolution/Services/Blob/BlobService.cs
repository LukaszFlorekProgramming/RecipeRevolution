using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;

namespace RecipeRevolution.Services.Blob
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly BlobContainerClient _containerClient;
        public BlobService(IConfiguration configuration)
        {
            _blobServiceClient = new BlobServiceClient(configuration["AzureBlobStorage:ConnectionString"]);
            _containerClient = _blobServiceClient.GetBlobContainerClient(configuration["AzureBlobStorage:ContainerName"]);
            _containerClient.CreateIfNotExists();
        }

        public string GenerateSasToken(string blobName)
        {
            var blobClient = _containerClient.GetBlobClient(blobName);
            var sasBuilder = new BlobSasBuilder
            {
                BlobContainerName = _containerClient.Name,
                BlobName = blobName,
                Resource = "b",
                StartsOn = DateTimeOffset.UtcNow.AddMinutes(-5),
                ExpiresOn = DateTimeOffset.UtcNow.AddHours(1),
                Protocol = SasProtocol.Https
            };

            sasBuilder.SetPermissions(BlobSasPermissions.Read);

            var sasToken = sasBuilder.ToSasQueryParameters(new StorageSharedKeyCredential(_blobServiceClient.AccountName, GetAccountKey())).ToString();
            return sasToken;
        }

        public BlobClient GetBlobClient(string blobName)
        {
            return _containerClient.GetBlobClient(blobName);
        }

        public async Task<string> UploadFileAsync(Stream content, string fileName)
        {
            await DeleteFileAsync(fileName);
            var blobClient = _containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(content, true);
            return blobClient.Uri.ToString();
        }

        private string GetAccountKey()
        {
            string accountKey = "N6axgKQamuev82Axc7xduIbxqij6qs9X27yDHLoTXFM2gA6zX0zv7hqK8TnNsD1QUqnE9v+O0RCl+AStQOH5jg==";
            return accountKey;
        }

        public async Task DeleteFileAsync(string fileName)
        {
            var blobClient = _containerClient.GetBlobClient(fileName);
            if (await blobClient.ExistsAsync())
            {
                await blobClient.DeleteAsync();
            }
        }
    }
}
