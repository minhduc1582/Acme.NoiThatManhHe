using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Acme.NoiThatManhHe.CloudinaryNet
{
    public interface ICloudianryAppService
    {
        string UploadImageToCloudinary(string urlImg);
    }
}
