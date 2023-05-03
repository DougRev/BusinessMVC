using Azure.Storage.Blobs;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Web;

namespace BusinessMVC2.Models
{
    public class AzureBlobDataStore : IDataStore
    {
        private readonly BlobContainerClient _containerClient;

        public AzureBlobDataStore(string storageConnectionString, string containerName)
        {
            _containerClient = new BlobContainerClient(storageConnectionString, containerName);
            _containerClient.CreateIfNotExists();
        }

        public Task ClearAsync()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync<T>(string key)
        {
            await _containerClient.DeleteBlobIfExistsAsync(key);
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var blobClient = _containerClient.GetBlobClient(key);

            if (await blobClient.ExistsAsync())
            {
                using (var memoryStream = new MemoryStream())
                {
                    await blobClient.DownloadToAsync(memoryStream);
                    memoryStream.Position = 0;
                    var formatter = new BinaryFormatter();
                    return (T)formatter.Deserialize(memoryStream);
                }
            }

            return default(T);
        }

        public async Task StoreAsync<T>(string key, T value)
        {
            var blobClient = _containerClient.GetBlobClient(key);

            using (var memoryStream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, value);
                memoryStream.Position = 0;
                await blobClient.UploadAsync(memoryStream, overwrite: true);
            }
        }
    }
}