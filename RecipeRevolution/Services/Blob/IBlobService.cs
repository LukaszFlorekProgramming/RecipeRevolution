using Azure.Storage.Blobs;

namespace RecipeRevolution.Services.Blob
{
    public interface IBlobService
    {
        Task<string> UploadFileAsync(Stream content, string fileName);
        string GenerateSasToken(string blobName);
        BlobClient GetBlobClient(string blobName);
    }
}
