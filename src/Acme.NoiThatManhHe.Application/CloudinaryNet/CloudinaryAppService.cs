using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.NoiThatManhHe.CloudinaryNet
{
    public class CloudinaryAppService : ICloudianryAppService
    {
        Account account = new Account(
          "dyvlzl3cw",
          "545395683675983",
          "z1i3oIu7ssuIG-1Gk6UCCvfc-Hc");
        
        public string UploadImageToCloudinary(string urlImg)
        {
            Cloudinary cloudinary = new Cloudinary(account);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(urlImg),
                Folder = "projects/IOTLink/NoiThat"

            };
            var uploadResult = cloudinary.Upload(uploadParams);
            return uploadResult.Url.ToString();
        }
    }
}
