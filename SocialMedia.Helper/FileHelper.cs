using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Helper
{
    public static class FileHelper
    {
        public static async Task<string> UploadFile(IHostingEnvironment environment , IFormFile file)
        {
            try
            {
                string uploadsFolder = Path.Combine(environment.WebRootPath, "images");
                string fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, fileName);
                await file.CopyToAsync(new FileStream(filePath, FileMode.Create));

                return fileName;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
