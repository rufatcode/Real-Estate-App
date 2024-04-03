using System;
using RealEstate_API.Dtos.CategoryDtos;
using RealEstate_API.Dtos.ContactDtos;

namespace RealEstate_API.Repositories.ContactRepository
{
	public interface IContactRepository
	{
        Task<List<ResoultContactDto>> GetAllCategoryAsync();
        Task<ResoultContactDto> GetCategoryById(int id);
        Task Create(CreateContactDto createContactDto);
        Task<int> Delete(int id);
        Task<int> Update(UpdateContactDto updateContactDto);
    }
}

