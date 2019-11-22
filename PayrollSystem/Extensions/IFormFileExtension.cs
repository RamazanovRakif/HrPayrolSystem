using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.Extensions
{
    public static class IFormFileExtension
    {
        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image/");
        }

        public static bool IsLessThan(this IFormFile file, int mb)
        {
            return file.Length / 1024 / 1024 < mb;
        }
        public async static Task<string> SaveAsync(this IFormFile file, string root, string folder)
        {

            string path = Path.Combine(root, "images");
            string fileName = Path.Combine(Guid.NewGuid().ToString() + file.FileName);
            string resultPath = Path.Combine(path, fileName);
            using (FileStream fileStream = new FileStream(resultPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return fileName;
        }
    }
    

}
