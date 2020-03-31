namespace ParadiseGuestHouse.Services.Data
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface ICloudinaryService
    {
        Task<string> UploadPhotoAsync(IFormFile picture, string name, string folderName);
    }
}
