using System.Drawing.Imaging;
using System.Drawing;


namespace CinemaControlSystem.Utils
{
    public static class FileOperationHelpers
    {
        public static string GetFileExtensionFromMimeType(string mimeType)
        {
            // Map of common MIME types to file extensions
            var mimeToExtensionMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        { "image/jpeg", ".jpg" },
        { "image/png", ".png" },
        { "image/gif", ".gif" },
        { "image/webp", ".webp"}
        // Add more mappings as needed
    };

            // Return the corresponding file extension or null if not found
            if (mimeToExtensionMap.TryGetValue(mimeType, out string extension))
            {
                return extension;
            }

            return null; // Or return a default value, like ".bin" for binary files
        }


        // stack over flow 

        public static string GetMimeTypeFromImageByteArray(byte[] byteArray)
        {
            using (MemoryStream stream = new MemoryStream(byteArray))
            using (Image image = Image.FromStream(stream))
            {
                return ImageCodecInfo.GetImageEncoders().First(codec => codec.FormatID == image.RawFormat.Guid).MimeType;
            }
        }
    }
}
