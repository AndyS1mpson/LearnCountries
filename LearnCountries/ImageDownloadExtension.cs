using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LearnCountries
{
    public static class ImageDownloadExtension
    {
        public static async Task ImageDownload(this IFormFile file)
        {
             using (var httpClient = new HttpClient())
            {
                File.WriteAllBytes(Environment.CurrentDirectory + @"\wwwroot\images",
                await httpClient.GetByteArrayAsync(file.ToString()));
            }
        }
    }
}