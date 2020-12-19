using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SocialNetwork
{
    public class ImageService : IImageService
    {
        public async Task SaveImage(IFormFile file, string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            
        }
    }
}