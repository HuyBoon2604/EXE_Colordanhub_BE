using Microsoft.AspNetCore.Http;


namespace Booking_Dance_Bussiness.Service.Interfaces
{
    public interface IFirebaseService {
        Task<List<string>> GetAllObjects();
        //Task<(MemoryStream, string)> GetImage(string filePath);
        Task<string> UploadImage(IFormFile file, string folder, string userId);
        Task<List<Google.Apis.Storage.v1.Data.Object>> GetObjectsByUserId(string userId);
        Task<List<string>> GetObjectsByUserId2(string userId);
        Task<(MemoryStream, string)> GetImage2(string filePath);
        Task<List<string>> GetImagePaths();
        Task<string> GetImagePath(string filepath,string folder);

    }
}
