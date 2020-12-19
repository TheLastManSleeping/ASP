using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SocialNetwork
{
    public interface IImageService
    {
        Task SaveImage(IFormFile file, string filePath);
    }
}