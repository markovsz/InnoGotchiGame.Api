using System;

namespace Application.Services.Services
{
    public interface IPicturesService
    {
        string CreatePicture(string pictureBase64);
        void RemovePicture(string pictureName);
    }
}
