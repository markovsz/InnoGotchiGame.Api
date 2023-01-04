using Application.Services.Services;
using Domain.Interfaces;
using Infrastructure.Services.Exceptions;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Services.Services
{
    public class PicturesService : IPicturesService
    {
        private IRepositoryManager _repositoryManager;
        private IConfiguration _configuration;

        public PicturesService(IRepositoryManager repositoryManager, IConfiguration configuration)
        {
            _repositoryManager = repositoryManager;
            _configuration = configuration;
        }

        public string CreatePicture(string pictureBase64)
        {
            string pictureName = Guid.NewGuid() + ".png";
            var picturesSourceFolder = _configuration.GetSection("Pictures").GetSection("sourceFolder").Value;
            string picturePath = picturesSourceFolder + pictureName;
            File.WriteAllBytes(picturePath, Convert.FromBase64String(pictureBase64));
            return pictureName;
        }

        public void RemovePicture(string pictureName)
        {
            var picturesSourceFolder = _configuration.GetSection("Pictures").GetSection("sourceFolder").Value;
            string picturePath = picturesSourceFolder + pictureName;
            if (!File.Exists(picturePath))
                throw new IncorrectRequestDataException("Incorrect picture name");
            File.Delete(picturePath);
        }
    }
}
