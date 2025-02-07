using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Google.Cloud.Storage.V1;
using Booking_Dance_Bussiness.Service.Interfaces;
using Booking_Dance_Data.Models.Entities;

namespace Booking_Dance_Bussiness.Service.Implements
{
    public class FirebaseService : IFirebaseService
    {
        private readonly StorageClient _storageClient;
        private readonly string _bucketName = "cursusprojectinternship.appspot.com";
        private readonly ILogger<FirebaseService> _logger;

        public FirebaseService(StorageClient storageClient, ILogger<FirebaseService> logger)
        {
            _storageClient = storageClient;
            _logger = logger;
        }

        public async Task<List<string>> GetAllObjects()
        {
            List<string> objectNames = new List<string>();

            // List all objects in the bucket
            await foreach (var storageObject in _storageClient.ListObjectsAsync(_bucketName))
            {
                // Add the object name to the list
                if (!string.IsNullOrEmpty(storageObject.Name))
                {
                    objectNames.Add(storageObject.Name);
                }
            }

            return objectNames;
        }

      
        public async Task<(MemoryStream, string)> GetImage2(string filePath)
        {
            try
            {
                var storageObject = await _storageClient.GetObjectAsync(_bucketName, filePath);

                string userId = null;
                if (storageObject.Metadata != null && storageObject.Metadata.TryGetValue("userId", out string objectUserId))
                {
                    userId = objectUserId;
                }
                else
                {
                    _logger.LogWarning($"Object {filePath} does not have 'userId' metadata.");
                }

                MemoryStream memoryStream = new MemoryStream();
                await _storageClient.DownloadObjectAsync(storageObject, memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);

                return (memoryStream, userId);
            }
            catch (Google.GoogleApiException gae)
            {
                _logger.LogError($"Google API Exception while retrieving object {filePath} from bucket {_bucketName}: {gae.Message}");
                throw; // Rethrow the exception to handle it in the calling code if needed
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception while retrieving object {filePath} from bucket {_bucketName}: {ex.Message}");
                return (null, null); // Return null values indicating failure
            }
        }


        public async Task<List<Google.Apis.Storage.v1.Data.Object>> GetObjectsByUserId(string userId)
        {
            List<Google.Apis.Storage.v1.Data.Object> allObjects = new List<Google.Apis.Storage.v1.Data.Object>();

            // List all objects in the bucket
            foreach (var storageObject in _storageClient.ListObjects(_bucketName))
            {
                // Check if the object has metadata and the userId matches
                if (storageObject.Metadata != null && storageObject.Metadata.ContainsKey("userId") && storageObject.Metadata["userId"] == userId)
                {
                    allObjects.Add(storageObject);
                }
            }

            return allObjects;
        }

        public async Task<List<string>> GetObjectsByUserId2(string userId)
        {
            List<string> mediaLinks = new List<string>();

            // List all objects in the bucket
            await foreach (var storageObject in _storageClient.ListObjectsAsync(_bucketName))
            {
                // Check if the object has metadata and the userId matches
                if (storageObject.Metadata != null &&
                    storageObject.Metadata.TryGetValue("userId", out string objectUserId) &&
                    objectUserId == userId)
                {
                    if (!string.IsNullOrEmpty(storageObject.Name))
                    {
                        mediaLinks.Add(storageObject.Name);
                    }
                }
            }

            return mediaLinks;
        }


        public async Task<string> UploadImage(IFormFile file, string folder, string userId)
        {
            if (file is null || file.Length == 0)
            {
                return "File is empty!";
            }

            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = $"{folder}/{fileName}";
            var tokenAccess=$"{Guid.NewGuid()}";

            await using (var stream = file.OpenReadStream())
            {
                var storageObject = new Google.Apis.Storage.v1.Data.Object
                {
                    Bucket = _bucketName,
                    Name = filePath,
                    ContentType = file.ContentType,
                    Metadata = new Dictionary<string, string>
            { 
                { "userId", userId },
                 {"firebaseStorageDownloadTokens",tokenAccess }
            }
                };

                await _storageClient.UploadObjectAsync(storageObject, stream);
            }

            return filePath;
        }
        public async Task<List<string>> GetImagePaths()
        {
            var imagePaths = new List<string>();
            var storageObjects = _storageClient.ListObjects(_bucketName, "images/");
           

             foreach (var storageObject in storageObjects)
            {
               storageObject.Metadata.TryGetValue("firebaseStorageDownloadTokens", out string tokenId);
                var imagePath = $"https://firebasestorage.googleapis.com/v0/b/{_bucketName}/o/{Uri.EscapeDataString(storageObject.Name)}?alt=media&token={tokenId}";

                imagePaths.Add(imagePath);
            }

            return imagePaths;
        }

        public async Task<string> GetImagePath(string filepath,string folder)
        {
            var storageObjects = _storageClient.ListObjects(_bucketName, folder);

            foreach (var storageObject in storageObjects)
            {
                if (storageObject.Name == filepath)
                {
                    storageObject.Metadata.TryGetValue("firebaseStorageDownloadTokens", out string tokenId);


                    var imagePath = $"https://firebasestorage.googleapis.com/v0/b/{_bucketName}/o/{Uri.EscapeDataString(storageObject.Name)}?alt=media&token={tokenId}";

                    return imagePath;
                }
            }

            return null;
        }



    }
}
