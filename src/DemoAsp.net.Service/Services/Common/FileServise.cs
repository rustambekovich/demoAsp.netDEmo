using DemoAsp.net.Service.Common.Helper;
using DemoAsp.net.Service.Interfaces.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAsp.net.Service.Services.Common
{
    public class FileServise : IFileServise
    {
        private readonly string MEDIA = "media";
        private readonly string IMAGES = "images";
        private readonly string ROOTPATH;

        public FileServise(IWebHostEnvironment env)
        {
            ROOTPATH = env.WebRootPath; 
        } 
       

        public async Task<bool> DeleteImageAsync(string subpath)
        {
            string path = Path.Combine(ROOTPATH, subpath);
            if(File.Exists(path))
            {
                await Task.Run(() =>
                {
                    File.Delete(path);
                });
                return true;
            }
            return false;
        }

       

        public async Task<string> UploadImageAsync(IFormFile image)
        {
            string newImageName = MediaHelper.MakeImageName(image.FileName);
            string subpath = Path.Combine(MEDIA, IMAGES, newImageName );

            string path = Path.Combine(ROOTPATH, subpath);
            var stream = new FileStream(path, FileMode.Create);
            await image.CopyToAsync(stream);
            stream.Close();
            return subpath;
        }
    }
}
