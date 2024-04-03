using System;
using RealEstate_API.Services.Interfaces;

namespace RealEstate_API.Services
{
    public class FileService : IFileService
    {
        public FileService()
        {
        }

        public bool IsImage(IFormFile file)
        {
            return file.ContentType.Contains("image");
        }

        public bool LengthIsSuitable(IFormFile file, int value)
        {
            return file.Length / 1024 < value ? true : false;
        }
    }
}

