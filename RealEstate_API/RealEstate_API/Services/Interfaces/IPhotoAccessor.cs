using System;
using CloudinaryDotNet.Actions;

namespace RealEstate_API.Services.Interfaces
{
	public interface IPhotoAccessor
	{
        Task<ImageUploadResult> AddPhoto(IFormFile file);
        Task<DeletionResult> DeletePhoto(string publicId);
    }
}

