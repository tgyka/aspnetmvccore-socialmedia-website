using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SocialMedia.Helper.File
{
    public interface IFileHelper
    {
        Task<string> UploadFile(IHostingEnvironment environment, IFormFile file);
    }
}