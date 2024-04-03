using System;
namespace RealEstate_API.Services.Interfaces
{
	public interface IFileService
	{
        bool LengthIsSuitable(IFormFile file, int value);
        bool IsImage(IFormFile file);
    }
}

