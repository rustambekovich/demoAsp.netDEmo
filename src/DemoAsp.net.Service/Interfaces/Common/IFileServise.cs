using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAsp.net.Service.Interfaces.Common
{
    public interface IFileServise
    {
        // returns sub path of this image
        public Task<string> UploadImageAsync(IFormFile image);

        public Task<bool> DeleteImageAsync(IFormFile subpath);

        // returns sub path of this avatar
        
    }
}
