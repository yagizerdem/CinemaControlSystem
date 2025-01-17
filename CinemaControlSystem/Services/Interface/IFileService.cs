using CinemaControlSystem.Models;

namespace CinemaControlSystem.Services.Interface
{
    public interface IFileService
    {
        public Task<ServiceResponse<string>> UploadFileByteArray(byte[] fileBytes, string dirName, string filePath);
    }
}
