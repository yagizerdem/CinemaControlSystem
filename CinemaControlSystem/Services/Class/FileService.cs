using CinemaControlSystem.Models;
using CinemaControlSystem.Services.Interface;

namespace CinemaControlSystem.Services.Class
{
    public class FileService :  IFileService
    {

        public async Task<ServiceResponse<string>> UploadFileByteArray(byte[] fileBytes,  string dirName ,string filePath)
        {
            try
            {
                // Validate input
                if (fileBytes == null || fileBytes.Length == 0)
                {
                    return ServiceResponse<string>.Fail("Invalid file data.");
                }

                // Ensure the target directory exists
                if (!Directory.Exists(dirName))
                {
                    Directory.CreateDirectory(dirName);
                }

                // Write the byte array to a file
                await File.WriteAllBytesAsync(filePath , fileBytes);

                return ServiceResponse<string>.Success(filePath, "File Upload successfull");
            }
            catch (Exception ex)
            {
                return ServiceResponse<string>.Fail("internal serve error");
            }
        }


    }
}
