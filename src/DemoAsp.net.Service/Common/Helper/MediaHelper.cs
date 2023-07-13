using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAsp.net.Service.Common.Helper
{
    public class MediaHelper
    {
        public static string MakeImageName(string imageName)
        {
            FileInfo fileInfofileInfo = new FileInfo(imageName);
            string extention = fileInfofileInfo.Extension;
            string name = "IMG" + Guid.NewGuid() + extention;
            return name;
        }
    }
}
